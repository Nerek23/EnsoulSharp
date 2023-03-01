using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000087 RID: 135
	[Flags]
	public enum StencilCaps
	{
		// Token: 0x0400086C RID: 2156
		Keep = 1,
		// Token: 0x0400086D RID: 2157
		Zero = 2,
		// Token: 0x0400086E RID: 2158
		Replace = 4,
		// Token: 0x0400086F RID: 2159
		IncrementClamp = 8,
		// Token: 0x04000870 RID: 2160
		DecrementClamp = 16,
		// Token: 0x04000871 RID: 2161
		Invert = 32,
		// Token: 0x04000872 RID: 2162
		Increment = 64,
		// Token: 0x04000873 RID: 2163
		Decrement = 128,
		// Token: 0x04000874 RID: 2164
		TwoSided = 256
	}
}
