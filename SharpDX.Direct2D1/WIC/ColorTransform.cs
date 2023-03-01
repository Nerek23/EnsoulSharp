using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000015 RID: 21
	[Guid("B66F034F-D0E2-40ab-B436-6DE39E321A94")]
	public class ColorTransform : BitmapSource
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00004BAF File Offset: 0x00002DAF
		public ColorTransform(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreateColorTransformer(this);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002145 File Offset: 0x00000345
		public ColorTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004BC3 File Offset: 0x00002DC3
		public new static explicit operator ColorTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ColorTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004BDC File Offset: 0x00002DDC
		public unsafe void Initialize(BitmapSource bitmapSourceRef, ColorContext contextSourceRef, ColorContext contextDestRef, Guid ixelFmtDestRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(bitmapSourceRef);
			value2 = CppObject.ToCallbackPtr<ColorContext>(contextSourceRef);
			value3 = CppObject.ToCallbackPtr<ColorContext>(contextDestRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, &ixelFmtDestRef, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
