using System;

namespace System.Text
{
	/// <summary>Provides a failure-handling mechanism, called a fallback, for an encoded input byte sequence that cannot be converted to an output character. The fallback emits a user-specified replacement string instead of a decoded input byte sequence. This class cannot be inherited.</summary>
	// Token: 0x02000A39 RID: 2617
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DecoderReplacementFallback : DecoderFallback
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderReplacementFallback" /> class.</summary>
		// Token: 0x06006696 RID: 26262 RVA: 0x001598BA File Offset: 0x00157ABA
		[__DynamicallyInvokable]
		public DecoderReplacementFallback() : this("?")
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderReplacementFallback" /> class using a specified replacement string.</summary>
		/// <param name="replacement">A string that is emitted in a decoding operation in place of an input byte sequence that cannot be decoded.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="replacement" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="replacement" /> contains an invalid surrogate pair. In other words, the surrogate pair does not consist of one high surrogate component followed by one low surrogate component.</exception>
		// Token: 0x06006697 RID: 26263 RVA: 0x001598C8 File Offset: 0x00157AC8
		[__DynamicallyInvokable]
		public DecoderReplacementFallback(string replacement)
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

		/// <summary>Gets the replacement string that is the value of the <see cref="T:System.Text.DecoderReplacementFallback" /> object.</summary>
		/// <returns>A substitute string that is emitted in place of an input byte sequence that cannot be decoded.</returns>
		// Token: 0x17001194 RID: 4500
		// (get) Token: 0x06006698 RID: 26264 RVA: 0x0015994B File Offset: 0x00157B4B
		[__DynamicallyInvokable]
		public string DefaultString
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault;
			}
		}

		/// <summary>Creates a <see cref="T:System.Text.DecoderFallbackBuffer" /> object that is initialized with the replacement string of this <see cref="T:System.Text.DecoderReplacementFallback" /> object.</summary>
		/// <returns>A <see cref="T:System.Text.DecoderFallbackBuffer" /> object that specifies a string to use instead of the original decoding operation input.</returns>
		// Token: 0x06006699 RID: 26265 RVA: 0x00159953 File Offset: 0x00157B53
		[__DynamicallyInvokable]
		public override DecoderFallbackBuffer CreateFallbackBuffer()
		{
			return new DecoderReplacementFallbackBuffer(this);
		}

		/// <summary>Gets the number of characters in the replacement string for the <see cref="T:System.Text.DecoderReplacementFallback" /> object.</summary>
		/// <returns>The number of characters in the string that is emitted in place of a byte sequence that cannot be decoded, that is, the length of the string returned by the <see cref="P:System.Text.DecoderReplacementFallback.DefaultString" /> property.</returns>
		// Token: 0x17001195 RID: 4501
		// (get) Token: 0x0600669A RID: 26266 RVA: 0x0015995B File Offset: 0x00157B5B
		[__DynamicallyInvokable]
		public override int MaxCharCount
		{
			[__DynamicallyInvokable]
			get
			{
				return this.strDefault.Length;
			}
		}

		/// <summary>Indicates whether the value of a specified object is equal to the <see cref="T:System.Text.DecoderReplacementFallback" /> object.</summary>
		/// <param name="value">A <see cref="T:System.Text.DecoderReplacementFallback" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is a <see cref="T:System.Text.DecoderReplacementFallback" /> object having a <see cref="P:System.Text.DecoderReplacementFallback.DefaultString" /> property that is equal to the <see cref="P:System.Text.DecoderReplacementFallback.DefaultString" /> property of the current <see cref="T:System.Text.DecoderReplacementFallback" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600669B RID: 26267 RVA: 0x00159968 File Offset: 0x00157B68
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			DecoderReplacementFallback decoderReplacementFallback = value as DecoderReplacementFallback;
			return decoderReplacementFallback != null && this.strDefault == decoderReplacementFallback.strDefault;
		}

		/// <summary>Retrieves the hash code for the value of the <see cref="T:System.Text.DecoderReplacementFallback" /> object.</summary>
		/// <returns>The hash code of the value of the object.</returns>
		// Token: 0x0600669C RID: 26268 RVA: 0x00159992 File Offset: 0x00157B92
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.strDefault.GetHashCode();
		}

		// Token: 0x04002D95 RID: 11669
		private string strDefault;
	}
}
