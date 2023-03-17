using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Controls the marshaling behavior of a delegate signature passed as an unmanaged function pointer to or from unmanaged code. This class cannot be inherited.</summary>
	// Token: 0x020008E2 RID: 2274
	[AttributeUsage(AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class UnmanagedFunctionPointerAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute" /> class with the specified calling convention.</summary>
		/// <param name="callingConvention">The specified calling convention.</param>
		// Token: 0x06005ED1 RID: 24273 RVA: 0x00146AD6 File Offset: 0x00144CD6
		[__DynamicallyInvokable]
		public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention)
		{
			this.m_callingConvention = callingConvention;
		}

		/// <summary>Gets the value of the calling convention.</summary>
		/// <returns>The value of the calling convention specified by the <see cref="M:System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute.#ctor(System.Runtime.InteropServices.CallingConvention)" /> constructor.</returns>
		// Token: 0x170010B7 RID: 4279
		// (get) Token: 0x06005ED2 RID: 24274 RVA: 0x00146AE5 File Offset: 0x00144CE5
		[__DynamicallyInvokable]
		public CallingConvention CallingConvention
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_callingConvention;
			}
		}

		// Token: 0x040029A2 RID: 10658
		private CallingConvention m_callingConvention;

		/// <summary>Indicates how to marshal string parameters to the method, and controls name mangling.</summary>
		// Token: 0x040029A3 RID: 10659
		[__DynamicallyInvokable]
		public CharSet CharSet;

		/// <summary>Enables or disables best-fit mapping behavior when converting Unicode characters to ANSI characters.</summary>
		// Token: 0x040029A4 RID: 10660
		[__DynamicallyInvokable]
		public bool BestFitMapping;

		/// <summary>Enables or disables the throwing of an exception on an unmappable Unicode character that is converted to an ANSI "?" character.</summary>
		// Token: 0x040029A5 RID: 10661
		[__DynamicallyInvokable]
		public bool ThrowOnUnmappableChar;

		/// <summary>Indicates whether the callee calls the <see langword="SetLastError" /> Win32 API function before returning from the attributed method.</summary>
		// Token: 0x040029A6 RID: 10662
		[__DynamicallyInvokable]
		public bool SetLastError;
	}
}
