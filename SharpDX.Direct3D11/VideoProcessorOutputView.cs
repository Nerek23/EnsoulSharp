using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000CE RID: 206
	[Guid("A048285E-25A9-4527-BD93-D68B68C44254")]
	public class VideoProcessorOutputView : ResourceView
	{
		// Token: 0x06000432 RID: 1074 RVA: 0x00002F64 File Offset: 0x00001164
		public VideoProcessorOutputView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000107CE File Offset: 0x0000E9CE
		public new static explicit operator VideoProcessorOutputView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoProcessorOutputView(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x000107E8 File Offset: 0x0000E9E8
		public VideoProcessorOutputViewDescription Description
		{
			get
			{
				VideoProcessorOutputViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00010800 File Offset: 0x0000EA00
		internal unsafe void GetDescription(out VideoProcessorOutputViewDescription descRef)
		{
			descRef = default(VideoProcessorOutputViewDescription);
			fixed (VideoProcessorOutputViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
