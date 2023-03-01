using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000007 RID: 7
	public class AdapterDetails
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000020DF File Offset: 0x000002DF
		public bool Certified
		{
			get
			{
				return this.WhqlLevel != 0;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000020EC File Offset: 0x000002EC
		public Version DriverVersion
		{
			get
			{
				return new Version((int)(this.RawDriverVersion >> 48) & 65535, (int)(this.RawDriverVersion >> 32) & 65535, (int)(this.RawDriverVersion >> 16) & 65535, (int)this.RawDriverVersion & 65535);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000213C File Offset: 0x0000033C
		public DateTime CertificationDate
		{
			get
			{
				if (this.WhqlLevel == 0)
				{
					return DateTime.MaxValue;
				}
				if (this.WhqlLevel != 1)
				{
					return new DateTime(1999 + (this.WhqlLevel >> 16), (this.WhqlLevel & 65280) >> 8, this.WhqlLevel & 255);
				}
				return DateTime.MinValue;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002194 File Offset: 0x00000394
		internal void __MarshalFree(ref AdapterDetails.__Native @ref)
		{
			@ref.__MarshalFree();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000219C File Offset: 0x0000039C
		internal unsafe void __MarshalFrom(ref AdapterDetails.__Native @ref)
		{
			fixed (byte* ptr = &@ref.Driver)
			{
				void* value = (void*)ptr;
				this.Driver = Utilities.PtrToStringAnsi((IntPtr)value, 512);
			}
			fixed (byte* ptr = &@ref.Description)
			{
				void* value2 = (void*)ptr;
				this.Description = Utilities.PtrToStringAnsi((IntPtr)value2, 512);
			}
			fixed (byte* ptr = &@ref.DeviceName)
			{
				void* value3 = (void*)ptr;
				this.DeviceName = Utilities.PtrToStringAnsi((IntPtr)value3, 32);
			}
			this.RawDriverVersion = @ref.RawDriverVersion;
			this.VendorId = @ref.VendorId;
			this.DeviceId = @ref.DeviceId;
			this.SubsystemId = @ref.SubsystemId;
			this.Revision = @ref.Revision;
			this.DeviceIdentifier = @ref.DeviceIdentifier;
			this.WhqlLevel = @ref.WhqlLevel;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002264 File Offset: 0x00000464
		internal unsafe void __MarshalTo(ref AdapterDetails.__Native @ref)
		{
			IntPtr intPtr = Utilities.StringToHGlobalAnsi(this.Driver);
			fixed (byte* ptr = &@ref.Driver)
			{
				void* value = (void*)ptr;
				Utilities.CopyMemory((IntPtr)value, intPtr, this.Driver.Length);
			}
			Marshal.FreeHGlobal(intPtr);
			IntPtr intPtr2 = Utilities.StringToHGlobalAnsi(this.Description);
			fixed (byte* ptr = &@ref.Description)
			{
				void* value2 = (void*)ptr;
				Utilities.CopyMemory((IntPtr)value2, intPtr2, this.Description.Length);
			}
			Marshal.FreeHGlobal(intPtr2);
			IntPtr intPtr3 = Utilities.StringToHGlobalAnsi(this.DeviceName);
			fixed (byte* ptr = &@ref.DeviceName)
			{
				void* value3 = (void*)ptr;
				Utilities.CopyMemory((IntPtr)value3, intPtr3, this.DeviceName.Length);
			}
			Marshal.FreeHGlobal(intPtr3);
			@ref.RawDriverVersion = this.RawDriverVersion;
			@ref.VendorId = this.VendorId;
			@ref.DeviceId = this.DeviceId;
			@ref.SubsystemId = this.SubsystemId;
			@ref.Revision = this.Revision;
			@ref.DeviceIdentifier = this.DeviceIdentifier;
			@ref.WhqlLevel = this.WhqlLevel;
		}

		// Token: 0x0400001D RID: 29
		public string Driver;

		// Token: 0x0400001E RID: 30
		public string Description;

		// Token: 0x0400001F RID: 31
		public string DeviceName;

		// Token: 0x04000020 RID: 32
		internal long RawDriverVersion;

		// Token: 0x04000021 RID: 33
		public int VendorId;

		// Token: 0x04000022 RID: 34
		public int DeviceId;

		// Token: 0x04000023 RID: 35
		public int SubsystemId;

		// Token: 0x04000024 RID: 36
		public int Revision;

		// Token: 0x04000025 RID: 37
		public Guid DeviceIdentifier;

		// Token: 0x04000026 RID: 38
		public int WhqlLevel;

		// Token: 0x02000008 RID: 8
		internal struct __Native
		{
			// Token: 0x06000021 RID: 33 RVA: 0x00002374 File Offset: 0x00000574
			internal void __MarshalFree()
			{
			}

			// Token: 0x04000027 RID: 39
			public byte Driver;

			// Token: 0x04000028 RID: 40
			private byte __Driver1;

			// Token: 0x04000029 RID: 41
			private byte __Driver2;

			// Token: 0x0400002A RID: 42
			private byte __Driver3;

			// Token: 0x0400002B RID: 43
			private byte __Driver4;

			// Token: 0x0400002C RID: 44
			private byte __Driver5;

			// Token: 0x0400002D RID: 45
			private byte __Driver6;

			// Token: 0x0400002E RID: 46
			private byte __Driver7;

			// Token: 0x0400002F RID: 47
			private byte __Driver8;

			// Token: 0x04000030 RID: 48
			private byte __Driver9;

			// Token: 0x04000031 RID: 49
			private byte __Driver10;

			// Token: 0x04000032 RID: 50
			private byte __Driver11;

			// Token: 0x04000033 RID: 51
			private byte __Driver12;

			// Token: 0x04000034 RID: 52
			private byte __Driver13;

			// Token: 0x04000035 RID: 53
			private byte __Driver14;

			// Token: 0x04000036 RID: 54
			private byte __Driver15;

			// Token: 0x04000037 RID: 55
			private byte __Driver16;

			// Token: 0x04000038 RID: 56
			private byte __Driver17;

			// Token: 0x04000039 RID: 57
			private byte __Driver18;

			// Token: 0x0400003A RID: 58
			private byte __Driver19;

			// Token: 0x0400003B RID: 59
			private byte __Driver20;

			// Token: 0x0400003C RID: 60
			private byte __Driver21;

			// Token: 0x0400003D RID: 61
			private byte __Driver22;

			// Token: 0x0400003E RID: 62
			private byte __Driver23;

			// Token: 0x0400003F RID: 63
			private byte __Driver24;

			// Token: 0x04000040 RID: 64
			private byte __Driver25;

			// Token: 0x04000041 RID: 65
			private byte __Driver26;

			// Token: 0x04000042 RID: 66
			private byte __Driver27;

			// Token: 0x04000043 RID: 67
			private byte __Driver28;

			// Token: 0x04000044 RID: 68
			private byte __Driver29;

			// Token: 0x04000045 RID: 69
			private byte __Driver30;

			// Token: 0x04000046 RID: 70
			private byte __Driver31;

			// Token: 0x04000047 RID: 71
			private byte __Driver32;

			// Token: 0x04000048 RID: 72
			private byte __Driver33;

			// Token: 0x04000049 RID: 73
			private byte __Driver34;

			// Token: 0x0400004A RID: 74
			private byte __Driver35;

			// Token: 0x0400004B RID: 75
			private byte __Driver36;

			// Token: 0x0400004C RID: 76
			private byte __Driver37;

			// Token: 0x0400004D RID: 77
			private byte __Driver38;

			// Token: 0x0400004E RID: 78
			private byte __Driver39;

			// Token: 0x0400004F RID: 79
			private byte __Driver40;

			// Token: 0x04000050 RID: 80
			private byte __Driver41;

			// Token: 0x04000051 RID: 81
			private byte __Driver42;

			// Token: 0x04000052 RID: 82
			private byte __Driver43;

			// Token: 0x04000053 RID: 83
			private byte __Driver44;

			// Token: 0x04000054 RID: 84
			private byte __Driver45;

			// Token: 0x04000055 RID: 85
			private byte __Driver46;

			// Token: 0x04000056 RID: 86
			private byte __Driver47;

			// Token: 0x04000057 RID: 87
			private byte __Driver48;

			// Token: 0x04000058 RID: 88
			private byte __Driver49;

			// Token: 0x04000059 RID: 89
			private byte __Driver50;

			// Token: 0x0400005A RID: 90
			private byte __Driver51;

			// Token: 0x0400005B RID: 91
			private byte __Driver52;

			// Token: 0x0400005C RID: 92
			private byte __Driver53;

			// Token: 0x0400005D RID: 93
			private byte __Driver54;

			// Token: 0x0400005E RID: 94
			private byte __Driver55;

			// Token: 0x0400005F RID: 95
			private byte __Driver56;

			// Token: 0x04000060 RID: 96
			private byte __Driver57;

			// Token: 0x04000061 RID: 97
			private byte __Driver58;

			// Token: 0x04000062 RID: 98
			private byte __Driver59;

			// Token: 0x04000063 RID: 99
			private byte __Driver60;

			// Token: 0x04000064 RID: 100
			private byte __Driver61;

			// Token: 0x04000065 RID: 101
			private byte __Driver62;

			// Token: 0x04000066 RID: 102
			private byte __Driver63;

			// Token: 0x04000067 RID: 103
			private byte __Driver64;

			// Token: 0x04000068 RID: 104
			private byte __Driver65;

			// Token: 0x04000069 RID: 105
			private byte __Driver66;

			// Token: 0x0400006A RID: 106
			private byte __Driver67;

			// Token: 0x0400006B RID: 107
			private byte __Driver68;

			// Token: 0x0400006C RID: 108
			private byte __Driver69;

			// Token: 0x0400006D RID: 109
			private byte __Driver70;

			// Token: 0x0400006E RID: 110
			private byte __Driver71;

			// Token: 0x0400006F RID: 111
			private byte __Driver72;

			// Token: 0x04000070 RID: 112
			private byte __Driver73;

			// Token: 0x04000071 RID: 113
			private byte __Driver74;

			// Token: 0x04000072 RID: 114
			private byte __Driver75;

			// Token: 0x04000073 RID: 115
			private byte __Driver76;

			// Token: 0x04000074 RID: 116
			private byte __Driver77;

			// Token: 0x04000075 RID: 117
			private byte __Driver78;

			// Token: 0x04000076 RID: 118
			private byte __Driver79;

			// Token: 0x04000077 RID: 119
			private byte __Driver80;

			// Token: 0x04000078 RID: 120
			private byte __Driver81;

			// Token: 0x04000079 RID: 121
			private byte __Driver82;

			// Token: 0x0400007A RID: 122
			private byte __Driver83;

			// Token: 0x0400007B RID: 123
			private byte __Driver84;

			// Token: 0x0400007C RID: 124
			private byte __Driver85;

			// Token: 0x0400007D RID: 125
			private byte __Driver86;

			// Token: 0x0400007E RID: 126
			private byte __Driver87;

			// Token: 0x0400007F RID: 127
			private byte __Driver88;

			// Token: 0x04000080 RID: 128
			private byte __Driver89;

			// Token: 0x04000081 RID: 129
			private byte __Driver90;

			// Token: 0x04000082 RID: 130
			private byte __Driver91;

			// Token: 0x04000083 RID: 131
			private byte __Driver92;

			// Token: 0x04000084 RID: 132
			private byte __Driver93;

			// Token: 0x04000085 RID: 133
			private byte __Driver94;

			// Token: 0x04000086 RID: 134
			private byte __Driver95;

			// Token: 0x04000087 RID: 135
			private byte __Driver96;

			// Token: 0x04000088 RID: 136
			private byte __Driver97;

			// Token: 0x04000089 RID: 137
			private byte __Driver98;

			// Token: 0x0400008A RID: 138
			private byte __Driver99;

			// Token: 0x0400008B RID: 139
			private byte __Driver100;

			// Token: 0x0400008C RID: 140
			private byte __Driver101;

			// Token: 0x0400008D RID: 141
			private byte __Driver102;

			// Token: 0x0400008E RID: 142
			private byte __Driver103;

			// Token: 0x0400008F RID: 143
			private byte __Driver104;

			// Token: 0x04000090 RID: 144
			private byte __Driver105;

			// Token: 0x04000091 RID: 145
			private byte __Driver106;

			// Token: 0x04000092 RID: 146
			private byte __Driver107;

			// Token: 0x04000093 RID: 147
			private byte __Driver108;

			// Token: 0x04000094 RID: 148
			private byte __Driver109;

			// Token: 0x04000095 RID: 149
			private byte __Driver110;

			// Token: 0x04000096 RID: 150
			private byte __Driver111;

			// Token: 0x04000097 RID: 151
			private byte __Driver112;

			// Token: 0x04000098 RID: 152
			private byte __Driver113;

			// Token: 0x04000099 RID: 153
			private byte __Driver114;

			// Token: 0x0400009A RID: 154
			private byte __Driver115;

			// Token: 0x0400009B RID: 155
			private byte __Driver116;

			// Token: 0x0400009C RID: 156
			private byte __Driver117;

			// Token: 0x0400009D RID: 157
			private byte __Driver118;

			// Token: 0x0400009E RID: 158
			private byte __Driver119;

			// Token: 0x0400009F RID: 159
			private byte __Driver120;

			// Token: 0x040000A0 RID: 160
			private byte __Driver121;

			// Token: 0x040000A1 RID: 161
			private byte __Driver122;

			// Token: 0x040000A2 RID: 162
			private byte __Driver123;

			// Token: 0x040000A3 RID: 163
			private byte __Driver124;

			// Token: 0x040000A4 RID: 164
			private byte __Driver125;

			// Token: 0x040000A5 RID: 165
			private byte __Driver126;

			// Token: 0x040000A6 RID: 166
			private byte __Driver127;

			// Token: 0x040000A7 RID: 167
			private byte __Driver128;

			// Token: 0x040000A8 RID: 168
			private byte __Driver129;

			// Token: 0x040000A9 RID: 169
			private byte __Driver130;

			// Token: 0x040000AA RID: 170
			private byte __Driver131;

			// Token: 0x040000AB RID: 171
			private byte __Driver132;

			// Token: 0x040000AC RID: 172
			private byte __Driver133;

			// Token: 0x040000AD RID: 173
			private byte __Driver134;

			// Token: 0x040000AE RID: 174
			private byte __Driver135;

			// Token: 0x040000AF RID: 175
			private byte __Driver136;

			// Token: 0x040000B0 RID: 176
			private byte __Driver137;

			// Token: 0x040000B1 RID: 177
			private byte __Driver138;

			// Token: 0x040000B2 RID: 178
			private byte __Driver139;

			// Token: 0x040000B3 RID: 179
			private byte __Driver140;

			// Token: 0x040000B4 RID: 180
			private byte __Driver141;

			// Token: 0x040000B5 RID: 181
			private byte __Driver142;

			// Token: 0x040000B6 RID: 182
			private byte __Driver143;

			// Token: 0x040000B7 RID: 183
			private byte __Driver144;

			// Token: 0x040000B8 RID: 184
			private byte __Driver145;

			// Token: 0x040000B9 RID: 185
			private byte __Driver146;

			// Token: 0x040000BA RID: 186
			private byte __Driver147;

			// Token: 0x040000BB RID: 187
			private byte __Driver148;

			// Token: 0x040000BC RID: 188
			private byte __Driver149;

			// Token: 0x040000BD RID: 189
			private byte __Driver150;

			// Token: 0x040000BE RID: 190
			private byte __Driver151;

			// Token: 0x040000BF RID: 191
			private byte __Driver152;

			// Token: 0x040000C0 RID: 192
			private byte __Driver153;

			// Token: 0x040000C1 RID: 193
			private byte __Driver154;

			// Token: 0x040000C2 RID: 194
			private byte __Driver155;

			// Token: 0x040000C3 RID: 195
			private byte __Driver156;

			// Token: 0x040000C4 RID: 196
			private byte __Driver157;

			// Token: 0x040000C5 RID: 197
			private byte __Driver158;

			// Token: 0x040000C6 RID: 198
			private byte __Driver159;

			// Token: 0x040000C7 RID: 199
			private byte __Driver160;

			// Token: 0x040000C8 RID: 200
			private byte __Driver161;

			// Token: 0x040000C9 RID: 201
			private byte __Driver162;

			// Token: 0x040000CA RID: 202
			private byte __Driver163;

			// Token: 0x040000CB RID: 203
			private byte __Driver164;

			// Token: 0x040000CC RID: 204
			private byte __Driver165;

			// Token: 0x040000CD RID: 205
			private byte __Driver166;

			// Token: 0x040000CE RID: 206
			private byte __Driver167;

			// Token: 0x040000CF RID: 207
			private byte __Driver168;

			// Token: 0x040000D0 RID: 208
			private byte __Driver169;

			// Token: 0x040000D1 RID: 209
			private byte __Driver170;

			// Token: 0x040000D2 RID: 210
			private byte __Driver171;

			// Token: 0x040000D3 RID: 211
			private byte __Driver172;

			// Token: 0x040000D4 RID: 212
			private byte __Driver173;

			// Token: 0x040000D5 RID: 213
			private byte __Driver174;

			// Token: 0x040000D6 RID: 214
			private byte __Driver175;

			// Token: 0x040000D7 RID: 215
			private byte __Driver176;

			// Token: 0x040000D8 RID: 216
			private byte __Driver177;

			// Token: 0x040000D9 RID: 217
			private byte __Driver178;

			// Token: 0x040000DA RID: 218
			private byte __Driver179;

			// Token: 0x040000DB RID: 219
			private byte __Driver180;

			// Token: 0x040000DC RID: 220
			private byte __Driver181;

			// Token: 0x040000DD RID: 221
			private byte __Driver182;

			// Token: 0x040000DE RID: 222
			private byte __Driver183;

			// Token: 0x040000DF RID: 223
			private byte __Driver184;

			// Token: 0x040000E0 RID: 224
			private byte __Driver185;

			// Token: 0x040000E1 RID: 225
			private byte __Driver186;

			// Token: 0x040000E2 RID: 226
			private byte __Driver187;

			// Token: 0x040000E3 RID: 227
			private byte __Driver188;

			// Token: 0x040000E4 RID: 228
			private byte __Driver189;

			// Token: 0x040000E5 RID: 229
			private byte __Driver190;

			// Token: 0x040000E6 RID: 230
			private byte __Driver191;

			// Token: 0x040000E7 RID: 231
			private byte __Driver192;

			// Token: 0x040000E8 RID: 232
			private byte __Driver193;

			// Token: 0x040000E9 RID: 233
			private byte __Driver194;

			// Token: 0x040000EA RID: 234
			private byte __Driver195;

			// Token: 0x040000EB RID: 235
			private byte __Driver196;

			// Token: 0x040000EC RID: 236
			private byte __Driver197;

			// Token: 0x040000ED RID: 237
			private byte __Driver198;

			// Token: 0x040000EE RID: 238
			private byte __Driver199;

			// Token: 0x040000EF RID: 239
			private byte __Driver200;

			// Token: 0x040000F0 RID: 240
			private byte __Driver201;

			// Token: 0x040000F1 RID: 241
			private byte __Driver202;

			// Token: 0x040000F2 RID: 242
			private byte __Driver203;

			// Token: 0x040000F3 RID: 243
			private byte __Driver204;

			// Token: 0x040000F4 RID: 244
			private byte __Driver205;

			// Token: 0x040000F5 RID: 245
			private byte __Driver206;

			// Token: 0x040000F6 RID: 246
			private byte __Driver207;

			// Token: 0x040000F7 RID: 247
			private byte __Driver208;

			// Token: 0x040000F8 RID: 248
			private byte __Driver209;

			// Token: 0x040000F9 RID: 249
			private byte __Driver210;

			// Token: 0x040000FA RID: 250
			private byte __Driver211;

			// Token: 0x040000FB RID: 251
			private byte __Driver212;

			// Token: 0x040000FC RID: 252
			private byte __Driver213;

			// Token: 0x040000FD RID: 253
			private byte __Driver214;

			// Token: 0x040000FE RID: 254
			private byte __Driver215;

			// Token: 0x040000FF RID: 255
			private byte __Driver216;

			// Token: 0x04000100 RID: 256
			private byte __Driver217;

			// Token: 0x04000101 RID: 257
			private byte __Driver218;

			// Token: 0x04000102 RID: 258
			private byte __Driver219;

			// Token: 0x04000103 RID: 259
			private byte __Driver220;

			// Token: 0x04000104 RID: 260
			private byte __Driver221;

			// Token: 0x04000105 RID: 261
			private byte __Driver222;

			// Token: 0x04000106 RID: 262
			private byte __Driver223;

			// Token: 0x04000107 RID: 263
			private byte __Driver224;

			// Token: 0x04000108 RID: 264
			private byte __Driver225;

			// Token: 0x04000109 RID: 265
			private byte __Driver226;

			// Token: 0x0400010A RID: 266
			private byte __Driver227;

			// Token: 0x0400010B RID: 267
			private byte __Driver228;

			// Token: 0x0400010C RID: 268
			private byte __Driver229;

			// Token: 0x0400010D RID: 269
			private byte __Driver230;

			// Token: 0x0400010E RID: 270
			private byte __Driver231;

			// Token: 0x0400010F RID: 271
			private byte __Driver232;

			// Token: 0x04000110 RID: 272
			private byte __Driver233;

			// Token: 0x04000111 RID: 273
			private byte __Driver234;

			// Token: 0x04000112 RID: 274
			private byte __Driver235;

			// Token: 0x04000113 RID: 275
			private byte __Driver236;

			// Token: 0x04000114 RID: 276
			private byte __Driver237;

			// Token: 0x04000115 RID: 277
			private byte __Driver238;

			// Token: 0x04000116 RID: 278
			private byte __Driver239;

			// Token: 0x04000117 RID: 279
			private byte __Driver240;

			// Token: 0x04000118 RID: 280
			private byte __Driver241;

			// Token: 0x04000119 RID: 281
			private byte __Driver242;

			// Token: 0x0400011A RID: 282
			private byte __Driver243;

			// Token: 0x0400011B RID: 283
			private byte __Driver244;

			// Token: 0x0400011C RID: 284
			private byte __Driver245;

			// Token: 0x0400011D RID: 285
			private byte __Driver246;

			// Token: 0x0400011E RID: 286
			private byte __Driver247;

			// Token: 0x0400011F RID: 287
			private byte __Driver248;

			// Token: 0x04000120 RID: 288
			private byte __Driver249;

			// Token: 0x04000121 RID: 289
			private byte __Driver250;

			// Token: 0x04000122 RID: 290
			private byte __Driver251;

			// Token: 0x04000123 RID: 291
			private byte __Driver252;

			// Token: 0x04000124 RID: 292
			private byte __Driver253;

			// Token: 0x04000125 RID: 293
			private byte __Driver254;

			// Token: 0x04000126 RID: 294
			private byte __Driver255;

			// Token: 0x04000127 RID: 295
			private byte __Driver256;

			// Token: 0x04000128 RID: 296
			private byte __Driver257;

			// Token: 0x04000129 RID: 297
			private byte __Driver258;

			// Token: 0x0400012A RID: 298
			private byte __Driver259;

			// Token: 0x0400012B RID: 299
			private byte __Driver260;

			// Token: 0x0400012C RID: 300
			private byte __Driver261;

			// Token: 0x0400012D RID: 301
			private byte __Driver262;

			// Token: 0x0400012E RID: 302
			private byte __Driver263;

			// Token: 0x0400012F RID: 303
			private byte __Driver264;

			// Token: 0x04000130 RID: 304
			private byte __Driver265;

			// Token: 0x04000131 RID: 305
			private byte __Driver266;

			// Token: 0x04000132 RID: 306
			private byte __Driver267;

			// Token: 0x04000133 RID: 307
			private byte __Driver268;

			// Token: 0x04000134 RID: 308
			private byte __Driver269;

			// Token: 0x04000135 RID: 309
			private byte __Driver270;

			// Token: 0x04000136 RID: 310
			private byte __Driver271;

			// Token: 0x04000137 RID: 311
			private byte __Driver272;

			// Token: 0x04000138 RID: 312
			private byte __Driver273;

			// Token: 0x04000139 RID: 313
			private byte __Driver274;

			// Token: 0x0400013A RID: 314
			private byte __Driver275;

			// Token: 0x0400013B RID: 315
			private byte __Driver276;

			// Token: 0x0400013C RID: 316
			private byte __Driver277;

			// Token: 0x0400013D RID: 317
			private byte __Driver278;

			// Token: 0x0400013E RID: 318
			private byte __Driver279;

			// Token: 0x0400013F RID: 319
			private byte __Driver280;

			// Token: 0x04000140 RID: 320
			private byte __Driver281;

			// Token: 0x04000141 RID: 321
			private byte __Driver282;

			// Token: 0x04000142 RID: 322
			private byte __Driver283;

			// Token: 0x04000143 RID: 323
			private byte __Driver284;

			// Token: 0x04000144 RID: 324
			private byte __Driver285;

			// Token: 0x04000145 RID: 325
			private byte __Driver286;

			// Token: 0x04000146 RID: 326
			private byte __Driver287;

			// Token: 0x04000147 RID: 327
			private byte __Driver288;

			// Token: 0x04000148 RID: 328
			private byte __Driver289;

			// Token: 0x04000149 RID: 329
			private byte __Driver290;

			// Token: 0x0400014A RID: 330
			private byte __Driver291;

			// Token: 0x0400014B RID: 331
			private byte __Driver292;

			// Token: 0x0400014C RID: 332
			private byte __Driver293;

			// Token: 0x0400014D RID: 333
			private byte __Driver294;

			// Token: 0x0400014E RID: 334
			private byte __Driver295;

			// Token: 0x0400014F RID: 335
			private byte __Driver296;

			// Token: 0x04000150 RID: 336
			private byte __Driver297;

			// Token: 0x04000151 RID: 337
			private byte __Driver298;

			// Token: 0x04000152 RID: 338
			private byte __Driver299;

			// Token: 0x04000153 RID: 339
			private byte __Driver300;

			// Token: 0x04000154 RID: 340
			private byte __Driver301;

			// Token: 0x04000155 RID: 341
			private byte __Driver302;

			// Token: 0x04000156 RID: 342
			private byte __Driver303;

			// Token: 0x04000157 RID: 343
			private byte __Driver304;

			// Token: 0x04000158 RID: 344
			private byte __Driver305;

			// Token: 0x04000159 RID: 345
			private byte __Driver306;

			// Token: 0x0400015A RID: 346
			private byte __Driver307;

			// Token: 0x0400015B RID: 347
			private byte __Driver308;

			// Token: 0x0400015C RID: 348
			private byte __Driver309;

			// Token: 0x0400015D RID: 349
			private byte __Driver310;

			// Token: 0x0400015E RID: 350
			private byte __Driver311;

			// Token: 0x0400015F RID: 351
			private byte __Driver312;

			// Token: 0x04000160 RID: 352
			private byte __Driver313;

			// Token: 0x04000161 RID: 353
			private byte __Driver314;

			// Token: 0x04000162 RID: 354
			private byte __Driver315;

			// Token: 0x04000163 RID: 355
			private byte __Driver316;

			// Token: 0x04000164 RID: 356
			private byte __Driver317;

			// Token: 0x04000165 RID: 357
			private byte __Driver318;

			// Token: 0x04000166 RID: 358
			private byte __Driver319;

			// Token: 0x04000167 RID: 359
			private byte __Driver320;

			// Token: 0x04000168 RID: 360
			private byte __Driver321;

			// Token: 0x04000169 RID: 361
			private byte __Driver322;

			// Token: 0x0400016A RID: 362
			private byte __Driver323;

			// Token: 0x0400016B RID: 363
			private byte __Driver324;

			// Token: 0x0400016C RID: 364
			private byte __Driver325;

			// Token: 0x0400016D RID: 365
			private byte __Driver326;

			// Token: 0x0400016E RID: 366
			private byte __Driver327;

			// Token: 0x0400016F RID: 367
			private byte __Driver328;

			// Token: 0x04000170 RID: 368
			private byte __Driver329;

			// Token: 0x04000171 RID: 369
			private byte __Driver330;

			// Token: 0x04000172 RID: 370
			private byte __Driver331;

			// Token: 0x04000173 RID: 371
			private byte __Driver332;

			// Token: 0x04000174 RID: 372
			private byte __Driver333;

			// Token: 0x04000175 RID: 373
			private byte __Driver334;

			// Token: 0x04000176 RID: 374
			private byte __Driver335;

			// Token: 0x04000177 RID: 375
			private byte __Driver336;

			// Token: 0x04000178 RID: 376
			private byte __Driver337;

			// Token: 0x04000179 RID: 377
			private byte __Driver338;

			// Token: 0x0400017A RID: 378
			private byte __Driver339;

			// Token: 0x0400017B RID: 379
			private byte __Driver340;

			// Token: 0x0400017C RID: 380
			private byte __Driver341;

			// Token: 0x0400017D RID: 381
			private byte __Driver342;

			// Token: 0x0400017E RID: 382
			private byte __Driver343;

			// Token: 0x0400017F RID: 383
			private byte __Driver344;

			// Token: 0x04000180 RID: 384
			private byte __Driver345;

			// Token: 0x04000181 RID: 385
			private byte __Driver346;

			// Token: 0x04000182 RID: 386
			private byte __Driver347;

			// Token: 0x04000183 RID: 387
			private byte __Driver348;

			// Token: 0x04000184 RID: 388
			private byte __Driver349;

			// Token: 0x04000185 RID: 389
			private byte __Driver350;

			// Token: 0x04000186 RID: 390
			private byte __Driver351;

			// Token: 0x04000187 RID: 391
			private byte __Driver352;

			// Token: 0x04000188 RID: 392
			private byte __Driver353;

			// Token: 0x04000189 RID: 393
			private byte __Driver354;

			// Token: 0x0400018A RID: 394
			private byte __Driver355;

			// Token: 0x0400018B RID: 395
			private byte __Driver356;

			// Token: 0x0400018C RID: 396
			private byte __Driver357;

			// Token: 0x0400018D RID: 397
			private byte __Driver358;

			// Token: 0x0400018E RID: 398
			private byte __Driver359;

			// Token: 0x0400018F RID: 399
			private byte __Driver360;

			// Token: 0x04000190 RID: 400
			private byte __Driver361;

			// Token: 0x04000191 RID: 401
			private byte __Driver362;

			// Token: 0x04000192 RID: 402
			private byte __Driver363;

			// Token: 0x04000193 RID: 403
			private byte __Driver364;

			// Token: 0x04000194 RID: 404
			private byte __Driver365;

			// Token: 0x04000195 RID: 405
			private byte __Driver366;

			// Token: 0x04000196 RID: 406
			private byte __Driver367;

			// Token: 0x04000197 RID: 407
			private byte __Driver368;

			// Token: 0x04000198 RID: 408
			private byte __Driver369;

			// Token: 0x04000199 RID: 409
			private byte __Driver370;

			// Token: 0x0400019A RID: 410
			private byte __Driver371;

			// Token: 0x0400019B RID: 411
			private byte __Driver372;

			// Token: 0x0400019C RID: 412
			private byte __Driver373;

			// Token: 0x0400019D RID: 413
			private byte __Driver374;

			// Token: 0x0400019E RID: 414
			private byte __Driver375;

			// Token: 0x0400019F RID: 415
			private byte __Driver376;

			// Token: 0x040001A0 RID: 416
			private byte __Driver377;

			// Token: 0x040001A1 RID: 417
			private byte __Driver378;

			// Token: 0x040001A2 RID: 418
			private byte __Driver379;

			// Token: 0x040001A3 RID: 419
			private byte __Driver380;

			// Token: 0x040001A4 RID: 420
			private byte __Driver381;

			// Token: 0x040001A5 RID: 421
			private byte __Driver382;

			// Token: 0x040001A6 RID: 422
			private byte __Driver383;

			// Token: 0x040001A7 RID: 423
			private byte __Driver384;

			// Token: 0x040001A8 RID: 424
			private byte __Driver385;

			// Token: 0x040001A9 RID: 425
			private byte __Driver386;

			// Token: 0x040001AA RID: 426
			private byte __Driver387;

			// Token: 0x040001AB RID: 427
			private byte __Driver388;

			// Token: 0x040001AC RID: 428
			private byte __Driver389;

			// Token: 0x040001AD RID: 429
			private byte __Driver390;

			// Token: 0x040001AE RID: 430
			private byte __Driver391;

			// Token: 0x040001AF RID: 431
			private byte __Driver392;

			// Token: 0x040001B0 RID: 432
			private byte __Driver393;

			// Token: 0x040001B1 RID: 433
			private byte __Driver394;

			// Token: 0x040001B2 RID: 434
			private byte __Driver395;

			// Token: 0x040001B3 RID: 435
			private byte __Driver396;

			// Token: 0x040001B4 RID: 436
			private byte __Driver397;

			// Token: 0x040001B5 RID: 437
			private byte __Driver398;

			// Token: 0x040001B6 RID: 438
			private byte __Driver399;

			// Token: 0x040001B7 RID: 439
			private byte __Driver400;

			// Token: 0x040001B8 RID: 440
			private byte __Driver401;

			// Token: 0x040001B9 RID: 441
			private byte __Driver402;

			// Token: 0x040001BA RID: 442
			private byte __Driver403;

			// Token: 0x040001BB RID: 443
			private byte __Driver404;

			// Token: 0x040001BC RID: 444
			private byte __Driver405;

			// Token: 0x040001BD RID: 445
			private byte __Driver406;

			// Token: 0x040001BE RID: 446
			private byte __Driver407;

			// Token: 0x040001BF RID: 447
			private byte __Driver408;

			// Token: 0x040001C0 RID: 448
			private byte __Driver409;

			// Token: 0x040001C1 RID: 449
			private byte __Driver410;

			// Token: 0x040001C2 RID: 450
			private byte __Driver411;

			// Token: 0x040001C3 RID: 451
			private byte __Driver412;

			// Token: 0x040001C4 RID: 452
			private byte __Driver413;

			// Token: 0x040001C5 RID: 453
			private byte __Driver414;

			// Token: 0x040001C6 RID: 454
			private byte __Driver415;

			// Token: 0x040001C7 RID: 455
			private byte __Driver416;

			// Token: 0x040001C8 RID: 456
			private byte __Driver417;

			// Token: 0x040001C9 RID: 457
			private byte __Driver418;

			// Token: 0x040001CA RID: 458
			private byte __Driver419;

			// Token: 0x040001CB RID: 459
			private byte __Driver420;

			// Token: 0x040001CC RID: 460
			private byte __Driver421;

			// Token: 0x040001CD RID: 461
			private byte __Driver422;

			// Token: 0x040001CE RID: 462
			private byte __Driver423;

			// Token: 0x040001CF RID: 463
			private byte __Driver424;

			// Token: 0x040001D0 RID: 464
			private byte __Driver425;

			// Token: 0x040001D1 RID: 465
			private byte __Driver426;

			// Token: 0x040001D2 RID: 466
			private byte __Driver427;

			// Token: 0x040001D3 RID: 467
			private byte __Driver428;

			// Token: 0x040001D4 RID: 468
			private byte __Driver429;

			// Token: 0x040001D5 RID: 469
			private byte __Driver430;

			// Token: 0x040001D6 RID: 470
			private byte __Driver431;

			// Token: 0x040001D7 RID: 471
			private byte __Driver432;

			// Token: 0x040001D8 RID: 472
			private byte __Driver433;

			// Token: 0x040001D9 RID: 473
			private byte __Driver434;

			// Token: 0x040001DA RID: 474
			private byte __Driver435;

			// Token: 0x040001DB RID: 475
			private byte __Driver436;

			// Token: 0x040001DC RID: 476
			private byte __Driver437;

			// Token: 0x040001DD RID: 477
			private byte __Driver438;

			// Token: 0x040001DE RID: 478
			private byte __Driver439;

			// Token: 0x040001DF RID: 479
			private byte __Driver440;

			// Token: 0x040001E0 RID: 480
			private byte __Driver441;

			// Token: 0x040001E1 RID: 481
			private byte __Driver442;

			// Token: 0x040001E2 RID: 482
			private byte __Driver443;

			// Token: 0x040001E3 RID: 483
			private byte __Driver444;

			// Token: 0x040001E4 RID: 484
			private byte __Driver445;

			// Token: 0x040001E5 RID: 485
			private byte __Driver446;

			// Token: 0x040001E6 RID: 486
			private byte __Driver447;

			// Token: 0x040001E7 RID: 487
			private byte __Driver448;

			// Token: 0x040001E8 RID: 488
			private byte __Driver449;

			// Token: 0x040001E9 RID: 489
			private byte __Driver450;

			// Token: 0x040001EA RID: 490
			private byte __Driver451;

			// Token: 0x040001EB RID: 491
			private byte __Driver452;

			// Token: 0x040001EC RID: 492
			private byte __Driver453;

			// Token: 0x040001ED RID: 493
			private byte __Driver454;

			// Token: 0x040001EE RID: 494
			private byte __Driver455;

			// Token: 0x040001EF RID: 495
			private byte __Driver456;

			// Token: 0x040001F0 RID: 496
			private byte __Driver457;

			// Token: 0x040001F1 RID: 497
			private byte __Driver458;

			// Token: 0x040001F2 RID: 498
			private byte __Driver459;

			// Token: 0x040001F3 RID: 499
			private byte __Driver460;

			// Token: 0x040001F4 RID: 500
			private byte __Driver461;

			// Token: 0x040001F5 RID: 501
			private byte __Driver462;

			// Token: 0x040001F6 RID: 502
			private byte __Driver463;

			// Token: 0x040001F7 RID: 503
			private byte __Driver464;

			// Token: 0x040001F8 RID: 504
			private byte __Driver465;

			// Token: 0x040001F9 RID: 505
			private byte __Driver466;

			// Token: 0x040001FA RID: 506
			private byte __Driver467;

			// Token: 0x040001FB RID: 507
			private byte __Driver468;

			// Token: 0x040001FC RID: 508
			private byte __Driver469;

			// Token: 0x040001FD RID: 509
			private byte __Driver470;

			// Token: 0x040001FE RID: 510
			private byte __Driver471;

			// Token: 0x040001FF RID: 511
			private byte __Driver472;

			// Token: 0x04000200 RID: 512
			private byte __Driver473;

			// Token: 0x04000201 RID: 513
			private byte __Driver474;

			// Token: 0x04000202 RID: 514
			private byte __Driver475;

			// Token: 0x04000203 RID: 515
			private byte __Driver476;

			// Token: 0x04000204 RID: 516
			private byte __Driver477;

			// Token: 0x04000205 RID: 517
			private byte __Driver478;

			// Token: 0x04000206 RID: 518
			private byte __Driver479;

			// Token: 0x04000207 RID: 519
			private byte __Driver480;

			// Token: 0x04000208 RID: 520
			private byte __Driver481;

			// Token: 0x04000209 RID: 521
			private byte __Driver482;

			// Token: 0x0400020A RID: 522
			private byte __Driver483;

			// Token: 0x0400020B RID: 523
			private byte __Driver484;

			// Token: 0x0400020C RID: 524
			private byte __Driver485;

			// Token: 0x0400020D RID: 525
			private byte __Driver486;

			// Token: 0x0400020E RID: 526
			private byte __Driver487;

			// Token: 0x0400020F RID: 527
			private byte __Driver488;

			// Token: 0x04000210 RID: 528
			private byte __Driver489;

			// Token: 0x04000211 RID: 529
			private byte __Driver490;

			// Token: 0x04000212 RID: 530
			private byte __Driver491;

			// Token: 0x04000213 RID: 531
			private byte __Driver492;

			// Token: 0x04000214 RID: 532
			private byte __Driver493;

			// Token: 0x04000215 RID: 533
			private byte __Driver494;

			// Token: 0x04000216 RID: 534
			private byte __Driver495;

			// Token: 0x04000217 RID: 535
			private byte __Driver496;

			// Token: 0x04000218 RID: 536
			private byte __Driver497;

			// Token: 0x04000219 RID: 537
			private byte __Driver498;

			// Token: 0x0400021A RID: 538
			private byte __Driver499;

			// Token: 0x0400021B RID: 539
			private byte __Driver500;

			// Token: 0x0400021C RID: 540
			private byte __Driver501;

			// Token: 0x0400021D RID: 541
			private byte __Driver502;

			// Token: 0x0400021E RID: 542
			private byte __Driver503;

			// Token: 0x0400021F RID: 543
			private byte __Driver504;

			// Token: 0x04000220 RID: 544
			private byte __Driver505;

			// Token: 0x04000221 RID: 545
			private byte __Driver506;

			// Token: 0x04000222 RID: 546
			private byte __Driver507;

			// Token: 0x04000223 RID: 547
			private byte __Driver508;

			// Token: 0x04000224 RID: 548
			private byte __Driver509;

			// Token: 0x04000225 RID: 549
			private byte __Driver510;

			// Token: 0x04000226 RID: 550
			private byte __Driver511;

			// Token: 0x04000227 RID: 551
			public byte Description;

			// Token: 0x04000228 RID: 552
			private byte __Description1;

			// Token: 0x04000229 RID: 553
			private byte __Description2;

			// Token: 0x0400022A RID: 554
			private byte __Description3;

			// Token: 0x0400022B RID: 555
			private byte __Description4;

			// Token: 0x0400022C RID: 556
			private byte __Description5;

			// Token: 0x0400022D RID: 557
			private byte __Description6;

			// Token: 0x0400022E RID: 558
			private byte __Description7;

			// Token: 0x0400022F RID: 559
			private byte __Description8;

			// Token: 0x04000230 RID: 560
			private byte __Description9;

			// Token: 0x04000231 RID: 561
			private byte __Description10;

			// Token: 0x04000232 RID: 562
			private byte __Description11;

			// Token: 0x04000233 RID: 563
			private byte __Description12;

			// Token: 0x04000234 RID: 564
			private byte __Description13;

			// Token: 0x04000235 RID: 565
			private byte __Description14;

			// Token: 0x04000236 RID: 566
			private byte __Description15;

			// Token: 0x04000237 RID: 567
			private byte __Description16;

			// Token: 0x04000238 RID: 568
			private byte __Description17;

			// Token: 0x04000239 RID: 569
			private byte __Description18;

			// Token: 0x0400023A RID: 570
			private byte __Description19;

			// Token: 0x0400023B RID: 571
			private byte __Description20;

			// Token: 0x0400023C RID: 572
			private byte __Description21;

			// Token: 0x0400023D RID: 573
			private byte __Description22;

			// Token: 0x0400023E RID: 574
			private byte __Description23;

			// Token: 0x0400023F RID: 575
			private byte __Description24;

			// Token: 0x04000240 RID: 576
			private byte __Description25;

			// Token: 0x04000241 RID: 577
			private byte __Description26;

			// Token: 0x04000242 RID: 578
			private byte __Description27;

			// Token: 0x04000243 RID: 579
			private byte __Description28;

			// Token: 0x04000244 RID: 580
			private byte __Description29;

			// Token: 0x04000245 RID: 581
			private byte __Description30;

			// Token: 0x04000246 RID: 582
			private byte __Description31;

			// Token: 0x04000247 RID: 583
			private byte __Description32;

			// Token: 0x04000248 RID: 584
			private byte __Description33;

			// Token: 0x04000249 RID: 585
			private byte __Description34;

			// Token: 0x0400024A RID: 586
			private byte __Description35;

			// Token: 0x0400024B RID: 587
			private byte __Description36;

			// Token: 0x0400024C RID: 588
			private byte __Description37;

			// Token: 0x0400024D RID: 589
			private byte __Description38;

			// Token: 0x0400024E RID: 590
			private byte __Description39;

			// Token: 0x0400024F RID: 591
			private byte __Description40;

			// Token: 0x04000250 RID: 592
			private byte __Description41;

			// Token: 0x04000251 RID: 593
			private byte __Description42;

			// Token: 0x04000252 RID: 594
			private byte __Description43;

			// Token: 0x04000253 RID: 595
			private byte __Description44;

			// Token: 0x04000254 RID: 596
			private byte __Description45;

			// Token: 0x04000255 RID: 597
			private byte __Description46;

			// Token: 0x04000256 RID: 598
			private byte __Description47;

			// Token: 0x04000257 RID: 599
			private byte __Description48;

			// Token: 0x04000258 RID: 600
			private byte __Description49;

			// Token: 0x04000259 RID: 601
			private byte __Description50;

			// Token: 0x0400025A RID: 602
			private byte __Description51;

			// Token: 0x0400025B RID: 603
			private byte __Description52;

			// Token: 0x0400025C RID: 604
			private byte __Description53;

			// Token: 0x0400025D RID: 605
			private byte __Description54;

			// Token: 0x0400025E RID: 606
			private byte __Description55;

			// Token: 0x0400025F RID: 607
			private byte __Description56;

			// Token: 0x04000260 RID: 608
			private byte __Description57;

			// Token: 0x04000261 RID: 609
			private byte __Description58;

			// Token: 0x04000262 RID: 610
			private byte __Description59;

			// Token: 0x04000263 RID: 611
			private byte __Description60;

			// Token: 0x04000264 RID: 612
			private byte __Description61;

			// Token: 0x04000265 RID: 613
			private byte __Description62;

			// Token: 0x04000266 RID: 614
			private byte __Description63;

			// Token: 0x04000267 RID: 615
			private byte __Description64;

			// Token: 0x04000268 RID: 616
			private byte __Description65;

			// Token: 0x04000269 RID: 617
			private byte __Description66;

			// Token: 0x0400026A RID: 618
			private byte __Description67;

			// Token: 0x0400026B RID: 619
			private byte __Description68;

			// Token: 0x0400026C RID: 620
			private byte __Description69;

			// Token: 0x0400026D RID: 621
			private byte __Description70;

			// Token: 0x0400026E RID: 622
			private byte __Description71;

			// Token: 0x0400026F RID: 623
			private byte __Description72;

			// Token: 0x04000270 RID: 624
			private byte __Description73;

			// Token: 0x04000271 RID: 625
			private byte __Description74;

			// Token: 0x04000272 RID: 626
			private byte __Description75;

			// Token: 0x04000273 RID: 627
			private byte __Description76;

			// Token: 0x04000274 RID: 628
			private byte __Description77;

			// Token: 0x04000275 RID: 629
			private byte __Description78;

			// Token: 0x04000276 RID: 630
			private byte __Description79;

			// Token: 0x04000277 RID: 631
			private byte __Description80;

			// Token: 0x04000278 RID: 632
			private byte __Description81;

			// Token: 0x04000279 RID: 633
			private byte __Description82;

			// Token: 0x0400027A RID: 634
			private byte __Description83;

			// Token: 0x0400027B RID: 635
			private byte __Description84;

			// Token: 0x0400027C RID: 636
			private byte __Description85;

			// Token: 0x0400027D RID: 637
			private byte __Description86;

			// Token: 0x0400027E RID: 638
			private byte __Description87;

			// Token: 0x0400027F RID: 639
			private byte __Description88;

			// Token: 0x04000280 RID: 640
			private byte __Description89;

			// Token: 0x04000281 RID: 641
			private byte __Description90;

			// Token: 0x04000282 RID: 642
			private byte __Description91;

			// Token: 0x04000283 RID: 643
			private byte __Description92;

			// Token: 0x04000284 RID: 644
			private byte __Description93;

			// Token: 0x04000285 RID: 645
			private byte __Description94;

			// Token: 0x04000286 RID: 646
			private byte __Description95;

			// Token: 0x04000287 RID: 647
			private byte __Description96;

			// Token: 0x04000288 RID: 648
			private byte __Description97;

			// Token: 0x04000289 RID: 649
			private byte __Description98;

			// Token: 0x0400028A RID: 650
			private byte __Description99;

			// Token: 0x0400028B RID: 651
			private byte __Description100;

			// Token: 0x0400028C RID: 652
			private byte __Description101;

			// Token: 0x0400028D RID: 653
			private byte __Description102;

			// Token: 0x0400028E RID: 654
			private byte __Description103;

			// Token: 0x0400028F RID: 655
			private byte __Description104;

			// Token: 0x04000290 RID: 656
			private byte __Description105;

			// Token: 0x04000291 RID: 657
			private byte __Description106;

			// Token: 0x04000292 RID: 658
			private byte __Description107;

			// Token: 0x04000293 RID: 659
			private byte __Description108;

			// Token: 0x04000294 RID: 660
			private byte __Description109;

			// Token: 0x04000295 RID: 661
			private byte __Description110;

			// Token: 0x04000296 RID: 662
			private byte __Description111;

			// Token: 0x04000297 RID: 663
			private byte __Description112;

			// Token: 0x04000298 RID: 664
			private byte __Description113;

			// Token: 0x04000299 RID: 665
			private byte __Description114;

			// Token: 0x0400029A RID: 666
			private byte __Description115;

			// Token: 0x0400029B RID: 667
			private byte __Description116;

			// Token: 0x0400029C RID: 668
			private byte __Description117;

			// Token: 0x0400029D RID: 669
			private byte __Description118;

			// Token: 0x0400029E RID: 670
			private byte __Description119;

			// Token: 0x0400029F RID: 671
			private byte __Description120;

			// Token: 0x040002A0 RID: 672
			private byte __Description121;

			// Token: 0x040002A1 RID: 673
			private byte __Description122;

			// Token: 0x040002A2 RID: 674
			private byte __Description123;

			// Token: 0x040002A3 RID: 675
			private byte __Description124;

			// Token: 0x040002A4 RID: 676
			private byte __Description125;

			// Token: 0x040002A5 RID: 677
			private byte __Description126;

			// Token: 0x040002A6 RID: 678
			private byte __Description127;

			// Token: 0x040002A7 RID: 679
			private byte __Description128;

			// Token: 0x040002A8 RID: 680
			private byte __Description129;

			// Token: 0x040002A9 RID: 681
			private byte __Description130;

			// Token: 0x040002AA RID: 682
			private byte __Description131;

			// Token: 0x040002AB RID: 683
			private byte __Description132;

			// Token: 0x040002AC RID: 684
			private byte __Description133;

			// Token: 0x040002AD RID: 685
			private byte __Description134;

			// Token: 0x040002AE RID: 686
			private byte __Description135;

			// Token: 0x040002AF RID: 687
			private byte __Description136;

			// Token: 0x040002B0 RID: 688
			private byte __Description137;

			// Token: 0x040002B1 RID: 689
			private byte __Description138;

			// Token: 0x040002B2 RID: 690
			private byte __Description139;

			// Token: 0x040002B3 RID: 691
			private byte __Description140;

			// Token: 0x040002B4 RID: 692
			private byte __Description141;

			// Token: 0x040002B5 RID: 693
			private byte __Description142;

			// Token: 0x040002B6 RID: 694
			private byte __Description143;

			// Token: 0x040002B7 RID: 695
			private byte __Description144;

			// Token: 0x040002B8 RID: 696
			private byte __Description145;

			// Token: 0x040002B9 RID: 697
			private byte __Description146;

			// Token: 0x040002BA RID: 698
			private byte __Description147;

			// Token: 0x040002BB RID: 699
			private byte __Description148;

			// Token: 0x040002BC RID: 700
			private byte __Description149;

			// Token: 0x040002BD RID: 701
			private byte __Description150;

			// Token: 0x040002BE RID: 702
			private byte __Description151;

			// Token: 0x040002BF RID: 703
			private byte __Description152;

			// Token: 0x040002C0 RID: 704
			private byte __Description153;

			// Token: 0x040002C1 RID: 705
			private byte __Description154;

			// Token: 0x040002C2 RID: 706
			private byte __Description155;

			// Token: 0x040002C3 RID: 707
			private byte __Description156;

			// Token: 0x040002C4 RID: 708
			private byte __Description157;

			// Token: 0x040002C5 RID: 709
			private byte __Description158;

			// Token: 0x040002C6 RID: 710
			private byte __Description159;

			// Token: 0x040002C7 RID: 711
			private byte __Description160;

			// Token: 0x040002C8 RID: 712
			private byte __Description161;

			// Token: 0x040002C9 RID: 713
			private byte __Description162;

			// Token: 0x040002CA RID: 714
			private byte __Description163;

			// Token: 0x040002CB RID: 715
			private byte __Description164;

			// Token: 0x040002CC RID: 716
			private byte __Description165;

			// Token: 0x040002CD RID: 717
			private byte __Description166;

			// Token: 0x040002CE RID: 718
			private byte __Description167;

			// Token: 0x040002CF RID: 719
			private byte __Description168;

			// Token: 0x040002D0 RID: 720
			private byte __Description169;

			// Token: 0x040002D1 RID: 721
			private byte __Description170;

			// Token: 0x040002D2 RID: 722
			private byte __Description171;

			// Token: 0x040002D3 RID: 723
			private byte __Description172;

			// Token: 0x040002D4 RID: 724
			private byte __Description173;

			// Token: 0x040002D5 RID: 725
			private byte __Description174;

			// Token: 0x040002D6 RID: 726
			private byte __Description175;

			// Token: 0x040002D7 RID: 727
			private byte __Description176;

			// Token: 0x040002D8 RID: 728
			private byte __Description177;

			// Token: 0x040002D9 RID: 729
			private byte __Description178;

			// Token: 0x040002DA RID: 730
			private byte __Description179;

			// Token: 0x040002DB RID: 731
			private byte __Description180;

			// Token: 0x040002DC RID: 732
			private byte __Description181;

			// Token: 0x040002DD RID: 733
			private byte __Description182;

			// Token: 0x040002DE RID: 734
			private byte __Description183;

			// Token: 0x040002DF RID: 735
			private byte __Description184;

			// Token: 0x040002E0 RID: 736
			private byte __Description185;

			// Token: 0x040002E1 RID: 737
			private byte __Description186;

			// Token: 0x040002E2 RID: 738
			private byte __Description187;

			// Token: 0x040002E3 RID: 739
			private byte __Description188;

			// Token: 0x040002E4 RID: 740
			private byte __Description189;

			// Token: 0x040002E5 RID: 741
			private byte __Description190;

			// Token: 0x040002E6 RID: 742
			private byte __Description191;

			// Token: 0x040002E7 RID: 743
			private byte __Description192;

			// Token: 0x040002E8 RID: 744
			private byte __Description193;

			// Token: 0x040002E9 RID: 745
			private byte __Description194;

			// Token: 0x040002EA RID: 746
			private byte __Description195;

			// Token: 0x040002EB RID: 747
			private byte __Description196;

			// Token: 0x040002EC RID: 748
			private byte __Description197;

			// Token: 0x040002ED RID: 749
			private byte __Description198;

			// Token: 0x040002EE RID: 750
			private byte __Description199;

			// Token: 0x040002EF RID: 751
			private byte __Description200;

			// Token: 0x040002F0 RID: 752
			private byte __Description201;

			// Token: 0x040002F1 RID: 753
			private byte __Description202;

			// Token: 0x040002F2 RID: 754
			private byte __Description203;

			// Token: 0x040002F3 RID: 755
			private byte __Description204;

			// Token: 0x040002F4 RID: 756
			private byte __Description205;

			// Token: 0x040002F5 RID: 757
			private byte __Description206;

			// Token: 0x040002F6 RID: 758
			private byte __Description207;

			// Token: 0x040002F7 RID: 759
			private byte __Description208;

			// Token: 0x040002F8 RID: 760
			private byte __Description209;

			// Token: 0x040002F9 RID: 761
			private byte __Description210;

			// Token: 0x040002FA RID: 762
			private byte __Description211;

			// Token: 0x040002FB RID: 763
			private byte __Description212;

			// Token: 0x040002FC RID: 764
			private byte __Description213;

			// Token: 0x040002FD RID: 765
			private byte __Description214;

			// Token: 0x040002FE RID: 766
			private byte __Description215;

			// Token: 0x040002FF RID: 767
			private byte __Description216;

			// Token: 0x04000300 RID: 768
			private byte __Description217;

			// Token: 0x04000301 RID: 769
			private byte __Description218;

			// Token: 0x04000302 RID: 770
			private byte __Description219;

			// Token: 0x04000303 RID: 771
			private byte __Description220;

			// Token: 0x04000304 RID: 772
			private byte __Description221;

			// Token: 0x04000305 RID: 773
			private byte __Description222;

			// Token: 0x04000306 RID: 774
			private byte __Description223;

			// Token: 0x04000307 RID: 775
			private byte __Description224;

			// Token: 0x04000308 RID: 776
			private byte __Description225;

			// Token: 0x04000309 RID: 777
			private byte __Description226;

			// Token: 0x0400030A RID: 778
			private byte __Description227;

			// Token: 0x0400030B RID: 779
			private byte __Description228;

			// Token: 0x0400030C RID: 780
			private byte __Description229;

			// Token: 0x0400030D RID: 781
			private byte __Description230;

			// Token: 0x0400030E RID: 782
			private byte __Description231;

			// Token: 0x0400030F RID: 783
			private byte __Description232;

			// Token: 0x04000310 RID: 784
			private byte __Description233;

			// Token: 0x04000311 RID: 785
			private byte __Description234;

			// Token: 0x04000312 RID: 786
			private byte __Description235;

			// Token: 0x04000313 RID: 787
			private byte __Description236;

			// Token: 0x04000314 RID: 788
			private byte __Description237;

			// Token: 0x04000315 RID: 789
			private byte __Description238;

			// Token: 0x04000316 RID: 790
			private byte __Description239;

			// Token: 0x04000317 RID: 791
			private byte __Description240;

			// Token: 0x04000318 RID: 792
			private byte __Description241;

			// Token: 0x04000319 RID: 793
			private byte __Description242;

			// Token: 0x0400031A RID: 794
			private byte __Description243;

			// Token: 0x0400031B RID: 795
			private byte __Description244;

			// Token: 0x0400031C RID: 796
			private byte __Description245;

			// Token: 0x0400031D RID: 797
			private byte __Description246;

			// Token: 0x0400031E RID: 798
			private byte __Description247;

			// Token: 0x0400031F RID: 799
			private byte __Description248;

			// Token: 0x04000320 RID: 800
			private byte __Description249;

			// Token: 0x04000321 RID: 801
			private byte __Description250;

			// Token: 0x04000322 RID: 802
			private byte __Description251;

			// Token: 0x04000323 RID: 803
			private byte __Description252;

			// Token: 0x04000324 RID: 804
			private byte __Description253;

			// Token: 0x04000325 RID: 805
			private byte __Description254;

			// Token: 0x04000326 RID: 806
			private byte __Description255;

			// Token: 0x04000327 RID: 807
			private byte __Description256;

			// Token: 0x04000328 RID: 808
			private byte __Description257;

			// Token: 0x04000329 RID: 809
			private byte __Description258;

			// Token: 0x0400032A RID: 810
			private byte __Description259;

			// Token: 0x0400032B RID: 811
			private byte __Description260;

			// Token: 0x0400032C RID: 812
			private byte __Description261;

			// Token: 0x0400032D RID: 813
			private byte __Description262;

			// Token: 0x0400032E RID: 814
			private byte __Description263;

			// Token: 0x0400032F RID: 815
			private byte __Description264;

			// Token: 0x04000330 RID: 816
			private byte __Description265;

			// Token: 0x04000331 RID: 817
			private byte __Description266;

			// Token: 0x04000332 RID: 818
			private byte __Description267;

			// Token: 0x04000333 RID: 819
			private byte __Description268;

			// Token: 0x04000334 RID: 820
			private byte __Description269;

			// Token: 0x04000335 RID: 821
			private byte __Description270;

			// Token: 0x04000336 RID: 822
			private byte __Description271;

			// Token: 0x04000337 RID: 823
			private byte __Description272;

			// Token: 0x04000338 RID: 824
			private byte __Description273;

			// Token: 0x04000339 RID: 825
			private byte __Description274;

			// Token: 0x0400033A RID: 826
			private byte __Description275;

			// Token: 0x0400033B RID: 827
			private byte __Description276;

			// Token: 0x0400033C RID: 828
			private byte __Description277;

			// Token: 0x0400033D RID: 829
			private byte __Description278;

			// Token: 0x0400033E RID: 830
			private byte __Description279;

			// Token: 0x0400033F RID: 831
			private byte __Description280;

			// Token: 0x04000340 RID: 832
			private byte __Description281;

			// Token: 0x04000341 RID: 833
			private byte __Description282;

			// Token: 0x04000342 RID: 834
			private byte __Description283;

			// Token: 0x04000343 RID: 835
			private byte __Description284;

			// Token: 0x04000344 RID: 836
			private byte __Description285;

			// Token: 0x04000345 RID: 837
			private byte __Description286;

			// Token: 0x04000346 RID: 838
			private byte __Description287;

			// Token: 0x04000347 RID: 839
			private byte __Description288;

			// Token: 0x04000348 RID: 840
			private byte __Description289;

			// Token: 0x04000349 RID: 841
			private byte __Description290;

			// Token: 0x0400034A RID: 842
			private byte __Description291;

			// Token: 0x0400034B RID: 843
			private byte __Description292;

			// Token: 0x0400034C RID: 844
			private byte __Description293;

			// Token: 0x0400034D RID: 845
			private byte __Description294;

			// Token: 0x0400034E RID: 846
			private byte __Description295;

			// Token: 0x0400034F RID: 847
			private byte __Description296;

			// Token: 0x04000350 RID: 848
			private byte __Description297;

			// Token: 0x04000351 RID: 849
			private byte __Description298;

			// Token: 0x04000352 RID: 850
			private byte __Description299;

			// Token: 0x04000353 RID: 851
			private byte __Description300;

			// Token: 0x04000354 RID: 852
			private byte __Description301;

			// Token: 0x04000355 RID: 853
			private byte __Description302;

			// Token: 0x04000356 RID: 854
			private byte __Description303;

			// Token: 0x04000357 RID: 855
			private byte __Description304;

			// Token: 0x04000358 RID: 856
			private byte __Description305;

			// Token: 0x04000359 RID: 857
			private byte __Description306;

			// Token: 0x0400035A RID: 858
			private byte __Description307;

			// Token: 0x0400035B RID: 859
			private byte __Description308;

			// Token: 0x0400035C RID: 860
			private byte __Description309;

			// Token: 0x0400035D RID: 861
			private byte __Description310;

			// Token: 0x0400035E RID: 862
			private byte __Description311;

			// Token: 0x0400035F RID: 863
			private byte __Description312;

			// Token: 0x04000360 RID: 864
			private byte __Description313;

			// Token: 0x04000361 RID: 865
			private byte __Description314;

			// Token: 0x04000362 RID: 866
			private byte __Description315;

			// Token: 0x04000363 RID: 867
			private byte __Description316;

			// Token: 0x04000364 RID: 868
			private byte __Description317;

			// Token: 0x04000365 RID: 869
			private byte __Description318;

			// Token: 0x04000366 RID: 870
			private byte __Description319;

			// Token: 0x04000367 RID: 871
			private byte __Description320;

			// Token: 0x04000368 RID: 872
			private byte __Description321;

			// Token: 0x04000369 RID: 873
			private byte __Description322;

			// Token: 0x0400036A RID: 874
			private byte __Description323;

			// Token: 0x0400036B RID: 875
			private byte __Description324;

			// Token: 0x0400036C RID: 876
			private byte __Description325;

			// Token: 0x0400036D RID: 877
			private byte __Description326;

			// Token: 0x0400036E RID: 878
			private byte __Description327;

			// Token: 0x0400036F RID: 879
			private byte __Description328;

			// Token: 0x04000370 RID: 880
			private byte __Description329;

			// Token: 0x04000371 RID: 881
			private byte __Description330;

			// Token: 0x04000372 RID: 882
			private byte __Description331;

			// Token: 0x04000373 RID: 883
			private byte __Description332;

			// Token: 0x04000374 RID: 884
			private byte __Description333;

			// Token: 0x04000375 RID: 885
			private byte __Description334;

			// Token: 0x04000376 RID: 886
			private byte __Description335;

			// Token: 0x04000377 RID: 887
			private byte __Description336;

			// Token: 0x04000378 RID: 888
			private byte __Description337;

			// Token: 0x04000379 RID: 889
			private byte __Description338;

			// Token: 0x0400037A RID: 890
			private byte __Description339;

			// Token: 0x0400037B RID: 891
			private byte __Description340;

			// Token: 0x0400037C RID: 892
			private byte __Description341;

			// Token: 0x0400037D RID: 893
			private byte __Description342;

			// Token: 0x0400037E RID: 894
			private byte __Description343;

			// Token: 0x0400037F RID: 895
			private byte __Description344;

			// Token: 0x04000380 RID: 896
			private byte __Description345;

			// Token: 0x04000381 RID: 897
			private byte __Description346;

			// Token: 0x04000382 RID: 898
			private byte __Description347;

			// Token: 0x04000383 RID: 899
			private byte __Description348;

			// Token: 0x04000384 RID: 900
			private byte __Description349;

			// Token: 0x04000385 RID: 901
			private byte __Description350;

			// Token: 0x04000386 RID: 902
			private byte __Description351;

			// Token: 0x04000387 RID: 903
			private byte __Description352;

			// Token: 0x04000388 RID: 904
			private byte __Description353;

			// Token: 0x04000389 RID: 905
			private byte __Description354;

			// Token: 0x0400038A RID: 906
			private byte __Description355;

			// Token: 0x0400038B RID: 907
			private byte __Description356;

			// Token: 0x0400038C RID: 908
			private byte __Description357;

			// Token: 0x0400038D RID: 909
			private byte __Description358;

			// Token: 0x0400038E RID: 910
			private byte __Description359;

			// Token: 0x0400038F RID: 911
			private byte __Description360;

			// Token: 0x04000390 RID: 912
			private byte __Description361;

			// Token: 0x04000391 RID: 913
			private byte __Description362;

			// Token: 0x04000392 RID: 914
			private byte __Description363;

			// Token: 0x04000393 RID: 915
			private byte __Description364;

			// Token: 0x04000394 RID: 916
			private byte __Description365;

			// Token: 0x04000395 RID: 917
			private byte __Description366;

			// Token: 0x04000396 RID: 918
			private byte __Description367;

			// Token: 0x04000397 RID: 919
			private byte __Description368;

			// Token: 0x04000398 RID: 920
			private byte __Description369;

			// Token: 0x04000399 RID: 921
			private byte __Description370;

			// Token: 0x0400039A RID: 922
			private byte __Description371;

			// Token: 0x0400039B RID: 923
			private byte __Description372;

			// Token: 0x0400039C RID: 924
			private byte __Description373;

			// Token: 0x0400039D RID: 925
			private byte __Description374;

			// Token: 0x0400039E RID: 926
			private byte __Description375;

			// Token: 0x0400039F RID: 927
			private byte __Description376;

			// Token: 0x040003A0 RID: 928
			private byte __Description377;

			// Token: 0x040003A1 RID: 929
			private byte __Description378;

			// Token: 0x040003A2 RID: 930
			private byte __Description379;

			// Token: 0x040003A3 RID: 931
			private byte __Description380;

			// Token: 0x040003A4 RID: 932
			private byte __Description381;

			// Token: 0x040003A5 RID: 933
			private byte __Description382;

			// Token: 0x040003A6 RID: 934
			private byte __Description383;

			// Token: 0x040003A7 RID: 935
			private byte __Description384;

			// Token: 0x040003A8 RID: 936
			private byte __Description385;

			// Token: 0x040003A9 RID: 937
			private byte __Description386;

			// Token: 0x040003AA RID: 938
			private byte __Description387;

			// Token: 0x040003AB RID: 939
			private byte __Description388;

			// Token: 0x040003AC RID: 940
			private byte __Description389;

			// Token: 0x040003AD RID: 941
			private byte __Description390;

			// Token: 0x040003AE RID: 942
			private byte __Description391;

			// Token: 0x040003AF RID: 943
			private byte __Description392;

			// Token: 0x040003B0 RID: 944
			private byte __Description393;

			// Token: 0x040003B1 RID: 945
			private byte __Description394;

			// Token: 0x040003B2 RID: 946
			private byte __Description395;

			// Token: 0x040003B3 RID: 947
			private byte __Description396;

			// Token: 0x040003B4 RID: 948
			private byte __Description397;

			// Token: 0x040003B5 RID: 949
			private byte __Description398;

			// Token: 0x040003B6 RID: 950
			private byte __Description399;

			// Token: 0x040003B7 RID: 951
			private byte __Description400;

			// Token: 0x040003B8 RID: 952
			private byte __Description401;

			// Token: 0x040003B9 RID: 953
			private byte __Description402;

			// Token: 0x040003BA RID: 954
			private byte __Description403;

			// Token: 0x040003BB RID: 955
			private byte __Description404;

			// Token: 0x040003BC RID: 956
			private byte __Description405;

			// Token: 0x040003BD RID: 957
			private byte __Description406;

			// Token: 0x040003BE RID: 958
			private byte __Description407;

			// Token: 0x040003BF RID: 959
			private byte __Description408;

			// Token: 0x040003C0 RID: 960
			private byte __Description409;

			// Token: 0x040003C1 RID: 961
			private byte __Description410;

			// Token: 0x040003C2 RID: 962
			private byte __Description411;

			// Token: 0x040003C3 RID: 963
			private byte __Description412;

			// Token: 0x040003C4 RID: 964
			private byte __Description413;

			// Token: 0x040003C5 RID: 965
			private byte __Description414;

			// Token: 0x040003C6 RID: 966
			private byte __Description415;

			// Token: 0x040003C7 RID: 967
			private byte __Description416;

			// Token: 0x040003C8 RID: 968
			private byte __Description417;

			// Token: 0x040003C9 RID: 969
			private byte __Description418;

			// Token: 0x040003CA RID: 970
			private byte __Description419;

			// Token: 0x040003CB RID: 971
			private byte __Description420;

			// Token: 0x040003CC RID: 972
			private byte __Description421;

			// Token: 0x040003CD RID: 973
			private byte __Description422;

			// Token: 0x040003CE RID: 974
			private byte __Description423;

			// Token: 0x040003CF RID: 975
			private byte __Description424;

			// Token: 0x040003D0 RID: 976
			private byte __Description425;

			// Token: 0x040003D1 RID: 977
			private byte __Description426;

			// Token: 0x040003D2 RID: 978
			private byte __Description427;

			// Token: 0x040003D3 RID: 979
			private byte __Description428;

			// Token: 0x040003D4 RID: 980
			private byte __Description429;

			// Token: 0x040003D5 RID: 981
			private byte __Description430;

			// Token: 0x040003D6 RID: 982
			private byte __Description431;

			// Token: 0x040003D7 RID: 983
			private byte __Description432;

			// Token: 0x040003D8 RID: 984
			private byte __Description433;

			// Token: 0x040003D9 RID: 985
			private byte __Description434;

			// Token: 0x040003DA RID: 986
			private byte __Description435;

			// Token: 0x040003DB RID: 987
			private byte __Description436;

			// Token: 0x040003DC RID: 988
			private byte __Description437;

			// Token: 0x040003DD RID: 989
			private byte __Description438;

			// Token: 0x040003DE RID: 990
			private byte __Description439;

			// Token: 0x040003DF RID: 991
			private byte __Description440;

			// Token: 0x040003E0 RID: 992
			private byte __Description441;

			// Token: 0x040003E1 RID: 993
			private byte __Description442;

			// Token: 0x040003E2 RID: 994
			private byte __Description443;

			// Token: 0x040003E3 RID: 995
			private byte __Description444;

			// Token: 0x040003E4 RID: 996
			private byte __Description445;

			// Token: 0x040003E5 RID: 997
			private byte __Description446;

			// Token: 0x040003E6 RID: 998
			private byte __Description447;

			// Token: 0x040003E7 RID: 999
			private byte __Description448;

			// Token: 0x040003E8 RID: 1000
			private byte __Description449;

			// Token: 0x040003E9 RID: 1001
			private byte __Description450;

			// Token: 0x040003EA RID: 1002
			private byte __Description451;

			// Token: 0x040003EB RID: 1003
			private byte __Description452;

			// Token: 0x040003EC RID: 1004
			private byte __Description453;

			// Token: 0x040003ED RID: 1005
			private byte __Description454;

			// Token: 0x040003EE RID: 1006
			private byte __Description455;

			// Token: 0x040003EF RID: 1007
			private byte __Description456;

			// Token: 0x040003F0 RID: 1008
			private byte __Description457;

			// Token: 0x040003F1 RID: 1009
			private byte __Description458;

			// Token: 0x040003F2 RID: 1010
			private byte __Description459;

			// Token: 0x040003F3 RID: 1011
			private byte __Description460;

			// Token: 0x040003F4 RID: 1012
			private byte __Description461;

			// Token: 0x040003F5 RID: 1013
			private byte __Description462;

			// Token: 0x040003F6 RID: 1014
			private byte __Description463;

			// Token: 0x040003F7 RID: 1015
			private byte __Description464;

			// Token: 0x040003F8 RID: 1016
			private byte __Description465;

			// Token: 0x040003F9 RID: 1017
			private byte __Description466;

			// Token: 0x040003FA RID: 1018
			private byte __Description467;

			// Token: 0x040003FB RID: 1019
			private byte __Description468;

			// Token: 0x040003FC RID: 1020
			private byte __Description469;

			// Token: 0x040003FD RID: 1021
			private byte __Description470;

			// Token: 0x040003FE RID: 1022
			private byte __Description471;

			// Token: 0x040003FF RID: 1023
			private byte __Description472;

			// Token: 0x04000400 RID: 1024
			private byte __Description473;

			// Token: 0x04000401 RID: 1025
			private byte __Description474;

			// Token: 0x04000402 RID: 1026
			private byte __Description475;

			// Token: 0x04000403 RID: 1027
			private byte __Description476;

			// Token: 0x04000404 RID: 1028
			private byte __Description477;

			// Token: 0x04000405 RID: 1029
			private byte __Description478;

			// Token: 0x04000406 RID: 1030
			private byte __Description479;

			// Token: 0x04000407 RID: 1031
			private byte __Description480;

			// Token: 0x04000408 RID: 1032
			private byte __Description481;

			// Token: 0x04000409 RID: 1033
			private byte __Description482;

			// Token: 0x0400040A RID: 1034
			private byte __Description483;

			// Token: 0x0400040B RID: 1035
			private byte __Description484;

			// Token: 0x0400040C RID: 1036
			private byte __Description485;

			// Token: 0x0400040D RID: 1037
			private byte __Description486;

			// Token: 0x0400040E RID: 1038
			private byte __Description487;

			// Token: 0x0400040F RID: 1039
			private byte __Description488;

			// Token: 0x04000410 RID: 1040
			private byte __Description489;

			// Token: 0x04000411 RID: 1041
			private byte __Description490;

			// Token: 0x04000412 RID: 1042
			private byte __Description491;

			// Token: 0x04000413 RID: 1043
			private byte __Description492;

			// Token: 0x04000414 RID: 1044
			private byte __Description493;

			// Token: 0x04000415 RID: 1045
			private byte __Description494;

			// Token: 0x04000416 RID: 1046
			private byte __Description495;

			// Token: 0x04000417 RID: 1047
			private byte __Description496;

			// Token: 0x04000418 RID: 1048
			private byte __Description497;

			// Token: 0x04000419 RID: 1049
			private byte __Description498;

			// Token: 0x0400041A RID: 1050
			private byte __Description499;

			// Token: 0x0400041B RID: 1051
			private byte __Description500;

			// Token: 0x0400041C RID: 1052
			private byte __Description501;

			// Token: 0x0400041D RID: 1053
			private byte __Description502;

			// Token: 0x0400041E RID: 1054
			private byte __Description503;

			// Token: 0x0400041F RID: 1055
			private byte __Description504;

			// Token: 0x04000420 RID: 1056
			private byte __Description505;

			// Token: 0x04000421 RID: 1057
			private byte __Description506;

			// Token: 0x04000422 RID: 1058
			private byte __Description507;

			// Token: 0x04000423 RID: 1059
			private byte __Description508;

			// Token: 0x04000424 RID: 1060
			private byte __Description509;

			// Token: 0x04000425 RID: 1061
			private byte __Description510;

			// Token: 0x04000426 RID: 1062
			private byte __Description511;

			// Token: 0x04000427 RID: 1063
			public byte DeviceName;

			// Token: 0x04000428 RID: 1064
			private byte __DeviceName1;

			// Token: 0x04000429 RID: 1065
			private byte __DeviceName2;

			// Token: 0x0400042A RID: 1066
			private byte __DeviceName3;

			// Token: 0x0400042B RID: 1067
			private byte __DeviceName4;

			// Token: 0x0400042C RID: 1068
			private byte __DeviceName5;

			// Token: 0x0400042D RID: 1069
			private byte __DeviceName6;

			// Token: 0x0400042E RID: 1070
			private byte __DeviceName7;

			// Token: 0x0400042F RID: 1071
			private byte __DeviceName8;

			// Token: 0x04000430 RID: 1072
			private byte __DeviceName9;

			// Token: 0x04000431 RID: 1073
			private byte __DeviceName10;

			// Token: 0x04000432 RID: 1074
			private byte __DeviceName11;

			// Token: 0x04000433 RID: 1075
			private byte __DeviceName12;

			// Token: 0x04000434 RID: 1076
			private byte __DeviceName13;

			// Token: 0x04000435 RID: 1077
			private byte __DeviceName14;

			// Token: 0x04000436 RID: 1078
			private byte __DeviceName15;

			// Token: 0x04000437 RID: 1079
			private byte __DeviceName16;

			// Token: 0x04000438 RID: 1080
			private byte __DeviceName17;

			// Token: 0x04000439 RID: 1081
			private byte __DeviceName18;

			// Token: 0x0400043A RID: 1082
			private byte __DeviceName19;

			// Token: 0x0400043B RID: 1083
			private byte __DeviceName20;

			// Token: 0x0400043C RID: 1084
			private byte __DeviceName21;

			// Token: 0x0400043D RID: 1085
			private byte __DeviceName22;

			// Token: 0x0400043E RID: 1086
			private byte __DeviceName23;

			// Token: 0x0400043F RID: 1087
			private byte __DeviceName24;

			// Token: 0x04000440 RID: 1088
			private byte __DeviceName25;

			// Token: 0x04000441 RID: 1089
			private byte __DeviceName26;

			// Token: 0x04000442 RID: 1090
			private byte __DeviceName27;

			// Token: 0x04000443 RID: 1091
			private byte __DeviceName28;

			// Token: 0x04000444 RID: 1092
			private byte __DeviceName29;

			// Token: 0x04000445 RID: 1093
			private byte __DeviceName30;

			// Token: 0x04000446 RID: 1094
			private byte __DeviceName31;

			// Token: 0x04000447 RID: 1095
			public long RawDriverVersion;

			// Token: 0x04000448 RID: 1096
			public int VendorId;

			// Token: 0x04000449 RID: 1097
			public int DeviceId;

			// Token: 0x0400044A RID: 1098
			public int SubsystemId;

			// Token: 0x0400044B RID: 1099
			public int Revision;

			// Token: 0x0400044C RID: 1100
			public Guid DeviceIdentifier;

			// Token: 0x0400044D RID: 1101
			public int WhqlLevel;
		}
	}
}
