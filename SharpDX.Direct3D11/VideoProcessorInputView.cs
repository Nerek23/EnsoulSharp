using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000CD RID: 205
	[Guid("11EC5A5F-51DC-4945-AB34-6E8C21300EA5")]
	public class VideoProcessorInputView : ResourceView
	{
		// Token: 0x0600042E RID: 1070 RVA: 0x00002F64 File Offset: 0x00001164
		public VideoProcessorInputView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00010763 File Offset: 0x0000E963
		public new static explicit operator VideoProcessorInputView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoProcessorInputView(nativePtr);
			}
			return null;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0001077C File Offset: 0x0000E97C
		public VideoProcessorInputViewDescription Description
		{
			get
			{
				VideoProcessorInputViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00010794 File Offset: 0x0000E994
		internal unsafe void GetDescription(out VideoProcessorInputViewDescription descRef)
		{
			descRef = default(VideoProcessorInputViewDescription);
			fixed (VideoProcessorInputViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
