using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Wraps a managed object holding a handle to a resource that is passed to unmanaged code using platform invoke.</summary>
	// Token: 0x0200091D RID: 2333
	[ComVisible(true)]
	public struct HandleRef
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.HandleRef" /> class with the object to wrap and a handle to the resource used by unmanaged code.</summary>
		/// <param name="wrapper">A managed object that should not be finalized until the platform invoke call returns.</param>
		/// <param name="handle">An <see cref="T:System.IntPtr" /> that indicates a handle to a resource.</param>
		// Token: 0x06005F89 RID: 24457 RVA: 0x00147F3D File Offset: 0x0014613D
		public HandleRef(object wrapper, IntPtr handle)
		{
			this.m_wrapper = wrapper;
			this.m_handle = handle;
		}

		/// <summary>Gets the object holding the handle to a resource.</summary>
		/// <returns>The object holding the handle to a resource.</returns>
		// Token: 0x170010E4 RID: 4324
		// (get) Token: 0x06005F8A RID: 24458 RVA: 0x00147F4D File Offset: 0x0014614D
		public object Wrapper
		{
			get
			{
				return this.m_wrapper;
			}
		}

		/// <summary>Gets the handle to a resource.</summary>
		/// <returns>The handle to a resource.</returns>
		// Token: 0x170010E5 RID: 4325
		// (get) Token: 0x06005F8B RID: 24459 RVA: 0x00147F55 File Offset: 0x00146155
		public IntPtr Handle
		{
			get
			{
				return this.m_handle;
			}
		}

		/// <summary>Returns the handle to a resource of the specified <see cref="T:System.Runtime.InteropServices.HandleRef" /> object.</summary>
		/// <param name="value">The object that needs a handle.</param>
		/// <returns>The handle to a resource of the specified <see cref="T:System.Runtime.InteropServices.HandleRef" /> object.</returns>
		// Token: 0x06005F8C RID: 24460 RVA: 0x00147F5D File Offset: 0x0014615D
		public static explicit operator IntPtr(HandleRef value)
		{
			return value.m_handle;
		}

		/// <summary>Returns the internal integer representation of a <see cref="T:System.Runtime.InteropServices.HandleRef" /> object.</summary>
		/// <param name="value">A <see cref="T:System.Runtime.InteropServices.HandleRef" /> object to retrieve an internal integer representation from.</param>
		/// <returns>An <see cref="T:System.IntPtr" /> object that represents a <see cref="T:System.Runtime.InteropServices.HandleRef" /> object.</returns>
		// Token: 0x06005F8D RID: 24461 RVA: 0x00147F65 File Offset: 0x00146165
		public static IntPtr ToIntPtr(HandleRef value)
		{
			return value.m_handle;
		}

		// Token: 0x04002A97 RID: 10903
		internal object m_wrapper;

		// Token: 0x04002A98 RID: 10904
		internal IntPtr m_handle;
	}
}
