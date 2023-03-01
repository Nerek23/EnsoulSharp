using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200006A RID: 106
	[Guid("409cd537-8532-40cb-9774-e2feb2df4e9c")]
	public class DdsDecoder : ComObject
	{
		// Token: 0x060001E6 RID: 486 RVA: 0x00002A7F File Offset: 0x00000C7F
		public DdsDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000840F File Offset: 0x0000660F
		public new static explicit operator DdsDecoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DdsDecoder(nativePtr);
			}
			return null;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00008428 File Offset: 0x00006628
		public DdsParameters Parameters
		{
			get
			{
				DdsParameters result;
				this.GetParameters(out result);
				return result;
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00008440 File Offset: 0x00006640
		internal unsafe void GetParameters(out DdsParameters parametersRef)
		{
			parametersRef = default(DdsParameters);
			Result result;
			fixed (DdsParameters* ptr = &parametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00008488 File Offset: 0x00006688
		public unsafe void GetFrame(int arrayIndex, int mipLevel, int sliceIndex, out BitmapFrameDecode bitmapFrameOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, arrayIndex, mipLevel, sliceIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmapFrameOut = new BitmapFrameDecode(zero);
			}
			else
			{
				bitmapFrameOut = null;
			}
			result.CheckError();
		}
	}
}
