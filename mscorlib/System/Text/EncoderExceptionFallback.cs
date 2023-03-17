using System;

namespace System.Text
{
	/// <summary>Provides a failure-handling mechanism, called a fallback, for an input character that cannot be converted to an output byte sequence. The fallback throws an exception if an input character cannot be converted to an output byte sequence. This class cannot be inherited.</summary>
	// Token: 0x02000A3F RID: 2623
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class EncoderExceptionFallback : EncoderFallback
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderExceptionFallback" /> class.</summary>
		// Token: 0x060066CE RID: 26318 RVA: 0x0015A753 File Offset: 0x00158953
		[__DynamicallyInvokable]
		public EncoderExceptionFallback()
		{
		}

		/// <summary>Returns an encoder fallback buffer that throws an exception if it cannot convert a character sequence to a byte sequence.</summary>
		/// <returns>An encoder fallback buffer that throws an exception when it cannot encode a character sequence.</returns>
		// Token: 0x060066CF RID: 26319 RVA: 0x0015A75B File Offset: 0x0015895B
		[__DynamicallyInvokable]
		public override EncoderFallbackBuffer CreateFallbackBuffer()
		{
			return new EncoderExceptionFallbackBuffer();
		}

		/// <summary>Gets the maximum number of characters this instance can return.</summary>
		/// <returns>The return value is always zero.</returns>
		// Token: 0x170011A0 RID: 4512
		// (get) Token: 0x060066D0 RID: 26320 RVA: 0x0015A762 File Offset: 0x00158962
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return 0;
			}
		}

		/// <summary>Indicates whether the current <see cref="T:System.Text.EncoderExceptionFallback" /> object and a specified object are equal.</summary>
		/// <param name="value">An object that derives from the <see cref="T:System.Text.EncoderExceptionFallback" /> class.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is not <see langword="null" /> (<see langword="Nothing" /> in Visual Basic .NET) and is a <see cref="T:System.Text.EncoderExceptionFallback" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060066D1 RID: 26321 RVA: 0x0015A768 File Offset: 0x00158968
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			return value is EncoderExceptionFallback;
		}

		/// <summary>Retrieves the hash code for this instance.</summary>
		/// <returns>The return value is always the same arbitrary value, and has no special significance.</returns>
		// Token: 0x060066D2 RID: 26322 RVA: 0x0015A782 File Offset: 0x00158982
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return 654;
		}
	}
}
