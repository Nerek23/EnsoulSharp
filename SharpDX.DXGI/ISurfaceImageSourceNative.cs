using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000064 RID: 100
	[Guid("f2e9edc1-d307-4525-9886-0fafaa44163c")]
	public class ISurfaceImageSourceNative : ComObject
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x0000272E File Offset: 0x0000092E
		public ISurfaceImageSourceNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00006D8A File Offset: 0x00004F8A
		public new static explicit operator ISurfaceImageSourceNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ISurfaceImageSourceNative(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002F RID: 47
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00006DA1 File Offset: 0x00004FA1
		public Device Device
		{
			set
			{
				this.SetDevice(value);
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00006DAC File Offset: 0x00004FAC
		internal unsafe void SetDevice(Device device)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Device>(device);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00006DF8 File Offset: 0x00004FF8
		public unsafe Surface BeginDraw(RawRectangle updateRect, out RawPoint offset)
		{
			IntPtr zero = IntPtr.Zero;
			offset = default(RawPoint);
			Result result;
			fixed (RawPoint* ptr = &offset)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawRectangle,System.Void*,System.Void*), this._nativePointer, updateRect, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			Surface result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Surface(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00006E68 File Offset: 0x00005068
		public unsafe void EndDraw()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
