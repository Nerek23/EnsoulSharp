using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200003B RID: 59
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RasterizerStateDescription1
	{
		// Token: 0x060002A4 RID: 676 RVA: 0x0000B058 File Offset: 0x00009258
		public static RasterizerStateDescription1 Default()
		{
			return new RasterizerStateDescription1
			{
				FillMode = FillMode.Solid,
				CullMode = CullMode.Back,
				IsFrontCounterClockwise = false,
				DepthBias = 0,
				SlopeScaledDepthBias = 0f,
				DepthBiasClamp = 0f,
				IsDepthClipEnabled = true,
				IsScissorEnabled = false,
				IsMultisampleEnabled = false,
				IsAntialiasedLineEnabled = false,
				ForcedSampleCount = 0
			};
		}

		// Token: 0x040000BB RID: 187
		public FillMode FillMode;

		// Token: 0x040000BC RID: 188
		public CullMode CullMode;

		// Token: 0x040000BD RID: 189
		public RawBool IsFrontCounterClockwise;

		// Token: 0x040000BE RID: 190
		public int DepthBias;

		// Token: 0x040000BF RID: 191
		public float DepthBiasClamp;

		// Token: 0x040000C0 RID: 192
		public float SlopeScaledDepthBias;

		// Token: 0x040000C1 RID: 193
		public RawBool IsDepthClipEnabled;

		// Token: 0x040000C2 RID: 194
		public RawBool IsScissorEnabled;

		// Token: 0x040000C3 RID: 195
		public RawBool IsMultisampleEnabled;

		// Token: 0x040000C4 RID: 196
		public RawBool IsAntialiasedLineEnabled;

		// Token: 0x040000C5 RID: 197
		public int ForcedSampleCount;
	}
}
