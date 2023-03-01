using System;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Dx11
{
	// Token: 0x020000A0 RID: 160
	internal class D3D11Rectangle : ID3DRectangle
	{
		// Token: 0x0600058E RID: 1422 RVA: 0x00026E3C File Offset: 0x0002503C
		public void Draw(Vector2 position, float width, float height, float borderWidth, Color color, Color borderColor)
		{
			RectangleF value = new RectangleF(position.X, position.Y, width, height);
			Render.D3D11RenderTarget.FillRectangle(value, BrushCache.Get(color));
			Render.D3D11RenderTarget.DrawRectangle(value, BrushCache.Get(borderColor));
		}
	}
}
