using System;

namespace System.Reflection
{
	/// <summary>Provides migration from an older, simpler strong name key to a larger key with a stronger hashing algorithm.</summary>
	// Token: 0x02000598 RID: 1432
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	public sealed class AssemblySignatureKeyAttribute : Attribute
	{
		/// <summary>Creates a new instance of the <see cref="T:System.Reflection.AssemblySignatureKeyAttribute" /> class by using the specified public key and countersignature.</summary>
		/// <param name="publicKey">The public or identity key.</param>
		/// <param name="countersignature">The countersignature, which is the signature key portion of the strong-name key.</param>
		// Token: 0x06004359 RID: 17241 RVA: 0x000F7B42 File Offset: 0x000F5D42
		[__DynamicallyInvokable]
		public AssemblySignatureKeyAttribute(string publicKey, string countersignature)
		{
			this._publicKey = publicKey;
			this._countersignature = countersignature;
		}

		/// <summary>Gets the public key for the strong name used to sign the assembly.</summary>
		/// <returns>The public key for this assembly.</returns>
		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x0600435A RID: 17242 RVA: 0x000F7B58 File Offset: 0x000F5D58
		[__DynamicallyInvokable]
		public string PublicKey
		{
			[__DynamicallyInvokable]
			get
			{
				return this._publicKey;
			}
		}

		/// <summary>Gets the countersignature for the strong name for this assembly.</summary>
		/// <returns>The countersignature for this signature key.</returns>
		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x0600435B RID: 17243 RVA: 0x000F7B60 File Offset: 0x000F5D60
		[__DynamicallyInvokable]
		public string Countersignature
		{
			[__DynamicallyInvokable]
			get
			{
				return this._countersignature;
			}
		}

		// Token: 0x04001B54 RID: 6996
		private string _publicKey;

		// Token: 0x04001B55 RID: 6997
		private string _countersignature;
	}
}
