using System;

namespace System.Security.Cryptography
{
	/// <summary>Specifies the padding mode and parameters to use with RSA encryption or decryption operations.</summary>
	// Token: 0x02000280 RID: 640
	public sealed class RSAEncryptionPadding : IEquatable<RSAEncryptionPadding>
	{
		/// <summary>Gets an object that represents the PKCS #1 encryption standard.</summary>
		/// <returns>An object that represents the PKCS #1 encryption standard.</returns>
		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x060022D2 RID: 8914 RVA: 0x0007D317 File Offset: 0x0007B517
		public static RSAEncryptionPadding Pkcs1
		{
			get
			{
				return RSAEncryptionPadding.s_pkcs1;
			}
		}

		/// <summary>Gets an object that represents the Optimal Asymmetric Encryption Padding (OAEP) encryption standard with a SHA1 hash algorithm.</summary>
		/// <returns>An object that represents the OAEP encryption standard with a SHA1 hash algorithm.</returns>
		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x060022D3 RID: 8915 RVA: 0x0007D31E File Offset: 0x0007B51E
		public static RSAEncryptionPadding OaepSHA1
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA1;
			}
		}

		/// <summary>Gets an object that represents the Optimal Asymmetric Encryption Padding (OAEP) encryption standard with a SHA256 hash algorithm.</summary>
		/// <returns>An object that represents the OAEP encryption standard with a SHA256 hash algorithm.</returns>
		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x060022D4 RID: 8916 RVA: 0x0007D325 File Offset: 0x0007B525
		public static RSAEncryptionPadding OaepSHA256
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA256;
			}
		}

		/// <summary>Gets an object that represents the Optimal Asymmetric Encryption Padding (OAEP) encryption standard with a SHA-384 hash algorithm.</summary>
		/// <returns>An object that represents the OAEP encryption standard with a SHA384 hash algorithm.</returns>
		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x060022D5 RID: 8917 RVA: 0x0007D32C File Offset: 0x0007B52C
		public static RSAEncryptionPadding OaepSHA384
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA384;
			}
		}

		/// <summary>Gets an object that represents the Optimal Asymmetric Encryption Padding (OAEP) encryption standard with a SHA512 hash algorithm.</summary>
		/// <returns>An object that represents the OAEP encryption standard with a SHA512 hash algorithm.</returns>
		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060022D6 RID: 8918 RVA: 0x0007D333 File Offset: 0x0007B533
		public static RSAEncryptionPadding OaepSHA512
		{
			get
			{
				return RSAEncryptionPadding.s_oaepSHA512;
			}
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x0007D33A File Offset: 0x0007B53A
		private RSAEncryptionPadding(RSAEncryptionPaddingMode mode, HashAlgorithmName oaepHashAlgorithm)
		{
			this._mode = mode;
			this._oaepHashAlgorithm = oaepHashAlgorithm;
		}

		/// <summary>Creates a new <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> instance whose <see cref="P:System.Security.Cryptography.RSAEncryptionPadding.Mode" /> is <see cref="F:System.Security.Cryptography.RSAEncryptionPaddingMode.Oaep" /> with the given hash algorithm.</summary>
		/// <param name="hashAlgorithm">The hash algorithm.</param>
		/// <returns>An object whose mode is <see cref="P:System.Security.Cryptography.RSAEncryptionPadding.Mode" /> is <see cref="F:System.Security.Cryptography.RSAEncryptionPaddingMode.Oaep" /> with the hash algorithm specified by <paramref name="hashAlgorithm" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> property of <paramref name="hashAlgorithm" /> is either <see langword="null" /> or <see cref="F:System.String.Empty" />.</exception>
		// Token: 0x060022D8 RID: 8920 RVA: 0x0007D350 File Offset: 0x0007B550
		public static RSAEncryptionPadding CreateOaep(HashAlgorithmName hashAlgorithm)
		{
			if (string.IsNullOrEmpty(hashAlgorithm.Name))
			{
				throw new ArgumentException(Environment.GetResourceString("Cryptography_HashAlgorithmNameNullOrEmpty"), "hashAlgorithm");
			}
			return new RSAEncryptionPadding(RSAEncryptionPaddingMode.Oaep, hashAlgorithm);
		}

		/// <summary>Gets the padding mode represented by this <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> instance.</summary>
		/// <returns>A padding mode.</returns>
		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060022D9 RID: 8921 RVA: 0x0007D37C File Offset: 0x0007B57C
		public RSAEncryptionPaddingMode Mode
		{
			get
			{
				return this._mode;
			}
		}

		/// <summary>Gets the hash algorithm used in conjunction with the <see cref="F:System.Security.Cryptography.RSAEncryptionPaddingMode.Oaep" /> padding mode. If the value of the <see cref="P:System.Security.Cryptography.RSAEncryptionPadding.Mode" /> property is not <see cref="F:System.Security.Cryptography.RSAEncryptionPaddingMode.Oaep" />, <see cref="P:System.Security.Cryptography.HashAlgorithmName.Name" /> is <see langword="null" />.</summary>
		/// <returns>The hash algorithm.</returns>
		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060022DA RID: 8922 RVA: 0x0007D384 File Offset: 0x0007B584
		public HashAlgorithmName OaepHashAlgorithm
		{
			get
			{
				return this._oaepHashAlgorithm;
			}
		}

		/// <summary>Returns the hash code of this <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> object.</summary>
		/// <returns>The hash code of this instance.</returns>
		// Token: 0x060022DB RID: 8923 RVA: 0x0007D38C File Offset: 0x0007B58C
		public override int GetHashCode()
		{
			return RSAEncryptionPadding.CombineHashCodes(this._mode.GetHashCode(), this._oaepHashAlgorithm.GetHashCode());
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x0007D3B5 File Offset: 0x0007B5B5
		private static int CombineHashCodes(int h1, int h2)
		{
			return (h1 << 5) + h1 ^ h2;
		}

		/// <summary>Determines whether the current instance is equal to the specified object.</summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is equal to the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060022DD RID: 8925 RVA: 0x0007D3BE File Offset: 0x0007B5BE
		public override bool Equals(object obj)
		{
			return this.Equals(obj as RSAEncryptionPadding);
		}

		/// <summary>Determines whether the current instance is equal to the specified <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> object.</summary>
		/// <param name="other">The object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="other" /> is equal to the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x060022DE RID: 8926 RVA: 0x0007D3CC File Offset: 0x0007B5CC
		public bool Equals(RSAEncryptionPadding other)
		{
			return other != null && this._mode == other._mode && this._oaepHashAlgorithm == other._oaepHashAlgorithm;
		}

		/// <summary>Indicates whether two specified <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> objects are equal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <see langword="left" /> and <see langword="right" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060022DF RID: 8927 RVA: 0x0007D3F8 File Offset: 0x0007B5F8
		public static bool operator ==(RSAEncryptionPadding left, RSAEncryptionPadding right)
		{
			if (left == null)
			{
				return right == null;
			}
			return left.Equals(right);
		}

		/// <summary>Indicates whether two specified <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> objects are unequal.</summary>
		/// <param name="left">The first object to compare.</param>
		/// <param name="right">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <see langword="left" /> and <see langword="right" /> are not equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x060022E0 RID: 8928 RVA: 0x0007D409 File Offset: 0x0007B609
		public static bool operator !=(RSAEncryptionPadding left, RSAEncryptionPadding right)
		{
			return !(left == right);
		}

		/// <summary>Returns the string representation of the current <see cref="T:System.Security.Cryptography.RSAEncryptionPadding" /> instance.</summary>
		/// <returns>The string representation of the current object.</returns>
		// Token: 0x060022E1 RID: 8929 RVA: 0x0007D415 File Offset: 0x0007B615
		public override string ToString()
		{
			return this._mode.ToString() + this._oaepHashAlgorithm.Name;
		}

		// Token: 0x04000CA1 RID: 3233
		private static readonly RSAEncryptionPadding s_pkcs1 = new RSAEncryptionPadding(RSAEncryptionPaddingMode.Pkcs1, default(HashAlgorithmName));

		// Token: 0x04000CA2 RID: 3234
		private static readonly RSAEncryptionPadding s_oaepSHA1 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA1);

		// Token: 0x04000CA3 RID: 3235
		private static readonly RSAEncryptionPadding s_oaepSHA256 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA256);

		// Token: 0x04000CA4 RID: 3236
		private static readonly RSAEncryptionPadding s_oaepSHA384 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA384);

		// Token: 0x04000CA5 RID: 3237
		private static readonly RSAEncryptionPadding s_oaepSHA512 = RSAEncryptionPadding.CreateOaep(HashAlgorithmName.SHA512);

		// Token: 0x04000CA6 RID: 3238
		private RSAEncryptionPaddingMode _mode;

		// Token: 0x04000CA7 RID: 3239
		private HashAlgorithmName _oaepHashAlgorithm;
	}
}
