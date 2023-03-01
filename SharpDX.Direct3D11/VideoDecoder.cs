using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C6 RID: 198
	[Guid("3C9C5B51-995D-48d1-9B8D-FA5CAEDED65C")]
	public class VideoDecoder : DeviceChild
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x00002075 File Offset: 0x00000275
		public VideoDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000FA41 File Offset: 0x0000DC41
		public new static explicit operator VideoDecoder(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoDecoder(nativePtr);
			}
			return null;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000FA58 File Offset: 0x0000DC58
		public IntPtr DriverHandle
		{
			get
			{
				IntPtr result;
				this.GetDriverHandle(out result);
				return result;
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000FA70 File Offset: 0x0000DC70
		public unsafe void GetCreationParameters(out VideoDecoderDescription videoDescRef, out VideoDecoderConfig configRef)
		{
			videoDescRef = default(VideoDecoderDescription);
			configRef = default(VideoDecoderConfig);
			Result result;
			fixed (VideoDecoderConfig* ptr = &configRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoDecoderDescription* ptr3 = &videoDescRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000FACC File Offset: 0x0000DCCC
		internal unsafe void GetDriverHandle(out IntPtr driverHandleRef)
		{
			Result result;
			fixed (IntPtr* ptr = &driverHandleRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
