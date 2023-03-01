using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000011 RID: 17
	public struct Capabilities
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00003DFC File Offset: 0x00001FFC
		public Version PixelShaderVersion
		{
			get
			{
				return new Version(this.PixelShaderVersion_ >> 8 & 255, this.PixelShaderVersion_ & 255);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003E1D File Offset: 0x0000201D
		public Version VertexShaderVersion
		{
			get
			{
				return new Version(this.VertexShaderVersion_ >> 8 & 255, this.VertexShaderVersion_ & 255);
			}
		}

		// Token: 0x04000461 RID: 1121
		public DeviceType DeviceType;

		// Token: 0x04000462 RID: 1122
		public int AdapterOrdinal;

		// Token: 0x04000463 RID: 1123
		public Caps Caps;

		// Token: 0x04000464 RID: 1124
		public Caps2 Caps2;

		// Token: 0x04000465 RID: 1125
		public Caps3 Caps3;

		// Token: 0x04000466 RID: 1126
		public PresentInterval PresentationIntervals;

		// Token: 0x04000467 RID: 1127
		public CursorCaps CursorCaps;

		// Token: 0x04000468 RID: 1128
		public DeviceCaps DeviceCaps;

		// Token: 0x04000469 RID: 1129
		public PrimitiveMiscCaps PrimitiveMiscCaps;

		// Token: 0x0400046A RID: 1130
		public RasterCaps RasterCaps;

		// Token: 0x0400046B RID: 1131
		public CompareCaps DepthCompareCaps;

		// Token: 0x0400046C RID: 1132
		public BlendCaps SourceBlendCaps;

		// Token: 0x0400046D RID: 1133
		public BlendCaps DestinationBlendCaps;

		// Token: 0x0400046E RID: 1134
		public CompareCaps AlpaCompareCaps;

		// Token: 0x0400046F RID: 1135
		public ShadeCaps ShadeCaps;

		// Token: 0x04000470 RID: 1136
		public TextureCaps TextureCaps;

		// Token: 0x04000471 RID: 1137
		public FilterCaps TextureFilterCaps;

		// Token: 0x04000472 RID: 1138
		public FilterCaps CubeTextureFilterCaps;

		// Token: 0x04000473 RID: 1139
		public FilterCaps VolumeTextureFilterCaps;

		// Token: 0x04000474 RID: 1140
		public TextureAddressCaps TextureAddressCaps;

		// Token: 0x04000475 RID: 1141
		public TextureAddressCaps VolumeTextureAddressCaps;

		// Token: 0x04000476 RID: 1142
		public LineCaps LineCaps;

		// Token: 0x04000477 RID: 1143
		public int MaxTextureWidth;

		// Token: 0x04000478 RID: 1144
		public int MaxTextureHeight;

		// Token: 0x04000479 RID: 1145
		public int MaxVolumeExtent;

		// Token: 0x0400047A RID: 1146
		public int MaxTextureRepeat;

		// Token: 0x0400047B RID: 1147
		public int MaxTextureAspectRatio;

		// Token: 0x0400047C RID: 1148
		public int MaxAnisotropy;

		// Token: 0x0400047D RID: 1149
		public float MaxVertexW;

		// Token: 0x0400047E RID: 1150
		public float GuardBandLeft;

		// Token: 0x0400047F RID: 1151
		public float GuardBandTop;

		// Token: 0x04000480 RID: 1152
		public float GuardBandRight;

		// Token: 0x04000481 RID: 1153
		public float GuardBandBottom;

		// Token: 0x04000482 RID: 1154
		public float ExtentsAdjust;

		// Token: 0x04000483 RID: 1155
		public StencilCaps StencilCaps;

		// Token: 0x04000484 RID: 1156
		public VertexFormatCaps FVFCaps;

		// Token: 0x04000485 RID: 1157
		public TextureOperationCaps TextureOperationCaps;

		// Token: 0x04000486 RID: 1158
		public int MaxTextureBlendStages;

		// Token: 0x04000487 RID: 1159
		public int MaxSimultaneousTextures;

		// Token: 0x04000488 RID: 1160
		public VertexProcessingCaps VertexProcessingCaps;

		// Token: 0x04000489 RID: 1161
		public int MaxActiveLights;

		// Token: 0x0400048A RID: 1162
		public int MaxUserClipPlanes;

		// Token: 0x0400048B RID: 1163
		public int MaxVertexBlendMatrices;

		// Token: 0x0400048C RID: 1164
		public int MaxVertexBlendMatrixIndex;

		// Token: 0x0400048D RID: 1165
		public float MaxPointSize;

		// Token: 0x0400048E RID: 1166
		public int MaxPrimitiveCount;

		// Token: 0x0400048F RID: 1167
		public int MaxVertexIndex;

		// Token: 0x04000490 RID: 1168
		public int MaxStreams;

		// Token: 0x04000491 RID: 1169
		public int MaxStreamStride;

		// Token: 0x04000492 RID: 1170
		internal int VertexShaderVersion_;

		// Token: 0x04000493 RID: 1171
		public int MaxVertexShaderConst;

		// Token: 0x04000494 RID: 1172
		internal int PixelShaderVersion_;

		// Token: 0x04000495 RID: 1173
		public float PixelShader1xMaxValue;

		// Token: 0x04000496 RID: 1174
		public DeviceCaps2 DeviceCaps2;

		// Token: 0x04000497 RID: 1175
		public float MaxNpatchTessellationLevel;

		// Token: 0x04000498 RID: 1176
		internal int Reserved5;

		// Token: 0x04000499 RID: 1177
		public int MasterAdapterOrdinal;

		// Token: 0x0400049A RID: 1178
		public int AdapterOrdinalInGroup;

		// Token: 0x0400049B RID: 1179
		public int NumberOfAdaptersInGroup;

		// Token: 0x0400049C RID: 1180
		public DeclarationTypeCaps DeclarationTypes;

		// Token: 0x0400049D RID: 1181
		public int SimultaneousRTCount;

		// Token: 0x0400049E RID: 1182
		public FilterCaps StretchRectFilterCaps;

		// Token: 0x0400049F RID: 1183
		public VertexShader20Caps VS20Caps;

		// Token: 0x040004A0 RID: 1184
		public PixelShader20Caps PS20Caps;

		// Token: 0x040004A1 RID: 1185
		public FilterCaps VertexTextureFilterCaps;

		// Token: 0x040004A2 RID: 1186
		public int MaxVShaderInstructionsExecuted;

		// Token: 0x040004A3 RID: 1187
		public int MaxPShaderInstructionsExecuted;

		// Token: 0x040004A4 RID: 1188
		public int MaxVertexShader30InstructionSlots;

		// Token: 0x040004A5 RID: 1189
		public int MaxPixelShader30InstructionSlots;
	}
}
