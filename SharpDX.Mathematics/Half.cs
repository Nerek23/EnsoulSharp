using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace SharpDX
{
	// Token: 0x02000010 RID: 16
	public struct Half
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0000AD4A File Offset: 0x00008F4A
		public Half(float value)
		{
			this.value = HalfUtils.Pack(value);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000AD58 File Offset: 0x00008F58
		public Half(ushort rawvalue)
		{
			this.value = rawvalue;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600022F RID: 559 RVA: 0x0000AD61 File Offset: 0x00008F61
		// (set) Token: 0x06000230 RID: 560 RVA: 0x0000AD58 File Offset: 0x00008F58
		public ushort RawValue
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000AD6C File Offset: 0x00008F6C
		public static float[] ConvertToFloat(Half[] values)
		{
			float[] array = new float[values.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = HalfUtils.Unpack(values[i].RawValue);
			}
			return array;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000ADA8 File Offset: 0x00008FA8
		public static Half[] ConvertToHalf(float[] values)
		{
			Half[] array = new Half[values.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Half(values[i]);
			}
			return array;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000ADDC File Offset: 0x00008FDC
		public static implicit operator Half(float value)
		{
			return new Half(value);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000ADE4 File Offset: 0x00008FE4
		public static implicit operator float(Half value)
		{
			return HalfUtils.Unpack(value.value);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000ADF1 File Offset: 0x00008FF1
		public static bool operator ==(Half left, Half right)
		{
			return left.value == right.value;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000AE01 File Offset: 0x00009001
		public static bool operator !=(Half left, Half right)
		{
			return left.value != right.value;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000AE14 File Offset: 0x00009014
		public override string ToString()
		{
			return this.ToString(CultureInfo.CurrentCulture);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000AE3C File Offset: 0x0000903C
		public override int GetHashCode()
		{
			ushort num = this.value;
			return (int)(num * 3 / 2 ^ num);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000ADF1 File Offset: 0x00008FF1
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Equals(ref Half value1, ref Half value2)
		{
			return value1.value == value2.value;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000AE57 File Offset: 0x00009057
		public bool Equals(Half other)
		{
			return other.value == this.value;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000AE67 File Offset: 0x00009067
		public override bool Equals(object obj)
		{
			return obj is Half && this.Equals((Half)obj);
		}

		// Token: 0x040000D8 RID: 216
		private ushort value;

		// Token: 0x040000D9 RID: 217
		public const int PrecisionDigits = 3;

		// Token: 0x040000DA RID: 218
		public const int MantissaBits = 11;

		// Token: 0x040000DB RID: 219
		public const int MaximumDecimalExponent = 4;

		// Token: 0x040000DC RID: 220
		public const int MaximumBinaryExponent = 15;

		// Token: 0x040000DD RID: 221
		public const int MinimumDecimalExponent = -4;

		// Token: 0x040000DE RID: 222
		public const int MinimumBinaryExponent = -14;

		// Token: 0x040000DF RID: 223
		public const int ExponentRadix = 2;

		// Token: 0x040000E0 RID: 224
		public const int AdditionRounding = 1;

		// Token: 0x040000E1 RID: 225
		public static readonly float Epsilon = 0.0004887581f;

		// Token: 0x040000E2 RID: 226
		public static readonly float MaxValue = 65504f;

		// Token: 0x040000E3 RID: 227
		public static readonly float MinValue = 6.103516E-05f;
	}
}
