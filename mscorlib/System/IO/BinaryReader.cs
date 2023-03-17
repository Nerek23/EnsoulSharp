﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System.IO
{
	/// <summary>Reads primitive data types as binary values in a specific encoding.</summary>
	// Token: 0x02000177 RID: 375
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public class BinaryReader : IDisposable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.IO.BinaryReader" /> class based on the specified stream and using UTF-8 encoding.</summary>
		/// <param name="input">The input stream.</param>
		/// <exception cref="T:System.ArgumentException">The stream does not support reading, is <see langword="null" />, or is already closed.</exception>
		// Token: 0x06001699 RID: 5785 RVA: 0x000476E9 File Offset: 0x000458E9
		[__DynamicallyInvokable]
		public BinaryReader(Stream input) : this(input, new UTF8Encoding(), false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.BinaryReader" /> class based on the specified stream and character encoding.</summary>
		/// <param name="input">The input stream.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <exception cref="T:System.ArgumentException">The stream does not support reading, is <see langword="null" />, or is already closed.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="encoding" /> is <see langword="null" />.</exception>
		// Token: 0x0600169A RID: 5786 RVA: 0x000476F8 File Offset: 0x000458F8
		[__DynamicallyInvokable]
		public BinaryReader(Stream input, Encoding encoding) : this(input, encoding, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.BinaryReader" /> class based on the specified stream and character encoding, and optionally leaves the stream open.</summary>
		/// <param name="input">The input stream.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="leaveOpen">
		///   <see langword="true" /> to leave the stream open after the <see cref="T:System.IO.BinaryReader" /> object is disposed; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentException">The stream does not support reading, is <see langword="null" />, or is already closed.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="encoding" /> or <paramref name="input" /> is <see langword="null" />.</exception>
		// Token: 0x0600169B RID: 5787 RVA: 0x00047704 File Offset: 0x00045904
		[__DynamicallyInvokable]
		public BinaryReader(Stream input, Encoding encoding, bool leaveOpen)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (!input.CanRead)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotReadable"));
			}
			this.m_stream = input;
			this.m_decoder = encoding.GetDecoder();
			this.m_maxCharsSize = encoding.GetMaxCharCount(128);
			int num = encoding.GetMaxByteCount(1);
			if (num < 16)
			{
				num = 16;
			}
			this.m_buffer = new byte[num];
			this.m_2BytesPerChar = (encoding is UnicodeEncoding);
			this.m_isMemoryStream = (this.m_stream.GetType() == typeof(MemoryStream));
			this.m_leaveOpen = leaveOpen;
		}

		/// <summary>Exposes access to the underlying stream of the <see cref="T:System.IO.BinaryReader" />.</summary>
		/// <returns>The underlying stream associated with the <see langword="BinaryReader" />.</returns>
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x0600169C RID: 5788 RVA: 0x000477C1 File Offset: 0x000459C1
		[__DynamicallyInvokable]
		public virtual Stream BaseStream
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_stream;
			}
		}

		/// <summary>Closes the current reader and the underlying stream.</summary>
		// Token: 0x0600169D RID: 5789 RVA: 0x000477C9 File Offset: 0x000459C9
		public virtual void Close()
		{
			this.Dispose(true);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.IO.BinaryReader" /> class and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x0600169E RID: 5790 RVA: 0x000477D4 File Offset: 0x000459D4
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				Stream stream = this.m_stream;
				this.m_stream = null;
				if (stream != null && !this.m_leaveOpen)
				{
					stream.Close();
				}
			}
			this.m_stream = null;
			this.m_buffer = null;
			this.m_decoder = null;
			this.m_charBytes = null;
			this.m_singleChar = null;
			this.m_charBuffer = null;
		}

		/// <summary>Releases all resources used by the current instance of the <see cref="T:System.IO.BinaryReader" /> class.</summary>
		// Token: 0x0600169F RID: 5791 RVA: 0x0004782D File Offset: 0x00045A2D
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
		}

		/// <summary>Returns the next available character and does not advance the byte or character position.</summary>
		/// <returns>The next available character, or -1 if no more characters are available or the stream does not support seeking.</returns>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ArgumentException">The current character cannot be decoded into the internal character buffer by using the <see cref="T:System.Text.Encoding" /> selected for the stream.</exception>
		// Token: 0x060016A0 RID: 5792 RVA: 0x00047838 File Offset: 0x00045A38
		[__DynamicallyInvokable]
		public virtual int PeekChar()
		{
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			if (!this.m_stream.CanSeek)
			{
				return -1;
			}
			long position = this.m_stream.Position;
			int result = this.Read();
			this.m_stream.Position = position;
			return result;
		}

		/// <summary>Reads characters from the underlying stream and advances the current position of the stream in accordance with the <see langword="Encoding" /> used and the specific character being read from the stream.</summary>
		/// <returns>The next character from the input stream, or -1 if no characters are currently available.</returns>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		// Token: 0x060016A1 RID: 5793 RVA: 0x00047881 File Offset: 0x00045A81
		[__DynamicallyInvokable]
		public virtual int Read()
		{
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			return this.InternalReadOneChar();
		}

		/// <summary>Reads a <see langword="Boolean" /> value from the current stream and advances the current position of the stream by one byte.</summary>
		/// <returns>
		///   <see langword="true" /> if the byte is nonzero; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A2 RID: 5794 RVA: 0x00047896 File Offset: 0x00045A96
		[__DynamicallyInvokable]
		public virtual bool ReadBoolean()
		{
			this.FillBuffer(1);
			return this.m_buffer[0] > 0;
		}

		/// <summary>Reads the next byte from the current stream and advances the current position of the stream by one byte.</summary>
		/// <returns>The next byte read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A3 RID: 5795 RVA: 0x000478AC File Offset: 0x00045AAC
		[__DynamicallyInvokable]
		public virtual byte ReadByte()
		{
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			int num = this.m_stream.ReadByte();
			if (num == -1)
			{
				__Error.EndOfFile();
			}
			return (byte)num;
		}

		/// <summary>Reads a signed byte from this stream and advances the current position of the stream by one byte.</summary>
		/// <returns>A signed byte read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A4 RID: 5796 RVA: 0x000478DD File Offset: 0x00045ADD
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual sbyte ReadSByte()
		{
			this.FillBuffer(1);
			return (sbyte)this.m_buffer[0];
		}

		/// <summary>Reads the next character from the current stream and advances the current position of the stream in accordance with the <see langword="Encoding" /> used and the specific character being read from the stream.</summary>
		/// <returns>A character read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ArgumentException">A surrogate character was read.</exception>
		// Token: 0x060016A5 RID: 5797 RVA: 0x000478F0 File Offset: 0x00045AF0
		[__DynamicallyInvokable]
		public virtual char ReadChar()
		{
			int num = this.Read();
			if (num == -1)
			{
				__Error.EndOfFile();
			}
			return (char)num;
		}

		/// <summary>Reads a 2-byte signed integer from the current stream and advances the current position of the stream by two bytes.</summary>
		/// <returns>A 2-byte signed integer read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A6 RID: 5798 RVA: 0x0004790F File Offset: 0x00045B0F
		[__DynamicallyInvokable]
		public virtual short ReadInt16()
		{
			this.FillBuffer(2);
			return (short)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8);
		}

		/// <summary>Reads a 2-byte unsigned integer from the current stream using little-endian encoding and advances the position of the stream by two bytes.</summary>
		/// <returns>A 2-byte unsigned integer read from this stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A7 RID: 5799 RVA: 0x0004792C File Offset: 0x00045B2C
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual ushort ReadUInt16()
		{
			this.FillBuffer(2);
			return (ushort)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8);
		}

		/// <summary>Reads a 4-byte signed integer from the current stream and advances the current position of the stream by four bytes.</summary>
		/// <returns>A 4-byte signed integer read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A8 RID: 5800 RVA: 0x0004794C File Offset: 0x00045B4C
		[__DynamicallyInvokable]
		public virtual int ReadInt32()
		{
			if (this.m_isMemoryStream)
			{
				if (this.m_stream == null)
				{
					__Error.FileNotOpen();
				}
				MemoryStream memoryStream = this.m_stream as MemoryStream;
				return memoryStream.InternalReadInt32();
			}
			this.FillBuffer(4);
			return (int)this.m_buffer[0] | (int)this.m_buffer[1] << 8 | (int)this.m_buffer[2] << 16 | (int)this.m_buffer[3] << 24;
		}

		/// <summary>Reads a 4-byte unsigned integer from the current stream and advances the position of the stream by four bytes.</summary>
		/// <returns>A 4-byte unsigned integer read from this stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016A9 RID: 5801 RVA: 0x000479B3 File Offset: 0x00045BB3
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual uint ReadUInt32()
		{
			this.FillBuffer(4);
			return (uint)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8 | (int)this.m_buffer[2] << 16 | (int)this.m_buffer[3] << 24);
		}

		/// <summary>Reads an 8-byte signed integer from the current stream and advances the current position of the stream by eight bytes.</summary>
		/// <returns>An 8-byte signed integer read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016AA RID: 5802 RVA: 0x000479E8 File Offset: 0x00045BE8
		[__DynamicallyInvokable]
		public virtual long ReadInt64()
		{
			this.FillBuffer(8);
			uint num = (uint)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8 | (int)this.m_buffer[2] << 16 | (int)this.m_buffer[3] << 24);
			uint num2 = (uint)((int)this.m_buffer[4] | (int)this.m_buffer[5] << 8 | (int)this.m_buffer[6] << 16 | (int)this.m_buffer[7] << 24);
			return (long)((ulong)num2 << 32 | (ulong)num);
		}

		/// <summary>Reads an 8-byte unsigned integer from the current stream and advances the position of the stream by eight bytes.</summary>
		/// <returns>An 8-byte unsigned integer read from this stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		// Token: 0x060016AB RID: 5803 RVA: 0x00047A5C File Offset: 0x00045C5C
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual ulong ReadUInt64()
		{
			this.FillBuffer(8);
			uint num = (uint)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8 | (int)this.m_buffer[2] << 16 | (int)this.m_buffer[3] << 24);
			uint num2 = (uint)((int)this.m_buffer[4] | (int)this.m_buffer[5] << 8 | (int)this.m_buffer[6] << 16 | (int)this.m_buffer[7] << 24);
			return (ulong)num2 << 32 | (ulong)num;
		}

		/// <summary>Reads a 4-byte floating point value from the current stream and advances the current position of the stream by four bytes.</summary>
		/// <returns>A 4-byte floating point value read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016AC RID: 5804 RVA: 0x00047AD0 File Offset: 0x00045CD0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe virtual float ReadSingle()
		{
			this.FillBuffer(4);
			uint num = (uint)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8 | (int)this.m_buffer[2] << 16 | (int)this.m_buffer[3] << 24);
			return *(float*)(&num);
		}

		/// <summary>Reads an 8-byte floating point value from the current stream and advances the current position of the stream by eight bytes.</summary>
		/// <returns>An 8-byte floating point value read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016AD RID: 5805 RVA: 0x00047B14 File Offset: 0x00045D14
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe virtual double ReadDouble()
		{
			this.FillBuffer(8);
			uint num = (uint)((int)this.m_buffer[0] | (int)this.m_buffer[1] << 8 | (int)this.m_buffer[2] << 16 | (int)this.m_buffer[3] << 24);
			uint num2 = (uint)((int)this.m_buffer[4] | (int)this.m_buffer[5] << 8 | (int)this.m_buffer[6] << 16 | (int)this.m_buffer[7] << 24);
			ulong num3 = (ulong)num2 << 32 | (ulong)num;
			return *(double*)(&num3);
		}

		/// <summary>Reads a decimal value from the current stream and advances the current position of the stream by sixteen bytes.</summary>
		/// <returns>A decimal value read from the current stream.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016AE RID: 5806 RVA: 0x00047B90 File Offset: 0x00045D90
		[__DynamicallyInvokable]
		public virtual decimal ReadDecimal()
		{
			this.FillBuffer(16);
			decimal result;
			try
			{
				result = decimal.ToDecimal(this.m_buffer);
			}
			catch (ArgumentException innerException)
			{
				throw new IOException(Environment.GetResourceString("Arg_DecBitCtor"), innerException);
			}
			return result;
		}

		/// <summary>Reads a string from the current stream. The string is prefixed with the length, encoded as an integer seven bits at a time.</summary>
		/// <returns>The string being read.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016AF RID: 5807 RVA: 0x00047BD8 File Offset: 0x00045DD8
		[__DynamicallyInvokable]
		public virtual string ReadString()
		{
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			int num = 0;
			int num2 = this.Read7BitEncodedInt();
			if (num2 < 0)
			{
				throw new IOException(Environment.GetResourceString("IO.IO_InvalidStringLen_Len", new object[]
				{
					num2
				}));
			}
			if (num2 == 0)
			{
				return string.Empty;
			}
			if (this.m_charBytes == null)
			{
				this.m_charBytes = new byte[128];
			}
			if (this.m_charBuffer == null)
			{
				this.m_charBuffer = new char[this.m_maxCharsSize];
			}
			StringBuilder stringBuilder = null;
			int chars;
			for (;;)
			{
				int count = (num2 - num > 128) ? 128 : (num2 - num);
				int num3 = this.m_stream.Read(this.m_charBytes, 0, count);
				if (num3 == 0)
				{
					__Error.EndOfFile();
				}
				chars = this.m_decoder.GetChars(this.m_charBytes, 0, num3, this.m_charBuffer, 0);
				if (num == 0 && num3 == num2)
				{
					break;
				}
				if (stringBuilder == null)
				{
					stringBuilder = StringBuilderCache.Acquire(Math.Min(num2, 360));
				}
				stringBuilder.Append(this.m_charBuffer, 0, chars);
				num += num3;
				if (num >= num2)
				{
					goto Block_11;
				}
			}
			return new string(this.m_charBuffer, 0, chars);
			Block_11:
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		/// <summary>Reads the specified number of characters from the stream, starting from a specified point in the character array.</summary>
		/// <param name="buffer">The buffer to read data into.</param>
		/// <param name="index">The starting point in the buffer at which to begin reading into the buffer.</param>
		/// <param name="count">The number of characters to read.</param>
		/// <returns>The total number of characters read into the buffer. This might be less than the number of characters requested if that many characters are not currently available, or it might be zero if the end of the stream is reached.</returns>
		/// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index" /> is less than <paramref name="count" />.  
		///  -or-  
		///  The number of decoded characters to read is greater than <paramref name="count" />. This can happen if a Unicode decoder returns fallback characters or a surrogate pair.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016B0 RID: 5808 RVA: 0x00047CF8 File Offset: 0x00045EF8
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public virtual int Read(char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			return this.InternalReadChars(buffer, index, count);
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x00047D80 File Offset: 0x00045F80
		[SecurityCritical]
		private unsafe int InternalReadChars(char[] buffer, int index, int count)
		{
			int i = count;
			if (this.m_charBytes == null)
			{
				this.m_charBytes = new byte[128];
			}
			while (i > 0)
			{
				int num = i;
				DecoderNLS decoderNLS = this.m_decoder as DecoderNLS;
				if (decoderNLS != null && decoderNLS.HasState && num > 1)
				{
					num--;
				}
				if (this.m_2BytesPerChar)
				{
					num <<= 1;
				}
				if (num > 128)
				{
					num = 128;
				}
				int num2 = 0;
				byte[] array;
				if (this.m_isMemoryStream)
				{
					MemoryStream memoryStream = this.m_stream as MemoryStream;
					num2 = memoryStream.InternalGetPosition();
					num = memoryStream.InternalEmulateRead(num);
					array = memoryStream.InternalGetBuffer();
				}
				else
				{
					num = this.m_stream.Read(this.m_charBytes, 0, num);
					array = this.m_charBytes;
				}
				if (num == 0)
				{
					return count - i;
				}
				int chars;
				checked
				{
					if (num2 < 0 || num < 0 || num2 + num > array.Length)
					{
						throw new ArgumentOutOfRangeException("byteCount");
					}
					if (index < 0 || i < 0 || index + i > buffer.Length)
					{
						throw new ArgumentOutOfRangeException("charsRemaining");
					}
					fixed (byte* ptr = array)
					{
						fixed (char* ptr2 = buffer)
						{
							chars = this.m_decoder.GetChars(ptr + num2, num, ptr2 + index, i, false);
						}
					}
				}
				i -= chars;
				index += chars;
			}
			return count - i;
		}

		// Token: 0x060016B2 RID: 5810 RVA: 0x00047EF4 File Offset: 0x000460F4
		private int InternalReadOneChar()
		{
			int num = 0;
			long num2 = num2 = 0L;
			if (this.m_stream.CanSeek)
			{
				num2 = this.m_stream.Position;
			}
			if (this.m_charBytes == null)
			{
				this.m_charBytes = new byte[128];
			}
			if (this.m_singleChar == null)
			{
				this.m_singleChar = new char[1];
			}
			while (num == 0)
			{
				int num3 = this.m_2BytesPerChar ? 2 : 1;
				int num4 = this.m_stream.ReadByte();
				this.m_charBytes[0] = (byte)num4;
				if (num4 == -1)
				{
					num3 = 0;
				}
				if (num3 == 2)
				{
					num4 = this.m_stream.ReadByte();
					this.m_charBytes[1] = (byte)num4;
					if (num4 == -1)
					{
						num3 = 1;
					}
				}
				if (num3 == 0)
				{
					return -1;
				}
				try
				{
					num = this.m_decoder.GetChars(this.m_charBytes, 0, num3, this.m_singleChar, 0);
				}
				catch
				{
					if (this.m_stream.CanSeek)
					{
						this.m_stream.Seek(num2 - this.m_stream.Position, SeekOrigin.Current);
					}
					throw;
				}
			}
			if (num == 0)
			{
				return -1;
			}
			return (int)this.m_singleChar[0];
		}

		/// <summary>Reads the specified number of characters from the current stream, returns the data in a character array, and advances the current position in accordance with the <see langword="Encoding" /> used and the specific character being read from the stream.</summary>
		/// <param name="count">The number of characters to read.</param>
		/// <returns>A character array containing data read from the underlying stream. This might be less than the number of characters requested if the end of the stream is reached.</returns>
		/// <exception cref="T:System.ArgumentException">The number of decoded characters to read is greater than <paramref name="count" />. This can happen if a Unicode decoder returns fallback characters or a surrogate pair.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.</exception>
		// Token: 0x060016B3 RID: 5811 RVA: 0x00048010 File Offset: 0x00046210
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public virtual char[] ReadChars(int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			if (count == 0)
			{
				return EmptyArray<char>.Value;
			}
			char[] array = new char[count];
			int num = this.InternalReadChars(array, 0, count);
			if (num != count)
			{
				char[] array2 = new char[num];
				Buffer.InternalBlockCopy(array, 0, array2, 0, 2 * num);
				array = array2;
			}
			return array;
		}

		/// <summary>Reads the specified number of bytes from the stream, starting from a specified point in the byte array.</summary>
		/// <param name="buffer">The buffer to read data into.</param>
		/// <param name="index">The starting point in the buffer at which to begin reading into the buffer.</param>
		/// <param name="count">The number of bytes to read.</param>
		/// <returns>The number of bytes read into <paramref name="buffer" />. This might be less than the number of bytes requested if that many bytes are not available, or it might be zero if the end of the stream is reached.</returns>
		/// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index" /> is less than <paramref name="count" />.  
		///  -or-  
		///  The number of decoded characters to read is greater than <paramref name="count" />. This can happen if a Unicode decoder returns fallback characters or a surrogate pair.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060016B4 RID: 5812 RVA: 0x00048078 File Offset: 0x00046278
		[__DynamicallyInvokable]
		public virtual int Read(byte[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			return this.m_stream.Read(buffer, index, count);
		}

		/// <summary>Reads the specified number of bytes from the current stream into a byte array and advances the current position by that number of bytes.</summary>
		/// <param name="count">The number of bytes to read. This value must be 0 or a non-negative number or an exception will occur.</param>
		/// <returns>A byte array containing data read from the underlying stream. This might be less than the number of bytes requested if the end of the stream is reached.</returns>
		/// <exception cref="T:System.ArgumentException">The number of decoded characters to read is greater than <paramref name="count" />. This can happen if a Unicode decoder returns fallback characters or a surrogate pair.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is negative.</exception>
		// Token: 0x060016B5 RID: 5813 RVA: 0x00048104 File Offset: 0x00046304
		[__DynamicallyInvokable]
		public virtual byte[] ReadBytes(int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			if (count == 0)
			{
				return EmptyArray<byte>.Value;
			}
			byte[] array = new byte[count];
			int num = 0;
			do
			{
				int num2 = this.m_stream.Read(array, num, count);
				if (num2 == 0)
				{
					break;
				}
				num += num2;
				count -= num2;
			}
			while (count > 0);
			if (num != array.Length)
			{
				byte[] array2 = new byte[num];
				Buffer.InternalBlockCopy(array, 0, array2, 0, num);
				array = array2;
			}
			return array;
		}

		/// <summary>Fills the internal buffer with the specified number of bytes read from the stream.</summary>
		/// <param name="numBytes">The number of bytes to be read.</param>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached before <paramref name="numBytes" /> could be read.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">Requested <paramref name="numBytes" /> is larger than the internal buffer size.</exception>
		// Token: 0x060016B6 RID: 5814 RVA: 0x00048184 File Offset: 0x00046384
		[__DynamicallyInvokable]
		protected virtual void FillBuffer(int numBytes)
		{
			if (this.m_buffer != null && (numBytes < 0 || numBytes > this.m_buffer.Length))
			{
				throw new ArgumentOutOfRangeException("numBytes", Environment.GetResourceString("ArgumentOutOfRange_BinaryReaderFillBuffer"));
			}
			int num = 0;
			if (this.m_stream == null)
			{
				__Error.FileNotOpen();
			}
			if (numBytes == 1)
			{
				int num2 = this.m_stream.ReadByte();
				if (num2 == -1)
				{
					__Error.EndOfFile();
				}
				this.m_buffer[0] = (byte)num2;
				return;
			}
			do
			{
				int num2 = this.m_stream.Read(this.m_buffer, num, numBytes - num);
				if (num2 == 0)
				{
					__Error.EndOfFile();
				}
				num += num2;
			}
			while (num < numBytes);
		}

		/// <summary>Reads in a 32-bit integer in compressed format.</summary>
		/// <returns>A 32-bit integer in compressed format.</returns>
		/// <exception cref="T:System.IO.EndOfStreamException">The end of the stream is reached.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.FormatException">The stream is corrupted.</exception>
		// Token: 0x060016B7 RID: 5815 RVA: 0x00048218 File Offset: 0x00046418
		[__DynamicallyInvokable]
		protected internal int Read7BitEncodedInt()
		{
			int num = 0;
			int num2 = 0;
			while (num2 != 35)
			{
				byte b = this.ReadByte();
				num |= (int)(b & 127) << num2;
				num2 += 7;
				if ((b & 128) == 0)
				{
					return num;
				}
			}
			throw new FormatException(Environment.GetResourceString("Format_Bad7BitInt32"));
		}

		// Token: 0x040007FA RID: 2042
		private const int MaxCharBytesSize = 128;

		// Token: 0x040007FB RID: 2043
		private Stream m_stream;

		// Token: 0x040007FC RID: 2044
		private byte[] m_buffer;

		// Token: 0x040007FD RID: 2045
		private Decoder m_decoder;

		// Token: 0x040007FE RID: 2046
		private byte[] m_charBytes;

		// Token: 0x040007FF RID: 2047
		private char[] m_singleChar;

		// Token: 0x04000800 RID: 2048
		private char[] m_charBuffer;

		// Token: 0x04000801 RID: 2049
		private int m_maxCharsSize;

		// Token: 0x04000802 RID: 2050
		private bool m_2BytesPerChar;

		// Token: 0x04000803 RID: 2051
		private bool m_isMemoryStream;

		// Token: 0x04000804 RID: 2052
		private bool m_leaveOpen;
	}
}
