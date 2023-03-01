using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000CA RID: 202
	[Guid("1D7B0652-185F-41c6-85CE-0C5BE3D4AE6C")]
	public class VideoProcessor : DeviceChild
	{
		// Token: 0x0600041B RID: 1051 RVA: 0x00002075 File Offset: 0x00000275
		public VideoProcessor(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00010434 File Offset: 0x0000E634
		public new static explicit operator VideoProcessor(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoProcessor(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0001044C File Offset: 0x0000E64C
		public VideoProcessorContentDescription ContentDescription
		{
			get
			{
				VideoProcessorContentDescription result;
				this.GetContentDescription(out result);
				return result;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00010464 File Offset: 0x0000E664
		public VideoProcessorRateConversionCaps RateConversionCaps
		{
			get
			{
				VideoProcessorRateConversionCaps result;
				this.GetRateConversionCaps(out result);
				return result;
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001047C File Offset: 0x0000E67C
		internal unsafe void GetContentDescription(out VideoProcessorContentDescription descRef)
		{
			descRef = default(VideoProcessorContentDescription);
			fixed (VideoProcessorContentDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x000104B8 File Offset: 0x0000E6B8
		internal unsafe void GetRateConversionCaps(out VideoProcessorRateConversionCaps capsRef)
		{
			capsRef = default(VideoProcessorRateConversionCaps);
			fixed (VideoProcessorRateConversionCaps* ptr = &capsRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
