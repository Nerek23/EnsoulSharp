using System;

namespace SharpDX
{
	// Token: 0x02000018 RID: 24
	public static class MathUtil
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0000C904 File Offset: 0x0000AB04
		public unsafe static bool NearEqual(float a, float b)
		{
			if (MathUtil.IsZero(a - b))
			{
				return true;
			}
			int num = *(int*)(&a);
			int num2 = *(int*)(&b);
			return num < 0 == num2 < 0 && Math.Abs(num - num2) <= 4;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000C941 File Offset: 0x0000AB41
		public static bool IsZero(float a)
		{
			return Math.Abs(a) < 1E-06f;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000C950 File Offset: 0x0000AB50
		public static bool IsOne(float a)
		{
			return MathUtil.IsZero(a - 1f);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000C960 File Offset: 0x0000AB60
		public static bool WithinEpsilon(float a, float b, float epsilon)
		{
			float num = a - b;
			return -epsilon <= num && num <= epsilon;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000C97F File Offset: 0x0000AB7F
		public static float RevolutionsToDegrees(float revolution)
		{
			return revolution * 360f;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000C988 File Offset: 0x0000AB88
		public static float RevolutionsToRadians(float revolution)
		{
			return revolution * 6.2831855f;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000C991 File Offset: 0x0000AB91
		public static float RevolutionsToGradians(float revolution)
		{
			return revolution * 400f;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000C99A File Offset: 0x0000AB9A
		public static float DegreesToRevolutions(float degree)
		{
			return degree / 360f;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000C9A3 File Offset: 0x0000ABA3
		public static float DegreesToRadians(float degree)
		{
			return degree * 0.017453292f;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000C9AC File Offset: 0x0000ABAC
		public static float RadiansToRevolutions(float radian)
		{
			return radian / 6.2831855f;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000C9B5 File Offset: 0x0000ABB5
		public static float RadiansToGradians(float radian)
		{
			return radian * 63.661976f;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000C9BE File Offset: 0x0000ABBE
		public static float GradiansToRevolutions(float gradian)
		{
			return gradian / 400f;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000C9C7 File Offset: 0x0000ABC7
		public static float GradiansToDegrees(float gradian)
		{
			return gradian * 0.9f;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000C9D0 File Offset: 0x0000ABD0
		public static float GradiansToRadians(float gradian)
		{
			return gradian * 0.015707964f;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000C9D9 File Offset: 0x0000ABD9
		public static float RadiansToDegrees(float radian)
		{
			return radian * 57.295776f;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000C9E2 File Offset: 0x0000ABE2
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			if (value <= max)
			{
				return value;
			}
			return max;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000C9E2 File Offset: 0x0000ABE2
		public static int Clamp(int value, int min, int max)
		{
			if (value < min)
			{
				return min;
			}
			if (value <= max)
			{
				return value;
			}
			return max;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000C9F1 File Offset: 0x0000ABF1
		public static double Lerp(double from, double to, double amount)
		{
			return (1.0 - amount) * from + amount * to;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000CA04 File Offset: 0x0000AC04
		public static float Lerp(float from, float to, float amount)
		{
			return (1f - amount) * from + amount * to;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000CA13 File Offset: 0x0000AC13
		public static byte Lerp(byte from, byte to, float amount)
		{
			return (byte)MathUtil.Lerp((float)from, (float)to, amount);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000CA20 File Offset: 0x0000AC20
		public static float SmoothStep(float amount)
		{
			if (amount <= 0f)
			{
				return 0f;
			}
			if (amount < 1f)
			{
				return amount * amount * (3f - 2f * amount);
			}
			return 1f;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000CA4F File Offset: 0x0000AC4F
		public static float SmootherStep(float amount)
		{
			if (amount <= 0f)
			{
				return 0f;
			}
			if (amount < 1f)
			{
				return amount * amount * amount * (amount * (amount * 6f - 15f) + 10f);
			}
			return 1f;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000CA88 File Offset: 0x0000AC88
		public static float Mod(float value, float modulo)
		{
			if (modulo == 0f)
			{
				return value;
			}
			return value % modulo;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000CA97 File Offset: 0x0000AC97
		public static float Mod2PI(float value)
		{
			return MathUtil.Mod(value, 6.2831855f);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
		public static int Wrap(int value, int min, int max)
		{
			if (min > max)
			{
				throw new ArgumentException(string.Format("min {0} should be less than or equal to max {1}", min, max), "min");
			}
			int num = max - min + 1;
			if (value < min)
			{
				value += num * ((min - value) / num + 1);
			}
			return min + (value - min) % num;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000CAF4 File Offset: 0x0000ACF4
		public static float Wrap(float value, float min, float max)
		{
			if (MathUtil.NearEqual(min, max))
			{
				return min;
			}
			double num = (double)min;
			double num2 = (double)max;
			double num3 = (double)value;
			if (num > num2)
			{
				throw new ArgumentException(string.Format("min {0} should be less than or equal to max {1}", min, max), "min");
			}
			double num4 = num2 - num;
			return (float)(num + (num3 - num) - num4 * Math.Floor((num3 - num) / num4));
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000CB51 File Offset: 0x0000AD51
		public static float Gauss(float amplitude, float x, float y, float centerX, float centerY, float sigmaX, float sigmaY)
		{
			return (float)MathUtil.Gauss((double)amplitude, (double)x, (double)y, (double)centerX, (double)centerY, (double)sigmaX, (double)sigmaY);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000CB6C File Offset: 0x0000AD6C
		public static double Gauss(double amplitude, double x, double y, double centerX, double centerY, double sigmaX, double sigmaY)
		{
			double num = x - centerX;
			double num2 = y - centerY;
			double num3 = num * num / (2.0 * sigmaX * sigmaX);
			double num4 = num2 * num2 / (2.0 * sigmaY * sigmaY);
			return amplitude * Math.Exp(-(num3 + num4));
		}

		// Token: 0x04000108 RID: 264
		public const float ZeroTolerance = 1E-06f;

		// Token: 0x04000109 RID: 265
		public const float Pi = 3.1415927f;

		// Token: 0x0400010A RID: 266
		public const float TwoPi = 6.2831855f;

		// Token: 0x0400010B RID: 267
		public const float PiOverTwo = 1.5707964f;

		// Token: 0x0400010C RID: 268
		public const float PiOverFour = 0.7853982f;
	}
}
