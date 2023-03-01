using System;
using System.Collections.Generic;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Caches
{
	// Token: 0x020000A3 RID: 163
	public static class BrushCache
	{
		// Token: 0x060005A0 RID: 1440 RVA: 0x00027600 File Offset: 0x00025800
		public static SolidColorBrush Get(Color color)
		{
			int key = color.ToRgba();
			if (BrushCache.bushCaches.ContainsKey(key))
			{
				return BrushCache.bushCaches[key];
			}
			SolidColorBrush solidColorBrush = new SolidColorBrush(Render.D3D11RenderTarget, new RawColor4((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f));
			BrushCache.bushCaches.Add(key, solidColorBrush);
			return solidColorBrush;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00027680 File Offset: 0x00025880
		public static void OnDispose()
		{
			foreach (SolidColorBrush solidColorBrush in BrushCache.bushCaches.Values)
			{
				if (!solidColorBrush.IsDisposed)
				{
					solidColorBrush.Dispose();
				}
			}
		}

		// Token: 0x040002FD RID: 765
		private static readonly Dictionary<int, SolidColorBrush> bushCaches = new Dictionary<int, SolidColorBrush>();
	}
}
