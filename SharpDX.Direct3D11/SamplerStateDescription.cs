using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000043 RID: 67
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SamplerStateDescription
	{
		// Token: 0x060002CA RID: 714 RVA: 0x0000B544 File Offset: 0x00009744
		public static SamplerStateDescription Default()
		{
			return new SamplerStateDescription
			{
				Filter = Filter.MinMagMipLinear,
				AddressU = TextureAddressMode.Clamp,
				AddressV = TextureAddressMode.Clamp,
				AddressW = TextureAddressMode.Clamp,
				MinimumLod = float.MinValue,
				MaximumLod = float.MaxValue,
				MipLodBias = 0f,
				MaximumAnisotropy = 16,
				ComparisonFunction = Comparison.Never,
				BorderColor = default(RawColor4)
			};
		}

		// Token: 0x040000DC RID: 220
		public Filter Filter;

		// Token: 0x040000DD RID: 221
		public TextureAddressMode AddressU;

		// Token: 0x040000DE RID: 222
		public TextureAddressMode AddressV;

		// Token: 0x040000DF RID: 223
		public TextureAddressMode AddressW;

		// Token: 0x040000E0 RID: 224
		public float MipLodBias;

		// Token: 0x040000E1 RID: 225
		public int MaximumAnisotropy;

		// Token: 0x040000E2 RID: 226
		public Comparison ComparisonFunction;

		// Token: 0x040000E3 RID: 227
		public RawColor4 BorderColor;

		// Token: 0x040000E4 RID: 228
		public float MinimumLod;

		// Token: 0x040000E5 RID: 229
		public float MaximumLod;
	}
}
