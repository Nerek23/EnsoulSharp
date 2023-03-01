using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001CE RID: 462
	[Guid("235a7496-8351-414c-bcd4-6672ab2d8e00")]
	public class DeviceContext3 : DeviceContext2
	{
		// Token: 0x06000947 RID: 2375 RVA: 0x0001AC29 File Offset: 0x00018E29
		public DeviceContext3(Device3 device, DeviceContextOptions options) : base(IntPtr.Zero)
		{
			device.CreateDeviceContext(options, this);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0001AC3E File Offset: 0x00018E3E
		public DeviceContext3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0001AC47 File Offset: 0x00018E47
		public new static explicit operator DeviceContext3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext3(nativePtr);
			}
			return null;
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0001AC60 File Offset: 0x00018E60
		internal unsafe void CreateSpriteBatch(SpriteBatch spriteBatch)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)106 * (IntPtr)sizeof(void*)));
			spriteBatch.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0001ACA8 File Offset: 0x00018EA8
		public unsafe void DrawSpriteBatch(SpriteBatch spriteBatch, int startIndex, int spriteCount, Bitmap bitmap, BitmapInterpolationMode interpolationMode, SpriteOptions spriteOptions)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SpriteBatch>(spriteBatch);
			value2 = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, startIndex, spriteCount, (void*)value2, interpolationMode, spriteOptions, *(*(IntPtr*)this._nativePointer + (IntPtr)107 * (IntPtr)sizeof(void*)));
		}
	}
}
