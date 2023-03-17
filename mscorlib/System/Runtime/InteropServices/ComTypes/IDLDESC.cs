using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains information needed for transferring a structure element, parameter, or function return value between processes.</summary>
	// Token: 0x02000A13 RID: 2579
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct IDLDESC
	{
		/// <summary>Reserved; set to <see langword="null" />.</summary>
		// Token: 0x04002CEB RID: 11499
		public IntPtr dwReserved;

		/// <summary>Indicates an <see cref="T:System.Runtime.InteropServices.IDLFLAG" /> value describing the type.</summary>
		// Token: 0x04002CEC RID: 11500
		[__DynamicallyInvokable]
		public IDLFLAG wIDLFlags;
	}
}
