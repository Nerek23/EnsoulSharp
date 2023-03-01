using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000090 RID: 144
	[Flags]
	public enum TextureCoordIndex
	{
		// Token: 0x040008BF RID: 2239
		PassThru = 0,
		// Token: 0x040008C0 RID: 2240
		CameraSpaceNormal = 65536,
		// Token: 0x040008C1 RID: 2241
		CameraSpacePosition = 131072,
		// Token: 0x040008C2 RID: 2242
		CameraSpaceReflectionVector = 196608,
		// Token: 0x040008C3 RID: 2243
		SphereMap = 262144
	}
}
