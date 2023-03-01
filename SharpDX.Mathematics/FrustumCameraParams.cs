using System;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200000F RID: 15
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FrustumCameraParams
	{
		// Token: 0x040000D1 RID: 209
		public Vector3 Position;

		// Token: 0x040000D2 RID: 210
		public Vector3 LookAtDir;

		// Token: 0x040000D3 RID: 211
		public Vector3 UpDir;

		// Token: 0x040000D4 RID: 212
		public float FOV;

		// Token: 0x040000D5 RID: 213
		public float ZNear;

		// Token: 0x040000D6 RID: 214
		public float ZFar;

		// Token: 0x040000D7 RID: 215
		public float AspectRatio;
	}
}
