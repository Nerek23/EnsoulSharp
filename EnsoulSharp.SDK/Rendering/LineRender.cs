using System;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Dx11;
using EnsoulSharp.SDK.Rendering.Dx9;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering
{
	// Token: 0x02000094 RID: 148
	public static class LineRender
	{
		// Token: 0x0600053B RID: 1339 RVA: 0x00025801 File Offset: 0x00023A01
		static LineRender()
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				LineRender.IRender = new D3D9Line();
				return;
			}
			LineRender.IRender = new D3D11Line();
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0002581F File Offset: 0x00023A1F
		public static LineCache CreateLine(float width, bool gllines, bool antialias)
		{
			ID3DLine irender = LineRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateLine(width, gllines, antialias);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00025834 File Offset: 0x00023A34
		public static void Draw(this LineCache lineCache, Vector2 startPosition, Vector2 endPosition, Color color, int width = 0)
		{
			ID3DLine irender = LineRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(lineCache, new Vector2[]
			{
				startPosition,
				endPosition
			}, color, (float)width);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00025860 File Offset: 0x00023A60
		public static void Draw(this LineCache lineCache, Vector2[] positions, Color color, float width = 0f)
		{
			ID3DLine irender = LineRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(lineCache, positions, color, width);
		}

		// Token: 0x040002F3 RID: 755
		private static readonly ID3DLine IRender;
	}
}
