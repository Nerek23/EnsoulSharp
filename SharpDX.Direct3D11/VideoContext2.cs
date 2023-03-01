using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C5 RID: 197
	[Guid("C4E7374C-6243-4D1B-AE87-52B4F740E261")]
	public class VideoContext2 : VideoContext1
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x0000F8EA File Offset: 0x0000DAEA
		public VideoContext2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000F8F3 File Offset: 0x0000DAF3
		public new static explicit operator VideoContext2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoContext2(nativePtr);
			}
			return null;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000F90C File Offset: 0x0000DB0C
		public unsafe void VideoProcessorSetOutputHDRMetaData(VideoProcessor videoProcessorRef, HdrMetadataType type, int size, IntPtr hDRMetaDataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, type, size, (void*)hDRMetaDataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)79 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000F954 File Offset: 0x0000DB54
		public unsafe void VideoProcessorGetOutputHDRMetaData(VideoProcessor videoProcessorRef, out HdrMetadataType typeRef, int size, IntPtr metaDataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (HdrMetadataType* ptr = &typeRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, ptr2, size, (void*)metaDataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)80 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000F9A4 File Offset: 0x0000DBA4
		public unsafe void VideoProcessorSetStreamHDRMetaData(VideoProcessor videoProcessorRef, int streamIndex, HdrMetadataType type, int size, IntPtr hDRMetaDataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, type, size, (void*)hDRMetaDataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)81 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000F9F0 File Offset: 0x0000DBF0
		public unsafe void VideoProcessorGetStreamHDRMetaData(VideoProcessor videoProcessorRef, int streamIndex, out HdrMetadataType typeRef, int size, IntPtr metaDataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (HdrMetadataType* ptr = &typeRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr2, size, (void*)metaDataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)82 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
