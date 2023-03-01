using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000077 RID: 119
	[Flags]
	public enum PrimitiveMiscCaps
	{
		// Token: 0x04000775 RID: 1909
		MaskZ = 2,
		// Token: 0x04000776 RID: 1910
		CullNone = 16,
		// Token: 0x04000777 RID: 1911
		CullCW = 32,
		// Token: 0x04000778 RID: 1912
		CullCCW = 64,
		// Token: 0x04000779 RID: 1913
		ColorWriteEnable = 128,
		// Token: 0x0400077A RID: 1914
		ClipPlanesScaledPoints = 256,
		// Token: 0x0400077B RID: 1915
		ClipTLVertices = 512,
		// Token: 0x0400077C RID: 1916
		TssArgTemp = 1024,
		// Token: 0x0400077D RID: 1917
		BlendOperation = 2048,
		// Token: 0x0400077E RID: 1918
		NullReference = 4096,
		// Token: 0x0400077F RID: 1919
		IndependentWriteMasks = 16384,
		// Token: 0x04000780 RID: 1920
		PerStageConstant = 32768,
		// Token: 0x04000781 RID: 1921
		FogAndSpecularAlpha = 65536,
		// Token: 0x04000782 RID: 1922
		SeparateAlphaBlend = 131072,
		// Token: 0x04000783 RID: 1923
		MrtIndependentBitDepths = 262144,
		// Token: 0x04000784 RID: 1924
		MrtPostPixelShaderBlending = 524288,
		// Token: 0x04000785 RID: 1925
		FogVertexClamped = 1048576,
		// Token: 0x04000786 RID: 1926
		PostBlendSrgbConvert = 2097152
	}
}
