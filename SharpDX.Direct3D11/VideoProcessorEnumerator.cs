using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000CB RID: 203
	[Guid("31627037-53AB-4200-9061-05FAA9AB45F9")]
	public class VideoProcessorEnumerator : DeviceChild
	{
		// Token: 0x06000421 RID: 1057 RVA: 0x00002075 File Offset: 0x00000275
		public VideoProcessorEnumerator(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000104F2 File Offset: 0x0000E6F2
		public new static explicit operator VideoProcessorEnumerator(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoProcessorEnumerator(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0001050C File Offset: 0x0000E70C
		public VideoProcessorContentDescription VideoProcessorContentDescription
		{
			get
			{
				VideoProcessorContentDescription result;
				this.GetVideoProcessorContentDescription(out result);
				return result;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00010524 File Offset: 0x0000E724
		public VideoProcessorCaps VideoProcessorCaps
		{
			get
			{
				VideoProcessorCaps result;
				this.GetVideoProcessorCaps(out result);
				return result;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0001053C File Offset: 0x0000E73C
		internal unsafe void GetVideoProcessorContentDescription(out VideoProcessorContentDescription contentDescRef)
		{
			contentDescRef = default(VideoProcessorContentDescription);
			Result result;
			fixed (VideoProcessorContentDescription* ptr = &contentDescRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00010584 File Offset: 0x0000E784
		public unsafe void CheckVideoProcessorFormat(Format format, out int flagsRef)
		{
			Result result;
			fixed (int* ptr = &flagsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, format, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000105C8 File Offset: 0x0000E7C8
		internal unsafe void GetVideoProcessorCaps(out VideoProcessorCaps capsRef)
		{
			capsRef = default(VideoProcessorCaps);
			Result result;
			fixed (VideoProcessorCaps* ptr = &capsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00010610 File Offset: 0x0000E810
		public unsafe void GetVideoProcessorRateConversionCaps(int typeIndex, out VideoProcessorRateConversionCaps capsRef)
		{
			capsRef = default(VideoProcessorRateConversionCaps);
			Result result;
			fixed (VideoProcessorRateConversionCaps* ptr = &capsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, typeIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001065C File Offset: 0x0000E85C
		public unsafe void GetVideoProcessorCustomRate(int typeIndex, int customRateIndex, out VideoProcessorCustomRate rateRef)
		{
			rateRef = default(VideoProcessorCustomRate);
			Result result;
			fixed (VideoProcessorCustomRate* ptr = &rateRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, typeIndex, customRateIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000106A8 File Offset: 0x0000E8A8
		public unsafe void GetVideoProcessorFilterRange(VideoProcessorFilter filter, out VideoProcessorFilterRange rangeRef)
		{
			rangeRef = default(VideoProcessorFilterRange);
			Result result;
			fixed (VideoProcessorFilterRange* ptr = &rangeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, filter, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
