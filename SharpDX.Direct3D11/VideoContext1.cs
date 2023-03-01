using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C4 RID: 196
	[Guid("A7F026DA-A5F8-4487-A564-15E34357651E")]
	public class VideoContext1 : VideoContext
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x0000F42D File Offset: 0x0000D62D
		public VideoContext1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000F436 File Offset: 0x0000D636
		public new static explicit operator VideoContext1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoContext1(nativePtr);
			}
			return null;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000F450 File Offset: 0x0000D650
		public unsafe void SubmitDecoderBuffers1(VideoDecoder decoderRef, int numBuffers, VideoDecoderBufferDescription1[] bufferDescRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			Result result;
			fixed (VideoDecoderBufferDescription1[] array = bufferDescRef)
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
		public unsafe void GetDataForNewHardwareKey(CryptoSession cryptoSessionRef, int privateInputSize, IntPtr privatInputDataRef, out long privateOutputDataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			Result result;
			fixed (long* ptr = &privateOutputDataRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, privateInputSize, (void*)privatInputDataRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000F514 File Offset: 0x0000D714
		public unsafe void CheckCryptoSessionStatus(CryptoSession cryptoSessionRef, out CryptoSessionStatus statusRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CryptoSession>(cryptoSessionRef);
			Result result;
			fixed (CryptoSessionStatus* ptr = &statusRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000F568 File Offset: 0x0000D768
		public unsafe void DecoderEnableDownsampling(VideoDecoder decoderRef, ColorSpaceType inputColorSpace, VideoSampleDescription outputDescRef, int referenceFrameCount)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, (void*)value, inputColorSpace, &outputDescRef, referenceFrameCount, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000F5BC File Offset: 0x0000D7BC
		public unsafe void DecoderUpdateDownsampling(VideoDecoder decoderRef, VideoSampleDescription outputDescRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoDecoder>(decoderRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &outputDescRef, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000F60C File Offset: 0x0000D80C
		public unsafe void VideoProcessorSetOutputColorSpace1(VideoProcessor videoProcessorRef, ColorSpaceType colorSpace)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, colorSpace, *(*(IntPtr*)this._nativePointer + (IntPtr)70 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000F64C File Offset: 0x0000D84C
		public unsafe void VideoProcessorSetOutputShaderUsage(VideoProcessor videoProcessorRef, RawBool shaderUsage)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, shaderUsage, *(*(IntPtr*)this._nativePointer + (IntPtr)71 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000F68C File Offset: 0x0000D88C
		public unsafe void VideoProcessorGetOutputColorSpace1(VideoProcessor videoProcessorRef, out ColorSpaceType colorSpaceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (ColorSpaceType* ptr = &colorSpaceRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)72 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000F6D4 File Offset: 0x0000D8D4
		public unsafe void VideoProcessorGetOutputShaderUsage(VideoProcessor videoProcessorRef, out RawBool shaderUsageRef)
		{
			IntPtr value = IntPtr.Zero;
			shaderUsageRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawBool* ptr = &shaderUsageRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)73 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000F724 File Offset: 0x0000D924
		public unsafe void VideoProcessorSetStreamColorSpace1(VideoProcessor videoProcessorRef, int streamIndex, ColorSpaceType colorSpace)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, streamIndex, colorSpace, *(*(IntPtr*)this._nativePointer + (IntPtr)74 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000F764 File Offset: 0x0000D964
		public unsafe void VideoProcessorSetStreamMirror(VideoProcessor videoProcessorRef, int streamIndex, RawBool enable, RawBool flipHorizontal, RawBool flipVertical)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, streamIndex, enable, flipHorizontal, flipVertical, *(*(IntPtr*)this._nativePointer + (IntPtr)75 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000F7A8 File Offset: 0x0000D9A8
		public unsafe void VideoProcessorGetStreamColorSpace1(VideoProcessor videoProcessorRef, int streamIndex, out ColorSpaceType colorSpaceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (ColorSpaceType* ptr = &colorSpaceRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)76 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000F7F0 File Offset: 0x0000D9F0
		public unsafe void VideoProcessorGetStreamMirror(VideoProcessor videoProcessorRef, int streamIndex, out RawBool enableRef, out RawBool flipHorizontalRef, out RawBool flipVerticalRef)
		{
			IntPtr value = IntPtr.Zero;
			enableRef = default(RawBool);
			flipHorizontalRef = default(RawBool);
			flipVerticalRef = default(RawBool);
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			fixed (RawBool* ptr = &flipVerticalRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &flipHorizontalRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (RawBool* ptr5 = &enableRef)
					{
						void* ptr6 = (void*)ptr5;
						calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, streamIndex, ptr6, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)77 * (IntPtr)sizeof(void*)));
					}
				}
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000F86C File Offset: 0x0000DA6C
		public unsafe void VideoProcessorGetBehaviorHints(VideoProcessor videoProcessorRef, int outputWidth, int outputHeight, Format outputFormat, int streamCount, VideoProcessorStreamBehaviorHint[] streamsRef, out int behaviorHintsRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessor>(videoProcessorRef);
			Result result;
			fixed (int* ptr = &behaviorHintsRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoProcessorStreamBehaviorHint[] array = streamsRef)
				{
					void* ptr3;
					if (streamsRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, outputWidth, outputHeight, outputFormat, streamCount, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)78 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}
