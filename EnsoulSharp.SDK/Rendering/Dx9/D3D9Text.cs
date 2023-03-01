using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Dx9
{
	// Token: 0x0200009E RID: 158
	internal class D3D9Text : ID3DText
	{
		// Token: 0x0600057E RID: 1406 RVA: 0x000269E4 File Offset: 0x00024BE4
		public D3D9Text()
		{
			Render.OnPreReset += D3D9Text.OnPreReset;
			Render.OnPostReset += D3D9Text.OnPostReset;
			AppDomain.CurrentDomain.DomainUnload += D3D9Text.OnDispose;
			AppDomain.CurrentDomain.ProcessExit += D3D9Text.OnDispose;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00026A48 File Offset: 0x00024C48
		public FontCache CreateFont(FontCache.DrawFontDescription fontDescription)
		{
			D3D9Text.D3D9FontCache d3D9FontCache = new D3D9Text.D3D9FontCache(fontDescription)
			{
				CacheFont = new Font(Drawing.Direct3DDevice9, new FontDescription
				{
					Height = fontDescription.Height,
					Width = fontDescription.Width,
					FaceName = fontDescription.FaceName,
					Weight = (FontWeight)fontDescription.Weight,
					MipLevels = fontDescription.MipLevels,
					Italic = fontDescription.Italic,
					CharacterSet = fontDescription.CharacterSet,
					OutputPrecision = fontDescription.OutputPrecision,
					PitchAndFamily = fontDescription.PitchAndFamily,
					Quality = fontDescription.Quality
				})
			};
			D3D9Text.FontCaches.Add(d3D9FontCache);
			return d3D9FontCache;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00026B04 File Offset: 0x00024D04
		public FontCache CreateFont(int height, FontCache.DrawFontWeight weight = FontCache.DrawFontWeight.DoNotCare, string faceName = "Tahoma")
		{
			return this.CreateFont(new FontCache.DrawFontDescription
			{
				Height = height,
				Weight = weight,
				FaceName = faceName
			});
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00026B26 File Offset: 0x00024D26
		public void Draw(FontCache fontCache, string text, Vector2 position, Color color)
		{
			if (fontCache == null)
			{
				return;
			}
			((D3D9Text.D3D9FontCache)fontCache).CacheFont.DrawText(null, text, (int)position.X, (int)position.Y, color);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00026B54 File Offset: 0x00024D54
		public void Draw(FontCache fontCache, string text, int x, int y, Color color)
		{
			if (fontCache == null)
			{
				return;
			}
			((D3D9Text.D3D9FontCache)fontCache).CacheFont.DrawText(null, text, x, y, color);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00026B77 File Offset: 0x00024D77
		public void Draw(FontCache fontCache, string text, Rectangle rectangle, FontCache.DrawFontFlags fontDrawFlags, Color color)
		{
			if (fontCache == null)
			{
				return;
			}
			((D3D9Text.D3D9FontCache)fontCache).CacheFont.DrawText(null, text, rectangle, (FontDrawFlags)fontDrawFlags, color);
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00026BA0 File Offset: 0x00024DA0
		private static void OnPreReset(EventArgs args)
		{
			foreach (D3D9Text.D3D9FontCache d3D9FontCache in D3D9Text.FontCaches)
			{
				if (((d3D9FontCache != null) ? d3D9FontCache.CacheFont : null) != null && !d3D9FontCache.CacheFont.IsDisposed)
				{
					d3D9FontCache.CacheFont.OnLostDevice();
				}
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00026C14 File Offset: 0x00024E14
		private static void OnPostReset(EventArgs args)
		{
			foreach (D3D9Text.D3D9FontCache d3D9FontCache in D3D9Text.FontCaches)
			{
				if (((d3D9FontCache != null) ? d3D9FontCache.CacheFont : null) != null && !d3D9FontCache.CacheFont.IsDisposed)
				{
					d3D9FontCache.CacheFont.OnResetDevice();
				}
			}
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00026C88 File Offset: 0x00024E88
		private static void OnDispose(object sender, EventArgs args)
		{
			foreach (D3D9Text.D3D9FontCache d3D9FontCache in D3D9Text.FontCaches)
			{
				if (((d3D9FontCache != null) ? d3D9FontCache.CacheFont : null) != null)
				{
					d3D9FontCache.CacheFont.Dispose();
					d3D9FontCache.CacheFont = null;
				}
			}
		}

		// Token: 0x040002FC RID: 764
		private static readonly HashSet<D3D9Text.D3D9FontCache> FontCaches = new HashSet<D3D9Text.D3D9FontCache>();

		// Token: 0x020004DA RID: 1242
		public class D3D9FontCache : FontCache
		{
			// Token: 0x06001681 RID: 5761 RVA: 0x0004E9AB File Offset: 0x0004CBAB
			public D3D9FontCache(FontCache.DrawFontDescription fontDescription) : base(fontDescription)
			{
			}

			// Token: 0x06001682 RID: 5762 RVA: 0x0004E9B4 File Offset: 0x0004CBB4
			public override RawRectangle MeasureText(string text, FontCache.DrawFontFlags fontDrawFlags)
			{
				return this.MeasureText(null, text, fontDrawFlags);
			}

			// Token: 0x06001683 RID: 5763 RVA: 0x0004E9BF File Offset: 0x0004CBBF
			public override RawRectangle MeasureText(Sprite sprite, string text, FontCache.DrawFontFlags fontDrawFlags)
			{
				return this.CacheFont.MeasureText(sprite, text, (FontDrawFlags)fontDrawFlags);
			}

			// Token: 0x06001684 RID: 5764 RVA: 0x0004E9CF File Offset: 0x0004CBCF
			public override void Dispose()
			{
				Font cacheFont = this.CacheFont;
				if (cacheFont == null)
				{
					return;
				}
				cacheFont.Dispose();
			}

			// Token: 0x04000C87 RID: 3207
			public Font CacheFont;
		}
	}
}
