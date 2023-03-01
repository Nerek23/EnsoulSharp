using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000052 RID: 82
	[Guid("61F21C45-3C0E-4a74-9CEA-67100D9AD5E4")]
	public class VideoContext : DeviceChild
	{
		// Token: 0x0600031D RID: 797 RVA: 0x0000C014 File Offset: 0x0000A214
		public DataPointer GetDecoderBuffer(VideoDecoder decoder, VideoDecoderBufferType type)
		{
			int size;
			IntPtr pointer;
			this.GetDecoderBuffer(decoder, type, out size, out pointer);
			return new DataPointer(pointer, size);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00002075 File Offset: 0x00000275
		public VideoContext(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000C034 File Offset: 0x0000A234
		public new static explicit operator VideoContext(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoContext(nativePtr);
			}
			return null;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000C04C File Offset: 0x0000A24C
		internal unsafe void GetDecoderBuffer(VideoDecoder decoderRef, VideoDecoderBufferType type, out int bufferSizeRef, out IntPtr bufferOut)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			Result result;
			fixed (IntPtr* ptr = &bufferOut)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &bufferSizeRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, type, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000C0B0 File Offset: 0x0000A2B0
		public unsafe void ReleaseDecoderBuffer(VideoDecoder decoderRef, VideoDecoderBufferType type)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, type, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000C0FC File Offset: 0x0000A2FC
		public unsafe void DecoderBeginFrame(VideoDecoder decoderRef, VideoDecoderOutputView viewRef, int contentKeySize, IntPtr contentKeyRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			value2 = CppObject.ToCallbackPtr<VideoDecoderOutputView>(viewRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, (void*)value2, contentKeySize, (void*)contentKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000C164 File Offset: 0x0000A364
		public unsafe void DecoderEndFrame(VideoDecoder decoderRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000C1B0 File Offset: 0x0000A3B0
		public unsafe void SubmitDecoderBuffers(VideoDecoder decoderRef, int numBuffers, VideoDecoderBufferDescription[] bufferDescRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			Result result;
			fixed (VideoDecoderBufferDescription[] array = bufferDescRef)
			{
				void* ptr;
				if (bufferDescRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000C218 File Offset: 0x0000A418
		public unsafe void DecoderExtension(VideoDecoder decoderRef, ref VideoDecoderExtension extensionDataRef)
		{
			IntPtr value = IntPtr.Zero;
			VideoDecoderExtension.__Native _Native = default(VideoDecoderExtension.__Native);
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			extensionDataRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			extensionDataRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000C280 File Offset: 0x0000A480
		public unsafe void VideoProcessorSetOutputTargetRect(VideoProcessor videoProcessorRef, RawBool enable, RawRectangle? rectRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			RawRectangle value2;
			if (rectRef != null)
			{
				value2 = rectRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, (void*)value, enable, (rectRef == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000C2E0 File Offset: 0x0000A4E0
		public unsafe void VideoProcessorSetOutputBackgroundColor(VideoProcessor videoProcessorRef, RawBool yCbCr, VideoColor colorRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, (void*)value, yCbCr, &colorRef, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000C324 File Offset: 0x0000A524
		public unsafe void VideoProcessorSetOutputColorSpace(VideoProcessor videoProcessorRef, VideoProcessorColorSpace colorSpaceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &colorSpaceRef, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000C368 File Offset: 0x0000A568
		public unsafe void VideoProcessorSetOutputAlphaFillMode(VideoProcessor videoProcessorRef, VideoProcessorAlphaFillMode alphaFillMode, int streamIndex)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, alphaFillMode, streamIndex, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000C3A8 File Offset: 0x0000A5A8
		public unsafe void VideoProcessorSetOutputConstriction(VideoProcessor videoProcessorRef, RawBool enable, Size2 size)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool,SharpDX.Size2), this._nativePointer, (void*)value, enable, size, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
		public unsafe void VideoProcessorSetOutputStereoMode(VideoProcessor videoProcessorRef, RawBool enable)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, enable, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000C428 File Offset: 0x0000A628
		public unsafe void VideoProcessorSetOutputExtension(VideoProcessor videoProcessorRef, Guid extensionGuidRef, int dataSize, IntPtr dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, &extensionGuidRef, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000C480 File Offset: 0x0000A680
		public unsafe void VideoProcessorGetOutputTargetRect(VideoProcessor videoProcessorRef, out RawBool enabled, out RawRectangle rectRef)
		{
			IntPtr value = IntPtr.Zero;
			enabled = default(RawBool);
			rectRef = default(RawRectangle);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawRectangle* ptr = &rectRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enabled)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000C4E4 File Offset: 0x0000A6E4
		public unsafe void VideoProcessorGetOutputBackgroundColor(VideoProcessor videoProcessorRef, out RawBool yCbCrRef, out VideoColor colorRef)
		{
			IntPtr value = IntPtr.Zero;
			yCbCrRef = default(RawBool);
			colorRef = default(VideoColor);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (VideoColor* ptr = &colorRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &yCbCrRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000C548 File Offset: 0x0000A748
		public unsafe void VideoProcessorGetOutputColorSpace(VideoProcessor videoProcessorRef, out VideoProcessorColorSpace colorSpaceRef)
		{
			IntPtr value = IntPtr.Zero;
			colorSpaceRef = default(VideoProcessorColorSpace);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (VideoProcessorColorSpace* ptr = &colorSpaceRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000C598 File Offset: 0x0000A798
		public unsafe void VideoProcessorGetOutputAlphaFillMode(VideoProcessor videoProcessorRef, out VideoProcessorAlphaFillMode alphaFillModeRef, out int streamIndexRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (int* ptr = &streamIndexRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoProcessorAlphaFillMode* ptr3 = &alphaFillModeRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000C5EC File Offset: 0x0000A7EC
		public unsafe void VideoProcessorGetOutputConstriction(VideoProcessor videoProcessorRef, out RawBool enabledRef, out Size2 sizeRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			sizeRef = default(Size2);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (Size2* ptr = &sizeRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enabledRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000C650 File Offset: 0x0000A850
		public unsafe void VideoProcessorGetOutputStereoMode(VideoProcessor videoProcessorRef, out RawBool enabledRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawBool* ptr = &enabledRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000C6A0 File Offset: 0x0000A8A0
		public unsafe void VideoProcessorGetOutputExtension(VideoProcessor videoProcessorRef, Guid extensionGuidRef, int dataSize, IntPtr dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, &extensionGuidRef, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000C6F8 File Offset: 0x0000A8F8
		public unsafe void VideoProcessorSetStreamFrameFormat(VideoProcessor videoProcessorRef, int streamIndex, VideoFrameFormat frameFormat)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, streamIndex, frameFormat, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000C738 File Offset: 0x0000A938
		public unsafe void VideoProcessorSetStreamColorSpace(VideoProcessor videoProcessorRef, int streamIndex, VideoProcessorColorSpace colorSpaceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, &colorSpaceRef, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000C77C File Offset: 0x0000A97C
		public unsafe void VideoProcessorSetStreamOutputRate(VideoProcessor videoProcessorRef, int streamIndex, VideoProcessorOutputRate outputRate, RawBool repeatFrame, Rational? customRateRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			Rational value2;
			if (customRateRef != null)
			{
				value2 = customRateRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, (void*)value, streamIndex, outputRate, repeatFrame, (customRateRef == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
		public unsafe void VideoProcessorSetStreamSourceRect(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, RawRectangle? rectRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			RawRectangle value2;
			if (rectRef != null)
			{
				value2 = rectRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, (void*)value, streamIndex, enable, (rectRef == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000C844 File Offset: 0x0000AA44
		public unsafe void VideoProcessorSetStreamDestRect(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, RawRectangle? rectRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			RawRectangle value2;
			if (rectRef != null)
			{
				value2 = rectRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, (void*)value, streamIndex, enable, (rectRef == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000C8A8 File Offset: 0x0000AAA8
		public unsafe void VideoProcessorSetStreamAlpha(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, float alpha)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Single), this._nativePointer, (void*)value, streamIndex, enable, alpha, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000C8EC File Offset: 0x0000AAEC
		public unsafe void VideoProcessorSetStreamPalette(VideoProcessor videoProcessorRef, int streamIndex, int count, int[] entriesRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (int[] array = entriesRef)
			{
				void* ptr;
				if (entriesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, count, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000C948 File Offset: 0x0000AB48
		public unsafe void VideoProcessorSetStreamPixelAspectRatio(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, Rational? sourceAspectRatioRef, Rational? destinationAspectRatioRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			Rational value2;
			if (sourceAspectRatioRef != null)
			{
				value2 = sourceAspectRatioRef.Value;
			}
			Rational value3;
			if (destinationAspectRatioRef != null)
			{
				value3 = destinationAspectRatioRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, enable, (sourceAspectRatioRef == null) ? null : (&value2), (destinationAspectRatioRef == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000C9CC File Offset: 0x0000ABCC
		public unsafe void VideoProcessorSetStreamLumaKey(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, float lower, float upper)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Single,System.Single), this._nativePointer, (void*)value, streamIndex, enable, lower, upper, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000CA10 File Offset: 0x0000AC10
		public unsafe void VideoProcessorSetStreamStereoFormat(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, VideoProcessorStereoFormat format, RawBool leftViewFrame0, RawBool baseViewFrame0, VideoProcessorStereoFlipMode flipMode, int monoOffset)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Int32,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,System.Int32,System.Int32), this._nativePointer, (void*)value, streamIndex, enable, format, leftViewFrame0, baseViewFrame0, flipMode, monoOffset, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000CA5C File Offset: 0x0000AC5C
		public unsafe void VideoProcessorSetStreamAutoProcessingMode(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, streamIndex, enable, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000CA9C File Offset: 0x0000AC9C
		public unsafe void VideoProcessorSetStreamFilter(VideoProcessor videoProcessorRef, int streamIndex, VideoProcessorFilter filter, RawBool enable, int level)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Int32), this._nativePointer, (void*)value, streamIndex, filter, enable, level, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000CAE0 File Offset: 0x0000ACE0
		public unsafe void VideoProcessorSetStreamExtension(VideoProcessor videoProcessorRef, int streamIndex, Guid extensionGuidRef, int dataSize, IntPtr dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, &extensionGuidRef, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000CB38 File Offset: 0x0000AD38
		public unsafe void VideoProcessorGetStreamFrameFormat(VideoProcessor videoProcessorRef, int streamIndex, out VideoFrameFormat frameFormatRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (VideoFrameFormat* ptr = &frameFormatRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000CB80 File Offset: 0x0000AD80
		public unsafe void VideoProcessorGetStreamColorSpace(VideoProcessor videoProcessorRef, int streamIndex, out VideoProcessorColorSpace colorSpaceRef)
		{
			IntPtr value = IntPtr.Zero;
			colorSpaceRef = default(VideoProcessorColorSpace);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (VideoProcessorColorSpace* ptr = &colorSpaceRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
		public unsafe void VideoProcessorGetStreamOutputRate(VideoProcessor videoProcessorRef, int streamIndex, out VideoProcessorOutputRate outputRateRef, out RawBool repeatFrameRef, out Rational customRateRef)
		{
			IntPtr value = IntPtr.Zero;
			repeatFrameRef = default(RawBool);
			customRateRef = default(Rational);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (Rational* ptr = &customRateRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &repeatFrameRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (VideoProcessorOutputRate* ptr5 = &outputRateRef)
					{
						void* ptr6 = (void*)ptr5;
						calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
					}
				}
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public unsafe void VideoProcessorGetStreamSourceRect(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enabledRef, out RawRectangle rectRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			rectRef = default(RawRectangle);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawRectangle* ptr = &rectRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enabledRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000CCA8 File Offset: 0x0000AEA8
		public unsafe void VideoProcessorGetStreamDestRect(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enabledRef, out RawRectangle rectRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			rectRef = default(RawRectangle);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawRectangle* ptr = &rectRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enabledRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000CD0C File Offset: 0x0000AF0C
		public unsafe void VideoProcessorGetStreamAlpha(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enabledRef, out float alphaRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (float* ptr = &alphaRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enabledRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000CD68 File Offset: 0x0000AF68
		public unsafe void VideoProcessorGetStreamPalette(VideoProcessor videoProcessorRef, int streamIndex, int count, int[] entriesRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (int[] array = entriesRef)
			{
				void* ptr;
				if (entriesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, count, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000CDC4 File Offset: 0x0000AFC4
		public unsafe void VideoProcessorGetStreamPixelAspectRatio(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enabledRef, out Rational sourceAspectRatioRef, out Rational destinationAspectRatioRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			sourceAspectRatioRef = default(Rational);
			destinationAspectRatioRef = default(Rational);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (Rational* ptr = &destinationAspectRatioRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (Rational* ptr3 = &sourceAspectRatioRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (RawBool* ptr5 = &enabledRef)
					{
						void* ptr6 = (void*)ptr5;
						calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
					}
				}
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000CE40 File Offset: 0x0000B040
		public unsafe void VideoProcessorGetStreamLumaKey(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enabledRef, out float lowerRef, out float upperRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (float* ptr = &upperRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &lowerRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (RawBool* ptr5 = &enabledRef)
					{
						void* ptr6 = (void*)ptr5;
						calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
					}
				}
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000CEAC File Offset: 0x0000B0AC
		public unsafe void VideoProcessorGetStreamStereoFormat(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enableRef, out VideoProcessorStereoFormat formatRef, out RawBool leftViewFrame0Ref, out RawBool baseViewFrame0Ref, out VideoProcessorStereoFlipMode flipModeRef, out int monoOffset)
		{
			IntPtr value = IntPtr.Zero;
			enableRef = default(RawBool);
			leftViewFrame0Ref = default(RawBool);
			baseViewFrame0Ref = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (int* ptr = &monoOffset)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoProcessorStereoFlipMode* ptr3 = &flipModeRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (RawBool* ptr5 = &baseViewFrame0Ref)
					{
						void* ptr6 = (void*)ptr5;
						fixed (RawBool* ptr7 = &leftViewFrame0Ref)
						{
							void* ptr8 = (void*)ptr7;
							fixed (VideoProcessorStereoFormat* ptr9 = &formatRef)
							{
								void* ptr10 = (void*)ptr9;
								fixed (RawBool* ptr11 = &enableRef)
								{
									void* ptr12 = (void*)ptr11;
									calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr12, ptr10, ptr8, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000CF54 File Offset: 0x0000B154
		public unsafe void VideoProcessorGetStreamAutoProcessingMode(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enabledRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawBool* ptr = &enabledRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
		public unsafe void VideoProcessorGetStreamFilter(VideoProcessor videoProcessorRef, int streamIndex, VideoProcessorFilter filter, out RawBool enabledRef, out int levelRef)
		{
			IntPtr value = IntPtr.Zero;
			enabledRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (int* ptr = &levelRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enabledRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, filter, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000D004 File Offset: 0x0000B204
		public unsafe void VideoProcessorGetStreamExtension(VideoProcessor videoProcessorRef, int streamIndex, Guid extensionGuidRef, int dataSize, IntPtr dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, &extensionGuidRef, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000D05C File Offset: 0x0000B25C
		public unsafe void VideoProcessorBlt(VideoProcessor videoProcessorRef, VideoProcessorOutputView viewRef, int outputFrame, int streamCount, VideoProcessorStream[] streamsRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			VideoProcessorStream.__Native[] array = new VideoProcessorStream.__Native[streamsRef.Length];
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			value2 = CppObject.ToCallbackPtr<VideoProcessorOutputView>(viewRef);
			for (int i = 0; i < streamsRef.Length; i++)
			{
				streamsRef[i].__MarshalTo(ref array[i]);
			}
			VideoProcessorStream.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, (void*)value2, outputFrame, streamCount, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*)));
			array2 = null;
			for (int j = 0; j < streamsRef.Length; j++)
			{
				streamsRef[j].__MarshalFree(ref array[j]);
			}
			result.CheckError();
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000D13C File Offset: 0x0000B33C
		public unsafe void NegotiateCryptoSessionKeyExchange(CryptoSession cryptoSessionRef, int dataSize, IntPtr dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000D190 File Offset: 0x0000B390
		public unsafe void EncryptionBlt(CryptoSession cryptoSessionRef, Texture2D srcSurfaceRef, Texture2D dstSurfaceRef, int iVSize, IntPtr iVRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			value2 = CppObject.ToCallbackPtr<Texture2D>(srcSurfaceRef);
			value3 = CppObject.ToCallbackPtr<Texture2D>(dstSurfaceRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, iVSize, (void*)iVRef, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000D200 File Offset: 0x0000B400
		public unsafe void DecryptionBlt(CryptoSession cryptoSessionRef, Texture2D srcSurfaceRef, Texture2D dstSurfaceRef, EncryptedBlockInformation? encryptedBlockInfoRef, int contentKeySize, IntPtr contentKeyRef, int iVSize, IntPtr iVRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			value2 = CppObject.ToCallbackPtr<Texture2D>(srcSurfaceRef);
			value3 = CppObject.ToCallbackPtr<Texture2D>(dstSurfaceRef);
			EncryptedBlockInformation value4;
			if (encryptedBlockInfoRef != null)
			{
				value4 = encryptedBlockInfoRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, (encryptedBlockInfoRef == null) ? null : (&value4), contentKeySize, (void*)contentKeyRef, iVSize, (void*)iVRef, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000D298 File Offset: 0x0000B498
		public unsafe void StartSessionKeyRefresh(CryptoSession cryptoSessionRef, int randomNumberSize, IntPtr randomNumberRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, randomNumberSize, (void*)randomNumberRef, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
		public unsafe void FinishSessionKeyRefresh(CryptoSession cryptoSessionRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000D320 File Offset: 0x0000B520
		public unsafe void GetEncryptionBltKey(CryptoSession cryptoSessionRef, int keySize, IntPtr readbackKeyRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, keySize, (void*)readbackKeyRef, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000D374 File Offset: 0x0000B574
		public unsafe void NegotiateAuthenticatedChannelKeyExchange(AuthenticatedChannel channelRef, int dataSize, IntPtr dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<AuthenticatedChannel>(channelRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000D3C8 File Offset: 0x0000B5C8
		public unsafe void QueryAuthenticatedChannel(AuthenticatedChannel channelRef, int inputSize, IntPtr inputRef, int outputSize, IntPtr outputRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<AuthenticatedChannel>(channelRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, inputSize, (void*)inputRef, outputSize, (void*)outputRef, *(*(IntPtr*)this._nativePointer + (IntPtr)61 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000D424 File Offset: 0x0000B624
		public unsafe void ConfigureAuthenticatedChannel(AuthenticatedChannel channelRef, int inputSize, IntPtr inputRef, out AuthenticatedConfigureOutput outputRef)
		{
			IntPtr value = IntPtr.Zero;
			AuthenticatedConfigureOutput.__Native _Native = default(AuthenticatedConfigureOutput.__Native);
			outputRef = default(AuthenticatedConfigureOutput);
			value = CppObject.ToCallbackPtr<AuthenticatedChannel>(channelRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, inputSize, (void*)inputRef, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)62 * (IntPtr)sizeof(void*)));
			outputRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000D494 File Offset: 0x0000B694
		public unsafe void VideoProcessorSetStreamRotation(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, VideoProcessorRotation rotation)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Int32), this._nativePointer, (void*)value, streamIndex, enable, rotation, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000D4D8 File Offset: 0x0000B6D8
		public unsafe void VideoProcessorGetStreamRotation(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enableRef, out VideoProcessorRotation rotationRef)
		{
			IntPtr value = IntPtr.Zero;
			enableRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (VideoProcessorRotation* ptr = &rotationRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &enableRef)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
				}
			}
		}
	}
}
