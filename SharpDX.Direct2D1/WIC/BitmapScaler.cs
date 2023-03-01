using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200000D RID: 13
	[Guid("00000302-a8f2-4877-ba0a-fd2b6645fb94")]
	public class BitmapScaler : BitmapSource
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x000041CB File Offset: 0x000023CB
		public BitmapScaler(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreateBitmapScaler(this);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00002145 File Offset: 0x00000345
		public BitmapScaler(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000041DF File Offset: 0x000023DF
		public new static explicit operator BitmapScaler(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapScaler(nativePtr);
			}
			return null;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000041F8 File Offset: 0x000023F8
		public unsafe void Initialize(BitmapSource sourceRef, int width, int height, BitmapInterpolationMode mode)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(sourceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, (void*)value, width, height, mode, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
