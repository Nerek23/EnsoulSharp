using System;
using System.Runtime.CompilerServices;

namespace System.Security.Cryptography
{
	/// <summary>Represents the abstract base class from which all implementations of the Advanced Encryption Standard (AES) must inherit.</summary>
	// Token: 0x02000248 RID: 584
	[TypeForwardedFrom("System.Core, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=b77a5c561934e089")]
	public abstract class Aes : SymmetricAlgorithm
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.Aes" /> class.</summary>
		// Token: 0x060020CF RID: 8399 RVA: 0x00072A94 File Offset: 0x00070C94
		protected Aes()
		{
			this.LegalBlockSizesValue = Aes.s_legalBlockSizes;
			this.LegalKeySizesValue = Aes.s_legalKeySizes;
			this.BlockSizeValue = 128;
			this.FeedbackSizeValue = 8;
			this.KeySizeValue = 256;
			this.ModeValue = CipherMode.CBC;
		}

		/// <summary>Creates a cryptographic object that is used to perform the symmetric algorithm.</summary>
		/// <returns>A cryptographic object that is used to perform the symmetric algorithm.</returns>
		// Token: 0x060020D0 RID: 8400 RVA: 0x00072AE1 File Offset: 0x00070CE1
		public new static Aes Create()
		{
			return Aes.Create("AES");
		}

		/// <summary>Creates a cryptographic object that specifies the implementation of AES to use to perform the symmetric algorithm.</summary>
		/// <param name="algorithmName">The name of the specific implementation of AES to use.</param>
		/// <returns>A cryptographic object that is used to perform the symmetric algorithm.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="algorithmName" /> parameter is <see langword="null" />.</exception>
		// Token: 0x060020D1 RID: 8401 RVA: 0x00072AED File Offset: 0x00070CED
		public new static Aes Create(string algorithmName)
		{
			if (algorithmName == null)
			{
				throw new ArgumentNullException("algorithmName");
			}
			return CryptoConfig.CreateFromName(algorithmName) as Aes;
		}

		// Token: 0x04000BE6 RID: 3046
		private static KeySizes[] s_legalBlockSizes = new KeySizes[]
		{
			new KeySizes(128, 128, 0)
		};

		// Token: 0x04000BE7 RID: 3047
		private static KeySizes[] s_legalKeySizes = new KeySizes[]
		{
			new KeySizes(128, 256, 64)
		};
	}
}
