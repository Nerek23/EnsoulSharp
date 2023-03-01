using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200007C RID: 124
	public enum RenderState
	{
		// Token: 0x040007B5 RID: 1973
		ZEnable = 7,
		// Token: 0x040007B6 RID: 1974
		FillMode,
		// Token: 0x040007B7 RID: 1975
		ShadeMode,
		// Token: 0x040007B8 RID: 1976
		ZWriteEnable = 14,
		// Token: 0x040007B9 RID: 1977
		AlphaTestEnable,
		// Token: 0x040007BA RID: 1978
		LastPixel,
		// Token: 0x040007BB RID: 1979
		SourceBlend = 19,
		// Token: 0x040007BC RID: 1980
		DestinationBlend,
		// Token: 0x040007BD RID: 1981
		CullMode = 22,
		// Token: 0x040007BE RID: 1982
		ZFunc,
		// Token: 0x040007BF RID: 1983
		AlphaRef,
		// Token: 0x040007C0 RID: 1984
		AlphaFunc,
		// Token: 0x040007C1 RID: 1985
		DitherEnable,
		// Token: 0x040007C2 RID: 1986
		AlphaBlendEnable,
		// Token: 0x040007C3 RID: 1987
		FogEnable,
		// Token: 0x040007C4 RID: 1988
		SpecularEnable,
		// Token: 0x040007C5 RID: 1989
		FogColor = 34,
		// Token: 0x040007C6 RID: 1990
		FogTableMode,
		// Token: 0x040007C7 RID: 1991
		FogStart,
		// Token: 0x040007C8 RID: 1992
		FogEnd,
		// Token: 0x040007C9 RID: 1993
		FogDensity,
		// Token: 0x040007CA RID: 1994
		RangeFogEnable = 48,
		// Token: 0x040007CB RID: 1995
		StencilEnable = 52,
		// Token: 0x040007CC RID: 1996
		StencilFail,
		// Token: 0x040007CD RID: 1997
		StencilZFail,
		// Token: 0x040007CE RID: 1998
		StencilPass,
		// Token: 0x040007CF RID: 1999
		StencilFunc,
		// Token: 0x040007D0 RID: 2000
		StencilRef,
		// Token: 0x040007D1 RID: 2001
		StencilMask,
		// Token: 0x040007D2 RID: 2002
		StencilWriteMask,
		// Token: 0x040007D3 RID: 2003
		TextureFactor,
		// Token: 0x040007D4 RID: 2004
		Wrap0 = 128,
		// Token: 0x040007D5 RID: 2005
		Wrap1,
		// Token: 0x040007D6 RID: 2006
		Wrap2,
		// Token: 0x040007D7 RID: 2007
		Wrap3,
		// Token: 0x040007D8 RID: 2008
		Wrap4,
		// Token: 0x040007D9 RID: 2009
		Wrap5,
		// Token: 0x040007DA RID: 2010
		Wrap6,
		// Token: 0x040007DB RID: 2011
		Wrap7,
		// Token: 0x040007DC RID: 2012
		Clipping,
		// Token: 0x040007DD RID: 2013
		Lighting,
		// Token: 0x040007DE RID: 2014
		Ambient = 139,
		// Token: 0x040007DF RID: 2015
		FogVertexMode,
		// Token: 0x040007E0 RID: 2016
		ColorVertex,
		// Token: 0x040007E1 RID: 2017
		LocalViewer,
		// Token: 0x040007E2 RID: 2018
		NormalizeNormals,
		// Token: 0x040007E3 RID: 2019
		DiffuseMaterialSource = 145,
		// Token: 0x040007E4 RID: 2020
		SpecularMaterialSource,
		// Token: 0x040007E5 RID: 2021
		AmbientMaterialSource,
		// Token: 0x040007E6 RID: 2022
		EmissiveMaterialSource,
		// Token: 0x040007E7 RID: 2023
		VertexBlend = 151,
		// Token: 0x040007E8 RID: 2024
		ClipPlaneEnable,
		// Token: 0x040007E9 RID: 2025
		PointSize = 154,
		// Token: 0x040007EA RID: 2026
		PointSizeMin,
		// Token: 0x040007EB RID: 2027
		PointSpriteEnable,
		// Token: 0x040007EC RID: 2028
		PointScaleEnable,
		// Token: 0x040007ED RID: 2029
		PointScaleA,
		// Token: 0x040007EE RID: 2030
		PointScaleB,
		// Token: 0x040007EF RID: 2031
		PointScaleC,
		// Token: 0x040007F0 RID: 2032
		MultisampleAntialias,
		// Token: 0x040007F1 RID: 2033
		MultisampleMask,
		// Token: 0x040007F2 RID: 2034
		PatchEdgeStyle,
		// Token: 0x040007F3 RID: 2035
		DebugMonitorToken = 165,
		// Token: 0x040007F4 RID: 2036
		PointSizeMax,
		// Token: 0x040007F5 RID: 2037
		IndexedVertexBlendEnable,
		// Token: 0x040007F6 RID: 2038
		ColorWriteEnable,
		// Token: 0x040007F7 RID: 2039
		TweenFactor = 170,
		// Token: 0x040007F8 RID: 2040
		BlendOperation,
		// Token: 0x040007F9 RID: 2041
		PositionDegree,
		// Token: 0x040007FA RID: 2042
		NormalDegree,
		// Token: 0x040007FB RID: 2043
		ScissorTestEnable,
		// Token: 0x040007FC RID: 2044
		SlopeScaleDepthBias,
		// Token: 0x040007FD RID: 2045
		AntialiasedLineEnable,
		// Token: 0x040007FE RID: 2046
		MinTessellationLevel = 178,
		// Token: 0x040007FF RID: 2047
		MaxTessellationLevel,
		// Token: 0x04000800 RID: 2048
		AdaptiveTessX,
		// Token: 0x04000801 RID: 2049
		AdaptiveTessY,
		// Token: 0x04000802 RID: 2050
		AdaptiveTessZ,
		// Token: 0x04000803 RID: 2051
		AdaptiveTessW,
		// Token: 0x04000804 RID: 2052
		EnableAdaptiveTessellation,
		// Token: 0x04000805 RID: 2053
		TwoSidedStencilMode,
		// Token: 0x04000806 RID: 2054
		CcwStencilFail,
		// Token: 0x04000807 RID: 2055
		CcwStencilZFail,
		// Token: 0x04000808 RID: 2056
		CcwStencilPass,
		// Token: 0x04000809 RID: 2057
		CcwStencilFunc,
		// Token: 0x0400080A RID: 2058
		ColorWriteEnable1,
		// Token: 0x0400080B RID: 2059
		ColorWriteEnable2,
		// Token: 0x0400080C RID: 2060
		ColorWriteEnable3,
		// Token: 0x0400080D RID: 2061
		BlendFactor,
		// Token: 0x0400080E RID: 2062
		SrgbWriteEnable,
		// Token: 0x0400080F RID: 2063
		DepthBias,
		// Token: 0x04000810 RID: 2064
		Wrap8 = 198,
		// Token: 0x04000811 RID: 2065
		Wrap9,
		// Token: 0x04000812 RID: 2066
		Wrap10,
		// Token: 0x04000813 RID: 2067
		Wrap11,
		// Token: 0x04000814 RID: 2068
		Wrap12,
		// Token: 0x04000815 RID: 2069
		Wrap13,
		// Token: 0x04000816 RID: 2070
		Wrap14,
		// Token: 0x04000817 RID: 2071
		Wrap15,
		// Token: 0x04000818 RID: 2072
		SeparateAlphaBlendEnable,
		// Token: 0x04000819 RID: 2073
		SourceBlendAlpha,
		// Token: 0x0400081A RID: 2074
		DestinationBlendAlpha,
		// Token: 0x0400081B RID: 2075
		BlendOperationAlpha
	}
}
