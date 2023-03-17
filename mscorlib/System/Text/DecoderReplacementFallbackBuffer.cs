using System;
using System.Security;

namespace System.Text
{
	/// <summary>Represents a substitute output string that is emitted when the original input byte sequence cannot be decoded. This class cannot be inherited.</summary>
	// Token: 0x02000A3A RID: 2618
	public sealed class DecoderReplacementFallbackBuffer : DecoderFallbackBuffer
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderReplacementFallbackBuffer" /> class using the value of a <see cref="T:System.Text.DecoderReplacementFallback" /> object.</summary>
		/// <param name="fallback">A <see cref="T:System.Text.DecoderReplacementFallback" /> object that contains a replacement string.</param>
		// Token: 0x0600669D RID: 26269 RVA: 0x0015999F File Offset: 0x00157B9F
		public DecoderReplacementFallbackBuffer(DecoderReplacementFallback fallback)
		{
			this.strDefault = fallback.DefaultString;
		}

		/// <summary>Prepares the replacement fallback buffer to use the current replacement string.</summary>
		/// <param name="bytesUnknown">An input byte sequence. This parameter is ignored unless an exception is thrown.</param>
		/// <param name="index">The index position of the byte in <paramref name="bytesUnknown" />. This parameter is ignored in this operation.</param>
		/// <returns>
		///   <see langword="true" /> if the replacement string is not empty; <see langword="false" /> if the replacement string is empty.</returns>
		/// <exception cref="T:System.ArgumentException">This method is called again before the <see cref="M:System.Text.DecoderReplacementFallbackBuffer.GetNextChar" /> method has read all the characters in the replacement fallback buffer.</exception>
		// Token: 0x0600669E RID: 26270 RVA: 0x001599C1 File Offset: 0x00157BC1
		public override bool Fallback(byte[] bytesUnknown, int index)
		{
			if (this.fallbackCount >= 1)
			{
				base.ThrowLastBytesRecursive(bytesUnknown);
			}
			if (this.strDefault.Length == 0)
			{
				return false;
			}
			this.fallbackCount = this.strDefault.Length;
			this.fallbackIndex = -1;
			return true;
		}

		/// <summary>Retrieves the next character in the replacement fallback buffer.</summary>
		/// <returns>The next character in the replacement fallback buffer.</returns>
		// Token: 0x0600669F RID: 26271 RVA: 0x001599FC File Offset: 0x00157BFC
		public override char GetNextChar()
		{
			this.fallbackCount--;
			this.fallbackIndex++;
			if (this.fallbackCount < 0)
			{
				return '\0';
			}
			if (this.fallbackCount == 2147483647)
			{
				this.fallbackCount = -1;
				return '\0';
			}
			return this.strDefault[this.fallbackIndex];
		}

		/// <summary>Causes the next call to <see cref="M:System.Text.DecoderReplacementFallbackBuffer.GetNextChar" /> to access the character position in the replacement fallback buffer prior to the current character position.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="M:System.Text.DecoderReplacementFallbackBuffer.MovePrevious" /> operation was successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x060066A0 RID: 26272 RVA: 0x00159A57 File Offset: 0x00157C57
		public override bool MovePrevious()
		{
			if (this.fallbackCount >= -1 && this.fallbackIndex >= 0)
			{
				this.fallbackIndex--;
				this.fallbackCount++;
				return true;
			}
			return false;
		}

		/// <summary>Gets the number of characters in the replacement fallback buffer that remain to be processed.</summary>
		/// <returns>The number of characters in the replacement fallback buffer that have not yet been processed.</returns>
		// Token: 0x17001196 RID: 4502
		// (get) Token: 0x060066A1 RID: 26273 RVA: 0x00159A8A File Offset: 0x00157C8A
		public override int Remaining
		{
			get
			{
				if (this.fallbackCount >= 0)
				{
					return this.fallbackCount;
				}
				return 0;
			}
		}

		/// <summary>Initializes all internal state information and data in the <see cref="T:System.Text.DecoderReplacementFallbackBuffer" /> object.</summary>
		// Token: 0x060066A2 RID: 26274 RVA: 0x00159A9D File Offset: 0x00157C9D
		[SecuritySafeCritical]
		public override void Reset()
		{
			this.fallbackCount = -1;
			this.fallbackIndex = -1;
			this.byteStart = null;
		}

		// Token: 0x060066A3 RID: 26275 RVA: 0x00159AB5 File Offset: 0x00157CB5
		[SecurityCritical]
		internal unsafe override int InternalFallback(byte[] bytes, byte* pBytes)
		{
			return this.strDefault.Length;
		}

		// Token: 0x04002D96 RID: 11670
		private string strDefault;

		// Token: 0x04002D97 RID: 11671
		private int fallbackCount = -1;

		// Token: 0x04002D98 RID: 11672
		private int fallbackIndex = -1;
	}
}
