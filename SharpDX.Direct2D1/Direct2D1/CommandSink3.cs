using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200018B RID: 395
	[Guid("18079135-4cf3-4868-bc8e-06067e6d242d")]
	public interface CommandSink3 : CommandSink2, CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600076D RID: 1901
		void DrawSpriteBatch(SpriteBatch spriteBatch, int startIndex, int spriteCount, Bitmap bitmap, BitmapInterpolationMode interpolationMode, SpriteOptions spriteOptions);
	}
}
