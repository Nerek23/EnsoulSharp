using System;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Interfaces
{
	// Token: 0x02000097 RID: 151
	internal interface ID3DLine
	{
		// Token: 0x0600054F RID: 1359
		LineCache CreateLine(float width, bool gllines, bool antialias);

		// Token: 0x06000550 RID: 1360
		void Draw(LineCache lineCache, Vector2 startPosition, Vector2 endPosition, Color color, int width = 0);

		// Token: 0x06000551 RID: 1361
		void Draw(LineCache lineCache, Vector3 startPosition, Vector3 endPosition, Color color, int width = 0);

		// Token: 0x06000552 RID: 1362
		void Draw(LineCache lineCache, Vector2[] positions, Color color, float width = 0f);
	}
}
