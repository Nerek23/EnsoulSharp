using System;

namespace System.Text
{
	/// <summary>Provides a failure handling mechanism, called a fallback, for an input character that cannot be converted to an output byte sequence. The fallback uses a user-specified replacement string instead of the original input character. This class cannot be inherited.</summary>
	// Token: 0x02000A44 RID: 2628
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class EncoderReplacementFallback : EncoderFallback
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderReplacementFallback" /> class.</summary>
		// Token: 0x060066F6 RID: 26358 RVA: 0x0015AC5F File Offset: 0x00158E5F
		[__DynamicallyInvokable]
		public EncoderReplacementFallback() : this("?")
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.EncoderReplacementFallback" /> class using a specified replacement string.</summary>
		/// <param name="replacement">A string that is converted in an encoding operation in place of an input character that cannot be encoded.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="replacement" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="replacement" /> contains an invalid surrogate pair. In other words, the surrogate does not consist of one high surrogate component followed by one low surrogate component.</exception>
		// Token: 0x060066F7 RID: 26359 RVA: 0x0015AC6C File Offset: 0x00158E6C
		[__DynamicallyInvokable]
		public EncoderReplacementFallback(string replacement)
		{
			if (replacement == null)
			{
				throw new ArgumentNullException("replacement");
			}
			bool flag = false;
			for (int i = 0; i < replacement.Length; i++)
			{
				if (char.IsSurrogate(replacement, i))
				{
					if (char.IsHighSurrogate(replacement, i))
					{
						if (flag)
						{
							break;
						}
						flag = true;
					}
					else
					{
						if (!flag)
						{
							flag = true;
							break;
						}
						flag = false;
					}
				}
				else if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex", new object[]
				{
					"replacement"
				}));
			}
			this.strDefault = replacement;
		}

		/// <summary>Gets the replacement string that is the value of the <see cref="T:System.Text.EncoderReplacementFallback" /> object.</summary>
		/// <returns>A substitute string that is used in place of an input character that cannot be encoded.</returns>
		// Token: 0x170011AB RID: 4523
		// (get) Token: 0x060066F8 RID: 26360 RVA: 0x0015ACEF File Offset: 0x00158EEF
		[__DynamicallyInvokable]
		public string DefaultString
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault;
			}
		}

		/// <summary>Creates a <see cref="T:System.Text.EncoderFallbackBuffer" /> object that is initialized with the replacement string of this <see cref="T:System.Text.EncoderReplacementFallback" /> object.</summary>
		/// <returns>A <see cref="T:System.Text.EncoderFallbackBuffer" /> object equal to this <see cref="T:System.Text.EncoderReplacementFallback" /> object.</returns>
		// Token: 0x060066F9 RID: 26361 RVA: 0x0015ACF7 File Offset: 0x00158EF7
		[__DynamicallyInvokable]
		public override EncoderFallbackBuffer CreateFallbackBuffer()
		{
			return new EncoderReplacementFallbackBuffer(this);
		}

		/// <summary>Gets the number of characters in the replacement string for the <see cref="T:System.Text.EncoderReplacementFallback" /> object.</summary>
		/// <returns>The number of characters in the string used in place of an input character that cannot be encoded.</returns>
		// Token: 0x170011AC RID: 4524
		// (get) Token: 0x060066FA RID: 26362 RVA: 0x0015ACFF File Offset: 0x00158EFF
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault.Length;
			}
		}

		/// <summary>Indicates whether the value of a specified object is equal to the <see cref="T:System.Text.EncoderReplacementFallback" /> object.</summary>
		/// <param name="value">A <see cref="T:System.Text.EncoderReplacementFallback" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter specifies an <see cref="T:System.Text.EncoderReplacementFallback" /> object and the replacement string of that object is equal to the replacement string of this <see cref="T:System.Text.EncoderReplacementFallback" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060066FB RID: 26363 RVA: 0x0015AD0C File Offset: 0x00158F0C
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			EncoderReplacementFallback encoderReplacementFallback = value as EncoderReplacementFallback;
			return encoderReplacementFallback != null && this.strDefault == encoderReplacementFallback.strDefault;
		}

		/// <summary>Retrieves the hash code for the value of the <see cref="T:System.Text.EncoderReplacementFallback" /> object.</summary>
		/// <returns>The hash code of the value of the object.</returns>
		// Token: 0x060066FC RID: 26364 RVA: 0x0015AD36 File Offset: 0x00158F36
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.strDefault.GetHashCode();
		}

		// Token: 0x04002DB7 RID: 11703
		private string strDefault;
	}
}
