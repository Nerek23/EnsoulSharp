using System;
using System.Runtime.Serialization;

namespace System.Text
{
	/// <summary>The exception that is thrown when a decoder fallback operation fails. This class cannot be inherited.</summary>
	// Token: 0x02000A36 RID: 2614
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecoderFallbackException : ArgumentException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderFallbackException" /> class.</summary>
		// Token: 0x0600667D RID: 26237 RVA: 0x00159551 File Offset: 0x00157751
		[__DynamicallyInvokable]
		public DecoderFallbackException() : base(Environment.GetResourceString("Arg_ArgumentException"))
		{
			base.SetErrorCode(-2147024809);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderFallbackException" /> class. A parameter specifies the error message.</summary>
		/// <param name="message">An error message.</param>
		// Token: 0x0600667E RID: 26238 RVA: 0x0015956E File Offset: 0x0015776E
		[__DynamicallyInvokable]
		public DecoderFallbackException(string message) : base(message)
		{
			base.SetErrorCode(-2147024809);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderFallbackException" /> class. Parameters specify the error message and the inner exception that is the cause of this exception.</summary>
		/// <param name="message">An error message.</param>
		/// <param name="innerException">The exception that caused this exception.</param>
		// Token: 0x0600667F RID: 26239 RVA: 0x00159582 File Offset: 0x00157782
		[__DynamicallyInvokable]
		public DecoderFallbackException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x06006680 RID: 26240 RVA: 0x00159597 File Offset: 0x00157797
		internal DecoderFallbackException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderFallbackException" /> class. Parameters specify the error message, the array of bytes being decoded, and the index of the byte that cannot be decoded.</summary>
		/// <param name="message">An error message.</param>
		/// <param name="bytesUnknown">The input byte array.</param>
		/// <param name="index">The index position in <paramref name="bytesUnknown" /> of the byte that cannot be decoded.</param>
		// Token: 0x06006681 RID: 26241 RVA: 0x001595A1 File Offset: 0x001577A1
		[__DynamicallyInvokable]
		public DecoderFallbackException(string message, byte[] bytesUnknown, int index) : base(message)
		{
			this.bytesUnknown = bytesUnknown;
			this.index = index;
		}

		/// <summary>Gets the input byte sequence that caused the exception.</summary>
		/// <returns>The input byte array that cannot be decoded.</returns>
		// Token: 0x1700118C RID: 4492
		// (get) Token: 0x06006682 RID: 26242 RVA: 0x001595B8 File Offset: 0x001577B8
		[__DynamicallyInvokable]
		public byte[] BytesUnknown
		{
			[__DynamicallyInvokable]
			get
			{
				return this.bytesUnknown;
			}
		}

		/// <summary>Gets the index position in the input byte sequence of the byte that caused the exception.</summary>
		/// <returns>The index position in the input byte array of the byte that cannot be decoded. The index position is zero-based.</returns>
		// Token: 0x1700118D RID: 4493
		// (get) Token: 0x06006683 RID: 26243 RVA: 0x001595C0 File Offset: 0x001577C0
		[__DynamicallyInvokable]
		public int Index
		{
			[__DynamicallyInvokable]
			get
			{
				return this.index;
			}
		}

		// Token: 0x04002D8D RID: 11661
		private byte[] bytesUnknown;

		// Token: 0x04002D8E RID: 11662
		private int index;
	}
}
