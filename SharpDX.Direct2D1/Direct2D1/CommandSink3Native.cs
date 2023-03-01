using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200018C RID: 396
	[Guid("18079135-4cf3-4868-bc8e-06067e6d242d")]
	internal class CommandSink3Native : CommandSink2Native, CommandSink3, CommandSink2, CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600076E RID: 1902 RVA: 0x00016745 File Offset: 0x00014945
		public void DrawSpriteBatch(SpriteBatch spriteBatch, int startIndex, int spriteCount, Bitmap bitmap, BitmapInterpolationMode interpolationMode, SpriteOptions spriteOptions)
		{
			this.DrawSpriteBatch_(spriteBatch, startIndex, spriteCount, bitmap, interpolationMode, spriteOptions);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00016756 File Offset: 0x00014956
		public CommandSink3Native(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001675F File Offset: 0x0001495F
		public new static explicit operator CommandSink3Native(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandSink3Native(nativePtr);
			}
			return null;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00016778 File Offset: 0x00014978
		internal unsafe void DrawSpriteBatch_(SpriteBatch spriteBatch, int startIndex, int spriteCount, Bitmap bitmap, BitmapInterpolationMode interpolationMode, SpriteOptions spriteOptions)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SpriteBatch>(spriteBatch);
			value2 = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, startIndex, spriteCount, (void*)value2, interpolationMode, spriteOptions, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
