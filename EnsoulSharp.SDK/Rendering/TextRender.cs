using System;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Dx11;
using EnsoulSharp.SDK.Rendering.Dx9;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct3D9;

namespace EnsoulSharp.SDK.Rendering
{
	// Token: 0x02000096 RID: 150
	public static class TextRender
	{
		// Token: 0x06000549 RID: 1353 RVA: 0x00025946 File Offset: 0x00023B46
		static TextRender()
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				TextRender.IRender = new D3D9Text();
				return;
			}
			TextRender.IRender = new D3D11Text();
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00025964 File Offset: 0x00023B64
		public static FontCache CreateFont(FontCache.DrawFontDescription fontDescription)
		{
			ID3DText irender = TextRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateFont(fontDescription);
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00025977 File Offset: 0x00023B77
		public static FontCache CreateFont(int height, FontCache.DrawFontWeight weight = FontCache.DrawFontWeight.DoNotCare, string faceName = "Tahoma")
		{
			ID3DText irender = TextRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateFont(height, weight, faceName);
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0002598C File Offset: 0x00023B8C
		public static void Draw(this FontCache fontCache, string text, Vector2 position, Color color, Sprite sprite = null)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("Cant be print null string with Font Draw.");
			}
			ID3DText irender = TextRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(fontCache, text, position, color);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x000259B4 File Offset: 0x00023BB4
		public static void Draw(this FontCache fontCache, string text, int x, int y, Color color, Sprite sprite = null)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("Cant be print null string with Font Draw.");
			}
			ID3DText irender = TextRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(fontCache, text, x, y, color);
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000259DE File Offset: 0x00023BDE
		public static void Draw(this FontCache fontCache, string text, Rectangle rectangle, FontCache.DrawFontFlags fontDrawFlags, Color color, Sprite sprite = null)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("Cant be print null string with Font Draw.");
			}
			ID3DText irender = TextRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(fontCache, text, rectangle, fontDrawFlags, color);
		}

		// Token: 0x040002F5 RID: 757
		private static readonly ID3DText IRender;
	}
}
