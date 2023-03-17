using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Represents the abstract class from which all implementations of the MD160 hash algorithm inherit.</summary>
	// Token: 0x02000278 RID: 632
	[ComVisible(true)]
	public abstract class RIPEMD160 : HashAlgorithm
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.RIPEMD160" /> class.</summary>
		// Token: 0x0600226C RID: 8812 RVA: 0x00079BCC File Offset: 0x00077DCC
		protected RIPEMD160()
		{
			this.HashSizeValue = 160;
		}

		/// <summary>Creates an instance of the default implementation of the <see cref="T:System.Security.Cryptography.RIPEMD160" /> hash algorithm.</summary>
		/// <returns>A new instance of the <see cref="T:System.Security.Cryptography.RIPEMD160" /> hash algorithm.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm was used with Federal Information Processing Standards (FIPS) mode enabled, but it is not FIPS-compatible.</exception>
		// Token: 0x0600226D RID: 8813 RVA: 0x00079BDF File Offset: 0x00077DDF
		public new static RIPEMD160 Create()
		{
			return RIPEMD160.Create("System.Security.Cryptography.RIPEMD160");
		}

		/// <summary>Creates an instance of the specified implementation of the <see cref="T:System.Security.Cryptography.RIPEMD160" /> hash algorithm.</summary>
		/// <param name="hashName">The name of the specific implementation of <see cref="T:System.Security.Cryptography.RIPEMD160" /> to use.</param>
		/// <returns>A new instance of the specified implementation of <see cref="T:System.Security.Cryptography.RIPEMD160" />.</returns>
		/// <exception cref="T:System.Reflection.TargetInvocationException">The algorithm described by the <paramref name="hashName" /> parameter was used with Federal Information Processing Standards (FIPS) mode enabled, but it is not FIPS-compatible.</exception>
		// Token: 0x0600226E RID: 8814 RVA: 0x00079BEB File Offset: 0x00077DEB
		public new static RIPEMD160 Create(string hashName)
		{
			return (RIPEMD160)CryptoConfig.CreateFromName(hashName);
		}
	}
}
