using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000F0 RID: 240
	public struct Light
	{
		// Token: 0x04000D95 RID: 3477
		public LightType Type;

		// Token: 0x04000D96 RID: 3478
		public RawColor4 Diffuse;

		// Token: 0x04000D97 RID: 3479
		public RawColor4 Specular;

		// Token: 0x04000D98 RID: 3480
		public RawColor4 Ambient;

		// Token: 0x04000D99 RID: 3481
		public RawVector3 Position;

		// Token: 0x04000D9A RID: 3482
		public RawVector3 Direction;

		// Token: 0x04000D9B RID: 3483
		public float Range;

		// Token: 0x04000D9C RID: 3484
		public float Falloff;

		// Token: 0x04000D9D RID: 3485
		public float Attenuation0;

		// Token: 0x04000D9E RID: 3486
		public float Attenuation1;

		// Token: 0x04000D9F RID: 3487
		public float Attenuation2;

		// Token: 0x04000DA0 RID: 3488
		public float Theta;

		// Token: 0x04000DA1 RID: 3489
		public float Phi;
	}
}
