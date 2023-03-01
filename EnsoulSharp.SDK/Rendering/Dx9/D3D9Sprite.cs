using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using EnsoulSharp.SDK.MenuUI.Theme;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Dx9
{
	// Token: 0x0200009D RID: 157
	internal class D3D9Sprite : ID3DSprite
	{
		// Token: 0x06000572 RID: 1394 RVA: 0x0002623C File Offset: 0x0002443C
		public D3D9Sprite()
		{
			AppDomain.CurrentDomain.DomainUnload += D3D9Sprite.OnDispose;
			AppDomain.CurrentDomain.ProcessExit += D3D9Sprite.OnDispose;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00026270 File Offset: 0x00024470
		public SpriteCache CreateLogo(Bitmap bitmap, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)MenuSettings.ContainerHeight * 0.8f), (int)((float)MenuSettings.ContainerHeight * 0.8f), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00026324 File Offset: 0x00024524
		public SpriteCache CreateLogo(byte[] bytes, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			Bitmap bitmap = (Bitmap)Image.FromStream(new MemoryStream(bytes));
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)MenuSettings.ContainerHeight * 0.8f), (int)((float)MenuSettings.ContainerHeight * 0.8f), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000263E8 File Offset: 0x000245E8
		public SpriteCache CreateLogo(string fileLocation, Vector2 Scale = default(Vector2))
		{
			if (!File.Exists(fileLocation))
			{
				return null;
			}
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			Bitmap bitmap = new Bitmap(fileLocation);
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)MenuSettings.ContainerHeight * 0.8f), (int)((float)MenuSettings.ContainerHeight * 0.8f), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x000264AC File Offset: 0x000246AC
		public SpriteCache CreateSprite(Bitmap bitmap, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)bitmap.Width * Scale.X), (int)((float)bitmap.Height * Scale.Y), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00026564 File Offset: 0x00024764
		public SpriteCache CreateSprite(Stream stream, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			Bitmap bitmap = new Bitmap(stream);
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)bitmap.Width * Scale.X), (int)((float)bitmap.Height * Scale.Y), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00026624 File Offset: 0x00024824
		public SpriteCache CreateSprite(byte[] bytes, Vector2 Scale = default(Vector2))
		{
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			Bitmap bitmap = (Bitmap)Image.FromStream(new MemoryStream(bytes));
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)bitmap.Width * Scale.X), (int)((float)bitmap.Height * Scale.Y), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000266EC File Offset: 0x000248EC
		public SpriteCache CreateSprite(string fileLocation, Vector2 Scale = default(Vector2))
		{
			if (!File.Exists(fileLocation))
			{
				return null;
			}
			if (!Scale.IsValid())
			{
				Scale = Vector2.One;
			}
			Bitmap bitmap = new Bitmap(fileLocation);
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = new D3D9Sprite.D3D9SpriteCache
			{
				CacheBitmap = bitmap,
				Scale = Scale,
				originHeight = (float)bitmap.Size.Height,
				originWidth = (float)bitmap.Size.Width,
				CacheTexture = Texture.FromMemory(Drawing.Direct3DDevice9, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)((float)bitmap.Width * Scale.X), (int)((float)bitmap.Height * Scale.Y), 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0)
			};
			D3D9Sprite.spriteCaches.Add(d3D9SpriteCache);
			return d3D9SpriteCache;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x000267B4 File Offset: 0x000249B4
		public void Draw(SpriteCache spriteCache, Vector2 position)
		{
			this.Draw(spriteCache, position.X, position.Y);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x000267CC File Offset: 0x000249CC
		public void Draw(SpriteCache spriteCache, float x, float y)
		{
			if (Drawing.Direct3DDevice9 == null || Drawing.Direct3DDevice9.IsDisposed)
			{
				return;
			}
			if (Render.D3D9Sprite == null || Render.D3D9Sprite.IsDisposed)
			{
				return;
			}
			if (spriteCache == null)
			{
				return;
			}
			D3D9Sprite.D3D9SpriteCache d3D9SpriteCache = (D3D9Sprite.D3D9SpriteCache)spriteCache;
			if (d3D9SpriteCache.CacheTexture == null || d3D9SpriteCache.CacheTexture.IsDisposed)
			{
				return;
			}
			if (x == 0f || y == 0f)
			{
				return;
			}
			if (d3D9SpriteCache.IsRendering)
			{
				return;
			}
			d3D9SpriteCache.IsRendering = true;
			RawColorBGRA rawColorBGRA = new RawColorBGRA(d3D9SpriteCache.Color.B, d3D9SpriteCache.Color.G, d3D9SpriteCache.Color.R, d3D9SpriteCache.Alpha);
			Render.D3D9Sprite.Begin(SpriteFlags.AlphaBlend);
			RawMatrix transform = Render.D3D9Sprite.Transform;
			Render.D3D9Sprite.Transform = Matrix.Scaling(d3D9SpriteCache.Scale.X, d3D9SpriteCache.Scale.Y, 0f) * Matrix.RotationZ(d3D9SpriteCache.Rotation) * Matrix.Translation(x, y, 0f);
			Sprite d3D9Sprite = Render.D3D9Sprite;
			Texture cacheTexture = d3D9SpriteCache.CacheTexture;
			RawColorBGRA color = rawColorBGRA;
			SharpDX.Rectangle? rectangle = (d3D9SpriteCache._crop != null) ? new SharpDX.Rectangle?(d3D9SpriteCache._crop.GetValueOrDefault()) : null;
			d3D9Sprite.Draw(cacheTexture, color, (rectangle != null) ? new RawRectangle?(rectangle.GetValueOrDefault()) : null, null, null);
			Render.D3D9Sprite.Transform = transform;
			Render.D3D9Sprite.End();
			d3D9SpriteCache.IsRendering = false;
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0002696C File Offset: 0x00024B6C
		private static void OnDispose(object sender, EventArgs args)
		{
			foreach (D3D9Sprite.D3D9SpriteCache d3D9SpriteCache in D3D9Sprite.spriteCaches)
			{
				if (((d3D9SpriteCache != null) ? d3D9SpriteCache.CacheTexture : null) != null)
				{
					d3D9SpriteCache.CacheTexture.Dispose();
					d3D9SpriteCache.CacheTexture = null;
				}
			}
		}

		// Token: 0x040002FB RID: 763
		private static readonly HashSet<D3D9Sprite.D3D9SpriteCache> spriteCaches = new HashSet<D3D9Sprite.D3D9SpriteCache>();

		// Token: 0x020004D9 RID: 1241
		public class D3D9SpriteCache : SpriteCache
		{
			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x0600167B RID: 5755 RVA: 0x0004E8E2 File Offset: 0x0004CAE2
			// (set) Token: 0x0600167C RID: 5756 RVA: 0x0004E8EA File Offset: 0x0004CAEA
			public override ColorBGRA Color { get; set; } = SharpDX.Color.White;

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x0600167D RID: 5757 RVA: 0x0004E8F3 File Offset: 0x0004CAF3
			// (set) Token: 0x0600167E RID: 5758 RVA: 0x0004E8FB File Offset: 0x0004CAFB
			public override Vector2 Scale { get; set; } = Vector2.One;

			// Token: 0x0600167F RID: 5759 RVA: 0x0004E904 File Offset: 0x0004CB04
			public override void SetSaturation(float saturiation)
			{
				Bitmap bitmap = base.SaturateBitmap(this.CacheBitmap, saturiation);
				Bitmap cacheBitmap = this.CacheBitmap;
				if (cacheBitmap != null)
				{
					cacheBitmap.Dispose();
				}
				this.CacheBitmap = bitmap;
				Texture cacheTexture = this.CacheTexture;
				if (cacheTexture != null)
				{
					cacheTexture.Dispose();
				}
				this.CacheTexture = Texture.FromMemory(Render.D3D9Device, (byte[])new ImageConverter().ConvertTo(bitmap, typeof(byte[])), (int)base.Width, (int)base.Height, 0, Usage.None, Format.A1, Pool.Managed, Filter.Default, Filter.Default, 0);
			}

			// Token: 0x04000C84 RID: 3204
			internal Texture CacheTexture;
		}
	}
}
