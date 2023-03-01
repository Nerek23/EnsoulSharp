using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000087 RID: 135
	public struct JpegAcHuffmanTable
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600020F RID: 527 RVA: 0x000084A4 File Offset: 0x000066A4
		// (set) Token: 0x06000210 RID: 528 RVA: 0x000084CB File Offset: 0x000066CB
		public byte[] CodeCounts
		{
			get
			{
				byte[] result;
				if ((result = this._CodeCounts) == null)
				{
					result = (this._CodeCounts = new byte[16]);
				}
				return result;
			}
			private set
			{
				this._CodeCounts = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000211 RID: 529 RVA: 0x000084D4 File Offset: 0x000066D4
		// (set) Token: 0x06000212 RID: 530 RVA: 0x000084FE File Offset: 0x000066FE
		public byte[] CodeValues
		{
			get
			{
				byte[] result;
				if ((result = this._CodeValues) == null)
				{
					result = (this._CodeValues = new byte[162]);
				}
				return result;
			}
			private set
			{
				this._CodeValues = value;
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref JpegAcHuffmanTable.__Native @ref)
		{
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00008508 File Offset: 0x00006708
		internal unsafe void __MarshalFrom(ref JpegAcHuffmanTable.__Native @ref)
		{
			fixed (byte* ptr = &this.CodeCounts[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.CodeCounts)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 16);
					ptr = null;
				}
				fixed (byte* ptr2 = &this.CodeValues[0])
				{
					void* value3 = (void*)ptr2;
					fixed (byte* ptr = &@ref.CodeValues)
					{
						void* value4 = (void*)ptr;
						Utilities.CopyMemory((IntPtr)value3, (IntPtr)value4, 162);
						ptr2 = null;
					}
				}
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00008584 File Offset: 0x00006784
		internal unsafe void __MarshalTo(ref JpegAcHuffmanTable.__Native @ref)
		{
			fixed (byte* ptr = &this.CodeCounts[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.CodeCounts)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 16);
					ptr = null;
				}
				fixed (byte* ptr2 = &this.CodeValues[0])
				{
					void* value3 = (void*)ptr2;
					fixed (byte* ptr = &@ref.CodeValues)
					{
						void* value4 = (void*)ptr;
						Utilities.CopyMemory((IntPtr)value4, (IntPtr)value3, 162);
						ptr2 = null;
					}
				}
			}
		}

		// Token: 0x04000C45 RID: 3141
		internal byte[] _CodeCounts;

		// Token: 0x04000C46 RID: 3142
		internal byte[] _CodeValues;

		// Token: 0x02000088 RID: 136
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000C47 RID: 3143
			public byte CodeCounts;

			// Token: 0x04000C48 RID: 3144
			public byte __CodeCounts1;

			// Token: 0x04000C49 RID: 3145
			public byte __CodeCounts2;

			// Token: 0x04000C4A RID: 3146
			public byte __CodeCounts3;

			// Token: 0x04000C4B RID: 3147
			public byte __CodeCounts4;

			// Token: 0x04000C4C RID: 3148
			public byte __CodeCounts5;

			// Token: 0x04000C4D RID: 3149
			public byte __CodeCounts6;

			// Token: 0x04000C4E RID: 3150
			public byte __CodeCounts7;

			// Token: 0x04000C4F RID: 3151
			public byte __CodeCounts8;

			// Token: 0x04000C50 RID: 3152
			public byte __CodeCounts9;

			// Token: 0x04000C51 RID: 3153
			public byte __CodeCounts10;

			// Token: 0x04000C52 RID: 3154
			public byte __CodeCounts11;

			// Token: 0x04000C53 RID: 3155
			public byte __CodeCounts12;

			// Token: 0x04000C54 RID: 3156
			public byte __CodeCounts13;

			// Token: 0x04000C55 RID: 3157
			public byte __CodeCounts14;

			// Token: 0x04000C56 RID: 3158
			public byte __CodeCounts15;

			// Token: 0x04000C57 RID: 3159
			public byte CodeValues;

			// Token: 0x04000C58 RID: 3160
			public byte __CodeValues1;

			// Token: 0x04000C59 RID: 3161
			public byte __CodeValues2;

			// Token: 0x04000C5A RID: 3162
			public byte __CodeValues3;

			// Token: 0x04000C5B RID: 3163
			public byte __CodeValues4;

			// Token: 0x04000C5C RID: 3164
			public byte __CodeValues5;

			// Token: 0x04000C5D RID: 3165
			public byte __CodeValues6;

			// Token: 0x04000C5E RID: 3166
			public byte __CodeValues7;

			// Token: 0x04000C5F RID: 3167
			public byte __CodeValues8;

			// Token: 0x04000C60 RID: 3168
			public byte __CodeValues9;

			// Token: 0x04000C61 RID: 3169
			public byte __CodeValues10;

			// Token: 0x04000C62 RID: 3170
			public byte __CodeValues11;

			// Token: 0x04000C63 RID: 3171
			public byte __CodeValues12;

			// Token: 0x04000C64 RID: 3172
			public byte __CodeValues13;

			// Token: 0x04000C65 RID: 3173
			public byte __CodeValues14;

			// Token: 0x04000C66 RID: 3174
			public byte __CodeValues15;

			// Token: 0x04000C67 RID: 3175
			public byte __CodeValues16;

			// Token: 0x04000C68 RID: 3176
			public byte __CodeValues17;

			// Token: 0x04000C69 RID: 3177
			public byte __CodeValues18;

			// Token: 0x04000C6A RID: 3178
			public byte __CodeValues19;

			// Token: 0x04000C6B RID: 3179
			public byte __CodeValues20;

			// Token: 0x04000C6C RID: 3180
			public byte __CodeValues21;

			// Token: 0x04000C6D RID: 3181
			public byte __CodeValues22;

			// Token: 0x04000C6E RID: 3182
			public byte __CodeValues23;

			// Token: 0x04000C6F RID: 3183
			public byte __CodeValues24;

			// Token: 0x04000C70 RID: 3184
			public byte __CodeValues25;

			// Token: 0x04000C71 RID: 3185
			public byte __CodeValues26;

			// Token: 0x04000C72 RID: 3186
			public byte __CodeValues27;

			// Token: 0x04000C73 RID: 3187
			public byte __CodeValues28;

			// Token: 0x04000C74 RID: 3188
			public byte __CodeValues29;

			// Token: 0x04000C75 RID: 3189
			public byte __CodeValues30;

			// Token: 0x04000C76 RID: 3190
			public byte __CodeValues31;

			// Token: 0x04000C77 RID: 3191
			public byte __CodeValues32;

			// Token: 0x04000C78 RID: 3192
			public byte __CodeValues33;

			// Token: 0x04000C79 RID: 3193
			public byte __CodeValues34;

			// Token: 0x04000C7A RID: 3194
			public byte __CodeValues35;

			// Token: 0x04000C7B RID: 3195
			public byte __CodeValues36;

			// Token: 0x04000C7C RID: 3196
			public byte __CodeValues37;

			// Token: 0x04000C7D RID: 3197
			public byte __CodeValues38;

			// Token: 0x04000C7E RID: 3198
			public byte __CodeValues39;

			// Token: 0x04000C7F RID: 3199
			public byte __CodeValues40;

			// Token: 0x04000C80 RID: 3200
			public byte __CodeValues41;

			// Token: 0x04000C81 RID: 3201
			public byte __CodeValues42;

			// Token: 0x04000C82 RID: 3202
			public byte __CodeValues43;

			// Token: 0x04000C83 RID: 3203
			public byte __CodeValues44;

			// Token: 0x04000C84 RID: 3204
			public byte __CodeValues45;

			// Token: 0x04000C85 RID: 3205
			public byte __CodeValues46;

			// Token: 0x04000C86 RID: 3206
			public byte __CodeValues47;

			// Token: 0x04000C87 RID: 3207
			public byte __CodeValues48;

			// Token: 0x04000C88 RID: 3208
			public byte __CodeValues49;

			// Token: 0x04000C89 RID: 3209
			public byte __CodeValues50;

			// Token: 0x04000C8A RID: 3210
			public byte __CodeValues51;

			// Token: 0x04000C8B RID: 3211
			public byte __CodeValues52;

			// Token: 0x04000C8C RID: 3212
			public byte __CodeValues53;

			// Token: 0x04000C8D RID: 3213
			public byte __CodeValues54;

			// Token: 0x04000C8E RID: 3214
			public byte __CodeValues55;

			// Token: 0x04000C8F RID: 3215
			public byte __CodeValues56;

			// Token: 0x04000C90 RID: 3216
			public byte __CodeValues57;

			// Token: 0x04000C91 RID: 3217
			public byte __CodeValues58;

			// Token: 0x04000C92 RID: 3218
			public byte __CodeValues59;

			// Token: 0x04000C93 RID: 3219
			public byte __CodeValues60;

			// Token: 0x04000C94 RID: 3220
			public byte __CodeValues61;

			// Token: 0x04000C95 RID: 3221
			public byte __CodeValues62;

			// Token: 0x04000C96 RID: 3222
			public byte __CodeValues63;

			// Token: 0x04000C97 RID: 3223
			public byte __CodeValues64;

			// Token: 0x04000C98 RID: 3224
			public byte __CodeValues65;

			// Token: 0x04000C99 RID: 3225
			public byte __CodeValues66;

			// Token: 0x04000C9A RID: 3226
			public byte __CodeValues67;

			// Token: 0x04000C9B RID: 3227
			public byte __CodeValues68;

			// Token: 0x04000C9C RID: 3228
			public byte __CodeValues69;

			// Token: 0x04000C9D RID: 3229
			public byte __CodeValues70;

			// Token: 0x04000C9E RID: 3230
			public byte __CodeValues71;

			// Token: 0x04000C9F RID: 3231
			public byte __CodeValues72;

			// Token: 0x04000CA0 RID: 3232
			public byte __CodeValues73;

			// Token: 0x04000CA1 RID: 3233
			public byte __CodeValues74;

			// Token: 0x04000CA2 RID: 3234
			public byte __CodeValues75;

			// Token: 0x04000CA3 RID: 3235
			public byte __CodeValues76;

			// Token: 0x04000CA4 RID: 3236
			public byte __CodeValues77;

			// Token: 0x04000CA5 RID: 3237
			public byte __CodeValues78;

			// Token: 0x04000CA6 RID: 3238
			public byte __CodeValues79;

			// Token: 0x04000CA7 RID: 3239
			public byte __CodeValues80;

			// Token: 0x04000CA8 RID: 3240
			public byte __CodeValues81;

			// Token: 0x04000CA9 RID: 3241
			public byte __CodeValues82;

			// Token: 0x04000CAA RID: 3242
			public byte __CodeValues83;

			// Token: 0x04000CAB RID: 3243
			public byte __CodeValues84;

			// Token: 0x04000CAC RID: 3244
			public byte __CodeValues85;

			// Token: 0x04000CAD RID: 3245
			public byte __CodeValues86;

			// Token: 0x04000CAE RID: 3246
			public byte __CodeValues87;

			// Token: 0x04000CAF RID: 3247
			public byte __CodeValues88;

			// Token: 0x04000CB0 RID: 3248
			public byte __CodeValues89;

			// Token: 0x04000CB1 RID: 3249
			public byte __CodeValues90;

			// Token: 0x04000CB2 RID: 3250
			public byte __CodeValues91;

			// Token: 0x04000CB3 RID: 3251
			public byte __CodeValues92;

			// Token: 0x04000CB4 RID: 3252
			public byte __CodeValues93;

			// Token: 0x04000CB5 RID: 3253
			public byte __CodeValues94;

			// Token: 0x04000CB6 RID: 3254
			public byte __CodeValues95;

			// Token: 0x04000CB7 RID: 3255
			public byte __CodeValues96;

			// Token: 0x04000CB8 RID: 3256
			public byte __CodeValues97;

			// Token: 0x04000CB9 RID: 3257
			public byte __CodeValues98;

			// Token: 0x04000CBA RID: 3258
			public byte __CodeValues99;

			// Token: 0x04000CBB RID: 3259
			public byte __CodeValues100;

			// Token: 0x04000CBC RID: 3260
			public byte __CodeValues101;

			// Token: 0x04000CBD RID: 3261
			public byte __CodeValues102;

			// Token: 0x04000CBE RID: 3262
			public byte __CodeValues103;

			// Token: 0x04000CBF RID: 3263
			public byte __CodeValues104;

			// Token: 0x04000CC0 RID: 3264
			public byte __CodeValues105;

			// Token: 0x04000CC1 RID: 3265
			public byte __CodeValues106;

			// Token: 0x04000CC2 RID: 3266
			public byte __CodeValues107;

			// Token: 0x04000CC3 RID: 3267
			public byte __CodeValues108;

			// Token: 0x04000CC4 RID: 3268
			public byte __CodeValues109;

			// Token: 0x04000CC5 RID: 3269
			public byte __CodeValues110;

			// Token: 0x04000CC6 RID: 3270
			public byte __CodeValues111;

			// Token: 0x04000CC7 RID: 3271
			public byte __CodeValues112;

			// Token: 0x04000CC8 RID: 3272
			public byte __CodeValues113;

			// Token: 0x04000CC9 RID: 3273
			public byte __CodeValues114;

			// Token: 0x04000CCA RID: 3274
			public byte __CodeValues115;

			// Token: 0x04000CCB RID: 3275
			public byte __CodeValues116;

			// Token: 0x04000CCC RID: 3276
			public byte __CodeValues117;

			// Token: 0x04000CCD RID: 3277
			public byte __CodeValues118;

			// Token: 0x04000CCE RID: 3278
			public byte __CodeValues119;

			// Token: 0x04000CCF RID: 3279
			public byte __CodeValues120;

			// Token: 0x04000CD0 RID: 3280
			public byte __CodeValues121;

			// Token: 0x04000CD1 RID: 3281
			public byte __CodeValues122;

			// Token: 0x04000CD2 RID: 3282
			public byte __CodeValues123;

			// Token: 0x04000CD3 RID: 3283
			public byte __CodeValues124;

			// Token: 0x04000CD4 RID: 3284
			public byte __CodeValues125;

			// Token: 0x04000CD5 RID: 3285
			public byte __CodeValues126;

			// Token: 0x04000CD6 RID: 3286
			public byte __CodeValues127;

			// Token: 0x04000CD7 RID: 3287
			public byte __CodeValues128;

			// Token: 0x04000CD8 RID: 3288
			public byte __CodeValues129;

			// Token: 0x04000CD9 RID: 3289
			public byte __CodeValues130;

			// Token: 0x04000CDA RID: 3290
			public byte __CodeValues131;

			// Token: 0x04000CDB RID: 3291
			public byte __CodeValues132;

			// Token: 0x04000CDC RID: 3292
			public byte __CodeValues133;

			// Token: 0x04000CDD RID: 3293
			public byte __CodeValues134;

			// Token: 0x04000CDE RID: 3294
			public byte __CodeValues135;

			// Token: 0x04000CDF RID: 3295
			public byte __CodeValues136;

			// Token: 0x04000CE0 RID: 3296
			public byte __CodeValues137;

			// Token: 0x04000CE1 RID: 3297
			public byte __CodeValues138;

			// Token: 0x04000CE2 RID: 3298
			public byte __CodeValues139;

			// Token: 0x04000CE3 RID: 3299
			public byte __CodeValues140;

			// Token: 0x04000CE4 RID: 3300
			public byte __CodeValues141;

			// Token: 0x04000CE5 RID: 3301
			public byte __CodeValues142;

			// Token: 0x04000CE6 RID: 3302
			public byte __CodeValues143;

			// Token: 0x04000CE7 RID: 3303
			public byte __CodeValues144;

			// Token: 0x04000CE8 RID: 3304
			public byte __CodeValues145;

			// Token: 0x04000CE9 RID: 3305
			public byte __CodeValues146;

			// Token: 0x04000CEA RID: 3306
			public byte __CodeValues147;

			// Token: 0x04000CEB RID: 3307
			public byte __CodeValues148;

			// Token: 0x04000CEC RID: 3308
			public byte __CodeValues149;

			// Token: 0x04000CED RID: 3309
			public byte __CodeValues150;

			// Token: 0x04000CEE RID: 3310
			public byte __CodeValues151;

			// Token: 0x04000CEF RID: 3311
			public byte __CodeValues152;

			// Token: 0x04000CF0 RID: 3312
			public byte __CodeValues153;

			// Token: 0x04000CF1 RID: 3313
			public byte __CodeValues154;

			// Token: 0x04000CF2 RID: 3314
			public byte __CodeValues155;

			// Token: 0x04000CF3 RID: 3315
			public byte __CodeValues156;

			// Token: 0x04000CF4 RID: 3316
			public byte __CodeValues157;

			// Token: 0x04000CF5 RID: 3317
			public byte __CodeValues158;

			// Token: 0x04000CF6 RID: 3318
			public byte __CodeValues159;

			// Token: 0x04000CF7 RID: 3319
			public byte __CodeValues160;

			// Token: 0x04000CF8 RID: 3320
			public byte __CodeValues161;
		}
	}
}
