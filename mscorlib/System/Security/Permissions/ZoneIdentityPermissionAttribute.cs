using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.ZoneIdentityPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002CD RID: 717
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class ZoneIdentityPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.ZoneIdentityPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x060025B9 RID: 9657 RVA: 0x000882D5 File Offset: 0x000864D5
		public ZoneIdentityPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets membership in the content zone specified by the property value.</summary>
		/// <returns>One of the <see cref="T:System.Security.SecurityZone" /> values.</returns>
		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060025BA RID: 9658 RVA: 0x000882E5 File Offset: 0x000864E5
		// (set) Token: 0x060025BB RID: 9659 RVA: 0x000882ED File Offset: 0x000864ED
		public SecurityZone Zone
		{
			get
			{
				return this.m_flag;
			}
			set
			{
				this.m_flag = value;
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.ZoneIdentityPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.ZoneIdentityPermission" /> that corresponds to this attribute.</returns>
		// Token: 0x060025BC RID: 9660 RVA: 0x000882F6 File Offset: 0x000864F6
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new ZoneIdentityPermission(PermissionState.Unrestricted);
			}
			return new ZoneIdentityPermission(this.m_flag);
		}

		// Token: 0x04000E4A RID: 3658
		private SecurityZone m_flag = SecurityZone.NoZone;
	}
}
