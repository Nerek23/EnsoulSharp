using System;
using System.Security;

namespace System.Text
{
	/// <summary>Represents a substitute input string that is used when the original input character cannot be encoded. This class cannot be inherited.</summary>
	// Token: 0x02000A45 RID: 2629
	public sealed class EncoderReplacementFallbackBuffer : EncoderFallbackBuffer
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderReplacementFallbackBuffer" /> class using the value of a <see cref="T:System.Text.EncoderReplacementFallback" /> object.</summary>
		/// <param name="fallback">A <see cref="T:System.Text.EncoderReplacementFallback" /> object.</param>
		// Token: 0x060066FD RID: 26365 RVA: 0x0015AD43 File Offset: 0x00158F43
		public EncoderReplacementFallbackBuffer(EncoderReplacementFallback fallback)
		{
			this.strDefault = fallback.DefaultString + fallback.DefaultString;
		}

		/// <summary>Prepares the replacement fallback buffer to use the current replacement string.</summary>
		/// <param name="charUnknown">An input character. This parameter is ignored in this operation unless an exception is thrown.</param>
		/// <param name="index">The index position of the character in the input buffer. This parameter is ignored in this operation.</param>
		/// <returns>
		///   <see langword="true" /> if the replacement string is not empty; <see langword="false" /> if the replacement string is empty.</returns>
		/// <exception cref="T:System.ArgumentException">This method is called again before the <see cref="M:System.Text.EncoderReplacementFallbackBuffer.GetNextChar" /> method has read all the characters in the replacement fallback buffer.</exception>
		// Token: 0x060066FE RID: 26366 RVA: 0x0015AD70 File Offset: 0x00158F70
		public override bool Fallback(char charUnknown, int index)
		{
			if (this.fallbackCount >= 1)
			{
				if (char.IsHighSurrogate(charUnknown) && this.fallbackCount >= 0 && char.IsLowSurrogate(this.strDefault[this.fallbackIndex + 1]))
				{
					base.ThrowLastCharRecursive(char.ConvertToUtf32(charUnknown, this.strDefault[this.fallbackIndex + 1]));
				}
				base.ThrowLastCharRecursive((int)charUnknown);
			}
			this.fallbackCount = this.strDefault.Length / 2;
			this.fallbackIndex = -1;
			return this.fallbackCount != 0;
		}

		/// <summary>Indicates whether a replacement string can be used when an input surrogate pair cannot be encoded, or whether the surrogate pair can be ignored. Parameters specify the surrogate pair and the index position of the pair in the input.</summary>
		/// <param name="charUnknownHigh">The high surrogate of the input pair.</param>
		/// <param name="charUnknownLow">The low surrogate of the input pair.</param>
		/// <param name="index">The index position of the surrogate pair in the input buffer.</param>
		/// <returns>
		///   <see langword="true" /> if the replacement string is not empty; <see langword="false" /> if the replacement string is empty.</returns>
		/// <exception cref="T:System.ArgumentException">This method is called again before the <see cref="M:System.Text.EncoderReplacementFallbackBuffer.GetNextChar" /> method has read all the replacement string characters.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of <paramref name="charUnknownHigh" /> is less than U+D800 or greater than U+D8FF.  
		///  -or-  
		///  The value of <paramref name="charUnknownLow" /> is less than U+DC00 or greater than U+DFFF.</exception>
		// Token: 0x060066FF RID: 26367 RVA: 0x0015ADFC File Offset: 0x00158FFC
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
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
			if (this.fallbackCount >= 1)
			{
				base.ThrowLastCharRecursive(char.ConvertToUtf32(charUnknownHigh, charUnknownLow));
			}
			this.fallbackCount = this.strDefault.Length;
			this.fallbackIndex = -1;
			return this.fallbackCount != 0;
		}

		/// <summary>Retrieves the next character in the replacement fallback buffer.</summary>
		/// <returns>The next Unicode character in the replacement fallback buffer that the application can encode.</returns>
		// Token: 0x06006700 RID: 26368 RVA: 0x0015AEBC File Offset: 0x001590BC
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

		/// <summary>Causes the next call to the <see cref="M:System.Text.EncoderReplacementFallbackBuffer.GetNextChar" /> method to access the character position in the replacement fallback buffer prior to the current character position.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="M:System.Text.EncoderReplacementFallbackBuffer.MovePrevious" /> operation was successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006701 RID: 26369 RVA: 0x0015AF17 File Offset: 0x00159117
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
		// Token: 0x170011AD RID: 4525
		// (get) Token: 0x06006702 RID: 26370 RVA: 0x0015AF4A File Offset: 0x0015914A
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

		/// <summary>Initializes all internal state information and data in this instance of <see cref="T:System.Text.EncoderReplacementFallbackBuffer" />.</summary>
		// Token: 0x06006703 RID: 26371 RVA: 0x0015AF5D File Offset: 0x0015915D
		[SecuritySafeCritical]
		public override void Reset()
		{
			this.fallbackCount = -1;
			this.fallbackIndex = 0;
			this.charStart = null;
			this.bFallingBack = false;
		}

		// Token: 0x04002DB8 RID: 11704
		private string strDefault;

		// Token: 0x04002DB9 RID: 11705
		private int fallbackCount = -1;

		// Token: 0x04002DBA RID: 11706
		private int fallbackIndex = -1;
	}
}
