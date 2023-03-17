using System;
using System.Runtime.Serialization;

namespace System.Text
{
	/// <summary>The exception that is thrown when an encoder fallback operation fails. This class cannot be inherited.</summary>
	// Token: 0x02000A41 RID: 2625
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class EncoderFallbackException : ArgumentException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderFallbackException" /> class.</summary>
		// Token: 0x060066D9 RID: 26329 RVA: 0x0015A87E File Offset: 0x00158A7E
		[__DynamicallyInvokable]
		public EncoderFallbackException() : base(Environment.GetResourceString("Arg_ArgumentException"))
		{
			base.SetErrorCode(-2147024809);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderFallbackException" /> class. A parameter specifies the error message.</summary>
		/// <param name="message">An error message.</param>
		// Token: 0x060066DA RID: 26330 RVA: 0x0015A89B File Offset: 0x00158A9B
		[__DynamicallyInvokable]
		public EncoderFallbackException(string message) : base(message)
		{
			base.SetErrorCode(-2147024809);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderFallbackException" /> class. Parameters specify the error message and the inner exception that is the cause of this exception.</summary>
		/// <param name="message">An error message.</param>
		/// <param name="innerException">The exception that caused this exception.</param>
		// Token: 0x060066DB RID: 26331 RVA: 0x0015A8AF File Offset: 0x00158AAF
		[__DynamicallyInvokable]
		public EncoderFallbackException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2147024809);
		}

		// Token: 0x060066DC RID: 26332 RVA: 0x0015A8C4 File Offset: 0x00158AC4
		internal EncoderFallbackException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060066DD RID: 26333 RVA: 0x0015A8CE File Offset: 0x00158ACE
		internal EncoderFallbackException(string message, char charUnknown, int index) : base(message)
		{
			this.charUnknown = charUnknown;
			this.index = index;
		}

		// Token: 0x060066DE RID: 26334 RVA: 0x0015A8E8 File Offset: 0x00158AE8
		internal EncoderFallbackException(string message, char charUnknownHigh, char charUnknownLow, int index) : base(message)
		{
			if (!char.IsHighSurrogate(charUnknownHigh))
			{
				throw new ArgumentOutOfRangeException("charUnknownHigh", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					55296,
					56319
				}));
			}
			if (!char.IsLowSurrogate(charUnknownLow))
			{
				throw new ArgumentOutOfRangeException("CharUnknownLow", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					56320,
					57343
				}));
			}
			this.charUnknownHigh = charUnknownHigh;
			this.charUnknownLow = charUnknownLow;
			this.index = index;
		}

		/// <summary>Gets the input character that caused the exception.</summary>
		/// <returns>The character that cannot be encoded.</returns>
		// Token: 0x170011A2 RID: 4514
		// (get) Token: 0x060066DF RID: 26335 RVA: 0x0015A98C File Offset: 0x00158B8C
		[__DynamicallyInvokable]
		public char CharUnknown
		{
			[__DynamicallyInvokable]
			get
			{
				return this.charUnknown;
			}
		}

		/// <summary>Gets the high component character of the surrogate pair that caused the exception.</summary>
		/// <returns>The high component character of the surrogate pair that cannot be encoded.</returns>
		// Token: 0x170011A3 RID: 4515
		// (get) Token: 0x060066E0 RID: 26336 RVA: 0x0015A994 File Offset: 0x00158B94
		[__DynamicallyInvokable]
		public char CharUnknownHigh
		{
			[__DynamicallyInvokable]
			get
			{
				return this.charUnknownHigh;
			}
		}

		/// <summary>Gets the low component character of the surrogate pair that caused the exception.</summary>
		/// <returns>The low component character of the surrogate pair that cannot be encoded.</returns>
		// Token: 0x170011A4 RID: 4516
		// (get) Token: 0x060066E1 RID: 26337 RVA: 0x0015A99C File Offset: 0x00158B9C
		[__DynamicallyInvokable]
		public char CharUnknownLow
		{
			[__DynamicallyInvokable]
			get
			{
				return this.charUnknownLow;
			}
		}

		/// <summary>Gets the index position in the input buffer of the character that caused the exception.</summary>
		/// <returns>The index position in the input buffer of the character that cannot be encoded.</returns>
		// Token: 0x170011A5 RID: 4517
		// (get) Token: 0x060066E2 RID: 26338 RVA: 0x0015A9A4 File Offset: 0x00158BA4
		[__DynamicallyInvokable]
		public int Index
		{
			[__DynamicallyInvokable]
			get
			{
				return this.index;
			}
		}

		/// <summary>Indicates whether the input that caused the exception is a surrogate pair.</summary>
		/// <returns>
		///   <see langword="true" /> if the input was a surrogate pair; otherwise, <see langword="false" />.</returns>
		// Token: 0x060066E3 RID: 26339 RVA: 0x0015A9AC File Offset: 0x00158BAC
		[__DynamicallyInvokable]
		public bool IsUnknownSurrogate()
		{
			return this.charUnknownHigh > '\0';
		}

		// Token: 0x04002DA7 RID: 11687
		private char charUnknown;

		// Token: 0x04002DA8 RID: 11688
		private char charUnknownHigh;

		// Token: 0x04002DA9 RID: 11689
		private char charUnknownLow;

		// Token: 0x04002DAA RID: 11690
		private int index;
	}
}
