using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.StrongNameIdentityPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002CE RID: 718
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class StrongNameIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.StrongNameIdentityPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x060025BD RID: 9661 RVA: 0x00088312 File Offset: 0x00086512
		public StrongNameIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets the name of the strong name identity.</summary>
		/// <returns>A name to compare against the name specified by the security provider.</returns>
		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060025BE RID: 9662 RVA: 0x0008831B File Offset: 0x0008651B
		// (set) Token: 0x060025BF RID: 9663 RVA: 0x00088323 File Offset: 0x00086523
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		/// <summary>Gets or sets the version of the strong name identity.</summary>
		/// <returns>The version number of the strong name identity.</returns>
		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060025C0 RID: 9664 RVA: 0x0008832C File Offset: 0x0008652C
		// (set) Token: 0x060025C1 RID: 9665 RVA: 0x00088334 File Offset: 0x00086534
		public string Version
		{
			get
			{
				return this.m_version;
			}
			set
			{
				this.m_version = value;
			}
		}

		/// <summary>Gets or sets the public key value of the strong name identity expressed as a hexadecimal string.</summary>
		/// <returns>The public key value of the strong name identity expressed as a hexadecimal string.</returns>
		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060025C2 RID: 9666 RVA: 0x0008833D File Offset: 0x0008653D
		// (set) Token: 0x060025C3 RID: 9667 RVA: 0x00088345 File Offset: 0x00086545
		public string PublicKey
		{
			get
			{
				return this.m_blob;
			}
			set
			{
				this.m_blob = value;
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.StrongNameIdentityPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.StrongNameIdentityPermission" /> that corresponds to this attribute.</returns>
		/// <exception cref="T:System.ArgumentException">The method failed because the key is <see langword="null" />.</exception>
		// Token: 0x060025C4 RID: 9668 RVA: 0x00088350 File Offset: 0x00086550
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new StrongNameIdentityPermission(PermissionState.Unrestricted);
			}
			if (this.m_blob == null && this.m_name == null && this.m_version == null)
			{
				return new StrongNameIdentityPermission(PermissionState.None);
			}
			if (this.m_blob == null)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentNull_Key"));
			}
			StrongNamePublicKeyBlob blob = new StrongNamePublicKeyBlob(this.m_blob);
			if (this.m_version == null || this.m_version.Equals(string.Empty))
			{
				return new StrongNameIdentityPermission(blob, this.m_name, null);
			}
			return new StrongNameIdentityPermission(blob, this.m_name, new Version(this.m_version));
		}

		// Token: 0x04000E4B RID: 3659
		private string m_name;

		// Token: 0x04000E4C RID: 3660
		private string m_version;

		// Token: 0x04000E4D RID: 3661
		private string m_blob;
	}
}
