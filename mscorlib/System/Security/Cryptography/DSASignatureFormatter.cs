﻿using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace System.Security.Cryptography
{
	/// <summary>Creates a Digital Signature Algorithm (<see cref="T:System.Security.Cryptography.DSA" />) signature.</summary>
	// Token: 0x02000260 RID: 608
	[ComVisible(true)]
	public class DSASignatureFormatter : AsymmetricSignatureFormatter
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.DSASignatureFormatter" /> class.</summary>
		// Token: 0x060021A6 RID: 8614 RVA: 0x0007727E File Offset: 0x0007547E
		public DSASignatureFormatter()
		{
			this._oid = CryptoConfig.MapNameToOID("SHA1", OidGroup.HashAlgorithm);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.DSASignatureFormatter" /> class with the specified key.</summary>
		/// <param name="key">The instance of the Digital Signature Algorithm (<see cref="T:System.Security.Cryptography.DSA" />) that holds the key.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060021A7 RID: 8615 RVA: 0x00077297 File Offset: 0x00075497
		public DSASignatureFormatter(AsymmetricAlgorithm key) : this()
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._dsaKey = (DSA)key;
		}

		/// <summary>Specifies the key to be used for the Digital Signature Algorithm (<see cref="T:System.Security.Cryptography.DSA" />) signature formatter.</summary>
		/// <param name="key">The instance of <see cref="T:System.Security.Cryptography.DSA" /> that holds the key.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060021A8 RID: 8616 RVA: 0x000772B9 File Offset: 0x000754B9
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._dsaKey = (DSA)key;
		}

		/// <summary>Specifies the hash algorithm for the Digital Signature Algorithm (<see cref="T:System.Security.Cryptography.DSA" />) signature formatter.</summary>
		/// <param name="strName">The name of the hash algorithm to use for the signature formatter.</param>
		/// <exception cref="T:System.Security.Cryptography.CryptographicUnexpectedOperationException">The <paramref name="strName" /> parameter does not map to the <see cref="T:System.Security.Cryptography.SHA1" /> hash algorithm.</exception>
		// Token: 0x060021A9 RID: 8617 RVA: 0x000772D5 File Offset: 0x000754D5
		public override void SetHashAlgorithm(string strName)
		{
			if (CryptoConfig.MapNameToOID(strName, OidGroup.HashAlgorithm) != this._oid)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_InvalidOperation"));
			}
		}

		/// <summary>Creates the Digital Signature Algorithm (<see cref="T:System.Security.Cryptography.DSA" />) PKCS #1 signature for the specified data.</summary>
		/// <param name="rgbHash">The data to be signed.</param>
		/// <returns>The digital signature for the specified data.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="rgbHash" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicUnexpectedOperationException">The OID is <see langword="null" />.  
		///  -or-  
		///  The DSA key is <see langword="null" />.</exception>
		// Token: 0x060021AA RID: 8618 RVA: 0x000772FC File Offset: 0x000754FC
		public override byte[] CreateSignature(byte[] rgbHash)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (this._oid == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingOID"));
			}
			if (this._dsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			return this._dsaKey.CreateSignature(rgbHash);
		}

		// Token: 0x04000C44 RID: 3140
		private DSA _dsaKey;

		// Token: 0x04000C45 RID: 3141
		private string _oid;
	}
}
