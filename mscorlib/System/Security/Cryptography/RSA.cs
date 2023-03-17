using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Util;
using System.Text;

namespace System.Security.Cryptography
{
	/// <summary>Represents the base class from which all implementations of the <see cref="T:System.Security.Cryptography.RSA" /> algorithm inherit.</summary>
	// Token: 0x0200027B RID: 635
	[ComVisible(true)]
	public abstract class RSA : AsymmetricAlgorithm
	{
		/// <summary>Creates an instance of the default implementation of the <see cref="T:System.Security.Cryptography.RSA" /> algorithm.</summary>
		/// <returns>A new instance of the default implementation of <see cref="T:System.Security.Cryptography.RSA" />.</returns>
		// Token: 0x0600227D RID: 8829 RVA: 0x0007C094 File Offset: 0x0007A294
		public new static RSA Create()
		{
			return RSA.Create("System.Security.Cryptography.RSA");
		}

		/// <summary>Creates an instance of the specified implementation of <see cref="T:System.Security.Cryptography.RSA" />.</summary>
		/// <param name="algName">The name of the implementation of <see cref="T:System.Security.Cryptography.RSA" /> to use.</param>
		/// <returns>A new instance of the specified implementation of <see cref="T:System.Security.Cryptography.RSA" />.</returns>
		// Token: 0x0600227E RID: 8830 RVA: 0x0007C0A0 File Offset: 0x0007A2A0
		public new static RSA Create(string algName)
		{
			return (RSA)CryptoConfig.CreateFromName(algName);
		}

		/// <summary>Creates a new ephemeral RSA key with the specified key size.</summary>
		/// <param name="keySizeInBits">The key size, in bits.</param>
		/// <returns>A new ephemeral RSA key with the specified key size.</returns>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">
		///   <paramref name="keySizeInBits" /> is different than <see cref="P:System.Security.Cryptography.AsymmetricAlgorithm.KeySize" />.</exception>
		// Token: 0x0600227F RID: 8831 RVA: 0x0007C0B0 File Offset: 0x0007A2B0
		public static RSA Create(int keySizeInBits)
		{
			RSA rsa = (RSA)CryptoConfig.CreateFromName("RSAPSS");
			rsa.KeySize = keySizeInBits;
			if (rsa.KeySize != keySizeInBits)
			{
				throw new CryptographicException();
			}
			return rsa;
		}

		/// <summary>Creates a new ephemeral RSA key with the specified RSA key parameters.</summary>
		/// <param name="parameters">The parameters for the <see cref="T:System.Security.Cryptography.RSA" /> algorithm.</param>
		/// <returns>A new ephemeral RSA key.</returns>
		// Token: 0x06002280 RID: 8832 RVA: 0x0007C0E4 File Offset: 0x0007A2E4
		public static RSA Create(RSAParameters parameters)
		{
			RSA rsa = (RSA)CryptoConfig.CreateFromName("RSAPSS");
			rsa.ImportParameters(parameters);
			return rsa;
		}

		/// <summary>When overridden in a derived class, encrypts the input data using the specified padding mode.</summary>
		/// <param name="data">The data to encrypt.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>The encrypted data.</returns>
		/// <exception cref="T:System.NotImplementedException">A derived class must override this method.</exception>
		// Token: 0x06002281 RID: 8833 RVA: 0x0007C109 File Offset: 0x0007A309
		public virtual byte[] Encrypt(byte[] data, RSAEncryptionPadding padding)
		{
			throw RSA.DerivedClassMustOverride();
		}

		/// <summary>When overridden in a derived class, decrypts the input data using the specified padding mode.</summary>
		/// <param name="data">The data to decrypt.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>The decrypted data.</returns>
		/// <exception cref="T:System.NotImplementedException">A derived class must override this method.</exception>
		// Token: 0x06002282 RID: 8834 RVA: 0x0007C110 File Offset: 0x0007A310
		public virtual byte[] Decrypt(byte[] data, RSAEncryptionPadding padding)
		{
			throw RSA.DerivedClassMustOverride();
		}

		/// <summary>When overridden in a derived class, computes the signature for the specified hash value by encrypting it with the private key using the specified padding.</summary>
		/// <param name="hash">The hash value of the data to be signed.</param>
		/// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the data.</param>
		/// <param name="padding">The padding.</param>
		/// <returns>The RSA signature for the specified hash value.</returns>
		/// <exception cref="T:System.NotImplementedException">A derived class must override this method.</exception>
		// Token: 0x06002283 RID: 8835 RVA: 0x0007C117 File Offset: 0x0007A317
		public virtual byte[] SignHash(byte[] hash, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			throw RSA.DerivedClassMustOverride();
		}

		/// <summary>Verifies that a digital signature is valid by determining the hash value in the signature using the specified hash algorithm and padding, and comparing it to the provided hash value.</summary>
		/// <param name="hash">The hash value of the signed data.</param>
		/// <param name="signature">The signature data to be verified.</param>
		/// <param name="hashAlgorithm">The hash algorithm used to create the hash value.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>
		///   <see langword="true" /> if the signature is valid; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NotImplementedException">A derived class must override this method.</exception>
		// Token: 0x06002284 RID: 8836 RVA: 0x0007C11E File Offset: 0x0007A31E
		public virtual bool VerifyHash(byte[] hash, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			throw RSA.DerivedClassMustOverride();
		}

		/// <summary>When overridden in a derived class, computes the hash value of a specified portion of a byte array by using a specified hashing algorithm.</summary>
		/// <param name="data">The data to be hashed.</param>
		/// <param name="offset">The index of the first byte in <paramref name="data" /> that is to be hashed.</param>
		/// <param name="count">The number of bytes to hash.</param>
		/// <param name="hashAlgorithm">The algorithm to use in hash the data.</param>
		/// <returns>The hashed data.</returns>
		/// <exception cref="T:System.NotImplementedException">A derived class must override this method.</exception>
		// Token: 0x06002285 RID: 8837 RVA: 0x0007C125 File Offset: 0x0007A325
		protected virtual byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm)
		{
			throw RSA.DerivedClassMustOverride();
		}

		/// <summary>When overridden in a derived class, computes the hash value of a specified binary stream by using a specified hashing algorithm.</summary>
		/// <param name="data">The binary stream to hash.</param>
		/// <param name="hashAlgorithm">The hash algorithm.</param>
		/// <returns>The hashed data.</returns>
		/// <exception cref="T:System.NotImplementedException">A derived class must override this method.</exception>
		// Token: 0x06002286 RID: 8838 RVA: 0x0007C12C File Offset: 0x0007A32C
		protected virtual byte[] HashData(Stream data, HashAlgorithmName hashAlgorithm)
		{
			throw RSA.DerivedClassMustOverride();
		}

		/// <summary>Computes the hash value of the specified byte array using the specified hash algorithm and padding mode, and signs the resulting hash value.</summary>
		/// <param name="data">The input data for which to compute the hash.</param>
		/// <param name="hashAlgorithm">The hash algorithm to use to create the hash value.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>The RSA signature for the specified data.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="data" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="padding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="hashAlgorithm" />.<see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		// Token: 0x06002287 RID: 8839 RVA: 0x0007C133 File Offset: 0x0007A333
		public byte[] SignData(byte[] data, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return this.SignData(data, 0, data.Length, hashAlgorithm, padding);
		}

		/// <summary>Computes the hash value of a portion of the specified byte array using the specified hash algorithm and padding mode, and signs the resulting hash value.</summary>
		/// <param name="data">The input data for which to compute the hash.</param>
		/// <param name="offset">The offset into the array at which to begin using data.</param>
		/// <param name="count">The number of bytes in the array to use as data.</param>
		/// <param name="hashAlgorithm">The hash algorithm to use to create the hash value.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>The RSA signature for the specified data.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="data" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="padding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="hashAlgorithm" />.<see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is less than zero.  
		/// -or-  
		/// <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="offset" /> + <paramref name="count" /> - 1 results in an index that is beyond the upper bound of <paramref name="data" />.</exception>
		// Token: 0x06002288 RID: 8840 RVA: 0x0007C150 File Offset: 0x0007A350
		public virtual byte[] SignData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (offset < 0 || offset > data.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > data.Length - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw RSA.HashAlgorithmNameNullOrEmpty();
			}
			if (padding == null)
			{
				throw new ArgumentNullException("padding");
			}
			byte[] hash = this.HashData(data, offset, count, hashAlgorithm);
			return this.SignHash(hash, hashAlgorithm, padding);
		}

		/// <summary>Computes the hash value of the specified stream using the specified hash algorithm and padding mode, and signs the resulting hash value.</summary>
		/// <param name="data">The input stream for which to compute the hash.</param>
		/// <param name="hashAlgorithm">The hash algorithm to use to create the hash value.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>The RSA signature for the specified data.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="data" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="padding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="hashAlgorithm" />.<see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		// Token: 0x06002289 RID: 8841 RVA: 0x0007C1D8 File Offset: 0x0007A3D8
		public virtual byte[] SignData(Stream data, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw RSA.HashAlgorithmNameNullOrEmpty();
			}
			if (padding == null)
			{
				throw new ArgumentNullException("padding");
			}
			byte[] hash = this.HashData(data, hashAlgorithm);
			return this.SignHash(hash, hashAlgorithm, padding);
		}

		/// <summary>Verifies that a digital signature is valid by calculating the hash value of the specified data using the specified hash algorithm and padding, and comparing it to the provided signature.</summary>
		/// <param name="data">The signed data.</param>
		/// <param name="signature">The signature data to be verified.</param>
		/// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the data.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>
		///   <see langword="true" /> if the signature is valid; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="data" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="signature" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="padding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="hashAlgorithm" />.<see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		// Token: 0x0600228A RID: 8842 RVA: 0x0007C22D File Offset: 0x0007A42D
		public bool VerifyData(byte[] data, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return this.VerifyData(data, 0, data.Length, signature, hashAlgorithm, padding);
		}

		/// <summary>Verifies that a digital signature is valid by calculating the hash value of the data in a portion of a byte array using the specified hash algorithm and padding, and comparing it to the provided signature.</summary>
		/// <param name="data">The signed data.</param>
		/// <param name="offset">The starting index at which to compute the hash.</param>
		/// <param name="count">The number of bytes to hash.</param>
		/// <param name="signature">The signature data to be verified.</param>
		/// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the data.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>
		///   <see langword="true" /> if the signature is valid; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="data" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="signature" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="padding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="hashAlgorithm" />.<see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="offset" /> is less than zero.  
		/// -or-  
		/// <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="offset" /> + <paramref name="count" /> - 1 results in an index that is beyond the upper bound of <paramref name="data" />.</exception>
		// Token: 0x0600228B RID: 8843 RVA: 0x0007C24C File Offset: 0x0007A44C
		public virtual bool VerifyData(byte[] data, int offset, int count, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (offset < 0 || offset > data.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || count > data.Length - offset)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw RSA.HashAlgorithmNameNullOrEmpty();
			}
			if (padding == null)
			{
				throw new ArgumentNullException("padding");
			}
			byte[] hash = this.HashData(data, offset, count, hashAlgorithm);
			return this.VerifyHash(hash, signature, hashAlgorithm, padding);
		}

		/// <summary>Verifies that a digital signature is valid by calculating the hash value of the specified stream using the specified hash algorithm and padding, and comparing it to the provided signature.</summary>
		/// <param name="data">The signed data.</param>
		/// <param name="signature">The signature data to be verified.</param>
		/// <param name="hashAlgorithm">The hash algorithm used to create the hash value of the data.</param>
		/// <param name="padding">The padding mode.</param>
		/// <returns>
		///   <see langword="true" /> if the signature is valid; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="data" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="signature" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="padding" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="hashAlgorithm" />.<see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		// Token: 0x0600228C RID: 8844 RVA: 0x0007C2E4 File Offset: 0x0007A4E4
		public bool VerifyData(Stream data, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (signature == null)
			{
				throw new ArgumentNullException("signature");
			}
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw RSA.HashAlgorithmNameNullOrEmpty();
			}
			if (padding == null)
			{
				throw new ArgumentNullException("padding");
			}
			byte[] hash = this.HashData(data, hashAlgorithm);
			return this.VerifyHash(hash, signature, hashAlgorithm, padding);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x0007C34A File Offset: 0x0007A54A
		private static Exception DerivedClassMustOverride()
		{
			return new NotImplementedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x0007C35B File Offset: 0x0007A55B
		internal static Exception HashAlgorithmNameNullOrEmpty()
		{
			return new ArgumentException(Environment.GetResourceString("Cryptography_HashAlgorithmNameNullOrEmpty"), "hashAlgorithm");
		}

		/// <summary>When overridden in a derived class, decrypts the input data using the private key.</summary>
		/// <param name="rgb">The cipher text to be decrypted.</param>
		/// <returns>The resulting decryption of the <paramref name="rgb" /> parameter in plain text.</returns>
		/// <exception cref="T:System.NotSupportedException">This method call is not supported. This exception is thrown starting with the .NET Framework 4.6.</exception>
		// Token: 0x0600228F RID: 8847 RVA: 0x0007C371 File Offset: 0x0007A571
		public virtual byte[] DecryptValue(byte[] rgb)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		/// <summary>When overridden in a derived class, encrypts the input data using the public key.</summary>
		/// <param name="rgb">The plain text to be encrypted.</param>
		/// <returns>The resulting encryption of the <paramref name="rgb" /> parameter as cipher text.</returns>
		/// <exception cref="T:System.NotSupportedException">This method call is not supported. This exception is thrown starting with the .NET Framework 4.6.</exception>
		// Token: 0x06002290 RID: 8848 RVA: 0x0007C382 File Offset: 0x0007A582
		public virtual byte[] EncryptValue(byte[] rgb)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		/// <summary>Gets the name of the key exchange algorithm available with this implementation of <see cref="T:System.Security.Cryptography.RSA" />.</summary>
		/// <returns>Returns "RSA".</returns>
		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06002291 RID: 8849 RVA: 0x0007C393 File Offset: 0x0007A593
		public override string KeyExchangeAlgorithm
		{
			get
			{
				return "RSA";
			}
		}

		/// <summary>Gets the name of the signature algorithm available with this implementation of <see cref="T:System.Security.Cryptography.RSA" />.</summary>
		/// <returns>Returns "RSA".</returns>
		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06002292 RID: 8850 RVA: 0x0007C39A File Offset: 0x0007A59A
		public override string SignatureAlgorithm
		{
			get
			{
				return "RSA";
			}
		}

		/// <summary>Initializes an <see cref="T:System.Security.Cryptography.RSA" /> object from the key information from an XML string.</summary>
		/// <param name="xmlString">The XML string containing <see cref="T:System.Security.Cryptography.RSA" /> key information.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="xmlString" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The format of the <paramref name="xmlString" /> parameter is not valid.</exception>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		// Token: 0x06002293 RID: 8851 RVA: 0x0007C3A4 File Offset: 0x0007A5A4
		public override void FromXmlString(string xmlString)
		{
			if (xmlString == null)
			{
				throw new ArgumentNullException("xmlString");
			}
			RSAParameters parameters = default(RSAParameters);
			Parser parser = new Parser(xmlString);
			SecurityElement topElement = parser.GetTopElement();
			string text = topElement.SearchForTextOfLocalName("Modulus");
			if (text == null)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidFromXmlString", new object[]
				{
					"RSA",
					"Modulus"
				}));
			}
			parameters.Modulus = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text));
			string text2 = topElement.SearchForTextOfLocalName("Exponent");
			if (text2 == null)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidFromXmlString", new object[]
				{
					"RSA",
					"Exponent"
				}));
			}
			parameters.Exponent = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text2));
			string text3 = topElement.SearchForTextOfLocalName("P");
			if (text3 != null)
			{
				parameters.P = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text3));
			}
			string text4 = topElement.SearchForTextOfLocalName("Q");
			if (text4 != null)
			{
				parameters.Q = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text4));
			}
			string text5 = topElement.SearchForTextOfLocalName("DP");
			if (text5 != null)
			{
				parameters.DP = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text5));
			}
			string text6 = topElement.SearchForTextOfLocalName("DQ");
			if (text6 != null)
			{
				parameters.DQ = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text6));
			}
			string text7 = topElement.SearchForTextOfLocalName("InverseQ");
			if (text7 != null)
			{
				parameters.InverseQ = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text7));
			}
			string text8 = topElement.SearchForTextOfLocalName("D");
			if (text8 != null)
			{
				parameters.D = Convert.FromBase64String(Utils.DiscardWhiteSpaces(text8));
			}
			this.ImportParameters(parameters);
		}

		/// <summary>Creates and returns an XML string containing the key of the current <see cref="T:System.Security.Cryptography.RSA" /> object.</summary>
		/// <param name="includePrivateParameters">
		///   <see langword="true" /> to include a public and private RSA key; <see langword="false" /> to include only the public key.</param>
		/// <returns>An XML string containing the key of the current <see cref="T:System.Security.Cryptography.RSA" /> object.</returns>
		/// <exception cref="T:System.PlatformNotSupportedException">.NET Core only: This member is not supported.</exception>
		// Token: 0x06002294 RID: 8852 RVA: 0x0007C548 File Offset: 0x0007A748
		public override string ToXmlString(bool includePrivateParameters)
		{
			RSAParameters rsaparameters = this.ExportParameters(includePrivateParameters);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<RSAKeyValue>");
			stringBuilder.Append("<Modulus>" + Convert.ToBase64String(rsaparameters.Modulus) + "</Modulus>");
			stringBuilder.Append("<Exponent>" + Convert.ToBase64String(rsaparameters.Exponent) + "</Exponent>");
			if (includePrivateParameters)
			{
				stringBuilder.Append("<P>" + Convert.ToBase64String(rsaparameters.P) + "</P>");
				stringBuilder.Append("<Q>" + Convert.ToBase64String(rsaparameters.Q) + "</Q>");
				stringBuilder.Append("<DP>" + Convert.ToBase64String(rsaparameters.DP) + "</DP>");
				stringBuilder.Append("<DQ>" + Convert.ToBase64String(rsaparameters.DQ) + "</DQ>");
				stringBuilder.Append("<InverseQ>" + Convert.ToBase64String(rsaparameters.InverseQ) + "</InverseQ>");
				stringBuilder.Append("<D>" + Convert.ToBase64String(rsaparameters.D) + "</D>");
			}
			stringBuilder.Append("</RSAKeyValue>");
			return stringBuilder.ToString();
		}

		/// <summary>When overridden in a derived class, exports the <see cref="T:System.Security.Cryptography.RSAParameters" />.</summary>
		/// <param name="includePrivateParameters">
		///   <see langword="true" /> to include private parameters; otherwise, <see langword="false" />.</param>
		/// <returns>The parameters for <see cref="T:System.Security.Cryptography.RSA" />.</returns>
		// Token: 0x06002295 RID: 8853
		public abstract RSAParameters ExportParameters(bool includePrivateParameters);

		/// <summary>When overridden in a derived class, imports the specified <see cref="T:System.Security.Cryptography.RSAParameters" />.</summary>
		/// <param name="parameters">The parameters for <see cref="T:System.Security.Cryptography.RSA" />.</param>
		// Token: 0x06002296 RID: 8854
		public abstract void ImportParameters(RSAParameters parameters);
	}
}
