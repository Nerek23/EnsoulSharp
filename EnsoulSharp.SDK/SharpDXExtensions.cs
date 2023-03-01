using System;
using System.Drawing;
using System.Drawing.Imaging;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000058 RID: 88
	public static class SharpDXExtensions
	{
		// Token: 0x06000364 RID: 868 RVA: 0x00019630 File Offset: 0x00017830
		public static int ToArgb(this SharpDX.Color color)
		{
			int num = color.ToRgba();
			return (int)(((long)num & (long)((ulong)-16777216)) >> 8) | (num & 16711680) >> 8 | (num & 65280) >> 8 | (num & 255) << 24;
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00019670 File Offset: 0x00017870
		public static string ToHex(this SharpDX.Color color)
		{
			return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000196B0 File Offset: 0x000178B0
		public static string ToHex(this System.Drawing.Color color)
		{
			return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00019704 File Offset: 0x00017904
		public static int ToRgba(this System.Drawing.Color color)
		{
			int num = color.ToArgb();
			return (int)(((long)num & (long)((ulong)-16777216)) >> 24) | (num & 16711680) << 8 | (num & 65280) << 8 | (num & 255) << 8;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00019744 File Offset: 0x00017944
		public static SharpDX.Color ToSharpDxColor(this System.Drawing.Color color)
		{
			return new SharpDX.Color(color.R, color.G, color.B, color.A);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00019767 File Offset: 0x00017967
		public static System.Drawing.Color ToSystemColor(this SharpDX.Color color)
		{
			return System.Drawing.Color.FromArgb((int)color.A, (int)color.R, (int)color.G, (int)color.B);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00019786 File Offset: 0x00017986
		public static System.Drawing.Color ToSystemColor(this ColorBGRA color)
		{
			return System.Drawing.Color.FromArgb((int)color.A, (int)color.R, (int)color.G, (int)color.B);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x000197A8 File Offset: 0x000179A8
		public static Bitmap ChangeColor(this Bitmap bitmap, ColorBGRA color)
		{
			Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap2))
			{
				float num = (float)color.R / 255f;
				float num2 = (float)color.G / 255f;
				float num3 = (float)color.B / 255f;
				float num4 = (float)color.A / 255f;
				graphics.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
				float[][] array = new float[5][];
				array[0] = new float[5];
				array[1] = new float[5];
				array[2] = new float[5];
				int num5 = 3;
				float[] array2 = new float[5];
				array2[3] = num4;
				array[num5] = array2;
				array[4] = new float[]
				{
					num,
					num2,
					num3,
					0f,
					1f
				};
				ColorMatrix colorMatrix = new ColorMatrix(array);
				ImageAttributes imageAttributes = new ImageAttributes();
				imageAttributes.SetColorMatrix(colorMatrix);
				graphics.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
				imageAttributes.Dispose();
				graphics.Dispose();
			}
			return bitmap2;
		}
	}
}
