using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x0200000A RID: 10
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Color4 : IEquatable<Color4>, IFormattable
	{
		// Token: 0x06000192 RID: 402 RVA: 0x00008B08 File Offset: 0x00006D08
		public Color4(float value)
		{
			this.Blue = value;
			this.Green = value;
			this.Red = value;
			this.Alpha = value;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00008B37 File Offset: 0x00006D37
		public Color4(float red, float green, float blue, float alpha)
		{
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
			this.Alpha = alpha;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00008B56 File Offset: 0x00006D56
		public Color4(Vector4 value)
		{
			this.Red = value.X;
			this.Green = value.Y;
			this.Blue = value.Z;
			this.Alpha = value.W;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00008B88 File Offset: 0x00006D88
		public Color4(Vector3 value, float alpha)
		{
			this.Red = value.X;
			this.Green = value.Y;
			this.Blue = value.Z;
			this.Alpha = alpha;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008BB8 File Offset: 0x00006DB8
		public Color4(uint rgba)
		{
			this.Alpha = (rgba >> 24 & 255U) / 255f;
			this.Blue = (rgba >> 16 & 255U) / 255f;
			this.Green = (rgba >> 8 & 255U) / 255f;
			this.Red = (rgba & 255U) / 255f;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008C24 File Offset: 0x00006E24
		public Color4(int rgba)
		{
			this.Alpha = (float)(rgba >> 24 & 255) / 255f;
			this.Blue = (float)(rgba >> 16 & 255) / 255f;
			this.Green = (float)(rgba >> 8 & 255) / 255f;
			this.Red = (float)(rgba & 255) / 255f;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00008C8C File Offset: 0x00006E8C
		public Color4(float[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Color4.");
			}
			this.Red = values[0];
			this.Green = values[1];
			this.Blue = values[2];
			this.Alpha = values[3];
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00008CE1 File Offset: 0x00006EE1
		public Color4(Color3 color)
		{
			this.Red = color.Red;
			this.Green = color.Green;
			this.Blue = color.Blue;
			this.Alpha = 1f;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00008D12 File Offset: 0x00006F12
		public Color4(Color3 color, float alpha)
		{
			this.Red = color.Red;
			this.Green = color.Green;
			this.Blue = color.Blue;
			this.Alpha = alpha;
		}

		// Token: 0x17000029 RID: 41
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
				case 3:
					return this.Alpha;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Color4 run from 0 to 3, inclusive.");
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
				case 3:
					this.Alpha = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Color4 run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00008DE4 File Offset: 0x00006FE4
		public int ToBgra()
		{
			uint num = (uint)(this.Alpha * 255f) & 255U;
			uint num2 = (uint)(this.Red * 255f) & 255U;
			uint num3 = (uint)(this.Green * 255f) & 255U;
			return (int)(((uint)(this.Blue * 255f) & 255U) | num3 << 8 | num2 << 16 | num << 24);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00008E4E File Offset: 0x0000704E
		public void ToBgra(out byte r, out byte g, out byte b, out byte a)
		{
			a = (byte)(this.Alpha * 255f);
			r = (byte)(this.Red * 255f);
			g = (byte)(this.Green * 255f);
			b = (byte)(this.Blue * 255f);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00008E90 File Offset: 0x00007090
		public int ToRgba()
		{
			uint num = (uint)(this.Alpha * 255f) & 255U;
			int num2 = (int)((uint)(this.Red * 255f) & 255U);
			uint num3 = (uint)(this.Green * 255f) & 255U;
			uint num4 = (uint)(this.Blue * 255f) & 255U;
			return num2 | (int)((int)num3 << 8) | (int)((int)num4 << 16) | (int)((int)num << 24);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00008EFA File Offset: 0x000070FA
		public Vector3 ToVector3()
		{
			return new Vector3(this.Red, this.Green, this.Blue);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00008F13 File Offset: 0x00007113
		public Vector4 ToVector4()
		{
			return new Vector4(this.Red, this.Green, this.Blue, this.Alpha);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00008F32 File Offset: 0x00007132
		public float[] ToArray()
		{
			return new float[]
			{
				this.Red,
				this.Green,
				this.Blue,
				this.Alpha
			};
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00008F60 File Offset: 0x00007160
		public static void Add(ref Color4 left, ref Color4 right, out Color4 result)
		{
			result.Alpha = left.Alpha + right.Alpha;
			result.Red = left.Red + right.Red;
			result.Green = left.Green + right.Green;
			result.Blue = left.Blue + right.Blue;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00008FB9 File Offset: 0x000071B9
		public static Color4 Add(Color4 left, Color4 right)
		{
			return new Color4(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue, left.Alpha + right.Alpha);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00008FF4 File Offset: 0x000071F4
		public static void Subtract(ref Color4 left, ref Color4 right, out Color4 result)
		{
			result.Alpha = left.Alpha - right.Alpha;
			result.Red = left.Red - right.Red;
			result.Green = left.Green - right.Green;
			result.Blue = left.Blue - right.Blue;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000904D File Offset: 0x0000724D
		public static Color4 Subtract(Color4 left, Color4 right)
		{
			return new Color4(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue, left.Alpha - right.Alpha);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00009088 File Offset: 0x00007288
		public static void Modulate(ref Color4 left, ref Color4 right, out Color4 result)
		{
			result.Alpha = left.Alpha * right.Alpha;
			result.Red = left.Red * right.Red;
			result.Green = left.Green * right.Green;
			result.Blue = left.Blue * right.Blue;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000090E1 File Offset: 0x000072E1
		public static Color4 Modulate(Color4 left, Color4 right)
		{
			return new Color4(left.Red * right.Red, left.Green * right.Green, left.Blue * right.Blue, left.Alpha * right.Alpha);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000911C File Offset: 0x0000731C
		public static void Scale(ref Color4 value, float scale, out Color4 result)
		{
			result.Alpha = value.Alpha * scale;
			result.Red = value.Red * scale;
			result.Green = value.Green * scale;
			result.Blue = value.Blue * scale;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00009156 File Offset: 0x00007356
		public static Color4 Scale(Color4 value, float scale)
		{
			return new Color4(value.Red * scale, value.Green * scale, value.Blue * scale, value.Alpha * scale);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00009180 File Offset: 0x00007380
		public static void Negate(ref Color4 value, out Color4 result)
		{
			result.Alpha = 1f - value.Alpha;
			result.Red = 1f - value.Red;
			result.Green = 1f - value.Green;
			result.Blue = 1f - value.Blue;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000091D5 File Offset: 0x000073D5
		public static Color4 Negate(Color4 value)
		{
			return new Color4(1f - value.Red, 1f - value.Green, 1f - value.Blue, 1f - value.Alpha);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000920C File Offset: 0x0000740C
		public static void Clamp(ref Color4 value, ref Color4 min, ref Color4 max, out Color4 result)
		{
			float num = value.Alpha;
			num = ((num > max.Alpha) ? max.Alpha : num);
			num = ((num < min.Alpha) ? min.Alpha : num);
			float num2 = value.Red;
			num2 = ((num2 > max.Red) ? max.Red : num2);
			num2 = ((num2 < min.Red) ? min.Red : num2);
			float num3 = value.Green;
			num3 = ((num3 > max.Green) ? max.Green : num3);
			num3 = ((num3 < min.Green) ? min.Green : num3);
			float num4 = value.Blue;
			num4 = ((num4 > max.Blue) ? max.Blue : num4);
			num4 = ((num4 < min.Blue) ? min.Blue : num4);
			result = new Color4(num2, num3, num4, num);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000092DC File Offset: 0x000074DC
		public static Color4 Clamp(Color4 value, Color4 min, Color4 max)
		{
			Color4 result;
			Color4.Clamp(ref value, ref min, ref max, out result);
			return result;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000092F8 File Offset: 0x000074F8
		public static void Lerp(ref Color4 start, ref Color4 end, float amount, out Color4 result)
		{
			result.Red = MathUtil.Lerp(start.Red, end.Red, amount);
			result.Green = MathUtil.Lerp(start.Green, end.Green, amount);
			result.Blue = MathUtil.Lerp(start.Blue, end.Blue, amount);
			result.Alpha = MathUtil.Lerp(start.Alpha, end.Alpha, amount);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00009368 File Offset: 0x00007568
		public static Color4 Lerp(Color4 start, Color4 end, float amount)
		{
			Color4 result;
			Color4.Lerp(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00009382 File Offset: 0x00007582
		public static void SmoothStep(ref Color4 start, ref Color4 end, float amount, out Color4 result)
		{
			amount = MathUtil.SmoothStep(amount);
			Color4.Lerp(ref start, ref end, amount, out result);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00009398 File Offset: 0x00007598
		public static Color4 SmoothStep(Color4 start, Color4 end, float amount)
		{
			Color4 result;
			Color4.SmoothStep(ref start, ref end, amount, out result);
			return result;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000093B4 File Offset: 0x000075B4
		public static void Max(ref Color4 left, ref Color4 right, out Color4 result)
		{
			result.Alpha = ((left.Alpha > right.Alpha) ? left.Alpha : right.Alpha);
			result.Red = ((left.Red > right.Red) ? left.Red : right.Red);
			result.Green = ((left.Green > right.Green) ? left.Green : right.Green);
			result.Blue = ((left.Blue > right.Blue) ? left.Blue : right.Blue);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000944C File Offset: 0x0000764C
		public static Color4 Max(Color4 left, Color4 right)
		{
			Color4 result;
			Color4.Max(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00009468 File Offset: 0x00007668
		public static void Min(ref Color4 left, ref Color4 right, out Color4 result)
		{
			result.Alpha = ((left.Alpha < right.Alpha) ? left.Alpha : right.Alpha);
			result.Red = ((left.Red < right.Red) ? left.Red : right.Red);
			result.Green = ((left.Green < right.Green) ? left.Green : right.Green);
			result.Blue = ((left.Blue < right.Blue) ? left.Blue : right.Blue);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00009500 File Offset: 0x00007700
		public static Color4 Min(Color4 left, Color4 right)
		{
			Color4 result;
			Color4.Min(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000951C File Offset: 0x0000771C
		public static void AdjustContrast(ref Color4 value, float contrast, out Color4 result)
		{
			result.Alpha = value.Alpha;
			result.Red = 0.5f + contrast * (value.Red - 0.5f);
			result.Green = 0.5f + contrast * (value.Green - 0.5f);
			result.Blue = 0.5f + contrast * (value.Blue - 0.5f);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00009584 File Offset: 0x00007784
		public static Color4 AdjustContrast(Color4 value, float contrast)
		{
			return new Color4(0.5f + contrast * (value.Red - 0.5f), 0.5f + contrast * (value.Green - 0.5f), 0.5f + contrast * (value.Blue - 0.5f), value.Alpha);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000095D8 File Offset: 0x000077D8
		public static void AdjustSaturation(ref Color4 value, float saturation, out Color4 result)
		{
			float num = value.Red * 0.2125f + value.Green * 0.7154f + value.Blue * 0.0721f;
			result.Alpha = value.Alpha;
			result.Red = num + saturation * (value.Red - num);
			result.Green = num + saturation * (value.Green - num);
			result.Blue = num + saturation * (value.Blue - num);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00009650 File Offset: 0x00007850
		public static Color4 AdjustSaturation(Color4 value, float saturation)
		{
			float num = value.Red * 0.2125f + value.Green * 0.7154f + value.Blue * 0.0721f;
			return new Color4(num + saturation * (value.Red - num), num + saturation * (value.Green - num), num + saturation * (value.Blue - num), value.Alpha);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000096B4 File Offset: 0x000078B4
		public static void Premultiply(ref Color4 value, out Color4 result)
		{
			result.Alpha = value.Alpha;
			result.Red = value.Red * value.Alpha;
			result.Green = value.Green * value.Alpha;
			result.Blue = value.Blue * value.Alpha;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00009708 File Offset: 0x00007908
		public static Color4 Premultiply(Color4 value)
		{
			Color4 result;
			Color4.Premultiply(ref value, out result);
			return result;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00008FB9 File Offset: 0x000071B9
		public static Color4 operator +(Color4 left, Color4 right)
		{
			return new Color4(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue, left.Alpha + right.Alpha);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00002505 File Offset: 0x00000705
		public static Color4 operator +(Color4 value)
		{
			return value;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000904D File Offset: 0x0000724D
		public static Color4 operator -(Color4 left, Color4 right)
		{
			return new Color4(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue, left.Alpha - right.Alpha);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000971F File Offset: 0x0000791F
		public static Color4 operator -(Color4 value)
		{
			return new Color4(-value.Red, -value.Green, -value.Blue, -value.Alpha);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00009742 File Offset: 0x00007942
		public static Color4 operator *(float scale, Color4 value)
		{
			return new Color4(value.Red * scale, value.Green * scale, value.Blue * scale, value.Alpha * scale);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00009156 File Offset: 0x00007356
		public static Color4 operator *(Color4 value, float scale)
		{
			return new Color4(value.Red * scale, value.Green * scale, value.Blue * scale, value.Alpha * scale);
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000090E1 File Offset: 0x000072E1
		public static Color4 operator *(Color4 left, Color4 right)
		{
			return new Color4(left.Red * right.Red, left.Green * right.Green, left.Blue * right.Blue, left.Alpha * right.Alpha);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00009769 File Offset: 0x00007969
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Color4 left, Color4 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00009774 File Offset: 0x00007974
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Color4 left, Color4 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00009782 File Offset: 0x00007982
		public static explicit operator Color3(Color4 value)
		{
			return new Color3(value.Red, value.Green, value.Blue);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00008EFA File Offset: 0x000070FA
		public static explicit operator Vector3(Color4 value)
		{
			return new Vector3(value.Red, value.Green, value.Blue);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00008F13 File Offset: 0x00007113
		public static implicit operator Vector4(Color4 value)
		{
			return new Vector4(value.Red, value.Green, value.Blue, value.Alpha);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000979B File Offset: 0x0000799B
		public static explicit operator Color4(Vector3 value)
		{
			return new Color4(value.X, value.Y, value.Z, 1f);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000097B9 File Offset: 0x000079B9
		public static explicit operator Color4(Vector4 value)
		{
			return new Color4(value.X, value.Y, value.Z, value.W);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000097D8 File Offset: 0x000079D8
		public static explicit operator Color4(ColorBGRA value)
		{
			return new Color4((float)value.R, (float)value.G, (float)value.B, (float)value.A);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000097FB File Offset: 0x000079FB
		public static explicit operator ColorBGRA(Color4 value)
		{
			return new ColorBGRA(value.Red, value.Green, value.Blue, value.Alpha);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000981A File Offset: 0x00007A1A
		public static explicit operator int(Color4 value)
		{
			return value.ToRgba();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00009823 File Offset: 0x00007A23
		public static explicit operator Color4(int value)
		{
			return new Color4(value);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000982B File Offset: 0x00007A2B
		public override string ToString()
		{
			return this.ToString(CultureInfo.CurrentCulture);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00009838 File Offset: 0x00007A38
		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.CurrentCulture);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00009848 File Offset: 0x00007A48
		public string ToString(IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", new object[]
			{
				this.Alpha,
				this.Red,
				this.Green,
				this.Blue
			});
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000098A0 File Offset: 0x00007AA0
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (format == null)
			{
				return this.ToString(formatProvider);
			}
			return string.Format(formatProvider, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", new object[]
			{
				this.Alpha.ToString(format, formatProvider),
				this.Red.ToString(format, formatProvider),
				this.Green.ToString(format, formatProvider),
				this.Blue.ToString(format, formatProvider)
			});
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000990C File Offset: 0x00007B0C
		public override int GetHashCode()
		{
			return ((this.Red.GetHashCode() * 397 ^ this.Green.GetHashCode()) * 397 ^ this.Blue.GetHashCode()) * 397 ^ this.Alpha.GetHashCode();
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000995A File Offset: 0x00007B5A
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Color4 other)
		{
			return this.Alpha == other.Alpha && this.Red == other.Red && this.Green == other.Green && this.Blue == other.Blue;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00009996 File Offset: 0x00007B96
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Color4 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x000099A0 File Offset: 0x00007BA0
		public override bool Equals(object value)
		{
			if (!(value is Color4))
			{
				return false;
			}
			Color4 color = (Color4)value;
			return this.Equals(ref color);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000099C6 File Offset: 0x00007BC6
		public unsafe static implicit operator RawColor4(Color4 value)
		{
			return *(RawColor4*)(&value);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000099D0 File Offset: 0x00007BD0
		public unsafe static implicit operator Color4(RawColor4 value)
		{
			return *(Color4*)(&value);
		}

		// Token: 0x040000B8 RID: 184
		private const string toStringFormat = "Alpha:{0} Red:{1} Green:{2} Blue:{3}";

		// Token: 0x040000B9 RID: 185
		public static readonly Color4 Black = new Color4(0f, 0f, 0f, 1f);

		// Token: 0x040000BA RID: 186
		public static readonly Color4 White = new Color4(1f, 1f, 1f, 1f);

		// Token: 0x040000BB RID: 187
		public float Red;

		// Token: 0x040000BC RID: 188
		public float Green;

		// Token: 0x040000BD RID: 189
		public float Blue;

		// Token: 0x040000BE RID: 190
		public float Alpha;
	}
}
