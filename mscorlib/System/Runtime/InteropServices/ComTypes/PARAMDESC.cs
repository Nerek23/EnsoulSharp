using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains information about how to transfer a structure element, parameter, or function return value between processes.</summary>
	// Token: 0x02000A15 RID: 2581
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PARAMDESC
	{
		/// <summary>Represents a pointer to a value that is being passed between processes.</summary>
		// Token: 0x04002CF6 RID: 11510
		public IntPtr lpVarValue;

		/// <summary>Represents bitmask values that describe the structure element, parameter, or return value.</summary>
		// Token: 0x04002CF7 RID: 11511
		[__DynamicallyInvokable]
		public PARAMFLAG wParamFlags;
	}
}
