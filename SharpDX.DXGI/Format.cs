using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000039 RID: 57
	public enum Format
	{
		// Token: 0x0400008A RID: 138
		Unknown,
		// Token: 0x0400008B RID: 139
		R32G32B32A32_Typeless,
		// Token: 0x0400008C RID: 140
		R32G32B32A32_Float,
		// Token: 0x0400008D RID: 141
		R32G32B32A32_UInt,
		// Token: 0x0400008E RID: 142
		R32G32B32A32_SInt,
		// Token: 0x0400008F RID: 143
		R32G32B32_Typeless,
		// Token: 0x04000090 RID: 144
		R32G32B32_Float,
		// Token: 0x04000091 RID: 145
		R32G32B32_UInt,
		// Token: 0x04000092 RID: 146
		R32G32B32_SInt,
		// Token: 0x04000093 RID: 147
		R16G16B16A16_Typeless,
		// Token: 0x04000094 RID: 148
		R16G16B16A16_Float,
		// Token: 0x04000095 RID: 149
		R16G16B16A16_UNorm,
		// Token: 0x04000096 RID: 150
		R16G16B16A16_UInt,
		// Token: 0x04000097 RID: 151
		R16G16B16A16_SNorm,
		// Token: 0x04000098 RID: 152
		R16G16B16A16_SInt,
		// Token: 0x04000099 RID: 153
		R32G32_Typeless,
		// Token: 0x0400009A RID: 154
		R32G32_Float,
		// Token: 0x0400009B RID: 155
		R32G32_UInt,
		// Token: 0x0400009C RID: 156
		R32G32_SInt,
		// Token: 0x0400009D RID: 157
		R32G8X24_Typeless,
		// Token: 0x0400009E RID: 158
		D32_Float_S8X24_UInt,
		// Token: 0x0400009F RID: 159
		R32_Float_X8X24_Typeless,
		// Token: 0x040000A0 RID: 160
		X32_Typeless_G8X24_UInt,
		// Token: 0x040000A1 RID: 161
		R10G10B10A2_Typeless,
		// Token: 0x040000A2 RID: 162
		R10G10B10A2_UNorm,
		// Token: 0x040000A3 RID: 163
		R10G10B10A2_UInt,
		// Token: 0x040000A4 RID: 164
		R11G11B10_Float,
		// Token: 0x040000A5 RID: 165
		R8G8B8A8_Typeless,
		// Token: 0x040000A6 RID: 166
		R8G8B8A8_UNorm,
		// Token: 0x040000A7 RID: 167
		R8G8B8A8_UNorm_SRgb,
		// Token: 0x040000A8 RID: 168
		R8G8B8A8_UInt,
		// Token: 0x040000A9 RID: 169
		R8G8B8A8_SNorm,
		// Token: 0x040000AA RID: 170
		R8G8B8A8_SInt,
		// Token: 0x040000AB RID: 171
		R16G16_Typeless,
		// Token: 0x040000AC RID: 172
		R16G16_Float,
		// Token: 0x040000AD RID: 173
		R16G16_UNorm,
		// Token: 0x040000AE RID: 174
		R16G16_UInt,
		// Token: 0x040000AF RID: 175
		R16G16_SNorm,
		// Token: 0x040000B0 RID: 176
		R16G16_SInt,
		// Token: 0x040000B1 RID: 177
		R32_Typeless,
		// Token: 0x040000B2 RID: 178
		D32_Float,
		// Token: 0x040000B3 RID: 179
		R32_Float,
		// Token: 0x040000B4 RID: 180
		R32_UInt,
		// Token: 0x040000B5 RID: 181
		R32_SInt,
		// Token: 0x040000B6 RID: 182
		R24G8_Typeless,
		// Token: 0x040000B7 RID: 183
		D24_UNorm_S8_UInt,
		// Token: 0x040000B8 RID: 184
		R24_UNorm_X8_Typeless,
		// Token: 0x040000B9 RID: 185
		X24_Typeless_G8_UInt,
		// Token: 0x040000BA RID: 186
		R8G8_Typeless,
		// Token: 0x040000BB RID: 187
		R8G8_UNorm,
		// Token: 0x040000BC RID: 188
		R8G8_UInt,
		// Token: 0x040000BD RID: 189
		R8G8_SNorm,
		// Token: 0x040000BE RID: 190
		R8G8_SInt,
		// Token: 0x040000BF RID: 191
		R16_Typeless,
		// Token: 0x040000C0 RID: 192
		R16_Float,
		// Token: 0x040000C1 RID: 193
		D16_UNorm,
		// Token: 0x040000C2 RID: 194
		R16_UNorm,
		// Token: 0x040000C3 RID: 195
		R16_UInt,
		// Token: 0x040000C4 RID: 196
		R16_SNorm,
		// Token: 0x040000C5 RID: 197
		R16_SInt,
		// Token: 0x040000C6 RID: 198
		R8_Typeless,
		// Token: 0x040000C7 RID: 199
		R8_UNorm,
		// Token: 0x040000C8 RID: 200
		R8_UInt,
		// Token: 0x040000C9 RID: 201
		R8_SNorm,
		// Token: 0x040000CA RID: 202
		R8_SInt,
		// Token: 0x040000CB RID: 203
		A8_UNorm,
		// Token: 0x040000CC RID: 204
		R1_UNorm,
		// Token: 0x040000CD RID: 205
		R9G9B9E5_Sharedexp,
		// Token: 0x040000CE RID: 206
		R8G8_B8G8_UNorm,
		// Token: 0x040000CF RID: 207
		G8R8_G8B8_UNorm,
		// Token: 0x040000D0 RID: 208
		BC1_Typeless,
		// Token: 0x040000D1 RID: 209
		BC1_UNorm,
		// Token: 0x040000D2 RID: 210
		BC1_UNorm_SRgb,
		// Token: 0x040000D3 RID: 211
		BC2_Typeless,
		// Token: 0x040000D4 RID: 212
		BC2_UNorm,
		// Token: 0x040000D5 RID: 213
		BC2_UNorm_SRgb,
		// Token: 0x040000D6 RID: 214
		BC3_Typeless,
		// Token: 0x040000D7 RID: 215
		BC3_UNorm,
		// Token: 0x040000D8 RID: 216
		BC3_UNorm_SRgb,
		// Token: 0x040000D9 RID: 217
		BC4_Typeless,
		// Token: 0x040000DA RID: 218
		BC4_UNorm,
		// Token: 0x040000DB RID: 219
		BC4_SNorm,
		// Token: 0x040000DC RID: 220
		BC5_Typeless,
		// Token: 0x040000DD RID: 221
		BC5_UNorm,
		// Token: 0x040000DE RID: 222
		BC5_SNorm,
		// Token: 0x040000DF RID: 223
		B5G6R5_UNorm,
		// Token: 0x040000E0 RID: 224
		B5G5R5A1_UNorm,
		// Token: 0x040000E1 RID: 225
		B8G8R8A8_UNorm,
		// Token: 0x040000E2 RID: 226
		B8G8R8X8_UNorm,
		// Token: 0x040000E3 RID: 227
		R10G10B10_Xr_Bias_A2_UNorm,
		// Token: 0x040000E4 RID: 228
		B8G8R8A8_Typeless,
		// Token: 0x040000E5 RID: 229
		B8G8R8A8_UNorm_SRgb,
		// Token: 0x040000E6 RID: 230
		B8G8R8X8_Typeless,
		// Token: 0x040000E7 RID: 231
		B8G8R8X8_UNorm_SRgb,
		// Token: 0x040000E8 RID: 232
		BC6H_Typeless,
		// Token: 0x040000E9 RID: 233
		BC6H_Uf16,
		// Token: 0x040000EA RID: 234
		BC6H_Sf16,
		// Token: 0x040000EB RID: 235
		BC7_Typeless,
		// Token: 0x040000EC RID: 236
		BC7_UNorm,
		// Token: 0x040000ED RID: 237
		BC7_UNorm_SRgb,
		// Token: 0x040000EE RID: 238
		AYUV,
		// Token: 0x040000EF RID: 239
		Y410,
		// Token: 0x040000F0 RID: 240
		Y416,
		// Token: 0x040000F1 RID: 241
		NV12,
		// Token: 0x040000F2 RID: 242
		P010,
		// Token: 0x040000F3 RID: 243
		P016,
		// Token: 0x040000F4 RID: 244
		Opaque420,
		// Token: 0x040000F5 RID: 245
		YUY2,
		// Token: 0x040000F6 RID: 246
		Y210,
		// Token: 0x040000F7 RID: 247
		Y216,
		// Token: 0x040000F8 RID: 248
		NV11,
		// Token: 0x040000F9 RID: 249
		AI44,
		// Token: 0x040000FA RID: 250
		IA44,
		// Token: 0x040000FB RID: 251
		P8,
		// Token: 0x040000FC RID: 252
		A8P8,
		// Token: 0x040000FD RID: 253
		B4G4R4A4_UNorm,
		// Token: 0x040000FE RID: 254
		P208 = 130,
		// Token: 0x040000FF RID: 255
		V208,
		// Token: 0x04000100 RID: 256
		V408
	}
}
