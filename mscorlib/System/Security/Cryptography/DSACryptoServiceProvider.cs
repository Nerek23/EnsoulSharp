using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;

namespace System.Security.Cryptography
{
	/// <summary>Defines a wrapper object to access the cryptographic service provider (CSP) implementation of the <see cref="T:System.Security.Cryptography.DSA" /> algorithm. This class cannot be inherited.</summary>
	// Token: 0x0200025E RID: 606
	[ComVisible(true)]
	public sealed class DSACryptoServiceProvider : DSA, ICspAsymmetricAlgorithm
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> class.</summary>
		// Token: 0x0600217F RID: 8575 RVA: 0x00076960 File Offset: 0x00074B60
		public DSACryptoServiceProvider() : this(0, new CspParameters(13, null, null, DSACryptoServiceProvider.s_UseMachineKeyStore))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> class with the specified key size.</summary>
		/// <param name="dwKeySize">The size of the key for the asymmetric algorithm in bits.</param>
		// Token: 0x06002180 RID: 8576 RVA: 0x00076979 File Offset: 0x00074B79
		public DSACryptoServiceProvider(int dwKeySize) : this(dwKeySize, new CspParameters(13, null, null, DSACryptoServiceProvider.s_UseMachineKeyStore))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> class with the specified parameters for the cryptographic service provider (CSP).</summary>
		/// <param name="parameters">The parameters for the CSP.</param>
		// Token: 0x06002181 RID: 8577 RVA: 0x00076992 File Offset: 0x00074B92
		public DSACryptoServiceProvider(CspParameters parameters) : this(0, parameters)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> class with the specified key size and parameters for the cryptographic service provider (CSP).</summary>
		/// <param name="dwKeySize">The size of the key for the cryptographic algorithm in bits.</param>
		/// <param name="parameters">The parameters for the CSP.</param>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The CSP cannot be acquired.  
		///  -or-  
		///  The key cannot be created.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="dwKeySize" /> is out of range.</exception>
		// Token: 0x06002182 RID: 8578 RVA: 0x0007699C File Offset: 0x00074B9C
		[SecuritySafeCritical]
		public DSACryptoServiceProvider(int dwKeySize, CspParameters parameters)
		{
			if (dwKeySize < 0)
			{
				throw new ArgumentOutOfRangeException("dwKeySize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this._parameters = Utils.SaveCspParameters(CspAlgorithmType.Dss, parameters, DSACryptoServiceProvider.s_UseMachineKeyStore, ref this._randomKeyContainer);
			this.LegalKeySizesValue = new KeySizes[]
			{
				new KeySizes(512, 1024, 64)
			};
			this._dwKeySize = dwKeySize;
			this._sha1 = new SHA1CryptoServiceProvider();
			if (!this._randomKeyContainer || Environment.GetCompatibilityFlag(CompatibilityFlag.EagerlyGenerateRandomAsymmKeys))
			{
				this.GetKeyPair();
			}
		}

		// Token: 0x06002183 RID: 8579 RVA: 0x00076A2C File Offset: 0x00074C2C
		[SecurityCritical]
		private void GetKeyPair()
		{
			if (this._safeKeyHandle == null)
			{
				lock (this)
				{
					if (this._safeKeyHandle == null)
					{
						Utils.GetKeyPairHelper(CspAlgorithmType.Dss, this._parameters, this._randomKeyContainer, this._dwKeySize, ref this._safeProvHandle, ref this._safeKeyHandle);
					}
				}
			}
		}

		// Token: 0x06002184 RID: 8580 RVA: 0x00076A98 File Offset: 0x00074C98
		[SecuritySafeCritical]
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (this._safeKeyHandle != null && !this._safeKeyHandle.IsClosed)
			{
				this._safeKeyHandle.Dispose();
			}
			if (this._safeProvHandle != null && !this._safeProvHandle.IsClosed)
			{
				this._safeProvHandle.Dispose();
			}
		}

		/// <summary>Gets a value that indicates whether the <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> object contains only a public key.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> object contains only a public key; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06002185 RID: 8581 RVA: 0x00076AEC File Offset: 0x00074CEC
		[ComVisible(false)]
		public bool PublicOnly
		{
			[SecuritySafeCritical]
			get
			{
				this.GetKeyPair();
				byte[] array = Utils._GetKeyParameter(this._safeKeyHandle, 2U);
				return array[0] == 1;
			}
		}

		/// <summary>Gets a <see cref="T:System.Security.Cryptography.CspKeyContainerInfo" /> object that describes additional information about a cryptographic key pair.</summary>
		/// <returns>A <see cref="T:System.Security.Cryptography.CspKeyContainerInfo" /> object that describes additional information about a cryptographic key pair.</returns>
		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06002186 RID: 8582 RVA: 0x00076B12 File Offset: 0x00074D12
		[ComVisible(false)]
		public CspKeyContainerInfo CspKeyContainerInfo
		{
			[SecuritySafeCritical]
			get
			{
				this.GetKeyPair();
				return new CspKeyContainerInfo(this._parameters, this._randomKeyContainer);
			}
		}

		/// <summary>Gets the size of the key used by the asymmetric algorithm in bits.</summary>
		/// <returns>The size of the key used by the asymmetric algorithm.</returns>
		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06002187 RID: 8583 RVA: 0x00076B2C File Offset: 0x00074D2C
		public override int KeySize
		{
			[SecuritySafeCritical]
			get
			{
				this.GetKeyPair();
				byte[] array = Utils._GetKeyParameter(this._safeKeyHandle, 1U);
				this._dwKeySize = ((int)array[0] | (int)array[1] << 8 | (int)array[2] << 16 | (int)array[3] << 24);
				return this._dwKeySize;
			}
		}

		/// <summary>Gets the name of the key exchange algorithm.</summary>
		/// <returns>The name of the key exchange algorithm.</returns>
		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06002188 RID: 8584 RVA: 0x00076B6F File Offset: 0x00074D6F
		public override string KeyExchangeAlgorithm
		{
			get
			{
				return null;
			}
		}

		/// <summary>Gets the name of the signature algorithm.</summary>
		/// <returns>The name of the signature algorithm.</returns>
		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06002189 RID: 8585 RVA: 0x00076B72 File Offset: 0x00074D72
		public override string SignatureAlgorithm
		{
			get
			{
				return "http://www.w3.org/2000/09/xmldsig#dsa-sha1";
			}
		}

		/// <summary>Gets or sets a value indicating whether the key should be persisted in the computer's key store instead of the user profile store.</summary>
		/// <returns>
		///   <see langword="true" /> if the key should be persisted in the computer key store; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x0600218A RID: 8586 RVA: 0x00076B79 File Offset: 0x00074D79
		// (set) Token: 0x0600218B RID: 8587 RVA: 0x00076B85 File Offset: 0x00074D85
		public static bool UseMachineKeyStore
		{
			get
			{
				return DSACryptoServiceProvider.s_UseMachineKeyStore == CspProviderFlags.UseMachineKeyStore;
			}
			set
			{
				DSACryptoServiceProvider.s_UseMachineKeyStore = (value ? CspProviderFlags.UseMachineKeyStore : CspProviderFlags.NoFlags);
			}
		}

		/// <summary>Gets or sets a value indicating whether the key should be persisted in the cryptographic service provider (CSP).</summary>
		/// <returns>
		///   <see langword="true" /> if the key should be persisted in the CSP; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x0600218C RID: 8588 RVA: 0x00076B98 File Offset: 0x00074D98
		// (set) Token: 0x0600218D RID: 8589 RVA: 0x00076C00 File Offset: 0x00074E00
		public bool PersistKeyInCsp
		{
			[SecuritySafeCritical]
			get
			{
				if (this._safeProvHandle == null)
				{
					lock (this)
					{
						if (this._safeProvHandle == null)
						{
							this._safeProvHandle = Utils.CreateProvHandle(this._parameters, this._randomKeyContainer);
						}
					}
				}
				return Utils.GetPersistKeyInCsp(this._safeProvHandle);
			}
			[SecuritySafeCritical]
			set
			{
				bool persistKeyInCsp = this.PersistKeyInCsp;
				if (value == persistKeyInCsp)
				{
					return;
				}
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
				if (!value)
				{
					KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Delete);
					keyContainerPermission.AccessEntries.Add(accessEntry);
				}
				else
				{
					KeyContainerPermissionAccessEntry accessEntry2 = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Create);
					keyContainerPermission.AccessEntries.Add(accessEntry2);
				}
				keyContainerPermission.Demand();
				Utils.SetPersistKeyInCsp(this._safeProvHandle, value);
			}
		}

		/// <summary>Exports the <see cref="T:System.Security.Cryptography.DSAParameters" />.</summary>
		/// <param name="includePrivateParameters">
		///   <see langword="true" /> to include private parameters; otherwise, <see langword="false" />.</param>
		/// <returns>The parameters for <see cref="T:System.Security.Cryptography.DSA" />.</returns>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The key cannot be exported.</exception>
		// Token: 0x0600218E RID: 8590 RVA: 0x00076C6C File Offset: 0x00074E6C
		[SecuritySafeCritical]
		public override DSAParameters ExportParameters(bool includePrivateParameters)
		{
			this.GetKeyPair();
			if (includePrivateParameters)
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
				KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Export);
				keyContainerPermission.AccessEntries.Add(accessEntry);
				keyContainerPermission.Demand();
			}
			DSACspObject dsacspObject = new DSACspObject();
			int blobType = includePrivateParameters ? 7 : 6;
			Utils._ExportKey(this._safeKeyHandle, blobType, dsacspObject);
			return DSACryptoServiceProvider.DSAObjectToStruct(dsacspObject);
		}

		/// <summary>Exports a blob containing the key information associated with a <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> object.</summary>
		/// <param name="includePrivateParameters">
		///   <see langword="true" /> to include the private key; otherwise, <see langword="false" />.</param>
		/// <returns>A byte array containing the key information associated with a <see cref="T:System.Security.Cryptography.DSACryptoServiceProvider" /> object.</returns>
		// Token: 0x0600218F RID: 8591 RVA: 0x00076CCB File Offset: 0x00074ECB
		[SecuritySafeCritical]
		[ComVisible(false)]
		public byte[] ExportCspBlob(bool includePrivateParameters)
		{
			this.GetKeyPair();
			return Utils.ExportCspBlobHelper(includePrivateParameters, this._parameters, this._safeKeyHandle);
		}

		/// <summary>Imports the specified <see cref="T:System.Security.Cryptography.DSAParameters" />.</summary>
		/// <param name="parameters">The parameters for <see cref="T:System.Security.Cryptography.DSA" />.</param>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.  
		///  -or-  
		///  The <paramref name="parameters" /> parameter has missing fields.</exception>
		// Token: 0x06002190 RID: 8592 RVA: 0x00076CE8 File Offset: 0x00074EE8
		[SecuritySafeCritical]
		public override void ImportParameters(DSAParameters parameters)
		{
			DSACspObject cspObject = DSACryptoServiceProvider.DSAStructToObject(parameters);
			if (this._safeKeyHandle != null && !this._safeKeyHandle.IsClosed)
			{
				this._safeKeyHandle.Dispose();
			}
			this._safeKeyHandle = SafeKeyHandle.InvalidHandle;
			if (DSACryptoServiceProvider.IsPublic(parameters))
			{
				Utils._ImportKey(Utils.StaticDssProvHandle, 8704, CspProviderFlags.NoFlags, cspObject, ref this._safeKeyHandle);
				return;
			}
			KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
			KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Import);
			keyContainerPermission.AccessEntries.Add(accessEntry);
			keyContainerPermission.Demand();
			if (this._safeProvHandle == null)
			{
				this._safeProvHandle = Utils.CreateProvHandle(this._parameters, this._randomKeyContainer);
			}
			Utils._ImportKey(this._safeProvHandle, 8704, this._parameters.Flags, cspObject, ref this._safeKeyHandle);
		}

		/// <summary>Imports a blob that represents DSA key information.</summary>
		/// <param name="keyBlob">A byte array that represents a DSA key blob.</param>
		// Token: 0x06002191 RID: 8593 RVA: 0x00076DB0 File Offset: 0x00074FB0
		[SecuritySafeCritical]
		[ComVisible(false)]
		public void ImportCspBlob(byte[] keyBlob)
		{
			Utils.ImportCspBlobHelper(CspAlgorithmType.Dss, keyBlob, DSACryptoServiceProvider.IsPublic(keyBlob), ref this._parameters, this._randomKeyContainer, ref this._safeProvHandle, ref this._safeKeyHandle);
		}

		/// <summary>Computes the hash value of the specified input stream and signs the resulting hash value.</summary>
		/// <param name="inputStream">The input data for which to compute the hash.</param>
		/// <returns>The <see cref="T:System.Security.Cryptography.DSA" /> signature for the specified data.</returns>
		// Token: 0x06002192 RID: 8594 RVA: 0x00076DD8 File Offset: 0x00074FD8
		public byte[] SignData(Stream inputStream)
		{
			byte[] rgbHash = this._sha1.ComputeHash(inputStream);
			return this.SignHash(rgbHash, null);
		}

		/// <summary>Computes the hash value of the specified byte array and signs the resulting hash value.</summary>
		/// <param name="buffer">The input data for which to compute the hash.</param>
		/// <returns>The <see cref="T:System.Security.Cryptography.DSA" /> signature for the specified data.</returns>
		// Token: 0x06002193 RID: 8595 RVA: 0x00076DFC File Offset: 0x00074FFC
		public byte[] SignData(byte[] buffer)
		{
			byte[] rgbHash = this._sha1.ComputeHash(buffer);
			return this.SignHash(rgbHash, null);
		}

		/// <summary>Signs a byte array from the specified start point to the specified end point.</summary>
		/// <param name="buffer">The input data to sign.</param>
		/// <param name="offset">The offset into the array from which to begin using data.</param>
		/// <param name="count">The number of bytes in the array to use as data.</param>
		/// <returns>The <see cref="T:System.Security.Cryptography.DSA" /> signature for the specified data.</returns>
		// Token: 0x06002194 RID: 8596 RVA: 0x00076E20 File Offset: 0x00075020
		public byte[] SignData(byte[] buffer, int offset, int count)
		{
			byte[] rgbHash = this._sha1.ComputeHash(buffer, offset, count);
			return this.SignHash(rgbHash, null);
		}

		/// <summary>Verifies the specified signature data by comparing it to the signature computed for the specified data.</summary>
		/// <param name="rgbData">The data that was signed.</param>
		/// <param name="rgbSignature">The signature data to be verified.</param>
		/// <returns>
		///   <see langword="true" /> if the signature verifies as valid; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002195 RID: 8597 RVA: 0x00076E44 File Offset: 0x00075044
		public bool VerifyData(byte[] rgbData, byte[] rgbSignature)
		{
			byte[] rgbHash = this._sha1.ComputeHash(rgbData);
			return this.VerifyHash(rgbHash, null, rgbSignature);
		}

		/// <summary>Creates the <see cref="T:System.Security.Cryptography.DSA" /> signature for the specified data.</summary>
		/// <param name="rgbHash">The data to be signed.</param>
		/// <returns>The digital signature for the specified data.</returns>
		// Token: 0x06002196 RID: 8598 RVA: 0x00076E67 File Offset: 0x00075067
		public override byte[] CreateSignature(byte[] rgbHash)
		{
			return this.SignHash(rgbHash, null);
		}

		/// <summary>Verifies the <see cref="T:System.Security.Cryptography.DSA" /> signature for the specified data.</summary>
		/// <param name="rgbHash">The data signed with <paramref name="rgbSignature" />.</param>
		/// <param name="rgbSignature">The signature to be verified for <paramref name="rgbData" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="rgbSignature" /> matches the signature computed using the specified hash algorithm and key on <paramref name="rgbHash" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002197 RID: 8599 RVA: 0x00076E71 File Offset: 0x00075071
		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature)
		{
			return this.VerifyHash(rgbHash, null, rgbSignature);
		}

		// Token: 0x06002198 RID: 8600 RVA: 0x00076E7C File Offset: 0x0007507C
		protected override byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm)
		{
			if (hashAlgorithm != HashAlgorithmName.SHA1)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_UnknownHashAlgorithm", new object[]
				{
					hashAlgorithm.Name
				}));
			}
			return this._sha1.ComputeHash(data, offset, count);
		}

		// Token: 0x06002199 RID: 8601 RVA: 0x00076EBA File Offset: 0x000750BA
		protected override byte[] HashData(Stream data, HashAlgorithmName hashAlgorithm)
		{
			if (hashAlgorithm != HashAlgorithmName.SHA1)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_UnknownHashAlgorithm", new object[]
				{
					hashAlgorithm.Name
				}));
			}
			return this._sha1.ComputeHash(data);
		}

		/// <summary>Computes the signature for the specified hash value by encrypting it with the private key.</summary>
		/// <param name="rgbHash">The hash value of the data to be signed.</param>
		/// <param name="str">The name of the hash algorithm used to create the hash value of the data.</param>
		/// <returns>The <see cref="T:System.Security.Cryptography.DSA" /> signature for the specified hash value.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="rgbHash" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.  
		///  -or-  
		///  There is no private key.</exception>
		// Token: 0x0600219A RID: 8602 RVA: 0x00076EF8 File Offset: 0x000750F8
		[SecuritySafeCritical]
		public byte[] SignHash(byte[] rgbHash, string str)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (this.PublicOnly)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_CSP_NoPrivateKey"));
			}
			int calgHash = X509Utils.NameOrOidToAlgId(str, OidGroup.HashAlgorithm);
			if (rgbHash.Length != this._sha1.HashSize / 8)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidHashSize", new object[]
				{
					"SHA1",
					this._sha1.HashSize / 8
				}));
			}
			this.GetKeyPair();
			if (!this.CspKeyContainerInfo.RandomlyGenerated)
			{
				KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
				KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this._parameters, KeyContainerPermissionFlags.Sign);
				keyContainerPermission.AccessEntries.Add(accessEntry);
				keyContainerPermission.Demand();
			}
			return Utils.SignValue(this._safeKeyHandle, this._parameters.KeyNumber, 8704, calgHash, rgbHash);
		}

		/// <summary>Verifies the specified signature data by comparing it to the signature computed for the specified hash value.</summary>
		/// <param name="rgbHash">The hash value of the data to be signed.</param>
		/// <param name="str">The name of the hash algorithm used to create the hash value of the data.</param>
		/// <param name="rgbSignature">The signature data to be verified.</param>
		/// <returns>
		///   <see langword="true" /> if the signature verifies as valid; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="rgbHash" /> parameter is <see langword="null" />.  
		///  -or-  
		///  The <paramref name="rgbSignature" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.  
		///  -or-  
		///  The signature cannot be verified.</exception>
		// Token: 0x0600219B RID: 8603 RVA: 0x00076FD4 File Offset: 0x000751D4
		[SecuritySafeCritical]
		public bool VerifyHash(byte[] rgbHash, string str, byte[] rgbSignature)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (rgbSignature == null)
			{
				throw new ArgumentNullException("rgbSignature");
			}
			int calgHash = X509Utils.NameOrOidToAlgId(str, OidGroup.HashAlgorithm);
			if (rgbHash.Length != this._sha1.HashSize / 8)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidHashSize", new object[]
				{
					"SHA1",
					this._sha1.HashSize / 8
				}));
			}
			this.GetKeyPair();
			return Utils.VerifySign(this._safeKeyHandle, 8704, calgHash, rgbHash, rgbSignature);
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x00077064 File Offset: 0x00075264
		private static DSAParameters DSAObjectToStruct(DSACspObject dsaCspObject)
		{
			return new DSAParameters
			{
				P = dsaCspObject.P,
				Q = dsaCspObject.Q,
				G = dsaCspObject.G,
				Y = dsaCspObject.Y,
				J = dsaCspObject.J,
				X = dsaCspObject.X,
				Seed = dsaCspObject.Seed,
				Counter = dsaCspObject.Counter
			};
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x000770E4 File Offset: 0x000752E4
		private static DSACspObject DSAStructToObject(DSAParameters dsaParams)
		{
			return new DSACspObject
			{
				P = dsaParams.P,
				Q = dsaParams.Q,
				G = dsaParams.G,
				Y = dsaParams.Y,
				J = dsaParams.J,
				X = dsaParams.X,
				Seed = dsaParams.Seed,
				Counter = dsaParams.Counter
			};
		}

		// Token: 0x0600219E RID: 8606 RVA: 0x00077158 File Offset: 0x00075358
		private static bool IsPublic(DSAParameters dsaParams)
		{
			return dsaParams.X == null;
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x00077164 File Offset: 0x00075364
		private static bool IsPublic(byte[] keyBlob)
		{
			if (keyBlob == null)
			{
				throw new ArgumentNullException("keyBlob");
			}
			return keyBlob[0] == 6 && (keyBlob[11] == 49 || keyBlob[11] == 51) && keyBlob[10] == 83 && keyBlob[9] == 83 && keyBlob[8] == 68;
		}

		// Token: 0x04000C3B RID: 3131
		private int _dwKeySize;

		// Token: 0x04000C3C RID: 3132
		private CspParameters _parameters;

		// Token: 0x04000C3D RID: 3133
		private bool _randomKeyContainer;

		// Token: 0x04000C3E RID: 3134
		[SecurityCritical]
		private SafeProvHandle _safeProvHandle;

		// Token: 0x04000C3F RID: 3135
		[SecurityCritical]
		private SafeKeyHandle _safeKeyHandle;

		// Token: 0x04000C40 RID: 3136
		private SHA1CryptoServiceProvider _sha1;

		// Token: 0x04000C41 RID: 3137
		private static volatile CspProviderFlags s_UseMachineKeyStore;
	}
}
