using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Accesses the managed version of the <see cref="T:System.Security.Cryptography.Rijndael" /> algorithm. This class cannot be inherited.</summary>
	// Token: 0x02000289 RID: 649
	[ComVisible(true)]
	public sealed class RijndaelManaged : Rijndael
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.RijndaelManaged" /> class.</summary>
		/// <exception cref="T:System.InvalidOperationException">This class is not compliant with the FIPS algorithm.</exception>
		// Token: 0x06002317 RID: 8983 RVA: 0x0007DDF2 File Offset: 0x0007BFF2
		public RijndaelManaged()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
		}

		/// <summary>Creates a symmetric <see cref="T:System.Security.Cryptography.Rijndael" /> encryptor object with the specified <see cref="P:System.Security.Cryptography.SymmetricAlgorithm.Key" /> and initialization vector (<see cref="P:System.Security.Cryptography.SymmetricAlgorithm.IV" />).</summary>
		/// <param name="rgbKey">The secret key to be used for the symmetric algorithm. The key size must be 128, 192, or 256 bits.</param>
		/// <param name="rgbIV">The IV to be used for the symmetric algorithm.</param>
		/// <returns>A symmetric <see cref="T:System.Security.Cryptography.Rijndael" /> encryptor object.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="rgbKey" /> parameter is <see langword="null" />.  
		///  -or-  
		///  The <paramref name="rgbIV" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The value of the <see cref="P:System.Security.Cryptography.SymmetricAlgorithm.Mode" /> property is not <see cref="F:System.Security.Cryptography.CipherMode.ECB" />, <see cref="F:System.Security.Cryptography.CipherMode.CBC" />, or <see cref="F:System.Security.Cryptography.CipherMode.CFB" />.</exception>
		// Token: 0x06002318 RID: 8984 RVA: 0x0007DE18 File Offset: 0x0007C018
		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return this.NewEncryptor(rgbKey, this.ModeValue, rgbIV, this.FeedbackSizeValue, RijndaelManagedTransformMode.Encrypt);
		}

		/// <summary>Creates a symmetric <see cref="T:System.Security.Cryptography.Rijndael" /> decryptor object with the specified <see cref="P:System.Security.Cryptography.SymmetricAlgorithm.Key" /> and initialization vector (<see cref="P:System.Security.Cryptography.SymmetricAlgorithm.IV" />).</summary>
		/// <param name="rgbKey">The secret key to be used for the symmetric algorithm. The key size must be 128, 192, or 256 bits.</param>
		/// <param name="rgbIV">The IV to be used for the symmetric algorithm.</param>
		/// <returns>A symmetric <see cref="T:System.Security.Cryptography.Rijndael" /> decryptor object.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="rgbKey" /> parameter is <see langword="null" />.  
		///  -or-  
		///  The <paramref name="rgbIV" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The value of the <see cref="P:System.Security.Cryptography.SymmetricAlgorithm.Mode" /> property is not <see cref="F:System.Security.Cryptography.CipherMode.ECB" />, <see cref="F:System.Security.Cryptography.CipherMode.CBC" />, or <see cref="F:System.Security.Cryptography.CipherMode.CFB" />.</exception>
		// Token: 0x06002319 RID: 8985 RVA: 0x0007DE2F File Offset: 0x0007C02F
		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			return this.NewEncryptor(rgbKey, this.ModeValue, rgbIV, this.FeedbackSizeValue, RijndaelManagedTransformMode.Decrypt);
		}

		/// <summary>Generates a random <see cref="P:System.Security.Cryptography.SymmetricAlgorithm.Key" /> to be used for the algorithm.</summary>
		// Token: 0x0600231A RID: 8986 RVA: 0x0007DE46 File Offset: 0x0007C046
		public override void GenerateKey()
		{
			this.KeyValue = Utils.GenerateRandom(this.KeySizeValue / 8);
		}

		/// <summary>Generates a random initialization vector (<see cref="P:System.Security.Cryptography.SymmetricAlgorithm.IV" />) to be used for the algorithm.</summary>
		// Token: 0x0600231B RID: 8987 RVA: 0x0007DE5B File Offset: 0x0007C05B
		public override void GenerateIV()
		{
			this.IVValue = Utils.GenerateRandom(this.BlockSizeValue / 8);
		}

		// Token: 0x0600231C RID: 8988 RVA: 0x0007DE70 File Offset: 0x0007C070
		private ICryptoTransform NewEncryptor(byte[] rgbKey, CipherMode mode, byte[] rgbIV, int feedbackSize, RijndaelManagedTransformMode encryptMode)
		{
			if (rgbKey == null)
			{
				rgbKey = Utils.GenerateRandom(this.KeySizeValue / 8);
			}
			if (rgbIV == null)
			{
				rgbIV = Utils.GenerateRandom(this.BlockSizeValue / 8);
			}
			return new RijndaelManagedTransform(rgbKey, mode, rgbIV, this.BlockSizeValue, feedbackSize, this.PaddingValue, encryptMode);
		}
	}
}
