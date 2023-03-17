using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Allows security actions for <see cref="T:System.Security.Permissions.UIPermission" /> to be applied to code using declarative security. This class cannot be inherited.</summary>
	// Token: 0x020002CC RID: 716
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class UIPermissionAttribute : CodeAccessSecurityAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.UIPermissionAttribute" /> class with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x060025B3 RID: 9651 RVA: 0x00088288 File Offset: 0x00086488
		public UIPermissionAttribute(SecurityAction action) : base(action)
		{
		}

		/// <summary>Gets or sets the type of access to the window resources that is permitted.</summary>
		/// <returns>One of the <see cref="T:System.Security.Permissions.UIPermissionWindow" /> values.</returns>
		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060025B4 RID: 9652 RVA: 0x00088291 File Offset: 0x00086491
		// (set) Token: 0x060025B5 RID: 9653 RVA: 0x00088299 File Offset: 0x00086499
		public UIPermissionWindow Window
		{
			get
			{
				return this.m_windowFlag;
			}
			set
			{
				this.m_windowFlag = value;
			}
		}

		/// <summary>Gets or sets the type of access to the clipboard that is permitted.</summary>
		/// <returns>One of the <see cref="T:System.Security.Permissions.UIPermissionClipboard" /> values.</returns>
		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060025B6 RID: 9654 RVA: 0x000882A2 File Offset: 0x000864A2
		// (set) Token: 0x060025B7 RID: 9655 RVA: 0x000882AA File Offset: 0x000864AA
		public UIPermissionClipboard Clipboard
		{
			get
			{
				return this.m_clipboardFlag;
			}
			set
			{
				this.m_clipboardFlag = value;
			}
		}

		/// <summary>Creates and returns a new <see cref="T:System.Security.Permissions.UIPermission" />.</summary>
		/// <returns>A <see cref="T:System.Security.Permissions.UIPermission" /> that corresponds to this attribute.</returns>
		// Token: 0x060025B8 RID: 9656 RVA: 0x000882B3 File Offset: 0x000864B3
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new UIPermission(PermissionState.Unrestricted);
			}
			return new UIPermission(this.m_windowFlag, this.m_clipboardFlag);
		}

		// Token: 0x04000E48 RID: 3656
		private UIPermissionWindow m_windowFlag;

		// Token: 0x04000E49 RID: 3657
		private UIPermissionClipboard m_clipboardFlag;
	}
}
