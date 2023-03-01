using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x0200000B RID: 11
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct ColorBGRA : IEquatable<ColorBGRA>, IFormattable
	{
		// Token: 0x060001DA RID: 474 RVA: 0x00009A18 File Offset: 0x00007C18
		public ColorBGRA(byte value)
		{
			this.B = value;
			this.G = value;
			this.R = value;
			this.A = value;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00009A48 File Offset: 0x00007C48
		public ColorBGRA(float value)
		{
			this.A = (this.R = (this.G = (this.B = ColorBGRA.ToByte(value))));
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00009A7C File Offset: 0x00007C7C
		public ColorBGRA(byte red, byte green, byte blue, byte alpha)
		{
			this.R = red;
			this.G = green;
			this.B = blue;
			this.A = alpha;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00009A9B File Offset: 0x00007C9B
		public ColorBGRA(float red, float green, float blue, float alpha)
		{
			this.R = ColorBGRA.ToByte(red);
			this.G = ColorBGRA.ToByte(green);
			this.B = ColorBGRA.ToByte(blue);
			this.A = ColorBGRA.ToByte(alpha);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00009AD0 File Offset: 0x00007CD0
		public ColorBGRA(Vector4 value)
		{
			this.R = ColorBGRA.ToByte(value.X);
			this.G = ColorBGRA.ToByte(value.Y);
			this.B = ColorBGRA.ToByte(value.Z);
			this.A = ColorBGRA.ToByte(value.W);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00009B24 File Offset: 0x00007D24
		public ColorBGRA(Vector3 value, float alpha)
		{
			this.R = ColorBGRA.ToByte(value.X);
			this.G = ColorBGRA.ToByte(value.Y);
			this.B = ColorBGRA.ToByte(value.Z);
			this.A = ColorBGRA.ToByte(alpha);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00009B70 File Offset: 0x00007D70
		public ColorBGRA(uint bgra)
		{
			this.A = (byte)(bgra >> 24 & 255U);
			this.R = (byte)(bgra >> 16 & 255U);
			this.G = (byte)(bgra >> 8 & 255U);
			this.B = (byte)(bgra & 255U);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00009BC0 File Offset: 0x00007DC0
		public ColorBGRA(int bgra)
		{
			this.A = (byte)(bgra >> 24 & 255);
			this.R = (byte)(bgra >> 16 & 255);
			this.G = (byte)(bgra >> 8 & 255);
			this.B = (byte)(bgra & 255);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00009C10 File Offset: 0x00007E10
		public ColorBGRA(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for ColorBGRA.");
			}
			this.B = ColorBGRA.ToByte(values[0]);
			this.G = ColorBGRA.ToByte(values[1]);
			this.R = ColorBGRA.ToByte(values[2]);
			this.A = ColorBGRA.ToByte(values[3]);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00009C7C File Offset: 0x00007E7C
		public ColorBGRA(byte[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for ColorBGRA.");
			}
			this.B = values[0];
			this.G = values[1];
			this.R = values[2];
			this.A = values[3];
		}

		// Token: 0x1700002A RID: 42
		public byte this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.B;
				case 1:
					return this.G;
				case 2:
					return this.R;
				case 3:
					return this.A;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for ColorBGRA run from 0 to 3, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.B = value;
					return;
				case 1:
					this.G = value;
					return;
				case 2:
					this.R = value;
					return;
				case 3:
					this.A = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for ColorBGRA run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00009D78 File Offset: 0x00007F78
		public int ToBgra()
		{
			return (int)this.B | (int)this.G << 8 | (int)this.R << 16 | (int)this.A << 24;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00009D9D File Offset: 0x00007F9D
		public int ToRgba()
		{
			return (int)this.R | (int)this.G << 8 | (int)this.B << 16 | (int)this.A << 24;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00009DC2 File Offset: 0x00007FC2
		public Vector3 ToVector3()
		{
			return new Vector3((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00009DF0 File Offset: 0x00007FF0
		public Color3 ToColor3()
		{
			return new Color3((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00009E1E File Offset: 0x0000801E
		public Vector4 ToVector4()
		{
			return new Vector4((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f, (float)this.A / 255f);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00009E59 File Offset: 0x00008059
		public byte[] ToArray()
		{
			return new byte[]
			{
				this.B,
				this.G,
				this.R,
				this.A
			};
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00009E88 File Offset: 0x00008088
		public float GetBrightness()
		{
			float num = (float)this.R / 255f;
			float num2 = (float)this.G / 255f;
			float num3 = (float)this.B / 255f;
			float num4 = num;
			float num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 < num5)
			{
				num5 = num3;
			}
			return (num4 + num5) / 2f;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00009EE4 File Offset: 0x000080E4
		public float GetHue()
		{
			if (this.R == this.G && this.G == this.B)
			{
				return 0f;
			}
			float num = (float)this.R / 255f;
			float num2 = (float)this.G / 255f;
			float num3 = (float)this.B / 255f;
			float num4 = 0f;
			float num5 = num;
			float num6 = num;
			if (num2 > num5)
			{
				num5 = num2;
			}
			if (num3 > num5)
			{
				num5 = num3;
			}
			if (num2 < num6)
			{
				num6 = num2;
			}
			if (num3 < num6)
			{
				num6 = num3;
			}
			float num7 = num5 - num6;
			if (num == num5)
			{
				num4 = (num2 - num3) / num7;
			}
			else if (num2 == num5)
			{
				num4 = 2f + (num3 - num) / num7;
			}
			else if (num3 == num5)
			{
				num4 = 4f + (num - num2) / num7;
			}
			num4 *= 60f;
			if (num4 < 0f)
			{
				num4 += 360f;
			}
			return num4;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00009FC0 File Offset: 0x000081C0
		public float GetSaturation()
		{
			float num = (float)this.R / 255f;
			float num2 = (float)this.G / 255f;
			float num3 = (float)this.B / 255f;
			float result = 0f;
			float num4 = num;
			float num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 < num5)
			{
				num5 = num3;
			}
			if (num4 != num5)
			{
				if ((double)((num4 + num5) / 2f) <= 0.5)
				{
					result = (num4 - num5) / (num4 + num5);
				}
				else
				{
					result = (num4 - num5) / (2f - num4 - num5);
				}
			}
			return result;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000A04D File Offset: 0x0000824D
		public static ColorBGRA FromBgra(int color)
		{
			return new ColorBGRA(color);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000A055 File Offset: 0x00008255
		public static ColorBGRA FromBgra(uint color)
		{
			return new ColorBGRA(color);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000A05D File Offset: 0x0000825D
		public static ColorBGRA FromRgba(int color)
		{
			return new ColorBGRA((byte)(color & 255), (byte)(color >> 8 & 255), (byte)(color >> 16 & 255), (byte)(color >> 24 & 255));
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000A08C File Offset: 0x0000828C
		public static ColorBGRA FromRgba(uint color)
		{
			return ColorBGRA.FromRgba((int)color);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000A094 File Offset: 0x00008294
		public static void Add(ref ColorBGRA left, ref ColorBGRA right, out ColorBGRA result)
		{
			result.A = left.A + right.A;
			result.R = left.R + right.R;
			result.G = left.G + right.G;
			result.B = left.B + right.B;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000A0F1 File Offset: 0x000082F1
		public static ColorBGRA Add(ColorBGRA left, ColorBGRA right)
		{
			return new ColorBGRA((float)(left.R + right.R), (float)(left.G + right.G), (float)(left.B + right.B), (float)(left.A + right.A));
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000A130 File Offset: 0x00008330
		public static void Subtract(ref ColorBGRA left, ref ColorBGRA right, out ColorBGRA result)
		{
			result.A = left.A - right.A;
			result.R = left.R - right.R;
			result.G = left.G - right.G;
			result.B = left.B - right.B;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000A18D File Offset: 0x0000838D
		public static ColorBGRA Subtract(ColorBGRA left, ColorBGRA right)
		{
			return new ColorBGRA((float)(left.R - right.R), (float)(left.G - right.G), (float)(left.B - right.B), (float)(left.A - right.A));
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000A1CC File Offset: 0x000083CC
		public static void Modulate(ref ColorBGRA left, ref ColorBGRA right, out ColorBGRA result)
		{
			result.A = (byte)((float)(left.A * right.A) / 255f);
			result.R = (byte)((float)(left.R * right.R) / 255f);
			result.G = (byte)((float)(left.G * right.G) / 255f);
			result.B = (byte)((float)(left.B * right.B) / 255f);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000A248 File Offset: 0x00008448
		public static ColorBGRA Modulate(ColorBGRA left, ColorBGRA right)
		{
			return new ColorBGRA((float)(left.R * right.R >> 8), (float)(left.G * right.G >> 8), (float)(left.B * right.B >> 8), (float)(left.A * right.A >> 8));
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000A29C File Offset: 0x0000849C
		public static void Scale(ref ColorBGRA value, float scale, out ColorBGRA result)
		{
			result.A = (byte)((float)value.A * scale);
			result.R = (byte)((float)value.R * scale);
			result.G = (byte)((float)value.G * scale);
			result.B = (byte)((float)value.B * scale);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000A2E9 File Offset: 0x000084E9
		public static ColorBGRA Scale(ColorBGRA value, float scale)
		{
			return new ColorBGRA((byte)((float)value.R * scale), (byte)((float)value.G * scale), (byte)((float)value.B * scale), (byte)((float)value.A * scale));
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000A318 File Offset: 0x00008518
		public static void Negate(ref ColorBGRA value, out ColorBGRA result)
		{
			result.A = byte.MaxValue - value.A;
			result.R = byte.MaxValue - value.R;
			result.G = byte.MaxValue - value.G;
			result.B = byte.MaxValue - value.B;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000A371 File Offset: 0x00008571
		public static ColorBGRA Negate(ColorBGRA value)
		{
			return new ColorBGRA((float)(byte.MaxValue - value.R), (float)(byte.MaxValue - value.G), (float)(byte.MaxValue - value.B), (float)(byte.MaxValue - value.A));
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000A3AC File Offset: 0x000085AC
		public static void Clamp(ref ColorBGRA value, ref ColorBGRA min, ref ColorBGRA max, out ColorBGRA result)
		{
			byte b = value.A;
			b = ((b > max.A) ? max.A : b);
			b = ((b < min.A) ? min.A : b);
			byte b2 = value.R;
			b2 = ((b2 > max.R) ? max.R : b2);
			b2 = ((b2 < min.R) ? min.R : b2);
			byte b3 = value.G;
			b3 = ((b3 > max.G) ? max.G : b3);
			b3 = ((b3 < min.G) ? min.G : b3);
			byte b4 = value.B;
			b4 = ((b4 > max.B) ? max.B : b4);
			b4 = ((b4 < min.B) ? min.B : b4);
			result = new ColorBGRA(b2, b3, b4, b);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000A47C File Offset: 0x0000867C
		public static ColorBGRA Clamp(ColorBGRA value, ColorBGRA min, ColorBGRA max)
		{
			ColorBGRA result;
			ColorBGRA.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000A498 File Offset: 0x00008698
		public static void Lerp(ref ColorBGRA start, ref ColorBGRA end, float amount, out ColorBGRA result)
		{
			result.B = MathUtil.Lerp(start.B, end.B, amount);
			result.G = MathUtil.Lerp(start.G, end.G, amount);
			result.R = MathUtil.Lerp(start.R, end.R, amount);
			result.A = MathUtil.Lerp(start.A, end.A, amount);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000A508 File Offset: 0x00008708
		public static ColorBGRA Lerp(ColorBGRA start, ColorBGRA end, float amount)
		{
			ColorBGRA result;
			ColorBGRA.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000A522 File Offset: 0x00008722
		public static void SmoothStep(ref ColorBGRA start, ref ColorBGRA end, float amount, out ColorBGRA result)
		{
			amount = MathUtil.SmoothStep(amount);
			ColorBGRA.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000A538 File Offset: 0x00008738
		public static ColorBGRA SmoothStep(ColorBGRA start, ColorBGRA end, float amount)
		{
			ColorBGRA result;
			ColorBGRA.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000A554 File Offset: 0x00008754
		public static void Max(ref ColorBGRA left, ref ColorBGRA right, out ColorBGRA result)
		{
			result.A = ((left.A > right.A) ? left.A : right.A);
			result.R = ((left.R > right.R) ? left.R : right.R);
			result.G = ((left.G > right.G) ? left.G : right.G);
			result.B = ((left.B > right.B) ? left.B : right.B);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000A5EC File Offset: 0x000087EC
		public static ColorBGRA Max(ColorBGRA left, ColorBGRA right)
		{
			ColorBGRA result;
			ColorBGRA.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000A608 File Offset: 0x00008808
		public static void Min(ref ColorBGRA left, ref ColorBGRA right, out ColorBGRA result)
		{
			result.A = ((left.A < right.A) ? left.A : right.A);
			result.R = ((left.R < right.R) ? left.R : right.R);
			result.G = ((left.G < right.G) ? left.G : right.G);
			result.B = ((left.B < right.B) ? left.B : right.B);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000A6A0 File Offset: 0x000088A0
		public static ColorBGRA Min(ColorBGRA left, ColorBGRA right)
		{
			ColorBGRA result;
			ColorBGRA.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000A6BC File Offset: 0x000088BC
		public static void AdjustContrast(ref ColorBGRA value, float contrast, out ColorBGRA result)
		{
			result.A = value.A;
			result.R = ColorBGRA.ToByte(0.5f + contrast * ((float)value.R / 255f - 0.5f));
			result.G = ColorBGRA.ToByte(0.5f + contrast * ((float)value.G / 255f - 0.5f));
			result.B = ColorBGRA.ToByte(0.5f + contrast * ((float)value.B / 255f - 0.5f));
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000A748 File Offset: 0x00008948
		public static ColorBGRA AdjustContrast(ColorBGRA value, float contrast)
		{
			return new ColorBGRA(ColorBGRA.ToByte(0.5f + contrast * ((float)value.R / 255f - 0.5f)), ColorBGRA.ToByte(0.5f + contrast * ((float)value.G / 255f - 0.5f)), ColorBGRA.ToByte(0.5f + contrast * ((float)value.B / 255f - 0.5f)), value.A);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000A7C0 File Offset: 0x000089C0
		public static void AdjustSaturation(ref ColorBGRA value, float saturation, out ColorBGRA result)
		{
			float num = (float)value.R / 255f * 0.2125f + (float)value.G / 255f * 0.7154f + (float)value.B / 255f * 0.0721f;
			result.A = value.A;
			result.R = ColorBGRA.ToByte(num + saturation * ((float)value.R / 255f - num));
			result.G = ColorBGRA.ToByte(num + saturation * ((float)value.G / 255f - num));
			result.B = ColorBGRA.ToByte(num + saturation * ((float)value.B / 255f - num));
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000A870 File Offset: 0x00008A70
		public static ColorBGRA AdjustSaturation(ColorBGRA value, float saturation)
		{
			float num = (float)value.R / 255f * 0.2125f + (float)value.G / 255f * 0.7154f + (float)value.B / 255f * 0.0721f;
			return new ColorBGRA(ColorBGRA.ToByte(num + saturation * ((float)value.R / 255f - num)), ColorBGRA.ToByte(num + saturation * ((float)value.G / 255f - num)), ColorBGRA.ToByte(num + saturation * ((float)value.B / 255f - num)), value.A);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000A90C File Offset: 0x00008B0C
		public static void Premultiply(ref ColorBGRA value, out ColorBGRA result)
		{
			float num = (float)value.A / 65025f;
			result.A = value.A;
			result.R = ColorBGRA.ToByte((float)value.R * num);
			result.G = ColorBGRA.ToByte((float)value.G * num);
			result.B = ColorBGRA.ToByte((float)value.B * num);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000A970 File Offset: 0x00008B70
		public static ColorBGRA Premultiply(ColorBGRA value)
		{
			ColorBGRA result;
			ColorBGRA.Premultiply(ref value, out result);
			return result;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000A0F1 File Offset: 0x000082F1
		public static ColorBGRA operator +(ColorBGRA left, ColorBGRA right)
		{
			return new ColorBGRA((float)(left.R + right.R), (float)(left.G + right.G), (float)(left.B + right.B), (float)(left.A + right.A));
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00002505 File Offset: 0x00000705
		public static ColorBGRA operator +(ColorBGRA value)
		{
			return value;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000A18D File Offset: 0x0000838D
		public static ColorBGRA operator -(ColorBGRA left, ColorBGRA right)
		{
			return new ColorBGRA((float)(left.R - right.R), (float)(left.G - right.G), (float)(left.B - right.B), (float)(left.A - right.A));
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000A987 File Offset: 0x00008B87
		public static ColorBGRA operator -(ColorBGRA value)
		{
			return new ColorBGRA((float)(-(float)value.R), (float)(-(float)value.G), (float)(-(float)value.B), (float)(-(float)value.A));
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000A9AE File Offset: 0x00008BAE
		public static ColorBGRA operator *(float scale, ColorBGRA value)
		{
			return new ColorBGRA((byte)((float)value.R * scale), (byte)((float)value.G * scale), (byte)((float)value.B * scale), (byte)((float)value.A * scale));
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000A2E9 File Offset: 0x000084E9
		public static ColorBGRA operator *(ColorBGRA value, float scale)
		{
			return new ColorBGRA((byte)((float)value.R * scale), (byte)((float)value.G * scale), (byte)((float)value.B * scale), (byte)((float)value.A * scale));
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000A9E0 File Offset: 0x00008BE0
		public static ColorBGRA operator *(ColorBGRA left, ColorBGRA right)
		{
			return new ColorBGRA((byte)((float)(left.R * right.R) / 255f), (byte)((float)(left.G * right.G) / 255f), (byte)((float)(left.B * right.B) / 255f), (byte)((float)(left.A * right.A) / 255f));
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000AA46 File Offset: 0x00008C46
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(ColorBGRA left, ColorBGRA right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000AA51 File Offset: 0x00008C51
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(ColorBGRA left, ColorBGRA right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000AA5F File Offset: 0x00008C5F
		public static explicit operator Color3(ColorBGRA value)
		{
			return new Color3((float)value.R, (float)value.G, (float)value.B);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00009DC2 File Offset: 0x00007FC2
		public static explicit operator Vector3(ColorBGRA value)
		{
			return new Vector3((float)value.R / 255f, (float)value.G / 255f, (float)value.B / 255f);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00009E1E File Offset: 0x0000801E
		public static explicit operator Vector4(ColorBGRA value)
		{
			return new Vector4((float)value.R / 255f, (float)value.G / 255f, (float)value.B / 255f, (float)value.A / 255f);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000AA7B File Offset: 0x00008C7B
		public static explicit operator Color4(ColorBGRA value)
		{
			return new Color4((float)value.R / 255f, (float)value.G / 255f, (float)value.B / 255f, (float)value.A / 255f);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000AAB6 File Offset: 0x00008CB6
		public static explicit operator ColorBGRA(Vector3 value)
		{
			return new ColorBGRA(value.X / 255f, value.Y / 255f, value.Z / 255f, 1f);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000AAE6 File Offset: 0x00008CE6
		public static explicit operator ColorBGRA(Color3 value)
		{
			return new ColorBGRA(value.Red, value.Green, value.Blue, 1f);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000AB04 File Offset: 0x00008D04
		public static explicit operator ColorBGRA(Vector4 value)
		{
			return new ColorBGRA(value.X, value.Y, value.Z, value.W);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000097FB File Offset: 0x000079FB
		public static explicit operator ColorBGRA(Color4 value)
		{
			return new ColorBGRA(value.Red, value.Green, value.Blue, value.Alpha);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000AB23 File Offset: 0x00008D23
		public static implicit operator ColorBGRA(Color value)
		{
			return new ColorBGRA(value.R, value.G, value.B, value.A);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000AB42 File Offset: 0x00008D42
		public static implicit operator Color(ColorBGRA value)
		{
			return new Color(value.R, value.G, value.B, value.A);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000AB61 File Offset: 0x00008D61
		public static explicit operator int(ColorBGRA value)
		{
			return value.ToBgra();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000A04D File Offset: 0x0000824D
		public static explicit operator ColorBGRA(int value)
		{
			return new ColorBGRA(value);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000AB6A File Offset: 0x00008D6A
		public override string ToString()
		{
			return this.ToString(CultureInfo.CurrentCulture);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000AB77 File Offset: 0x00008D77
		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.CurrentCulture);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000AB88 File Offset: 0x00008D88
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "A:{0} R:{1} G:{2} B:{3}", new object[]
			{
				this.A,
				this.R,
				this.G,
				this.B
			});
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000ABE0 File Offset: 0x00008DE0
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "A:{0} R:{1} G:{2} B:{3}", new object[]
			{
				this.A.ToString(format, formatProvider),
				this.R.ToString(format, formatProvider),
				this.G.ToString(format, formatProvider),
				this.B.ToString(format, formatProvider)
			});
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000AC4C File Offset: 0x00008E4C
		public override int GetHashCode()
		{
			return ((this.B.GetHashCode() * 397 ^ this.G.GetHashCode()) * 397 ^ this.R.GetHashCode()) * 397 ^ this.A.GetHashCode();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000AC9A File Offset: 0x00008E9A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref ColorBGRA other)
		{
			return this.R == other.R && this.G == other.G && this.B == other.B && this.A == other.A;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000ACD6 File Offset: 0x00008ED6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ColorBGRA other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000ACE0 File Offset: 0x00008EE0
		public override bool Equals(object value)
		{
			if (!(value is ColorBGRA))
			{
				return false;
			}
			ColorBGRA colorBGRA = (ColorBGRA)value;
			return this.Equals(ref colorBGRA);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000AD08 File Offset: 0x00008F08
		private static byte ToByte(float component)
		{
			int num = (int)(component * 255f);
			return (byte)((num < 0) ? 0 : ((num > 255) ? 255 : num));
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000AD36 File Offset: 0x00008F36
		public unsafe static implicit operator RawColorBGRA(ColorBGRA value)
		{
			return *(RawColorBGRA*)(&value);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000AD40 File Offset: 0x00008F40
		public unsafe static implicit operator ColorBGRA(RawColorBGRA value)
		{
			return *(ColorBGRA*)(&value);
		}

		// Token: 0x040000BF RID: 191
		private const string toStringFormat = "A:{0} R:{1} G:{2} B:{3}";

		// Token: 0x040000C0 RID: 192
		public byte B;

		// Token: 0x040000C1 RID: 193
		public byte G;

		// Token: 0x040000C2 RID: 194
		public byte R;

		// Token: 0x040000C3 RID: 195
		public byte A;
	}
}
