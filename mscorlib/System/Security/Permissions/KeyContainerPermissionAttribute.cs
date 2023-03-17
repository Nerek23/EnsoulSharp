using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.KeyContainerPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002C7 RID: 711
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class KeyContainerPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.KeyContainerPermissionAttribute" /> class with the specified security action.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x06002561 RID: 9569 RVA: 0x00087C10 File Offset: 0x00085E10
		public KeyContainerPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets the name of the key store.</summary>
		/// <returns>The name of the key store. The default is "*".</returns>
		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06002562 RID: 9570 RVA: 0x00087C27 File Offset: 0x00085E27
		// (set) Token: 0x06002563 RID: 9571 RVA: 0x00087C2F File Offset: 0x00085E2F
		public string KeyStore
		{
			get
			{
				return this.m_keyStore;
			}
			set
			{
				this.m_keyStore = value;
			}
		}

		/// <summary>Gets or sets the provider name.</summary>
		/// <returns>The name of the provider.</returns>
		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06002564 RID: 9572 RVA: 0x00087C38 File Offset: 0x00085E38
		// (set) Token: 0x06002565 RID: 9573 RVA: 0x00087C40 File Offset: 0x00085E40
		public string ProviderName
		{
			get
			{
				return this.m_providerName;
			}
			set
			{
				this.m_providerName = value;
			}
		}

		/// <summary>Gets or sets the provider type.</summary>
		/// <returns>One of the PROV_ values defined in the Wincrypt.h header file.</returns>
		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06002566 RID: 9574 RVA: 0x00087C49 File Offset: 0x00085E49
		// (set) Token: 0x06002567 RID: 9575 RVA: 0x00087C51 File Offset: 0x00085E51
		public int ProviderType
		{
			get
			{
				return this.m_providerType;
			}
			set
			{
				this.m_providerType = value;
			}
		}

		/// <summary>Gets or sets the name of the key container.</summary>
		/// <returns>The name of the key container.</returns>
		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06002568 RID: 9576 RVA: 0x00087C5A File Offset: 0x00085E5A
		// (set) Token: 0x06002569 RID: 9577 RVA: 0x00087C62 File Offset: 0x00085E62
		public string KeyContainerName
		{
			get
			{
				return this.m_keyContainerName;
			}
			set
			{
				this.m_keyContainerName = value;
			}
		}

		/// <summary>Gets or sets the key specification.</summary>
		/// <returns>One of the AT_ values defined in the Wincrypt.h header file.</returns>
		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x0600256A RID: 9578 RVA: 0x00087C6B File Offset: 0x00085E6B
		// (set) Token: 0x0600256B RID: 9579 RVA: 0x00087C73 File Offset: 0x00085E73
		public int KeySpec
		{
			get
			{
				return this.m_keySpec;
			}
			set
			{
				this.m_keySpec = value;
			}
		}

		/// <summary>Gets or sets the key container permissions.</summary>
		/// <returns>A bitwise combination of the <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> values. The default is <see cref="F:System.Security.Permissions.KeyContainerPermissionFlags.NoFlags" />.</returns>
		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x0600256C RID: 9580 RVA: 0x00087C7C File Offset: 0x00085E7C
		// (set) Token: 0x0600256D RID: 9581 RVA: 0x00087C84 File Offset: 0x00085E84
		public KeyContainerPermissionFlags Flags
		{
			get
			{
				return this.m_flags;
			}
			set
			{
				this.m_flags = value;
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.KeyContainerPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.KeyContainerPermission" /> that corresponds to the attribute.</returns>
		// Token: 0x0600256E RID: 9582 RVA: 0x00087C90 File Offset: 0x00085E90
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new KeyContainerPermission(PermissionState.Unrestricted);
			}
			if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.m_keyStore, this.m_providerName, this.m_providerType, this.m_keyContainerName, this.m_keySpec))
			{
				return new KeyContainerPermission(this.m_flags);
			}
			KeyContainerPermission keyContainerPermission = new KeyContainerPermission(KeyContainerPermissionFlags.NoFlags);
			KeyContainerPermissionAccessEntry accessEntry = new KeyContainerPermissionAccessEntry(this.m_keyStore, this.m_providerName, this.m_providerType, this.m_keyContainerName, this.m_keySpec, this.m_flags);
			keyContainerPermission.AccessEntries.Add(accessEntry);
			return keyContainerPermission;
		}

		// Token: 0x04000E38 RID: 3640
		private KeyContainerPermissionFlags m_flags;

		// Token: 0x04000E39 RID: 3641
		private string m_keyStore;

		// Token: 0x04000E3A RID: 3642
		private string m_providerName;

		// Token: 0x04000E3B RID: 3643
		private int m_providerType = -1;

		// Token: 0x04000E3C RID: 3644
		private string m_keyContainerName;

		// Token: 0x04000E3D RID: 3645
		private int m_keySpec = -1;
	}
}
