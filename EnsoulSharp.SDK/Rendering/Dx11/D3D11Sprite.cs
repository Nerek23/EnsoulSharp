using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.WIC;

namespace EnsoulSharp.SDK.Rendering.Dx11
{
	// Token: 0x020000A1 RID: 161
	internal class D3D11Sprite : ID3DSprite
	{
		// Token: 0x06000590 RID: 1424 RVA: 0x00026E94 File Offset: 0x00025094
		public SpriteCache CreateLogo(System.Drawing.Bitmap bitmap, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			SharpDX.Direct2D1.Bitmap value = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)MenuSettings.ContainerHeight * 0.8f,
				originWidth = (float)MenuSettings.ContainerHeight * 0.8f,
				Size = new Vector2((float)MenuSettings.ContainerHeight * 0.8f, (float)MenuSettings.ContainerHeight * 0.8f),
				CacheBitmap = 
				{
					{
						-1,
						value
					}
				}
			};
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00026F20 File Offset: 0x00025120
		public SpriteCache CreateLogo(byte[] bytes, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(new MemoryStream(bytes));
			SharpDX.Direct2D1.Bitmap value = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)MenuSettings.ContainerHeight * 0.8f,
				originWidth = (float)MenuSettings.ContainerHeight * 0.8f,
				Size = new Vector2((float)MenuSettings.ContainerHeight * 0.8f, (float)MenuSettings.ContainerHeight * 0.8f),
				CacheBitmap = 
				{
					{
						-1,
						value
					}
				}
			};
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00026FBC File Offset: 0x000251BC
		public SpriteCache CreateLogo(string fileLocation, Vector2 Scale = default(Vector2))
		{
			if (!File.Exists(fileLocation))
			{
				throw new Exception("file not exist: " + fileLocation);
			}
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(fileLocation);
			SharpDX.Direct2D1.Bitmap value = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)MenuSettings.ContainerHeight * 0.8f,
				originWidth = (float)MenuSettings.ContainerHeight * 0.8f,
				Size = new Vector2((float)MenuSettings.ContainerHeight * 0.8f, (float)MenuSettings.ContainerHeight * 0.8f),
				CacheBitmap = 
				{
					{
						-1,
						value
					}
				}
			};
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00027068 File Offset: 0x00025268
		public SpriteCache CreateSprite(System.Drawing.Bitmap bitmap, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			SharpDX.Direct2D1.Bitmap bitmap2 = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height * Scale.Y,
				originWidth = (float)bitmap.Size.Width * Scale.X,
				Size = new Vector2(bitmap2.Size.Width, bitmap2.Size.Height),
				CacheBitmap = 
				{
					{
						-1,
						bitmap2
					}
				}
			};
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00027104 File Offset: 0x00025304
		public SpriteCache CreateSprite(Stream stream, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream);
			SharpDX.Direct2D1.Bitmap bitmap2 = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height * Scale.Y,
				originWidth = (float)bitmap.Size.Width * Scale.X,
				Size = new Vector2(bitmap2.Size.Width, bitmap2.Size.Height),
				CacheBitmap = 
				{
					{
						-1,
						bitmap2
					}
				}
			};
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000271A8 File Offset: 0x000253A8
		public SpriteCache CreateSprite(byte[] bytes, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(new MemoryStream(bytes));
			SharpDX.Direct2D1.Bitmap bitmap2 = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height * Scale.Y,
				originWidth = (float)bitmap.Size.Width * Scale.X,
				Size = new Vector2(bitmap2.Size.Width, bitmap2.Size.Height),
				CacheBitmap = 
				{
					{
						-1,
						bitmap2
					}
				}
			};
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00027258 File Offset: 0x00025458
		public SpriteCache CreateSprite(string fileLocation, Vector2 Scale = default(Vector2))
		{
			if (!File.Exists(fileLocation))
			{
				throw new Exception("file not exist: " + fileLocation);
			}
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(fileLocation);
			SharpDX.Direct2D1.Bitmap bitmap2 = D3D11Sprite.LoadBitmapFromBitmap(bitmap);
			return new D3D11Sprite.D3D11SpriteCache
			{
				OriginBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height * Scale.Y,
				originWidth = (float)bitmap.Size.Width * Scale.X,
				Size = new Vector2(bitmap2.Size.Width, bitmap2.Size.Height),
				CacheBitmap = 
				{
					{
						-1,
						bitmap2
					}
				}
			};
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00027314 File Offset: 0x00025514
		public void Draw(SpriteCache spriteCache, Vector2 position)
		{
			this.Draw(spriteCache, position.X, position.Y);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0002732C File Offset: 0x0002552C
		public void Draw(SpriteCache spriteCache, float x, float y)
		{
			D3D11Sprite.D3D11SpriteCache d3D11SpriteCache = (D3D11Sprite.D3D11SpriteCache)spriteCache;
			SharpDX.RectangleF value = new SharpDX.RectangleF(x, y, d3D11SpriteCache.originWidth * d3D11SpriteCache.Scale.X, d3D11SpriteCache.originHeight * d3D11SpriteCache.Scale.Y);
			Render.D3D11RenderTarget.DrawBitmap(d3D11SpriteCache.DrawBitmap, value, 0.003921569f * (float)d3D11SpriteCache.Alpha, SharpDX.Direct2D1.BitmapInterpolationMode.Linear);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00027394 File Offset: 0x00025594
		private static SharpDX.Direct2D1.Bitmap LoadBitmapFromBitmap(System.Drawing.Image bitmap)
		{
			ImagingFactory factory = new ImagingFactory();
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			BitmapDecoder bitmapDecoder = new BitmapDecoder(factory, memoryStream, DecodeOptions.CacheOnDemand);
			BitmapFrameDecode frame = bitmapDecoder.GetFrame(0);
			FormatConverter formatConverter = new FormatConverter(factory);
			formatConverter.Initialize(frame, SharpDX.WIC.PixelFormat.Format32bppPRGBA);
			SharpDX.Direct2D1.Bitmap result = SharpDX.Direct2D1.Bitmap.FromWicBitmap(Render.D3D11RenderTarget, formatConverter, new BitmapProperties(new SharpDX.Direct2D1.PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)));
			Utilities.Dispose<FormatConverter>(ref formatConverter);
			Utilities.Dispose<BitmapFrameDecode>(ref frame);
			Utilities.Dispose<BitmapDecoder>(ref bitmapDecoder);
			Utilities.Dispose<MemoryStream>(ref memoryStream);
			Utilities.Dispose<ImagingFactory>(ref factory);
			return result;
		}

		// Token: 0x020004DB RID: 1243
		public class D3D11SpriteCache : SpriteCache
		{
			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x06001685 RID: 5765 RVA: 0x0004E9E1 File Offset: 0x0004CBE1
			// (set) Token: 0x06001686 RID: 5766 RVA: 0x0004E9E9 File Offset: 0x0004CBE9
			public System.Drawing.Bitmap OriginBitmap { get; set; }

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x06001687 RID: 5767 RVA: 0x0004E9F2 File Offset: 0x0004CBF2
			// (set) Token: 0x06001688 RID: 5768 RVA: 0x0004E9FA File Offset: 0x0004CBFA
			public Vector2 Size { get; set; }

			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x06001689 RID: 5769 RVA: 0x0004EA03 File Offset: 0x0004CC03
			public SharpDX.Direct2D1.Bitmap DrawBitmap
			{
				get
				{
					return this.CacheBitmap[this.ColorValue];
				}
			}

			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x0600168A RID: 5770 RVA: 0x0004EA16 File Offset: 0x0004CC16
			// (set) Token: 0x0600168B RID: 5771 RVA: 0x0004EA20 File Offset: 0x0004CC20
			public override ColorBGRA Color
			{
				get
				{
					return this.originColor;
				}
				set
				{
					if (this.originColor.R == value.R && this.originColor.B == value.B && this.originColor.G == value.G)
					{
						return;
					}
					this.originColor = value;
					this.originColor.A = 155;
					if (value.R == 255 && value.G == 255 && value.B == 255)
					{
						this.ColorValue = -1;
						return;
					}
					if (!this.CacheBitmap.ContainsKey(value.ToRgba()))
					{
						SharpDX.Direct2D1.Bitmap value2 = D3D11Sprite.LoadBitmapFromBitmap(this.OriginBitmap.ChangeColor(this.originColor));
						this.CacheBitmap[value.ToRgba()] = value2;
					}
					this.ColorValue = value.ToRgba();
				}
			}

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x0600168C RID: 5772 RVA: 0x0004EAF8 File Offset: 0x0004CCF8
			// (set) Token: 0x0600168D RID: 5773 RVA: 0x0004EB00 File Offset: 0x0004CD00
			public override Vector2 Scale { get; set; } = Vector2.One;

			// Token: 0x0600168E RID: 5774 RVA: 0x0004EB0C File Offset: 0x0004CD0C
			public override void SetSaturation(float saturiation)
			{
				SharpDX.Direct2D1.Bitmap bitmap = D3D11Sprite.LoadBitmapFromBitmap(base.SaturateBitmap((this.Color != SharpDX.Color.White) ? this.OriginBitmap.ChangeColor(this.Color) : this.OriginBitmap, saturiation));
				this.Size = new Vector2(bitmap.Size.Width, bitmap.Size.Height);
				this.CacheBitmap[this.Color.ToRgba()] = bitmap;
			}

			// Token: 0x04000C88 RID: 3208
			private int ColorValue = -1;

			// Token: 0x04000C89 RID: 3209
			private ColorBGRA originColor = SharpDX.Color.White;

			// Token: 0x04000C8A RID: 3210
			public new Dictionary<int, SharpDX.Direct2D1.Bitmap> CacheBitmap = new Dictionary<int, SharpDX.Direct2D1.Bitmap>();
		}
	}
}
