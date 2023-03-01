using System;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering
{
	// Token: 0x02000092 RID: 146
	public static class CircleRender
	{
		// Token: 0x06000536 RID: 1334 RVA: 0x000255F5 File Offset: 0x000237F5
		public static void Draw(Vector3 position, float radius, Color color, int width = 5, bool zDeep = false)
		{
			Drawing.DrawCircle(position, radius, (float)width, color.ToSystemColor());
		}
	}
}
