using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000008 RID: 8
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct Color : IEquatable<Color>, IFormattable
	{
		// Token: 0x060000F8 RID: 248 RVA: 0x00006420 File Offset: 0x00004620
		public Color(byte value)
		{
			this.B = value;
			this.G = value;
			this.R = value;
			this.A = value;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006450 File Offset: 0x00004650
		public Color(float value)
		{
			this.A = (this.R = (this.G = (this.B = Color.ToByte(value))));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006484 File Offset: 0x00004684
		public Color(byte red, byte green, byte blue, byte alpha)
		{
			this.R = red;
			this.G = green;
			this.B = blue;
			this.A = alpha;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000064A3 File Offset: 0x000046A3
		public Color(byte red, byte green, byte blue)
		{
			this.R = red;
			this.G = green;
			this.B = blue;
			this.A = byte.MaxValue;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000064C5 File Offset: 0x000046C5
		public Color(int red, int green, int blue, int alpha)
		{
			this.R = Color.ToByte(red);
			this.G = Color.ToByte(green);
			this.B = Color.ToByte(blue);
			this.A = Color.ToByte(alpha);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000064F8 File Offset: 0x000046F8
		public Color(int red, int green, int blue)
		{
			this = new Color(red, green, blue, 255);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006508 File Offset: 0x00004708
		public Color(float red, float green, float blue, float alpha)
		{
			this.R = Color.ToByte(red);
			this.G = Color.ToByte(green);
			this.B = Color.ToByte(blue);
			this.A = Color.ToByte(alpha);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000653B File Offset: 0x0000473B
		public Color(float red, float green, float blue)
		{
			this.R = Color.ToByte(red);
			this.G = Color.ToByte(green);
			this.B = Color.ToByte(blue);
			this.A = byte.MaxValue;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000656C File Offset: 0x0000476C
		public Color(Vector4 value)
		{
			this.R = Color.ToByte(value.X);
			this.G = Color.ToByte(value.Y);
			this.B = Color.ToByte(value.Z);
			this.A = Color.ToByte(value.W);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000065C0 File Offset: 0x000047C0
		public Color(Vector3 value, float alpha)
		{
			this.R = Color.ToByte(value.X);
			this.G = Color.ToByte(value.Y);
			this.B = Color.ToByte(value.Z);
			this.A = Color.ToByte(alpha);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000660C File Offset: 0x0000480C
		public Color(Vector3 value)
		{
			this.R = Color.ToByte(value.X);
			this.G = Color.ToByte(value.Y);
			this.B = Color.ToByte(value.Z);
			this.A = byte.MaxValue;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000664C File Offset: 0x0000484C
		public Color(uint rgba)
		{
			this.A = (byte)(rgba >> 24 & 255U);
			this.B = (byte)(rgba >> 16 & 255U);
			this.G = (byte)(rgba >> 8 & 255U);
			this.R = (byte)(rgba & 255U);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000669C File Offset: 0x0000489C
		public Color(int rgba)
		{
			this.A = (byte)(rgba >> 24 & 255);
			this.B = (byte)(rgba >> 16 & 255);
			this.G = (byte)(rgba >> 8 & 255);
			this.R = (byte)(rgba & 255);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000066EC File Offset: 0x000048EC
		public Color(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Color.");
			}
			this.R = Color.ToByte(values[0]);
			this.G = Color.ToByte(values[1]);
			this.B = Color.ToByte(values[2]);
			this.A = Color.ToByte(values[3]);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00006758 File Offset: 0x00004958
		public Color(byte[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Color.");
			}
			this.R = values[0];
			this.G = values[1];
			this.B = values[2];
			this.A = values[3];
		}

		// Token: 0x17000027 RID: 39
		public byte this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.R;
				case 1:
					return this.G;
				case 2:
					return this.B;
				case 3:
					return this.A;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Color run from 0 to 3, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.R = value;
					return;
				case 1:
					this.G = value;
					return;
				case 2:
					this.B = value;
					return;
				case 3:
					this.A = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Color run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00006854 File Offset: 0x00004A54
		public int ToBgra()
		{
			return (int)this.B | (int)this.G << 8 | (int)this.R << 16 | (int)this.A << 24;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006879 File Offset: 0x00004A79
		public int ToRgba()
		{
			return (int)this.R | (int)this.G << 8 | (int)this.B << 16 | (int)this.A << 24;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000689E File Offset: 0x00004A9E
		public int ToAbgr()
		{
			return (int)this.A | (int)this.B << 8 | (int)this.G << 16 | (int)this.R << 24;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000068C3 File Offset: 0x00004AC3
		public Vector3 ToVector3()
		{
			return new Vector3((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000068F1 File Offset: 0x00004AF1
		public Color3 ToColor3()
		{
			return new Color3((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000691F File Offset: 0x00004B1F
		public Vector4 ToVector4()
		{
			return new Vector4((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f, (float)this.A / 255f);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000695A File Offset: 0x00004B5A
		public byte[] ToArray()
		{
			return new byte[]
			{
				this.R,
				this.G,
				this.B,
				this.A
			};
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00006988 File Offset: 0x00004B88
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

		// Token: 0x06000111 RID: 273 RVA: 0x000069E4 File Offset: 0x00004BE4
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

		// Token: 0x06000112 RID: 274 RVA: 0x00006AC0 File Offset: 0x00004CC0
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

		// Token: 0x06000113 RID: 275 RVA: 0x00006B50 File Offset: 0x00004D50
		public static void Add(ref Color left, ref Color right, out Color result)
		{
			result.A = left.A + right.A;
			result.R = left.R + right.R;
			result.G = left.G + right.G;
			result.B = left.B + right.B;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006BAD File Offset: 0x00004DAD
		public static Color Add(Color left, Color right)
		{
			return new Color((int)(left.R + right.R), (int)(left.G + right.G), (int)(left.B + right.B), (int)(left.A + right.A));
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00006BE8 File Offset: 0x00004DE8
		public static void Subtract(ref Color left, ref Color right, out Color result)
		{
			result.A = left.A - right.A;
			result.R = left.R - right.R;
			result.G = left.G - right.G;
			result.B = left.B - right.B;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00006C45 File Offset: 0x00004E45
		public static Color Subtract(Color left, Color right)
		{
			return new Color((int)(left.R - right.R), (int)(left.G - right.G), (int)(left.B - right.B), (int)(left.A - right.A));
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00006C80 File Offset: 0x00004E80
		public static void Modulate(ref Color left, ref Color right, out Color result)
		{
			result.A = (byte)((float)(left.A * right.A) / 255f);
			result.R = (byte)((float)(left.R * right.R) / 255f);
			result.G = (byte)((float)(left.G * right.G) / 255f);
			result.B = (byte)((float)(left.B * right.B) / 255f);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00006CF9 File Offset: 0x00004EF9
		public static Color Modulate(Color left, Color right)
		{
			return new Color((int)(left.R * right.R), (int)(left.G * right.G), (int)(left.B * right.B), (int)(left.A * right.A));
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00006D34 File Offset: 0x00004F34
		public static void Scale(ref Color value, float scale, out Color result)
		{
			result.A = (byte)((float)value.A * scale);
			result.R = (byte)((float)value.R * scale);
			result.G = (byte)((float)value.G * scale);
			result.B = (byte)((float)value.B * scale);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00006D81 File Offset: 0x00004F81
		public static Color Scale(Color value, float scale)
		{
			return new Color((byte)((float)value.R * scale), (byte)((float)value.G * scale), (byte)((float)value.B * scale), (byte)((float)value.A * scale));
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00006DB0 File Offset: 0x00004FB0
		public static void Negate(ref Color value, out Color result)
		{
			result.A = byte.MaxValue - value.A;
			result.R = byte.MaxValue - value.R;
			result.G = byte.MaxValue - value.G;
			result.B = byte.MaxValue - value.B;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00006E09 File Offset: 0x00005009
		public static Color Negate(Color value)
		{
			return new Color((int)(byte.MaxValue - value.R), (int)(byte.MaxValue - value.G), (int)(byte.MaxValue - value.B), (int)(byte.MaxValue - value.A));
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00006E40 File Offset: 0x00005040
		public static void Clamp(ref Color value, ref Color min, ref Color max, out Color result)
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
			result = new Color(b2, b3, b4, b);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00006F10 File Offset: 0x00005110
		public static void Premultiply(ref Color value, out Color result)
		{
			float num = (float)value.A / 65025f;
			result.A = value.A;
			result.R = Color.ToByte((float)value.R * num);
			result.G = Color.ToByte((float)value.G * num);
			result.B = Color.ToByte((float)value.B * num);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00006F74 File Offset: 0x00005174
		public static Color Premultiply(Color value)
		{
			Color result;
			Color.Premultiply(ref value, out result);
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00006F8B File Offset: 0x0000518B
		public static Color FromBgra(int color)
		{
			return new Color((byte)(color >> 16 & 255), (byte)(color >> 8 & 255), (byte)(color & 255), (byte)(color >> 24 & 255));
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00006FBA File Offset: 0x000051BA
		public static Color FromBgra(uint color)
		{
			return Color.FromBgra((int)color);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006FC2 File Offset: 0x000051C2
		public static Color FromAbgr(int color)
		{
			return new Color((byte)(color >> 24), (byte)(color >> 16), (byte)(color >> 8), (byte)color);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006FD9 File Offset: 0x000051D9
		public static Color FromAbgr(uint color)
		{
			return Color.FromAbgr((int)color);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006FE1 File Offset: 0x000051E1
		public static Color FromRgba(int color)
		{
			return new Color(color);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006FE9 File Offset: 0x000051E9
		public static Color FromRgba(uint color)
		{
			return new Color(color);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006FF4 File Offset: 0x000051F4
		public static Color Clamp(Color value, Color min, Color max)
		{
			Color result;
			Color.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00007010 File Offset: 0x00005210
		public static void Lerp(ref Color start, ref Color end, float amount, out Color result)
		{
			result.R = MathUtil.Lerp(start.R, end.R, amount);
			result.G = MathUtil.Lerp(start.G, end.G, amount);
			result.B = MathUtil.Lerp(start.B, end.B, amount);
			result.A = MathUtil.Lerp(start.A, end.A, amount);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00007080 File Offset: 0x00005280
		public static Color Lerp(Color start, Color end, float amount)
		{
			Color result;
			Color.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000709A File Offset: 0x0000529A
		public static void SmoothStep(ref Color start, ref Color end, float amount, out Color result)
		{
			amount = MathUtil.SmoothStep(amount);
			Color.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000070B0 File Offset: 0x000052B0
		public static Color SmoothStep(Color start, Color end, float amount)
		{
			Color result;
			Color.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000070CC File Offset: 0x000052CC
		public static void Max(ref Color left, ref Color right, out Color result)
		{
			result.A = ((left.A > right.A) ? left.A : right.A);
			result.R = ((left.R > right.R) ? left.R : right.R);
			result.G = ((left.G > right.G) ? left.G : right.G);
			result.B = ((left.B > right.B) ? left.B : right.B);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00007164 File Offset: 0x00005364
		public static Color Max(Color left, Color right)
		{
			Color result;
			Color.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00007180 File Offset: 0x00005380
		public static void Min(ref Color left, ref Color right, out Color result)
		{
			result.A = ((left.A < right.A) ? left.A : right.A);
			result.R = ((left.R < right.R) ? left.R : right.R);
			result.G = ((left.G < right.G) ? left.G : right.G);
			result.B = ((left.B < right.B) ? left.B : right.B);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00007218 File Offset: 0x00005418
		public static Color Min(Color left, Color right)
		{
			Color result;
			Color.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00007234 File Offset: 0x00005434
		public static void AdjustContrast(ref Color value, float contrast, out Color result)
		{
			result.A = value.A;
			result.R = Color.ToByte(0.5f + contrast * ((float)value.R / 255f - 0.5f));
			result.G = Color.ToByte(0.5f + contrast * ((float)value.G / 255f - 0.5f));
			result.B = Color.ToByte(0.5f + contrast * ((float)value.B / 255f - 0.5f));
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000072C0 File Offset: 0x000054C0
		public static Color AdjustContrast(Color value, float contrast)
		{
			return new Color(Color.ToByte(0.5f + contrast * ((float)value.R / 255f - 0.5f)), Color.ToByte(0.5f + contrast * ((float)value.G / 255f - 0.5f)), Color.ToByte(0.5f + contrast * ((float)value.B / 255f - 0.5f)), value.A);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007338 File Offset: 0x00005538
		public static void AdjustSaturation(ref Color value, float saturation, out Color result)
		{
			float num = (float)value.R / 255f * 0.2125f + (float)value.G / 255f * 0.7154f + (float)value.B / 255f * 0.0721f;
			result.A = value.A;
			result.R = Color.ToByte(num + saturation * ((float)value.R / 255f - num));
			result.G = Color.ToByte(num + saturation * ((float)value.G / 255f - num));
			result.B = Color.ToByte(num + saturation * ((float)value.B / 255f - num));
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000073E8 File Offset: 0x000055E8
		public static Color AdjustSaturation(Color value, float saturation)
		{
			float num = (float)value.R / 255f * 0.2125f + (float)value.G / 255f * 0.7154f + (float)value.B / 255f * 0.0721f;
			return new Color(Color.ToByte(num + saturation * ((float)value.R / 255f - num)), Color.ToByte(num + saturation * ((float)value.G / 255f - num)), Color.ToByte(num + saturation * ((float)value.B / 255f - num)), value.A);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00006BAD File Offset: 0x00004DAD
		public static Color operator +(Color left, Color right)
		{
			return new Color((int)(left.R + right.R), (int)(left.G + right.G), (int)(left.B + right.B), (int)(left.A + right.A));
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00002505 File Offset: 0x00000705
		public static Color operator +(Color value)
		{
			return value;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00006C45 File Offset: 0x00004E45
		public static Color operator -(Color left, Color right)
		{
			return new Color((int)(left.R - right.R), (int)(left.G - right.G), (int)(left.B - right.B), (int)(left.A - right.A));
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007484 File Offset: 0x00005684
		public static Color operator -(Color value)
		{
			return new Color((int)(-(int)value.R), (int)(-(int)value.G), (int)(-(int)value.B), (int)(-(int)value.A));
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000074A7 File Offset: 0x000056A7
		public static Color operator *(float scale, Color value)
		{
			return new Color((byte)((float)value.R * scale), (byte)((float)value.G * scale), (byte)((float)value.B * scale), (byte)((float)value.A * scale));
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00006D81 File Offset: 0x00004F81
		public static Color operator *(Color value, float scale)
		{
			return new Color((byte)((float)value.R * scale), (byte)((float)value.G * scale), (byte)((float)value.B * scale), (byte)((float)value.A * scale));
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000074D8 File Offset: 0x000056D8
		public static Color operator *(Color left, Color right)
		{
			return new Color((byte)((float)(left.R * right.R) / 255f), (byte)((float)(left.G * right.G) / 255f), (byte)((float)(left.B * right.B) / 255f), (byte)((float)(left.A * right.A) / 255f));
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000753E File Offset: 0x0000573E
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Color left, Color right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00007549 File Offset: 0x00005749
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Color left, Color right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00007557 File Offset: 0x00005757
		public static explicit operator Color3(Color value)
		{
			return value.ToColor3();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000068C3 File Offset: 0x00004AC3
		public static explicit operator Vector3(Color value)
		{
			return new Vector3((float)value.R / 255f, (float)value.G / 255f, (float)value.B / 255f);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000691F File Offset: 0x00004B1F
		public static explicit operator Vector4(Color value)
		{
			return new Vector4((float)value.R / 255f, (float)value.G / 255f, (float)value.B / 255f, (float)value.A / 255f);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00007560 File Offset: 0x00005760
		public Color4 ToColor4()
		{
			return new Color4((float)this.R / 255f, (float)this.G / 255f, (float)this.B / 255f, (float)this.A / 255f);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000759B File Offset: 0x0000579B
		public static implicit operator Color4(Color value)
		{
			return value.ToColor4();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000075A4 File Offset: 0x000057A4
		public static implicit operator RawColor4(Color value)
		{
			return value.ToColor4();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000075B2 File Offset: 0x000057B2
		public static implicit operator RawColorBGRA(Color value)
		{
			return new RawColorBGRA(value.B, value.G, value.R, value.A);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000075D1 File Offset: 0x000057D1
		public static implicit operator RawColor4?(Color value)
		{
			return new RawColor4?(value.ToColor4());
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000075E4 File Offset: 0x000057E4
		public static explicit operator Color(Vector3 value)
		{
			return new Color(value.X, value.Y, value.Z, 1f);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00007602 File Offset: 0x00005802
		public static explicit operator Color(Color3 value)
		{
			return new Color(value.Red, value.Green, value.Blue, 1f);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00007620 File Offset: 0x00005820
		public static explicit operator Color(Vector4 value)
		{
			return new Color(value.X, value.Y, value.Z, value.W);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000763F File Offset: 0x0000583F
		public static explicit operator Color(Color4 value)
		{
			return new Color(value.Red, value.Green, value.Blue, value.Alpha);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000765E File Offset: 0x0000585E
		public static explicit operator int(Color value)
		{
			return value.ToRgba();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00006FE1 File Offset: 0x000051E1
		public static explicit operator Color(int value)
		{
			return new Color(value);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00007667 File Offset: 0x00005867
		public override string ToString()
		{
			return this.ToString(CultureInfo.CurrentCulture);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00007674 File Offset: 0x00005874
		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.CurrentCulture);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00007684 File Offset: 0x00005884
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

		// Token: 0x0600014D RID: 333 RVA: 0x000076DC File Offset: 0x000058DC
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

		// Token: 0x0600014E RID: 334 RVA: 0x00007748 File Offset: 0x00005948
		public override int GetHashCode()
		{
			return ((this.R.GetHashCode() * 397 ^ this.G.GetHashCode()) * 397 ^ this.B.GetHashCode()) * 397 ^ this.A.GetHashCode();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00007796 File Offset: 0x00005996
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Color other)
		{
			return this.R == other.R && this.G == other.G && this.B == other.B && this.A == other.A;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000077D2 File Offset: 0x000059D2
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Color other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000077DC File Offset: 0x000059DC
		public override bool Equals(object value)
		{
			if (!(value is Color))
			{
				return false;
			}
			Color color = (Color)value;
			return this.Equals(ref color);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00007802 File Offset: 0x00005A02
		private static byte ToByte(float component)
		{
			return Color.ToByte((int)(component * 255f));
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00007811 File Offset: 0x00005A11
		public static byte ToByte(int value)
		{
			return (byte)((value < 0) ? 0 : ((value > 255) ? 255 : value));
		}

		// Token: 0x0400001F RID: 31
		private const string toStringFormat = "A:{0} R:{1} G:{2} B:{3}";

		// Token: 0x04000020 RID: 32
		public byte R;

		// Token: 0x04000021 RID: 33
		public byte G;

		// Token: 0x04000022 RID: 34
		public byte B;

		// Token: 0x04000023 RID: 35
		public byte A;

		// Token: 0x04000024 RID: 36
		public static readonly Color Zero = Color.FromBgra(0);

		// Token: 0x04000025 RID: 37
		public static readonly Color Transparent = Color.FromBgra(0);

		// Token: 0x04000026 RID: 38
		public static readonly Color AliceBlue = Color.FromBgra(4293982463U);

		// Token: 0x04000027 RID: 39
		public static readonly Color AntiqueWhite = Color.FromBgra(4294634455U);

		// Token: 0x04000028 RID: 40
		public static readonly Color Aqua = Color.FromBgra(4278255615U);

		// Token: 0x04000029 RID: 41
		public static readonly Color Aquamarine = Color.FromBgra(4286578644U);

		// Token: 0x0400002A RID: 42
		public static readonly Color Azure = Color.FromBgra(4293984255U);

		// Token: 0x0400002B RID: 43
		public static readonly Color Beige = Color.FromBgra(4294309340U);

		// Token: 0x0400002C RID: 44
		public static readonly Color Bisque = Color.FromBgra(4294960324U);

		// Token: 0x0400002D RID: 45
		public static readonly Color Black = Color.FromBgra(4278190080U);

		// Token: 0x0400002E RID: 46
		public static readonly Color BlanchedAlmond = Color.FromBgra(4294962125U);

		// Token: 0x0400002F RID: 47
		public static readonly Color Blue = Color.FromBgra(4278190335U);

		// Token: 0x04000030 RID: 48
		public static readonly Color BlueViolet = Color.FromBgra(4287245282U);

		// Token: 0x04000031 RID: 49
		public static readonly Color Brown = Color.FromBgra(4289014314U);

		// Token: 0x04000032 RID: 50
		public static readonly Color BurlyWood = Color.FromBgra(4292786311U);

		// Token: 0x04000033 RID: 51
		public static readonly Color CadetBlue = Color.FromBgra(4284456608U);

		// Token: 0x04000034 RID: 52
		public static readonly Color Chartreuse = Color.FromBgra(4286578432U);

		// Token: 0x04000035 RID: 53
		public static readonly Color Chocolate = Color.FromBgra(4291979550U);

		// Token: 0x04000036 RID: 54
		public static readonly Color Coral = Color.FromBgra(4294934352U);

		// Token: 0x04000037 RID: 55
		public static readonly Color CornflowerBlue = Color.FromBgra(4284782061U);

		// Token: 0x04000038 RID: 56
		public static readonly Color Cornsilk = Color.FromBgra(4294965468U);

		// Token: 0x04000039 RID: 57
		public static readonly Color Crimson = Color.FromBgra(4292613180U);

		// Token: 0x0400003A RID: 58
		public static readonly Color Cyan = Color.FromBgra(4278255615U);

		// Token: 0x0400003B RID: 59
		public static readonly Color DarkBlue = Color.FromBgra(4278190219U);

		// Token: 0x0400003C RID: 60
		public static readonly Color DarkCyan = Color.FromBgra(4278225803U);

		// Token: 0x0400003D RID: 61
		public static readonly Color DarkGoldenrod = Color.FromBgra(4290283019U);

		// Token: 0x0400003E RID: 62
		public static readonly Color DarkGray = Color.FromBgra(4289309097U);

		// Token: 0x0400003F RID: 63
		public static readonly Color DarkGreen = Color.FromBgra(4278215680U);

		// Token: 0x04000040 RID: 64
		public static readonly Color DarkKhaki = Color.FromBgra(4290623339U);

		// Token: 0x04000041 RID: 65
		public static readonly Color DarkMagenta = Color.FromBgra(4287299723U);

		// Token: 0x04000042 RID: 66
		public static readonly Color DarkOliveGreen = Color.FromBgra(4283788079U);

		// Token: 0x04000043 RID: 67
		public static readonly Color DarkOrange = Color.FromBgra(4294937600U);

		// Token: 0x04000044 RID: 68
		public static readonly Color DarkOrchid = Color.FromBgra(4288230092U);

		// Token: 0x04000045 RID: 69
		public static readonly Color DarkRed = Color.FromBgra(4287299584U);

		// Token: 0x04000046 RID: 70
		public static readonly Color DarkSalmon = Color.FromBgra(4293498490U);

		// Token: 0x04000047 RID: 71
		public static readonly Color DarkSeaGreen = Color.FromBgra(4287609995U);

		// Token: 0x04000048 RID: 72
		public static readonly Color DarkSlateBlue = Color.FromBgra(4282924427U);

		// Token: 0x04000049 RID: 73
		public static readonly Color DarkSlateGray = Color.FromBgra(4281290575U);

		// Token: 0x0400004A RID: 74
		public static readonly Color DarkTurquoise = Color.FromBgra(4278243025U);

		// Token: 0x0400004B RID: 75
		public static readonly Color DarkViolet = Color.FromBgra(4287889619U);

		// Token: 0x0400004C RID: 76
		public static readonly Color DeepPink = Color.FromBgra(4294907027U);

		// Token: 0x0400004D RID: 77
		public static readonly Color DeepSkyBlue = Color.FromBgra(4278239231U);

		// Token: 0x0400004E RID: 78
		public static readonly Color DimGray = Color.FromBgra(4285098345U);

		// Token: 0x0400004F RID: 79
		public static readonly Color DodgerBlue = Color.FromBgra(4280193279U);

		// Token: 0x04000050 RID: 80
		public static readonly Color Firebrick = Color.FromBgra(4289864226U);

		// Token: 0x04000051 RID: 81
		public static readonly Color FloralWhite = Color.FromBgra(4294966000U);

		// Token: 0x04000052 RID: 82
		public static readonly Color ForestGreen = Color.FromBgra(4280453922U);

		// Token: 0x04000053 RID: 83
		public static readonly Color Fuchsia = Color.FromBgra(4294902015U);

		// Token: 0x04000054 RID: 84
		public static readonly Color Gainsboro = Color.FromBgra(4292664540U);

		// Token: 0x04000055 RID: 85
		public static readonly Color GhostWhite = Color.FromBgra(4294506751U);

		// Token: 0x04000056 RID: 86
		public static readonly Color Gold = Color.FromBgra(4294956800U);

		// Token: 0x04000057 RID: 87
		public static readonly Color Goldenrod = Color.FromBgra(4292519200U);

		// Token: 0x04000058 RID: 88
		public static readonly Color Gray = Color.FromBgra(4286611584U);

		// Token: 0x04000059 RID: 89
		public static readonly Color Green = Color.FromBgra(4278222848U);

		// Token: 0x0400005A RID: 90
		public static readonly Color GreenYellow = Color.FromBgra(4289593135U);

		// Token: 0x0400005B RID: 91
		public static readonly Color Honeydew = Color.FromBgra(4293984240U);

		// Token: 0x0400005C RID: 92
		public static readonly Color HotPink = Color.FromBgra(4294928820U);

		// Token: 0x0400005D RID: 93
		public static readonly Color IndianRed = Color.FromBgra(4291648604U);

		// Token: 0x0400005E RID: 94
		public static readonly Color Indigo = Color.FromBgra(4283105410U);

		// Token: 0x0400005F RID: 95
		public static readonly Color Ivory = Color.FromBgra(4294967280U);

		// Token: 0x04000060 RID: 96
		public static readonly Color Khaki = Color.FromBgra(4293977740U);

		// Token: 0x04000061 RID: 97
		public static readonly Color Lavender = Color.FromBgra(4293322490U);

		// Token: 0x04000062 RID: 98
		public static readonly Color LavenderBlush = Color.FromBgra(4294963445U);

		// Token: 0x04000063 RID: 99
		public static readonly Color LawnGreen = Color.FromBgra(4286381056U);

		// Token: 0x04000064 RID: 100
		public static readonly Color LemonChiffon = Color.FromBgra(4294965965U);

		// Token: 0x04000065 RID: 101
		public static readonly Color LightBlue = Color.FromBgra(4289583334U);

		// Token: 0x04000066 RID: 102
		public static readonly Color LightCoral = Color.FromBgra(4293951616U);

		// Token: 0x04000067 RID: 103
		public static readonly Color LightCyan = Color.FromBgra(4292935679U);

		// Token: 0x04000068 RID: 104
		public static readonly Color LightGoldenrodYellow = Color.FromBgra(4294638290U);

		// Token: 0x04000069 RID: 105
		public static readonly Color LightGray = Color.FromBgra(4292072403U);

		// Token: 0x0400006A RID: 106
		public static readonly Color LightGreen = Color.FromBgra(4287688336U);

		// Token: 0x0400006B RID: 107
		public static readonly Color LightPink = Color.FromBgra(4294948545U);

		// Token: 0x0400006C RID: 108
		public static readonly Color LightSalmon = Color.FromBgra(4294942842U);

		// Token: 0x0400006D RID: 109
		public static readonly Color LightSeaGreen = Color.FromBgra(4280332970U);

		// Token: 0x0400006E RID: 110
		public static readonly Color LightSkyBlue = Color.FromBgra(4287090426U);

		// Token: 0x0400006F RID: 111
		public static readonly Color LightSlateGray = Color.FromBgra(4286023833U);

		// Token: 0x04000070 RID: 112
		public static readonly Color LightSteelBlue = Color.FromBgra(4289774814U);

		// Token: 0x04000071 RID: 113
		public static readonly Color LightYellow = Color.FromBgra(4294967264U);

		// Token: 0x04000072 RID: 114
		public static readonly Color Lime = Color.FromBgra(4278255360U);

		// Token: 0x04000073 RID: 115
		public static readonly Color LimeGreen = Color.FromBgra(4281519410U);

		// Token: 0x04000074 RID: 116
		public static readonly Color Linen = Color.FromBgra(4294635750U);

		// Token: 0x04000075 RID: 117
		public static readonly Color Magenta = Color.FromBgra(4294902015U);

		// Token: 0x04000076 RID: 118
		public static readonly Color Maroon = Color.FromBgra(4286578688U);

		// Token: 0x04000077 RID: 119
		public static readonly Color MediumAquamarine = Color.FromBgra(4284927402U);

		// Token: 0x04000078 RID: 120
		public static readonly Color MediumBlue = Color.FromBgra(4278190285U);

		// Token: 0x04000079 RID: 121
		public static readonly Color MediumOrchid = Color.FromBgra(4290401747U);

		// Token: 0x0400007A RID: 122
		public static readonly Color MediumPurple = Color.FromBgra(4287852763U);

		// Token: 0x0400007B RID: 123
		public static readonly Color MediumSeaGreen = Color.FromBgra(4282168177U);

		// Token: 0x0400007C RID: 124
		public static readonly Color MediumSlateBlue = Color.FromBgra(4286277870U);

		// Token: 0x0400007D RID: 125
		public static readonly Color MediumSpringGreen = Color.FromBgra(4278254234U);

		// Token: 0x0400007E RID: 126
		public static readonly Color MediumTurquoise = Color.FromBgra(4282962380U);

		// Token: 0x0400007F RID: 127
		public static readonly Color MediumVioletRed = Color.FromBgra(4291237253U);

		// Token: 0x04000080 RID: 128
		public static readonly Color MidnightBlue = Color.FromBgra(4279834992U);

		// Token: 0x04000081 RID: 129
		public static readonly Color MintCream = Color.FromBgra(4294311930U);

		// Token: 0x04000082 RID: 130
		public static readonly Color MistyRose = Color.FromBgra(4294960353U);

		// Token: 0x04000083 RID: 131
		public static readonly Color Moccasin = Color.FromBgra(4294960309U);

		// Token: 0x04000084 RID: 132
		public static readonly Color NavajoWhite = Color.FromBgra(4294958765U);

		// Token: 0x04000085 RID: 133
		public static readonly Color Navy = Color.FromBgra(4278190208U);

		// Token: 0x04000086 RID: 134
		public static readonly Color OldLace = Color.FromBgra(4294833638U);

		// Token: 0x04000087 RID: 135
		public static readonly Color Olive = Color.FromBgra(4286611456U);

		// Token: 0x04000088 RID: 136
		public static readonly Color OliveDrab = Color.FromBgra(4285238819U);

		// Token: 0x04000089 RID: 137
		public static readonly Color Orange = Color.FromBgra(4294944000U);

		// Token: 0x0400008A RID: 138
		public static readonly Color OrangeRed = Color.FromBgra(4294919424U);

		// Token: 0x0400008B RID: 139
		public static readonly Color Orchid = Color.FromBgra(4292505814U);

		// Token: 0x0400008C RID: 140
		public static readonly Color PaleGoldenrod = Color.FromBgra(4293847210U);

		// Token: 0x0400008D RID: 141
		public static readonly Color PaleGreen = Color.FromBgra(4288215960U);

		// Token: 0x0400008E RID: 142
		public static readonly Color PaleTurquoise = Color.FromBgra(4289720046U);

		// Token: 0x0400008F RID: 143
		public static readonly Color PaleVioletRed = Color.FromBgra(4292571283U);

		// Token: 0x04000090 RID: 144
		public static readonly Color PapayaWhip = Color.FromBgra(4294963157U);

		// Token: 0x04000091 RID: 145
		public static readonly Color PeachPuff = Color.FromBgra(4294957753U);

		// Token: 0x04000092 RID: 146
		public static readonly Color Peru = Color.FromBgra(4291659071U);

		// Token: 0x04000093 RID: 147
		public static readonly Color Pink = Color.FromBgra(4294951115U);

		// Token: 0x04000094 RID: 148
		public static readonly Color Plum = Color.FromBgra(4292714717U);

		// Token: 0x04000095 RID: 149
		public static readonly Color PowderBlue = Color.FromBgra(4289781990U);

		// Token: 0x04000096 RID: 150
		public static readonly Color Purple = Color.FromBgra(4286578816U);

		// Token: 0x04000097 RID: 151
		public static readonly Color Red = Color.FromBgra(4294901760U);

		// Token: 0x04000098 RID: 152
		public static readonly Color RosyBrown = Color.FromBgra(4290547599U);

		// Token: 0x04000099 RID: 153
		public static readonly Color RoyalBlue = Color.FromBgra(4282477025U);

		// Token: 0x0400009A RID: 154
		public static readonly Color SaddleBrown = Color.FromBgra(4287317267U);

		// Token: 0x0400009B RID: 155
		public static readonly Color Salmon = Color.FromBgra(4294606962U);

		// Token: 0x0400009C RID: 156
		public static readonly Color SandyBrown = Color.FromBgra(4294222944U);

		// Token: 0x0400009D RID: 157
		public static readonly Color SeaGreen = Color.FromBgra(4281240407U);

		// Token: 0x0400009E RID: 158
		public static readonly Color SeaShell = Color.FromBgra(4294964718U);

		// Token: 0x0400009F RID: 159
		public static readonly Color Sienna = Color.FromBgra(4288696877U);

		// Token: 0x040000A0 RID: 160
		public static readonly Color Silver = Color.FromBgra(4290822336U);

		// Token: 0x040000A1 RID: 161
		public static readonly Color SkyBlue = Color.FromBgra(4287090411U);

		// Token: 0x040000A2 RID: 162
		public static readonly Color SlateBlue = Color.FromBgra(4285160141U);

		// Token: 0x040000A3 RID: 163
		public static readonly Color SlateGray = Color.FromBgra(4285563024U);

		// Token: 0x040000A4 RID: 164
		public static readonly Color Snow = Color.FromBgra(4294966010U);

		// Token: 0x040000A5 RID: 165
		public static readonly Color SpringGreen = Color.FromBgra(4278255487U);

		// Token: 0x040000A6 RID: 166
		public static readonly Color SteelBlue = Color.FromBgra(4282811060U);

		// Token: 0x040000A7 RID: 167
		public static readonly Color Tan = Color.FromBgra(4291998860U);

		// Token: 0x040000A8 RID: 168
		public static readonly Color Teal = Color.FromBgra(4278222976U);

		// Token: 0x040000A9 RID: 169
		public static readonly Color Thistle = Color.FromBgra(4292394968U);

		// Token: 0x040000AA RID: 170
		public static readonly Color Tomato = Color.FromBgra(4294927175U);

		// Token: 0x040000AB RID: 171
		public static readonly Color Turquoise = Color.FromBgra(4282441936U);

		// Token: 0x040000AC RID: 172
		public static readonly Color Violet = Color.FromBgra(4293821166U);

		// Token: 0x040000AD RID: 173
		public static readonly Color Wheat = Color.FromBgra(4294303411U);

		// Token: 0x040000AE RID: 174
		public static readonly Color White = Color.FromBgra(uint.MaxValue);

		// Token: 0x040000AF RID: 175
		public static readonly Color WhiteSmoke = Color.FromBgra(4294309365U);

		// Token: 0x040000B0 RID: 176
		public static readonly Color Yellow = Color.FromBgra(4294967040U);

		// Token: 0x040000B1 RID: 177
		public static readonly Color YellowGreen = Color.FromBgra(4288335154U);
	}
}
