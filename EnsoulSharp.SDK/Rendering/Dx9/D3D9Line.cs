using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Dx9
{
	// Token: 0x0200009B RID: 155
	internal class D3D9Line : ID3DLine
	{
		// Token: 0x06000562 RID: 1378 RVA: 0x00025A08 File Offset: 0x00023C08
		public D3D9Line()
		{
			Render.OnPreReset += D3D9Line.OnPreReset;
			Render.OnPostReset += D3D9Line.OnPostReset;
			AppDomain.CurrentDomain.DomainUnload += D3D9Line.OnDispose;
			AppDomain.CurrentDomain.ProcessExit += D3D9Line.OnDispose;
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00025A6C File Offset: 0x00023C6C
		public LineCache CreateLine(float width, bool gllines, bool antialias)
		{
			D3D9Line.D3D9LineCache d3D9LineCache = new D3D9Line.D3D9LineCache
			{
				CacheWidth = width,
				CacheGLLines = gllines,
				CacheAntialias = antialias,
				CacheLine = new Line(Drawing.Direct3DDevice9)
				{
					Width = width,
					GLLines = gllines,
					Antialias = antialias
				}
			};
			D3D9Line.lineCaches.Add(d3D9LineCache);
			return d3D9LineCache;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00025AD0 File Offset: 0x00023CD0
		public void Draw(LineCache lineCache, Vector2 startPosition, Vector2 endPosition, Color color, int width = 0)
		{
			if (lineCache == null)
			{
				return;
			}
			this.Draw(lineCache, new Vector2[]
			{
				startPosition,
				endPosition
			}, color, (float)width);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00025AF8 File Offset: 0x00023CF8
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

		// Token: 0x06000566 RID: 1382 RVA: 0x00025B34 File Offset: 0x00023D34
		public void Draw(LineCache lineCache, Vector2[] positions, Color color, float width = 0f)
		{
			if (lineCache == null || positions.Length < 2)
			{
				return;
			}
			D3D9Line.D3D9LineCache d3D9LineCache = (D3D9Line.D3D9LineCache)lineCache;
			if (!d3D9LineCache.IsRendering)
			{
				d3D9LineCache.IsRendering = true;
				if (width > 0f && width != d3D9LineCache.CacheWidth)
				{
					d3D9LineCache.CacheLine.Width = width;
					d3D9LineCache.CacheWidth = width;
				}
				d3D9LineCache.CacheLine.Begin();
			}
			try
			{
				d3D9LineCache.CacheLine.Draw(Array.ConvertAll<Vector2, RawVector2>(positions, (Vector2 v) => v.ToRawVector2()), color);
			}
			finally
			{
				d3D9LineCache.CacheLine.End();
				d3D9LineCache.IsRendering = false;
			}
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00025BF0 File Offset: 0x00023DF0
		private static void OnPreReset(EventArgs args)
		{
			foreach (D3D9Line.D3D9LineCache d3D9LineCache in D3D9Line.lineCaches)
			{
				if (d3D9LineCache != null)
				{
					Line cacheLine = d3D9LineCache.CacheLine;
					if (cacheLine != null)
					{
						cacheLine.OnLostDevice();
					}
				}
			}
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00025C50 File Offset: 0x00023E50
		private static void OnPostReset(EventArgs args)
		{
			foreach (D3D9Line.D3D9LineCache d3D9LineCache in D3D9Line.lineCaches)
			{
				if (d3D9LineCache != null)
				{
					Line cacheLine = d3D9LineCache.CacheLine;
					if (cacheLine != null)
					{
						cacheLine.OnResetDevice();
					}
				}
			}
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00025CB0 File Offset: 0x00023EB0
		private static void OnDispose(object sender, EventArgs args)
		{
			foreach (D3D9Line.D3D9LineCache d3D9LineCache in D3D9Line.lineCaches)
			{
				if (((d3D9LineCache != null) ? d3D9LineCache.CacheLine : null) != null)
				{
					d3D9LineCache.CacheLine.Dispose();
					d3D9LineCache.CacheLine = null;
				}
			}
		}

		// Token: 0x040002F6 RID: 758
		private static readonly HashSet<D3D9Line.D3D9LineCache> lineCaches = new HashSet<D3D9Line.D3D9LineCache>();

		// Token: 0x020004D7 RID: 1239
		public class D3D9LineCache : LineCache
		{
			// Token: 0x04000C81 RID: 3201
			public Line CacheLine;
		}
	}
}
