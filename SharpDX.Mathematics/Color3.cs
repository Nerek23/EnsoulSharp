using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000009 RID: 9
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Color3 : IEquatable<Color3>, IFormattable
	{
		// Token: 0x06000155 RID: 341 RVA: 0x0000807C File Offset: 0x0000627C
		public Color3(float value)
		{
			this.Blue = value;
			this.Green = value;
			this.Red = value;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000080A2 File Offset: 0x000062A2
		public Color3(float red, float green, float blue)
		{
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000080B9 File Offset: 0x000062B9
		public Color3(Vector3 value)
		{
			this.Red = value.X;
			this.Green = value.Y;
			this.Blue = value.Z;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000080E0 File Offset: 0x000062E0
		public Color3(int rgb)
		{
			this.Blue = (float)(rgb >> 16 & 255) / 255f;
			this.Green = (float)(rgb >> 8 & 255) / 255f;
			this.Red = (float)(rgb & 255) / 255f;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00008130 File Offset: 0x00006330
		public Color3(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 3)
			{
				throw new ArgumentOutOfRangeException("values", "There must be three and only three input values for Color3.");
			}
			this.Red = values[0];
			this.Green = values[1];
			this.Blue = values[2];
		}

		// Token: 0x17000028 RID: 40
		public float this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.Red;
				case 1:
					return this.Green;
				case 2:
					return this.Blue;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Color3 run from 0 to 2, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.Red = value;
					return;
				case 1:
					this.Green = value;
					return;
				case 2:
					this.Blue = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Color3 run from 0 to 2, inclusive.");
				}
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000081F4 File Offset: 0x000063F4
		public int ToRgba()
		{
			uint num = 255U;
			int num2 = (int)((uint)(this.Red * 255f) & 255U);
			uint num3 = (uint)(this.Green * 255f) & 255U;
			uint num4 = (uint)(this.Blue * 255f) & 255U;
			return num2 | (int)((int)num3 << 8) | (int)((int)num4 << 16) | (int)((int)num << 24);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00008250 File Offset: 0x00006450
		public int ToBgra()
		{
			uint num = 255U;
			uint num2 = (uint)(this.Red * 255f) & 255U;
			uint num3 = (uint)(this.Green * 255f) & 255U;
			return (int)(((uint)(this.Blue * 255f) & 255U) | num3 << 8 | num2 << 16 | num << 24);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000082AC File Offset: 0x000064AC
		public Vector3 ToVector3()
		{
			return new Vector3(this.Red, this.Green, this.Blue);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000082C5 File Offset: 0x000064C5
		public float[] ToArray()
		{
			return new float[]
			{
				this.Red,
				this.Green,
				this.Blue
			};
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000082E8 File Offset: 0x000064E8
		public static void Add(ref Color3 left, ref Color3 right, out Color3 result)
		{
			result.Red = left.Red + right.Red;
			result.Green = left.Green + right.Green;
			result.Blue = left.Blue + right.Blue;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008323 File Offset: 0x00006523
		public static Color3 Add(Color3 left, Color3 right)
		{
			return new Color3(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00008351 File Offset: 0x00006551
		public static void Subtract(ref Color3 left, ref Color3 right, out Color3 result)
		{
			result.Red = left.Red - right.Red;
			result.Green = left.Green - right.Green;
			result.Blue = left.Blue - right.Blue;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000838C File Offset: 0x0000658C
		public static Color3 Subtract(Color3 left, Color3 right)
		{
			return new Color3(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000083BA File Offset: 0x000065BA
		public static void Modulate(ref Color3 left, ref Color3 right, out Color3 result)
		{
			result.Red = left.Red * right.Red;
			result.Green = left.Green * right.Green;
			result.Blue = left.Blue * right.Blue;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000083F5 File Offset: 0x000065F5
		public static Color3 Modulate(Color3 left, Color3 right)
		{
			return new Color3(left.Red * right.Red, left.Green * right.Green, left.Blue * right.Blue);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00008423 File Offset: 0x00006623
		public static void Scale(ref Color3 value, float scale, out Color3 result)
		{
			result.Red = value.Red * scale;
			result.Green = value.Green * scale;
			result.Blue = value.Blue * scale;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000844F File Offset: 0x0000664F
		public static Color3 Scale(Color3 value, float scale)
		{
			return new Color3(value.Red * scale, value.Green * scale, value.Blue * scale);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000846E File Offset: 0x0000666E
		public static void Negate(ref Color3 value, out Color3 result)
		{
			result.Red = 1f - value.Red;
			result.Green = 1f - value.Green;
			result.Blue = 1f - value.Blue;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000084A6 File Offset: 0x000066A6
		public static Color3 Negate(Color3 value)
		{
			return new Color3(1f - value.Red, 1f - value.Green, 1f - value.Blue);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000084D4 File Offset: 0x000066D4
		public static void Clamp(ref Color3 value, ref Color3 min, ref Color3 max, out Color3 result)
		{
			float num = value.Red;
			num = ((num > max.Red) ? max.Red : num);
			num = ((num < min.Red) ? min.Red : num);
			float num2 = value.Green;
			num2 = ((num2 > max.Green) ? max.Green : num2);
			num2 = ((num2 < min.Green) ? min.Green : num2);
			float num3 = value.Blue;
			num3 = ((num3 > max.Blue) ? max.Blue : num3);
			num3 = ((num3 < min.Blue) ? min.Blue : num3);
			result = new Color3(num, num2, num3);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00008578 File Offset: 0x00006778
		public static Color3 Clamp(Color3 value, Color3 min, Color3 max)
		{
			Color3 result;
			Color3.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00008594 File Offset: 0x00006794
		public static void Lerp(ref Color3 start, ref Color3 end, float amount, out Color3 result)
		{
			result.Red = MathUtil.Lerp(start.Red, end.Red, amount);
			result.Green = MathUtil.Lerp(start.Green, end.Green, amount);
			result.Blue = MathUtil.Lerp(start.Blue, end.Blue, amount);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000085EC File Offset: 0x000067EC
		public static Color3 Lerp(Color3 start, Color3 end, float amount)
		{
			Color3 result;
			Color3.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00008606 File Offset: 0x00006806
		public static void SmoothStep(ref Color3 start, ref Color3 end, float amount, out Color3 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Color3.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000861C File Offset: 0x0000681C
		public static Color3 SmoothStep(Color3 start, Color3 end, float amount)
		{
			Color3 result;
			Color3.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00008638 File Offset: 0x00006838
		public static void Max(ref Color3 left, ref Color3 right, out Color3 result)
		{
			result.Red = ((left.Red > right.Red) ? left.Red : right.Red);
			result.Green = ((left.Green > right.Green) ? left.Green : right.Green);
			result.Blue = ((left.Blue > right.Blue) ? left.Blue : right.Blue);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000086AC File Offset: 0x000068AC
		public static Color3 Max(Color3 left, Color3 right)
		{
			Color3 result;
			Color3.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000086C8 File Offset: 0x000068C8
		public static void Min(ref Color3 left, ref Color3 right, out Color3 result)
		{
			result.Red = ((left.Red < right.Red) ? left.Red : right.Red);
			result.Green = ((left.Green < right.Green) ? left.Green : right.Green);
			result.Blue = ((left.Blue < right.Blue) ? left.Blue : right.Blue);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000873C File Offset: 0x0000693C
		public static Color3 Min(Color3 left, Color3 right)
		{
			Color3 result;
			Color3.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008758 File Offset: 0x00006958
		public static void AdjustContrast(ref Color3 value, float contrast, out Color3 result)
		{
			result.Red = 0.5f + contrast * (value.Red - 0.5f);
			result.Green = 0.5f + contrast * (value.Green - 0.5f);
			result.Blue = 0.5f + contrast * (value.Blue - 0.5f);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000087B4 File Offset: 0x000069B4
		public static Color3 AdjustContrast(Color3 value, float contrast)
		{
			return new Color3(0.5f + contrast * (value.Red - 0.5f), 0.5f + contrast * (value.Green - 0.5f), 0.5f + contrast * (value.Blue - 0.5f));
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00008804 File Offset: 0x00006A04
		public static void AdjustSaturation(ref Color3 value, float saturation, out Color3 result)
		{
			float num = value.Red * 0.2125f + value.Green * 0.7154f + value.Blue * 0.0721f;
			result.Red = num + saturation * (value.Red - num);
			result.Green = num + saturation * (value.Green - num);
			result.Blue = num + saturation * (value.Blue - num);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00008870 File Offset: 0x00006A70
		public static Color3 AdjustSaturation(Color3 value, float saturation)
		{
			float num = value.Red * 0.2125f + value.Green * 0.7154f + value.Blue * 0.0721f;
			return new Color3(num + saturation * (value.Red - num), num + saturation * (value.Green - num), num + saturation * (value.Blue - num));
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00008423 File Offset: 0x00006623
		public static void Premultiply(ref Color3 value, float alpha, out Color3 result)
		{
			result.Red = value.Red * alpha;
			result.Green = value.Green * alpha;
			result.Blue = value.Blue * alpha;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000088D0 File Offset: 0x00006AD0
		public static Color3 Premultiply(Color3 value, float alpha)
		{
			Color3 result;
			Color3.Premultiply(ref value, alpha, out result);
			return result;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00008323 File Offset: 0x00006523
		public static Color3 operator +(Color3 left, Color3 right)
		{
			return new Color3(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00002505 File Offset: 0x00000705
		public static Color3 operator +(Color3 value)
		{
			return value;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000838C File Offset: 0x0000658C
		public static Color3 operator -(Color3 left, Color3 right)
		{
			return new Color3(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000088E8 File Offset: 0x00006AE8
		public static Color3 operator -(Color3 value)
		{
			return new Color3(-value.Red, -value.Green, -value.Blue);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00008904 File Offset: 0x00006B04
		public static Color3 operator *(float scale, Color3 value)
		{
			return new Color3(value.Red * scale, value.Green * scale, value.Blue * scale);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000844F File Offset: 0x0000664F
		public static Color3 operator *(Color3 value, float scale)
		{
			return new Color3(value.Red * scale, value.Green * scale, value.Blue * scale);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000083F5 File Offset: 0x000065F5
		public static Color3 operator *(Color3 left, Color3 right)
		{
			return new Color3(left.Red * right.Red, left.Green * right.Green, left.Blue * right.Blue);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00008923 File Offset: 0x00006B23
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Color3 left, Color3 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000892E File Offset: 0x00006B2E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Color3 left, Color3 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000893C File Offset: 0x00006B3C
		public static explicit operator Color4(Color3 value)
		{
			return new Color4(value.Red, value.Green, value.Blue, 1f);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000082AC File Offset: 0x000064AC
		public static implicit operator Vector3(Color3 value)
		{
			return new Vector3(value.Red, value.Green, value.Blue);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000895A File Offset: 0x00006B5A
		public static implicit operator Color3(Vector3 value)
		{
			return new Color3(value.X, value.Y, value.Z);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008973 File Offset: 0x00006B73
		public static explicit operator Color3(int value)
		{
			return new Color3(value);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000897B File Offset: 0x00006B7B
		public override string ToString()
		{
			return this.ToString(CultureInfo.CurrentCulture);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00008988 File Offset: 0x00006B88
		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.CurrentCulture);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00008996 File Offset: 0x00006B96
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Red:{0} Green:{1} Blue:{2}", new object[]
			{
				this.Red,
				this.Green,
				this.Blue
			});
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000089D4 File Offset: 0x00006BD4
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "Red:{0} Green:{1} Blue:{2}", new object[]
			{
				this.Red.ToString(format, formatProvider),
				this.Green.ToString(format, formatProvider),
				this.Blue.ToString(format, formatProvider)
			});
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00008A2D File Offset: 0x00006C2D
		public override int GetHashCode()
		{
			return (this.Red.GetHashCode() * 397 ^ this.Green.GetHashCode()) * 397 ^ this.Blue.GetHashCode();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00008A5E File Offset: 0x00006C5E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Color3 other)
		{
			return this.Red == other.Red && this.Green == other.Green && this.Blue == other.Blue;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00008A8C File Offset: 0x00006C8C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Color3 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00008A98 File Offset: 0x00006C98
		public override bool Equals(object value)
		{
			if (!(value is Color3))
			{
				return false;
			}
			Color3 color = (Color3)value;
			return this.Equals(ref color);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00008ABE File Offset: 0x00006CBE
		public unsafe static implicit operator RawColor3(Color3 value)
		{
			return *(RawColor3*)(&value);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00008AC8 File Offset: 0x00006CC8
		public unsafe static implicit operator Color3(RawColor3 value)
		{
			return *(Color3*)(&value);
		}

		// Token: 0x040000B2 RID: 178
		private const string toStringFormat = "Red:{0} Green:{1} Blue:{2}";

		// Token: 0x040000B3 RID: 179
		public static readonly Color3 Black = new Color3(0f, 0f, 0f);

		// Token: 0x040000B4 RID: 180
		public static readonly Color3 White = new Color3(1f, 1f, 1f);

		// Token: 0x040000B5 RID: 181
		public float Red;

		// Token: 0x040000B6 RID: 182
		public float Green;

		// Token: 0x040000B7 RID: 183
		public float Blue;
	}
}
