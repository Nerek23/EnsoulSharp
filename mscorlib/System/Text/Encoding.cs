using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Threading;
using Microsoft.Win32;

namespace System.Text
{
	/// <summary>Represents a character encoding.</summary>
	// Token: 0x02000A46 RID: 2630
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Encoding : ICloneable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.Encoding" /> class.</summary>
		// Token: 0x06006704 RID: 26372 RVA: 0x0015AF7C File Offset: 0x0015917C
		[__DynamicallyInvokable]
		protected Encoding() : this(0)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.Encoding" /> class that corresponds to the specified code page.</summary>
		/// <param name="codePage">The code page identifier of the preferred encoding.  
		///  -or-  
		///  0, to use the default encoding.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="codePage" /> is less than zero.</exception>
		// Token: 0x06006705 RID: 26373 RVA: 0x0015AF85 File Offset: 0x00159185
		[__DynamicallyInvokable]
		protected Encoding(int codePage)
		{
			this.m_isReadOnly = true;
			base..ctor();
			if (codePage < 0)
			{
				throw new ArgumentOutOfRangeException("codePage");
			}
			this.m_codePage = codePage;
			this.SetDefaultFallbacks();
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.Encoding" /> class that corresponds to the specified code page with the specified encoder and decoder fallback strategies.</summary>
		/// <param name="codePage">The encoding code page identifier.</param>
		/// <param name="encoderFallback">An object that provides an error-handling procedure when a character cannot be encoded with the current encoding.</param>
		/// <param name="decoderFallback">An object that provides an error-handling procedure when a byte sequence cannot be decoded with the current encoding.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="codePage" /> is less than zero.</exception>
		// Token: 0x06006706 RID: 26374 RVA: 0x0015AFB0 File Offset: 0x001591B0
		[__DynamicallyInvokable]
		protected Encoding(int codePage, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
		{
			this.m_isReadOnly = true;
			base..ctor();
			if (codePage < 0)
			{
				throw new ArgumentOutOfRangeException("codePage");
			}
			this.m_codePage = codePage;
			this.encoderFallback = (encoderFallback ?? new InternalEncoderBestFitFallback(this));
			this.decoderFallback = (decoderFallback ?? new InternalDecoderBestFitFallback(this));
		}

		// Token: 0x06006707 RID: 26375 RVA: 0x0015B002 File Offset: 0x00159202
		internal virtual void SetDefaultFallbacks()
		{
			this.encoderFallback = new InternalEncoderBestFitFallback(this);
			this.decoderFallback = new InternalDecoderBestFitFallback(this);
		}

		// Token: 0x06006708 RID: 26376 RVA: 0x0015B01C File Offset: 0x0015921C
		internal void OnDeserializing()
		{
			this.encoderFallback = null;
			this.decoderFallback = null;
			this.m_isReadOnly = true;
		}

		// Token: 0x06006709 RID: 26377 RVA: 0x0015B033 File Offset: 0x00159233
		internal void OnDeserialized()
		{
			if (this.encoderFallback == null || this.decoderFallback == null)
			{
				this.m_deserializedFromEverett = true;
				this.SetDefaultFallbacks();
			}
			this.dataItem = null;
		}

		// Token: 0x0600670A RID: 26378 RVA: 0x0015B059 File Offset: 0x00159259
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
			this.OnDeserializing();
		}

		// Token: 0x0600670B RID: 26379 RVA: 0x0015B061 File Offset: 0x00159261
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			this.OnDeserialized();
		}

		// Token: 0x0600670C RID: 26380 RVA: 0x0015B069 File Offset: 0x00159269
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			this.dataItem = null;
		}

		// Token: 0x0600670D RID: 26381 RVA: 0x0015B074 File Offset: 0x00159274
		internal void DeserializeEncoding(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			this.m_codePage = (int)info.GetValue("m_codePage", typeof(int));
			this.dataItem = null;
			try
			{
				this.m_isReadOnly = (bool)info.GetValue("m_isReadOnly", typeof(bool));
				this.encoderFallback = (EncoderFallback)info.GetValue("encoderFallback", typeof(EncoderFallback));
				this.decoderFallback = (DecoderFallback)info.GetValue("decoderFallback", typeof(DecoderFallback));
			}
			catch (SerializationException)
			{
				this.m_deserializedFromEverett = true;
				this.m_isReadOnly = true;
				this.SetDefaultFallbacks();
			}
		}

		// Token: 0x0600670E RID: 26382 RVA: 0x0015B140 File Offset: 0x00159340
		internal void SerializeEncoding(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("m_isReadOnly", this.m_isReadOnly);
			info.AddValue("encoderFallback", this.EncoderFallback);
			info.AddValue("decoderFallback", this.DecoderFallback);
			info.AddValue("m_codePage", this.m_codePage);
			info.AddValue("dataItem", null);
			info.AddValue("Encoding+m_codePage", this.m_codePage);
			info.AddValue("Encoding+dataItem", null);
		}

		/// <summary>Converts an entire byte array from one encoding to another.</summary>
		/// <param name="srcEncoding">The encoding format of <paramref name="bytes" />.</param>
		/// <param name="dstEncoding">The target encoding format.</param>
		/// <param name="bytes">The bytes to convert.</param>
		/// <returns>An array of type <see cref="T:System.Byte" /> containing the results of converting <paramref name="bytes" /> from <paramref name="srcEncoding" /> to <paramref name="dstEncoding" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="srcEncoding" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="dstEncoding" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  srcEncoding. <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  dstEncoding. <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x0600670F RID: 26383 RVA: 0x0015B1C8 File Offset: 0x001593C8
		[__DynamicallyInvokable]
		public static byte[] Convert(Encoding srcEncoding, Encoding dstEncoding, byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			return Encoding.Convert(srcEncoding, dstEncoding, bytes, 0, bytes.Length);
		}

		/// <summary>Converts a range of bytes in a byte array from one encoding to another.</summary>
		/// <param name="srcEncoding">The encoding of the source array, <paramref name="bytes" />.</param>
		/// <param name="dstEncoding">The encoding of the output array.</param>
		/// <param name="bytes">The array of bytes to convert.</param>
		/// <param name="index">The index of the first element of <paramref name="bytes" /> to convert.</param>
		/// <param name="count">The number of bytes to convert.</param>
		/// <returns>An array of type <see cref="T:System.Byte" /> containing the result of converting a range of bytes in <paramref name="bytes" /> from <paramref name="srcEncoding" /> to <paramref name="dstEncoding" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="srcEncoding" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="dstEncoding" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> and <paramref name="count" /> do not specify a valid range in the byte array.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  srcEncoding. <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  dstEncoding. <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006710 RID: 26384 RVA: 0x0015B1E4 File Offset: 0x001593E4
		[__DynamicallyInvokable]
		public static byte[] Convert(Encoding srcEncoding, Encoding dstEncoding, byte[] bytes, int index, int count)
		{
			if (srcEncoding == null || dstEncoding == null)
			{
				throw new ArgumentNullException((srcEncoding == null) ? "srcEncoding" : "dstEncoding", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			return dstEncoding.GetBytes(srcEncoding.GetChars(bytes, index, count));
		}

		// Token: 0x170011AE RID: 4526
		// (get) Token: 0x06006711 RID: 26385 RVA: 0x0015B240 File Offset: 0x00159440
		private static object InternalSyncObject
		{
			get
			{
				if (Encoding.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref Encoding.s_InternalSyncObject, value, null);
				}
				return Encoding.s_InternalSyncObject;
			}
		}

		/// <summary>Registers an encoding provider.</summary>
		/// <param name="provider">A subclass of <see cref="T:System.Text.EncodingProvider" /> that provides access to additional character encodings.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="provider" /> is <see langword="null" />.</exception>
		// Token: 0x06006712 RID: 26386 RVA: 0x0015B26C File Offset: 0x0015946C
		[SecurityCritical]
		[__DynamicallyInvokable]
		public static void RegisterProvider(EncodingProvider provider)
		{
			EncodingProvider.AddProvider(provider);
		}

		/// <summary>Returns the encoding associated with the specified code page identifier.</summary>
		/// <param name="codepage">The code page identifier of the preferred encoding. Possible values are listed in the Code Page column of the table that appears in the <see cref="T:System.Text.Encoding" /> class topic.  
		///  -or-  
		///  0 (zero), to use the default encoding.</param>
		/// <returns>The encoding that is associated with the specified code page.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="codepage" /> is less than zero or greater than 65535.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="codepage" /> is not supported by the underlying platform.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="codepage" /> is not supported by the underlying platform.</exception>
		// Token: 0x06006713 RID: 26387 RVA: 0x0015B274 File Offset: 0x00159474
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static Encoding GetEncoding(int codepage)
		{
			Encoding encoding = EncodingProvider.GetEncodingFromProvider(codepage);
			if (encoding != null)
			{
				return encoding;
			}
			if (codepage < 0 || codepage > 65535)
			{
				throw new ArgumentOutOfRangeException("codepage", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					0,
					65535
				}));
			}
			if (Encoding.encodings != null)
			{
				encoding = (Encoding)Encoding.encodings[codepage];
			}
			if (encoding == null)
			{
				object internalSyncObject = Encoding.InternalSyncObject;
				lock (internalSyncObject)
				{
					if (Encoding.encodings == null)
					{
						Encoding.encodings = new Hashtable();
					}
					if ((encoding = (Encoding)Encoding.encodings[codepage]) != null)
					{
						return encoding;
					}
					if (codepage <= 1200)
					{
						if (codepage <= 3)
						{
							if (codepage == 0)
							{
								encoding = Encoding.Default;
								goto IL_185;
							}
							if (codepage - 1 > 2)
							{
								goto IL_174;
							}
						}
						else if (codepage != 42)
						{
							if (codepage != 1200)
							{
								goto IL_174;
							}
							encoding = Encoding.Unicode;
							goto IL_185;
						}
						throw new ArgumentException(Environment.GetResourceString("Argument_CodepageNotSupported", new object[]
						{
							codepage
						}), "codepage");
					}
					if (codepage <= 1252)
					{
						if (codepage == 1201)
						{
							encoding = Encoding.BigEndianUnicode;
							goto IL_185;
						}
						if (codepage == 1252)
						{
							encoding = new SBCSCodePageEncoding(codepage);
							goto IL_185;
						}
					}
					else
					{
						if (codepage == 20127)
						{
							encoding = Encoding.ASCII;
							goto IL_185;
						}
						if (codepage == 28591)
						{
							encoding = Encoding.Latin1;
							goto IL_185;
						}
						if (codepage == 65001)
						{
							encoding = Encoding.UTF8;
							goto IL_185;
						}
					}
					IL_174:
					encoding = Encoding.GetEncodingCodePage(codepage);
					if (encoding == null)
					{
						encoding = Encoding.GetEncodingRare(codepage);
					}
					IL_185:
					Encoding.encodings.Add(codepage, encoding);
				}
				return encoding;
			}
			return encoding;
		}

		/// <summary>Returns the encoding associated with the specified code page identifier. Parameters specify an error handler for characters that cannot be encoded and byte sequences that cannot be decoded.</summary>
		/// <param name="codepage">The code page identifier of the preferred encoding. Possible values are listed in the Code Page column of the table that appears in the <see cref="T:System.Text.Encoding" /> class topic.  
		///  -or-  
		///  0 (zero), to use the default encoding.</param>
		/// <param name="encoderFallback">An object that provides an error-handling procedure when a character cannot be encoded with the current encoding.</param>
		/// <param name="decoderFallback">An object that provides an error-handling procedure when a byte sequence cannot be decoded with the current encoding.</param>
		/// <returns>The encoding that is associated with the specified code page.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="codepage" /> is less than zero or greater than 65535.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="codepage" /> is not supported by the underlying platform.</exception>
		/// <exception cref="T:System.NotSupportedException">
		///   <paramref name="codepage" /> is not supported by the underlying platform.</exception>
		// Token: 0x06006714 RID: 26388 RVA: 0x0015B444 File Offset: 0x00159644
		[__DynamicallyInvokable]
		public static Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
		{
			Encoding encoding = EncodingProvider.GetEncodingFromProvider(codepage, encoderFallback, decoderFallback);
			if (encoding != null)
			{
				return encoding;
			}
			encoding = Encoding.GetEncoding(codepage);
			Encoding encoding2 = (Encoding)encoding.Clone();
			encoding2.EncoderFallback = encoderFallback;
			encoding2.DecoderFallback = decoderFallback;
			return encoding2;
		}

		// Token: 0x06006715 RID: 26389 RVA: 0x0015B484 File Offset: 0x00159684
		[SecurityCritical]
		private static Encoding GetEncodingRare(int codepage)
		{
			if (codepage <= 50229)
			{
				if (codepage <= 12000)
				{
					if (codepage == 10003)
					{
						return new DBCSCodePageEncoding(10003, 20949);
					}
					if (codepage == 10008)
					{
						return new DBCSCodePageEncoding(10008, 20936);
					}
					if (codepage != 12000)
					{
						goto IL_192;
					}
					return Encoding.UTF32;
				}
				else
				{
					if (codepage == 12001)
					{
						return new UTF32Encoding(true, true);
					}
					if (codepage == 38598)
					{
						return new SBCSCodePageEncoding(codepage, 28598);
					}
					switch (codepage)
					{
					case 50220:
					case 50221:
					case 50222:
					case 50225:
						break;
					case 50223:
					case 50224:
					case 50226:
					case 50228:
						goto IL_192;
					case 50227:
						goto IL_150;
					case 50229:
						throw new NotSupportedException(Environment.GetResourceString("NotSupported_CodePage50229"));
					default:
						goto IL_192;
					}
				}
			}
			else if (codepage <= 51949)
			{
				if (codepage == 51932)
				{
					return new EUCJPEncoding();
				}
				if (codepage == 51936)
				{
					goto IL_150;
				}
				if (codepage != 51949)
				{
					goto IL_192;
				}
				return new DBCSCodePageEncoding(codepage, 20949);
			}
			else if (codepage <= 54936)
			{
				if (codepage != 52936)
				{
					if (codepage != 54936)
					{
						goto IL_192;
					}
					return new GB18030Encoding();
				}
			}
			else
			{
				if (codepage - 57002 <= 9)
				{
					return new ISCIIEncoding(codepage);
				}
				if (codepage == 65000)
				{
					return Encoding.UTF7;
				}
				goto IL_192;
			}
			return new ISO2022Encoding(codepage);
			IL_150:
			return new DBCSCodePageEncoding(codepage, 936);
			IL_192:
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoCodepageData", new object[]
			{
				codepage
			}));
		}

		// Token: 0x06006716 RID: 26390 RVA: 0x0015B644 File Offset: 0x00159844
		[SecurityCritical]
		private static Encoding GetEncodingCodePage(int CodePage)
		{
			int codePageByteSize = BaseCodePageEncoding.GetCodePageByteSize(CodePage);
			if (codePageByteSize == 1)
			{
				return new SBCSCodePageEncoding(CodePage);
			}
			if (codePageByteSize == 2)
			{
				return new DBCSCodePageEncoding(CodePage);
			}
			return null;
		}

		/// <summary>Returns the encoding associated with the specified code page name.</summary>
		/// <param name="name">The code page name of the preferred encoding. Any value returned by the <see cref="P:System.Text.Encoding.WebName" /> property is valid. Possible values are listed in the Name column of the table that appears in the <see cref="T:System.Text.Encoding" /> class topic.</param>
		/// <returns>The encoding  associated with the specified code page.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is not a valid code page name.  
		/// -or-  
		/// The code page indicated by <paramref name="name" /> is not supported by the underlying platform.</exception>
		// Token: 0x06006717 RID: 26391 RVA: 0x0015B670 File Offset: 0x00159870
		[__DynamicallyInvokable]
		public static Encoding GetEncoding(string name)
		{
			Encoding encodingFromProvider = EncodingProvider.GetEncodingFromProvider(name);
			if (encodingFromProvider != null)
			{
				return encodingFromProvider;
			}
			return Encoding.GetEncoding(EncodingTable.GetCodePageFromName(name));
		}

		/// <summary>Returns the encoding associated with the specified code page name. Parameters specify an error handler for characters that cannot be encoded and byte sequences that cannot be decoded.</summary>
		/// <param name="name">The code page name of the preferred encoding. Any value returned by the <see cref="P:System.Text.Encoding.WebName" /> property is valid. Possible values are listed in the Name column of the table that appears in the <see cref="T:System.Text.Encoding" /> class topic.</param>
		/// <param name="encoderFallback">An object that provides an error-handling procedure when a character cannot be encoded with the current encoding.</param>
		/// <param name="decoderFallback">An object that provides an error-handling procedure when a byte sequence cannot be decoded with the current encoding.</param>
		/// <returns>The encoding that is associated with the specified code page.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is not a valid code page name.  
		/// -or-  
		/// The code page indicated by <paramref name="name" /> is not supported by the underlying platform.</exception>
		// Token: 0x06006718 RID: 26392 RVA: 0x0015B694 File Offset: 0x00159894
		[__DynamicallyInvokable]
		public static Encoding GetEncoding(string name, EncoderFallback encoderFallback, DecoderFallback decoderFallback)
		{
			Encoding encodingFromProvider = EncodingProvider.GetEncodingFromProvider(name, encoderFallback, decoderFallback);
			if (encodingFromProvider != null)
			{
				return encodingFromProvider;
			}
			return Encoding.GetEncoding(EncodingTable.GetCodePageFromName(name), encoderFallback, decoderFallback);
		}

		/// <summary>Returns an array that contains all encodings.</summary>
		/// <returns>An array that contains all encodings.</returns>
		// Token: 0x06006719 RID: 26393 RVA: 0x0015B6BC File Offset: 0x001598BC
		public static EncodingInfo[] GetEncodings()
		{
			return EncodingTable.GetEncodings();
		}

		/// <summary>When overridden in a derived class, returns a sequence of bytes that specifies the encoding used.</summary>
		/// <returns>A byte array containing a sequence of bytes that specifies the encoding used.  
		///  -or-  
		///  A byte array of length zero, if a preamble is not required.</returns>
		// Token: 0x0600671A RID: 26394 RVA: 0x0015B6C3 File Offset: 0x001598C3
		[__DynamicallyInvokable]
		public virtual byte[] GetPreamble()
		{
			return EmptyArray<byte>.Value;
		}

		// Token: 0x0600671B RID: 26395 RVA: 0x0015B6CC File Offset: 0x001598CC
		private void GetDataItem()
		{
			if (this.dataItem == null)
			{
				this.dataItem = EncodingTable.GetCodePageDataItem(this.m_codePage);
				if (this.dataItem == null)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoCodepageData", new object[]
					{
						this.m_codePage
					}));
				}
			}
		}

		/// <summary>When overridden in a derived class, gets a name for the current encoding that can be used with mail agent body tags.</summary>
		/// <returns>A name for the current <see cref="T:System.Text.Encoding" /> that can be used with mail agent body tags.  
		///  -or-  
		///  An empty string (""), if the current <see cref="T:System.Text.Encoding" /> cannot be used.</returns>
		// Token: 0x170011AF RID: 4527
		// (get) Token: 0x0600671C RID: 26396 RVA: 0x0015B71E File Offset: 0x0015991E
		public virtual string BodyName
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return this.dataItem.BodyName;
			}
		}

		/// <summary>When overridden in a derived class, gets the human-readable description of the current encoding.</summary>
		/// <returns>The human-readable description of the current <see cref="T:System.Text.Encoding" />.</returns>
		// Token: 0x170011B0 RID: 4528
		// (get) Token: 0x0600671D RID: 26397 RVA: 0x0015B739 File Offset: 0x00159939
		[__DynamicallyInvokable]
		public virtual string EncodingName
		{
			[__DynamicallyInvokable]
			get
			{
				return Environment.GetResourceString("Globalization.cp_" + this.m_codePage);
			}
		}

		/// <summary>When overridden in a derived class, gets a name for the current encoding that can be used with mail agent header tags.</summary>
		/// <returns>A name for the current <see cref="T:System.Text.Encoding" /> to use with mail agent header tags.  
		///  -or-  
		///  An empty string (""), if the current <see cref="T:System.Text.Encoding" /> cannot be used.</returns>
		// Token: 0x170011B1 RID: 4529
		// (get) Token: 0x0600671E RID: 26398 RVA: 0x0015B755 File Offset: 0x00159955
		public virtual string HeaderName
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return this.dataItem.HeaderName;
			}
		}

		/// <summary>When overridden in a derived class, gets the name registered with the Internet Assigned Numbers Authority (IANA) for the current encoding.</summary>
		/// <returns>The IANA name for the current <see cref="T:System.Text.Encoding" />.</returns>
		// Token: 0x170011B2 RID: 4530
		// (get) Token: 0x0600671F RID: 26399 RVA: 0x0015B770 File Offset: 0x00159970
		[__DynamicallyInvokable]
		public virtual string WebName
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return this.dataItem.WebName;
			}
		}

		/// <summary>When overridden in a derived class, gets the Windows operating system code page that most closely corresponds to the current encoding.</summary>
		/// <returns>The Windows operating system code page that most closely corresponds to the current <see cref="T:System.Text.Encoding" />.</returns>
		// Token: 0x170011B3 RID: 4531
		// (get) Token: 0x06006720 RID: 26400 RVA: 0x0015B78B File Offset: 0x0015998B
		public virtual int WindowsCodePage
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return this.dataItem.UIFamilyCodePage;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding can be used by browser clients for displaying content.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> can be used by browser clients for displaying content; otherwise, <see langword="false" />.</returns>
		// Token: 0x170011B4 RID: 4532
		// (get) Token: 0x06006721 RID: 26401 RVA: 0x0015B7A6 File Offset: 0x001599A6
		public virtual bool IsBrowserDisplay
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return (this.dataItem.Flags & 2U) > 0U;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding can be used by browser clients for saving content.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> can be used by browser clients for saving content; otherwise, <see langword="false" />.</returns>
		// Token: 0x170011B5 RID: 4533
		// (get) Token: 0x06006722 RID: 26402 RVA: 0x0015B7C6 File Offset: 0x001599C6
		public virtual bool IsBrowserSave
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return (this.dataItem.Flags & 512U) > 0U;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding can be used by mail and news clients for displaying content.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> can be used by mail and news clients for displaying content; otherwise, <see langword="false" />.</returns>
		// Token: 0x170011B6 RID: 4534
		// (get) Token: 0x06006723 RID: 26403 RVA: 0x0015B7EA File Offset: 0x001599EA
		public virtual bool IsMailNewsDisplay
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return (this.dataItem.Flags & 1U) > 0U;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding can be used by mail and news clients for saving content.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> can be used by mail and news clients for saving content; otherwise, <see langword="false" />.</returns>
		// Token: 0x170011B7 RID: 4535
		// (get) Token: 0x06006724 RID: 26404 RVA: 0x0015B80A File Offset: 0x00159A0A
		public virtual bool IsMailNewsSave
		{
			get
			{
				if (this.dataItem == null)
				{
					this.GetDataItem();
				}
				return (this.dataItem.Flags & 256U) > 0U;
			}
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding uses single-byte code points.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> uses single-byte code points; otherwise, <see langword="false" />.</returns>
		// Token: 0x170011B8 RID: 4536
		// (get) Token: 0x06006725 RID: 26405 RVA: 0x0015B82E File Offset: 0x00159A2E
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual bool IsSingleByte
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets or sets the <see cref="T:System.Text.EncoderFallback" /> object for the current <see cref="T:System.Text.Encoding" /> object.</summary>
		/// <returns>The encoder fallback object for the current <see cref="T:System.Text.Encoding" /> object.</returns>
		/// <exception cref="T:System.ArgumentNullException">The value in a set operation is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">A value cannot be assigned in a set operation because the current <see cref="T:System.Text.Encoding" /> object is read-only.</exception>
		// Token: 0x170011B9 RID: 4537
		// (get) Token: 0x06006726 RID: 26406 RVA: 0x0015B831 File Offset: 0x00159A31
		// (set) Token: 0x06006727 RID: 26407 RVA: 0x0015B839 File Offset: 0x00159A39
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public EncoderFallback EncoderFallback
		{
			[__DynamicallyInvokable]
			get
			{
				return this.encoderFallback;
			}
			set
			{
				if (this.IsReadOnly)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.encoderFallback = value;
			}
		}

		/// <summary>Gets or sets the <see cref="T:System.Text.DecoderFallback" /> object for the current <see cref="T:System.Text.Encoding" /> object.</summary>
		/// <returns>The decoder fallback object for the current <see cref="T:System.Text.Encoding" /> object.</returns>
		/// <exception cref="T:System.ArgumentNullException">The value in a set operation is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">A value cannot be assigned in a set operation because the current <see cref="T:System.Text.Encoding" /> object is read-only.</exception>
		// Token: 0x170011BA RID: 4538
		// (get) Token: 0x06006728 RID: 26408 RVA: 0x0015B868 File Offset: 0x00159A68
		// (set) Token: 0x06006729 RID: 26409 RVA: 0x0015B870 File Offset: 0x00159A70
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public DecoderFallback DecoderFallback
		{
			[__DynamicallyInvokable]
			get
			{
				return this.decoderFallback;
			}
			set
			{
				if (this.IsReadOnly)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.decoderFallback = value;
			}
		}

		/// <summary>When overridden in a derived class, creates a shallow copy of the current <see cref="T:System.Text.Encoding" /> object.</summary>
		/// <returns>A copy of the current <see cref="T:System.Text.Encoding" /> object.</returns>
		// Token: 0x0600672A RID: 26410 RVA: 0x0015B8A0 File Offset: 0x00159AA0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual object Clone()
		{
			Encoding encoding = (Encoding)base.MemberwiseClone();
			encoding.m_isReadOnly = false;
			return encoding;
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding is read-only.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> is read-only; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x170011BB RID: 4539
		// (get) Token: 0x0600672B RID: 26411 RVA: 0x0015B8C1 File Offset: 0x00159AC1
		[ComVisible(false)]
		public bool IsReadOnly
		{
			get
			{
				return this.m_isReadOnly;
			}
		}

		/// <summary>Gets an encoding for the ASCII (7-bit) character set.</summary>
		/// <returns>An  encoding for the ASCII (7-bit) character set.</returns>
		// Token: 0x170011BC RID: 4540
		// (get) Token: 0x0600672C RID: 26412 RVA: 0x0015B8C9 File Offset: 0x00159AC9
		[__DynamicallyInvokable]
		public static Encoding ASCII
		{
			[__DynamicallyInvokable]
			get
			{
				if (Encoding.asciiEncoding == null)
				{
					Encoding.asciiEncoding = new ASCIIEncoding();
				}
				return Encoding.asciiEncoding;
			}
		}

		// Token: 0x170011BD RID: 4541
		// (get) Token: 0x0600672D RID: 26413 RVA: 0x0015B8E7 File Offset: 0x00159AE7
		private static Encoding Latin1
		{
			get
			{
				if (Encoding.latin1Encoding == null)
				{
					Encoding.latin1Encoding = new Latin1Encoding();
				}
				return Encoding.latin1Encoding;
			}
		}

		/// <summary>When overridden in a derived class, calculates the number of bytes produced by encoding all the characters in the specified character array.</summary>
		/// <param name="chars">The character array containing the characters to encode.</param>
		/// <returns>The number of bytes produced by encoding all the characters in the specified character array.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x0600672E RID: 26414 RVA: 0x0015B905 File Offset: 0x00159B05
		[__DynamicallyInvokable]
		public virtual int GetByteCount(char[] chars)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			return this.GetByteCount(chars, 0, chars.Length);
		}

		/// <summary>When overridden in a derived class, calculates the number of bytes produced by encoding the characters in the specified string.</summary>
		/// <param name="s">The string containing the set of characters to encode.</param>
		/// <returns>The number of bytes produced by encoding the specified characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x0600672F RID: 26415 RVA: 0x0015B92C File Offset: 0x00159B2C
		[__DynamicallyInvokable]
		public virtual int GetByteCount(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			char[] array = s.ToCharArray();
			return this.GetByteCount(array, 0, array.Length);
		}

		/// <summary>When overridden in a derived class, calculates the number of bytes produced by encoding a set of characters from the specified character array.</summary>
		/// <param name="chars">The character array containing the set of characters to encode.</param>
		/// <param name="index">The index of the first character to encode.</param>
		/// <param name="count">The number of characters to encode.</param>
		/// <returns>The number of bytes produced by encoding the specified characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="chars" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006730 RID: 26416
		[__DynamicallyInvokable]
		public abstract int GetByteCount(char[] chars, int index, int count);

		/// <summary>When overridden in a derived class, calculates the number of bytes produced by encoding a set of characters starting at the specified character pointer.</summary>
		/// <param name="chars">A pointer to the first character to encode.</param>
		/// <param name="count">The number of characters to encode.</param>
		/// <returns>The number of bytes produced by encoding the specified characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is less than zero.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006731 RID: 26417 RVA: 0x0015B95C File Offset: 0x00159B5C
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual int GetByteCount(char* chars, int count)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			char[] array = new char[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = chars[i];
			}
			return this.GetByteCount(array, 0, count);
		}

		// Token: 0x06006732 RID: 26418 RVA: 0x0015B9C2 File Offset: 0x00159BC2
		[SecurityCritical]
		internal unsafe virtual int GetByteCount(char* chars, int count, EncoderNLS encoder)
		{
			return this.GetByteCount(chars, count);
		}

		/// <summary>When overridden in a derived class, encodes all the characters in the specified character array into a sequence of bytes.</summary>
		/// <param name="chars">The character array containing the characters to encode.</param>
		/// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006733 RID: 26419 RVA: 0x0015B9CC File Offset: 0x00159BCC
		[__DynamicallyInvokable]
		public virtual byte[] GetBytes(char[] chars)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			return this.GetBytes(chars, 0, chars.Length);
		}

		/// <summary>When overridden in a derived class, encodes a set of characters from the specified character array into a sequence of bytes.</summary>
		/// <param name="chars">The character array containing the set of characters to encode.</param>
		/// <param name="index">The index of the first character to encode.</param>
		/// <param name="count">The number of characters to encode.</param>
		/// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="chars" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006734 RID: 26420 RVA: 0x0015B9F4 File Offset: 0x00159BF4
		[__DynamicallyInvokable]
		public virtual byte[] GetBytes(char[] chars, int index, int count)
		{
			byte[] array = new byte[this.GetByteCount(chars, index, count)];
			this.GetBytes(chars, index, count, array, 0);
			return array;
		}

		/// <summary>When overridden in a derived class, encodes a set of characters from the specified character array into the specified byte array.</summary>
		/// <param name="chars">The character array containing the set of characters to encode.</param>
		/// <param name="charIndex">The index of the first character to encode.</param>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <param name="bytes">The byte array to contain the resulting sequence of bytes.</param>
		/// <param name="byteIndex">The index at which to start writing the resulting sequence of bytes.</param>
		/// <returns>The actual number of bytes written into <paramref name="bytes" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charIndex" /> or <paramref name="charCount" /> or <paramref name="byteIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="charIndex" /> and <paramref name="charCount" /> do not denote a valid range in <paramref name="chars" />.  
		/// -or-  
		/// <paramref name="byteIndex" /> is not a valid index in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="bytes" /> does not have enough capacity from <paramref name="byteIndex" /> to the end of the array to accommodate the resulting bytes.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006735 RID: 26421
		[__DynamicallyInvokable]
		public abstract int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);

		/// <summary>When overridden in a derived class, encodes all the characters in the specified string into a sequence of bytes.</summary>
		/// <param name="s">The string containing the characters to encode.</param>
		/// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006736 RID: 26422 RVA: 0x0015BA20 File Offset: 0x00159C20
		[__DynamicallyInvokable]
		public virtual byte[] GetBytes(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s", Environment.GetResourceString("ArgumentNull_String"));
			}
			int byteCount = this.GetByteCount(s);
			byte[] array = new byte[byteCount];
			int bytes = this.GetBytes(s, 0, s.Length, array, 0);
			return array;
		}

		/// <summary>When overridden in a derived class, encodes a set of characters from the specified string into the specified byte array.</summary>
		/// <param name="s">The string containing the set of characters to encode.</param>
		/// <param name="charIndex">The index of the first character to encode.</param>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <param name="bytes">The byte array to contain the resulting sequence of bytes.</param>
		/// <param name="byteIndex">The index at which to start writing the resulting sequence of bytes.</param>
		/// <returns>The actual number of bytes written into <paramref name="bytes" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charIndex" /> or <paramref name="charCount" /> or <paramref name="byteIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="charIndex" /> and <paramref name="charCount" /> do not denote a valid range in <paramref name="chars" />.  
		/// -or-  
		/// <paramref name="byteIndex" /> is not a valid index in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="bytes" /> does not have enough capacity from <paramref name="byteIndex" /> to the end of the array to accommodate the resulting bytes.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006737 RID: 26423 RVA: 0x0015BA66 File Offset: 0x00159C66
		[__DynamicallyInvokable]
		public virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			return this.GetBytes(s.ToCharArray(), charIndex, charCount, bytes, byteIndex);
		}

		// Token: 0x06006738 RID: 26424 RVA: 0x0015BA88 File Offset: 0x00159C88
		[SecurityCritical]
		internal unsafe virtual int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS encoder)
		{
			return this.GetBytes(chars, charCount, bytes, byteCount);
		}

		/// <summary>When overridden in a derived class, encodes a set of characters starting at the specified character pointer into a sequence of bytes that are stored starting at the specified byte pointer.</summary>
		/// <param name="chars">A pointer to the first character to encode.</param>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <param name="bytes">A pointer to the location at which to start writing the resulting sequence of bytes.</param>
		/// <param name="byteCount">The maximum number of bytes to write.</param>
		/// <returns>The actual number of bytes written at the location indicated by the <paramref name="bytes" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charCount" /> or <paramref name="byteCount" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="byteCount" /> is less than the resulting number of bytes.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006739 RID: 26425 RVA: 0x0015BA98 File Offset: 0x00159C98
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
			if (bytes == null || chars == null)
			{
				throw new ArgumentNullException((bytes == null) ? "bytes" : "chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charCount < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((charCount < 0) ? "charCount" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			char[] array = new char[charCount];
			for (int i = 0; i < charCount; i++)
			{
				array[i] = chars[i];
			}
			byte[] array2 = new byte[byteCount];
			int bytes2 = this.GetBytes(array, 0, charCount, array2, 0);
			if (bytes2 < byteCount)
			{
				byteCount = bytes2;
			}
			for (int i = 0; i < byteCount; i++)
			{
				bytes[i] = array2[i];
			}
			return byteCount;
		}

		/// <summary>When overridden in a derived class, calculates the number of characters produced by decoding all the bytes in the specified byte array.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <returns>The number of characters produced by decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600673A RID: 26426 RVA: 0x0015BB48 File Offset: 0x00159D48
		[__DynamicallyInvokable]
		public virtual int GetCharCount(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			return this.GetCharCount(bytes, 0, bytes.Length);
		}

		/// <summary>When overridden in a derived class, calculates the number of characters produced by decoding a sequence of bytes from the specified byte array.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="index">The index of the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>The number of characters produced by decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600673B RID: 26427
		[__DynamicallyInvokable]
		public abstract int GetCharCount(byte[] bytes, int index, int count);

		/// <summary>When overridden in a derived class, calculates the number of characters produced by decoding a sequence of bytes starting at the specified byte pointer.</summary>
		/// <param name="bytes">A pointer to the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>The number of characters produced by decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is less than zero.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600673C RID: 26428 RVA: 0x0015BB70 File Offset: 0x00159D70
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual int GetCharCount(byte* bytes, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			byte[] array = new byte[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = bytes[i];
			}
			return this.GetCharCount(array, 0, count);
		}

		// Token: 0x0600673D RID: 26429 RVA: 0x0015BBD3 File Offset: 0x00159DD3
		[SecurityCritical]
		internal unsafe virtual int GetCharCount(byte* bytes, int count, DecoderNLS decoder)
		{
			return this.GetCharCount(bytes, count);
		}

		/// <summary>When overridden in a derived class, decodes all the bytes in the specified byte array into a set of characters.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <returns>A character array containing the results of decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600673E RID: 26430 RVA: 0x0015BBDD File Offset: 0x00159DDD
		[__DynamicallyInvokable]
		public virtual char[] GetChars(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			return this.GetChars(bytes, 0, bytes.Length);
		}

		/// <summary>When overridden in a derived class, decodes a sequence of bytes from the specified byte array into a set of characters.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="index">The index of the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>A character array containing the results of decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600673F RID: 26431 RVA: 0x0015BC04 File Offset: 0x00159E04
		[__DynamicallyInvokable]
		public virtual char[] GetChars(byte[] bytes, int index, int count)
		{
			char[] array = new char[this.GetCharCount(bytes, index, count)];
			this.GetChars(bytes, index, count, array, 0);
			return array;
		}

		/// <summary>When overridden in a derived class, decodes a sequence of bytes from the specified byte array into the specified character array.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="byteIndex">The index of the first byte to decode.</param>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <param name="chars">The character array to contain the resulting set of characters.</param>
		/// <param name="charIndex">The index at which to start writing the resulting set of characters.</param>
		/// <returns>The actual number of characters written into <paramref name="chars" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteIndex" /> or <paramref name="byteCount" /> or <paramref name="charIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="byteindex" /> and <paramref name="byteCount" /> do not denote a valid range in <paramref name="bytes" />.  
		/// -or-  
		/// <paramref name="charIndex" /> is not a valid index in <paramref name="chars" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="chars" /> does not have enough capacity from <paramref name="charIndex" /> to the end of the array to accommodate the resulting characters.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006740 RID: 26432
		[__DynamicallyInvokable]
		public abstract int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);

		/// <summary>When overridden in a derived class, decodes a sequence of bytes starting at the specified byte pointer into a set of characters that are stored starting at the specified character pointer.</summary>
		/// <param name="bytes">A pointer to the first byte to decode.</param>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <param name="chars">A pointer to the location at which to start writing the resulting set of characters.</param>
		/// <param name="charCount">The maximum number of characters to write.</param>
		/// <returns>The actual number of characters written at the location indicated by the <paramref name="chars" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteCount" /> or <paramref name="charCount" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="charCount" /> is less than the resulting number of characters.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006741 RID: 26433 RVA: 0x0015BC30 File Offset: 0x00159E30
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe virtual int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteCount < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteCount < 0) ? "byteCount" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			byte[] array = new byte[byteCount];
			for (int i = 0; i < byteCount; i++)
			{
				array[i] = bytes[i];
			}
			char[] array2 = new char[charCount];
			int chars2 = this.GetChars(array, 0, byteCount, array2, 0);
			if (chars2 < charCount)
			{
				charCount = chars2;
			}
			for (int i = 0; i < charCount; i++)
			{
				chars[i] = array2[i];
			}
			return charCount;
		}

		// Token: 0x06006742 RID: 26434 RVA: 0x0015BCE0 File Offset: 0x00159EE0
		[SecurityCritical]
		internal unsafe virtual int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS decoder)
		{
			return this.GetChars(bytes, byteCount, chars, charCount);
		}

		/// <summary>When overridden in a derived class, decodes a specified number of bytes starting at a specified address into a string.</summary>
		/// <param name="bytes">A pointer to a byte array.</param>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is a null pointer.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteCount" /> is less than zero.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A   fallback occurred (see Character Encoding in .NET for a complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006743 RID: 26435 RVA: 0x0015BCED File Offset: 0x00159EED
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe string GetString(byte* bytes, int byteCount)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteCount < 0)
			{
				throw new ArgumentOutOfRangeException("byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return string.CreateStringFromEncoding(bytes, byteCount, this);
		}

		/// <summary>When overridden in a derived class, gets the code page identifier of the current <see cref="T:System.Text.Encoding" />.</summary>
		/// <returns>The code page identifier of the current <see cref="T:System.Text.Encoding" />.</returns>
		// Token: 0x170011BE RID: 4542
		// (get) Token: 0x06006744 RID: 26436 RVA: 0x0015BD2A File Offset: 0x00159F2A
		[__DynamicallyInvokable]
		public virtual int CodePage
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_codePage;
			}
		}

		/// <summary>Gets a value indicating whether the current encoding is always normalized, using the default normalization form.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> is always normalized; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x06006745 RID: 26437 RVA: 0x0015BD32 File Offset: 0x00159F32
		[ComVisible(false)]
		public bool IsAlwaysNormalized()
		{
			return this.IsAlwaysNormalized(NormalizationForm.FormC);
		}

		/// <summary>When overridden in a derived class, gets a value indicating whether the current encoding is always normalized, using the specified normalization form.</summary>
		/// <param name="form">One of the <see cref="T:System.Text.NormalizationForm" /> values.</param>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Text.Encoding" /> object is always normalized using the specified <see cref="T:System.Text.NormalizationForm" /> value; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x06006746 RID: 26438 RVA: 0x0015BD3B File Offset: 0x00159F3B
		[ComVisible(false)]
		public virtual bool IsAlwaysNormalized(NormalizationForm form)
		{
			return false;
		}

		/// <summary>When overridden in a derived class, obtains a decoder that converts an encoded sequence of bytes into a sequence of characters.</summary>
		/// <returns>A <see cref="T:System.Text.Decoder" /> that converts an encoded sequence of bytes into a sequence of characters.</returns>
		// Token: 0x06006747 RID: 26439 RVA: 0x0015BD3E File Offset: 0x00159F3E
		[__DynamicallyInvokable]
		public virtual Decoder GetDecoder()
		{
			return new Encoding.DefaultDecoder(this);
		}

		// Token: 0x06006748 RID: 26440 RVA: 0x0015BD48 File Offset: 0x00159F48
		[SecurityCritical]
		private static Encoding CreateDefaultEncoding()
		{
			int acp = Win32Native.GetACP();
			Encoding result;
			if (acp == 1252)
			{
				result = new SBCSCodePageEncoding(acp);
			}
			else if (acp == 65001)
			{
				result = Encoding.s_defaultUtf8EncodingNoBom;
			}
			else
			{
				result = Encoding.GetEncoding(acp);
			}
			return result;
		}

		/// <summary>Gets the default encoding for this .NET implementation.</summary>
		/// <returns>The default encoding for this .NET implementation.</returns>
		// Token: 0x170011BF RID: 4543
		// (get) Token: 0x06006749 RID: 26441 RVA: 0x0015BD84 File Offset: 0x00159F84
		public static Encoding Default
		{
			[SecuritySafeCritical]
			get
			{
				if (Encoding.defaultEncoding == null)
				{
					Encoding.defaultEncoding = Encoding.CreateDefaultEncoding();
				}
				return Encoding.defaultEncoding;
			}
		}

		/// <summary>When overridden in a derived class, obtains an encoder that converts a sequence of Unicode characters into an encoded sequence of bytes.</summary>
		/// <returns>A <see cref="T:System.Text.Encoder" /> that converts a sequence of Unicode characters into an encoded sequence of bytes.</returns>
		// Token: 0x0600674A RID: 26442 RVA: 0x0015BDA2 File Offset: 0x00159FA2
		[__DynamicallyInvokable]
		public virtual Encoder GetEncoder()
		{
			return new Encoding.DefaultEncoder(this);
		}

		/// <summary>When overridden in a derived class, calculates the maximum number of bytes produced by encoding the specified number of characters.</summary>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <returns>The maximum number of bytes produced by encoding the specified number of characters.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charCount" /> is less than zero.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x0600674B RID: 26443
		[__DynamicallyInvokable]
		public abstract int GetMaxByteCount(int charCount);

		/// <summary>When overridden in a derived class, calculates the maximum number of characters produced by decoding the specified number of bytes.</summary>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <returns>The maximum number of characters produced by decoding the specified number of bytes.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteCount" /> is less than zero.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600674C RID: 26444
		[__DynamicallyInvokable]
		public abstract int GetMaxCharCount(int byteCount);

		/// <summary>When overridden in a derived class, decodes all the bytes in the specified byte array into a string.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentException">The byte array contains invalid Unicode code points.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600674D RID: 26445 RVA: 0x0015BDAA File Offset: 0x00159FAA
		[__DynamicallyInvokable]
		public virtual string GetString(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			return this.GetString(bytes, 0, bytes.Length);
		}

		/// <summary>When overridden in a derived class, decodes a sequence of bytes from the specified byte array into a string.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="index">The index of the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentException">The byte array contains invalid Unicode code points.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in .NET for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x0600674E RID: 26446 RVA: 0x0015BDCF File Offset: 0x00159FCF
		[__DynamicallyInvokable]
		public virtual string GetString(byte[] bytes, int index, int count)
		{
			return new string(this.GetChars(bytes, index, count));
		}

		/// <summary>Gets an encoding for the UTF-16 format using the little endian byte order.</summary>
		/// <returns>An encoding for the UTF-16 format using the little endian byte order.</returns>
		// Token: 0x170011C0 RID: 4544
		// (get) Token: 0x0600674F RID: 26447 RVA: 0x0015BDDF File Offset: 0x00159FDF
		[__DynamicallyInvokable]
		public static Encoding Unicode
		{
			[__DynamicallyInvokable]
			get
			{
				if (Encoding.unicodeEncoding == null)
				{
					Encoding.unicodeEncoding = new UnicodeEncoding(false, true);
				}
				return Encoding.unicodeEncoding;
			}
		}

		/// <summary>Gets an encoding for the UTF-16 format that uses the big endian byte order.</summary>
		/// <returns>An encoding object for the UTF-16 format that uses the big endian byte order.</returns>
		// Token: 0x170011C1 RID: 4545
		// (get) Token: 0x06006750 RID: 26448 RVA: 0x0015BDFF File Offset: 0x00159FFF
		[__DynamicallyInvokable]
		public static Encoding BigEndianUnicode
		{
			[__DynamicallyInvokable]
			get
			{
				if (Encoding.bigEndianUnicode == null)
				{
					Encoding.bigEndianUnicode = new UnicodeEncoding(true, true);
				}
				return Encoding.bigEndianUnicode;
			}
		}

		/// <summary>Gets an encoding for the UTF-7 format.</summary>
		/// <returns>An encoding for the UTF-7 format.</returns>
		// Token: 0x170011C2 RID: 4546
		// (get) Token: 0x06006751 RID: 26449 RVA: 0x0015BE1F File Offset: 0x0015A01F
		[__DynamicallyInvokable]
		public static Encoding UTF7
		{
			[__DynamicallyInvokable]
			get
			{
				if (Encoding.utf7Encoding == null)
				{
					Encoding.utf7Encoding = new UTF7Encoding();
				}
				return Encoding.utf7Encoding;
			}
		}

		/// <summary>Gets an encoding for the UTF-8 format.</summary>
		/// <returns>An encoding for the UTF-8 format.</returns>
		// Token: 0x170011C3 RID: 4547
		// (get) Token: 0x06006752 RID: 26450 RVA: 0x0015BE3D File Offset: 0x0015A03D
		[__DynamicallyInvokable]
		public static Encoding UTF8
		{
			[__DynamicallyInvokable]
			get
			{
				if (Encoding.utf8Encoding == null)
				{
					Encoding.utf8Encoding = new UTF8Encoding(true);
				}
				return Encoding.utf8Encoding;
			}
		}

		/// <summary>Gets an encoding for the UTF-32 format using the little endian byte order.</summary>
		/// <returns>An  encoding object for the UTF-32 format using the little endian byte order.</returns>
		// Token: 0x170011C4 RID: 4548
		// (get) Token: 0x06006753 RID: 26451 RVA: 0x0015BE5C File Offset: 0x0015A05C
		[__DynamicallyInvokable]
		public static Encoding UTF32
		{
			[__DynamicallyInvokable]
			get
			{
				if (Encoding.utf32Encoding == null)
				{
					Encoding.utf32Encoding = new UTF32Encoding(false, true);
				}
				return Encoding.utf32Encoding;
			}
		}

		/// <summary>Determines whether the specified <see cref="T:System.Object" /> is equal to the current instance.</summary>
		/// <param name="value">The <see cref="T:System.Object" /> to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is an instance of <see cref="T:System.Text.Encoding" /> and is equal to the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006754 RID: 26452 RVA: 0x0015BE7C File Offset: 0x0015A07C
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			Encoding encoding = value as Encoding;
			return encoding != null && (this.m_codePage == encoding.m_codePage && this.EncoderFallback.Equals(encoding.EncoderFallback)) && this.DecoderFallback.Equals(encoding.DecoderFallback);
		}

		/// <summary>Returns the hash code for the current instance.</summary>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x06006755 RID: 26453 RVA: 0x0015BEC9 File Offset: 0x0015A0C9
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_codePage + this.EncoderFallback.GetHashCode() + this.DecoderFallback.GetHashCode();
		}

		// Token: 0x06006756 RID: 26454 RVA: 0x0015BEE9 File Offset: 0x0015A0E9
		internal virtual char[] GetBestFitUnicodeToBytesData()
		{
			return EmptyArray<char>.Value;
		}

		// Token: 0x06006757 RID: 26455 RVA: 0x0015BEF0 File Offset: 0x0015A0F0
		internal virtual char[] GetBestFitBytesToUnicodeData()
		{
			return EmptyArray<char>.Value;
		}

		// Token: 0x06006758 RID: 26456 RVA: 0x0015BEF7 File Offset: 0x0015A0F7
		internal void ThrowBytesOverflow()
		{
			throw new ArgumentException(Environment.GetResourceString("Argument_EncodingConversionOverflowBytes", new object[]
			{
				this.EncodingName,
				this.EncoderFallback.GetType()
			}), "bytes");
		}

		// Token: 0x06006759 RID: 26457 RVA: 0x0015BF2A File Offset: 0x0015A12A
		[SecurityCritical]
		internal void ThrowBytesOverflow(EncoderNLS encoder, bool nothingEncoded)
		{
			if (encoder == null || encoder.m_throwOnOverflow || nothingEncoded)
			{
				if (encoder != null && encoder.InternalHasFallbackBuffer)
				{
					encoder.FallbackBuffer.InternalReset();
				}
				this.ThrowBytesOverflow();
			}
			encoder.ClearMustFlush();
		}

		// Token: 0x0600675A RID: 26458 RVA: 0x0015BF5E File Offset: 0x0015A15E
		internal void ThrowCharsOverflow()
		{
			throw new ArgumentException(Environment.GetResourceString("Argument_EncodingConversionOverflowChars", new object[]
			{
				this.EncodingName,
				this.DecoderFallback.GetType()
			}), "chars");
		}

		// Token: 0x0600675B RID: 26459 RVA: 0x0015BF91 File Offset: 0x0015A191
		[SecurityCritical]
		internal void ThrowCharsOverflow(DecoderNLS decoder, bool nothingDecoded)
		{
			if (decoder == null || decoder.m_throwOnOverflow || nothingDecoded)
			{
				if (decoder != null && decoder.InternalHasFallbackBuffer)
				{
					decoder.FallbackBuffer.InternalReset();
				}
				this.ThrowCharsOverflow();
			}
			decoder.ClearMustFlush();
		}

		// Token: 0x04002DBB RID: 11707
		private static readonly UTF8Encoding.UTF8EncodingSealed s_defaultUtf8EncodingNoBom = new UTF8Encoding.UTF8EncodingSealed(false);

		// Token: 0x04002DBC RID: 11708
		private static volatile Encoding defaultEncoding;

		// Token: 0x04002DBD RID: 11709
		private static volatile Encoding unicodeEncoding;

		// Token: 0x04002DBE RID: 11710
		private static volatile Encoding bigEndianUnicode;

		// Token: 0x04002DBF RID: 11711
		private static volatile Encoding utf7Encoding;

		// Token: 0x04002DC0 RID: 11712
		private static volatile Encoding utf8Encoding;

		// Token: 0x04002DC1 RID: 11713
		private static volatile Encoding utf32Encoding;

		// Token: 0x04002DC2 RID: 11714
		private static volatile Encoding asciiEncoding;

		// Token: 0x04002DC3 RID: 11715
		private static volatile Encoding latin1Encoding;

		// Token: 0x04002DC4 RID: 11716
		private static volatile Hashtable encodings;

		// Token: 0x04002DC5 RID: 11717
		private const int MIMECONTF_MAILNEWS = 1;

		// Token: 0x04002DC6 RID: 11718
		private const int MIMECONTF_BROWSER = 2;

		// Token: 0x04002DC7 RID: 11719
		private const int MIMECONTF_SAVABLE_MAILNEWS = 256;

		// Token: 0x04002DC8 RID: 11720
		private const int MIMECONTF_SAVABLE_BROWSER = 512;

		// Token: 0x04002DC9 RID: 11721
		private const int CodePageDefault = 0;

		// Token: 0x04002DCA RID: 11722
		private const int CodePageNoOEM = 1;

		// Token: 0x04002DCB RID: 11723
		private const int CodePageNoMac = 2;

		// Token: 0x04002DCC RID: 11724
		private const int CodePageNoThread = 3;

		// Token: 0x04002DCD RID: 11725
		private const int CodePageNoSymbol = 42;

		// Token: 0x04002DCE RID: 11726
		private const int CodePageUnicode = 1200;

		// Token: 0x04002DCF RID: 11727
		private const int CodePageBigEndian = 1201;

		// Token: 0x04002DD0 RID: 11728
		private const int CodePageWindows1252 = 1252;

		// Token: 0x04002DD1 RID: 11729
		private const int CodePageMacGB2312 = 10008;

		// Token: 0x04002DD2 RID: 11730
		private const int CodePageGB2312 = 20936;

		// Token: 0x04002DD3 RID: 11731
		private const int CodePageMacKorean = 10003;

		// Token: 0x04002DD4 RID: 11732
		private const int CodePageDLLKorean = 20949;

		// Token: 0x04002DD5 RID: 11733
		private const int ISO2022JP = 50220;

		// Token: 0x04002DD6 RID: 11734
		private const int ISO2022JPESC = 50221;

		// Token: 0x04002DD7 RID: 11735
		private const int ISO2022JPSISO = 50222;

		// Token: 0x04002DD8 RID: 11736
		private const int ISOKorean = 50225;

		// Token: 0x04002DD9 RID: 11737
		private const int ISOSimplifiedCN = 50227;

		// Token: 0x04002DDA RID: 11738
		private const int EUCJP = 51932;

		// Token: 0x04002DDB RID: 11739
		private const int ChineseHZ = 52936;

		// Token: 0x04002DDC RID: 11740
		private const int DuplicateEUCCN = 51936;

		// Token: 0x04002DDD RID: 11741
		private const int EUCCN = 936;

		// Token: 0x04002DDE RID: 11742
		private const int EUCKR = 51949;

		// Token: 0x04002DDF RID: 11743
		internal const int CodePageASCII = 20127;

		// Token: 0x04002DE0 RID: 11744
		internal const int ISO_8859_1 = 28591;

		// Token: 0x04002DE1 RID: 11745
		private const int ISCIIAssemese = 57006;

		// Token: 0x04002DE2 RID: 11746
		private const int ISCIIBengali = 57003;

		// Token: 0x04002DE3 RID: 11747
		private const int ISCIIDevanagari = 57002;

		// Token: 0x04002DE4 RID: 11748
		private const int ISCIIGujarathi = 57010;

		// Token: 0x04002DE5 RID: 11749
		private const int ISCIIKannada = 57008;

		// Token: 0x04002DE6 RID: 11750
		private const int ISCIIMalayalam = 57009;

		// Token: 0x04002DE7 RID: 11751
		private const int ISCIIOriya = 57007;

		// Token: 0x04002DE8 RID: 11752
		private const int ISCIIPanjabi = 57011;

		// Token: 0x04002DE9 RID: 11753
		private const int ISCIITamil = 57004;

		// Token: 0x04002DEA RID: 11754
		private const int ISCIITelugu = 57005;

		// Token: 0x04002DEB RID: 11755
		private const int GB18030 = 54936;

		// Token: 0x04002DEC RID: 11756
		private const int ISO_8859_8I = 38598;

		// Token: 0x04002DED RID: 11757
		private const int ISO_8859_8_Visual = 28598;

		// Token: 0x04002DEE RID: 11758
		private const int ENC50229 = 50229;

		// Token: 0x04002DEF RID: 11759
		private const int CodePageUTF7 = 65000;

		// Token: 0x04002DF0 RID: 11760
		private const int CodePageUTF8 = 65001;

		// Token: 0x04002DF1 RID: 11761
		private const int CodePageUTF32 = 12000;

		// Token: 0x04002DF2 RID: 11762
		private const int CodePageUTF32BE = 12001;

		// Token: 0x04002DF3 RID: 11763
		internal int m_codePage;

		// Token: 0x04002DF4 RID: 11764
		internal CodePageDataItem dataItem;

		// Token: 0x04002DF5 RID: 11765
		[NonSerialized]
		internal bool m_deserializedFromEverett;

		// Token: 0x04002DF6 RID: 11766
		[OptionalField(VersionAdded = 2)]
		private bool m_isReadOnly;

		// Token: 0x04002DF7 RID: 11767
		[OptionalField(VersionAdded = 2)]
		internal EncoderFallback encoderFallback;

		// Token: 0x04002DF8 RID: 11768
		[OptionalField(VersionAdded = 2)]
		internal DecoderFallback decoderFallback;

		// Token: 0x04002DF9 RID: 11769
		private static object s_InternalSyncObject;

		// Token: 0x02000C7B RID: 3195
		[Serializable]
		internal class DefaultEncoder : Encoder, ISerializable, IObjectReference
		{
			// Token: 0x0600702E RID: 28718 RVA: 0x001813AB File Offset: 0x0017F5AB
			public DefaultEncoder(Encoding encoding)
			{
				this.m_encoding = encoding;
				this.m_hasInitializedEncoding = true;
			}

			// Token: 0x0600702F RID: 28719 RVA: 0x001813C4 File Offset: 0x0017F5C4
			internal DefaultEncoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.m_encoding = (Encoding)info.GetValue("encoding", typeof(Encoding));
				try
				{
					this.m_fallback = (EncoderFallback)info.GetValue("m_fallback", typeof(EncoderFallback));
					this.charLeftOver = (char)info.GetValue("charLeftOver", typeof(char));
				}
				catch (SerializationException)
				{
				}
			}

			// Token: 0x06007030 RID: 28720 RVA: 0x0018145C File Offset: 0x0017F65C
			[SecurityCritical]
			public object GetRealObject(StreamingContext context)
			{
				if (this.m_hasInitializedEncoding)
				{
					return this;
				}
				Encoder encoder = this.m_encoding.GetEncoder();
				if (this.m_fallback != null)
				{
					encoder.m_fallback = this.m_fallback;
				}
				if (this.charLeftOver != '\0')
				{
					EncoderNLS encoderNLS = encoder as EncoderNLS;
					if (encoderNLS != null)
					{
						encoderNLS.charLeftOver = this.charLeftOver;
					}
				}
				return encoder;
			}

			// Token: 0x06007031 RID: 28721 RVA: 0x001814B2 File Offset: 0x0017F6B2
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				info.AddValue("encoding", this.m_encoding);
			}

			// Token: 0x06007032 RID: 28722 RVA: 0x001814D3 File Offset: 0x0017F6D3
			public override int GetByteCount(char[] chars, int index, int count, bool flush)
			{
				return this.m_encoding.GetByteCount(chars, index, count);
			}

			// Token: 0x06007033 RID: 28723 RVA: 0x001814E3 File Offset: 0x0017F6E3
			[SecurityCritical]
			public unsafe override int GetByteCount(char* chars, int count, bool flush)
			{
				return this.m_encoding.GetByteCount(chars, count);
			}

			// Token: 0x06007034 RID: 28724 RVA: 0x001814F2 File Offset: 0x0017F6F2
			public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush)
			{
				return this.m_encoding.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
			}

			// Token: 0x06007035 RID: 28725 RVA: 0x00181506 File Offset: 0x0017F706
			[SecurityCritical]
			public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush)
			{
				return this.m_encoding.GetBytes(chars, charCount, bytes, byteCount);
			}

			// Token: 0x040037BE RID: 14270
			private Encoding m_encoding;

			// Token: 0x040037BF RID: 14271
			[NonSerialized]
			private bool m_hasInitializedEncoding;

			// Token: 0x040037C0 RID: 14272
			[NonSerialized]
			internal char charLeftOver;
		}

		// Token: 0x02000C7C RID: 3196
		[Serializable]
		internal class DefaultDecoder : Decoder, ISerializable, IObjectReference
		{
			// Token: 0x06007036 RID: 28726 RVA: 0x00181518 File Offset: 0x0017F718
			public DefaultDecoder(Encoding encoding)
			{
				this.m_encoding = encoding;
				this.m_hasInitializedEncoding = true;
			}

			// Token: 0x06007037 RID: 28727 RVA: 0x00181530 File Offset: 0x0017F730
			internal DefaultDecoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.m_encoding = (Encoding)info.GetValue("encoding", typeof(Encoding));
				try
				{
					this.m_fallback = (DecoderFallback)info.GetValue("m_fallback", typeof(DecoderFallback));
				}
				catch (SerializationException)
				{
					this.m_fallback = null;
				}
			}

			// Token: 0x06007038 RID: 28728 RVA: 0x001815B0 File Offset: 0x0017F7B0
			[SecurityCritical]
			public object GetRealObject(StreamingContext context)
			{
				if (this.m_hasInitializedEncoding)
				{
					return this;
				}
				Decoder decoder = this.m_encoding.GetDecoder();
				if (this.m_fallback != null)
				{
					decoder.m_fallback = this.m_fallback;
				}
				return decoder;
			}

			// Token: 0x06007039 RID: 28729 RVA: 0x001815E8 File Offset: 0x0017F7E8
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				info.AddValue("encoding", this.m_encoding);
			}

			// Token: 0x0600703A RID: 28730 RVA: 0x00181609 File Offset: 0x0017F809
			public override int GetCharCount(byte[] bytes, int index, int count)
			{
				return this.GetCharCount(bytes, index, count, false);
			}

			// Token: 0x0600703B RID: 28731 RVA: 0x00181615 File Offset: 0x0017F815
			public override int GetCharCount(byte[] bytes, int index, int count, bool flush)
			{
				return this.m_encoding.GetCharCount(bytes, index, count);
			}

			// Token: 0x0600703C RID: 28732 RVA: 0x00181625 File Offset: 0x0017F825
			[SecurityCritical]
			public unsafe override int GetCharCount(byte* bytes, int count, bool flush)
			{
				return this.m_encoding.GetCharCount(bytes, count);
			}

			// Token: 0x0600703D RID: 28733 RVA: 0x00181634 File Offset: 0x0017F834
			public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
			{
				return this.GetChars(bytes, byteIndex, byteCount, chars, charIndex, false);
			}

			// Token: 0x0600703E RID: 28734 RVA: 0x00181644 File Offset: 0x0017F844
			public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush)
			{
				return this.m_encoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
			}

			// Token: 0x0600703F RID: 28735 RVA: 0x00181658 File Offset: 0x0017F858
			[SecurityCritical]
			public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush)
			{
				return this.m_encoding.GetChars(bytes, byteCount, chars, charCount);
			}

			// Token: 0x040037C1 RID: 14273
			private Encoding m_encoding;

			// Token: 0x040037C2 RID: 14274
			[NonSerialized]
			private bool m_hasInitializedEncoding;
		}

		// Token: 0x02000C7D RID: 3197
		internal class EncodingCharBuffer
		{
			// Token: 0x06007040 RID: 28736 RVA: 0x0018166C File Offset: 0x0017F86C
			[SecurityCritical]
			internal unsafe EncodingCharBuffer(Encoding enc, DecoderNLS decoder, char* charStart, int charCount, byte* byteStart, int byteCount)
			{
				this.enc = enc;
				this.decoder = decoder;
				this.chars = charStart;
				this.charStart = charStart;
				this.charEnd = charStart + charCount;
				this.byteStart = byteStart;
				this.bytes = byteStart;
				this.byteEnd = byteStart + byteCount;
				if (this.decoder == null)
				{
					this.fallbackBuffer = enc.DecoderFallback.CreateFallbackBuffer();
				}
				else
				{
					this.fallbackBuffer = this.decoder.FallbackBuffer;
				}
				this.fallbackBuffer.InternalInitialize(this.bytes, this.charEnd);
			}

			// Token: 0x06007041 RID: 28737 RVA: 0x00181708 File Offset: 0x0017F908
			[SecurityCritical]
			internal unsafe bool AddChar(char ch, int numBytes)
			{
				if (this.chars != null)
				{
					if (this.chars >= this.charEnd)
					{
						this.bytes -= numBytes;
						this.enc.ThrowCharsOverflow(this.decoder, this.bytes == this.byteStart);
						return false;
					}
					char* ptr = this.chars;
					this.chars = ptr + 1;
					*ptr = ch;
				}
				this.charCountResult++;
				return true;
			}

			// Token: 0x06007042 RID: 28738 RVA: 0x00181781 File Offset: 0x0017F981
			[SecurityCritical]
			internal bool AddChar(char ch)
			{
				return this.AddChar(ch, 1);
			}

			// Token: 0x06007043 RID: 28739 RVA: 0x0018178C File Offset: 0x0017F98C
			[SecurityCritical]
			internal bool AddChar(char ch1, char ch2, int numBytes)
			{
				if (this.chars >= this.charEnd - 1)
				{
					this.bytes -= numBytes;
					this.enc.ThrowCharsOverflow(this.decoder, this.bytes == this.byteStart);
					return false;
				}
				return this.AddChar(ch1, numBytes) && this.AddChar(ch2, numBytes);
			}

			// Token: 0x06007044 RID: 28740 RVA: 0x001817EF File Offset: 0x0017F9EF
			[SecurityCritical]
			internal void AdjustBytes(int count)
			{
				this.bytes += count;
			}

			// Token: 0x17001354 RID: 4948
			// (get) Token: 0x06007045 RID: 28741 RVA: 0x001817FF File Offset: 0x0017F9FF
			internal bool MoreData
			{
				[SecurityCritical]
				get
				{
					return this.bytes < this.byteEnd;
				}
			}

			// Token: 0x06007046 RID: 28742 RVA: 0x0018180F File Offset: 0x0017FA0F
			[SecurityCritical]
			internal bool EvenMoreData(int count)
			{
				return this.bytes == this.byteEnd - count;
			}

			// Token: 0x06007047 RID: 28743 RVA: 0x00181824 File Offset: 0x0017FA24
			[SecurityCritical]
			internal unsafe byte GetNextByte()
			{
				if (this.bytes >= this.byteEnd)
				{
					return 0;
				}
				byte* ptr = this.bytes;
				this.bytes = ptr + 1;
				return *ptr;
			}

			// Token: 0x17001355 RID: 4949
			// (get) Token: 0x06007048 RID: 28744 RVA: 0x00181853 File Offset: 0x0017FA53
			internal int BytesUsed
			{
				[SecurityCritical]
				get
				{
					return (int)((long)(this.bytes - this.byteStart));
				}
			}

			// Token: 0x06007049 RID: 28745 RVA: 0x00181868 File Offset: 0x0017FA68
			[SecurityCritical]
			internal bool Fallback(byte fallbackByte)
			{
				byte[] byteBuffer = new byte[]
				{
					fallbackByte
				};
				return this.Fallback(byteBuffer);
			}

			// Token: 0x0600704A RID: 28746 RVA: 0x00181888 File Offset: 0x0017FA88
			[SecurityCritical]
			internal bool Fallback(byte byte1, byte byte2)
			{
				byte[] byteBuffer = new byte[]
				{
					byte1,
					byte2
				};
				return this.Fallback(byteBuffer);
			}

			// Token: 0x0600704B RID: 28747 RVA: 0x001818AC File Offset: 0x0017FAAC
			[SecurityCritical]
			internal bool Fallback(byte byte1, byte byte2, byte byte3, byte byte4)
			{
				byte[] byteBuffer = new byte[]
				{
					byte1,
					byte2,
					byte3,
					byte4
				};
				return this.Fallback(byteBuffer);
			}

			// Token: 0x0600704C RID: 28748 RVA: 0x001818D8 File Offset: 0x0017FAD8
			[SecurityCritical]
			internal unsafe bool Fallback(byte[] byteBuffer)
			{
				if (this.chars != null)
				{
					char* ptr = this.chars;
					if (!this.fallbackBuffer.InternalFallback(byteBuffer, this.bytes, ref this.chars))
					{
						this.bytes -= byteBuffer.Length;
						this.fallbackBuffer.InternalReset();
						this.enc.ThrowCharsOverflow(this.decoder, this.chars == this.charStart);
						return false;
					}
					this.charCountResult += (int)((long)(this.chars - ptr));
				}
				else
				{
					this.charCountResult += this.fallbackBuffer.InternalFallback(byteBuffer, this.bytes);
				}
				return true;
			}

			// Token: 0x17001356 RID: 4950
			// (get) Token: 0x0600704D RID: 28749 RVA: 0x00181987 File Offset: 0x0017FB87
			internal int Count
			{
				get
				{
					return this.charCountResult;
				}
			}

			// Token: 0x040037C3 RID: 14275
			[SecurityCritical]
			private unsafe char* chars;

			// Token: 0x040037C4 RID: 14276
			[SecurityCritical]
			private unsafe char* charStart;

			// Token: 0x040037C5 RID: 14277
			[SecurityCritical]
			private unsafe char* charEnd;

			// Token: 0x040037C6 RID: 14278
			private int charCountResult;

			// Token: 0x040037C7 RID: 14279
			private Encoding enc;

			// Token: 0x040037C8 RID: 14280
			private DecoderNLS decoder;

			// Token: 0x040037C9 RID: 14281
			[SecurityCritical]
			private unsafe byte* byteStart;

			// Token: 0x040037CA RID: 14282
			[SecurityCritical]
			private unsafe byte* byteEnd;

			// Token: 0x040037CB RID: 14283
			[SecurityCritical]
			private unsafe byte* bytes;

			// Token: 0x040037CC RID: 14284
			private DecoderFallbackBuffer fallbackBuffer;
		}

		// Token: 0x02000C7E RID: 3198
		internal class EncodingByteBuffer
		{
			// Token: 0x0600704E RID: 28750 RVA: 0x00181990 File Offset: 0x0017FB90
			[SecurityCritical]
			internal unsafe EncodingByteBuffer(Encoding inEncoding, EncoderNLS inEncoder, byte* inByteStart, int inByteCount, char* inCharStart, int inCharCount)
			{
				this.enc = inEncoding;
				this.encoder = inEncoder;
				this.charStart = inCharStart;
				this.chars = inCharStart;
				this.charEnd = inCharStart + inCharCount;
				this.bytes = inByteStart;
				this.byteStart = inByteStart;
				this.byteEnd = inByteStart + inByteCount;
				if (this.encoder == null)
				{
					this.fallbackBuffer = this.enc.EncoderFallback.CreateFallbackBuffer();
				}
				else
				{
					this.fallbackBuffer = this.encoder.FallbackBuffer;
					if (this.encoder.m_throwOnOverflow && this.encoder.InternalHasFallbackBuffer && this.fallbackBuffer.Remaining > 0)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_EncoderFallbackNotEmpty", new object[]
						{
							this.encoder.Encoding.EncodingName,
							this.encoder.Fallback.GetType()
						}));
					}
				}
				this.fallbackBuffer.InternalInitialize(this.chars, this.charEnd, this.encoder, this.bytes != null);
			}

			// Token: 0x0600704F RID: 28751 RVA: 0x00181AA8 File Offset: 0x0017FCA8
			[SecurityCritical]
			internal unsafe bool AddByte(byte b, int moreBytesExpected)
			{
				if (this.bytes != null)
				{
					if (this.bytes >= this.byteEnd - moreBytesExpected)
					{
						this.MovePrevious(true);
						return false;
					}
					byte* ptr = this.bytes;
					this.bytes = ptr + 1;
					*ptr = b;
				}
				this.byteCountResult++;
				return true;
			}

			// Token: 0x06007050 RID: 28752 RVA: 0x00181AFA File Offset: 0x0017FCFA
			[SecurityCritical]
			internal bool AddByte(byte b1)
			{
				return this.AddByte(b1, 0);
			}

			// Token: 0x06007051 RID: 28753 RVA: 0x00181B04 File Offset: 0x0017FD04
			[SecurityCritical]
			internal bool AddByte(byte b1, byte b2)
			{
				return this.AddByte(b1, b2, 0);
			}

			// Token: 0x06007052 RID: 28754 RVA: 0x00181B0F File Offset: 0x0017FD0F
			[SecurityCritical]
			internal bool AddByte(byte b1, byte b2, int moreBytesExpected)
			{
				return this.AddByte(b1, 1 + moreBytesExpected) && this.AddByte(b2, moreBytesExpected);
			}

			// Token: 0x06007053 RID: 28755 RVA: 0x00181B27 File Offset: 0x0017FD27
			[SecurityCritical]
			internal bool AddByte(byte b1, byte b2, byte b3)
			{
				return this.AddByte(b1, b2, b3, 0);
			}

			// Token: 0x06007054 RID: 28756 RVA: 0x00181B33 File Offset: 0x0017FD33
			[SecurityCritical]
			internal bool AddByte(byte b1, byte b2, byte b3, int moreBytesExpected)
			{
				return this.AddByte(b1, 2 + moreBytesExpected) && this.AddByte(b2, 1 + moreBytesExpected) && this.AddByte(b3, moreBytesExpected);
			}

			// Token: 0x06007055 RID: 28757 RVA: 0x00181B5A File Offset: 0x0017FD5A
			[SecurityCritical]
			internal bool AddByte(byte b1, byte b2, byte b3, byte b4)
			{
				return this.AddByte(b1, 3) && this.AddByte(b2, 2) && this.AddByte(b3, 1) && this.AddByte(b4, 0);
			}

			// Token: 0x06007056 RID: 28758 RVA: 0x00181B88 File Offset: 0x0017FD88
			[SecurityCritical]
			internal void MovePrevious(bool bThrow)
			{
				if (this.fallbackBuffer.bFallingBack)
				{
					this.fallbackBuffer.MovePrevious();
				}
				else if (this.chars != this.charStart)
				{
					this.chars--;
				}
				if (bThrow)
				{
					this.enc.ThrowBytesOverflow(this.encoder, this.bytes == this.byteStart);
				}
			}

			// Token: 0x06007057 RID: 28759 RVA: 0x00181BEE File Offset: 0x0017FDEE
			[SecurityCritical]
			internal bool Fallback(char charFallback)
			{
				return this.fallbackBuffer.InternalFallback(charFallback, ref this.chars);
			}

			// Token: 0x17001357 RID: 4951
			// (get) Token: 0x06007058 RID: 28760 RVA: 0x00181C02 File Offset: 0x0017FE02
			internal bool MoreData
			{
				[SecurityCritical]
				get
				{
					return this.fallbackBuffer.Remaining > 0 || this.chars < this.charEnd;
				}
			}

			// Token: 0x06007059 RID: 28761 RVA: 0x00181C24 File Offset: 0x0017FE24
			[SecurityCritical]
			internal unsafe char GetNextChar()
			{
				char c = this.fallbackBuffer.InternalGetNextChar();
				if (c == '\0' && this.chars < this.charEnd)
				{
					char* ptr = this.chars;
					this.chars = ptr + 1;
					c = *ptr;
				}
				return c;
			}

			// Token: 0x17001358 RID: 4952
			// (get) Token: 0x0600705A RID: 28762 RVA: 0x00181C62 File Offset: 0x0017FE62
			internal int CharsUsed
			{
				[SecurityCritical]
				get
				{
					return (int)((long)(this.chars - this.charStart));
				}
			}

			// Token: 0x17001359 RID: 4953
			// (get) Token: 0x0600705B RID: 28763 RVA: 0x00181C75 File Offset: 0x0017FE75
			internal int Count
			{
				get
				{
					return this.byteCountResult;
				}
			}

			// Token: 0x040037CD RID: 14285
			[SecurityCritical]
			private unsafe byte* bytes;

			// Token: 0x040037CE RID: 14286
			[SecurityCritical]
			private unsafe byte* byteStart;

			// Token: 0x040037CF RID: 14287
			[SecurityCritical]
			private unsafe byte* byteEnd;

			// Token: 0x040037D0 RID: 14288
			[SecurityCritical]
			private unsafe char* chars;

			// Token: 0x040037D1 RID: 14289
			[SecurityCritical]
			private unsafe char* charStart;

			// Token: 0x040037D2 RID: 14290
			[SecurityCritical]
			private unsafe char* charEnd;

			// Token: 0x040037D3 RID: 14291
			private int byteCountResult;

			// Token: 0x040037D4 RID: 14292
			private Encoding enc;

			// Token: 0x040037D5 RID: 14293
			private EncoderNLS encoder;

			// Token: 0x040037D6 RID: 14294
			internal EncoderFallbackBuffer fallbackBuffer;
		}
	}
}
