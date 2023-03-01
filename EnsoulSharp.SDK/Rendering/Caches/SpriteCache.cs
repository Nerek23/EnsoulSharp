using System;
using System.Drawing;
using System.Drawing.Imaging;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Caches
{
	// Token: 0x020000A6 RID: 166
	public abstract class SpriteCache
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060005A8 RID: 1448
		// (set) Token: 0x060005A9 RID: 1449
		public abstract ColorBGRA Color { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060005AA RID: 1450
		// (set) Token: 0x060005AB RID: 1451
		public abstract Vector2 Scale { get; set; }

		// Token: 0x060005AC RID: 1452 RVA: 0x00027703 File Offset: 0x00025903
		internal SpriteCache()
		{
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x00027716 File Offset: 0x00025916
		public float Width
		{
			get
			{
				return this.originWidth * this.Scale.X;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x0002772A File Offset: 0x0002592A
		public float Height
		{
			get
			{
				return this.originHeight * this.Scale.Y;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x0002773E File Offset: 0x0002593E
		public Vector3 Center
		{
			get
			{
				return new Vector3(this.Width / 2f, this.Height / 2f, 0f);
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00027762 File Offset: 0x00025962
		public void Complement()
		{
			this.SetSaturation(-1f);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00027770 File Offset: 0x00025970
		public void Crop(int x, int y, int w, int h, bool scale = false)
		{
			this._crop = new SharpDX.Rectangle?(new SharpDX.Rectangle(x, y, w, h));
			if (!scale)
			{
				return;
			}
			this._crop = new SharpDX.Rectangle?(new SharpDX.Rectangle((int)(this.Scale.X * (float)x), (int)(this.Scale.Y * (float)y), (int)(this.Scale.X * (float)w), (int)(this.Scale.Y * (float)h)));
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x000277E4 File Offset: 0x000259E4
		public void Crop(SharpDX.Rectangle rect, bool scale = false)
		{
			this._crop = new SharpDX.Rectangle?(rect);
			if (!scale)
			{
				return;
			}
			this._crop = new SharpDX.Rectangle?(new SharpDX.Rectangle((int)(this.Scale.X * (float)rect.X), (int)(this.Scale.Y * (float)rect.Y), (int)(this.Scale.X * (float)rect.Width), (int)(this.Scale.Y * (float)rect.Height)));
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00027865 File Offset: 0x00025A65
		public void Fade()
		{
			this.SetSaturation(0.5f);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00027872 File Offset: 0x00025A72
		public void GrayScale()
		{
			this.SetSaturation(0f);
		}

		// Token: 0x060005B5 RID: 1461
		public abstract void SetSaturation(float saturiation);

		// Token: 0x060005B6 RID: 1462 RVA: 0x00027880 File Offset: 0x00025A80
		internal Bitmap SaturateBitmap(Image original, float saturation)
		{
			float num = (1f - saturation) * 0.3086f + saturation;
			float num2 = (1f - saturation) * 0.3086f;
			float num3 = (1f - saturation) * 0.3086f;
			float num4 = (1f - saturation) * 0.6094f;
			float num5 = (1f - saturation) * 0.6094f + saturation;
			float num6 = (1f - saturation) * 0.6094f;
			float num7 = (1f - saturation) * 0.082f;
			float num8 = (1f - saturation) * 0.082f;
			float num9 = (1f - saturation) * 0.082f + saturation;
			Bitmap bitmap = new Bitmap(original.Width, original.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			float[][] array = new float[5][];
			int num10 = 0;
			float[] array2 = new float[5];
			array2[0] = num;
			array2[1] = num2;
			array2[2] = num3;
			array[num10] = array2;
			int num11 = 1;
			float[] array3 = new float[5];
			array3[0] = num4;
			array3[1] = num5;
			array3[2] = num6;
			array[num11] = array3;
			int num12 = 2;
			float[] array4 = new float[5];
			array4[0] = num7;
			array4[1] = num8;
			array4[2] = num9;
			array[num12] = array4;
			int num13 = 3;
			float[] array5 = new float[5];
			array5[3] = 1f;
			array[num13] = array5;
			array[4] = new float[]
			{
				0f,
				0f,
				0f,
				0f,
				1f
			};
			ColorMatrix newColorMatrix = new ColorMatrix(array);
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(newColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Default);
			graphics.DrawImage(original, 0, 0, original.Width, original.Height);
			graphics.DrawImage(original, new System.Drawing.Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttributes);
			graphics.Dispose();
			return bitmap;
		}

		// Token: 0x04000303 RID: 771
		internal bool IsRendering;

		// Token: 0x04000304 RID: 772
		internal float originWidth;

		// Token: 0x04000305 RID: 773
		internal float originHeight;

		// Token: 0x04000306 RID: 774
		internal SharpDX.Rectangle? _crop;

		// Token: 0x04000307 RID: 775
		internal Bitmap CacheBitmap;

		// Token: 0x04000308 RID: 776
		public float Rotation;

		// Token: 0x04000309 RID: 777
		public byte Alpha = byte.MaxValue;
	}
}
