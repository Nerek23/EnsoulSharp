using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Computes the <see cref="T:System.Security.Cryptography.SHA384" /> hash for the input data.</summary>
	// Token: 0x02000294 RID: 660
	[ComVisible(true)]
	public abstract class SHA384 : HashAlgorithm
	{
		/// <summary>Initializes a new instance of <see cref="T:System.Security.Cryptography.SHA384" />.</summary>
		// Token: 0x0600236A RID: 9066 RVA: 0x00080DAE File Offset: 0x0007EFAE
		protected SHA384()
		{
			this.HashSizeValue = 384;
		}

		/// <summary>Creates an instance of the default implementation of <see cref="T:System.Security.Cryptography.SHA384" />.</summary>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA384" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		// Token: 0x0600236B RID: 9067 RVA: 0x00080DC1 File Offset: 0x0007EFC1
		public new static SHA384 Create()
		{
			return SHA384.Create("System.Security.Cryptography.SHA384");
		}

		/// <summary>Creates an instance of a specified implementation of <see cref="T:System.Security.Cryptography.SHA384" />.</summary>
		/// <param name="hashName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.SHA384" /> to be used.</param>
		/// <returns>A new instance of <see cref="T:System.Security.Cryptography.SHA384" /> using the specified implementation.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm described by the <paramref name="hashName" /> parameter was used with Federal Information Processing Standards (FIPS) mode enabled, but is not FIPS compatible.</exception>
		// Token: 0x0600236C RID: 9068 RVA: 0x00080DCD File Offset: 0x0007EFCD
		public new static SHA384 Create(string hashName)
		{
			return (SHA384)CryptoConfig.CreateFromName(hashName);
		}
	}
}
