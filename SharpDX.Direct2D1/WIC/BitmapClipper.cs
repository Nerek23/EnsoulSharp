using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000003 RID: 3
	[Guid("E4FBCF03-223D-4e81-9333-D635556DD1B5")]
	public class BitmapClipper : BitmapSource
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002256 File Offset: 0x00000456
		public BitmapClipper(ImagingFactory factory) : base(IntPtr.Zero)
		{
			factory.CreateBitmapClipper(this);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000226A File Offset: 0x0000046A
		public unsafe void Initialize(BitmapSource sourceRef, RawBox rectangleRef)
		{
			this.Initialize(sourceRef, new IntPtr((void*)(&rectangleRef)));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002145 File Offset: 0x00000345
		public BitmapClipper(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000227B File Offset: 0x0000047B
		public new static explicit operator BitmapClipper(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapClipper(nativePtr);
			}
			return null;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002294 File Offset: 0x00000494
		internal unsafe void Initialize(BitmapSource sourceRef, IntPtr rectangleRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(sourceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)rectangleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
