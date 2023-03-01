using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200003A RID: 58
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RasterizerStateDescription
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x0000AFD0 File Offset: 0x000091D0
		public static RasterizerStateDescription Default()
		{
			return new RasterizerStateDescription
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
				IsAntialiasedLineEnabled = false
			};
		}

		// Token: 0x040000B1 RID: 177
		public FillMode FillMode;

		// Token: 0x040000B2 RID: 178
		public CullMode CullMode;

		// Token: 0x040000B3 RID: 179
		public RawBool IsFrontCounterClockwise;

		// Token: 0x040000B4 RID: 180
		public int DepthBias;

		// Token: 0x040000B5 RID: 181
		public float DepthBiasClamp;

		// Token: 0x040000B6 RID: 182
		public float SlopeScaledDepthBias;

		// Token: 0x040000B7 RID: 183
		public RawBool IsDepthClipEnabled;

		// Token: 0x040000B8 RID: 184
		public RawBool IsScissorEnabled;

		// Token: 0x040000B9 RID: 185
		public RawBool IsMultisampleEnabled;

		// Token: 0x040000BA RID: 186
		public RawBool IsAntialiasedLineEnabled;
	}
}
