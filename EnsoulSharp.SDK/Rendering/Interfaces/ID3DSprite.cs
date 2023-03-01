using System;
using System.Drawing;
using System.IO;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering.Interfaces
{
	// Token: 0x02000099 RID: 153
	internal interface ID3DSprite
	{
		// Token: 0x06000554 RID: 1364
		SpriteCache CreateLogo(Bitmap bitmap, Vector2 Scale = default(Vector2));

		// Token: 0x06000555 RID: 1365
		SpriteCache CreateLogo(byte[] bytes, Vector2 Scale = default(Vector2));

		// Token: 0x06000556 RID: 1366
		SpriteCache CreateLogo(string fileLocation, Vector2 Scale = default(Vector2));

		// Token: 0x06000557 RID: 1367
		SpriteCache CreateSprite(Bitmap bitmap, Vector2 Scale = default(Vector2));

		// Token: 0x06000558 RID: 1368
		SpriteCache CreateSprite(Stream stream, Vector2 Scale = default(Vector2));

		// Token: 0x06000559 RID: 1369
		SpriteCache CreateSprite(byte[] bytes, Vector2 Scale = default(Vector2));

		// Token: 0x0600055A RID: 1370
		SpriteCache CreateSprite(string fileLocation, Vector2 Scale = default(Vector2));

		// Token: 0x0600055B RID: 1371
		void Draw(SpriteCache spriteCache, Vector2 position);

		// Token: 0x0600055C RID: 1372
		void Draw(SpriteCache spriteCache, float x, float y);
	}
}
