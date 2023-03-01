using System;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000014 RID: 20
	internal class HalfUtils
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0000B434 File Offset: 0x00009634
		public static float Unpack(ushort h)
		{
			return new HalfUtils.FloatToUint
			{
				uintValue = HalfUtils.HalfToFloatMantissaTable[(int)(HalfUtils.HalfToFloatOffsetTable[h >> 10] + (uint)(h & 1023))] + HalfUtils.HalfToFloatExponentTable[h >> 10]
			}.floatValue;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000B47C File Offset: 0x0000967C
		public static ushort Pack(float f)
		{
			HalfUtils.FloatToUint floatToUint = default(HalfUtils.FloatToUint);
			floatToUint.floatValue = f;
			return (ushort)((uint)HalfUtils.FloatToHalfBaseTable[(int)(floatToUint.uintValue >> 23 & 511U)] + ((floatToUint.uintValue & 8388607U) >> (int)HalfUtils.FloatToHalfShiftTable[(int)(floatToUint.uintValue >> 23 & 511U)]));
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000B4D8 File Offset: 0x000096D8
		static HalfUtils()
		{
			HalfUtils.HalfToFloatMantissaTable[0] = 0U;
			for (int i = 1; i < 1024; i++)
			{
				uint num = (uint)((uint)i << 13);
				uint num2 = 0U;
				while ((num & 8388608U) == 0U)
				{
					num2 -= 8388608U;
					num <<= 1;
				}
				num &= 4286578687U;
				num2 += 947912704U;
				HalfUtils.HalfToFloatMantissaTable[i] = (num | num2);
			}
			for (int i = 1024; i < 2048; i++)
			{
				HalfUtils.HalfToFloatMantissaTable[i] = (uint)(939524096 + (i - 1024 << 13));
			}
			HalfUtils.HalfToFloatExponentTable[0] = 0U;
			for (int i = 1; i < 63; i++)
			{
				if (i < 31)
				{
					HalfUtils.HalfToFloatExponentTable[i] = (uint)((uint)i << 23);
				}
				else
				{
					HalfUtils.HalfToFloatExponentTable[i] = (uint)(int.MinValue + (i - 32 << 23));
				}
			}
			HalfUtils.HalfToFloatExponentTable[31] = 1199570944U;
			HalfUtils.HalfToFloatExponentTable[32] = 2147483648U;
			HalfUtils.HalfToFloatExponentTable[63] = 3347054592U;
			HalfUtils.HalfToFloatOffsetTable[0] = 0U;
			for (int i = 1; i < 64; i++)
			{
				HalfUtils.HalfToFloatOffsetTable[i] = 1024U;
			}
			HalfUtils.HalfToFloatOffsetTable[32] = 0U;
			for (int i = 0; i < 256; i++)
			{
				int num3 = i - 127;
				if (num3 < -24)
				{
					HalfUtils.FloatToHalfBaseTable[i | 0] = 0;
					HalfUtils.FloatToHalfBaseTable[i | 256] = 32768;
					HalfUtils.FloatToHalfShiftTable[i | 0] = 24;
					HalfUtils.FloatToHalfShiftTable[i | 256] = 24;
				}
				else if (num3 < -14)
				{
					HalfUtils.FloatToHalfBaseTable[i | 0] = (ushort)(1024 >> -num3 - 14);
					HalfUtils.FloatToHalfBaseTable[i | 256] = (ushort)(1024 >> -num3 - 14 | 32768);
					HalfUtils.FloatToHalfShiftTable[i | 0] = (byte)(-num3 - 1);
					HalfUtils.FloatToHalfShiftTable[i | 256] = (byte)(-num3 - 1);
				}
				else if (num3 <= 15)
				{
					HalfUtils.FloatToHalfBaseTable[i | 0] = (ushort)(num3 + 15 << 10);
					HalfUtils.FloatToHalfBaseTable[i | 256] = (ushort)(num3 + 15 << 10 | 32768);
					HalfUtils.FloatToHalfShiftTable[i | 0] = 13;
					HalfUtils.FloatToHalfShiftTable[i | 256] = 13;
				}
				else if (num3 < 128)
				{
					HalfUtils.FloatToHalfBaseTable[i | 0] = 31744;
					HalfUtils.FloatToHalfBaseTable[i | 256] = 64512;
					HalfUtils.FloatToHalfShiftTable[i | 0] = 24;
					HalfUtils.FloatToHalfShiftTable[i | 256] = 24;
				}
				else
				{
					HalfUtils.FloatToHalfBaseTable[i | 0] = 31744;
					HalfUtils.FloatToHalfBaseTable[i | 256] = 64512;
					HalfUtils.FloatToHalfShiftTable[i | 0] = 13;
					HalfUtils.FloatToHalfShiftTable[i | 256] = 13;
				}
			}
		}

		// Token: 0x040000ED RID: 237
		private static readonly uint[] HalfToFloatMantissaTable = new uint[2048];

		// Token: 0x040000EE RID: 238
		private static readonly uint[] HalfToFloatExponentTable = new uint[64];

		// Token: 0x040000EF RID: 239
		private static readonly uint[] HalfToFloatOffsetTable = new uint[64];

		// Token: 0x040000F0 RID: 240
		private static readonly ushort[] FloatToHalfBaseTable = new ushort[512];

		// Token: 0x040000F1 RID: 241
		private static readonly byte[] FloatToHalfShiftTable = new byte[512];

		// Token: 0x02000015 RID: 21
		[StructLayout(LayoutKind.Explicit)]
		private struct FloatToUint
		{
			// Token: 0x040000F2 RID: 242
			[FieldOffset(0)]
			public uint uintValue;

			// Token: 0x040000F3 RID: 243
			[FieldOffset(0)]
			public float floatValue;
		}
	}
}
