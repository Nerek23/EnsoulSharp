using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000009 RID: 9
	[Guid("5009834F-2D6A-41ce-9E1B-17C5AFF7A782")]
	public class BitmapFlipRotator : BitmapSource
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00003886 File Offset: 0x00001A86
		public BitmapFlipRotator(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreateBitmapFlipRotator(this);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002145 File Offset: 0x00000345
		public BitmapFlipRotator(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000389A File Offset: 0x00001A9A
		public new static explicit operator BitmapFlipRotator(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapFlipRotator(nativePtr);
			}
			return null;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000038B4 File Offset: 0x00001AB4
		public unsafe void Initialize(BitmapSource sourceRef, BitmapTransformOptions options)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(sourceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, options, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
