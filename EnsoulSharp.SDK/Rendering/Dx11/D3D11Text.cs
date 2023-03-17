using System;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Dx11
{
	// Token: 0x020000A2 RID: 162
	internal class D3D11Text : ID3DText
	{
		// Token: 0x0600059B RID: 1435 RVA: 0x00027422 File Offset: 0x00025622
		public FontCache CreateFont(FontCache.DrawFontDescription fontDescription)
		{
			return new D3D11Text.D3D11FontCache(fontDescription)
			{
				TextFormat = new TextFormat(Render.DirectWriteFactory, fontDescription.FaceName, (SharpDX.DirectWrite.FontWeight)fontDescription.Weight, fontDescription.Italic ? FontStyle.Italic : FontStyle.Normal, (float)fontDescription.Height)
			};
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0002745E File Offset: 0x0002565E
		public FontCache CreateFont(int height, FontCache.DrawFontWeight weight = FontCache.DrawFontWeight.DoNotCare, string faceName = "Tahoma")
		{
			return this.CreateFont(new FontCache.DrawFontDescription
			{
				Height = height,
				Weight = weight,
				FaceName = faceName
			});
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00027480 File Offset: 0x00025680
		public void Draw(FontCache fontCache, string text, Vector2 position, Color color)
		{
			if (fontCache == null)
			{
				return;
			}
			D3D11Text.D3D11FontCache d3D11FontCache = (D3D11Text.D3D11FontCache)fontCache;
			Render.D3D11RenderTarget.DrawText(text, d3D11FontCache.TextFormat, new RawRectangleF(position.X, position.Y, Render.D3D11RenderTarget.Size.Width, Render.D3D11RenderTarget.Size.Height), BrushCache.Get(color));
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x000274E0 File Offset: 0x000256E0
		public void Draw(FontCache fontCache, string text, int x, int y, Color color)
		{
			if (fontCache == null)
			{
				return;
			}
			D3D11Text.D3D11FontCache d3D11FontCache = (D3D11Text.D3D11FontCache)fontCache;
			Render.D3D11RenderTarget.DrawText(text, d3D11FontCache.TextFormat, new RawRectangleF((float)x, (float)y, Render.D3D11RenderTarget.Size.Width, Render.D3D11RenderTarget.Size.Height), BrushCache.Get(color));
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00027538 File Offset: 0x00025738
		public void Draw(FontCache fontCache, string text, Rectangle rectangle, FontCache.DrawFontFlags fontDrawFlags, Color color)
		{
			if (fontCache == null)
			{
				return;
			}
			D3D11Text.D3D11FontCache d3D11FontCache = (D3D11Text.D3D11FontCache)fontCache;
			d3D11FontCache.TextFormat.WordWrapping = WordWrapping.NoWrap;
			if ((fontDrawFlags & FontCache.DrawFontFlags.Center) == FontCache.DrawFontFlags.Center)
			{
				d3D11FontCache.TextFormat.TextAlignment = TextAlignment.Center;
			}
			else if ((fontDrawFlags & FontCache.DrawFontFlags.Right) == FontCache.DrawFontFlags.Right)
			{
				d3D11FontCache.TextFormat.TextAlignment = TextAlignment.Trailing;
			}
			else
			{
				d3D11FontCache.TextFormat.TextAlignment = TextAlignment.Leading;
			}
			if ((fontDrawFlags & FontCache.DrawFontFlags.VerticalCenter) == FontCache.DrawFontFlags.VerticalCenter)
			{
				rectangle.Y += rectangle.Height / 2 - (int)((float)fontCache.FontDescription.Height * 0.6f);
			}
			Render.D3D11RenderTarget.DrawText(text, d3D11FontCache.TextFormat, new RawRectangleF((float)rectangle.Left, (float)rectangle.Top, (float)rectangle.Right, (float)rectangle.Bottom), BrushCache.Get(color));
		}

		// Token: 0x020004DC RID: 1244
		public class D3D11FontCache : FontCache
		{
			// Token: 0x06001690 RID: 5776 RVA: 0x0004EBC6 File Offset: 0x0004CDC6
			public D3D11FontCache(FontCache.DrawFontDescription fontDescription) : base(fontDescription)
			{
			}

			// Token: 0x06001691 RID: 5777 RVA: 0x0004EBD0 File Offset: 0x0004CDD0
			public override RawRectangle MeasureText(string text, FontCache.DrawFontFlags fontDrawFlags)
			{
				TextLayout textLayout = new TextLayout(Render.DirectWriteFactory, text, this.TextFormat, Render.D3D11RenderTarget.Size.Width, Render.D3D11RenderTarget.Size.Height);
				TextMetrics metrics = textLayout.Metrics;
				RawRectangle result = new RawRectangle((int)metrics.Left, (int)metrics.Top, (int)metrics.Width, (int)metrics.Height);
				Utilities.Dispose<TextLayout>(ref textLayout);
				return result;
			}

			// Token: 0x06001692 RID: 5778 RVA: 0x0004EC3C File Offset: 0x0004CE3C
			public override RawRectangle MeasureText(Sprite sprite, string text, FontCache.DrawFontFlags fontDrawFlags)
			{
				return this.MeasureText(text, fontDrawFlags);
			}

			// Token: 0x06001693 RID: 5779 RVA: 0x0004EC46 File Offset: 0x0004CE46
			public override void Dispose()
			{
			}

			// Token: 0x04000C8D RID: 3213
			public TextFormat TextFormat;
		}
	}
}
