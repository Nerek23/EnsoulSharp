using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C7 RID: 199
	[Guid("C2931AEA-2A85-4f20-860F-FBA1FD256E18")]
	public class VideoDecoderOutputView : ResourceView
	{
		// Token: 0x060003FD RID: 1021 RVA: 0x00002F64 File Offset: 0x00001164
		public VideoDecoderOutputView(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000FB0C File Offset: 0x0000DD0C
		public new static explicit operator VideoDecoderOutputView(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoDecoderOutputView(nativePtr);
			}
			return null;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000FB24 File Offset: 0x0000DD24
		public VideoDecoderOutputViewDescription Description
		{
			get
			{
				VideoDecoderOutputViewDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x0000FB3C File Offset: 0x0000DD3C
		internal unsafe void GetDescription(out VideoDecoderOutputViewDescription descRef)
		{
			descRef = default(VideoDecoderOutputViewDescription);
			fixed (VideoDecoderOutputViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
