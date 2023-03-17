using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.FileDialogPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002C5 RID: 709
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class FileDialogPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.FileDialogPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x06002545 RID: 9541 RVA: 0x000879D6 File Offset: 0x00085BD6
		public FileDialogPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets a value indicating whether permission to open files through the file dialog is declared.</summary>
		/// <returns>
		///   <see langword="true" /> if permission to open files through the file dialog is declared; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06002546 RID: 9542 RVA: 0x000879DF File Offset: 0x00085BDF
		// (set) Token: 0x06002547 RID: 9543 RVA: 0x000879EC File Offset: 0x00085BEC
		public bool Open
		{
			get
			{
				return (this.m_access & FileDialogPermissionAccess.Open) > FileDialogPermissionAccess.None;
			}
			set
			{
				this.m_access = (value ? (this.m_access | FileDialogPermissionAccess.Open) : (this.m_access & ~FileDialogPermissionAccess.Open));
			}
		}

		/// <summary>Gets or sets a value indicating whether permission to save files through the file dialog is declared.</summary>
		/// <returns>
		///   <see langword="true" /> if permission to save files through the file dialog is declared; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06002548 RID: 9544 RVA: 0x00087A0A File Offset: 0x00085C0A
		// (set) Token: 0x06002549 RID: 9545 RVA: 0x00087A17 File Offset: 0x00085C17
		public bool Save
		{
			get
			{
				return (this.m_access & FileDialogPermissionAccess.Save) > FileDialogPermissionAccess.None;
			}
			set
			{
				this.m_access = (value ? (this.m_access | FileDialogPermissionAccess.Save) : (this.m_access & ~FileDialogPermissionAccess.Save));
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.FileDialogPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.FileDialogPermission" /> that corresponds to this attribute.</returns>
		// Token: 0x0600254A RID: 9546 RVA: 0x00087A35 File Offset: 0x00085C35
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new FileDialogPermission(PermissionState.Unrestricted);
			}
			return new FileDialogPermission(this.m_access);
		}

		// Token: 0x04000E2F RID: 3631
		private FileDialogPermissionAccess m_access;
	}
}
