using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000F5 RID: 245
	public struct Material
	{
		// Token: 0x04000DAB RID: 3499
		public RawColor4 Diffuse;

		// Token: 0x04000DAC RID: 3500
		public RawColor4 Ambient;

		// Token: 0x04000DAD RID: 3501
		public RawColor4 Specular;

		// Token: 0x04000DAE RID: 3502
		public RawColor4 Emissive;

		// Token: 0x04000DAF RID: 3503
		public float Power;
	}
}
