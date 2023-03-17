﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Computes the <see cref="T:System.Security.Cryptography.SHA256" /> hash for the input data.</summary>
	// Token: 0x02000292 RID: 658
	[ComVisible(true)]
	public abstract class SHA256 : HashAlgorithm
	{
		/// <summary>Initializes a new instance of <see cref="T:System.Security.Cryptography.SHA256" />.</summary>
		// Token: 0x06002355 RID: 9045 RVA: 0x000805B4 File Offset: 0x0007E7B4
		protected SHA256()
		{
			this.HashSizeValue = 256;
		}

		/// <summary>Creates an instance of the default implementation of <see cref="T:System.Security.Cryptography.SHA256" />.</summary>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA256" />. On the .NET Framework, this method creates an instance of the <see cref="T:System.Security.Cryptography.SHA256Managed" /> class if FIPS mode is not active; if FIPS mode is active, it creates an instance of the <see cref="T:System.Security.Cryptography.SHA256Cng" /> class. On .NET Core, it returns an instance of a private class derived from <see cref="T:System.Security.Cryptography.SHA256" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">On the .NET Framework 4.6.1 and earlier versions only: The algorithm was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		// Token: 0x06002356 RID: 9046 RVA: 0x000805C7 File Offset: 0x0007E7C7
		public new static SHA256 Create()
		{
			return SHA256.Create("System.Security.Cryptography.SHA256");
		}

		/// <summary>Creates an instance of a specified implementation of <see cref="T:System.Security.Cryptography.SHA256" />.</summary>
		/// <param name="hashName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.SHA256" /> to be used.</param>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA256" /> using the specified implementation.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">On the .NET Framework only: FIPS mode is enabled, but <paramref name="hashName" /> requests <see cref="T:System.Security.Cryptography.SHA256Managed" />, which is not FIPS compatible.</exception>
		// Token: 0x06002357 RID: 9047 RVA: 0x000805D3 File Offset: 0x0007E7D3
		public new static SHA256 Create(string hashName)
		{
			return (SHA256)CryptoConfig.CreateFromName(hashName);
		}
	}
}
