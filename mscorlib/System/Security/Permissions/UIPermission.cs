using System;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	/// <summary>Controls the permissions related to user interfaces and the Clipboard. This class cannot be inherited.</summary>
	// Token: 0x020002E1 RID: 737
	[ComVisible(true)]
	[Serializable]
	public sealed class UIPermission : CodeAccessPermission, IUnrestrictedPermission, IBuiltInPermission
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.UIPermission" /> class with either fully restricted or unrestricted access, as specified.</summary>
		/// <param name="state">One of the enumeration values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="state" /> parameter is not a valid <see cref="T:System.Security.Permissions.PermissionState" />.</exception>
		// Token: 0x06002651 RID: 9809 RVA: 0x0008ABAE File Offset: 0x00088DAE
		public UIPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.SetUnrestricted(true);
				return;
			}
			if (state == PermissionState.None)
			{
				this.SetUnrestricted(false);
				this.Reset();
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.UIPermission" /> class with the specified permissions for windows and the Clipboard.</summary>
		/// <param name="windowFlag">One of the enumeration values.</param>
		/// <param name="clipboardFlag">One of the enumeration values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="windowFlag" /> parameter is not a valid <see cref="T:System.Security.Permissions.UIPermissionWindow" /> value.  
		///  -or-  
		///  The <paramref name="clipboardFlag" /> parameter is not a valid <see cref="T:System.Security.Permissions.UIPermissionClipboard" /> value.</exception>
		// Token: 0x06002652 RID: 9810 RVA: 0x0008ABE2 File Offset: 0x00088DE2
		public UIPermission(UIPermissionWindow windowFlag, UIPermissionClipboard clipboardFlag)
		{
			UIPermission.VerifyWindowFlag(windowFlag);
			UIPermission.VerifyClipboardFlag(clipboardFlag);
			this.m_windowFlag = windowFlag;
			this.m_clipboardFlag = clipboardFlag;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.UIPermission" /> class with the permissions for windows, and no access to the Clipboard.</summary>
		/// <param name="windowFlag">One of the enumeration values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="windowFlag" /> parameter is not a valid <see cref="T:System.Security.Permissions.UIPermissionWindow" /> value.</exception>
		// Token: 0x06002653 RID: 9811 RVA: 0x0008AC04 File Offset: 0x00088E04
		public UIPermission(UIPermissionWindow windowFlag)
		{
			UIPermission.VerifyWindowFlag(windowFlag);
			this.m_windowFlag = windowFlag;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.UIPermission" /> class with the permissions for the Clipboard, and no access to windows.</summary>
		/// <param name="clipboardFlag">One of the enumeration values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="clipboardFlag" /> parameter is not a valid <see cref="T:System.Security.Permissions.UIPermissionClipboard" /> value.</exception>
		// Token: 0x06002654 RID: 9812 RVA: 0x0008AC19 File Offset: 0x00088E19
		public UIPermission(UIPermissionClipboard clipboardFlag)
		{
			UIPermission.VerifyClipboardFlag(clipboardFlag);
			this.m_clipboardFlag = clipboardFlag;
		}

		/// <summary>Gets or sets the window access represented by the permission.</summary>
		/// <returns>One of the <see cref="T:System.Security.Permissions.UIPermissionWindow" /> values.</returns>
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06002656 RID: 9814 RVA: 0x0008AC3D File Offset: 0x00088E3D
		// (set) Token: 0x06002655 RID: 9813 RVA: 0x0008AC2E File Offset: 0x00088E2E
		public UIPermissionWindow Window
		{
			get
			{
				return this.m_windowFlag;
			}
			set
			{
				UIPermission.VerifyWindowFlag(value);
				this.m_windowFlag = value;
			}
		}

		/// <summary>Gets or sets the Clipboard access represented by the permission.</summary>
		/// <returns>One of the <see cref="T:System.Security.Permissions.UIPermissionClipboard" /> values.</returns>
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06002658 RID: 9816 RVA: 0x0008AC54 File Offset: 0x00088E54
		// (set) Token: 0x06002657 RID: 9815 RVA: 0x0008AC45 File Offset: 0x00088E45
		public UIPermissionClipboard Clipboard
		{
			get
			{
				return this.m_clipboardFlag;
			}
			set
			{
				UIPermission.VerifyClipboardFlag(value);
				this.m_clipboardFlag = value;
			}
		}

		// Token: 0x06002659 RID: 9817 RVA: 0x0008AC5C File Offset: 0x00088E5C
		private static void VerifyWindowFlag(UIPermissionWindow flag)
		{
			if (flag < UIPermissionWindow.NoWindows || flag > UIPermissionWindow.AllWindows)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)flag
				}));
			}
		}

		// Token: 0x0600265A RID: 9818 RVA: 0x0008AC85 File Offset: 0x00088E85
		private static void VerifyClipboardFlag(UIPermissionClipboard flag)
		{
			if (flag < UIPermissionClipboard.NoClipboard || flag > UIPermissionClipboard.AllClipboard)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)flag
				}));
			}
		}

		// Token: 0x0600265B RID: 9819 RVA: 0x0008ACAE File Offset: 0x00088EAE
		private void Reset()
		{
			this.m_windowFlag = UIPermissionWindow.NoWindows;
			this.m_clipboardFlag = UIPermissionClipboard.NoClipboard;
		}

		// Token: 0x0600265C RID: 9820 RVA: 0x0008ACBE File Offset: 0x00088EBE
		private void SetUnrestricted(bool unrestricted)
		{
			if (unrestricted)
			{
				this.m_windowFlag = UIPermissionWindow.AllWindows;
				this.m_clipboardFlag = UIPermissionClipboard.AllClipboard;
			}
		}

		/// <summary>Returns a value indicating whether the current permission is unrestricted.</summary>
		/// <returns>
		///   <see langword="true" /> if the current permission is unrestricted; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600265D RID: 9821 RVA: 0x0008ACD1 File Offset: 0x00088ED1
		public bool IsUnrestricted()
		{
			return this.m_windowFlag == UIPermissionWindow.AllWindows && this.m_clipboardFlag == UIPermissionClipboard.AllClipboard;
		}

		/// <summary>Determines whether the current permission is a subset of the specified permission.</summary>
		/// <param name="target">A permission to test for the subset relationship. This permission must be the same type as the current permission.</param>
		/// <returns>
		///   <see langword="true" /> if the current permission is a subset of the specified permission; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x0600265E RID: 9822 RVA: 0x0008ACE8 File Offset: 0x00088EE8
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.m_windowFlag == UIPermissionWindow.NoWindows && this.m_clipboardFlag == UIPermissionClipboard.NoClipboard;
			}
			bool result;
			try
			{
				UIPermission uipermission = (UIPermission)target;
				if (uipermission.IsUnrestricted())
				{
					result = true;
				}
				else if (this.IsUnrestricted())
				{
					result = false;
				}
				else
				{
					result = (this.m_windowFlag <= uipermission.m_windowFlag && this.m_clipboardFlag <= uipermission.m_clipboardFlag);
				}
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return result;
		}

		/// <summary>Creates and returns a permission that is the intersection of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to intersect with the current permission. It must be the same type as the current permission.</param>
		/// <returns>A new permission that represents the intersection of the current permission and the specified permission. This new permission is <see langword="null" /> if the intersection is empty.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x0600265F RID: 9823 RVA: 0x0008AD88 File Offset: 0x00088F88
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			UIPermission uipermission = (UIPermission)target;
			UIPermissionWindow uipermissionWindow = (this.m_windowFlag < uipermission.m_windowFlag) ? this.m_windowFlag : uipermission.m_windowFlag;
			UIPermissionClipboard uipermissionClipboard = (this.m_clipboardFlag < uipermission.m_clipboardFlag) ? this.m_clipboardFlag : uipermission.m_clipboardFlag;
			if (uipermissionWindow == UIPermissionWindow.NoWindows && uipermissionClipboard == UIPermissionClipboard.NoClipboard)
			{
				return null;
			}
			return new UIPermission(uipermissionWindow, uipermissionClipboard);
		}

		/// <summary>Creates a permission that is the union of the permission and the specified permission.</summary>
		/// <param name="target">A permission to combine with the current permission. It must be the same type as the current permission.</param>
		/// <returns>A new permission that represents the union of the current permission and the specified permission.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x06002660 RID: 9824 RVA: 0x0008AE18 File Offset: 0x00089018
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			UIPermission uipermission = (UIPermission)target;
			UIPermissionWindow uipermissionWindow = (this.m_windowFlag > uipermission.m_windowFlag) ? this.m_windowFlag : uipermission.m_windowFlag;
			UIPermissionClipboard uipermissionClipboard = (this.m_clipboardFlag > uipermission.m_clipboardFlag) ? this.m_clipboardFlag : uipermission.m_clipboardFlag;
			if (uipermissionWindow == UIPermissionWindow.NoWindows && uipermissionClipboard == UIPermissionClipboard.NoClipboard)
			{
				return null;
			}
			return new UIPermission(uipermissionWindow, uipermissionClipboard);
		}

		/// <summary>Creates and returns an identical copy of the current permission.</summary>
		/// <returns>A copy of the current permission.</returns>
		// Token: 0x06002661 RID: 9825 RVA: 0x0008AEAC File Offset: 0x000890AC
		public override IPermission Copy()
		{
			return new UIPermission(this.m_windowFlag, this.m_clipboardFlag);
		}

		/// <summary>Creates an XML encoding of the permission and its current state.</summary>
		/// <returns>An XML encoding of the permission, including any state information.</returns>
		// Token: 0x06002662 RID: 9826 RVA: 0x0008AEC0 File Offset: 0x000890C0
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.UIPermission");
			if (!this.IsUnrestricted())
			{
				if (this.m_windowFlag != UIPermissionWindow.NoWindows)
				{
					securityElement.AddAttribute("Window", Enum.GetName(typeof(UIPermissionWindow), this.m_windowFlag));
				}
				if (this.m_clipboardFlag != UIPermissionClipboard.NoClipboard)
				{
					securityElement.AddAttribute("Clipboard", Enum.GetName(typeof(UIPermissionClipboard), this.m_clipboardFlag));
				}
			}
			else
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			return securityElement;
		}

		/// <summary>Reconstructs a permission with a specified state from an XML encoding.</summary>
		/// <param name="esd">The XML encoding used to reconstruct the permission.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="esd" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="esd" /> parameter is not a valid permission element.  
		///  -or-  
		///  The <paramref name="esd" /> parameter's version number is not valid.</exception>
		// Token: 0x06002663 RID: 9827 RVA: 0x0008AF50 File Offset: 0x00089150
		public override void FromXml(SecurityElement esd)
		{
			CodeAccessPermission.ValidateElement(esd, this);
			if (XMLUtil.IsUnrestricted(esd))
			{
				this.SetUnrestricted(true);
				return;
			}
			this.m_windowFlag = UIPermissionWindow.NoWindows;
			this.m_clipboardFlag = UIPermissionClipboard.NoClipboard;
			string text = esd.Attribute("Window");
			if (text != null)
			{
				this.m_windowFlag = (UIPermissionWindow)Enum.Parse(typeof(UIPermissionWindow), text);
			}
			string text2 = esd.Attribute("Clipboard");
			if (text2 != null)
			{
				this.m_clipboardFlag = (UIPermissionClipboard)Enum.Parse(typeof(UIPermissionClipboard), text2);
			}
		}

		// Token: 0x06002664 RID: 9828 RVA: 0x0008AFD6 File Offset: 0x000891D6
		int IBuiltInPermission.GetTokenIndex()
		{
			return UIPermission.GetTokenIndex();
		}

		// Token: 0x06002665 RID: 9829 RVA: 0x0008AFDD File Offset: 0x000891DD
		internal static int GetTokenIndex()
		{
			return 7;
		}

		// Token: 0x04000E98 RID: 3736
		private UIPermissionWindow m_windowFlag;

		// Token: 0x04000E99 RID: 3737
		private UIPermissionClipboard m_clipboardFlag;
	}
}
