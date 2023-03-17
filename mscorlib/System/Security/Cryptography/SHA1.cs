using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Computes the <see cref="T:System.Security.Cryptography.SHA1" /> hash for the input data.</summary>
	// Token: 0x0200028F RID: 655
	[ComVisible(true)]
	public abstract class SHA1 : HashAlgorithm
	{
		/// <summary>Initializes a new instance of <see cref="T:System.Security.Cryptography.SHA1" />.</summary>
		/// <exception cref="T:System.InvalidOperationException">The policy on this object is not compliant with the FIPS algorithm.</exception>
		// Token: 0x06002343 RID: 9027 RVA: 0x0007FCAD File Offset: 0x0007DEAD
		protected SHA1()
		{
			this.HashSizeValue = 160;
		}

		/// <summary>Creates an instance of the default implementation of <see cref="T:System.Security.Cryptography.SHA1" />.</summary>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA1" />.</returns>
		// Token: 0x06002344 RID: 9028 RVA: 0x0007FCC0 File Offset: 0x0007DEC0
		public new static SHA1 Create()
		{
			return SHA1.Create("System.Security.Cryptography.SHA1");
		}

		/// <summary>Creates an instance of the specified implementation of <see cref="T:System.Security.Cryptography.SHA1" />.</summary>
		/// <param name="hashName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.SHA1" /> to be used.</param>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA1" /> using the specified implementation.</returns>
		// Token: 0x06002345 RID: 9029 RVA: 0x0007FCCC File Offset: 0x0007DECC
		public new static SHA1 Create(string hashName)
		{
			return (SHA1)CryptoConfig.CreateFromName(hashName);
		}
	}
}
