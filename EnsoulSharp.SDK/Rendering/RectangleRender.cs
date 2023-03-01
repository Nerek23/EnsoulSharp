using System;
using EnsoulSharp.SDK.Rendering.Dx11;
using EnsoulSharp.SDK.Rendering.Dx9;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering
{
	// Token: 0x02000091 RID: 145
	public static class RectangleRender
	{
		// Token: 0x06000534 RID: 1332 RVA: 0x000255BE File Offset: 0x000237BE
		static RectangleRender()
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				RectangleRender.IRender = new D3D9Rectangle();
				return;
			}
			RectangleRender.IRender = new D3D11Rectangle();
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x000255DC File Offset: 0x000237DC
		public static void Draw(Vector2 position, float width, float height, float borderWidth, Color color, Color borderColor)
		{
			ID3DRectangle irender = RectangleRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(position, width, height, borderWidth, color, borderColor);
		}

		// Token: 0x040002EB RID: 747
		private static readonly ID3DRectangle IRender;
	}
}
