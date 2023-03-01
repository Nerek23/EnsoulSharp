using System;
using System.Linq;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Dx11
{
	// Token: 0x0200009F RID: 159
	internal class D3D11Line : ID3DLine
	{
		// Token: 0x06000589 RID: 1417 RVA: 0x00026D08 File Offset: 0x00024F08
		public LineCache CreateLine(float width, bool gllines, bool antialias)
		{
			return new LineCache
			{
				CacheWidth = width,
				CacheGLLines = gllines,
				CacheAntialias = antialias
			};
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00026D24 File Offset: 0x00024F24
		public void Draw(LineCache lineCache, Vector2 startPosition, Vector2 endPosition, Color color, int width = 0)
		{
			if (lineCache == null)
			{
				return;
			}
			if (!lineCache.IsRendering)
			{
				lineCache.IsRendering = true;
				if (width > 0 && (float)width != lineCache.CacheWidth)
				{
					lineCache.CacheWidth = (float)width;
				}
			}
			Render.D3D11RenderTarget.DrawLine(startPosition, endPosition, BrushCache.Get(color), lineCache.CacheWidth);
			lineCache.IsRendering = false;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00026D87 File Offset: 0x00024F87
		public void Draw(LineCache lineCache, Vector3 startPosition, Vector3 endPosition, Color color, int width = 0)
		{
			if (lineCache == null)
			{
				return;
			}
			this.Draw(lineCache, Array.ConvertAll<Vector3, Vector2>(new Vector3[]
			{
				startPosition,
				endPosition
			}, new Converter<Vector3, Vector2>(Drawing.WorldToScreen)), color, (float)width);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00026DC0 File Offset: 0x00024FC0
		public void Draw(LineCache lineCache, Vector2[] positions, Color color, float width = 0f)
		{
			if (lineCache == null || positions.Length < 2)
			{
				return;
			}
			if (!lineCache.IsRendering)
			{
				lineCache.IsRendering = true;
				if (width > 0f && width != lineCache.CacheWidth)
				{
					lineCache.CacheWidth = width;
				}
			}
			Render.D3D11RenderTarget.DrawLine(positions.First<Vector2>(), positions.Last<Vector2>(), BrushCache.Get(color), lineCache.CacheWidth);
			lineCache.IsRendering = false;
		}
	}
}
