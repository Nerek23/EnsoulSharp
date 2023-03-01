using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000096 RID: 150
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OutputDuplicatePointerPosition
	{
		// Token: 0x04000DD2 RID: 3538
		public RawPoint Position;

		// Token: 0x04000DD3 RID: 3539
		public RawBool Visible;
	}
}
