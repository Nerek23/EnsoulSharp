using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000F8 RID: 248
	[StructLayout(LayoutKind.Explicit)]
	public struct MeshData
	{
		// Token: 0x04000DC0 RID: 3520
		[FieldOffset(0)]
		public MeshDataType Type;

		// Token: 0x04000DC1 RID: 3521
		[FieldOffset(4)]
		public IntPtr PMesh;

		// Token: 0x04000DC2 RID: 3522
		[FieldOffset(4)]
		public IntPtr PPMesh;

		// Token: 0x04000DC3 RID: 3523
		[FieldOffset(4)]
		public IntPtr PPatchMesh;
	}
}
