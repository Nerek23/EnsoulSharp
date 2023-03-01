using System;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Interfaces
{
	// Token: 0x02000098 RID: 152
	internal interface ID3DRectangle
	{
		// Token: 0x06000553 RID: 1363
		void Draw(Vector2 position, float width, float height, float borderWidth, Color color, Color borderColor);
	}
}
