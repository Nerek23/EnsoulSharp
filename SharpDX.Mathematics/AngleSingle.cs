using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x02000002 RID: 2
	[StructLayout(LayoutKind.Explicit)]
	public struct AngleSingle : IComparable, IComparable<AngleSingle>, IEquatable<AngleSingle>, IFormattable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public AngleSingle(float angle, AngleType type)
		{
			this.radiansInt = 0;
			switch (type)
			{
			case AngleType.Revolution:
				this.radians = MathUtil.RevolutionsToRadians(angle);
				return;
			case AngleType.Degree:
				this.radians = MathUtil.DegreesToRadians(angle);
				return;
			case AngleType.Radian:
				this.radians = angle;
				return;
			case AngleType.Gradian:
				this.radians = MathUtil.GradiansToRadians(angle);
				return;
			default:
				this.radians = 0f;
				return;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B6 File Offset: 0x000002B6
		public AngleSingle(float arcLength, float radius)
		{
			this.radiansInt = 0;
			this.radians = arcLength / radius;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020C8 File Offset: 0x000002C8
		public void Wrap()
		{
			float num = (float)Math.IEEERemainder((double)this.radians, 6.2831854820251465);
			if (num <= -3.1415927f)
			{
				num += 6.2831855f;
			}
			else if (num > 3.1415927f)
			{
				num -= 6.2831855f;
			}
			this.radians = num;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002118 File Offset: 0x00000318
		public void WrapPositive()
		{
			float num = this.radians % 6.2831855f;
			if ((double)num < 0.0)
			{
				num += 6.2831855f;
			}
			this.radians = num;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000214E File Offset: 0x0000034E
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000215B File Offset: 0x0000035B
		public float Revolutions
		{
			get
			{
				return MathUtil.RadiansToRevolutions(this.radians);
			}
			set
			{
				this.radians = MathUtil.RevolutionsToRadians(value);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002169 File Offset: 0x00000369
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002176 File Offset: 0x00000376
		public float Degrees
		{
			get
			{
				return MathUtil.RadiansToDegrees(this.radians);
			}
			set
			{
				this.radians = MathUtil.DegreesToRadians(value);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002184 File Offset: 0x00000384
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000021CC File Offset: 0x000003CC
		public float Minutes
		{
			get
			{
				float num = MathUtil.RadiansToDegrees(this.radians);
				if (num < 0f)
				{
					float num2 = (float)Math.Ceiling((double)num);
					return (num - num2) * 60f;
				}
				float num3 = (float)Math.Floor((double)num);
				return (num - num3) * 60f;
			}
			set
			{
				float num = (float)Math.Floor((double)MathUtil.RadiansToDegrees(this.radians));
				num += value / 60f;
				this.radians = MathUtil.DegreesToRadians(num);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002204 File Offset: 0x00000404
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002270 File Offset: 0x00000470
		public float Seconds
		{
			get
			{
				float num = MathUtil.RadiansToDegrees(this.radians);
				if (num < 0f)
				{
					float num2 = (float)Math.Ceiling((double)num);
					float num3 = (num - num2) * 60f;
					float num4 = (float)Math.Ceiling((double)num3);
					return (num3 - num4) * 60f;
				}
				float num5 = (float)Math.Floor((double)num);
				float num6 = (num - num5) * 60f;
				float num7 = (float)Math.Floor((double)num6);
				return (num6 - num7) * 60f;
			}
			set
			{
				float num = MathUtil.RadiansToDegrees(this.radians);
				float num2 = (float)Math.Floor((double)num);
				float num3 = (float)Math.Floor((double)((num - num2) * 60f));
				num3 += value / 60f;
				num2 += num3 / 60f;
				this.radians = MathUtil.DegreesToRadians(num2);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000022C1 File Offset: 0x000004C1
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000022C9 File Offset: 0x000004C9
		public float Radians
		{
			get
			{
				return this.radians;
			}
			set
			{
				this.radians = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000022D2 File Offset: 0x000004D2
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000022E0 File Offset: 0x000004E0
		public float Milliradians
		{
			get
			{
				return this.radians / 0.001f;
			}
			set
			{
				this.radians = value * 0.001f;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000022EF File Offset: 0x000004EF
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000022FC File Offset: 0x000004FC
		public float Gradians
		{
			get
			{
				return MathUtil.RadiansToGradians(this.radians);
			}
			set
			{
				this.radians = MathUtil.RadiansToGradians(value);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000230A File Offset: 0x0000050A
		public bool IsRight
		{
			get
			{
				return this.radians == 1.5707964f;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002319 File Offset: 0x00000519
		public bool IsStraight
		{
			get
			{
				return this.radians == 3.1415927f;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002328 File Offset: 0x00000528
		public bool IsFullRotation
		{
			get
			{
				return this.radians == 6.2831855f;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002337 File Offset: 0x00000537
		public bool IsOblique
		{
			get
			{
				return AngleSingle.WrapPositive(this).radians != 1.5707964f;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002353 File Offset: 0x00000553
		public bool IsAcute
		{
			get
			{
				return (double)this.radians > 0.0 && this.radians < 1.5707964f;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002376 File Offset: 0x00000576
		public bool IsObtuse
		{
			get
			{
				return this.radians > 1.5707964f && this.radians < 3.1415927f;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002394 File Offset: 0x00000594
		public bool IsReflex
		{
			get
			{
				return this.radians > 3.1415927f && this.radians < 6.2831855f;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000023B2 File Offset: 0x000005B2
		public AngleSingle Complement
		{
			get
			{
				return new AngleSingle(1.5707964f - this.radians, AngleType.Radian);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000023C6 File Offset: 0x000005C6
		public AngleSingle Supplement
		{
			get
			{
				return new AngleSingle(3.1415927f - this.radians, AngleType.Radian);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000023DA File Offset: 0x000005DA
		public static AngleSingle Wrap(AngleSingle value)
		{
			value.Wrap();
			return value;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023E4 File Offset: 0x000005E4
		public static AngleSingle WrapPositive(AngleSingle value)
		{
			value.WrapPositive();
			return value;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000023EE File Offset: 0x000005EE
		public static AngleSingle Min(AngleSingle left, AngleSingle right)
		{
			if (left.radians < right.radians)
			{
				return left;
			}
			return right;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002401 File Offset: 0x00000601
		public static AngleSingle Max(AngleSingle left, AngleSingle right)
		{
			if (left.radians > right.radians)
			{
				return left;
			}
			return right;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002414 File Offset: 0x00000614
		public static AngleSingle Add(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians + right.radians, AngleType.Radian);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002429 File Offset: 0x00000629
		public static AngleSingle Subtract(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians - right.radians, AngleType.Radian);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000243E File Offset: 0x0000063E
		public static AngleSingle Multiply(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians * right.radians, AngleType.Radian);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002453 File Offset: 0x00000653
		public static AngleSingle Divide(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians / right.radians, AngleType.Radian);
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002468 File Offset: 0x00000668
		public static AngleSingle ZeroAngle
		{
			get
			{
				return new AngleSingle(0f, AngleType.Radian);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002475 File Offset: 0x00000675
		public static AngleSingle RightAngle
		{
			get
			{
				return new AngleSingle(1.5707964f, AngleType.Radian);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002482 File Offset: 0x00000682
		public static AngleSingle StraightAngle
		{
			get
			{
				return new AngleSingle(3.1415927f, AngleType.Radian);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000248F File Offset: 0x0000068F
		public static AngleSingle FullRotationAngle
		{
			get
			{
				return new AngleSingle(6.2831855f, AngleType.Radian);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000249C File Offset: 0x0000069C
		public static bool operator ==(AngleSingle left, AngleSingle right)
		{
			return left.radians == right.radians;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000024AC File Offset: 0x000006AC
		public static bool operator !=(AngleSingle left, AngleSingle right)
		{
			return left.radians != right.radians;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000024BF File Offset: 0x000006BF
		public static bool operator <(AngleSingle left, AngleSingle right)
		{
			return left.radians < right.radians;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000024CF File Offset: 0x000006CF
		public static bool operator >(AngleSingle left, AngleSingle right)
		{
			return left.radians > right.radians;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000024DF File Offset: 0x000006DF
		public static bool operator <=(AngleSingle left, AngleSingle right)
		{
			return left.radians <= right.radians;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000024F2 File Offset: 0x000006F2
		public static bool operator >=(AngleSingle left, AngleSingle right)
		{
			return left.radians >= right.radians;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002505 File Offset: 0x00000705
		public static AngleSingle operator +(AngleSingle value)
		{
			return value;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002508 File Offset: 0x00000708
		public static AngleSingle operator -(AngleSingle value)
		{
			return new AngleSingle(-value.radians, AngleType.Radian);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002414 File Offset: 0x00000614
		public static AngleSingle operator +(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians + right.radians, AngleType.Radian);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002429 File Offset: 0x00000629
		public static AngleSingle operator -(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians - right.radians, AngleType.Radian);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000243E File Offset: 0x0000063E
		public static AngleSingle operator *(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians * right.radians, AngleType.Radian);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002453 File Offset: 0x00000653
		public static AngleSingle operator /(AngleSingle left, AngleSingle right)
		{
			return new AngleSingle(left.radians / right.radians, AngleType.Radian);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002518 File Offset: 0x00000718
		public int CompareTo(object other)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is AngleSingle))
			{
				throw new ArgumentException("Argument must be of type Angle.", "other");
			}
			float num = ((AngleSingle)other).radians;
			if (this.radians > num)
			{
				return 1;
			}
			if (this.radians < num)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002565 File Offset: 0x00000765
		public int CompareTo(AngleSingle other)
		{
			if (this.radians > other.radians)
			{
				return 1;
			}
			if (this.radians < other.radians)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002588 File Offset: 0x00000788
		public bool Equals(AngleSingle other)
		{
			return this == other;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002598 File Offset: 0x00000798
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, MathUtil.RadiansToDegrees(this.radians).ToString("0.##°"), new object[0]);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000025D0 File Offset: 0x000007D0
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "{0}°", new object[]
			{
				MathUtil.RadiansToDegrees(this.radians).ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002620 File Offset: 0x00000820
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, MathUtil.RadiansToDegrees(this.radians).ToString("0.##°"), new object[0]);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002654 File Offset: 0x00000854
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "{0}°", new object[]
			{
				MathUtil.RadiansToDegrees(this.radians).ToString(format, CultureInfo.CurrentCulture)
			});
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002699 File Offset: 0x00000899
		public override int GetHashCode()
		{
			return this.radiansInt;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000026A1 File Offset: 0x000008A1
		public override bool Equals(object obj)
		{
			return obj is AngleSingle && this == (AngleSingle)obj;
		}

		// Token: 0x04000001 RID: 1
		public const float Degree = 0.0027777778f;

		// Token: 0x04000002 RID: 2
		public const float Minute = 4.6296296E-05f;

		// Token: 0x04000003 RID: 3
		public const float Second = 7.7160496E-07f;

		// Token: 0x04000004 RID: 4
		public const float Radian = 0.15915494f;

		// Token: 0x04000005 RID: 5
		public const float Milliradian = 0.00015915494f;

		// Token: 0x04000006 RID: 6
		public const float Gradian = 0.0025f;

		// Token: 0x04000007 RID: 7
		[FieldOffset(0)]
		private float radians;

		// Token: 0x04000008 RID: 8
		[FieldOffset(0)]
		private int radiansInt;
	}
}
