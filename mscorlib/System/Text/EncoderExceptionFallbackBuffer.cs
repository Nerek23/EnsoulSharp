﻿using System;

namespace System.Text
{
	/// <summary>Throws <see cref="T:System.Text.EncoderFallbackException" /> when an input character cannot be converted to an encoded output byte sequence. This class cannot be inherited.</summary>
	// Token: 0x02000A40 RID: 2624
	public sealed class EncoderExceptionFallbackBuffer : EncoderFallbackBuffer
	{
		/// <summary>Throws an exception because the input character cannot be encoded. Parameters specify the value and index position of the character that cannot be converted.</summary>
		/// <param name="charUnknown">An input character.</param>
		/// <param name="index">The index position of the character in the input buffer.</param>
		/// <returns>None. No value is returned because the <see cref="M:System.Text.EncoderExceptionFallbackBuffer.Fallback(System.Char,System.Int32)" /> method always throws an exception.</returns>
		/// <exception cref="T:System.Text.EncoderFallbackException">
		///   <paramref name="charUnknown" /> cannot be encoded. This method always throws an exception that reports the value of the <paramref name="charUnknown" /> and <paramref name="index" /> parameters.</exception>
		// Token: 0x060066D4 RID: 26324 RVA: 0x0015A791 File Offset: 0x00158991
		public override bool Fallback(char charUnknown, int index)
		{
			throw new EncoderFallbackException(Environment.GetResourceString("Argument_InvalidCodePageConversionIndex", new object[]
			{
				(int)charUnknown,
				index
			}), charUnknown, index);
		}

		/// <summary>Throws an exception because the input character cannot be encoded. Parameters specify the value and index position of the surrogate pair in the input, and the nominal return value is not used.</summary>
		/// <param name="charUnknownHigh">The high surrogate of the input pair.</param>
		/// <param name="charUnknownLow">The low surrogate of the input pair.</param>
		/// <param name="index">The index position of the surrogate pair in the input buffer.</param>
		/// <returns>None. No value is returned because the <see cref="M:System.Text.EncoderExceptionFallbackBuffer.Fallback(System.Char,System.Char,System.Int32)" /> method always throws an exception.</returns>
		/// <exception cref="T:System.Text.EncoderFallbackException">The character represented by <paramref name="charUnknownHigh" /> and <paramref name="charUnknownLow" /> cannot be encoded.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">Either <paramref name="charUnknownHigh" /> or <paramref name="charUnknownLow" /> is invalid. <paramref name="charUnknownHigh" /> is not between U+D800 and U+DBFF, inclusive, or <paramref name="charUnknownLow" /> is not between U+DC00 and U+DFFF, inclusive.</exception>
		// Token: 0x060066D5 RID: 26325 RVA: 0x0015A7BC File Offset: 0x001589BC
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
			int num = char.ConvertToUtf32(charUnknownHigh, charUnknownLow);
			throw new EncoderFallbackException(Environment.GetResourceString("Argument_InvalidCodePageConversionIndex", new object[]
			{
				num,
				index
			}), charUnknownHigh, charUnknownLow, index);
		}

		/// <summary>Retrieves the next character in the exception fallback buffer.</summary>
		/// <returns>The return value is always the Unicode character, NULL (U+0000).  
		///  A return value is defined, although it is unchanging, because this method implements an abstract method.</returns>
		// Token: 0x060066D6 RID: 26326 RVA: 0x0015A875 File Offset: 0x00158A75
		public override char GetNextChar()
		{
			return '\0';
		}

		/// <summary>Causes the next call to the <see cref="M:System.Text.EncoderExceptionFallbackBuffer.GetNextChar" /> method to access the exception data buffer character position that is prior to the current position.</summary>
		/// <returns>The return value is always <see langword="false" />.  
		///  A return value is defined, although it is unchanging, because this method implements an abstract method.</returns>
		// Token: 0x060066D7 RID: 26327 RVA: 0x0015A878 File Offset: 0x00158A78
		public override bool MovePrevious()
		{
			return false;
		}

		/// <summary>Gets the number of characters in the current <see cref="T:System.Text.EncoderExceptionFallbackBuffer" /> object that remain to be processed.</summary>
		/// <returns>The return value is always zero.  
		///  A return value is defined, although it is unchanging, because this method implements an abstract method.</returns>
		// Token: 0x170011A1 RID: 4513
		// (get) Token: 0x060066D8 RID: 26328 RVA: 0x0015A87B File Offset: 0x00158A7B
		public override int Remaining
		{
			get
			{
				return 0;
			}
		}
	}
}
