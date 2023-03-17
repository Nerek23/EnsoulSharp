using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
	/// <summary>Implements a <see cref="T:System.IO.TextWriter" /> for writing characters to a stream in a particular encoding.</summary>
	// Token: 0x020001A3 RID: 419
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class StreamWriter : TextWriter
	{
		// Token: 0x060019E1 RID: 6625 RVA: 0x000563F4 File Offset: 0x000545F4
		private void CheckAsyncTaskInProgress()
		{
			Task asyncWriteTask = this._asyncWriteTask;
			if (asyncWriteTask != null && !asyncWriteTask.IsCompleted)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_AsyncIOInProgress"));
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060019E2 RID: 6626 RVA: 0x00056428 File Offset: 0x00054628
		internal static Encoding UTF8NoBOM
		{
			[FriendAccessAllowed]
			get
			{
				if (StreamWriter._UTF8NoBOM == null)
				{
					UTF8Encoding utf8NoBOM = new UTF8Encoding(false, true);
					Thread.MemoryBarrier();
					StreamWriter._UTF8NoBOM = utf8NoBOM;
				}
				return StreamWriter._UTF8NoBOM;
			}
		}

		// Token: 0x060019E3 RID: 6627 RVA: 0x0005645A File Offset: 0x0005465A
		internal StreamWriter() : base(null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by using UTF-8 encoding and the default buffer size.</summary>
		/// <param name="stream">The stream to write to.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="stream" /> is not writable.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stream" /> is <see langword="null" />.</exception>
		// Token: 0x060019E4 RID: 6628 RVA: 0x00056463 File Offset: 0x00054663
		[__DynamicallyInvokable]
		public StreamWriter(Stream stream) : this(stream, StreamWriter.UTF8NoBOM, 1024, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by using the specified encoding and the default buffer size.</summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stream" /> or <paramref name="encoding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="stream" /> is not writable.</exception>
		// Token: 0x060019E5 RID: 6629 RVA: 0x00056477 File Offset: 0x00054677
		[__DynamicallyInvokable]
		public StreamWriter(Stream stream, Encoding encoding) : this(stream, encoding, 1024, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by using the specified encoding and buffer size.</summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="bufferSize">The buffer size, in bytes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stream" /> or <paramref name="encoding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="bufferSize" /> is negative.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="stream" /> is not writable.</exception>
		// Token: 0x060019E6 RID: 6630 RVA: 0x00056487 File Offset: 0x00054687
		[__DynamicallyInvokable]
		public StreamWriter(Stream stream, Encoding encoding, int bufferSize) : this(stream, encoding, bufferSize, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified stream by using the specified encoding and buffer size, and optionally leaves the stream open.</summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="bufferSize">The buffer size, in bytes.</param>
		/// <param name="leaveOpen">
		///   <see langword="true" /> to leave the stream open after the <see cref="T:System.IO.StreamWriter" /> object is disposed; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="stream" /> or <paramref name="encoding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="bufferSize" /> is negative.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="stream" /> is not writable.</exception>
		// Token: 0x060019E7 RID: 6631 RVA: 0x00056494 File Offset: 0x00054694
		[__DynamicallyInvokable]
		public StreamWriter(Stream stream, Encoding encoding, int bufferSize, bool leaveOpen) : base(null)
		{
			if (stream == null || encoding == null)
			{
				throw new ArgumentNullException((stream == null) ? "stream" : "encoding");
			}
			if (!stream.CanWrite)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotWritable"));
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			this.Init(stream, encoding, bufferSize, leaveOpen);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified file by using the default encoding and buffer size.</summary>
		/// <param name="path">The complete file path to write to. <paramref name="path" /> can be a file name.</param>
		/// <exception cref="T:System.UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="path" /> is an empty string ("").  
		/// -or-  
		/// <paramref name="path" /> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="path" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
		/// <exception cref="T:System.IO.IOException">
		///   <paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x060019E8 RID: 6632 RVA: 0x000564FF File Offset: 0x000546FF
		public StreamWriter(string path) : this(path, false, StreamWriter.UTF8NoBOM, 1024)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified file by using the default encoding and buffer size. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.</summary>
		/// <param name="path">The complete file path to write to.</param>
		/// <param name="append">
		///   <see langword="true" /> to append data to the file; <see langword="false" /> to overwrite the file. If the specified file does not exist, this parameter has no effect, and the constructor creates a new file.</param>
		/// <exception cref="T:System.UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="path" /> is empty.  
		/// -or-  
		/// <paramref name="path" /> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="path" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
		/// <exception cref="T:System.IO.IOException">
		///   <paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x060019E9 RID: 6633 RVA: 0x00056513 File Offset: 0x00054713
		public StreamWriter(string path, bool append) : this(path, append, StreamWriter.UTF8NoBOM, 1024)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified file by using the specified encoding and default buffer size. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.</summary>
		/// <param name="path">The complete file path to write to.</param>
		/// <param name="append">
		///   <see langword="true" /> to append data to the file; <see langword="false" /> to overwrite the file. If the specified file does not exist, this parameter has no effect, and the constructor creates a new file.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <exception cref="T:System.UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="path" /> is empty.  
		/// -or-  
		/// <paramref name="path" /> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="path" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
		/// <exception cref="T:System.IO.IOException">
		///   <paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x060019EA RID: 6634 RVA: 0x00056527 File Offset: 0x00054727
		public StreamWriter(string path, bool append, Encoding encoding) : this(path, append, encoding, 1024)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.StreamWriter" /> class for the specified file on the specified path, using the specified encoding and buffer size. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.</summary>
		/// <param name="path">The complete file path to write to.</param>
		/// <param name="append">
		///   <see langword="true" /> to append data to the file; <see langword="false" /> to overwrite the file. If the specified file does not exist, this parameter has no effect, and the constructor creates a new file.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="bufferSize">The buffer size, in bytes.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="path" /> is an empty string ("").  
		/// -or-  
		/// <paramref name="path" /> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="path" /> or <paramref name="encoding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="bufferSize" /> is negative.</exception>
		/// <exception cref="T:System.IO.IOException">
		///   <paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="T:System.IO.DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
		/// <exception cref="T:System.IO.PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
		// Token: 0x060019EB RID: 6635 RVA: 0x00056537 File Offset: 0x00054737
		[SecuritySafeCritical]
		public StreamWriter(string path, bool append, Encoding encoding, int bufferSize) : this(path, append, encoding, bufferSize, true)
		{
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x00056548 File Offset: 0x00054748
		[SecurityCritical]
		internal StreamWriter(string path, bool append, Encoding encoding, int bufferSize, bool checkHost) : base(null)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			Stream streamArg = StreamWriter.CreateFile(path, append, checkHost);
			this.Init(streamArg, encoding, bufferSize, false);
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x000565C0 File Offset: 0x000547C0
		[SecuritySafeCritical]
		private void Init(Stream streamArg, Encoding encodingArg, int bufferSize, bool shouldLeaveOpen)
		{
			this.stream = streamArg;
			this.encoding = encodingArg;
			this.encoder = this.encoding.GetEncoder();
			if (bufferSize < 128)
			{
				bufferSize = 128;
			}
			this.charBuffer = new char[bufferSize];
			this.byteBuffer = new byte[this.encoding.GetMaxByteCount(bufferSize)];
			this.charLen = bufferSize;
			if (this.stream.CanSeek && this.stream.Position > 0L)
			{
				this.haveWrittenPreamble = true;
			}
			this.closable = !shouldLeaveOpen;
			if (Mda.StreamWriterBufferedDataLost.Enabled)
			{
				string cs = null;
				if (Mda.StreamWriterBufferedDataLost.CaptureAllocatedCallStack)
				{
					cs = Environment.GetStackTrace(null, false);
				}
				this.mdaHelper = new StreamWriter.MdaHelper(this, cs);
			}
		}

		// Token: 0x060019EE RID: 6638 RVA: 0x00056678 File Offset: 0x00054878
		[SecurityCritical]
		private static Stream CreateFile(string path, bool append, bool checkHost)
		{
			FileMode mode = append ? FileMode.Append : FileMode.Create;
			return new FileStream(path, mode, FileAccess.Write, FileShare.Read, 4096, FileOptions.SequentialScan, Path.GetFileName(path), false, false, checkHost);
		}

		/// <summary>Closes the current <see langword="StreamWriter" /> object and the underlying stream.</summary>
		/// <exception cref="T:System.Text.EncoderFallbackException">The current encoding does not support displaying half of a Unicode surrogate pair.</exception>
		// Token: 0x060019EF RID: 6639 RVA: 0x000566AB File Offset: 0x000548AB
		public override void Close()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.IO.StreamWriter" /> and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		/// <exception cref="T:System.Text.EncoderFallbackException">The current encoding does not support displaying half of a Unicode surrogate pair.</exception>
		// Token: 0x060019F0 RID: 6640 RVA: 0x000566BC File Offset: 0x000548BC
		[__DynamicallyInvokable]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (this.stream != null && (disposing || (this.LeaveOpen && this.stream is __ConsoleStream)))
				{
					this.CheckAsyncTaskInProgress();
					this.Flush(true, true);
					if (this.mdaHelper != null)
					{
						GC.SuppressFinalize(this.mdaHelper);
					}
				}
			}
			finally
			{
				if (!this.LeaveOpen && this.stream != null)
				{
					try
					{
						if (disposing)
						{
							this.stream.Close();
						}
					}
					finally
					{
						this.stream = null;
						this.byteBuffer = null;
						this.charBuffer = null;
						this.encoding = null;
						this.encoder = null;
						this.charLen = 0;
						base.Dispose(disposing);
					}
				}
			}
		}

		/// <summary>Clears all buffers for the current writer and causes any buffered data to be written to the underlying stream.</summary>
		/// <exception cref="T:System.ObjectDisposedException">The current writer is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error has occurred.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">The current encoding does not support displaying half of a Unicode surrogate pair.</exception>
		// Token: 0x060019F1 RID: 6641 RVA: 0x0005677C File Offset: 0x0005497C
		[__DynamicallyInvokable]
		public override void Flush()
		{
			this.CheckAsyncTaskInProgress();
			this.Flush(true, true);
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x0005678C File Offset: 0x0005498C
		private void Flush(bool flushStream, bool flushEncoder)
		{
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			if (this.charPos == 0 && ((!flushStream && !flushEncoder) || CompatibilitySwitches.IsAppEarlierThanWindowsPhone8))
			{
				return;
			}
			if (!this.haveWrittenPreamble)
			{
				this.haveWrittenPreamble = true;
				byte[] preamble = this.encoding.GetPreamble();
				if (preamble.Length != 0)
				{
					this.stream.Write(preamble, 0, preamble.Length);
				}
			}
			int bytes = this.encoder.GetBytes(this.charBuffer, 0, this.charPos, this.byteBuffer, 0, flushEncoder);
			this.charPos = 0;
			if (bytes > 0)
			{
				this.stream.Write(this.byteBuffer, 0, bytes);
			}
			if (flushStream)
			{
				this.stream.Flush();
			}
		}

		/// <summary>Gets or sets a value indicating whether the <see cref="T:System.IO.StreamWriter" /> will flush its buffer to the underlying stream after every call to <see cref="M:System.IO.StreamWriter.Write(System.Char)" />.</summary>
		/// <returns>
		///   <see langword="true" /> to force <see cref="T:System.IO.StreamWriter" /> to flush its buffer; otherwise, <see langword="false" />.</returns>
		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060019F3 RID: 6643 RVA: 0x00056838 File Offset: 0x00054A38
		// (set) Token: 0x060019F4 RID: 6644 RVA: 0x00056840 File Offset: 0x00054A40
		[__DynamicallyInvokable]
		public virtual bool AutoFlush
		{
			[__DynamicallyInvokable]
			get
			{
				return this.autoFlush;
			}
			[__DynamicallyInvokable]
			set
			{
				this.CheckAsyncTaskInProgress();
				this.autoFlush = value;
				if (value)
				{
					this.Flush(true, false);
				}
			}
		}

		/// <summary>Gets the underlying stream that interfaces with a backing store.</summary>
		/// <returns>The stream this <see langword="StreamWriter" /> is writing to.</returns>
		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x0005685A File Offset: 0x00054A5A
		[__DynamicallyInvokable]
		public virtual Stream BaseStream
		{
			[__DynamicallyInvokable]
			get
			{
				return this.stream;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060019F6 RID: 6646 RVA: 0x00056862 File Offset: 0x00054A62
		internal bool LeaveOpen
		{
			get
			{
				return !this.closable;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (set) Token: 0x060019F7 RID: 6647 RVA: 0x0005686D File Offset: 0x00054A6D
		internal bool HaveWrittenPreamble
		{
			set
			{
				this.haveWrittenPreamble = value;
			}
		}

		/// <summary>Gets the <see cref="T:System.Text.Encoding" /> in which the output is written.</summary>
		/// <returns>The <see cref="T:System.Text.Encoding" /> specified in the constructor for the current instance, or <see cref="T:System.Text.UTF8Encoding" /> if an encoding was not specified.</returns>
		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060019F8 RID: 6648 RVA: 0x00056876 File Offset: 0x00054A76
		[__DynamicallyInvokable]
		public override Encoding Encoding
		{
			[__DynamicallyInvokable]
			get
			{
				return this.encoding;
			}
		}

		/// <summary>Writes a character to the stream.</summary>
		/// <param name="value">The character to write to the stream.</param>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and current writer is closed.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter" /> is at the end the stream.</exception>
		// Token: 0x060019F9 RID: 6649 RVA: 0x00056880 File Offset: 0x00054A80
		[__DynamicallyInvokable]
		public override void Write(char value)
		{
			this.CheckAsyncTaskInProgress();
			if (this.charPos == this.charLen)
			{
				this.Flush(false, false);
			}
			this.charBuffer[this.charPos] = value;
			this.charPos++;
			if (this.autoFlush)
			{
				this.Flush(true, false);
			}
		}

		/// <summary>Writes a character array to the stream.</summary>
		/// <param name="buffer">A character array containing the data to write. If <paramref name="buffer" /> is <see langword="null" />, nothing is written.</param>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and current writer is closed.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter" /> is at the end the stream.</exception>
		// Token: 0x060019FA RID: 6650 RVA: 0x000568D8 File Offset: 0x00054AD8
		[__DynamicallyInvokable]
		public override void Write(char[] buffer)
		{
			if (buffer == null)
			{
				return;
			}
			this.CheckAsyncTaskInProgress();
			int num = 0;
			int num2;
			for (int i = buffer.Length; i > 0; i -= num2)
			{
				if (this.charPos == this.charLen)
				{
					this.Flush(false, false);
				}
				num2 = this.charLen - this.charPos;
				if (num2 > i)
				{
					num2 = i;
				}
				Buffer.InternalBlockCopy(buffer, num * 2, this.charBuffer, this.charPos * 2, num2 * 2);
				this.charPos += num2;
				num += num2;
			}
			if (this.autoFlush)
			{
				this.Flush(true, false);
			}
		}

		/// <summary>Writes a subarray of characters to the stream.</summary>
		/// <param name="buffer">A character array that contains the data to write.</param>
		/// <param name="index">The character position in the buffer at which to start reading data.</param>
		/// <param name="count">The maximum number of characters to write.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index" /> is less than <paramref name="count" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and current writer is closed.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter" /> is at the end the stream.</exception>
		// Token: 0x060019FB RID: 6651 RVA: 0x00056968 File Offset: 0x00054B68
		[__DynamicallyInvokable]
		public override void Write(char[] buffer, int index, int count)
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
			this.CheckAsyncTaskInProgress();
			while (count > 0)
			{
				if (this.charPos == this.charLen)
				{
					this.Flush(false, false);
				}
				int num = this.charLen - this.charPos;
				if (num > count)
				{
					num = count;
				}
				Buffer.InternalBlockCopy(buffer, index * 2, this.charBuffer, this.charPos * 2, num * 2);
				this.charPos += num;
				index += num;
				count -= num;
			}
			if (this.autoFlush)
			{
				this.Flush(true, false);
			}
		}

		/// <summary>Writes a string to the stream.</summary>
		/// <param name="value">The string to write to the stream. If <paramref name="value" /> is null, nothing is written.</param>
		/// <exception cref="T:System.ObjectDisposedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and current writer is closed.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <see cref="P:System.IO.StreamWriter.AutoFlush" /> is true or the <see cref="T:System.IO.StreamWriter" /> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter" /> is at the end the stream.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x060019FC RID: 6652 RVA: 0x00056A50 File Offset: 0x00054C50
		[__DynamicallyInvokable]
		public override void Write(string value)
		{
			if (value != null)
			{
				this.CheckAsyncTaskInProgress();
				int i = value.Length;
				int num = 0;
				while (i > 0)
				{
					if (this.charPos == this.charLen)
					{
						this.Flush(false, false);
					}
					int num2 = this.charLen - this.charPos;
					if (num2 > i)
					{
						num2 = i;
					}
					value.CopyTo(num, this.charBuffer, this.charPos, num2);
					this.charPos += num2;
					num += num2;
					i -= num2;
				}
				if (this.autoFlush)
				{
					this.Flush(true, false);
				}
			}
		}

		/// <summary>Writes a character to the stream asynchronously.</summary>
		/// <param name="value">The character to write to the stream.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x060019FD RID: 6653 RVA: 0x00056ADC File Offset: 0x00054CDC
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteAsync(char value)
		{
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteAsync(value);
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = StreamWriter.WriteAsyncInternal(this, value, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, false);
			this._asyncWriteTask = task;
			return task;
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x00056B4C File Offset: 0x00054D4C
		private static async Task WriteAsyncInternal(StreamWriter _this, char value, char[] charBuffer, int charPos, int charLen, char[] coreNewLine, bool autoFlush, bool appendNewLine)
		{
			if (charPos == charLen)
			{
				await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
				charPos = 0;
			}
			charBuffer[charPos] = value;
			charPos++;
			if (appendNewLine)
			{
				for (int i = 0; i < coreNewLine.Length; i++)
				{
					if (charPos == charLen)
					{
						await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
						charPos = 0;
					}
					charBuffer[charPos] = coreNewLine[i];
					charPos++;
				}
			}
			if (autoFlush)
			{
				await _this.FlushAsyncInternal(true, false, charBuffer, charPos).ConfigureAwait(false);
				charPos = 0;
			}
			_this.CharPos_Prop = charPos;
		}

		/// <summary>Writes a string to the stream asynchronously.</summary>
		/// <param name="value">The string to write to the stream. If <paramref name="value" /> is <see langword="null" />, nothing is written.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x060019FF RID: 6655 RVA: 0x00056BD0 File Offset: 0x00054DD0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteAsync(string value)
		{
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteAsync(value);
			}
			if (value != null)
			{
				if (this.stream == null)
				{
					__Error.WriterClosed();
				}
				this.CheckAsyncTaskInProgress();
				Task task = StreamWriter.WriteAsyncInternal(this, value, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, false);
				this._asyncWriteTask = task;
				return task;
			}
			return Task.CompletedTask;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x00056C4C File Offset: 0x00054E4C
		private static async Task WriteAsyncInternal(StreamWriter _this, string value, char[] charBuffer, int charPos, int charLen, char[] coreNewLine, bool autoFlush, bool appendNewLine)
		{
			int count = value.Length;
			int index = 0;
			while (count > 0)
			{
				if (charPos == charLen)
				{
					await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
					charPos = 0;
				}
				int num = charLen - charPos;
				if (num > count)
				{
					num = count;
				}
				value.CopyTo(index, charBuffer, charPos, num);
				charPos += num;
				index += num;
				count -= num;
			}
			if (appendNewLine)
			{
				for (int i = 0; i < coreNewLine.Length; i++)
				{
					if (charPos == charLen)
					{
						await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
						charPos = 0;
					}
					charBuffer[charPos] = coreNewLine[i];
					charPos++;
				}
			}
			if (autoFlush)
			{
				await _this.FlushAsyncInternal(true, false, charBuffer, charPos).ConfigureAwait(false);
				charPos = 0;
			}
			_this.CharPos_Prop = charPos;
		}

		/// <summary>Writes a subarray of characters to the stream asynchronously.</summary>
		/// <param name="buffer">A character array that contains the data to write.</param>
		/// <param name="index">The character position in the buffer at which to begin reading data.</param>
		/// <param name="count">The maximum number of characters to write.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="index" /> plus <paramref name="count" /> is greater than the buffer length.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x06001A01 RID: 6657 RVA: 0x00056CD0 File Offset: 0x00054ED0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteAsync(char[] buffer, int index, int count)
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
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteAsync(buffer, index, count);
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = StreamWriter.WriteAsyncInternal(this, buffer, index, count, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, false);
			this._asyncWriteTask = task;
			return task;
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x00056DA8 File Offset: 0x00054FA8
		private static async Task WriteAsyncInternal(StreamWriter _this, char[] buffer, int index, int count, char[] charBuffer, int charPos, int charLen, char[] coreNewLine, bool autoFlush, bool appendNewLine)
		{
			while (count > 0)
			{
				if (charPos == charLen)
				{
					await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
					charPos = 0;
				}
				int num = charLen - charPos;
				if (num > count)
				{
					num = count;
				}
				Buffer.InternalBlockCopy(buffer, index * 2, charBuffer, charPos * 2, num * 2);
				charPos += num;
				index += num;
				count -= num;
			}
			if (appendNewLine)
			{
				for (int i = 0; i < coreNewLine.Length; i++)
				{
					if (charPos == charLen)
					{
						await _this.FlushAsyncInternal(false, false, charBuffer, charPos).ConfigureAwait(false);
						charPos = 0;
					}
					charBuffer[charPos] = coreNewLine[i];
					charPos++;
				}
			}
			if (autoFlush)
			{
				await _this.FlushAsyncInternal(true, false, charBuffer, charPos).ConfigureAwait(false);
				charPos = 0;
			}
			_this.CharPos_Prop = charPos;
		}

		/// <summary>Writes a line terminator asynchronously to the stream.</summary>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x06001A03 RID: 6659 RVA: 0x00056E3C File Offset: 0x0005503C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync()
		{
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteLineAsync();
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = StreamWriter.WriteAsyncInternal(this, null, 0, 0, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, true);
			this._asyncWriteTask = task;
			return task;
		}

		/// <summary>Writes a character followed by a line terminator asynchronously to the stream.</summary>
		/// <param name="value">The character to write to the stream.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x06001A04 RID: 6660 RVA: 0x00056EB0 File Offset: 0x000550B0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync(char value)
		{
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteLineAsync(value);
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = StreamWriter.WriteAsyncInternal(this, value, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, true);
			this._asyncWriteTask = task;
			return task;
		}

		/// <summary>Writes a string followed by a line terminator asynchronously to the stream.</summary>
		/// <param name="value">The string to write. If the value is <see langword="null" />, only a line terminator is written.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x06001A05 RID: 6661 RVA: 0x00056F20 File Offset: 0x00055120
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync(string value)
		{
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteLineAsync(value);
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = StreamWriter.WriteAsyncInternal(this, value, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, true);
			this._asyncWriteTask = task;
			return task;
		}

		/// <summary>Writes a subarray of characters followed by a line terminator asynchronously to the stream.</summary>
		/// <param name="buffer">The character array to write data from.</param>
		/// <param name="index">The character position in the buffer at which to start reading data.</param>
		/// <param name="count">The maximum number of characters to write.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="index" /> plus <paramref name="count" /> is greater than the buffer length.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The stream writer is disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The stream writer is currently in use by a previous write operation.</exception>
		// Token: 0x06001A06 RID: 6662 RVA: 0x00056F90 File Offset: 0x00055190
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync(char[] buffer, int index, int count)
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
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.WriteLineAsync(buffer, index, count);
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = StreamWriter.WriteAsyncInternal(this, buffer, index, count, this.charBuffer, this.charPos, this.charLen, this.CoreNewLine, this.autoFlush, true);
			this._asyncWriteTask = task;
			return task;
		}

		/// <summary>Clears all buffers for this stream asynchronously and causes any buffered data to be written to the underlying device.</summary>
		/// <returns>A task that represents the asynchronous flush operation.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The stream has been disposed.</exception>
		// Token: 0x06001A07 RID: 6663 RVA: 0x00057068 File Offset: 0x00055268
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task FlushAsync()
		{
			if (base.GetType() != typeof(StreamWriter))
			{
				return base.FlushAsync();
			}
			if (this.stream == null)
			{
				__Error.WriterClosed();
			}
			this.CheckAsyncTaskInProgress();
			Task task = this.FlushAsyncInternal(true, true, this.charBuffer, this.charPos);
			this._asyncWriteTask = task;
			return task;
		}

		// Token: 0x170002E9 RID: 745
		// (set) Token: 0x06001A08 RID: 6664 RVA: 0x000570C5 File Offset: 0x000552C5
		private int CharPos_Prop
		{
			set
			{
				this.charPos = value;
			}
		}

		// Token: 0x170002EA RID: 746
		// (set) Token: 0x06001A09 RID: 6665 RVA: 0x000570CE File Offset: 0x000552CE
		private bool HaveWrittenPreamble_Prop
		{
			set
			{
				this.haveWrittenPreamble = value;
			}
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x000570D8 File Offset: 0x000552D8
		private Task FlushAsyncInternal(bool flushStream, bool flushEncoder, char[] sCharBuffer, int sCharPos)
		{
			if (sCharPos == 0 && !flushStream && !flushEncoder)
			{
				return Task.CompletedTask;
			}
			Task result = StreamWriter.FlushAsyncInternal(this, flushStream, flushEncoder, sCharBuffer, sCharPos, this.haveWrittenPreamble, this.encoding, this.encoder, this.byteBuffer, this.stream);
			this.charPos = 0;
			return result;
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x00057128 File Offset: 0x00055328
		private static async Task FlushAsyncInternal(StreamWriter _this, bool flushStream, bool flushEncoder, char[] charBuffer, int charPos, bool haveWrittenPreamble, Encoding encoding, Encoder encoder, byte[] byteBuffer, Stream stream)
		{
			if (!haveWrittenPreamble)
			{
				_this.HaveWrittenPreamble_Prop = true;
				byte[] preamble = encoding.GetPreamble();
				if (preamble.Length != 0)
				{
					await stream.WriteAsync(preamble, 0, preamble.Length).ConfigureAwait(false);
				}
			}
			int bytes = encoder.GetBytes(charBuffer, 0, charPos, byteBuffer, 0, flushEncoder);
			if (bytes > 0)
			{
				await stream.WriteAsync(byteBuffer, 0, bytes).ConfigureAwait(false);
			}
			if (flushStream)
			{
				await stream.FlushAsync().ConfigureAwait(false);
			}
		}

		// Token: 0x0400090A RID: 2314
		internal const int DefaultBufferSize = 1024;

		// Token: 0x0400090B RID: 2315
		private const int DefaultFileStreamBufferSize = 4096;

		// Token: 0x0400090C RID: 2316
		private const int MinBufferSize = 128;

		// Token: 0x0400090D RID: 2317
		private const int DontCopyOnWriteLineThreshold = 512;

		/// <summary>Provides a <see langword="StreamWriter" /> with no backing store that can be written to, but not read from.</summary>
		// Token: 0x0400090E RID: 2318
		[__DynamicallyInvokable]
		public new static readonly StreamWriter Null = new StreamWriter(Stream.Null, new UTF8Encoding(false, true), 128, true);

		// Token: 0x0400090F RID: 2319
		private Stream stream;

		// Token: 0x04000910 RID: 2320
		private Encoding encoding;

		// Token: 0x04000911 RID: 2321
		private Encoder encoder;

		// Token: 0x04000912 RID: 2322
		private byte[] byteBuffer;

		// Token: 0x04000913 RID: 2323
		private char[] charBuffer;

		// Token: 0x04000914 RID: 2324
		private int charPos;

		// Token: 0x04000915 RID: 2325
		private int charLen;

		// Token: 0x04000916 RID: 2326
		private bool autoFlush;

		// Token: 0x04000917 RID: 2327
		private bool haveWrittenPreamble;

		// Token: 0x04000918 RID: 2328
		private bool closable;

		// Token: 0x04000919 RID: 2329
		[NonSerialized]
		private StreamWriter.MdaHelper mdaHelper;

		// Token: 0x0400091A RID: 2330
		[NonSerialized]
		private volatile Task _asyncWriteTask;

		// Token: 0x0400091B RID: 2331
		private static volatile Encoding _UTF8NoBOM;

		// Token: 0x02000AF0 RID: 2800
		private sealed class MdaHelper
		{
			// Token: 0x060069DB RID: 27099 RVA: 0x0016D7AA File Offset: 0x0016B9AA
			internal MdaHelper(StreamWriter sw, string cs)
			{
				this.streamWriter = sw;
				this.allocatedCallstack = cs;
			}

			// Token: 0x060069DC RID: 27100 RVA: 0x0016D7C0 File Offset: 0x0016B9C0
			protected override void Finalize()
			{
				try
				{
					if (this.streamWriter.charPos != 0 && this.streamWriter.stream != null && this.streamWriter.stream != Stream.Null)
					{
						string text = (this.streamWriter.stream is FileStream) ? ((FileStream)this.streamWriter.stream).NameInternal : "<unknown>";
						string resourceString = this.allocatedCallstack;
						if (resourceString == null)
						{
							resourceString = Environment.GetResourceString("IO_StreamWriterBufferedDataLostCaptureAllocatedFromCallstackNotEnabled");
						}
						string resourceString2 = Environment.GetResourceString("IO_StreamWriterBufferedDataLost", new object[]
						{
							this.streamWriter.stream.GetType().FullName,
							text,
							resourceString
						});
						Mda.StreamWriterBufferedDataLost.ReportError(resourceString2);
					}
				}
				finally
				{
					base.Finalize();
				}
			}

			// Token: 0x04003224 RID: 12836
			private StreamWriter streamWriter;

			// Token: 0x04003225 RID: 12837
			private string allocatedCallstack;
		}
	}
}
