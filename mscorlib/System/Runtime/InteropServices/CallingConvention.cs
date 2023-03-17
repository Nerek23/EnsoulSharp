using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies the calling convention required to call methods implemented in unmanaged code.</summary>
	// Token: 0x02000915 RID: 2325
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum CallingConvention
	{
		/// <summary>This member is not actually a calling convention, but instead uses the default platform calling convention. For example, on Windows the default is <see cref="F:System.Runtime.InteropServices.CallingConvention.StdCall" /> and on Windows CE.NET it is <see cref="F:System.Runtime.InteropServices.CallingConvention.Cdecl" />.</summary>
		// Token: 0x04002A79 RID: 10873
		[__DynamicallyInvokable]
		Winapi = 1,
		/// <summary>The caller cleans the stack. This enables calling functions with <see langword="varargs" />, which makes it appropriate to use for methods that accept a variable number of parameters, such as <see langword="Printf" />.</summary>
		// Token: 0x04002A7A RID: 10874
		[__DynamicallyInvokable]
		Cdecl,
		/// <summary>The callee cleans the stack. This is the default convention for calling unmanaged functions with platform invoke.</summary>
		// Token: 0x04002A7B RID: 10875
		[__DynamicallyInvokable]
		StdCall,
		/// <summary>The first parameter is the <see langword="this" /> pointer and is stored in register ECX. Other parameters are pushed on the stack. This calling convention is used to call methods on classes exported from an unmanaged DLL.</summary>
		// Token: 0x04002A7C RID: 10876
		[__DynamicallyInvokable]
		ThisCall,
		/// <summary>This calling convention is not supported.</summary>
		// Token: 0x04002A7D RID: 10877
		FastCall
	}
}
