using System;
using System.Collections.Generic;
using System.Drawing;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x02000082 RID: 130
	public static class MiniMap
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x00024668 File Offset: 0x00022868
		public static void DrawCircle(Vector3 center, float radius, System.Drawing.Color color, int thickness = 1)
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < 20; i++)
			{
				double num = (double)i * 3.141592653589793 * 2.0 / 20.0;
				Vector3 worldCoord = new Vector3(center.X + radius * (float)Math.Cos(num), center.Y + radius * (float)Math.Sin(num), center.Z);
				list.Add(Drawing.WorldToMinimap(worldCoord));
			}
			for (int j = 0; j < list.Count; j++)
			{
				Vector2 vector = list[j];
				Vector2 vector2 = list[(j == list.Count - 1) ? 0 : (j + 1)];
				if (vector.IsOnMiniMap(0f) && vector2.IsOnMiniMap(0f))
				{
					MiniMap.cacheLine.Draw(vector, vector2, color.ToSharpDxColor(), thickness);
				}
			}
		}

		// Token: 0x040002B2 RID: 690
		private static readonly LineCache cacheLine = LineRender.CreateLine(1f, false, false);
	}
}
