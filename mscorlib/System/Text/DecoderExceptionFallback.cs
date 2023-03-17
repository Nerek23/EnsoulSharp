using System;

namespace System.Text
{
	/// <summary>Provides a failure-handling mechanism, called a fallback, for an encoded input byte sequence that cannot be converted to an input character. The fallback throws an exception instead of decoding the input byte sequence. This class cannot be inherited.</summary>
	// Token: 0x02000A34 RID: 2612
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecoderExceptionFallback : DecoderFallback
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderExceptionFallback" /> class.</summary>
		// Token: 0x06006672 RID: 26226 RVA: 0x00159467 File Offset: 0x00157667
		[__DynamicallyInvokable]
		public DecoderExceptionFallback()
		{
		}

		/// <summary>Returns a decoder fallback buffer that throws an exception if it cannot convert a sequence of bytes to a character.</summary>
		/// <returns>A decoder fallback buffer that throws an exception when it cannot decode a byte sequence.</returns>
		// Token: 0x06006673 RID: 26227 RVA: 0x0015946F File Offset: 0x0015766F
		[__DynamicallyInvokable]
		public override DecoderFallbackBuffer CreateFallbackBuffer()
		{
			return new DecoderExceptionFallbackBuffer();
		}

		/// <summary>Gets the maximum number of characters this instance can return.</summary>
		/// <returns>The return value is always zero.</returns>
		// Token: 0x1700118A RID: 4490
		// (get) Token: 0x06006674 RID: 26228 RVA: 0x00159476 File Offset: 0x00157676
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return 0;
			}
		}

		/// <summary>Indicates whether the current <see cref="T:System.Text.DecoderExceptionFallback" /> object and a specified object are equal.</summary>
		/// <param name="value">An object that derives from the <see cref="T:System.Text.DecoderExceptionFallback" /> class.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is not <see langword="null" /> and is a <see cref="T:System.Text.DecoderExceptionFallback" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006675 RID: 26229 RVA: 0x0015947C File Offset: 0x0015767C
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			return value is DecoderExceptionFallback;
		}

		/// <summary>Retrieves the hash code for this instance.</summary>
		/// <returns>The return value is always the same arbitrary value, and has no special significance.</returns>
		// Token: 0x06006676 RID: 26230 RVA: 0x00159496 File Offset: 0x00157696
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return 879;
		}
	}
}
