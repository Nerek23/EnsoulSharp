using System;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	/// <summary>Wraps objects the marshaler should marshal as a <see langword="VT_DISPATCH" />.</summary>
	// Token: 0x02000931 RID: 2353
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DispatchWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.DispatchWrapper" /> class with the object being wrapped.</summary>
		/// <param name="obj">The object to be wrapped and converted to <see cref="F:System.Runtime.InteropServices.VarEnum.VT_DISPATCH" />.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="obj" /> is not a class or an array.  
		/// -or-  
		/// <paramref name="obj" /> does not support <see langword="IDispatch" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <paramref name="obj" /> parameter was marked with a <see cref="T:System.Runtime.InteropServices.ComVisibleAttribute" /> attribute that was passed a value of <see langword="false" />.  
		///  -or-  
		///  The <paramref name="obj" /> parameter inherits from a type marked with a <see cref="T:System.Runtime.InteropServices.ComVisibleAttribute" /> attribute that was passed a value of <see langword="false" />.</exception>
		// Token: 0x060060FD RID: 24829 RVA: 0x0014AB90 File Offset: 0x00148D90
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public DispatchWrapper(object obj)
		{
			if (obj != null)
			{
				IntPtr idispatchForObject = Marshal.GetIDispatchForObject(obj);
				Marshal.Release(idispatchForObject);
			}
			this.m_WrappedObject = obj;
		}

		/// <summary>Gets the object wrapped by the <see cref="T:System.Runtime.InteropServices.DispatchWrapper" />.</summary>
		/// <returns>The object wrapped by the <see cref="T:System.Runtime.InteropServices.DispatchWrapper" />.</returns>
		// Token: 0x170010FB RID: 4347
		// (get) Token: 0x060060FE RID: 24830 RVA: 0x0014ABBB File Offset: 0x00148DBB
		[__DynamicallyInvokable]
		public object WrappedObject
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_WrappedObject;
			}
		}

		// Token: 0x04002AD2 RID: 10962
		private object m_WrappedObject;
	}
}
