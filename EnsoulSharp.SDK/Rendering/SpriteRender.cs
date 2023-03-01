using System;
using System.Drawing;
using System.IO;
using EnsoulSharp.SDK.Rendering.Caches;
using EnsoulSharp.SDK.Rendering.Dx11;
using EnsoulSharp.SDK.Rendering.Dx9;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering
{
	// Token: 0x02000095 RID: 149
	public static class SpriteRender
	{
		// Token: 0x0600053F RID: 1343 RVA: 0x00025875 File Offset: 0x00023A75
		static SpriteRender()
		{
			if (Render.Platform == X3DPlatform.Direct3D9)
			{
				SpriteRender.IRender = new D3D9Sprite();
				return;
			}
			SpriteRender.IRender = new D3D11Sprite();
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00025893 File Offset: 0x00023A93
		public static SpriteCache CreateLogo(Bitmap bitmap, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateLogo(bitmap, Scale);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000258A7 File Offset: 0x00023AA7
		public static SpriteCache CreateLogo(byte[] bytes, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateLogo(bytes, Scale);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x000258BB File Offset: 0x00023ABB
		public static SpriteCache CreateLogo(string fileLocation, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateLogo(fileLocation, Scale);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x000258CF File Offset: 0x00023ACF
		public static SpriteCache CreateSprite(Bitmap bitmap, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateSprite(bitmap, Scale);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x000258E3 File Offset: 0x00023AE3
		public static SpriteCache CreateSprite(Stream stream, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateSprite(stream, Scale);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x000258F7 File Offset: 0x00023AF7
		public static SpriteCache CreateSprite(byte[] bytes, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateSprite(bytes, Scale);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0002590B File Offset: 0x00023B0B
		public static SpriteCache CreateSprite(string fileLocation, Vector2 Scale = default(Vector2))
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return null;
			}
			return irender.CreateSprite(fileLocation, Scale);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0002591F File Offset: 0x00023B1F
		public static void Draw(this SpriteCache spriteCache, Vector2 position)
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(spriteCache, position);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00025932 File Offset: 0x00023B32
		public static void Draw(this SpriteCache spriteCache, float x, float y)
		{
			ID3DSprite irender = SpriteRender.IRender;
			if (irender == null)
			{
				return;
			}
			irender.Draw(spriteCache, x, y);
		}

		// Token: 0x040002F4 RID: 756
		private static readonly ID3DSprite IRender;
	}
}
