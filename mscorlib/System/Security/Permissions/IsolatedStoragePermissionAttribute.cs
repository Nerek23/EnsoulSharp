using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.IsolatedStoragePermission" /> to be applied to code using declarative security.</summary>
	// Token: 0x020002D2 RID: 722
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public abstract class IsolatedStoragePermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.IsolatedStoragePermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x060025D5 RID: 9685 RVA: 0x0008853E File Offset: 0x0008673E
		protected IsolatedStoragePermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets the maximum user storage quota size.</summary>
		/// <returns>The maximum user storage quota size in bytes.</returns>
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x060025D7 RID: 9687 RVA: 0x00088550 File Offset: 0x00086750
		// (set) Token: 0x060025D6 RID: 9686 RVA: 0x00088547 File Offset: 0x00086747
		public long UserQuota
		{
			get
			{
				return this.m_userQuota;
			}
			set
			{
				this.m_userQuota = value;
			}
		}

		/// <summary>Gets or sets the level of isolated storage that should be declared.</summary>
		/// <returns>One of the <see cref="T:System.Security.Permissions.IsolatedStorageContainment" /> values.</returns>
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x060025D9 RID: 9689 RVA: 0x00088561 File Offset: 0x00086761
		// (set) Token: 0x060025D8 RID: 9688 RVA: 0x00088558 File Offset: 0x00086758
		public IsolatedStorageContainment UsageAllowed
		{
			get
			{
				return this.m_allowed;
			}
			set
			{
				this.m_allowed = value;
			}
		}

		// Token: 0x04000E53 RID: 3667
		internal long m_userQuota;

		// Token: 0x04000E54 RID: 3668
		internal IsolatedStorageContainment m_allowed;
	}
}
