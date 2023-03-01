using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200007D RID: 125
	public struct GammaControl
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00007ED8 File Offset: 0x000060D8
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00007F02 File Offset: 0x00006102
		public RawColor4[] GammaCurve
		{
			get
			{
				RawColor4[] result;
				if ((result = this._GammaCurve) == null)
				{
					result = (this._GammaCurve = new RawColor4[1025]);
				}
				return result;
			}
			private set
			{
				this._GammaCurve = value;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref GammaControl.__Native @ref)
		{
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00007F0C File Offset: 0x0000610C
		internal unsafe void __MarshalFrom(ref GammaControl.__Native @ref)
		{
			this.Scale = @ref.Scale;
			this.Offset = @ref.Offset;
			fixed (RawColor4* ptr = &this.GammaCurve[0])
			{
				void* value = (void*)ptr;
				fixed (RawColor4* ptr2 = &@ref.GammaCurve)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 1025 * sizeof(RawColor4));
					ptr = null;
				}
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00007F70 File Offset: 0x00006170
		internal unsafe void __MarshalTo(ref GammaControl.__Native @ref)
		{
			@ref.Scale = this.Scale;
			@ref.Offset = this.Offset;
			fixed (RawColor4* ptr = &this.GammaCurve[0])
			{
				void* value = (void*)ptr;
				fixed (RawColor4* ptr2 = &@ref.GammaCurve)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 1025 * sizeof(RawColor4));
					ptr = null;
				}
			}
		}

		// Token: 0x0400040D RID: 1037
		public RawColor4 Scale;

		// Token: 0x0400040E RID: 1038
		public RawColor4 Offset;

		// Token: 0x0400040F RID: 1039
		internal RawColor4[] _GammaCurve;

		// Token: 0x0200007E RID: 126
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000410 RID: 1040
			public RawColor4 Scale;

			// Token: 0x04000411 RID: 1041
			public RawColor4 Offset;

			// Token: 0x04000412 RID: 1042
			public RawColor4 GammaCurve;

			// Token: 0x04000413 RID: 1043
			public RawColor4 __GammaCurve1;

			// Token: 0x04000414 RID: 1044
			public RawColor4 __GammaCurve2;

			// Token: 0x04000415 RID: 1045
			public RawColor4 __GammaCurve3;

			// Token: 0x04000416 RID: 1046
			public RawColor4 __GammaCurve4;

			// Token: 0x04000417 RID: 1047
			public RawColor4 __GammaCurve5;

			// Token: 0x04000418 RID: 1048
			public RawColor4 __GammaCurve6;

			// Token: 0x04000419 RID: 1049
			public RawColor4 __GammaCurve7;

			// Token: 0x0400041A RID: 1050
			public RawColor4 __GammaCurve8;

			// Token: 0x0400041B RID: 1051
			public RawColor4 __GammaCurve9;

			// Token: 0x0400041C RID: 1052
			public RawColor4 __GammaCurve10;

			// Token: 0x0400041D RID: 1053
			public RawColor4 __GammaCurve11;

			// Token: 0x0400041E RID: 1054
			public RawColor4 __GammaCurve12;

			// Token: 0x0400041F RID: 1055
			public RawColor4 __GammaCurve13;

			// Token: 0x04000420 RID: 1056
			public RawColor4 __GammaCurve14;

			// Token: 0x04000421 RID: 1057
			public RawColor4 __GammaCurve15;

			// Token: 0x04000422 RID: 1058
			public RawColor4 __GammaCurve16;

			// Token: 0x04000423 RID: 1059
			public RawColor4 __GammaCurve17;

			// Token: 0x04000424 RID: 1060
			public RawColor4 __GammaCurve18;

			// Token: 0x04000425 RID: 1061
			public RawColor4 __GammaCurve19;

			// Token: 0x04000426 RID: 1062
			public RawColor4 __GammaCurve20;

			// Token: 0x04000427 RID: 1063
			public RawColor4 __GammaCurve21;

			// Token: 0x04000428 RID: 1064
			public RawColor4 __GammaCurve22;

			// Token: 0x04000429 RID: 1065
			public RawColor4 __GammaCurve23;

			// Token: 0x0400042A RID: 1066
			public RawColor4 __GammaCurve24;

			// Token: 0x0400042B RID: 1067
			public RawColor4 __GammaCurve25;

			// Token: 0x0400042C RID: 1068
			public RawColor4 __GammaCurve26;

			// Token: 0x0400042D RID: 1069
			public RawColor4 __GammaCurve27;

			// Token: 0x0400042E RID: 1070
			public RawColor4 __GammaCurve28;

			// Token: 0x0400042F RID: 1071
			public RawColor4 __GammaCurve29;

			// Token: 0x04000430 RID: 1072
			public RawColor4 __GammaCurve30;

			// Token: 0x04000431 RID: 1073
			public RawColor4 __GammaCurve31;

			// Token: 0x04000432 RID: 1074
			public RawColor4 __GammaCurve32;

			// Token: 0x04000433 RID: 1075
			public RawColor4 __GammaCurve33;

			// Token: 0x04000434 RID: 1076
			public RawColor4 __GammaCurve34;

			// Token: 0x04000435 RID: 1077
			public RawColor4 __GammaCurve35;

			// Token: 0x04000436 RID: 1078
			public RawColor4 __GammaCurve36;

			// Token: 0x04000437 RID: 1079
			public RawColor4 __GammaCurve37;

			// Token: 0x04000438 RID: 1080
			public RawColor4 __GammaCurve38;

			// Token: 0x04000439 RID: 1081
			public RawColor4 __GammaCurve39;

			// Token: 0x0400043A RID: 1082
			public RawColor4 __GammaCurve40;

			// Token: 0x0400043B RID: 1083
			public RawColor4 __GammaCurve41;

			// Token: 0x0400043C RID: 1084
			public RawColor4 __GammaCurve42;

			// Token: 0x0400043D RID: 1085
			public RawColor4 __GammaCurve43;

			// Token: 0x0400043E RID: 1086
			public RawColor4 __GammaCurve44;

			// Token: 0x0400043F RID: 1087
			public RawColor4 __GammaCurve45;

			// Token: 0x04000440 RID: 1088
			public RawColor4 __GammaCurve46;

			// Token: 0x04000441 RID: 1089
			public RawColor4 __GammaCurve47;

			// Token: 0x04000442 RID: 1090
			public RawColor4 __GammaCurve48;

			// Token: 0x04000443 RID: 1091
			public RawColor4 __GammaCurve49;

			// Token: 0x04000444 RID: 1092
			public RawColor4 __GammaCurve50;

			// Token: 0x04000445 RID: 1093
			public RawColor4 __GammaCurve51;

			// Token: 0x04000446 RID: 1094
			public RawColor4 __GammaCurve52;

			// Token: 0x04000447 RID: 1095
			public RawColor4 __GammaCurve53;

			// Token: 0x04000448 RID: 1096
			public RawColor4 __GammaCurve54;

			// Token: 0x04000449 RID: 1097
			public RawColor4 __GammaCurve55;

			// Token: 0x0400044A RID: 1098
			public RawColor4 __GammaCurve56;

			// Token: 0x0400044B RID: 1099
			public RawColor4 __GammaCurve57;

			// Token: 0x0400044C RID: 1100
			public RawColor4 __GammaCurve58;

			// Token: 0x0400044D RID: 1101
			public RawColor4 __GammaCurve59;

			// Token: 0x0400044E RID: 1102
			public RawColor4 __GammaCurve60;

			// Token: 0x0400044F RID: 1103
			public RawColor4 __GammaCurve61;

			// Token: 0x04000450 RID: 1104
			public RawColor4 __GammaCurve62;

			// Token: 0x04000451 RID: 1105
			public RawColor4 __GammaCurve63;

			// Token: 0x04000452 RID: 1106
			public RawColor4 __GammaCurve64;

			// Token: 0x04000453 RID: 1107
			public RawColor4 __GammaCurve65;

			// Token: 0x04000454 RID: 1108
			public RawColor4 __GammaCurve66;

			// Token: 0x04000455 RID: 1109
			public RawColor4 __GammaCurve67;

			// Token: 0x04000456 RID: 1110
			public RawColor4 __GammaCurve68;

			// Token: 0x04000457 RID: 1111
			public RawColor4 __GammaCurve69;

			// Token: 0x04000458 RID: 1112
			public RawColor4 __GammaCurve70;

			// Token: 0x04000459 RID: 1113
			public RawColor4 __GammaCurve71;

			// Token: 0x0400045A RID: 1114
			public RawColor4 __GammaCurve72;

			// Token: 0x0400045B RID: 1115
			public RawColor4 __GammaCurve73;

			// Token: 0x0400045C RID: 1116
			public RawColor4 __GammaCurve74;

			// Token: 0x0400045D RID: 1117
			public RawColor4 __GammaCurve75;

			// Token: 0x0400045E RID: 1118
			public RawColor4 __GammaCurve76;

			// Token: 0x0400045F RID: 1119
			public RawColor4 __GammaCurve77;

			// Token: 0x04000460 RID: 1120
			public RawColor4 __GammaCurve78;

			// Token: 0x04000461 RID: 1121
			public RawColor4 __GammaCurve79;

			// Token: 0x04000462 RID: 1122
			public RawColor4 __GammaCurve80;

			// Token: 0x04000463 RID: 1123
			public RawColor4 __GammaCurve81;

			// Token: 0x04000464 RID: 1124
			public RawColor4 __GammaCurve82;

			// Token: 0x04000465 RID: 1125
			public RawColor4 __GammaCurve83;

			// Token: 0x04000466 RID: 1126
			public RawColor4 __GammaCurve84;

			// Token: 0x04000467 RID: 1127
			public RawColor4 __GammaCurve85;

			// Token: 0x04000468 RID: 1128
			public RawColor4 __GammaCurve86;

			// Token: 0x04000469 RID: 1129
			public RawColor4 __GammaCurve87;

			// Token: 0x0400046A RID: 1130
			public RawColor4 __GammaCurve88;

			// Token: 0x0400046B RID: 1131
			public RawColor4 __GammaCurve89;

			// Token: 0x0400046C RID: 1132
			public RawColor4 __GammaCurve90;

			// Token: 0x0400046D RID: 1133
			public RawColor4 __GammaCurve91;

			// Token: 0x0400046E RID: 1134
			public RawColor4 __GammaCurve92;

			// Token: 0x0400046F RID: 1135
			public RawColor4 __GammaCurve93;

			// Token: 0x04000470 RID: 1136
			public RawColor4 __GammaCurve94;

			// Token: 0x04000471 RID: 1137
			public RawColor4 __GammaCurve95;

			// Token: 0x04000472 RID: 1138
			public RawColor4 __GammaCurve96;

			// Token: 0x04000473 RID: 1139
			public RawColor4 __GammaCurve97;

			// Token: 0x04000474 RID: 1140
			public RawColor4 __GammaCurve98;

			// Token: 0x04000475 RID: 1141
			public RawColor4 __GammaCurve99;

			// Token: 0x04000476 RID: 1142
			public RawColor4 __GammaCurve100;

			// Token: 0x04000477 RID: 1143
			public RawColor4 __GammaCurve101;

			// Token: 0x04000478 RID: 1144
			public RawColor4 __GammaCurve102;

			// Token: 0x04000479 RID: 1145
			public RawColor4 __GammaCurve103;

			// Token: 0x0400047A RID: 1146
			public RawColor4 __GammaCurve104;

			// Token: 0x0400047B RID: 1147
			public RawColor4 __GammaCurve105;

			// Token: 0x0400047C RID: 1148
			public RawColor4 __GammaCurve106;

			// Token: 0x0400047D RID: 1149
			public RawColor4 __GammaCurve107;

			// Token: 0x0400047E RID: 1150
			public RawColor4 __GammaCurve108;

			// Token: 0x0400047F RID: 1151
			public RawColor4 __GammaCurve109;

			// Token: 0x04000480 RID: 1152
			public RawColor4 __GammaCurve110;

			// Token: 0x04000481 RID: 1153
			public RawColor4 __GammaCurve111;

			// Token: 0x04000482 RID: 1154
			public RawColor4 __GammaCurve112;

			// Token: 0x04000483 RID: 1155
			public RawColor4 __GammaCurve113;

			// Token: 0x04000484 RID: 1156
			public RawColor4 __GammaCurve114;

			// Token: 0x04000485 RID: 1157
			public RawColor4 __GammaCurve115;

			// Token: 0x04000486 RID: 1158
			public RawColor4 __GammaCurve116;

			// Token: 0x04000487 RID: 1159
			public RawColor4 __GammaCurve117;

			// Token: 0x04000488 RID: 1160
			public RawColor4 __GammaCurve118;

			// Token: 0x04000489 RID: 1161
			public RawColor4 __GammaCurve119;

			// Token: 0x0400048A RID: 1162
			public RawColor4 __GammaCurve120;

			// Token: 0x0400048B RID: 1163
			public RawColor4 __GammaCurve121;

			// Token: 0x0400048C RID: 1164
			public RawColor4 __GammaCurve122;

			// Token: 0x0400048D RID: 1165
			public RawColor4 __GammaCurve123;

			// Token: 0x0400048E RID: 1166
			public RawColor4 __GammaCurve124;

			// Token: 0x0400048F RID: 1167
			public RawColor4 __GammaCurve125;

			// Token: 0x04000490 RID: 1168
			public RawColor4 __GammaCurve126;

			// Token: 0x04000491 RID: 1169
			public RawColor4 __GammaCurve127;

			// Token: 0x04000492 RID: 1170
			public RawColor4 __GammaCurve128;

			// Token: 0x04000493 RID: 1171
			public RawColor4 __GammaCurve129;

			// Token: 0x04000494 RID: 1172
			public RawColor4 __GammaCurve130;

			// Token: 0x04000495 RID: 1173
			public RawColor4 __GammaCurve131;

			// Token: 0x04000496 RID: 1174
			public RawColor4 __GammaCurve132;

			// Token: 0x04000497 RID: 1175
			public RawColor4 __GammaCurve133;

			// Token: 0x04000498 RID: 1176
			public RawColor4 __GammaCurve134;

			// Token: 0x04000499 RID: 1177
			public RawColor4 __GammaCurve135;

			// Token: 0x0400049A RID: 1178
			public RawColor4 __GammaCurve136;

			// Token: 0x0400049B RID: 1179
			public RawColor4 __GammaCurve137;

			// Token: 0x0400049C RID: 1180
			public RawColor4 __GammaCurve138;

			// Token: 0x0400049D RID: 1181
			public RawColor4 __GammaCurve139;

			// Token: 0x0400049E RID: 1182
			public RawColor4 __GammaCurve140;

			// Token: 0x0400049F RID: 1183
			public RawColor4 __GammaCurve141;

			// Token: 0x040004A0 RID: 1184
			public RawColor4 __GammaCurve142;

			// Token: 0x040004A1 RID: 1185
			public RawColor4 __GammaCurve143;

			// Token: 0x040004A2 RID: 1186
			public RawColor4 __GammaCurve144;

			// Token: 0x040004A3 RID: 1187
			public RawColor4 __GammaCurve145;

			// Token: 0x040004A4 RID: 1188
			public RawColor4 __GammaCurve146;

			// Token: 0x040004A5 RID: 1189
			public RawColor4 __GammaCurve147;

			// Token: 0x040004A6 RID: 1190
			public RawColor4 __GammaCurve148;

			// Token: 0x040004A7 RID: 1191
			public RawColor4 __GammaCurve149;

			// Token: 0x040004A8 RID: 1192
			public RawColor4 __GammaCurve150;

			// Token: 0x040004A9 RID: 1193
			public RawColor4 __GammaCurve151;

			// Token: 0x040004AA RID: 1194
			public RawColor4 __GammaCurve152;

			// Token: 0x040004AB RID: 1195
			public RawColor4 __GammaCurve153;

			// Token: 0x040004AC RID: 1196
			public RawColor4 __GammaCurve154;

			// Token: 0x040004AD RID: 1197
			public RawColor4 __GammaCurve155;

			// Token: 0x040004AE RID: 1198
			public RawColor4 __GammaCurve156;

			// Token: 0x040004AF RID: 1199
			public RawColor4 __GammaCurve157;

			// Token: 0x040004B0 RID: 1200
			public RawColor4 __GammaCurve158;

			// Token: 0x040004B1 RID: 1201
			public RawColor4 __GammaCurve159;

			// Token: 0x040004B2 RID: 1202
			public RawColor4 __GammaCurve160;

			// Token: 0x040004B3 RID: 1203
			public RawColor4 __GammaCurve161;

			// Token: 0x040004B4 RID: 1204
			public RawColor4 __GammaCurve162;

			// Token: 0x040004B5 RID: 1205
			public RawColor4 __GammaCurve163;

			// Token: 0x040004B6 RID: 1206
			public RawColor4 __GammaCurve164;

			// Token: 0x040004B7 RID: 1207
			public RawColor4 __GammaCurve165;

			// Token: 0x040004B8 RID: 1208
			public RawColor4 __GammaCurve166;

			// Token: 0x040004B9 RID: 1209
			public RawColor4 __GammaCurve167;

			// Token: 0x040004BA RID: 1210
			public RawColor4 __GammaCurve168;

			// Token: 0x040004BB RID: 1211
			public RawColor4 __GammaCurve169;

			// Token: 0x040004BC RID: 1212
			public RawColor4 __GammaCurve170;

			// Token: 0x040004BD RID: 1213
			public RawColor4 __GammaCurve171;

			// Token: 0x040004BE RID: 1214
			public RawColor4 __GammaCurve172;

			// Token: 0x040004BF RID: 1215
			public RawColor4 __GammaCurve173;

			// Token: 0x040004C0 RID: 1216
			public RawColor4 __GammaCurve174;

			// Token: 0x040004C1 RID: 1217
			public RawColor4 __GammaCurve175;

			// Token: 0x040004C2 RID: 1218
			public RawColor4 __GammaCurve176;

			// Token: 0x040004C3 RID: 1219
			public RawColor4 __GammaCurve177;

			// Token: 0x040004C4 RID: 1220
			public RawColor4 __GammaCurve178;

			// Token: 0x040004C5 RID: 1221
			public RawColor4 __GammaCurve179;

			// Token: 0x040004C6 RID: 1222
			public RawColor4 __GammaCurve180;

			// Token: 0x040004C7 RID: 1223
			public RawColor4 __GammaCurve181;

			// Token: 0x040004C8 RID: 1224
			public RawColor4 __GammaCurve182;

			// Token: 0x040004C9 RID: 1225
			public RawColor4 __GammaCurve183;

			// Token: 0x040004CA RID: 1226
			public RawColor4 __GammaCurve184;

			// Token: 0x040004CB RID: 1227
			public RawColor4 __GammaCurve185;

			// Token: 0x040004CC RID: 1228
			public RawColor4 __GammaCurve186;

			// Token: 0x040004CD RID: 1229
			public RawColor4 __GammaCurve187;

			// Token: 0x040004CE RID: 1230
			public RawColor4 __GammaCurve188;

			// Token: 0x040004CF RID: 1231
			public RawColor4 __GammaCurve189;

			// Token: 0x040004D0 RID: 1232
			public RawColor4 __GammaCurve190;

			// Token: 0x040004D1 RID: 1233
			public RawColor4 __GammaCurve191;

			// Token: 0x040004D2 RID: 1234
			public RawColor4 __GammaCurve192;

			// Token: 0x040004D3 RID: 1235
			public RawColor4 __GammaCurve193;

			// Token: 0x040004D4 RID: 1236
			public RawColor4 __GammaCurve194;

			// Token: 0x040004D5 RID: 1237
			public RawColor4 __GammaCurve195;

			// Token: 0x040004D6 RID: 1238
			public RawColor4 __GammaCurve196;

			// Token: 0x040004D7 RID: 1239
			public RawColor4 __GammaCurve197;

			// Token: 0x040004D8 RID: 1240
			public RawColor4 __GammaCurve198;

			// Token: 0x040004D9 RID: 1241
			public RawColor4 __GammaCurve199;

			// Token: 0x040004DA RID: 1242
			public RawColor4 __GammaCurve200;

			// Token: 0x040004DB RID: 1243
			public RawColor4 __GammaCurve201;

			// Token: 0x040004DC RID: 1244
			public RawColor4 __GammaCurve202;

			// Token: 0x040004DD RID: 1245
			public RawColor4 __GammaCurve203;

			// Token: 0x040004DE RID: 1246
			public RawColor4 __GammaCurve204;

			// Token: 0x040004DF RID: 1247
			public RawColor4 __GammaCurve205;

			// Token: 0x040004E0 RID: 1248
			public RawColor4 __GammaCurve206;

			// Token: 0x040004E1 RID: 1249
			public RawColor4 __GammaCurve207;

			// Token: 0x040004E2 RID: 1250
			public RawColor4 __GammaCurve208;

			// Token: 0x040004E3 RID: 1251
			public RawColor4 __GammaCurve209;

			// Token: 0x040004E4 RID: 1252
			public RawColor4 __GammaCurve210;

			// Token: 0x040004E5 RID: 1253
			public RawColor4 __GammaCurve211;

			// Token: 0x040004E6 RID: 1254
			public RawColor4 __GammaCurve212;

			// Token: 0x040004E7 RID: 1255
			public RawColor4 __GammaCurve213;

			// Token: 0x040004E8 RID: 1256
			public RawColor4 __GammaCurve214;

			// Token: 0x040004E9 RID: 1257
			public RawColor4 __GammaCurve215;

			// Token: 0x040004EA RID: 1258
			public RawColor4 __GammaCurve216;

			// Token: 0x040004EB RID: 1259
			public RawColor4 __GammaCurve217;

			// Token: 0x040004EC RID: 1260
			public RawColor4 __GammaCurve218;

			// Token: 0x040004ED RID: 1261
			public RawColor4 __GammaCurve219;

			// Token: 0x040004EE RID: 1262
			public RawColor4 __GammaCurve220;

			// Token: 0x040004EF RID: 1263
			public RawColor4 __GammaCurve221;

			// Token: 0x040004F0 RID: 1264
			public RawColor4 __GammaCurve222;

			// Token: 0x040004F1 RID: 1265
			public RawColor4 __GammaCurve223;

			// Token: 0x040004F2 RID: 1266
			public RawColor4 __GammaCurve224;

			// Token: 0x040004F3 RID: 1267
			public RawColor4 __GammaCurve225;

			// Token: 0x040004F4 RID: 1268
			public RawColor4 __GammaCurve226;

			// Token: 0x040004F5 RID: 1269
			public RawColor4 __GammaCurve227;

			// Token: 0x040004F6 RID: 1270
			public RawColor4 __GammaCurve228;

			// Token: 0x040004F7 RID: 1271
			public RawColor4 __GammaCurve229;

			// Token: 0x040004F8 RID: 1272
			public RawColor4 __GammaCurve230;

			// Token: 0x040004F9 RID: 1273
			public RawColor4 __GammaCurve231;

			// Token: 0x040004FA RID: 1274
			public RawColor4 __GammaCurve232;

			// Token: 0x040004FB RID: 1275
			public RawColor4 __GammaCurve233;

			// Token: 0x040004FC RID: 1276
			public RawColor4 __GammaCurve234;

			// Token: 0x040004FD RID: 1277
			public RawColor4 __GammaCurve235;

			// Token: 0x040004FE RID: 1278
			public RawColor4 __GammaCurve236;

			// Token: 0x040004FF RID: 1279
			public RawColor4 __GammaCurve237;

			// Token: 0x04000500 RID: 1280
			public RawColor4 __GammaCurve238;

			// Token: 0x04000501 RID: 1281
			public RawColor4 __GammaCurve239;

			// Token: 0x04000502 RID: 1282
			public RawColor4 __GammaCurve240;

			// Token: 0x04000503 RID: 1283
			public RawColor4 __GammaCurve241;

			// Token: 0x04000504 RID: 1284
			public RawColor4 __GammaCurve242;

			// Token: 0x04000505 RID: 1285
			public RawColor4 __GammaCurve243;

			// Token: 0x04000506 RID: 1286
			public RawColor4 __GammaCurve244;

			// Token: 0x04000507 RID: 1287
			public RawColor4 __GammaCurve245;

			// Token: 0x04000508 RID: 1288
			public RawColor4 __GammaCurve246;

			// Token: 0x04000509 RID: 1289
			public RawColor4 __GammaCurve247;

			// Token: 0x0400050A RID: 1290
			public RawColor4 __GammaCurve248;

			// Token: 0x0400050B RID: 1291
			public RawColor4 __GammaCurve249;

			// Token: 0x0400050C RID: 1292
			public RawColor4 __GammaCurve250;

			// Token: 0x0400050D RID: 1293
			public RawColor4 __GammaCurve251;

			// Token: 0x0400050E RID: 1294
			public RawColor4 __GammaCurve252;

			// Token: 0x0400050F RID: 1295
			public RawColor4 __GammaCurve253;

			// Token: 0x04000510 RID: 1296
			public RawColor4 __GammaCurve254;

			// Token: 0x04000511 RID: 1297
			public RawColor4 __GammaCurve255;

			// Token: 0x04000512 RID: 1298
			public RawColor4 __GammaCurve256;

			// Token: 0x04000513 RID: 1299
			public RawColor4 __GammaCurve257;

			// Token: 0x04000514 RID: 1300
			public RawColor4 __GammaCurve258;

			// Token: 0x04000515 RID: 1301
			public RawColor4 __GammaCurve259;

			// Token: 0x04000516 RID: 1302
			public RawColor4 __GammaCurve260;

			// Token: 0x04000517 RID: 1303
			public RawColor4 __GammaCurve261;

			// Token: 0x04000518 RID: 1304
			public RawColor4 __GammaCurve262;

			// Token: 0x04000519 RID: 1305
			public RawColor4 __GammaCurve263;

			// Token: 0x0400051A RID: 1306
			public RawColor4 __GammaCurve264;

			// Token: 0x0400051B RID: 1307
			public RawColor4 __GammaCurve265;

			// Token: 0x0400051C RID: 1308
			public RawColor4 __GammaCurve266;

			// Token: 0x0400051D RID: 1309
			public RawColor4 __GammaCurve267;

			// Token: 0x0400051E RID: 1310
			public RawColor4 __GammaCurve268;

			// Token: 0x0400051F RID: 1311
			public RawColor4 __GammaCurve269;

			// Token: 0x04000520 RID: 1312
			public RawColor4 __GammaCurve270;

			// Token: 0x04000521 RID: 1313
			public RawColor4 __GammaCurve271;

			// Token: 0x04000522 RID: 1314
			public RawColor4 __GammaCurve272;

			// Token: 0x04000523 RID: 1315
			public RawColor4 __GammaCurve273;

			// Token: 0x04000524 RID: 1316
			public RawColor4 __GammaCurve274;

			// Token: 0x04000525 RID: 1317
			public RawColor4 __GammaCurve275;

			// Token: 0x04000526 RID: 1318
			public RawColor4 __GammaCurve276;

			// Token: 0x04000527 RID: 1319
			public RawColor4 __GammaCurve277;

			// Token: 0x04000528 RID: 1320
			public RawColor4 __GammaCurve278;

			// Token: 0x04000529 RID: 1321
			public RawColor4 __GammaCurve279;

			// Token: 0x0400052A RID: 1322
			public RawColor4 __GammaCurve280;

			// Token: 0x0400052B RID: 1323
			public RawColor4 __GammaCurve281;

			// Token: 0x0400052C RID: 1324
			public RawColor4 __GammaCurve282;

			// Token: 0x0400052D RID: 1325
			public RawColor4 __GammaCurve283;

			// Token: 0x0400052E RID: 1326
			public RawColor4 __GammaCurve284;

			// Token: 0x0400052F RID: 1327
			public RawColor4 __GammaCurve285;

			// Token: 0x04000530 RID: 1328
			public RawColor4 __GammaCurve286;

			// Token: 0x04000531 RID: 1329
			public RawColor4 __GammaCurve287;

			// Token: 0x04000532 RID: 1330
			public RawColor4 __GammaCurve288;

			// Token: 0x04000533 RID: 1331
			public RawColor4 __GammaCurve289;

			// Token: 0x04000534 RID: 1332
			public RawColor4 __GammaCurve290;

			// Token: 0x04000535 RID: 1333
			public RawColor4 __GammaCurve291;

			// Token: 0x04000536 RID: 1334
			public RawColor4 __GammaCurve292;

			// Token: 0x04000537 RID: 1335
			public RawColor4 __GammaCurve293;

			// Token: 0x04000538 RID: 1336
			public RawColor4 __GammaCurve294;

			// Token: 0x04000539 RID: 1337
			public RawColor4 __GammaCurve295;

			// Token: 0x0400053A RID: 1338
			public RawColor4 __GammaCurve296;

			// Token: 0x0400053B RID: 1339
			public RawColor4 __GammaCurve297;

			// Token: 0x0400053C RID: 1340
			public RawColor4 __GammaCurve298;

			// Token: 0x0400053D RID: 1341
			public RawColor4 __GammaCurve299;

			// Token: 0x0400053E RID: 1342
			public RawColor4 __GammaCurve300;

			// Token: 0x0400053F RID: 1343
			public RawColor4 __GammaCurve301;

			// Token: 0x04000540 RID: 1344
			public RawColor4 __GammaCurve302;

			// Token: 0x04000541 RID: 1345
			public RawColor4 __GammaCurve303;

			// Token: 0x04000542 RID: 1346
			public RawColor4 __GammaCurve304;

			// Token: 0x04000543 RID: 1347
			public RawColor4 __GammaCurve305;

			// Token: 0x04000544 RID: 1348
			public RawColor4 __GammaCurve306;

			// Token: 0x04000545 RID: 1349
			public RawColor4 __GammaCurve307;

			// Token: 0x04000546 RID: 1350
			public RawColor4 __GammaCurve308;

			// Token: 0x04000547 RID: 1351
			public RawColor4 __GammaCurve309;

			// Token: 0x04000548 RID: 1352
			public RawColor4 __GammaCurve310;

			// Token: 0x04000549 RID: 1353
			public RawColor4 __GammaCurve311;

			// Token: 0x0400054A RID: 1354
			public RawColor4 __GammaCurve312;

			// Token: 0x0400054B RID: 1355
			public RawColor4 __GammaCurve313;

			// Token: 0x0400054C RID: 1356
			public RawColor4 __GammaCurve314;

			// Token: 0x0400054D RID: 1357
			public RawColor4 __GammaCurve315;

			// Token: 0x0400054E RID: 1358
			public RawColor4 __GammaCurve316;

			// Token: 0x0400054F RID: 1359
			public RawColor4 __GammaCurve317;

			// Token: 0x04000550 RID: 1360
			public RawColor4 __GammaCurve318;

			// Token: 0x04000551 RID: 1361
			public RawColor4 __GammaCurve319;

			// Token: 0x04000552 RID: 1362
			public RawColor4 __GammaCurve320;

			// Token: 0x04000553 RID: 1363
			public RawColor4 __GammaCurve321;

			// Token: 0x04000554 RID: 1364
			public RawColor4 __GammaCurve322;

			// Token: 0x04000555 RID: 1365
			public RawColor4 __GammaCurve323;

			// Token: 0x04000556 RID: 1366
			public RawColor4 __GammaCurve324;

			// Token: 0x04000557 RID: 1367
			public RawColor4 __GammaCurve325;

			// Token: 0x04000558 RID: 1368
			public RawColor4 __GammaCurve326;

			// Token: 0x04000559 RID: 1369
			public RawColor4 __GammaCurve327;

			// Token: 0x0400055A RID: 1370
			public RawColor4 __GammaCurve328;

			// Token: 0x0400055B RID: 1371
			public RawColor4 __GammaCurve329;

			// Token: 0x0400055C RID: 1372
			public RawColor4 __GammaCurve330;

			// Token: 0x0400055D RID: 1373
			public RawColor4 __GammaCurve331;

			// Token: 0x0400055E RID: 1374
			public RawColor4 __GammaCurve332;

			// Token: 0x0400055F RID: 1375
			public RawColor4 __GammaCurve333;

			// Token: 0x04000560 RID: 1376
			public RawColor4 __GammaCurve334;

			// Token: 0x04000561 RID: 1377
			public RawColor4 __GammaCurve335;

			// Token: 0x04000562 RID: 1378
			public RawColor4 __GammaCurve336;

			// Token: 0x04000563 RID: 1379
			public RawColor4 __GammaCurve337;

			// Token: 0x04000564 RID: 1380
			public RawColor4 __GammaCurve338;

			// Token: 0x04000565 RID: 1381
			public RawColor4 __GammaCurve339;

			// Token: 0x04000566 RID: 1382
			public RawColor4 __GammaCurve340;

			// Token: 0x04000567 RID: 1383
			public RawColor4 __GammaCurve341;

			// Token: 0x04000568 RID: 1384
			public RawColor4 __GammaCurve342;

			// Token: 0x04000569 RID: 1385
			public RawColor4 __GammaCurve343;

			// Token: 0x0400056A RID: 1386
			public RawColor4 __GammaCurve344;

			// Token: 0x0400056B RID: 1387
			public RawColor4 __GammaCurve345;

			// Token: 0x0400056C RID: 1388
			public RawColor4 __GammaCurve346;

			// Token: 0x0400056D RID: 1389
			public RawColor4 __GammaCurve347;

			// Token: 0x0400056E RID: 1390
			public RawColor4 __GammaCurve348;

			// Token: 0x0400056F RID: 1391
			public RawColor4 __GammaCurve349;

			// Token: 0x04000570 RID: 1392
			public RawColor4 __GammaCurve350;

			// Token: 0x04000571 RID: 1393
			public RawColor4 __GammaCurve351;

			// Token: 0x04000572 RID: 1394
			public RawColor4 __GammaCurve352;

			// Token: 0x04000573 RID: 1395
			public RawColor4 __GammaCurve353;

			// Token: 0x04000574 RID: 1396
			public RawColor4 __GammaCurve354;

			// Token: 0x04000575 RID: 1397
			public RawColor4 __GammaCurve355;

			// Token: 0x04000576 RID: 1398
			public RawColor4 __GammaCurve356;

			// Token: 0x04000577 RID: 1399
			public RawColor4 __GammaCurve357;

			// Token: 0x04000578 RID: 1400
			public RawColor4 __GammaCurve358;

			// Token: 0x04000579 RID: 1401
			public RawColor4 __GammaCurve359;

			// Token: 0x0400057A RID: 1402
			public RawColor4 __GammaCurve360;

			// Token: 0x0400057B RID: 1403
			public RawColor4 __GammaCurve361;

			// Token: 0x0400057C RID: 1404
			public RawColor4 __GammaCurve362;

			// Token: 0x0400057D RID: 1405
			public RawColor4 __GammaCurve363;

			// Token: 0x0400057E RID: 1406
			public RawColor4 __GammaCurve364;

			// Token: 0x0400057F RID: 1407
			public RawColor4 __GammaCurve365;

			// Token: 0x04000580 RID: 1408
			public RawColor4 __GammaCurve366;

			// Token: 0x04000581 RID: 1409
			public RawColor4 __GammaCurve367;

			// Token: 0x04000582 RID: 1410
			public RawColor4 __GammaCurve368;

			// Token: 0x04000583 RID: 1411
			public RawColor4 __GammaCurve369;

			// Token: 0x04000584 RID: 1412
			public RawColor4 __GammaCurve370;

			// Token: 0x04000585 RID: 1413
			public RawColor4 __GammaCurve371;

			// Token: 0x04000586 RID: 1414
			public RawColor4 __GammaCurve372;

			// Token: 0x04000587 RID: 1415
			public RawColor4 __GammaCurve373;

			// Token: 0x04000588 RID: 1416
			public RawColor4 __GammaCurve374;

			// Token: 0x04000589 RID: 1417
			public RawColor4 __GammaCurve375;

			// Token: 0x0400058A RID: 1418
			public RawColor4 __GammaCurve376;

			// Token: 0x0400058B RID: 1419
			public RawColor4 __GammaCurve377;

			// Token: 0x0400058C RID: 1420
			public RawColor4 __GammaCurve378;

			// Token: 0x0400058D RID: 1421
			public RawColor4 __GammaCurve379;

			// Token: 0x0400058E RID: 1422
			public RawColor4 __GammaCurve380;

			// Token: 0x0400058F RID: 1423
			public RawColor4 __GammaCurve381;

			// Token: 0x04000590 RID: 1424
			public RawColor4 __GammaCurve382;

			// Token: 0x04000591 RID: 1425
			public RawColor4 __GammaCurve383;

			// Token: 0x04000592 RID: 1426
			public RawColor4 __GammaCurve384;

			// Token: 0x04000593 RID: 1427
			public RawColor4 __GammaCurve385;

			// Token: 0x04000594 RID: 1428
			public RawColor4 __GammaCurve386;

			// Token: 0x04000595 RID: 1429
			public RawColor4 __GammaCurve387;

			// Token: 0x04000596 RID: 1430
			public RawColor4 __GammaCurve388;

			// Token: 0x04000597 RID: 1431
			public RawColor4 __GammaCurve389;

			// Token: 0x04000598 RID: 1432
			public RawColor4 __GammaCurve390;

			// Token: 0x04000599 RID: 1433
			public RawColor4 __GammaCurve391;

			// Token: 0x0400059A RID: 1434
			public RawColor4 __GammaCurve392;

			// Token: 0x0400059B RID: 1435
			public RawColor4 __GammaCurve393;

			// Token: 0x0400059C RID: 1436
			public RawColor4 __GammaCurve394;

			// Token: 0x0400059D RID: 1437
			public RawColor4 __GammaCurve395;

			// Token: 0x0400059E RID: 1438
			public RawColor4 __GammaCurve396;

			// Token: 0x0400059F RID: 1439
			public RawColor4 __GammaCurve397;

			// Token: 0x040005A0 RID: 1440
			public RawColor4 __GammaCurve398;

			// Token: 0x040005A1 RID: 1441
			public RawColor4 __GammaCurve399;

			// Token: 0x040005A2 RID: 1442
			public RawColor4 __GammaCurve400;

			// Token: 0x040005A3 RID: 1443
			public RawColor4 __GammaCurve401;

			// Token: 0x040005A4 RID: 1444
			public RawColor4 __GammaCurve402;

			// Token: 0x040005A5 RID: 1445
			public RawColor4 __GammaCurve403;

			// Token: 0x040005A6 RID: 1446
			public RawColor4 __GammaCurve404;

			// Token: 0x040005A7 RID: 1447
			public RawColor4 __GammaCurve405;

			// Token: 0x040005A8 RID: 1448
			public RawColor4 __GammaCurve406;

			// Token: 0x040005A9 RID: 1449
			public RawColor4 __GammaCurve407;

			// Token: 0x040005AA RID: 1450
			public RawColor4 __GammaCurve408;

			// Token: 0x040005AB RID: 1451
			public RawColor4 __GammaCurve409;

			// Token: 0x040005AC RID: 1452
			public RawColor4 __GammaCurve410;

			// Token: 0x040005AD RID: 1453
			public RawColor4 __GammaCurve411;

			// Token: 0x040005AE RID: 1454
			public RawColor4 __GammaCurve412;

			// Token: 0x040005AF RID: 1455
			public RawColor4 __GammaCurve413;

			// Token: 0x040005B0 RID: 1456
			public RawColor4 __GammaCurve414;

			// Token: 0x040005B1 RID: 1457
			public RawColor4 __GammaCurve415;

			// Token: 0x040005B2 RID: 1458
			public RawColor4 __GammaCurve416;

			// Token: 0x040005B3 RID: 1459
			public RawColor4 __GammaCurve417;

			// Token: 0x040005B4 RID: 1460
			public RawColor4 __GammaCurve418;

			// Token: 0x040005B5 RID: 1461
			public RawColor4 __GammaCurve419;

			// Token: 0x040005B6 RID: 1462
			public RawColor4 __GammaCurve420;

			// Token: 0x040005B7 RID: 1463
			public RawColor4 __GammaCurve421;

			// Token: 0x040005B8 RID: 1464
			public RawColor4 __GammaCurve422;

			// Token: 0x040005B9 RID: 1465
			public RawColor4 __GammaCurve423;

			// Token: 0x040005BA RID: 1466
			public RawColor4 __GammaCurve424;

			// Token: 0x040005BB RID: 1467
			public RawColor4 __GammaCurve425;

			// Token: 0x040005BC RID: 1468
			public RawColor4 __GammaCurve426;

			// Token: 0x040005BD RID: 1469
			public RawColor4 __GammaCurve427;

			// Token: 0x040005BE RID: 1470
			public RawColor4 __GammaCurve428;

			// Token: 0x040005BF RID: 1471
			public RawColor4 __GammaCurve429;

			// Token: 0x040005C0 RID: 1472
			public RawColor4 __GammaCurve430;

			// Token: 0x040005C1 RID: 1473
			public RawColor4 __GammaCurve431;

			// Token: 0x040005C2 RID: 1474
			public RawColor4 __GammaCurve432;

			// Token: 0x040005C3 RID: 1475
			public RawColor4 __GammaCurve433;

			// Token: 0x040005C4 RID: 1476
			public RawColor4 __GammaCurve434;

			// Token: 0x040005C5 RID: 1477
			public RawColor4 __GammaCurve435;

			// Token: 0x040005C6 RID: 1478
			public RawColor4 __GammaCurve436;

			// Token: 0x040005C7 RID: 1479
			public RawColor4 __GammaCurve437;

			// Token: 0x040005C8 RID: 1480
			public RawColor4 __GammaCurve438;

			// Token: 0x040005C9 RID: 1481
			public RawColor4 __GammaCurve439;

			// Token: 0x040005CA RID: 1482
			public RawColor4 __GammaCurve440;

			// Token: 0x040005CB RID: 1483
			public RawColor4 __GammaCurve441;

			// Token: 0x040005CC RID: 1484
			public RawColor4 __GammaCurve442;

			// Token: 0x040005CD RID: 1485
			public RawColor4 __GammaCurve443;

			// Token: 0x040005CE RID: 1486
			public RawColor4 __GammaCurve444;

			// Token: 0x040005CF RID: 1487
			public RawColor4 __GammaCurve445;

			// Token: 0x040005D0 RID: 1488
			public RawColor4 __GammaCurve446;

			// Token: 0x040005D1 RID: 1489
			public RawColor4 __GammaCurve447;

			// Token: 0x040005D2 RID: 1490
			public RawColor4 __GammaCurve448;

			// Token: 0x040005D3 RID: 1491
			public RawColor4 __GammaCurve449;

			// Token: 0x040005D4 RID: 1492
			public RawColor4 __GammaCurve450;

			// Token: 0x040005D5 RID: 1493
			public RawColor4 __GammaCurve451;

			// Token: 0x040005D6 RID: 1494
			public RawColor4 __GammaCurve452;

			// Token: 0x040005D7 RID: 1495
			public RawColor4 __GammaCurve453;

			// Token: 0x040005D8 RID: 1496
			public RawColor4 __GammaCurve454;

			// Token: 0x040005D9 RID: 1497
			public RawColor4 __GammaCurve455;

			// Token: 0x040005DA RID: 1498
			public RawColor4 __GammaCurve456;

			// Token: 0x040005DB RID: 1499
			public RawColor4 __GammaCurve457;

			// Token: 0x040005DC RID: 1500
			public RawColor4 __GammaCurve458;

			// Token: 0x040005DD RID: 1501
			public RawColor4 __GammaCurve459;

			// Token: 0x040005DE RID: 1502
			public RawColor4 __GammaCurve460;

			// Token: 0x040005DF RID: 1503
			public RawColor4 __GammaCurve461;

			// Token: 0x040005E0 RID: 1504
			public RawColor4 __GammaCurve462;

			// Token: 0x040005E1 RID: 1505
			public RawColor4 __GammaCurve463;

			// Token: 0x040005E2 RID: 1506
			public RawColor4 __GammaCurve464;

			// Token: 0x040005E3 RID: 1507
			public RawColor4 __GammaCurve465;

			// Token: 0x040005E4 RID: 1508
			public RawColor4 __GammaCurve466;

			// Token: 0x040005E5 RID: 1509
			public RawColor4 __GammaCurve467;

			// Token: 0x040005E6 RID: 1510
			public RawColor4 __GammaCurve468;

			// Token: 0x040005E7 RID: 1511
			public RawColor4 __GammaCurve469;

			// Token: 0x040005E8 RID: 1512
			public RawColor4 __GammaCurve470;

			// Token: 0x040005E9 RID: 1513
			public RawColor4 __GammaCurve471;

			// Token: 0x040005EA RID: 1514
			public RawColor4 __GammaCurve472;

			// Token: 0x040005EB RID: 1515
			public RawColor4 __GammaCurve473;

			// Token: 0x040005EC RID: 1516
			public RawColor4 __GammaCurve474;

			// Token: 0x040005ED RID: 1517
			public RawColor4 __GammaCurve475;

			// Token: 0x040005EE RID: 1518
			public RawColor4 __GammaCurve476;

			// Token: 0x040005EF RID: 1519
			public RawColor4 __GammaCurve477;

			// Token: 0x040005F0 RID: 1520
			public RawColor4 __GammaCurve478;

			// Token: 0x040005F1 RID: 1521
			public RawColor4 __GammaCurve479;

			// Token: 0x040005F2 RID: 1522
			public RawColor4 __GammaCurve480;

			// Token: 0x040005F3 RID: 1523
			public RawColor4 __GammaCurve481;

			// Token: 0x040005F4 RID: 1524
			public RawColor4 __GammaCurve482;

			// Token: 0x040005F5 RID: 1525
			public RawColor4 __GammaCurve483;

			// Token: 0x040005F6 RID: 1526
			public RawColor4 __GammaCurve484;

			// Token: 0x040005F7 RID: 1527
			public RawColor4 __GammaCurve485;

			// Token: 0x040005F8 RID: 1528
			public RawColor4 __GammaCurve486;

			// Token: 0x040005F9 RID: 1529
			public RawColor4 __GammaCurve487;

			// Token: 0x040005FA RID: 1530
			public RawColor4 __GammaCurve488;

			// Token: 0x040005FB RID: 1531
			public RawColor4 __GammaCurve489;

			// Token: 0x040005FC RID: 1532
			public RawColor4 __GammaCurve490;

			// Token: 0x040005FD RID: 1533
			public RawColor4 __GammaCurve491;

			// Token: 0x040005FE RID: 1534
			public RawColor4 __GammaCurve492;

			// Token: 0x040005FF RID: 1535
			public RawColor4 __GammaCurve493;

			// Token: 0x04000600 RID: 1536
			public RawColor4 __GammaCurve494;

			// Token: 0x04000601 RID: 1537
			public RawColor4 __GammaCurve495;

			// Token: 0x04000602 RID: 1538
			public RawColor4 __GammaCurve496;

			// Token: 0x04000603 RID: 1539
			public RawColor4 __GammaCurve497;

			// Token: 0x04000604 RID: 1540
			public RawColor4 __GammaCurve498;

			// Token: 0x04000605 RID: 1541
			public RawColor4 __GammaCurve499;

			// Token: 0x04000606 RID: 1542
			public RawColor4 __GammaCurve500;

			// Token: 0x04000607 RID: 1543
			public RawColor4 __GammaCurve501;

			// Token: 0x04000608 RID: 1544
			public RawColor4 __GammaCurve502;

			// Token: 0x04000609 RID: 1545
			public RawColor4 __GammaCurve503;

			// Token: 0x0400060A RID: 1546
			public RawColor4 __GammaCurve504;

			// Token: 0x0400060B RID: 1547
			public RawColor4 __GammaCurve505;

			// Token: 0x0400060C RID: 1548
			public RawColor4 __GammaCurve506;

			// Token: 0x0400060D RID: 1549
			public RawColor4 __GammaCurve507;

			// Token: 0x0400060E RID: 1550
			public RawColor4 __GammaCurve508;

			// Token: 0x0400060F RID: 1551
			public RawColor4 __GammaCurve509;

			// Token: 0x04000610 RID: 1552
			public RawColor4 __GammaCurve510;

			// Token: 0x04000611 RID: 1553
			public RawColor4 __GammaCurve511;

			// Token: 0x04000612 RID: 1554
			public RawColor4 __GammaCurve512;

			// Token: 0x04000613 RID: 1555
			public RawColor4 __GammaCurve513;

			// Token: 0x04000614 RID: 1556
			public RawColor4 __GammaCurve514;

			// Token: 0x04000615 RID: 1557
			public RawColor4 __GammaCurve515;

			// Token: 0x04000616 RID: 1558
			public RawColor4 __GammaCurve516;

			// Token: 0x04000617 RID: 1559
			public RawColor4 __GammaCurve517;

			// Token: 0x04000618 RID: 1560
			public RawColor4 __GammaCurve518;

			// Token: 0x04000619 RID: 1561
			public RawColor4 __GammaCurve519;

			// Token: 0x0400061A RID: 1562
			public RawColor4 __GammaCurve520;

			// Token: 0x0400061B RID: 1563
			public RawColor4 __GammaCurve521;

			// Token: 0x0400061C RID: 1564
			public RawColor4 __GammaCurve522;

			// Token: 0x0400061D RID: 1565
			public RawColor4 __GammaCurve523;

			// Token: 0x0400061E RID: 1566
			public RawColor4 __GammaCurve524;

			// Token: 0x0400061F RID: 1567
			public RawColor4 __GammaCurve525;

			// Token: 0x04000620 RID: 1568
			public RawColor4 __GammaCurve526;

			// Token: 0x04000621 RID: 1569
			public RawColor4 __GammaCurve527;

			// Token: 0x04000622 RID: 1570
			public RawColor4 __GammaCurve528;

			// Token: 0x04000623 RID: 1571
			public RawColor4 __GammaCurve529;

			// Token: 0x04000624 RID: 1572
			public RawColor4 __GammaCurve530;

			// Token: 0x04000625 RID: 1573
			public RawColor4 __GammaCurve531;

			// Token: 0x04000626 RID: 1574
			public RawColor4 __GammaCurve532;

			// Token: 0x04000627 RID: 1575
			public RawColor4 __GammaCurve533;

			// Token: 0x04000628 RID: 1576
			public RawColor4 __GammaCurve534;

			// Token: 0x04000629 RID: 1577
			public RawColor4 __GammaCurve535;

			// Token: 0x0400062A RID: 1578
			public RawColor4 __GammaCurve536;

			// Token: 0x0400062B RID: 1579
			public RawColor4 __GammaCurve537;

			// Token: 0x0400062C RID: 1580
			public RawColor4 __GammaCurve538;

			// Token: 0x0400062D RID: 1581
			public RawColor4 __GammaCurve539;

			// Token: 0x0400062E RID: 1582
			public RawColor4 __GammaCurve540;

			// Token: 0x0400062F RID: 1583
			public RawColor4 __GammaCurve541;

			// Token: 0x04000630 RID: 1584
			public RawColor4 __GammaCurve542;

			// Token: 0x04000631 RID: 1585
			public RawColor4 __GammaCurve543;

			// Token: 0x04000632 RID: 1586
			public RawColor4 __GammaCurve544;

			// Token: 0x04000633 RID: 1587
			public RawColor4 __GammaCurve545;

			// Token: 0x04000634 RID: 1588
			public RawColor4 __GammaCurve546;

			// Token: 0x04000635 RID: 1589
			public RawColor4 __GammaCurve547;

			// Token: 0x04000636 RID: 1590
			public RawColor4 __GammaCurve548;

			// Token: 0x04000637 RID: 1591
			public RawColor4 __GammaCurve549;

			// Token: 0x04000638 RID: 1592
			public RawColor4 __GammaCurve550;

			// Token: 0x04000639 RID: 1593
			public RawColor4 __GammaCurve551;

			// Token: 0x0400063A RID: 1594
			public RawColor4 __GammaCurve552;

			// Token: 0x0400063B RID: 1595
			public RawColor4 __GammaCurve553;

			// Token: 0x0400063C RID: 1596
			public RawColor4 __GammaCurve554;

			// Token: 0x0400063D RID: 1597
			public RawColor4 __GammaCurve555;

			// Token: 0x0400063E RID: 1598
			public RawColor4 __GammaCurve556;

			// Token: 0x0400063F RID: 1599
			public RawColor4 __GammaCurve557;

			// Token: 0x04000640 RID: 1600
			public RawColor4 __GammaCurve558;

			// Token: 0x04000641 RID: 1601
			public RawColor4 __GammaCurve559;

			// Token: 0x04000642 RID: 1602
			public RawColor4 __GammaCurve560;

			// Token: 0x04000643 RID: 1603
			public RawColor4 __GammaCurve561;

			// Token: 0x04000644 RID: 1604
			public RawColor4 __GammaCurve562;

			// Token: 0x04000645 RID: 1605
			public RawColor4 __GammaCurve563;

			// Token: 0x04000646 RID: 1606
			public RawColor4 __GammaCurve564;

			// Token: 0x04000647 RID: 1607
			public RawColor4 __GammaCurve565;

			// Token: 0x04000648 RID: 1608
			public RawColor4 __GammaCurve566;

			// Token: 0x04000649 RID: 1609
			public RawColor4 __GammaCurve567;

			// Token: 0x0400064A RID: 1610
			public RawColor4 __GammaCurve568;

			// Token: 0x0400064B RID: 1611
			public RawColor4 __GammaCurve569;

			// Token: 0x0400064C RID: 1612
			public RawColor4 __GammaCurve570;

			// Token: 0x0400064D RID: 1613
			public RawColor4 __GammaCurve571;

			// Token: 0x0400064E RID: 1614
			public RawColor4 __GammaCurve572;

			// Token: 0x0400064F RID: 1615
			public RawColor4 __GammaCurve573;

			// Token: 0x04000650 RID: 1616
			public RawColor4 __GammaCurve574;

			// Token: 0x04000651 RID: 1617
			public RawColor4 __GammaCurve575;

			// Token: 0x04000652 RID: 1618
			public RawColor4 __GammaCurve576;

			// Token: 0x04000653 RID: 1619
			public RawColor4 __GammaCurve577;

			// Token: 0x04000654 RID: 1620
			public RawColor4 __GammaCurve578;

			// Token: 0x04000655 RID: 1621
			public RawColor4 __GammaCurve579;

			// Token: 0x04000656 RID: 1622
			public RawColor4 __GammaCurve580;

			// Token: 0x04000657 RID: 1623
			public RawColor4 __GammaCurve581;

			// Token: 0x04000658 RID: 1624
			public RawColor4 __GammaCurve582;

			// Token: 0x04000659 RID: 1625
			public RawColor4 __GammaCurve583;

			// Token: 0x0400065A RID: 1626
			public RawColor4 __GammaCurve584;

			// Token: 0x0400065B RID: 1627
			public RawColor4 __GammaCurve585;

			// Token: 0x0400065C RID: 1628
			public RawColor4 __GammaCurve586;

			// Token: 0x0400065D RID: 1629
			public RawColor4 __GammaCurve587;

			// Token: 0x0400065E RID: 1630
			public RawColor4 __GammaCurve588;

			// Token: 0x0400065F RID: 1631
			public RawColor4 __GammaCurve589;

			// Token: 0x04000660 RID: 1632
			public RawColor4 __GammaCurve590;

			// Token: 0x04000661 RID: 1633
			public RawColor4 __GammaCurve591;

			// Token: 0x04000662 RID: 1634
			public RawColor4 __GammaCurve592;

			// Token: 0x04000663 RID: 1635
			public RawColor4 __GammaCurve593;

			// Token: 0x04000664 RID: 1636
			public RawColor4 __GammaCurve594;

			// Token: 0x04000665 RID: 1637
			public RawColor4 __GammaCurve595;

			// Token: 0x04000666 RID: 1638
			public RawColor4 __GammaCurve596;

			// Token: 0x04000667 RID: 1639
			public RawColor4 __GammaCurve597;

			// Token: 0x04000668 RID: 1640
			public RawColor4 __GammaCurve598;

			// Token: 0x04000669 RID: 1641
			public RawColor4 __GammaCurve599;

			// Token: 0x0400066A RID: 1642
			public RawColor4 __GammaCurve600;

			// Token: 0x0400066B RID: 1643
			public RawColor4 __GammaCurve601;

			// Token: 0x0400066C RID: 1644
			public RawColor4 __GammaCurve602;

			// Token: 0x0400066D RID: 1645
			public RawColor4 __GammaCurve603;

			// Token: 0x0400066E RID: 1646
			public RawColor4 __GammaCurve604;

			// Token: 0x0400066F RID: 1647
			public RawColor4 __GammaCurve605;

			// Token: 0x04000670 RID: 1648
			public RawColor4 __GammaCurve606;

			// Token: 0x04000671 RID: 1649
			public RawColor4 __GammaCurve607;

			// Token: 0x04000672 RID: 1650
			public RawColor4 __GammaCurve608;

			// Token: 0x04000673 RID: 1651
			public RawColor4 __GammaCurve609;

			// Token: 0x04000674 RID: 1652
			public RawColor4 __GammaCurve610;

			// Token: 0x04000675 RID: 1653
			public RawColor4 __GammaCurve611;

			// Token: 0x04000676 RID: 1654
			public RawColor4 __GammaCurve612;

			// Token: 0x04000677 RID: 1655
			public RawColor4 __GammaCurve613;

			// Token: 0x04000678 RID: 1656
			public RawColor4 __GammaCurve614;

			// Token: 0x04000679 RID: 1657
			public RawColor4 __GammaCurve615;

			// Token: 0x0400067A RID: 1658
			public RawColor4 __GammaCurve616;

			// Token: 0x0400067B RID: 1659
			public RawColor4 __GammaCurve617;

			// Token: 0x0400067C RID: 1660
			public RawColor4 __GammaCurve618;

			// Token: 0x0400067D RID: 1661
			public RawColor4 __GammaCurve619;

			// Token: 0x0400067E RID: 1662
			public RawColor4 __GammaCurve620;

			// Token: 0x0400067F RID: 1663
			public RawColor4 __GammaCurve621;

			// Token: 0x04000680 RID: 1664
			public RawColor4 __GammaCurve622;

			// Token: 0x04000681 RID: 1665
			public RawColor4 __GammaCurve623;

			// Token: 0x04000682 RID: 1666
			public RawColor4 __GammaCurve624;

			// Token: 0x04000683 RID: 1667
			public RawColor4 __GammaCurve625;

			// Token: 0x04000684 RID: 1668
			public RawColor4 __GammaCurve626;

			// Token: 0x04000685 RID: 1669
			public RawColor4 __GammaCurve627;

			// Token: 0x04000686 RID: 1670
			public RawColor4 __GammaCurve628;

			// Token: 0x04000687 RID: 1671
			public RawColor4 __GammaCurve629;

			// Token: 0x04000688 RID: 1672
			public RawColor4 __GammaCurve630;

			// Token: 0x04000689 RID: 1673
			public RawColor4 __GammaCurve631;

			// Token: 0x0400068A RID: 1674
			public RawColor4 __GammaCurve632;

			// Token: 0x0400068B RID: 1675
			public RawColor4 __GammaCurve633;

			// Token: 0x0400068C RID: 1676
			public RawColor4 __GammaCurve634;

			// Token: 0x0400068D RID: 1677
			public RawColor4 __GammaCurve635;

			// Token: 0x0400068E RID: 1678
			public RawColor4 __GammaCurve636;

			// Token: 0x0400068F RID: 1679
			public RawColor4 __GammaCurve637;

			// Token: 0x04000690 RID: 1680
			public RawColor4 __GammaCurve638;

			// Token: 0x04000691 RID: 1681
			public RawColor4 __GammaCurve639;

			// Token: 0x04000692 RID: 1682
			public RawColor4 __GammaCurve640;

			// Token: 0x04000693 RID: 1683
			public RawColor4 __GammaCurve641;

			// Token: 0x04000694 RID: 1684
			public RawColor4 __GammaCurve642;

			// Token: 0x04000695 RID: 1685
			public RawColor4 __GammaCurve643;

			// Token: 0x04000696 RID: 1686
			public RawColor4 __GammaCurve644;

			// Token: 0x04000697 RID: 1687
			public RawColor4 __GammaCurve645;

			// Token: 0x04000698 RID: 1688
			public RawColor4 __GammaCurve646;

			// Token: 0x04000699 RID: 1689
			public RawColor4 __GammaCurve647;

			// Token: 0x0400069A RID: 1690
			public RawColor4 __GammaCurve648;

			// Token: 0x0400069B RID: 1691
			public RawColor4 __GammaCurve649;

			// Token: 0x0400069C RID: 1692
			public RawColor4 __GammaCurve650;

			// Token: 0x0400069D RID: 1693
			public RawColor4 __GammaCurve651;

			// Token: 0x0400069E RID: 1694
			public RawColor4 __GammaCurve652;

			// Token: 0x0400069F RID: 1695
			public RawColor4 __GammaCurve653;

			// Token: 0x040006A0 RID: 1696
			public RawColor4 __GammaCurve654;

			// Token: 0x040006A1 RID: 1697
			public RawColor4 __GammaCurve655;

			// Token: 0x040006A2 RID: 1698
			public RawColor4 __GammaCurve656;

			// Token: 0x040006A3 RID: 1699
			public RawColor4 __GammaCurve657;

			// Token: 0x040006A4 RID: 1700
			public RawColor4 __GammaCurve658;

			// Token: 0x040006A5 RID: 1701
			public RawColor4 __GammaCurve659;

			// Token: 0x040006A6 RID: 1702
			public RawColor4 __GammaCurve660;

			// Token: 0x040006A7 RID: 1703
			public RawColor4 __GammaCurve661;

			// Token: 0x040006A8 RID: 1704
			public RawColor4 __GammaCurve662;

			// Token: 0x040006A9 RID: 1705
			public RawColor4 __GammaCurve663;

			// Token: 0x040006AA RID: 1706
			public RawColor4 __GammaCurve664;

			// Token: 0x040006AB RID: 1707
			public RawColor4 __GammaCurve665;

			// Token: 0x040006AC RID: 1708
			public RawColor4 __GammaCurve666;

			// Token: 0x040006AD RID: 1709
			public RawColor4 __GammaCurve667;

			// Token: 0x040006AE RID: 1710
			public RawColor4 __GammaCurve668;

			// Token: 0x040006AF RID: 1711
			public RawColor4 __GammaCurve669;

			// Token: 0x040006B0 RID: 1712
			public RawColor4 __GammaCurve670;

			// Token: 0x040006B1 RID: 1713
			public RawColor4 __GammaCurve671;

			// Token: 0x040006B2 RID: 1714
			public RawColor4 __GammaCurve672;

			// Token: 0x040006B3 RID: 1715
			public RawColor4 __GammaCurve673;

			// Token: 0x040006B4 RID: 1716
			public RawColor4 __GammaCurve674;

			// Token: 0x040006B5 RID: 1717
			public RawColor4 __GammaCurve675;

			// Token: 0x040006B6 RID: 1718
			public RawColor4 __GammaCurve676;

			// Token: 0x040006B7 RID: 1719
			public RawColor4 __GammaCurve677;

			// Token: 0x040006B8 RID: 1720
			public RawColor4 __GammaCurve678;

			// Token: 0x040006B9 RID: 1721
			public RawColor4 __GammaCurve679;

			// Token: 0x040006BA RID: 1722
			public RawColor4 __GammaCurve680;

			// Token: 0x040006BB RID: 1723
			public RawColor4 __GammaCurve681;

			// Token: 0x040006BC RID: 1724
			public RawColor4 __GammaCurve682;

			// Token: 0x040006BD RID: 1725
			public RawColor4 __GammaCurve683;

			// Token: 0x040006BE RID: 1726
			public RawColor4 __GammaCurve684;

			// Token: 0x040006BF RID: 1727
			public RawColor4 __GammaCurve685;

			// Token: 0x040006C0 RID: 1728
			public RawColor4 __GammaCurve686;

			// Token: 0x040006C1 RID: 1729
			public RawColor4 __GammaCurve687;

			// Token: 0x040006C2 RID: 1730
			public RawColor4 __GammaCurve688;

			// Token: 0x040006C3 RID: 1731
			public RawColor4 __GammaCurve689;

			// Token: 0x040006C4 RID: 1732
			public RawColor4 __GammaCurve690;

			// Token: 0x040006C5 RID: 1733
			public RawColor4 __GammaCurve691;

			// Token: 0x040006C6 RID: 1734
			public RawColor4 __GammaCurve692;

			// Token: 0x040006C7 RID: 1735
			public RawColor4 __GammaCurve693;

			// Token: 0x040006C8 RID: 1736
			public RawColor4 __GammaCurve694;

			// Token: 0x040006C9 RID: 1737
			public RawColor4 __GammaCurve695;

			// Token: 0x040006CA RID: 1738
			public RawColor4 __GammaCurve696;

			// Token: 0x040006CB RID: 1739
			public RawColor4 __GammaCurve697;

			// Token: 0x040006CC RID: 1740
			public RawColor4 __GammaCurve698;

			// Token: 0x040006CD RID: 1741
			public RawColor4 __GammaCurve699;

			// Token: 0x040006CE RID: 1742
			public RawColor4 __GammaCurve700;

			// Token: 0x040006CF RID: 1743
			public RawColor4 __GammaCurve701;

			// Token: 0x040006D0 RID: 1744
			public RawColor4 __GammaCurve702;

			// Token: 0x040006D1 RID: 1745
			public RawColor4 __GammaCurve703;

			// Token: 0x040006D2 RID: 1746
			public RawColor4 __GammaCurve704;

			// Token: 0x040006D3 RID: 1747
			public RawColor4 __GammaCurve705;

			// Token: 0x040006D4 RID: 1748
			public RawColor4 __GammaCurve706;

			// Token: 0x040006D5 RID: 1749
			public RawColor4 __GammaCurve707;

			// Token: 0x040006D6 RID: 1750
			public RawColor4 __GammaCurve708;

			// Token: 0x040006D7 RID: 1751
			public RawColor4 __GammaCurve709;

			// Token: 0x040006D8 RID: 1752
			public RawColor4 __GammaCurve710;

			// Token: 0x040006D9 RID: 1753
			public RawColor4 __GammaCurve711;

			// Token: 0x040006DA RID: 1754
			public RawColor4 __GammaCurve712;

			// Token: 0x040006DB RID: 1755
			public RawColor4 __GammaCurve713;

			// Token: 0x040006DC RID: 1756
			public RawColor4 __GammaCurve714;

			// Token: 0x040006DD RID: 1757
			public RawColor4 __GammaCurve715;

			// Token: 0x040006DE RID: 1758
			public RawColor4 __GammaCurve716;

			// Token: 0x040006DF RID: 1759
			public RawColor4 __GammaCurve717;

			// Token: 0x040006E0 RID: 1760
			public RawColor4 __GammaCurve718;

			// Token: 0x040006E1 RID: 1761
			public RawColor4 __GammaCurve719;

			// Token: 0x040006E2 RID: 1762
			public RawColor4 __GammaCurve720;

			// Token: 0x040006E3 RID: 1763
			public RawColor4 __GammaCurve721;

			// Token: 0x040006E4 RID: 1764
			public RawColor4 __GammaCurve722;

			// Token: 0x040006E5 RID: 1765
			public RawColor4 __GammaCurve723;

			// Token: 0x040006E6 RID: 1766
			public RawColor4 __GammaCurve724;

			// Token: 0x040006E7 RID: 1767
			public RawColor4 __GammaCurve725;

			// Token: 0x040006E8 RID: 1768
			public RawColor4 __GammaCurve726;

			// Token: 0x040006E9 RID: 1769
			public RawColor4 __GammaCurve727;

			// Token: 0x040006EA RID: 1770
			public RawColor4 __GammaCurve728;

			// Token: 0x040006EB RID: 1771
			public RawColor4 __GammaCurve729;

			// Token: 0x040006EC RID: 1772
			public RawColor4 __GammaCurve730;

			// Token: 0x040006ED RID: 1773
			public RawColor4 __GammaCurve731;

			// Token: 0x040006EE RID: 1774
			public RawColor4 __GammaCurve732;

			// Token: 0x040006EF RID: 1775
			public RawColor4 __GammaCurve733;

			// Token: 0x040006F0 RID: 1776
			public RawColor4 __GammaCurve734;

			// Token: 0x040006F1 RID: 1777
			public RawColor4 __GammaCurve735;

			// Token: 0x040006F2 RID: 1778
			public RawColor4 __GammaCurve736;

			// Token: 0x040006F3 RID: 1779
			public RawColor4 __GammaCurve737;

			// Token: 0x040006F4 RID: 1780
			public RawColor4 __GammaCurve738;

			// Token: 0x040006F5 RID: 1781
			public RawColor4 __GammaCurve739;

			// Token: 0x040006F6 RID: 1782
			public RawColor4 __GammaCurve740;

			// Token: 0x040006F7 RID: 1783
			public RawColor4 __GammaCurve741;

			// Token: 0x040006F8 RID: 1784
			public RawColor4 __GammaCurve742;

			// Token: 0x040006F9 RID: 1785
			public RawColor4 __GammaCurve743;

			// Token: 0x040006FA RID: 1786
			public RawColor4 __GammaCurve744;

			// Token: 0x040006FB RID: 1787
			public RawColor4 __GammaCurve745;

			// Token: 0x040006FC RID: 1788
			public RawColor4 __GammaCurve746;

			// Token: 0x040006FD RID: 1789
			public RawColor4 __GammaCurve747;

			// Token: 0x040006FE RID: 1790
			public RawColor4 __GammaCurve748;

			// Token: 0x040006FF RID: 1791
			public RawColor4 __GammaCurve749;

			// Token: 0x04000700 RID: 1792
			public RawColor4 __GammaCurve750;

			// Token: 0x04000701 RID: 1793
			public RawColor4 __GammaCurve751;

			// Token: 0x04000702 RID: 1794
			public RawColor4 __GammaCurve752;

			// Token: 0x04000703 RID: 1795
			public RawColor4 __GammaCurve753;

			// Token: 0x04000704 RID: 1796
			public RawColor4 __GammaCurve754;

			// Token: 0x04000705 RID: 1797
			public RawColor4 __GammaCurve755;

			// Token: 0x04000706 RID: 1798
			public RawColor4 __GammaCurve756;

			// Token: 0x04000707 RID: 1799
			public RawColor4 __GammaCurve757;

			// Token: 0x04000708 RID: 1800
			public RawColor4 __GammaCurve758;

			// Token: 0x04000709 RID: 1801
			public RawColor4 __GammaCurve759;

			// Token: 0x0400070A RID: 1802
			public RawColor4 __GammaCurve760;

			// Token: 0x0400070B RID: 1803
			public RawColor4 __GammaCurve761;

			// Token: 0x0400070C RID: 1804
			public RawColor4 __GammaCurve762;

			// Token: 0x0400070D RID: 1805
			public RawColor4 __GammaCurve763;

			// Token: 0x0400070E RID: 1806
			public RawColor4 __GammaCurve764;

			// Token: 0x0400070F RID: 1807
			public RawColor4 __GammaCurve765;

			// Token: 0x04000710 RID: 1808
			public RawColor4 __GammaCurve766;

			// Token: 0x04000711 RID: 1809
			public RawColor4 __GammaCurve767;

			// Token: 0x04000712 RID: 1810
			public RawColor4 __GammaCurve768;

			// Token: 0x04000713 RID: 1811
			public RawColor4 __GammaCurve769;

			// Token: 0x04000714 RID: 1812
			public RawColor4 __GammaCurve770;

			// Token: 0x04000715 RID: 1813
			public RawColor4 __GammaCurve771;

			// Token: 0x04000716 RID: 1814
			public RawColor4 __GammaCurve772;

			// Token: 0x04000717 RID: 1815
			public RawColor4 __GammaCurve773;

			// Token: 0x04000718 RID: 1816
			public RawColor4 __GammaCurve774;

			// Token: 0x04000719 RID: 1817
			public RawColor4 __GammaCurve775;

			// Token: 0x0400071A RID: 1818
			public RawColor4 __GammaCurve776;

			// Token: 0x0400071B RID: 1819
			public RawColor4 __GammaCurve777;

			// Token: 0x0400071C RID: 1820
			public RawColor4 __GammaCurve778;

			// Token: 0x0400071D RID: 1821
			public RawColor4 __GammaCurve779;

			// Token: 0x0400071E RID: 1822
			public RawColor4 __GammaCurve780;

			// Token: 0x0400071F RID: 1823
			public RawColor4 __GammaCurve781;

			// Token: 0x04000720 RID: 1824
			public RawColor4 __GammaCurve782;

			// Token: 0x04000721 RID: 1825
			public RawColor4 __GammaCurve783;

			// Token: 0x04000722 RID: 1826
			public RawColor4 __GammaCurve784;

			// Token: 0x04000723 RID: 1827
			public RawColor4 __GammaCurve785;

			// Token: 0x04000724 RID: 1828
			public RawColor4 __GammaCurve786;

			// Token: 0x04000725 RID: 1829
			public RawColor4 __GammaCurve787;

			// Token: 0x04000726 RID: 1830
			public RawColor4 __GammaCurve788;

			// Token: 0x04000727 RID: 1831
			public RawColor4 __GammaCurve789;

			// Token: 0x04000728 RID: 1832
			public RawColor4 __GammaCurve790;

			// Token: 0x04000729 RID: 1833
			public RawColor4 __GammaCurve791;

			// Token: 0x0400072A RID: 1834
			public RawColor4 __GammaCurve792;

			// Token: 0x0400072B RID: 1835
			public RawColor4 __GammaCurve793;

			// Token: 0x0400072C RID: 1836
			public RawColor4 __GammaCurve794;

			// Token: 0x0400072D RID: 1837
			public RawColor4 __GammaCurve795;

			// Token: 0x0400072E RID: 1838
			public RawColor4 __GammaCurve796;

			// Token: 0x0400072F RID: 1839
			public RawColor4 __GammaCurve797;

			// Token: 0x04000730 RID: 1840
			public RawColor4 __GammaCurve798;

			// Token: 0x04000731 RID: 1841
			public RawColor4 __GammaCurve799;

			// Token: 0x04000732 RID: 1842
			public RawColor4 __GammaCurve800;

			// Token: 0x04000733 RID: 1843
			public RawColor4 __GammaCurve801;

			// Token: 0x04000734 RID: 1844
			public RawColor4 __GammaCurve802;

			// Token: 0x04000735 RID: 1845
			public RawColor4 __GammaCurve803;

			// Token: 0x04000736 RID: 1846
			public RawColor4 __GammaCurve804;

			// Token: 0x04000737 RID: 1847
			public RawColor4 __GammaCurve805;

			// Token: 0x04000738 RID: 1848
			public RawColor4 __GammaCurve806;

			// Token: 0x04000739 RID: 1849
			public RawColor4 __GammaCurve807;

			// Token: 0x0400073A RID: 1850
			public RawColor4 __GammaCurve808;

			// Token: 0x0400073B RID: 1851
			public RawColor4 __GammaCurve809;

			// Token: 0x0400073C RID: 1852
			public RawColor4 __GammaCurve810;

			// Token: 0x0400073D RID: 1853
			public RawColor4 __GammaCurve811;

			// Token: 0x0400073E RID: 1854
			public RawColor4 __GammaCurve812;

			// Token: 0x0400073F RID: 1855
			public RawColor4 __GammaCurve813;

			// Token: 0x04000740 RID: 1856
			public RawColor4 __GammaCurve814;

			// Token: 0x04000741 RID: 1857
			public RawColor4 __GammaCurve815;

			// Token: 0x04000742 RID: 1858
			public RawColor4 __GammaCurve816;

			// Token: 0x04000743 RID: 1859
			public RawColor4 __GammaCurve817;

			// Token: 0x04000744 RID: 1860
			public RawColor4 __GammaCurve818;

			// Token: 0x04000745 RID: 1861
			public RawColor4 __GammaCurve819;

			// Token: 0x04000746 RID: 1862
			public RawColor4 __GammaCurve820;

			// Token: 0x04000747 RID: 1863
			public RawColor4 __GammaCurve821;

			// Token: 0x04000748 RID: 1864
			public RawColor4 __GammaCurve822;

			// Token: 0x04000749 RID: 1865
			public RawColor4 __GammaCurve823;

			// Token: 0x0400074A RID: 1866
			public RawColor4 __GammaCurve824;

			// Token: 0x0400074B RID: 1867
			public RawColor4 __GammaCurve825;

			// Token: 0x0400074C RID: 1868
			public RawColor4 __GammaCurve826;

			// Token: 0x0400074D RID: 1869
			public RawColor4 __GammaCurve827;

			// Token: 0x0400074E RID: 1870
			public RawColor4 __GammaCurve828;

			// Token: 0x0400074F RID: 1871
			public RawColor4 __GammaCurve829;

			// Token: 0x04000750 RID: 1872
			public RawColor4 __GammaCurve830;

			// Token: 0x04000751 RID: 1873
			public RawColor4 __GammaCurve831;

			// Token: 0x04000752 RID: 1874
			public RawColor4 __GammaCurve832;

			// Token: 0x04000753 RID: 1875
			public RawColor4 __GammaCurve833;

			// Token: 0x04000754 RID: 1876
			public RawColor4 __GammaCurve834;

			// Token: 0x04000755 RID: 1877
			public RawColor4 __GammaCurve835;

			// Token: 0x04000756 RID: 1878
			public RawColor4 __GammaCurve836;

			// Token: 0x04000757 RID: 1879
			public RawColor4 __GammaCurve837;

			// Token: 0x04000758 RID: 1880
			public RawColor4 __GammaCurve838;

			// Token: 0x04000759 RID: 1881
			public RawColor4 __GammaCurve839;

			// Token: 0x0400075A RID: 1882
			public RawColor4 __GammaCurve840;

			// Token: 0x0400075B RID: 1883
			public RawColor4 __GammaCurve841;

			// Token: 0x0400075C RID: 1884
			public RawColor4 __GammaCurve842;

			// Token: 0x0400075D RID: 1885
			public RawColor4 __GammaCurve843;

			// Token: 0x0400075E RID: 1886
			public RawColor4 __GammaCurve844;

			// Token: 0x0400075F RID: 1887
			public RawColor4 __GammaCurve845;

			// Token: 0x04000760 RID: 1888
			public RawColor4 __GammaCurve846;

			// Token: 0x04000761 RID: 1889
			public RawColor4 __GammaCurve847;

			// Token: 0x04000762 RID: 1890
			public RawColor4 __GammaCurve848;

			// Token: 0x04000763 RID: 1891
			public RawColor4 __GammaCurve849;

			// Token: 0x04000764 RID: 1892
			public RawColor4 __GammaCurve850;

			// Token: 0x04000765 RID: 1893
			public RawColor4 __GammaCurve851;

			// Token: 0x04000766 RID: 1894
			public RawColor4 __GammaCurve852;

			// Token: 0x04000767 RID: 1895
			public RawColor4 __GammaCurve853;

			// Token: 0x04000768 RID: 1896
			public RawColor4 __GammaCurve854;

			// Token: 0x04000769 RID: 1897
			public RawColor4 __GammaCurve855;

			// Token: 0x0400076A RID: 1898
			public RawColor4 __GammaCurve856;

			// Token: 0x0400076B RID: 1899
			public RawColor4 __GammaCurve857;

			// Token: 0x0400076C RID: 1900
			public RawColor4 __GammaCurve858;

			// Token: 0x0400076D RID: 1901
			public RawColor4 __GammaCurve859;

			// Token: 0x0400076E RID: 1902
			public RawColor4 __GammaCurve860;

			// Token: 0x0400076F RID: 1903
			public RawColor4 __GammaCurve861;

			// Token: 0x04000770 RID: 1904
			public RawColor4 __GammaCurve862;

			// Token: 0x04000771 RID: 1905
			public RawColor4 __GammaCurve863;

			// Token: 0x04000772 RID: 1906
			public RawColor4 __GammaCurve864;

			// Token: 0x04000773 RID: 1907
			public RawColor4 __GammaCurve865;

			// Token: 0x04000774 RID: 1908
			public RawColor4 __GammaCurve866;

			// Token: 0x04000775 RID: 1909
			public RawColor4 __GammaCurve867;

			// Token: 0x04000776 RID: 1910
			public RawColor4 __GammaCurve868;

			// Token: 0x04000777 RID: 1911
			public RawColor4 __GammaCurve869;

			// Token: 0x04000778 RID: 1912
			public RawColor4 __GammaCurve870;

			// Token: 0x04000779 RID: 1913
			public RawColor4 __GammaCurve871;

			// Token: 0x0400077A RID: 1914
			public RawColor4 __GammaCurve872;

			// Token: 0x0400077B RID: 1915
			public RawColor4 __GammaCurve873;

			// Token: 0x0400077C RID: 1916
			public RawColor4 __GammaCurve874;

			// Token: 0x0400077D RID: 1917
			public RawColor4 __GammaCurve875;

			// Token: 0x0400077E RID: 1918
			public RawColor4 __GammaCurve876;

			// Token: 0x0400077F RID: 1919
			public RawColor4 __GammaCurve877;

			// Token: 0x04000780 RID: 1920
			public RawColor4 __GammaCurve878;

			// Token: 0x04000781 RID: 1921
			public RawColor4 __GammaCurve879;

			// Token: 0x04000782 RID: 1922
			public RawColor4 __GammaCurve880;

			// Token: 0x04000783 RID: 1923
			public RawColor4 __GammaCurve881;

			// Token: 0x04000784 RID: 1924
			public RawColor4 __GammaCurve882;

			// Token: 0x04000785 RID: 1925
			public RawColor4 __GammaCurve883;

			// Token: 0x04000786 RID: 1926
			public RawColor4 __GammaCurve884;

			// Token: 0x04000787 RID: 1927
			public RawColor4 __GammaCurve885;

			// Token: 0x04000788 RID: 1928
			public RawColor4 __GammaCurve886;

			// Token: 0x04000789 RID: 1929
			public RawColor4 __GammaCurve887;

			// Token: 0x0400078A RID: 1930
			public RawColor4 __GammaCurve888;

			// Token: 0x0400078B RID: 1931
			public RawColor4 __GammaCurve889;

			// Token: 0x0400078C RID: 1932
			public RawColor4 __GammaCurve890;

			// Token: 0x0400078D RID: 1933
			public RawColor4 __GammaCurve891;

			// Token: 0x0400078E RID: 1934
			public RawColor4 __GammaCurve892;

			// Token: 0x0400078F RID: 1935
			public RawColor4 __GammaCurve893;

			// Token: 0x04000790 RID: 1936
			public RawColor4 __GammaCurve894;

			// Token: 0x04000791 RID: 1937
			public RawColor4 __GammaCurve895;

			// Token: 0x04000792 RID: 1938
			public RawColor4 __GammaCurve896;

			// Token: 0x04000793 RID: 1939
			public RawColor4 __GammaCurve897;

			// Token: 0x04000794 RID: 1940
			public RawColor4 __GammaCurve898;

			// Token: 0x04000795 RID: 1941
			public RawColor4 __GammaCurve899;

			// Token: 0x04000796 RID: 1942
			public RawColor4 __GammaCurve900;

			// Token: 0x04000797 RID: 1943
			public RawColor4 __GammaCurve901;

			// Token: 0x04000798 RID: 1944
			public RawColor4 __GammaCurve902;

			// Token: 0x04000799 RID: 1945
			public RawColor4 __GammaCurve903;

			// Token: 0x0400079A RID: 1946
			public RawColor4 __GammaCurve904;

			// Token: 0x0400079B RID: 1947
			public RawColor4 __GammaCurve905;

			// Token: 0x0400079C RID: 1948
			public RawColor4 __GammaCurve906;

			// Token: 0x0400079D RID: 1949
			public RawColor4 __GammaCurve907;

			// Token: 0x0400079E RID: 1950
			public RawColor4 __GammaCurve908;

			// Token: 0x0400079F RID: 1951
			public RawColor4 __GammaCurve909;

			// Token: 0x040007A0 RID: 1952
			public RawColor4 __GammaCurve910;

			// Token: 0x040007A1 RID: 1953
			public RawColor4 __GammaCurve911;

			// Token: 0x040007A2 RID: 1954
			public RawColor4 __GammaCurve912;

			// Token: 0x040007A3 RID: 1955
			public RawColor4 __GammaCurve913;

			// Token: 0x040007A4 RID: 1956
			public RawColor4 __GammaCurve914;

			// Token: 0x040007A5 RID: 1957
			public RawColor4 __GammaCurve915;

			// Token: 0x040007A6 RID: 1958
			public RawColor4 __GammaCurve916;

			// Token: 0x040007A7 RID: 1959
			public RawColor4 __GammaCurve917;

			// Token: 0x040007A8 RID: 1960
			public RawColor4 __GammaCurve918;

			// Token: 0x040007A9 RID: 1961
			public RawColor4 __GammaCurve919;

			// Token: 0x040007AA RID: 1962
			public RawColor4 __GammaCurve920;

			// Token: 0x040007AB RID: 1963
			public RawColor4 __GammaCurve921;

			// Token: 0x040007AC RID: 1964
			public RawColor4 __GammaCurve922;

			// Token: 0x040007AD RID: 1965
			public RawColor4 __GammaCurve923;

			// Token: 0x040007AE RID: 1966
			public RawColor4 __GammaCurve924;

			// Token: 0x040007AF RID: 1967
			public RawColor4 __GammaCurve925;

			// Token: 0x040007B0 RID: 1968
			public RawColor4 __GammaCurve926;

			// Token: 0x040007B1 RID: 1969
			public RawColor4 __GammaCurve927;

			// Token: 0x040007B2 RID: 1970
			public RawColor4 __GammaCurve928;

			// Token: 0x040007B3 RID: 1971
			public RawColor4 __GammaCurve929;

			// Token: 0x040007B4 RID: 1972
			public RawColor4 __GammaCurve930;

			// Token: 0x040007B5 RID: 1973
			public RawColor4 __GammaCurve931;

			// Token: 0x040007B6 RID: 1974
			public RawColor4 __GammaCurve932;

			// Token: 0x040007B7 RID: 1975
			public RawColor4 __GammaCurve933;

			// Token: 0x040007B8 RID: 1976
			public RawColor4 __GammaCurve934;

			// Token: 0x040007B9 RID: 1977
			public RawColor4 __GammaCurve935;

			// Token: 0x040007BA RID: 1978
			public RawColor4 __GammaCurve936;

			// Token: 0x040007BB RID: 1979
			public RawColor4 __GammaCurve937;

			// Token: 0x040007BC RID: 1980
			public RawColor4 __GammaCurve938;

			// Token: 0x040007BD RID: 1981
			public RawColor4 __GammaCurve939;

			// Token: 0x040007BE RID: 1982
			public RawColor4 __GammaCurve940;

			// Token: 0x040007BF RID: 1983
			public RawColor4 __GammaCurve941;

			// Token: 0x040007C0 RID: 1984
			public RawColor4 __GammaCurve942;

			// Token: 0x040007C1 RID: 1985
			public RawColor4 __GammaCurve943;

			// Token: 0x040007C2 RID: 1986
			public RawColor4 __GammaCurve944;

			// Token: 0x040007C3 RID: 1987
			public RawColor4 __GammaCurve945;

			// Token: 0x040007C4 RID: 1988
			public RawColor4 __GammaCurve946;

			// Token: 0x040007C5 RID: 1989
			public RawColor4 __GammaCurve947;

			// Token: 0x040007C6 RID: 1990
			public RawColor4 __GammaCurve948;

			// Token: 0x040007C7 RID: 1991
			public RawColor4 __GammaCurve949;

			// Token: 0x040007C8 RID: 1992
			public RawColor4 __GammaCurve950;

			// Token: 0x040007C9 RID: 1993
			public RawColor4 __GammaCurve951;

			// Token: 0x040007CA RID: 1994
			public RawColor4 __GammaCurve952;

			// Token: 0x040007CB RID: 1995
			public RawColor4 __GammaCurve953;

			// Token: 0x040007CC RID: 1996
			public RawColor4 __GammaCurve954;

			// Token: 0x040007CD RID: 1997
			public RawColor4 __GammaCurve955;

			// Token: 0x040007CE RID: 1998
			public RawColor4 __GammaCurve956;

			// Token: 0x040007CF RID: 1999
			public RawColor4 __GammaCurve957;

			// Token: 0x040007D0 RID: 2000
			public RawColor4 __GammaCurve958;

			// Token: 0x040007D1 RID: 2001
			public RawColor4 __GammaCurve959;

			// Token: 0x040007D2 RID: 2002
			public RawColor4 __GammaCurve960;

			// Token: 0x040007D3 RID: 2003
			public RawColor4 __GammaCurve961;

			// Token: 0x040007D4 RID: 2004
			public RawColor4 __GammaCurve962;

			// Token: 0x040007D5 RID: 2005
			public RawColor4 __GammaCurve963;

			// Token: 0x040007D6 RID: 2006
			public RawColor4 __GammaCurve964;

			// Token: 0x040007D7 RID: 2007
			public RawColor4 __GammaCurve965;

			// Token: 0x040007D8 RID: 2008
			public RawColor4 __GammaCurve966;

			// Token: 0x040007D9 RID: 2009
			public RawColor4 __GammaCurve967;

			// Token: 0x040007DA RID: 2010
			public RawColor4 __GammaCurve968;

			// Token: 0x040007DB RID: 2011
			public RawColor4 __GammaCurve969;

			// Token: 0x040007DC RID: 2012
			public RawColor4 __GammaCurve970;

			// Token: 0x040007DD RID: 2013
			public RawColor4 __GammaCurve971;

			// Token: 0x040007DE RID: 2014
			public RawColor4 __GammaCurve972;

			// Token: 0x040007DF RID: 2015
			public RawColor4 __GammaCurve973;

			// Token: 0x040007E0 RID: 2016
			public RawColor4 __GammaCurve974;

			// Token: 0x040007E1 RID: 2017
			public RawColor4 __GammaCurve975;

			// Token: 0x040007E2 RID: 2018
			public RawColor4 __GammaCurve976;

			// Token: 0x040007E3 RID: 2019
			public RawColor4 __GammaCurve977;

			// Token: 0x040007E4 RID: 2020
			public RawColor4 __GammaCurve978;

			// Token: 0x040007E5 RID: 2021
			public RawColor4 __GammaCurve979;

			// Token: 0x040007E6 RID: 2022
			public RawColor4 __GammaCurve980;

			// Token: 0x040007E7 RID: 2023
			public RawColor4 __GammaCurve981;

			// Token: 0x040007E8 RID: 2024
			public RawColor4 __GammaCurve982;

			// Token: 0x040007E9 RID: 2025
			public RawColor4 __GammaCurve983;

			// Token: 0x040007EA RID: 2026
			public RawColor4 __GammaCurve984;

			// Token: 0x040007EB RID: 2027
			public RawColor4 __GammaCurve985;

			// Token: 0x040007EC RID: 2028
			public RawColor4 __GammaCurve986;

			// Token: 0x040007ED RID: 2029
			public RawColor4 __GammaCurve987;

			// Token: 0x040007EE RID: 2030
			public RawColor4 __GammaCurve988;

			// Token: 0x040007EF RID: 2031
			public RawColor4 __GammaCurve989;

			// Token: 0x040007F0 RID: 2032
			public RawColor4 __GammaCurve990;

			// Token: 0x040007F1 RID: 2033
			public RawColor4 __GammaCurve991;

			// Token: 0x040007F2 RID: 2034
			public RawColor4 __GammaCurve992;

			// Token: 0x040007F3 RID: 2035
			public RawColor4 __GammaCurve993;

			// Token: 0x040007F4 RID: 2036
			public RawColor4 __GammaCurve994;

			// Token: 0x040007F5 RID: 2037
			public RawColor4 __GammaCurve995;

			// Token: 0x040007F6 RID: 2038
			public RawColor4 __GammaCurve996;

			// Token: 0x040007F7 RID: 2039
			public RawColor4 __GammaCurve997;

			// Token: 0x040007F8 RID: 2040
			public RawColor4 __GammaCurve998;

			// Token: 0x040007F9 RID: 2041
			public RawColor4 __GammaCurve999;

			// Token: 0x040007FA RID: 2042
			public RawColor4 __GammaCurve1000;

			// Token: 0x040007FB RID: 2043
			public RawColor4 __GammaCurve1001;

			// Token: 0x040007FC RID: 2044
			public RawColor4 __GammaCurve1002;

			// Token: 0x040007FD RID: 2045
			public RawColor4 __GammaCurve1003;

			// Token: 0x040007FE RID: 2046
			public RawColor4 __GammaCurve1004;

			// Token: 0x040007FF RID: 2047
			public RawColor4 __GammaCurve1005;

			// Token: 0x04000800 RID: 2048
			public RawColor4 __GammaCurve1006;

			// Token: 0x04000801 RID: 2049
			public RawColor4 __GammaCurve1007;

			// Token: 0x04000802 RID: 2050
			public RawColor4 __GammaCurve1008;

			// Token: 0x04000803 RID: 2051
			public RawColor4 __GammaCurve1009;

			// Token: 0x04000804 RID: 2052
			public RawColor4 __GammaCurve1010;

			// Token: 0x04000805 RID: 2053
			public RawColor4 __GammaCurve1011;

			// Token: 0x04000806 RID: 2054
			public RawColor4 __GammaCurve1012;

			// Token: 0x04000807 RID: 2055
			public RawColor4 __GammaCurve1013;

			// Token: 0x04000808 RID: 2056
			public RawColor4 __GammaCurve1014;

			// Token: 0x04000809 RID: 2057
			public RawColor4 __GammaCurve1015;

			// Token: 0x0400080A RID: 2058
			public RawColor4 __GammaCurve1016;

			// Token: 0x0400080B RID: 2059
			public RawColor4 __GammaCurve1017;

			// Token: 0x0400080C RID: 2060
			public RawColor4 __GammaCurve1018;

			// Token: 0x0400080D RID: 2061
			public RawColor4 __GammaCurve1019;

			// Token: 0x0400080E RID: 2062
			public RawColor4 __GammaCurve1020;

			// Token: 0x0400080F RID: 2063
			public RawColor4 __GammaCurve1021;

			// Token: 0x04000810 RID: 2064
			public RawColor4 __GammaCurve1022;

			// Token: 0x04000811 RID: 2065
			public RawColor4 __GammaCurve1023;

			// Token: 0x04000812 RID: 2066
			public RawColor4 __GammaCurve1024;
		}
	}
}
