using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the base attribute class for declarative security from which <see cref="T:System.Security.Permissions.CodeAccessSecurityAttribute" /> is derived.</summary>
	// Token: 0x020002C2 RID: 706
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public abstract class SecurityAttribute : Attribute
	{
		/// <summary>Initializes a new instance of <see cref="T:System.Security.Permissions.SecurityAttribute" /> with the specified <see cref="T:System.Security.Permissions.SecurityAction" />.</summary>
		/// <param name="action">One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</param>
		// Token: 0x06002535 RID: 9525 RVA: 0x000878C0 File Offset: 0x00085AC0
		protected SecurityAttribute(SecurityAction action)
		{
			this.m_action = action;
		}

		/// <summary>Gets or sets a security action.</summary>
		/// <returns>One of the <see cref="T:System.Security.Permissions.SecurityAction" /> values.</returns>
		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06002536 RID: 9526 RVA: 0x000878CF File Offset: 0x00085ACF
		// (set) Token: 0x06002537 RID: 9527 RVA: 0x000878D7 File Offset: 0x00085AD7
		public SecurityAction Action
		{
			get
			{
				return this.m_action;
			}
			set
			{
				this.m_action = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether full (unrestricted) permission to the resource protected by the attribute is declared.</summary>
		/// <returns>
		///   <see langword="true" /> if full permission to the protected resource is declared; otherwise, <see langword="false" />.</returns>
		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06002538 RID: 9528 RVA: 0x000878E0 File Offset: 0x00085AE0
		// (set) Token: 0x06002539 RID: 9529 RVA: 0x000878E8 File Offset: 0x00085AE8
		public bool Unrestricted
		{
			get
			{
				return this.m_unrestricted;
			}
			set
			{
				this.m_unrestricted = value;
			}
		}

		/// <summary>When overridden in a derived class, creates a permission object that can then be serialized into binary form and persistently stored along with the <see cref="T:System.Security.Permissions.SecurityAction" /> in an assembly's metadata.</summary>
		/// <returns>A serializable permission object.</returns>
		// Token: 0x0600253A RID: 9530
		public abstract IPermission CreatePermission();

		// Token: 0x0600253B RID: 9531 RVA: 0x000878F4 File Offset: 0x00085AF4
		[SecurityCritical]
		internal static IntPtr FindSecurityAttributeTypeHandle(string typeName)
		{
			PermissionSet.s_fullTrust.Assert();
			Type type = Type.GetType(typeName, false, false);
			if (type == null)
			{
				return IntPtr.Zero;
			}
			return type.TypeHandle.Value;
		}

		// Token: 0x04000E2B RID: 3627
		internal SecurityAction m_action;

		// Token: 0x04000E2C RID: 3628
		internal bool m_unrestricted;
	}
}
