using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains the arguments passed to a method or property by <see langword="IDispatch::Invoke" />.</summary>
	// Token: 0x02000A1A RID: 2586
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DISPPARAMS
	{
		/// <summary>Represents a reference to the array of arguments.</summary>
		// Token: 0x04002D07 RID: 11527
		[__DynamicallyInvokable]
		public IntPtr rgvarg;

		/// <summary>Represents the dispatch IDs of named arguments.</summary>
		// Token: 0x04002D08 RID: 11528
		[__DynamicallyInvokable]
		public IntPtr rgdispidNamedArgs;

		/// <summary>Represents the count of arguments.</summary>
		// Token: 0x04002D09 RID: 11529
		[__DynamicallyInvokable]
		public int cArgs;

		/// <summary>Represents the count of named arguments</summary>
		// Token: 0x04002D0A RID: 11530
		[__DynamicallyInvokable]
		public int cNamedArgs;
	}
}
