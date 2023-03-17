using System;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	/// <summary>Marshals data of type <see langword="VT_BSTR" /> from managed to unmanaged code. This class cannot be inherited.</summary>
	// Token: 0x0200092F RID: 2351
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class BStrWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.BStrWrapper" /> class with the specified <see cref="T:System.String" /> object.</summary>
		/// <param name="value">The object to wrap and marshal as <see langword="VT_BSTR" />.</param>
		// Token: 0x060060F7 RID: 24823 RVA: 0x0014AB1B File Offset: 0x00148D1B
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public BStrWrapper(string value)
		{
			this.m_WrappedObject = value;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.BStrWrapper" /> class with the specified <see cref="T:System.Object" /> object.</summary>
		/// <param name="value">The object to wrap and marshal as <see langword="VT_BSTR" />.</param>
		// Token: 0x060060F8 RID: 24824 RVA: 0x0014AB2A File Offset: 0x00148D2A
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public BStrWrapper(object value)
		{
			this.m_WrappedObject = (string)value;
		}

		/// <summary>Gets the wrapped <see cref="T:System.String" /> object to marshal as type <see langword="VT_BSTR" />.</summary>
		/// <returns>The object that is wrapped by <see cref="T:System.Runtime.InteropServices.BStrWrapper" />.</returns>
		// Token: 0x170010F9 RID: 4345
		// (get) Token: 0x060060F9 RID: 24825 RVA: 0x0014AB3E File Offset: 0x00148D3E
		[__DynamicallyInvokable]
		public string WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002AD0 RID: 10960
		private string m_WrappedObject;
	}
}
