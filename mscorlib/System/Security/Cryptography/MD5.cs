using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Represents the abstract class from which all implementations of the <see cref="T:System.Security.Cryptography.MD5" /> hash algorithm inherit.</summary>
	// Token: 0x02000270 RID: 624
	[ComVisible(true)]
	public abstract class MD5 : HashAlgorithm
	{
		/// <summary>Initializes a new instance of <see cref="T:System.Security.Cryptography.MD5" />.</summary>
		// Token: 0x06002220 RID: 8736 RVA: 0x000788E1 File Offset: 0x00076AE1
		protected MD5()
		{
			this.HashSizeValue = 128;
		}

		/// <summary>Creates an instance of the default implementation of the <see cref="T:System.Security.Cryptography.MD5" /> hash algorithm.</summary>
		/// <returns>A new instance of the <see cref="T:System.Security.Cryptography.MD5" /> hash algorithm.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		// Token: 0x06002221 RID: 8737 RVA: 0x000788F4 File Offset: 0x00076AF4
		public new static MD5 Create()
		{
			return MD5.Create("System.Security.Cryptography.MD5");
		}

		/// <summary>Creates an instance of the specified implementation of the <see cref="T:System.Security.Cryptography.MD5" /> hash algorithm.</summary>
		/// <param name="algName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.MD5" /> to use.</param>
		/// <returns>A new instance of the specified implementation of <see cref="T:System.Security.Cryptography.MD5" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm described by the <paramref name="algName" /> parameter was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		// Token: 0x06002222 RID: 8738 RVA: 0x00078900 File Offset: 0x00076B00
		public new static MD5 Create(string algName)
		{
			return (MD5)CryptoConfig.CreateFromName(algName);
		}
	}
}
