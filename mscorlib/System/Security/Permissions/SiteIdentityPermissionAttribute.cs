using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.SiteIdentityPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002CF RID: 719
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class SiteIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.SiteIdentityPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x060025C5 RID: 9669 RVA: 0x000883EE File Offset: 0x000865EE
		public SiteIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets the site name of the calling code.</summary>
		/// <returns>The site name to compare against the site name specified by the security provider.</returns>
		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060025C6 RID: 9670 RVA: 0x000883F7 File Offset: 0x000865F7
		// (set) Token: 0x060025C7 RID: 9671 RVA: 0x000883FF File Offset: 0x000865FF
		public string Site
		{
			get
			{
				return this.m_site;
			}
			set
			{
				this.m_site = value;
			}
		}

		/// <summary>Creates and returns a new instance of <see cref="T:System.Security.Permissions.SiteIdentityPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.SiteIdentityPermission" /> that corresponds to this attribute.</returns>
		// Token: 0x060025C8 RID: 9672 RVA: 0x00088408 File Offset: 0x00086608
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new SiteIdentityPermission(PermissionState.Unrestricted);
			}
			if (this.m_site == null)
			{
				return new SiteIdentityPermission(PermissionState.None);
			}
			return new SiteIdentityPermission(this.m_site);
		}

		// Token: 0x04000E4E RID: 3662
		private string m_site;
	}
}
