using System;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.InteropServices
{
	/// <summary>Wraps objects the marshaler should marshal as a <see langword="VT_ERROR" />.</summary>
	// Token: 0x02000932 RID: 2354
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class ErrorWrapper
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ErrorWrapper" /> class with the HRESULT of the error.</summary>
		/// <param name="errorCode">The HRESULT of the error.</param>
		// Token: 0x060060FF RID: 24831 RVA: 0x0014ABC3 File Offset: 0x00148DC3
		[__DynamicallyInvokable]
		public ErrorWrapper(int errorCode)
		{
			this.m_ErrorCode = errorCode;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ErrorWrapper" /> class with an object containing the HRESULT of the error.</summary>
		/// <param name="errorCode">The object containing the HRESULT of the error.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="errorCode" /> parameter is not an <see cref="T:System.Int32" /> type.</exception>
		// Token: 0x06006100 RID: 24832 RVA: 0x0014ABD2 File Offset: 0x00148DD2
		[__DynamicallyInvokable]
		public ErrorWrapper(object errorCode)
		{
			if (!(errorCode is int))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeInt32"), "errorCode");
			}
			this.m_ErrorCode = (int)errorCode;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.ErrorWrapper" /> class with the HRESULT that corresponds to the exception supplied.</summary>
		/// <param name="e">The exception to be converted to an error code.</param>
		// Token: 0x06006101 RID: 24833 RVA: 0x0014AC03 File Offset: 0x00148E03
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		public ErrorWrapper(Exception e)
		{
			this.m_ErrorCode = Marshal.GetHRForException(e);
		}

		/// <summary>Gets the error code of the wrapper.</summary>
		/// <returns>The HRESULT of the error.</returns>
		// Token: 0x170010FC RID: 4348
		// (get) Token: 0x06006102 RID: 24834 RVA: 0x0014AC17 File Offset: 0x00148E17
		[__DynamicallyInvokable]
		public int ErrorCode
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_ErrorCode;
			}
		}

		// Token: 0x04002AD3 RID: 10963
		private int m_ErrorCode;
	}
}
