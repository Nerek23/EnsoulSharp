using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200007F RID: 127
	public struct GammaControlCapabilities
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00007FD4 File Offset: 0x000061D4
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00007FFE File Offset: 0x000061FE
		public float[] ControlPoints
		{
			get
			{
				float[] result;
				if ((result = this._ControlPoints) == null)
				{
					result = (this._ControlPoints = new float[1025]);
				}
				return result;
			}
			private set
			{
				this._ControlPoints = value;
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref GammaControlCapabilities.__Native @ref)
		{
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00008008 File Offset: 0x00006208
		internal unsafe void __MarshalFrom(ref GammaControlCapabilities.__Native @ref)
		{
			this.IsScaleAndOffsetSupported = @ref.IsScaleAndOffsetSupported;
			this.MaximumConvertedValue = @ref.MaximumConvertedValue;
			this.MinimumConvertedValue = @ref.MinimumConvertedValue;
			this.ControlPointsCount = @ref.ControlPointsCount;
			fixed (float* ptr = &this.ControlPoints[0])
			{
				void* value = (void*)ptr;
				fixed (float* ptr2 = &@ref.ControlPoints)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 4100);
					ptr = null;
				}
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000807C File Offset: 0x0000627C
		internal unsafe void __MarshalTo(ref GammaControlCapabilities.__Native @ref)
		{
			@ref.IsScaleAndOffsetSupported = this.IsScaleAndOffsetSupported;
			@ref.MaximumConvertedValue = this.MaximumConvertedValue;
			@ref.MinimumConvertedValue = this.MinimumConvertedValue;
			@ref.ControlPointsCount = this.ControlPointsCount;
			fixed (float* ptr = &this.ControlPoints[0])
			{
				void* value = (void*)ptr;
				fixed (float* ptr2 = &@ref.ControlPoints)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 4100);
					ptr = null;
				}
			}
		}

		// Token: 0x04000813 RID: 2067
		public RawBool IsScaleAndOffsetSupported;

		// Token: 0x04000814 RID: 2068
		public float MaximumConvertedValue;

		// Token: 0x04000815 RID: 2069
		public float MinimumConvertedValue;

		// Token: 0x04000816 RID: 2070
		public int ControlPointsCount;

		// Token: 0x04000817 RID: 2071
		internal float[] _ControlPoints;

		// Token: 0x02000080 RID: 128
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000818 RID: 2072
			public RawBool IsScaleAndOffsetSupported;

			// Token: 0x04000819 RID: 2073
			public float MaximumConvertedValue;

			// Token: 0x0400081A RID: 2074
			public float MinimumConvertedValue;

			// Token: 0x0400081B RID: 2075
			public int ControlPointsCount;

			// Token: 0x0400081C RID: 2076
			public float ControlPoints;

			// Token: 0x0400081D RID: 2077
			public float __ControlPoints1;

			// Token: 0x0400081E RID: 2078
			public float __ControlPoints2;

			// Token: 0x0400081F RID: 2079
			public float __ControlPoints3;

			// Token: 0x04000820 RID: 2080
			public float __ControlPoints4;

			// Token: 0x04000821 RID: 2081
			public float __ControlPoints5;

			// Token: 0x04000822 RID: 2082
			public float __ControlPoints6;

			// Token: 0x04000823 RID: 2083
			public float __ControlPoints7;

			// Token: 0x04000824 RID: 2084
			public float __ControlPoints8;

			// Token: 0x04000825 RID: 2085
			public float __ControlPoints9;

			// Token: 0x04000826 RID: 2086
			public float __ControlPoints10;

			// Token: 0x04000827 RID: 2087
			public float __ControlPoints11;

			// Token: 0x04000828 RID: 2088
			public float __ControlPoints12;

			// Token: 0x04000829 RID: 2089
			public float __ControlPoints13;

			// Token: 0x0400082A RID: 2090
			public float __ControlPoints14;

			// Token: 0x0400082B RID: 2091
			public float __ControlPoints15;

			// Token: 0x0400082C RID: 2092
			public float __ControlPoints16;

			// Token: 0x0400082D RID: 2093
			public float __ControlPoints17;

			// Token: 0x0400082E RID: 2094
			public float __ControlPoints18;

			// Token: 0x0400082F RID: 2095
			public float __ControlPoints19;

			// Token: 0x04000830 RID: 2096
			public float __ControlPoints20;

			// Token: 0x04000831 RID: 2097
			public float __ControlPoints21;

			// Token: 0x04000832 RID: 2098
			public float __ControlPoints22;

			// Token: 0x04000833 RID: 2099
			public float __ControlPoints23;

			// Token: 0x04000834 RID: 2100
			public float __ControlPoints24;

			// Token: 0x04000835 RID: 2101
			public float __ControlPoints25;

			// Token: 0x04000836 RID: 2102
			public float __ControlPoints26;

			// Token: 0x04000837 RID: 2103
			public float __ControlPoints27;

			// Token: 0x04000838 RID: 2104
			public float __ControlPoints28;

			// Token: 0x04000839 RID: 2105
			public float __ControlPoints29;

			// Token: 0x0400083A RID: 2106
			public float __ControlPoints30;

			// Token: 0x0400083B RID: 2107
			public float __ControlPoints31;

			// Token: 0x0400083C RID: 2108
			public float __ControlPoints32;

			// Token: 0x0400083D RID: 2109
			public float __ControlPoints33;

			// Token: 0x0400083E RID: 2110
			public float __ControlPoints34;

			// Token: 0x0400083F RID: 2111
			public float __ControlPoints35;

			// Token: 0x04000840 RID: 2112
			public float __ControlPoints36;

			// Token: 0x04000841 RID: 2113
			public float __ControlPoints37;

			// Token: 0x04000842 RID: 2114
			public float __ControlPoints38;

			// Token: 0x04000843 RID: 2115
			public float __ControlPoints39;

			// Token: 0x04000844 RID: 2116
			public float __ControlPoints40;

			// Token: 0x04000845 RID: 2117
			public float __ControlPoints41;

			// Token: 0x04000846 RID: 2118
			public float __ControlPoints42;

			// Token: 0x04000847 RID: 2119
			public float __ControlPoints43;

			// Token: 0x04000848 RID: 2120
			public float __ControlPoints44;

			// Token: 0x04000849 RID: 2121
			public float __ControlPoints45;

			// Token: 0x0400084A RID: 2122
			public float __ControlPoints46;

			// Token: 0x0400084B RID: 2123
			public float __ControlPoints47;

			// Token: 0x0400084C RID: 2124
			public float __ControlPoints48;

			// Token: 0x0400084D RID: 2125
			public float __ControlPoints49;

			// Token: 0x0400084E RID: 2126
			public float __ControlPoints50;

			// Token: 0x0400084F RID: 2127
			public float __ControlPoints51;

			// Token: 0x04000850 RID: 2128
			public float __ControlPoints52;

			// Token: 0x04000851 RID: 2129
			public float __ControlPoints53;

			// Token: 0x04000852 RID: 2130
			public float __ControlPoints54;

			// Token: 0x04000853 RID: 2131
			public float __ControlPoints55;

			// Token: 0x04000854 RID: 2132
			public float __ControlPoints56;

			// Token: 0x04000855 RID: 2133
			public float __ControlPoints57;

			// Token: 0x04000856 RID: 2134
			public float __ControlPoints58;

			// Token: 0x04000857 RID: 2135
			public float __ControlPoints59;

			// Token: 0x04000858 RID: 2136
			public float __ControlPoints60;

			// Token: 0x04000859 RID: 2137
			public float __ControlPoints61;

			// Token: 0x0400085A RID: 2138
			public float __ControlPoints62;

			// Token: 0x0400085B RID: 2139
			public float __ControlPoints63;

			// Token: 0x0400085C RID: 2140
			public float __ControlPoints64;

			// Token: 0x0400085D RID: 2141
			public float __ControlPoints65;

			// Token: 0x0400085E RID: 2142
			public float __ControlPoints66;

			// Token: 0x0400085F RID: 2143
			public float __ControlPoints67;

			// Token: 0x04000860 RID: 2144
			public float __ControlPoints68;

			// Token: 0x04000861 RID: 2145
			public float __ControlPoints69;

			// Token: 0x04000862 RID: 2146
			public float __ControlPoints70;

			// Token: 0x04000863 RID: 2147
			public float __ControlPoints71;

			// Token: 0x04000864 RID: 2148
			public float __ControlPoints72;

			// Token: 0x04000865 RID: 2149
			public float __ControlPoints73;

			// Token: 0x04000866 RID: 2150
			public float __ControlPoints74;

			// Token: 0x04000867 RID: 2151
			public float __ControlPoints75;

			// Token: 0x04000868 RID: 2152
			public float __ControlPoints76;

			// Token: 0x04000869 RID: 2153
			public float __ControlPoints77;

			// Token: 0x0400086A RID: 2154
			public float __ControlPoints78;

			// Token: 0x0400086B RID: 2155
			public float __ControlPoints79;

			// Token: 0x0400086C RID: 2156
			public float __ControlPoints80;

			// Token: 0x0400086D RID: 2157
			public float __ControlPoints81;

			// Token: 0x0400086E RID: 2158
			public float __ControlPoints82;

			// Token: 0x0400086F RID: 2159
			public float __ControlPoints83;

			// Token: 0x04000870 RID: 2160
			public float __ControlPoints84;

			// Token: 0x04000871 RID: 2161
			public float __ControlPoints85;

			// Token: 0x04000872 RID: 2162
			public float __ControlPoints86;

			// Token: 0x04000873 RID: 2163
			public float __ControlPoints87;

			// Token: 0x04000874 RID: 2164
			public float __ControlPoints88;

			// Token: 0x04000875 RID: 2165
			public float __ControlPoints89;

			// Token: 0x04000876 RID: 2166
			public float __ControlPoints90;

			// Token: 0x04000877 RID: 2167
			public float __ControlPoints91;

			// Token: 0x04000878 RID: 2168
			public float __ControlPoints92;

			// Token: 0x04000879 RID: 2169
			public float __ControlPoints93;

			// Token: 0x0400087A RID: 2170
			public float __ControlPoints94;

			// Token: 0x0400087B RID: 2171
			public float __ControlPoints95;

			// Token: 0x0400087C RID: 2172
			public float __ControlPoints96;

			// Token: 0x0400087D RID: 2173
			public float __ControlPoints97;

			// Token: 0x0400087E RID: 2174
			public float __ControlPoints98;

			// Token: 0x0400087F RID: 2175
			public float __ControlPoints99;

			// Token: 0x04000880 RID: 2176
			public float __ControlPoints100;

			// Token: 0x04000881 RID: 2177
			public float __ControlPoints101;

			// Token: 0x04000882 RID: 2178
			public float __ControlPoints102;

			// Token: 0x04000883 RID: 2179
			public float __ControlPoints103;

			// Token: 0x04000884 RID: 2180
			public float __ControlPoints104;

			// Token: 0x04000885 RID: 2181
			public float __ControlPoints105;

			// Token: 0x04000886 RID: 2182
			public float __ControlPoints106;

			// Token: 0x04000887 RID: 2183
			public float __ControlPoints107;

			// Token: 0x04000888 RID: 2184
			public float __ControlPoints108;

			// Token: 0x04000889 RID: 2185
			public float __ControlPoints109;

			// Token: 0x0400088A RID: 2186
			public float __ControlPoints110;

			// Token: 0x0400088B RID: 2187
			public float __ControlPoints111;

			// Token: 0x0400088C RID: 2188
			public float __ControlPoints112;

			// Token: 0x0400088D RID: 2189
			public float __ControlPoints113;

			// Token: 0x0400088E RID: 2190
			public float __ControlPoints114;

			// Token: 0x0400088F RID: 2191
			public float __ControlPoints115;

			// Token: 0x04000890 RID: 2192
			public float __ControlPoints116;

			// Token: 0x04000891 RID: 2193
			public float __ControlPoints117;

			// Token: 0x04000892 RID: 2194
			public float __ControlPoints118;

			// Token: 0x04000893 RID: 2195
			public float __ControlPoints119;

			// Token: 0x04000894 RID: 2196
			public float __ControlPoints120;

			// Token: 0x04000895 RID: 2197
			public float __ControlPoints121;

			// Token: 0x04000896 RID: 2198
			public float __ControlPoints122;

			// Token: 0x04000897 RID: 2199
			public float __ControlPoints123;

			// Token: 0x04000898 RID: 2200
			public float __ControlPoints124;

			// Token: 0x04000899 RID: 2201
			public float __ControlPoints125;

			// Token: 0x0400089A RID: 2202
			public float __ControlPoints126;

			// Token: 0x0400089B RID: 2203
			public float __ControlPoints127;

			// Token: 0x0400089C RID: 2204
			public float __ControlPoints128;

			// Token: 0x0400089D RID: 2205
			public float __ControlPoints129;

			// Token: 0x0400089E RID: 2206
			public float __ControlPoints130;

			// Token: 0x0400089F RID: 2207
			public float __ControlPoints131;

			// Token: 0x040008A0 RID: 2208
			public float __ControlPoints132;

			// Token: 0x040008A1 RID: 2209
			public float __ControlPoints133;

			// Token: 0x040008A2 RID: 2210
			public float __ControlPoints134;

			// Token: 0x040008A3 RID: 2211
			public float __ControlPoints135;

			// Token: 0x040008A4 RID: 2212
			public float __ControlPoints136;

			// Token: 0x040008A5 RID: 2213
			public float __ControlPoints137;

			// Token: 0x040008A6 RID: 2214
			public float __ControlPoints138;

			// Token: 0x040008A7 RID: 2215
			public float __ControlPoints139;

			// Token: 0x040008A8 RID: 2216
			public float __ControlPoints140;

			// Token: 0x040008A9 RID: 2217
			public float __ControlPoints141;

			// Token: 0x040008AA RID: 2218
			public float __ControlPoints142;

			// Token: 0x040008AB RID: 2219
			public float __ControlPoints143;

			// Token: 0x040008AC RID: 2220
			public float __ControlPoints144;

			// Token: 0x040008AD RID: 2221
			public float __ControlPoints145;

			// Token: 0x040008AE RID: 2222
			public float __ControlPoints146;

			// Token: 0x040008AF RID: 2223
			public float __ControlPoints147;

			// Token: 0x040008B0 RID: 2224
			public float __ControlPoints148;

			// Token: 0x040008B1 RID: 2225
			public float __ControlPoints149;

			// Token: 0x040008B2 RID: 2226
			public float __ControlPoints150;

			// Token: 0x040008B3 RID: 2227
			public float __ControlPoints151;

			// Token: 0x040008B4 RID: 2228
			public float __ControlPoints152;

			// Token: 0x040008B5 RID: 2229
			public float __ControlPoints153;

			// Token: 0x040008B6 RID: 2230
			public float __ControlPoints154;

			// Token: 0x040008B7 RID: 2231
			public float __ControlPoints155;

			// Token: 0x040008B8 RID: 2232
			public float __ControlPoints156;

			// Token: 0x040008B9 RID: 2233
			public float __ControlPoints157;

			// Token: 0x040008BA RID: 2234
			public float __ControlPoints158;

			// Token: 0x040008BB RID: 2235
			public float __ControlPoints159;

			// Token: 0x040008BC RID: 2236
			public float __ControlPoints160;

			// Token: 0x040008BD RID: 2237
			public float __ControlPoints161;

			// Token: 0x040008BE RID: 2238
			public float __ControlPoints162;

			// Token: 0x040008BF RID: 2239
			public float __ControlPoints163;

			// Token: 0x040008C0 RID: 2240
			public float __ControlPoints164;

			// Token: 0x040008C1 RID: 2241
			public float __ControlPoints165;

			// Token: 0x040008C2 RID: 2242
			public float __ControlPoints166;

			// Token: 0x040008C3 RID: 2243
			public float __ControlPoints167;

			// Token: 0x040008C4 RID: 2244
			public float __ControlPoints168;

			// Token: 0x040008C5 RID: 2245
			public float __ControlPoints169;

			// Token: 0x040008C6 RID: 2246
			public float __ControlPoints170;

			// Token: 0x040008C7 RID: 2247
			public float __ControlPoints171;

			// Token: 0x040008C8 RID: 2248
			public float __ControlPoints172;

			// Token: 0x040008C9 RID: 2249
			public float __ControlPoints173;

			// Token: 0x040008CA RID: 2250
			public float __ControlPoints174;

			// Token: 0x040008CB RID: 2251
			public float __ControlPoints175;

			// Token: 0x040008CC RID: 2252
			public float __ControlPoints176;

			// Token: 0x040008CD RID: 2253
			public float __ControlPoints177;

			// Token: 0x040008CE RID: 2254
			public float __ControlPoints178;

			// Token: 0x040008CF RID: 2255
			public float __ControlPoints179;

			// Token: 0x040008D0 RID: 2256
			public float __ControlPoints180;

			// Token: 0x040008D1 RID: 2257
			public float __ControlPoints181;

			// Token: 0x040008D2 RID: 2258
			public float __ControlPoints182;

			// Token: 0x040008D3 RID: 2259
			public float __ControlPoints183;

			// Token: 0x040008D4 RID: 2260
			public float __ControlPoints184;

			// Token: 0x040008D5 RID: 2261
			public float __ControlPoints185;

			// Token: 0x040008D6 RID: 2262
			public float __ControlPoints186;

			// Token: 0x040008D7 RID: 2263
			public float __ControlPoints187;

			// Token: 0x040008D8 RID: 2264
			public float __ControlPoints188;

			// Token: 0x040008D9 RID: 2265
			public float __ControlPoints189;

			// Token: 0x040008DA RID: 2266
			public float __ControlPoints190;

			// Token: 0x040008DB RID: 2267
			public float __ControlPoints191;

			// Token: 0x040008DC RID: 2268
			public float __ControlPoints192;

			// Token: 0x040008DD RID: 2269
			public float __ControlPoints193;

			// Token: 0x040008DE RID: 2270
			public float __ControlPoints194;

			// Token: 0x040008DF RID: 2271
			public float __ControlPoints195;

			// Token: 0x040008E0 RID: 2272
			public float __ControlPoints196;

			// Token: 0x040008E1 RID: 2273
			public float __ControlPoints197;

			// Token: 0x040008E2 RID: 2274
			public float __ControlPoints198;

			// Token: 0x040008E3 RID: 2275
			public float __ControlPoints199;

			// Token: 0x040008E4 RID: 2276
			public float __ControlPoints200;

			// Token: 0x040008E5 RID: 2277
			public float __ControlPoints201;

			// Token: 0x040008E6 RID: 2278
			public float __ControlPoints202;

			// Token: 0x040008E7 RID: 2279
			public float __ControlPoints203;

			// Token: 0x040008E8 RID: 2280
			public float __ControlPoints204;

			// Token: 0x040008E9 RID: 2281
			public float __ControlPoints205;

			// Token: 0x040008EA RID: 2282
			public float __ControlPoints206;

			// Token: 0x040008EB RID: 2283
			public float __ControlPoints207;

			// Token: 0x040008EC RID: 2284
			public float __ControlPoints208;

			// Token: 0x040008ED RID: 2285
			public float __ControlPoints209;

			// Token: 0x040008EE RID: 2286
			public float __ControlPoints210;

			// Token: 0x040008EF RID: 2287
			public float __ControlPoints211;

			// Token: 0x040008F0 RID: 2288
			public float __ControlPoints212;

			// Token: 0x040008F1 RID: 2289
			public float __ControlPoints213;

			// Token: 0x040008F2 RID: 2290
			public float __ControlPoints214;

			// Token: 0x040008F3 RID: 2291
			public float __ControlPoints215;

			// Token: 0x040008F4 RID: 2292
			public float __ControlPoints216;

			// Token: 0x040008F5 RID: 2293
			public float __ControlPoints217;

			// Token: 0x040008F6 RID: 2294
			public float __ControlPoints218;

			// Token: 0x040008F7 RID: 2295
			public float __ControlPoints219;

			// Token: 0x040008F8 RID: 2296
			public float __ControlPoints220;

			// Token: 0x040008F9 RID: 2297
			public float __ControlPoints221;

			// Token: 0x040008FA RID: 2298
			public float __ControlPoints222;

			// Token: 0x040008FB RID: 2299
			public float __ControlPoints223;

			// Token: 0x040008FC RID: 2300
			public float __ControlPoints224;

			// Token: 0x040008FD RID: 2301
			public float __ControlPoints225;

			// Token: 0x040008FE RID: 2302
			public float __ControlPoints226;

			// Token: 0x040008FF RID: 2303
			public float __ControlPoints227;

			// Token: 0x04000900 RID: 2304
			public float __ControlPoints228;

			// Token: 0x04000901 RID: 2305
			public float __ControlPoints229;

			// Token: 0x04000902 RID: 2306
			public float __ControlPoints230;

			// Token: 0x04000903 RID: 2307
			public float __ControlPoints231;

			// Token: 0x04000904 RID: 2308
			public float __ControlPoints232;

			// Token: 0x04000905 RID: 2309
			public float __ControlPoints233;

			// Token: 0x04000906 RID: 2310
			public float __ControlPoints234;

			// Token: 0x04000907 RID: 2311
			public float __ControlPoints235;

			// Token: 0x04000908 RID: 2312
			public float __ControlPoints236;

			// Token: 0x04000909 RID: 2313
			public float __ControlPoints237;

			// Token: 0x0400090A RID: 2314
			public float __ControlPoints238;

			// Token: 0x0400090B RID: 2315
			public float __ControlPoints239;

			// Token: 0x0400090C RID: 2316
			public float __ControlPoints240;

			// Token: 0x0400090D RID: 2317
			public float __ControlPoints241;

			// Token: 0x0400090E RID: 2318
			public float __ControlPoints242;

			// Token: 0x0400090F RID: 2319
			public float __ControlPoints243;

			// Token: 0x04000910 RID: 2320
			public float __ControlPoints244;

			// Token: 0x04000911 RID: 2321
			public float __ControlPoints245;

			// Token: 0x04000912 RID: 2322
			public float __ControlPoints246;

			// Token: 0x04000913 RID: 2323
			public float __ControlPoints247;

			// Token: 0x04000914 RID: 2324
			public float __ControlPoints248;

			// Token: 0x04000915 RID: 2325
			public float __ControlPoints249;

			// Token: 0x04000916 RID: 2326
			public float __ControlPoints250;

			// Token: 0x04000917 RID: 2327
			public float __ControlPoints251;

			// Token: 0x04000918 RID: 2328
			public float __ControlPoints252;

			// Token: 0x04000919 RID: 2329
			public float __ControlPoints253;

			// Token: 0x0400091A RID: 2330
			public float __ControlPoints254;

			// Token: 0x0400091B RID: 2331
			public float __ControlPoints255;

			// Token: 0x0400091C RID: 2332
			public float __ControlPoints256;

			// Token: 0x0400091D RID: 2333
			public float __ControlPoints257;

			// Token: 0x0400091E RID: 2334
			public float __ControlPoints258;

			// Token: 0x0400091F RID: 2335
			public float __ControlPoints259;

			// Token: 0x04000920 RID: 2336
			public float __ControlPoints260;

			// Token: 0x04000921 RID: 2337
			public float __ControlPoints261;

			// Token: 0x04000922 RID: 2338
			public float __ControlPoints262;

			// Token: 0x04000923 RID: 2339
			public float __ControlPoints263;

			// Token: 0x04000924 RID: 2340
			public float __ControlPoints264;

			// Token: 0x04000925 RID: 2341
			public float __ControlPoints265;

			// Token: 0x04000926 RID: 2342
			public float __ControlPoints266;

			// Token: 0x04000927 RID: 2343
			public float __ControlPoints267;

			// Token: 0x04000928 RID: 2344
			public float __ControlPoints268;

			// Token: 0x04000929 RID: 2345
			public float __ControlPoints269;

			// Token: 0x0400092A RID: 2346
			public float __ControlPoints270;

			// Token: 0x0400092B RID: 2347
			public float __ControlPoints271;

			// Token: 0x0400092C RID: 2348
			public float __ControlPoints272;

			// Token: 0x0400092D RID: 2349
			public float __ControlPoints273;

			// Token: 0x0400092E RID: 2350
			public float __ControlPoints274;

			// Token: 0x0400092F RID: 2351
			public float __ControlPoints275;

			// Token: 0x04000930 RID: 2352
			public float __ControlPoints276;

			// Token: 0x04000931 RID: 2353
			public float __ControlPoints277;

			// Token: 0x04000932 RID: 2354
			public float __ControlPoints278;

			// Token: 0x04000933 RID: 2355
			public float __ControlPoints279;

			// Token: 0x04000934 RID: 2356
			public float __ControlPoints280;

			// Token: 0x04000935 RID: 2357
			public float __ControlPoints281;

			// Token: 0x04000936 RID: 2358
			public float __ControlPoints282;

			// Token: 0x04000937 RID: 2359
			public float __ControlPoints283;

			// Token: 0x04000938 RID: 2360
			public float __ControlPoints284;

			// Token: 0x04000939 RID: 2361
			public float __ControlPoints285;

			// Token: 0x0400093A RID: 2362
			public float __ControlPoints286;

			// Token: 0x0400093B RID: 2363
			public float __ControlPoints287;

			// Token: 0x0400093C RID: 2364
			public float __ControlPoints288;

			// Token: 0x0400093D RID: 2365
			public float __ControlPoints289;

			// Token: 0x0400093E RID: 2366
			public float __ControlPoints290;

			// Token: 0x0400093F RID: 2367
			public float __ControlPoints291;

			// Token: 0x04000940 RID: 2368
			public float __ControlPoints292;

			// Token: 0x04000941 RID: 2369
			public float __ControlPoints293;

			// Token: 0x04000942 RID: 2370
			public float __ControlPoints294;

			// Token: 0x04000943 RID: 2371
			public float __ControlPoints295;

			// Token: 0x04000944 RID: 2372
			public float __ControlPoints296;

			// Token: 0x04000945 RID: 2373
			public float __ControlPoints297;

			// Token: 0x04000946 RID: 2374
			public float __ControlPoints298;

			// Token: 0x04000947 RID: 2375
			public float __ControlPoints299;

			// Token: 0x04000948 RID: 2376
			public float __ControlPoints300;

			// Token: 0x04000949 RID: 2377
			public float __ControlPoints301;

			// Token: 0x0400094A RID: 2378
			public float __ControlPoints302;

			// Token: 0x0400094B RID: 2379
			public float __ControlPoints303;

			// Token: 0x0400094C RID: 2380
			public float __ControlPoints304;

			// Token: 0x0400094D RID: 2381
			public float __ControlPoints305;

			// Token: 0x0400094E RID: 2382
			public float __ControlPoints306;

			// Token: 0x0400094F RID: 2383
			public float __ControlPoints307;

			// Token: 0x04000950 RID: 2384
			public float __ControlPoints308;

			// Token: 0x04000951 RID: 2385
			public float __ControlPoints309;

			// Token: 0x04000952 RID: 2386
			public float __ControlPoints310;

			// Token: 0x04000953 RID: 2387
			public float __ControlPoints311;

			// Token: 0x04000954 RID: 2388
			public float __ControlPoints312;

			// Token: 0x04000955 RID: 2389
			public float __ControlPoints313;

			// Token: 0x04000956 RID: 2390
			public float __ControlPoints314;

			// Token: 0x04000957 RID: 2391
			public float __ControlPoints315;

			// Token: 0x04000958 RID: 2392
			public float __ControlPoints316;

			// Token: 0x04000959 RID: 2393
			public float __ControlPoints317;

			// Token: 0x0400095A RID: 2394
			public float __ControlPoints318;

			// Token: 0x0400095B RID: 2395
			public float __ControlPoints319;

			// Token: 0x0400095C RID: 2396
			public float __ControlPoints320;

			// Token: 0x0400095D RID: 2397
			public float __ControlPoints321;

			// Token: 0x0400095E RID: 2398
			public float __ControlPoints322;

			// Token: 0x0400095F RID: 2399
			public float __ControlPoints323;

			// Token: 0x04000960 RID: 2400
			public float __ControlPoints324;

			// Token: 0x04000961 RID: 2401
			public float __ControlPoints325;

			// Token: 0x04000962 RID: 2402
			public float __ControlPoints326;

			// Token: 0x04000963 RID: 2403
			public float __ControlPoints327;

			// Token: 0x04000964 RID: 2404
			public float __ControlPoints328;

			// Token: 0x04000965 RID: 2405
			public float __ControlPoints329;

			// Token: 0x04000966 RID: 2406
			public float __ControlPoints330;

			// Token: 0x04000967 RID: 2407
			public float __ControlPoints331;

			// Token: 0x04000968 RID: 2408
			public float __ControlPoints332;

			// Token: 0x04000969 RID: 2409
			public float __ControlPoints333;

			// Token: 0x0400096A RID: 2410
			public float __ControlPoints334;

			// Token: 0x0400096B RID: 2411
			public float __ControlPoints335;

			// Token: 0x0400096C RID: 2412
			public float __ControlPoints336;

			// Token: 0x0400096D RID: 2413
			public float __ControlPoints337;

			// Token: 0x0400096E RID: 2414
			public float __ControlPoints338;

			// Token: 0x0400096F RID: 2415
			public float __ControlPoints339;

			// Token: 0x04000970 RID: 2416
			public float __ControlPoints340;

			// Token: 0x04000971 RID: 2417
			public float __ControlPoints341;

			// Token: 0x04000972 RID: 2418
			public float __ControlPoints342;

			// Token: 0x04000973 RID: 2419
			public float __ControlPoints343;

			// Token: 0x04000974 RID: 2420
			public float __ControlPoints344;

			// Token: 0x04000975 RID: 2421
			public float __ControlPoints345;

			// Token: 0x04000976 RID: 2422
			public float __ControlPoints346;

			// Token: 0x04000977 RID: 2423
			public float __ControlPoints347;

			// Token: 0x04000978 RID: 2424
			public float __ControlPoints348;

			// Token: 0x04000979 RID: 2425
			public float __ControlPoints349;

			// Token: 0x0400097A RID: 2426
			public float __ControlPoints350;

			// Token: 0x0400097B RID: 2427
			public float __ControlPoints351;

			// Token: 0x0400097C RID: 2428
			public float __ControlPoints352;

			// Token: 0x0400097D RID: 2429
			public float __ControlPoints353;

			// Token: 0x0400097E RID: 2430
			public float __ControlPoints354;

			// Token: 0x0400097F RID: 2431
			public float __ControlPoints355;

			// Token: 0x04000980 RID: 2432
			public float __ControlPoints356;

			// Token: 0x04000981 RID: 2433
			public float __ControlPoints357;

			// Token: 0x04000982 RID: 2434
			public float __ControlPoints358;

			// Token: 0x04000983 RID: 2435
			public float __ControlPoints359;

			// Token: 0x04000984 RID: 2436
			public float __ControlPoints360;

			// Token: 0x04000985 RID: 2437
			public float __ControlPoints361;

			// Token: 0x04000986 RID: 2438
			public float __ControlPoints362;

			// Token: 0x04000987 RID: 2439
			public float __ControlPoints363;

			// Token: 0x04000988 RID: 2440
			public float __ControlPoints364;

			// Token: 0x04000989 RID: 2441
			public float __ControlPoints365;

			// Token: 0x0400098A RID: 2442
			public float __ControlPoints366;

			// Token: 0x0400098B RID: 2443
			public float __ControlPoints367;

			// Token: 0x0400098C RID: 2444
			public float __ControlPoints368;

			// Token: 0x0400098D RID: 2445
			public float __ControlPoints369;

			// Token: 0x0400098E RID: 2446
			public float __ControlPoints370;

			// Token: 0x0400098F RID: 2447
			public float __ControlPoints371;

			// Token: 0x04000990 RID: 2448
			public float __ControlPoints372;

			// Token: 0x04000991 RID: 2449
			public float __ControlPoints373;

			// Token: 0x04000992 RID: 2450
			public float __ControlPoints374;

			// Token: 0x04000993 RID: 2451
			public float __ControlPoints375;

			// Token: 0x04000994 RID: 2452
			public float __ControlPoints376;

			// Token: 0x04000995 RID: 2453
			public float __ControlPoints377;

			// Token: 0x04000996 RID: 2454
			public float __ControlPoints378;

			// Token: 0x04000997 RID: 2455
			public float __ControlPoints379;

			// Token: 0x04000998 RID: 2456
			public float __ControlPoints380;

			// Token: 0x04000999 RID: 2457
			public float __ControlPoints381;

			// Token: 0x0400099A RID: 2458
			public float __ControlPoints382;

			// Token: 0x0400099B RID: 2459
			public float __ControlPoints383;

			// Token: 0x0400099C RID: 2460
			public float __ControlPoints384;

			// Token: 0x0400099D RID: 2461
			public float __ControlPoints385;

			// Token: 0x0400099E RID: 2462
			public float __ControlPoints386;

			// Token: 0x0400099F RID: 2463
			public float __ControlPoints387;

			// Token: 0x040009A0 RID: 2464
			public float __ControlPoints388;

			// Token: 0x040009A1 RID: 2465
			public float __ControlPoints389;

			// Token: 0x040009A2 RID: 2466
			public float __ControlPoints390;

			// Token: 0x040009A3 RID: 2467
			public float __ControlPoints391;

			// Token: 0x040009A4 RID: 2468
			public float __ControlPoints392;

			// Token: 0x040009A5 RID: 2469
			public float __ControlPoints393;

			// Token: 0x040009A6 RID: 2470
			public float __ControlPoints394;

			// Token: 0x040009A7 RID: 2471
			public float __ControlPoints395;

			// Token: 0x040009A8 RID: 2472
			public float __ControlPoints396;

			// Token: 0x040009A9 RID: 2473
			public float __ControlPoints397;

			// Token: 0x040009AA RID: 2474
			public float __ControlPoints398;

			// Token: 0x040009AB RID: 2475
			public float __ControlPoints399;

			// Token: 0x040009AC RID: 2476
			public float __ControlPoints400;

			// Token: 0x040009AD RID: 2477
			public float __ControlPoints401;

			// Token: 0x040009AE RID: 2478
			public float __ControlPoints402;

			// Token: 0x040009AF RID: 2479
			public float __ControlPoints403;

			// Token: 0x040009B0 RID: 2480
			public float __ControlPoints404;

			// Token: 0x040009B1 RID: 2481
			public float __ControlPoints405;

			// Token: 0x040009B2 RID: 2482
			public float __ControlPoints406;

			// Token: 0x040009B3 RID: 2483
			public float __ControlPoints407;

			// Token: 0x040009B4 RID: 2484
			public float __ControlPoints408;

			// Token: 0x040009B5 RID: 2485
			public float __ControlPoints409;

			// Token: 0x040009B6 RID: 2486
			public float __ControlPoints410;

			// Token: 0x040009B7 RID: 2487
			public float __ControlPoints411;

			// Token: 0x040009B8 RID: 2488
			public float __ControlPoints412;

			// Token: 0x040009B9 RID: 2489
			public float __ControlPoints413;

			// Token: 0x040009BA RID: 2490
			public float __ControlPoints414;

			// Token: 0x040009BB RID: 2491
			public float __ControlPoints415;

			// Token: 0x040009BC RID: 2492
			public float __ControlPoints416;

			// Token: 0x040009BD RID: 2493
			public float __ControlPoints417;

			// Token: 0x040009BE RID: 2494
			public float __ControlPoints418;

			// Token: 0x040009BF RID: 2495
			public float __ControlPoints419;

			// Token: 0x040009C0 RID: 2496
			public float __ControlPoints420;

			// Token: 0x040009C1 RID: 2497
			public float __ControlPoints421;

			// Token: 0x040009C2 RID: 2498
			public float __ControlPoints422;

			// Token: 0x040009C3 RID: 2499
			public float __ControlPoints423;

			// Token: 0x040009C4 RID: 2500
			public float __ControlPoints424;

			// Token: 0x040009C5 RID: 2501
			public float __ControlPoints425;

			// Token: 0x040009C6 RID: 2502
			public float __ControlPoints426;

			// Token: 0x040009C7 RID: 2503
			public float __ControlPoints427;

			// Token: 0x040009C8 RID: 2504
			public float __ControlPoints428;

			// Token: 0x040009C9 RID: 2505
			public float __ControlPoints429;

			// Token: 0x040009CA RID: 2506
			public float __ControlPoints430;

			// Token: 0x040009CB RID: 2507
			public float __ControlPoints431;

			// Token: 0x040009CC RID: 2508
			public float __ControlPoints432;

			// Token: 0x040009CD RID: 2509
			public float __ControlPoints433;

			// Token: 0x040009CE RID: 2510
			public float __ControlPoints434;

			// Token: 0x040009CF RID: 2511
			public float __ControlPoints435;

			// Token: 0x040009D0 RID: 2512
			public float __ControlPoints436;

			// Token: 0x040009D1 RID: 2513
			public float __ControlPoints437;

			// Token: 0x040009D2 RID: 2514
			public float __ControlPoints438;

			// Token: 0x040009D3 RID: 2515
			public float __ControlPoints439;

			// Token: 0x040009D4 RID: 2516
			public float __ControlPoints440;

			// Token: 0x040009D5 RID: 2517
			public float __ControlPoints441;

			// Token: 0x040009D6 RID: 2518
			public float __ControlPoints442;

			// Token: 0x040009D7 RID: 2519
			public float __ControlPoints443;

			// Token: 0x040009D8 RID: 2520
			public float __ControlPoints444;

			// Token: 0x040009D9 RID: 2521
			public float __ControlPoints445;

			// Token: 0x040009DA RID: 2522
			public float __ControlPoints446;

			// Token: 0x040009DB RID: 2523
			public float __ControlPoints447;

			// Token: 0x040009DC RID: 2524
			public float __ControlPoints448;

			// Token: 0x040009DD RID: 2525
			public float __ControlPoints449;

			// Token: 0x040009DE RID: 2526
			public float __ControlPoints450;

			// Token: 0x040009DF RID: 2527
			public float __ControlPoints451;

			// Token: 0x040009E0 RID: 2528
			public float __ControlPoints452;

			// Token: 0x040009E1 RID: 2529
			public float __ControlPoints453;

			// Token: 0x040009E2 RID: 2530
			public float __ControlPoints454;

			// Token: 0x040009E3 RID: 2531
			public float __ControlPoints455;

			// Token: 0x040009E4 RID: 2532
			public float __ControlPoints456;

			// Token: 0x040009E5 RID: 2533
			public float __ControlPoints457;

			// Token: 0x040009E6 RID: 2534
			public float __ControlPoints458;

			// Token: 0x040009E7 RID: 2535
			public float __ControlPoints459;

			// Token: 0x040009E8 RID: 2536
			public float __ControlPoints460;

			// Token: 0x040009E9 RID: 2537
			public float __ControlPoints461;

			// Token: 0x040009EA RID: 2538
			public float __ControlPoints462;

			// Token: 0x040009EB RID: 2539
			public float __ControlPoints463;

			// Token: 0x040009EC RID: 2540
			public float __ControlPoints464;

			// Token: 0x040009ED RID: 2541
			public float __ControlPoints465;

			// Token: 0x040009EE RID: 2542
			public float __ControlPoints466;

			// Token: 0x040009EF RID: 2543
			public float __ControlPoints467;

			// Token: 0x040009F0 RID: 2544
			public float __ControlPoints468;

			// Token: 0x040009F1 RID: 2545
			public float __ControlPoints469;

			// Token: 0x040009F2 RID: 2546
			public float __ControlPoints470;

			// Token: 0x040009F3 RID: 2547
			public float __ControlPoints471;

			// Token: 0x040009F4 RID: 2548
			public float __ControlPoints472;

			// Token: 0x040009F5 RID: 2549
			public float __ControlPoints473;

			// Token: 0x040009F6 RID: 2550
			public float __ControlPoints474;

			// Token: 0x040009F7 RID: 2551
			public float __ControlPoints475;

			// Token: 0x040009F8 RID: 2552
			public float __ControlPoints476;

			// Token: 0x040009F9 RID: 2553
			public float __ControlPoints477;

			// Token: 0x040009FA RID: 2554
			public float __ControlPoints478;

			// Token: 0x040009FB RID: 2555
			public float __ControlPoints479;

			// Token: 0x040009FC RID: 2556
			public float __ControlPoints480;

			// Token: 0x040009FD RID: 2557
			public float __ControlPoints481;

			// Token: 0x040009FE RID: 2558
			public float __ControlPoints482;

			// Token: 0x040009FF RID: 2559
			public float __ControlPoints483;

			// Token: 0x04000A00 RID: 2560
			public float __ControlPoints484;

			// Token: 0x04000A01 RID: 2561
			public float __ControlPoints485;

			// Token: 0x04000A02 RID: 2562
			public float __ControlPoints486;

			// Token: 0x04000A03 RID: 2563
			public float __ControlPoints487;

			// Token: 0x04000A04 RID: 2564
			public float __ControlPoints488;

			// Token: 0x04000A05 RID: 2565
			public float __ControlPoints489;

			// Token: 0x04000A06 RID: 2566
			public float __ControlPoints490;

			// Token: 0x04000A07 RID: 2567
			public float __ControlPoints491;

			// Token: 0x04000A08 RID: 2568
			public float __ControlPoints492;

			// Token: 0x04000A09 RID: 2569
			public float __ControlPoints493;

			// Token: 0x04000A0A RID: 2570
			public float __ControlPoints494;

			// Token: 0x04000A0B RID: 2571
			public float __ControlPoints495;

			// Token: 0x04000A0C RID: 2572
			public float __ControlPoints496;

			// Token: 0x04000A0D RID: 2573
			public float __ControlPoints497;

			// Token: 0x04000A0E RID: 2574
			public float __ControlPoints498;

			// Token: 0x04000A0F RID: 2575
			public float __ControlPoints499;

			// Token: 0x04000A10 RID: 2576
			public float __ControlPoints500;

			// Token: 0x04000A11 RID: 2577
			public float __ControlPoints501;

			// Token: 0x04000A12 RID: 2578
			public float __ControlPoints502;

			// Token: 0x04000A13 RID: 2579
			public float __ControlPoints503;

			// Token: 0x04000A14 RID: 2580
			public float __ControlPoints504;

			// Token: 0x04000A15 RID: 2581
			public float __ControlPoints505;

			// Token: 0x04000A16 RID: 2582
			public float __ControlPoints506;

			// Token: 0x04000A17 RID: 2583
			public float __ControlPoints507;

			// Token: 0x04000A18 RID: 2584
			public float __ControlPoints508;

			// Token: 0x04000A19 RID: 2585
			public float __ControlPoints509;

			// Token: 0x04000A1A RID: 2586
			public float __ControlPoints510;

			// Token: 0x04000A1B RID: 2587
			public float __ControlPoints511;

			// Token: 0x04000A1C RID: 2588
			public float __ControlPoints512;

			// Token: 0x04000A1D RID: 2589
			public float __ControlPoints513;

			// Token: 0x04000A1E RID: 2590
			public float __ControlPoints514;

			// Token: 0x04000A1F RID: 2591
			public float __ControlPoints515;

			// Token: 0x04000A20 RID: 2592
			public float __ControlPoints516;

			// Token: 0x04000A21 RID: 2593
			public float __ControlPoints517;

			// Token: 0x04000A22 RID: 2594
			public float __ControlPoints518;

			// Token: 0x04000A23 RID: 2595
			public float __ControlPoints519;

			// Token: 0x04000A24 RID: 2596
			public float __ControlPoints520;

			// Token: 0x04000A25 RID: 2597
			public float __ControlPoints521;

			// Token: 0x04000A26 RID: 2598
			public float __ControlPoints522;

			// Token: 0x04000A27 RID: 2599
			public float __ControlPoints523;

			// Token: 0x04000A28 RID: 2600
			public float __ControlPoints524;

			// Token: 0x04000A29 RID: 2601
			public float __ControlPoints525;

			// Token: 0x04000A2A RID: 2602
			public float __ControlPoints526;

			// Token: 0x04000A2B RID: 2603
			public float __ControlPoints527;

			// Token: 0x04000A2C RID: 2604
			public float __ControlPoints528;

			// Token: 0x04000A2D RID: 2605
			public float __ControlPoints529;

			// Token: 0x04000A2E RID: 2606
			public float __ControlPoints530;

			// Token: 0x04000A2F RID: 2607
			public float __ControlPoints531;

			// Token: 0x04000A30 RID: 2608
			public float __ControlPoints532;

			// Token: 0x04000A31 RID: 2609
			public float __ControlPoints533;

			// Token: 0x04000A32 RID: 2610
			public float __ControlPoints534;

			// Token: 0x04000A33 RID: 2611
			public float __ControlPoints535;

			// Token: 0x04000A34 RID: 2612
			public float __ControlPoints536;

			// Token: 0x04000A35 RID: 2613
			public float __ControlPoints537;

			// Token: 0x04000A36 RID: 2614
			public float __ControlPoints538;

			// Token: 0x04000A37 RID: 2615
			public float __ControlPoints539;

			// Token: 0x04000A38 RID: 2616
			public float __ControlPoints540;

			// Token: 0x04000A39 RID: 2617
			public float __ControlPoints541;

			// Token: 0x04000A3A RID: 2618
			public float __ControlPoints542;

			// Token: 0x04000A3B RID: 2619
			public float __ControlPoints543;

			// Token: 0x04000A3C RID: 2620
			public float __ControlPoints544;

			// Token: 0x04000A3D RID: 2621
			public float __ControlPoints545;

			// Token: 0x04000A3E RID: 2622
			public float __ControlPoints546;

			// Token: 0x04000A3F RID: 2623
			public float __ControlPoints547;

			// Token: 0x04000A40 RID: 2624
			public float __ControlPoints548;

			// Token: 0x04000A41 RID: 2625
			public float __ControlPoints549;

			// Token: 0x04000A42 RID: 2626
			public float __ControlPoints550;

			// Token: 0x04000A43 RID: 2627
			public float __ControlPoints551;

			// Token: 0x04000A44 RID: 2628
			public float __ControlPoints552;

			// Token: 0x04000A45 RID: 2629
			public float __ControlPoints553;

			// Token: 0x04000A46 RID: 2630
			public float __ControlPoints554;

			// Token: 0x04000A47 RID: 2631
			public float __ControlPoints555;

			// Token: 0x04000A48 RID: 2632
			public float __ControlPoints556;

			// Token: 0x04000A49 RID: 2633
			public float __ControlPoints557;

			// Token: 0x04000A4A RID: 2634
			public float __ControlPoints558;

			// Token: 0x04000A4B RID: 2635
			public float __ControlPoints559;

			// Token: 0x04000A4C RID: 2636
			public float __ControlPoints560;

			// Token: 0x04000A4D RID: 2637
			public float __ControlPoints561;

			// Token: 0x04000A4E RID: 2638
			public float __ControlPoints562;

			// Token: 0x04000A4F RID: 2639
			public float __ControlPoints563;

			// Token: 0x04000A50 RID: 2640
			public float __ControlPoints564;

			// Token: 0x04000A51 RID: 2641
			public float __ControlPoints565;

			// Token: 0x04000A52 RID: 2642
			public float __ControlPoints566;

			// Token: 0x04000A53 RID: 2643
			public float __ControlPoints567;

			// Token: 0x04000A54 RID: 2644
			public float __ControlPoints568;

			// Token: 0x04000A55 RID: 2645
			public float __ControlPoints569;

			// Token: 0x04000A56 RID: 2646
			public float __ControlPoints570;

			// Token: 0x04000A57 RID: 2647
			public float __ControlPoints571;

			// Token: 0x04000A58 RID: 2648
			public float __ControlPoints572;

			// Token: 0x04000A59 RID: 2649
			public float __ControlPoints573;

			// Token: 0x04000A5A RID: 2650
			public float __ControlPoints574;

			// Token: 0x04000A5B RID: 2651
			public float __ControlPoints575;

			// Token: 0x04000A5C RID: 2652
			public float __ControlPoints576;

			// Token: 0x04000A5D RID: 2653
			public float __ControlPoints577;

			// Token: 0x04000A5E RID: 2654
			public float __ControlPoints578;

			// Token: 0x04000A5F RID: 2655
			public float __ControlPoints579;

			// Token: 0x04000A60 RID: 2656
			public float __ControlPoints580;

			// Token: 0x04000A61 RID: 2657
			public float __ControlPoints581;

			// Token: 0x04000A62 RID: 2658
			public float __ControlPoints582;

			// Token: 0x04000A63 RID: 2659
			public float __ControlPoints583;

			// Token: 0x04000A64 RID: 2660
			public float __ControlPoints584;

			// Token: 0x04000A65 RID: 2661
			public float __ControlPoints585;

			// Token: 0x04000A66 RID: 2662
			public float __ControlPoints586;

			// Token: 0x04000A67 RID: 2663
			public float __ControlPoints587;

			// Token: 0x04000A68 RID: 2664
			public float __ControlPoints588;

			// Token: 0x04000A69 RID: 2665
			public float __ControlPoints589;

			// Token: 0x04000A6A RID: 2666
			public float __ControlPoints590;

			// Token: 0x04000A6B RID: 2667
			public float __ControlPoints591;

			// Token: 0x04000A6C RID: 2668
			public float __ControlPoints592;

			// Token: 0x04000A6D RID: 2669
			public float __ControlPoints593;

			// Token: 0x04000A6E RID: 2670
			public float __ControlPoints594;

			// Token: 0x04000A6F RID: 2671
			public float __ControlPoints595;

			// Token: 0x04000A70 RID: 2672
			public float __ControlPoints596;

			// Token: 0x04000A71 RID: 2673
			public float __ControlPoints597;

			// Token: 0x04000A72 RID: 2674
			public float __ControlPoints598;

			// Token: 0x04000A73 RID: 2675
			public float __ControlPoints599;

			// Token: 0x04000A74 RID: 2676
			public float __ControlPoints600;

			// Token: 0x04000A75 RID: 2677
			public float __ControlPoints601;

			// Token: 0x04000A76 RID: 2678
			public float __ControlPoints602;

			// Token: 0x04000A77 RID: 2679
			public float __ControlPoints603;

			// Token: 0x04000A78 RID: 2680
			public float __ControlPoints604;

			// Token: 0x04000A79 RID: 2681
			public float __ControlPoints605;

			// Token: 0x04000A7A RID: 2682
			public float __ControlPoints606;

			// Token: 0x04000A7B RID: 2683
			public float __ControlPoints607;

			// Token: 0x04000A7C RID: 2684
			public float __ControlPoints608;

			// Token: 0x04000A7D RID: 2685
			public float __ControlPoints609;

			// Token: 0x04000A7E RID: 2686
			public float __ControlPoints610;

			// Token: 0x04000A7F RID: 2687
			public float __ControlPoints611;

			// Token: 0x04000A80 RID: 2688
			public float __ControlPoints612;

			// Token: 0x04000A81 RID: 2689
			public float __ControlPoints613;

			// Token: 0x04000A82 RID: 2690
			public float __ControlPoints614;

			// Token: 0x04000A83 RID: 2691
			public float __ControlPoints615;

			// Token: 0x04000A84 RID: 2692
			public float __ControlPoints616;

			// Token: 0x04000A85 RID: 2693
			public float __ControlPoints617;

			// Token: 0x04000A86 RID: 2694
			public float __ControlPoints618;

			// Token: 0x04000A87 RID: 2695
			public float __ControlPoints619;

			// Token: 0x04000A88 RID: 2696
			public float __ControlPoints620;

			// Token: 0x04000A89 RID: 2697
			public float __ControlPoints621;

			// Token: 0x04000A8A RID: 2698
			public float __ControlPoints622;

			// Token: 0x04000A8B RID: 2699
			public float __ControlPoints623;

			// Token: 0x04000A8C RID: 2700
			public float __ControlPoints624;

			// Token: 0x04000A8D RID: 2701
			public float __ControlPoints625;

			// Token: 0x04000A8E RID: 2702
			public float __ControlPoints626;

			// Token: 0x04000A8F RID: 2703
			public float __ControlPoints627;

			// Token: 0x04000A90 RID: 2704
			public float __ControlPoints628;

			// Token: 0x04000A91 RID: 2705
			public float __ControlPoints629;

			// Token: 0x04000A92 RID: 2706
			public float __ControlPoints630;

			// Token: 0x04000A93 RID: 2707
			public float __ControlPoints631;

			// Token: 0x04000A94 RID: 2708
			public float __ControlPoints632;

			// Token: 0x04000A95 RID: 2709
			public float __ControlPoints633;

			// Token: 0x04000A96 RID: 2710
			public float __ControlPoints634;

			// Token: 0x04000A97 RID: 2711
			public float __ControlPoints635;

			// Token: 0x04000A98 RID: 2712
			public float __ControlPoints636;

			// Token: 0x04000A99 RID: 2713
			public float __ControlPoints637;

			// Token: 0x04000A9A RID: 2714
			public float __ControlPoints638;

			// Token: 0x04000A9B RID: 2715
			public float __ControlPoints639;

			// Token: 0x04000A9C RID: 2716
			public float __ControlPoints640;

			// Token: 0x04000A9D RID: 2717
			public float __ControlPoints641;

			// Token: 0x04000A9E RID: 2718
			public float __ControlPoints642;

			// Token: 0x04000A9F RID: 2719
			public float __ControlPoints643;

			// Token: 0x04000AA0 RID: 2720
			public float __ControlPoints644;

			// Token: 0x04000AA1 RID: 2721
			public float __ControlPoints645;

			// Token: 0x04000AA2 RID: 2722
			public float __ControlPoints646;

			// Token: 0x04000AA3 RID: 2723
			public float __ControlPoints647;

			// Token: 0x04000AA4 RID: 2724
			public float __ControlPoints648;

			// Token: 0x04000AA5 RID: 2725
			public float __ControlPoints649;

			// Token: 0x04000AA6 RID: 2726
			public float __ControlPoints650;

			// Token: 0x04000AA7 RID: 2727
			public float __ControlPoints651;

			// Token: 0x04000AA8 RID: 2728
			public float __ControlPoints652;

			// Token: 0x04000AA9 RID: 2729
			public float __ControlPoints653;

			// Token: 0x04000AAA RID: 2730
			public float __ControlPoints654;

			// Token: 0x04000AAB RID: 2731
			public float __ControlPoints655;

			// Token: 0x04000AAC RID: 2732
			public float __ControlPoints656;

			// Token: 0x04000AAD RID: 2733
			public float __ControlPoints657;

			// Token: 0x04000AAE RID: 2734
			public float __ControlPoints658;

			// Token: 0x04000AAF RID: 2735
			public float __ControlPoints659;

			// Token: 0x04000AB0 RID: 2736
			public float __ControlPoints660;

			// Token: 0x04000AB1 RID: 2737
			public float __ControlPoints661;

			// Token: 0x04000AB2 RID: 2738
			public float __ControlPoints662;

			// Token: 0x04000AB3 RID: 2739
			public float __ControlPoints663;

			// Token: 0x04000AB4 RID: 2740
			public float __ControlPoints664;

			// Token: 0x04000AB5 RID: 2741
			public float __ControlPoints665;

			// Token: 0x04000AB6 RID: 2742
			public float __ControlPoints666;

			// Token: 0x04000AB7 RID: 2743
			public float __ControlPoints667;

			// Token: 0x04000AB8 RID: 2744
			public float __ControlPoints668;

			// Token: 0x04000AB9 RID: 2745
			public float __ControlPoints669;

			// Token: 0x04000ABA RID: 2746
			public float __ControlPoints670;

			// Token: 0x04000ABB RID: 2747
			public float __ControlPoints671;

			// Token: 0x04000ABC RID: 2748
			public float __ControlPoints672;

			// Token: 0x04000ABD RID: 2749
			public float __ControlPoints673;

			// Token: 0x04000ABE RID: 2750
			public float __ControlPoints674;

			// Token: 0x04000ABF RID: 2751
			public float __ControlPoints675;

			// Token: 0x04000AC0 RID: 2752
			public float __ControlPoints676;

			// Token: 0x04000AC1 RID: 2753
			public float __ControlPoints677;

			// Token: 0x04000AC2 RID: 2754
			public float __ControlPoints678;

			// Token: 0x04000AC3 RID: 2755
			public float __ControlPoints679;

			// Token: 0x04000AC4 RID: 2756
			public float __ControlPoints680;

			// Token: 0x04000AC5 RID: 2757
			public float __ControlPoints681;

			// Token: 0x04000AC6 RID: 2758
			public float __ControlPoints682;

			// Token: 0x04000AC7 RID: 2759
			public float __ControlPoints683;

			// Token: 0x04000AC8 RID: 2760
			public float __ControlPoints684;

			// Token: 0x04000AC9 RID: 2761
			public float __ControlPoints685;

			// Token: 0x04000ACA RID: 2762
			public float __ControlPoints686;

			// Token: 0x04000ACB RID: 2763
			public float __ControlPoints687;

			// Token: 0x04000ACC RID: 2764
			public float __ControlPoints688;

			// Token: 0x04000ACD RID: 2765
			public float __ControlPoints689;

			// Token: 0x04000ACE RID: 2766
			public float __ControlPoints690;

			// Token: 0x04000ACF RID: 2767
			public float __ControlPoints691;

			// Token: 0x04000AD0 RID: 2768
			public float __ControlPoints692;

			// Token: 0x04000AD1 RID: 2769
			public float __ControlPoints693;

			// Token: 0x04000AD2 RID: 2770
			public float __ControlPoints694;

			// Token: 0x04000AD3 RID: 2771
			public float __ControlPoints695;

			// Token: 0x04000AD4 RID: 2772
			public float __ControlPoints696;

			// Token: 0x04000AD5 RID: 2773
			public float __ControlPoints697;

			// Token: 0x04000AD6 RID: 2774
			public float __ControlPoints698;

			// Token: 0x04000AD7 RID: 2775
			public float __ControlPoints699;

			// Token: 0x04000AD8 RID: 2776
			public float __ControlPoints700;

			// Token: 0x04000AD9 RID: 2777
			public float __ControlPoints701;

			// Token: 0x04000ADA RID: 2778
			public float __ControlPoints702;

			// Token: 0x04000ADB RID: 2779
			public float __ControlPoints703;

			// Token: 0x04000ADC RID: 2780
			public float __ControlPoints704;

			// Token: 0x04000ADD RID: 2781
			public float __ControlPoints705;

			// Token: 0x04000ADE RID: 2782
			public float __ControlPoints706;

			// Token: 0x04000ADF RID: 2783
			public float __ControlPoints707;

			// Token: 0x04000AE0 RID: 2784
			public float __ControlPoints708;

			// Token: 0x04000AE1 RID: 2785
			public float __ControlPoints709;

			// Token: 0x04000AE2 RID: 2786
			public float __ControlPoints710;

			// Token: 0x04000AE3 RID: 2787
			public float __ControlPoints711;

			// Token: 0x04000AE4 RID: 2788
			public float __ControlPoints712;

			// Token: 0x04000AE5 RID: 2789
			public float __ControlPoints713;

			// Token: 0x04000AE6 RID: 2790
			public float __ControlPoints714;

			// Token: 0x04000AE7 RID: 2791
			public float __ControlPoints715;

			// Token: 0x04000AE8 RID: 2792
			public float __ControlPoints716;

			// Token: 0x04000AE9 RID: 2793
			public float __ControlPoints717;

			// Token: 0x04000AEA RID: 2794
			public float __ControlPoints718;

			// Token: 0x04000AEB RID: 2795
			public float __ControlPoints719;

			// Token: 0x04000AEC RID: 2796
			public float __ControlPoints720;

			// Token: 0x04000AED RID: 2797
			public float __ControlPoints721;

			// Token: 0x04000AEE RID: 2798
			public float __ControlPoints722;

			// Token: 0x04000AEF RID: 2799
			public float __ControlPoints723;

			// Token: 0x04000AF0 RID: 2800
			public float __ControlPoints724;

			// Token: 0x04000AF1 RID: 2801
			public float __ControlPoints725;

			// Token: 0x04000AF2 RID: 2802
			public float __ControlPoints726;

			// Token: 0x04000AF3 RID: 2803
			public float __ControlPoints727;

			// Token: 0x04000AF4 RID: 2804
			public float __ControlPoints728;

			// Token: 0x04000AF5 RID: 2805
			public float __ControlPoints729;

			// Token: 0x04000AF6 RID: 2806
			public float __ControlPoints730;

			// Token: 0x04000AF7 RID: 2807
			public float __ControlPoints731;

			// Token: 0x04000AF8 RID: 2808
			public float __ControlPoints732;

			// Token: 0x04000AF9 RID: 2809
			public float __ControlPoints733;

			// Token: 0x04000AFA RID: 2810
			public float __ControlPoints734;

			// Token: 0x04000AFB RID: 2811
			public float __ControlPoints735;

			// Token: 0x04000AFC RID: 2812
			public float __ControlPoints736;

			// Token: 0x04000AFD RID: 2813
			public float __ControlPoints737;

			// Token: 0x04000AFE RID: 2814
			public float __ControlPoints738;

			// Token: 0x04000AFF RID: 2815
			public float __ControlPoints739;

			// Token: 0x04000B00 RID: 2816
			public float __ControlPoints740;

			// Token: 0x04000B01 RID: 2817
			public float __ControlPoints741;

			// Token: 0x04000B02 RID: 2818
			public float __ControlPoints742;

			// Token: 0x04000B03 RID: 2819
			public float __ControlPoints743;

			// Token: 0x04000B04 RID: 2820
			public float __ControlPoints744;

			// Token: 0x04000B05 RID: 2821
			public float __ControlPoints745;

			// Token: 0x04000B06 RID: 2822
			public float __ControlPoints746;

			// Token: 0x04000B07 RID: 2823
			public float __ControlPoints747;

			// Token: 0x04000B08 RID: 2824
			public float __ControlPoints748;

			// Token: 0x04000B09 RID: 2825
			public float __ControlPoints749;

			// Token: 0x04000B0A RID: 2826
			public float __ControlPoints750;

			// Token: 0x04000B0B RID: 2827
			public float __ControlPoints751;

			// Token: 0x04000B0C RID: 2828
			public float __ControlPoints752;

			// Token: 0x04000B0D RID: 2829
			public float __ControlPoints753;

			// Token: 0x04000B0E RID: 2830
			public float __ControlPoints754;

			// Token: 0x04000B0F RID: 2831
			public float __ControlPoints755;

			// Token: 0x04000B10 RID: 2832
			public float __ControlPoints756;

			// Token: 0x04000B11 RID: 2833
			public float __ControlPoints757;

			// Token: 0x04000B12 RID: 2834
			public float __ControlPoints758;

			// Token: 0x04000B13 RID: 2835
			public float __ControlPoints759;

			// Token: 0x04000B14 RID: 2836
			public float __ControlPoints760;

			// Token: 0x04000B15 RID: 2837
			public float __ControlPoints761;

			// Token: 0x04000B16 RID: 2838
			public float __ControlPoints762;

			// Token: 0x04000B17 RID: 2839
			public float __ControlPoints763;

			// Token: 0x04000B18 RID: 2840
			public float __ControlPoints764;

			// Token: 0x04000B19 RID: 2841
			public float __ControlPoints765;

			// Token: 0x04000B1A RID: 2842
			public float __ControlPoints766;

			// Token: 0x04000B1B RID: 2843
			public float __ControlPoints767;

			// Token: 0x04000B1C RID: 2844
			public float __ControlPoints768;

			// Token: 0x04000B1D RID: 2845
			public float __ControlPoints769;

			// Token: 0x04000B1E RID: 2846
			public float __ControlPoints770;

			// Token: 0x04000B1F RID: 2847
			public float __ControlPoints771;

			// Token: 0x04000B20 RID: 2848
			public float __ControlPoints772;

			// Token: 0x04000B21 RID: 2849
			public float __ControlPoints773;

			// Token: 0x04000B22 RID: 2850
			public float __ControlPoints774;

			// Token: 0x04000B23 RID: 2851
			public float __ControlPoints775;

			// Token: 0x04000B24 RID: 2852
			public float __ControlPoints776;

			// Token: 0x04000B25 RID: 2853
			public float __ControlPoints777;

			// Token: 0x04000B26 RID: 2854
			public float __ControlPoints778;

			// Token: 0x04000B27 RID: 2855
			public float __ControlPoints779;

			// Token: 0x04000B28 RID: 2856
			public float __ControlPoints780;

			// Token: 0x04000B29 RID: 2857
			public float __ControlPoints781;

			// Token: 0x04000B2A RID: 2858
			public float __ControlPoints782;

			// Token: 0x04000B2B RID: 2859
			public float __ControlPoints783;

			// Token: 0x04000B2C RID: 2860
			public float __ControlPoints784;

			// Token: 0x04000B2D RID: 2861
			public float __ControlPoints785;

			// Token: 0x04000B2E RID: 2862
			public float __ControlPoints786;

			// Token: 0x04000B2F RID: 2863
			public float __ControlPoints787;

			// Token: 0x04000B30 RID: 2864
			public float __ControlPoints788;

			// Token: 0x04000B31 RID: 2865
			public float __ControlPoints789;

			// Token: 0x04000B32 RID: 2866
			public float __ControlPoints790;

			// Token: 0x04000B33 RID: 2867
			public float __ControlPoints791;

			// Token: 0x04000B34 RID: 2868
			public float __ControlPoints792;

			// Token: 0x04000B35 RID: 2869
			public float __ControlPoints793;

			// Token: 0x04000B36 RID: 2870
			public float __ControlPoints794;

			// Token: 0x04000B37 RID: 2871
			public float __ControlPoints795;

			// Token: 0x04000B38 RID: 2872
			public float __ControlPoints796;

			// Token: 0x04000B39 RID: 2873
			public float __ControlPoints797;

			// Token: 0x04000B3A RID: 2874
			public float __ControlPoints798;

			// Token: 0x04000B3B RID: 2875
			public float __ControlPoints799;

			// Token: 0x04000B3C RID: 2876
			public float __ControlPoints800;

			// Token: 0x04000B3D RID: 2877
			public float __ControlPoints801;

			// Token: 0x04000B3E RID: 2878
			public float __ControlPoints802;

			// Token: 0x04000B3F RID: 2879
			public float __ControlPoints803;

			// Token: 0x04000B40 RID: 2880
			public float __ControlPoints804;

			// Token: 0x04000B41 RID: 2881
			public float __ControlPoints805;

			// Token: 0x04000B42 RID: 2882
			public float __ControlPoints806;

			// Token: 0x04000B43 RID: 2883
			public float __ControlPoints807;

			// Token: 0x04000B44 RID: 2884
			public float __ControlPoints808;

			// Token: 0x04000B45 RID: 2885
			public float __ControlPoints809;

			// Token: 0x04000B46 RID: 2886
			public float __ControlPoints810;

			// Token: 0x04000B47 RID: 2887
			public float __ControlPoints811;

			// Token: 0x04000B48 RID: 2888
			public float __ControlPoints812;

			// Token: 0x04000B49 RID: 2889
			public float __ControlPoints813;

			// Token: 0x04000B4A RID: 2890
			public float __ControlPoints814;

			// Token: 0x04000B4B RID: 2891
			public float __ControlPoints815;

			// Token: 0x04000B4C RID: 2892
			public float __ControlPoints816;

			// Token: 0x04000B4D RID: 2893
			public float __ControlPoints817;

			// Token: 0x04000B4E RID: 2894
			public float __ControlPoints818;

			// Token: 0x04000B4F RID: 2895
			public float __ControlPoints819;

			// Token: 0x04000B50 RID: 2896
			public float __ControlPoints820;

			// Token: 0x04000B51 RID: 2897
			public float __ControlPoints821;

			// Token: 0x04000B52 RID: 2898
			public float __ControlPoints822;

			// Token: 0x04000B53 RID: 2899
			public float __ControlPoints823;

			// Token: 0x04000B54 RID: 2900
			public float __ControlPoints824;

			// Token: 0x04000B55 RID: 2901
			public float __ControlPoints825;

			// Token: 0x04000B56 RID: 2902
			public float __ControlPoints826;

			// Token: 0x04000B57 RID: 2903
			public float __ControlPoints827;

			// Token: 0x04000B58 RID: 2904
			public float __ControlPoints828;

			// Token: 0x04000B59 RID: 2905
			public float __ControlPoints829;

			// Token: 0x04000B5A RID: 2906
			public float __ControlPoints830;

			// Token: 0x04000B5B RID: 2907
			public float __ControlPoints831;

			// Token: 0x04000B5C RID: 2908
			public float __ControlPoints832;

			// Token: 0x04000B5D RID: 2909
			public float __ControlPoints833;

			// Token: 0x04000B5E RID: 2910
			public float __ControlPoints834;

			// Token: 0x04000B5F RID: 2911
			public float __ControlPoints835;

			// Token: 0x04000B60 RID: 2912
			public float __ControlPoints836;

			// Token: 0x04000B61 RID: 2913
			public float __ControlPoints837;

			// Token: 0x04000B62 RID: 2914
			public float __ControlPoints838;

			// Token: 0x04000B63 RID: 2915
			public float __ControlPoints839;

			// Token: 0x04000B64 RID: 2916
			public float __ControlPoints840;

			// Token: 0x04000B65 RID: 2917
			public float __ControlPoints841;

			// Token: 0x04000B66 RID: 2918
			public float __ControlPoints842;

			// Token: 0x04000B67 RID: 2919
			public float __ControlPoints843;

			// Token: 0x04000B68 RID: 2920
			public float __ControlPoints844;

			// Token: 0x04000B69 RID: 2921
			public float __ControlPoints845;

			// Token: 0x04000B6A RID: 2922
			public float __ControlPoints846;

			// Token: 0x04000B6B RID: 2923
			public float __ControlPoints847;

			// Token: 0x04000B6C RID: 2924
			public float __ControlPoints848;

			// Token: 0x04000B6D RID: 2925
			public float __ControlPoints849;

			// Token: 0x04000B6E RID: 2926
			public float __ControlPoints850;

			// Token: 0x04000B6F RID: 2927
			public float __ControlPoints851;

			// Token: 0x04000B70 RID: 2928
			public float __ControlPoints852;

			// Token: 0x04000B71 RID: 2929
			public float __ControlPoints853;

			// Token: 0x04000B72 RID: 2930
			public float __ControlPoints854;

			// Token: 0x04000B73 RID: 2931
			public float __ControlPoints855;

			// Token: 0x04000B74 RID: 2932
			public float __ControlPoints856;

			// Token: 0x04000B75 RID: 2933
			public float __ControlPoints857;

			// Token: 0x04000B76 RID: 2934
			public float __ControlPoints858;

			// Token: 0x04000B77 RID: 2935
			public float __ControlPoints859;

			// Token: 0x04000B78 RID: 2936
			public float __ControlPoints860;

			// Token: 0x04000B79 RID: 2937
			public float __ControlPoints861;

			// Token: 0x04000B7A RID: 2938
			public float __ControlPoints862;

			// Token: 0x04000B7B RID: 2939
			public float __ControlPoints863;

			// Token: 0x04000B7C RID: 2940
			public float __ControlPoints864;

			// Token: 0x04000B7D RID: 2941
			public float __ControlPoints865;

			// Token: 0x04000B7E RID: 2942
			public float __ControlPoints866;

			// Token: 0x04000B7F RID: 2943
			public float __ControlPoints867;

			// Token: 0x04000B80 RID: 2944
			public float __ControlPoints868;

			// Token: 0x04000B81 RID: 2945
			public float __ControlPoints869;

			// Token: 0x04000B82 RID: 2946
			public float __ControlPoints870;

			// Token: 0x04000B83 RID: 2947
			public float __ControlPoints871;

			// Token: 0x04000B84 RID: 2948
			public float __ControlPoints872;

			// Token: 0x04000B85 RID: 2949
			public float __ControlPoints873;

			// Token: 0x04000B86 RID: 2950
			public float __ControlPoints874;

			// Token: 0x04000B87 RID: 2951
			public float __ControlPoints875;

			// Token: 0x04000B88 RID: 2952
			public float __ControlPoints876;

			// Token: 0x04000B89 RID: 2953
			public float __ControlPoints877;

			// Token: 0x04000B8A RID: 2954
			public float __ControlPoints878;

			// Token: 0x04000B8B RID: 2955
			public float __ControlPoints879;

			// Token: 0x04000B8C RID: 2956
			public float __ControlPoints880;

			// Token: 0x04000B8D RID: 2957
			public float __ControlPoints881;

			// Token: 0x04000B8E RID: 2958
			public float __ControlPoints882;

			// Token: 0x04000B8F RID: 2959
			public float __ControlPoints883;

			// Token: 0x04000B90 RID: 2960
			public float __ControlPoints884;

			// Token: 0x04000B91 RID: 2961
			public float __ControlPoints885;

			// Token: 0x04000B92 RID: 2962
			public float __ControlPoints886;

			// Token: 0x04000B93 RID: 2963
			public float __ControlPoints887;

			// Token: 0x04000B94 RID: 2964
			public float __ControlPoints888;

			// Token: 0x04000B95 RID: 2965
			public float __ControlPoints889;

			// Token: 0x04000B96 RID: 2966
			public float __ControlPoints890;

			// Token: 0x04000B97 RID: 2967
			public float __ControlPoints891;

			// Token: 0x04000B98 RID: 2968
			public float __ControlPoints892;

			// Token: 0x04000B99 RID: 2969
			public float __ControlPoints893;

			// Token: 0x04000B9A RID: 2970
			public float __ControlPoints894;

			// Token: 0x04000B9B RID: 2971
			public float __ControlPoints895;

			// Token: 0x04000B9C RID: 2972
			public float __ControlPoints896;

			// Token: 0x04000B9D RID: 2973
			public float __ControlPoints897;

			// Token: 0x04000B9E RID: 2974
			public float __ControlPoints898;

			// Token: 0x04000B9F RID: 2975
			public float __ControlPoints899;

			// Token: 0x04000BA0 RID: 2976
			public float __ControlPoints900;

			// Token: 0x04000BA1 RID: 2977
			public float __ControlPoints901;

			// Token: 0x04000BA2 RID: 2978
			public float __ControlPoints902;

			// Token: 0x04000BA3 RID: 2979
			public float __ControlPoints903;

			// Token: 0x04000BA4 RID: 2980
			public float __ControlPoints904;

			// Token: 0x04000BA5 RID: 2981
			public float __ControlPoints905;

			// Token: 0x04000BA6 RID: 2982
			public float __ControlPoints906;

			// Token: 0x04000BA7 RID: 2983
			public float __ControlPoints907;

			// Token: 0x04000BA8 RID: 2984
			public float __ControlPoints908;

			// Token: 0x04000BA9 RID: 2985
			public float __ControlPoints909;

			// Token: 0x04000BAA RID: 2986
			public float __ControlPoints910;

			// Token: 0x04000BAB RID: 2987
			public float __ControlPoints911;

			// Token: 0x04000BAC RID: 2988
			public float __ControlPoints912;

			// Token: 0x04000BAD RID: 2989
			public float __ControlPoints913;

			// Token: 0x04000BAE RID: 2990
			public float __ControlPoints914;

			// Token: 0x04000BAF RID: 2991
			public float __ControlPoints915;

			// Token: 0x04000BB0 RID: 2992
			public float __ControlPoints916;

			// Token: 0x04000BB1 RID: 2993
			public float __ControlPoints917;

			// Token: 0x04000BB2 RID: 2994
			public float __ControlPoints918;

			// Token: 0x04000BB3 RID: 2995
			public float __ControlPoints919;

			// Token: 0x04000BB4 RID: 2996
			public float __ControlPoints920;

			// Token: 0x04000BB5 RID: 2997
			public float __ControlPoints921;

			// Token: 0x04000BB6 RID: 2998
			public float __ControlPoints922;

			// Token: 0x04000BB7 RID: 2999
			public float __ControlPoints923;

			// Token: 0x04000BB8 RID: 3000
			public float __ControlPoints924;

			// Token: 0x04000BB9 RID: 3001
			public float __ControlPoints925;

			// Token: 0x04000BBA RID: 3002
			public float __ControlPoints926;

			// Token: 0x04000BBB RID: 3003
			public float __ControlPoints927;

			// Token: 0x04000BBC RID: 3004
			public float __ControlPoints928;

			// Token: 0x04000BBD RID: 3005
			public float __ControlPoints929;

			// Token: 0x04000BBE RID: 3006
			public float __ControlPoints930;

			// Token: 0x04000BBF RID: 3007
			public float __ControlPoints931;

			// Token: 0x04000BC0 RID: 3008
			public float __ControlPoints932;

			// Token: 0x04000BC1 RID: 3009
			public float __ControlPoints933;

			// Token: 0x04000BC2 RID: 3010
			public float __ControlPoints934;

			// Token: 0x04000BC3 RID: 3011
			public float __ControlPoints935;

			// Token: 0x04000BC4 RID: 3012
			public float __ControlPoints936;

			// Token: 0x04000BC5 RID: 3013
			public float __ControlPoints937;

			// Token: 0x04000BC6 RID: 3014
			public float __ControlPoints938;

			// Token: 0x04000BC7 RID: 3015
			public float __ControlPoints939;

			// Token: 0x04000BC8 RID: 3016
			public float __ControlPoints940;

			// Token: 0x04000BC9 RID: 3017
			public float __ControlPoints941;

			// Token: 0x04000BCA RID: 3018
			public float __ControlPoints942;

			// Token: 0x04000BCB RID: 3019
			public float __ControlPoints943;

			// Token: 0x04000BCC RID: 3020
			public float __ControlPoints944;

			// Token: 0x04000BCD RID: 3021
			public float __ControlPoints945;

			// Token: 0x04000BCE RID: 3022
			public float __ControlPoints946;

			// Token: 0x04000BCF RID: 3023
			public float __ControlPoints947;

			// Token: 0x04000BD0 RID: 3024
			public float __ControlPoints948;

			// Token: 0x04000BD1 RID: 3025
			public float __ControlPoints949;

			// Token: 0x04000BD2 RID: 3026
			public float __ControlPoints950;

			// Token: 0x04000BD3 RID: 3027
			public float __ControlPoints951;

			// Token: 0x04000BD4 RID: 3028
			public float __ControlPoints952;

			// Token: 0x04000BD5 RID: 3029
			public float __ControlPoints953;

			// Token: 0x04000BD6 RID: 3030
			public float __ControlPoints954;

			// Token: 0x04000BD7 RID: 3031
			public float __ControlPoints955;

			// Token: 0x04000BD8 RID: 3032
			public float __ControlPoints956;

			// Token: 0x04000BD9 RID: 3033
			public float __ControlPoints957;

			// Token: 0x04000BDA RID: 3034
			public float __ControlPoints958;

			// Token: 0x04000BDB RID: 3035
			public float __ControlPoints959;

			// Token: 0x04000BDC RID: 3036
			public float __ControlPoints960;

			// Token: 0x04000BDD RID: 3037
			public float __ControlPoints961;

			// Token: 0x04000BDE RID: 3038
			public float __ControlPoints962;

			// Token: 0x04000BDF RID: 3039
			public float __ControlPoints963;

			// Token: 0x04000BE0 RID: 3040
			public float __ControlPoints964;

			// Token: 0x04000BE1 RID: 3041
			public float __ControlPoints965;

			// Token: 0x04000BE2 RID: 3042
			public float __ControlPoints966;

			// Token: 0x04000BE3 RID: 3043
			public float __ControlPoints967;

			// Token: 0x04000BE4 RID: 3044
			public float __ControlPoints968;

			// Token: 0x04000BE5 RID: 3045
			public float __ControlPoints969;

			// Token: 0x04000BE6 RID: 3046
			public float __ControlPoints970;

			// Token: 0x04000BE7 RID: 3047
			public float __ControlPoints971;

			// Token: 0x04000BE8 RID: 3048
			public float __ControlPoints972;

			// Token: 0x04000BE9 RID: 3049
			public float __ControlPoints973;

			// Token: 0x04000BEA RID: 3050
			public float __ControlPoints974;

			// Token: 0x04000BEB RID: 3051
			public float __ControlPoints975;

			// Token: 0x04000BEC RID: 3052
			public float __ControlPoints976;

			// Token: 0x04000BED RID: 3053
			public float __ControlPoints977;

			// Token: 0x04000BEE RID: 3054
			public float __ControlPoints978;

			// Token: 0x04000BEF RID: 3055
			public float __ControlPoints979;

			// Token: 0x04000BF0 RID: 3056
			public float __ControlPoints980;

			// Token: 0x04000BF1 RID: 3057
			public float __ControlPoints981;

			// Token: 0x04000BF2 RID: 3058
			public float __ControlPoints982;

			// Token: 0x04000BF3 RID: 3059
			public float __ControlPoints983;

			// Token: 0x04000BF4 RID: 3060
			public float __ControlPoints984;

			// Token: 0x04000BF5 RID: 3061
			public float __ControlPoints985;

			// Token: 0x04000BF6 RID: 3062
			public float __ControlPoints986;

			// Token: 0x04000BF7 RID: 3063
			public float __ControlPoints987;

			// Token: 0x04000BF8 RID: 3064
			public float __ControlPoints988;

			// Token: 0x04000BF9 RID: 3065
			public float __ControlPoints989;

			// Token: 0x04000BFA RID: 3066
			public float __ControlPoints990;

			// Token: 0x04000BFB RID: 3067
			public float __ControlPoints991;

			// Token: 0x04000BFC RID: 3068
			public float __ControlPoints992;

			// Token: 0x04000BFD RID: 3069
			public float __ControlPoints993;

			// Token: 0x04000BFE RID: 3070
			public float __ControlPoints994;

			// Token: 0x04000BFF RID: 3071
			public float __ControlPoints995;

			// Token: 0x04000C00 RID: 3072
			public float __ControlPoints996;

			// Token: 0x04000C01 RID: 3073
			public float __ControlPoints997;

			// Token: 0x04000C02 RID: 3074
			public float __ControlPoints998;

			// Token: 0x04000C03 RID: 3075
			public float __ControlPoints999;

			// Token: 0x04000C04 RID: 3076
			public float __ControlPoints1000;

			// Token: 0x04000C05 RID: 3077
			public float __ControlPoints1001;

			// Token: 0x04000C06 RID: 3078
			public float __ControlPoints1002;

			// Token: 0x04000C07 RID: 3079
			public float __ControlPoints1003;

			// Token: 0x04000C08 RID: 3080
			public float __ControlPoints1004;

			// Token: 0x04000C09 RID: 3081
			public float __ControlPoints1005;

			// Token: 0x04000C0A RID: 3082
			public float __ControlPoints1006;

			// Token: 0x04000C0B RID: 3083
			public float __ControlPoints1007;

			// Token: 0x04000C0C RID: 3084
			public float __ControlPoints1008;

			// Token: 0x04000C0D RID: 3085
			public float __ControlPoints1009;

			// Token: 0x04000C0E RID: 3086
			public float __ControlPoints1010;

			// Token: 0x04000C0F RID: 3087
			public float __ControlPoints1011;

			// Token: 0x04000C10 RID: 3088
			public float __ControlPoints1012;

			// Token: 0x04000C11 RID: 3089
			public float __ControlPoints1013;

			// Token: 0x04000C12 RID: 3090
			public float __ControlPoints1014;

			// Token: 0x04000C13 RID: 3091
			public float __ControlPoints1015;

			// Token: 0x04000C14 RID: 3092
			public float __ControlPoints1016;

			// Token: 0x04000C15 RID: 3093
			public float __ControlPoints1017;

			// Token: 0x04000C16 RID: 3094
			public float __ControlPoints1018;

			// Token: 0x04000C17 RID: 3095
			public float __ControlPoints1019;

			// Token: 0x04000C18 RID: 3096
			public float __ControlPoints1020;

			// Token: 0x04000C19 RID: 3097
			public float __ControlPoints1021;

			// Token: 0x04000C1A RID: 3098
			public float __ControlPoints1022;

			// Token: 0x04000C1B RID: 3099
			public float __ControlPoints1023;

			// Token: 0x04000C1C RID: 3100
			public float __ControlPoints1024;
		}
	}
}
