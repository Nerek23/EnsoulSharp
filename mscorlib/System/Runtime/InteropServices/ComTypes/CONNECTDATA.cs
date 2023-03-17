using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Describes a connection that exists to a given connection point.</summary>
	// Token: 0x020009FD RID: 2557
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CONNECTDATA
	{
		/// <summary>Represents a pointer to the <see langword="IUnknown" /> interface on a connected advisory sink. The caller must call <see langword="IUnknown::Release" /> on this pointer when the <see langword="CONNECTDATA" /> structure is no longer needed.</summary>
		// Token: 0x04002C8E RID: 11406
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.Interface)]
		public object pUnk;

		/// <summary>Represents a connection token that is returned from a call to <see cref="M:System.Runtime.InteropServices.ComTypes.IConnectionPoint.Advise(System.Object,System.Int32@)" />.</summary>
		// Token: 0x04002C8F RID: 11407
		[__DynamicallyInvokable]
		public int dwCookie;
	}
}
