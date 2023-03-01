using System;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Interfaces
{
	// Token: 0x0200009A RID: 154
	internal interface ID3DText
	{
		// Token: 0x0600055D RID: 1373
		FontCache CreateFont(FontCache.DrawFontDescription fontDescription);

		// Token: 0x0600055E RID: 1374
		FontCache CreateFont(int height, FontCache.DrawFontWeight weight = FontCache.DrawFontWeight.DoNotCare, string faceName = "Tahoma");

		// Token: 0x0600055F RID: 1375
		void Draw(FontCache fontCache, string text, Vector2 position, Color color);

		// Token: 0x06000560 RID: 1376
		void Draw(FontCache fontCache, string text, int x, int y, Color color);

		// Token: 0x06000561 RID: 1377
		void Draw(FontCache fontCache, string text, Rectangle rectangle, FontCache.DrawFontFlags fontDrawFlags, Color color);
	}
}
