using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.WIC
{
	// Token: 0x02000020 RID: 32
	[Guid("7B816B45-1996-4476-B132-DE9E247C8AF0")]
	public class ImagingFactory2 : ImagingFactory
	{
		// Token: 0x06000161 RID: 353 RVA: 0x00005F61 File Offset: 0x00004161
		public ImagingFactory2()
		{
			Utilities.CreateComInstance(ImagingFactory.WICImagingFactoryClsid, Utilities.CLSCTX.ClsctxInprocServer, Utilities.GetGuidFromType(typeof(ImagingFactory2)), this);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005F84 File Offset: 0x00004184
		public ImagingFactory2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005F8D File Offset: 0x0000418D
		public new static explicit operator ImagingFactory2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ImagingFactory2(nativePtr);
			}
			return null;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005FA4 File Offset: 0x000041A4
		internal unsafe void CreateImageEncoder(Device d2DDeviceRef, ImageEncoder wICImageEncoderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(d2DDeviceRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			wICImageEncoderOut.NativePointer = zero;
			result.CheckError();
		}
	}
}
