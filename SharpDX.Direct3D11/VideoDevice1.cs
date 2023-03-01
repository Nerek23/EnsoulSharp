using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C9 RID: 201
	[Guid("29DA1D51-1321-4454-804B-F5FC9F861F0F")]
	public class VideoDevice1 : VideoDevice
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x0001023E File Offset: 0x0000E43E
		public VideoDevice1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00010247 File Offset: 0x0000E447
		public new static explicit operator VideoDevice1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoDevice1(nativePtr);
			}
			return null;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00010260 File Offset: 0x0000E460
		public unsafe void GetCryptoSessionPrivateDataSize(Guid cryptoTypeRef, Guid? decoderProfileRef, Guid keyExchangeTypeRef, out int privateInputSizeRef, out int privateOutputSizeRef)
		{
			Guid value;
			if (decoderProfileRef != null)
			{
				value = decoderProfileRef.Value;
			}
			Result result;
			fixed (int* ptr = &privateOutputSizeRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &privateInputSizeRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &cryptoTypeRef, (decoderProfileRef == null) ? null : (&value), &keyExchangeTypeRef, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000102D8 File Offset: 0x0000E4D8
		public unsafe void GetVideoDecoderCaps(Guid decoderProfileRef, int sampleWidth, int sampleHeight, Rational frameRateRef, int bitRate, Guid? cryptoTypeRef, out int decoderCapsRef)
		{
			Guid value;
			if (cryptoTypeRef != null)
			{
				value = cryptoTypeRef.Value;
			}
			Result result;
			fixed (int* ptr = &decoderCapsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, &decoderProfileRef, sampleWidth, sampleHeight, &frameRateRef, bitRate, (cryptoTypeRef == null) ? null : (&value), ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00010348 File Offset: 0x0000E548
		public unsafe void CheckVideoDecoderDownsampling(ref VideoDecoderDescription inputDescRef, ColorSpaceType inputColorSpace, ref VideoDecoderConfig inputConfigRef, Rational frameRateRef, VideoSampleDescription outputDescRef, out RawBool supportedRef, out RawBool realTimeHintRef)
		{
			supportedRef = default(RawBool);
			realTimeHintRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &realTimeHintRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawBool* ptr3 = &supportedRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (VideoDecoderConfig* ptr5 = &inputConfigRef)
					{
						void* ptr6 = (void*)ptr5;
						fixed (VideoDecoderDescription* ptr7 = &inputDescRef)
						{
							void* ptr8 = (void*)ptr7;
							result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr8, inputColorSpace, ptr6, &frameRateRef, &outputDescRef, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000103CC File Offset: 0x0000E5CC
		public unsafe void RecommendVideoDecoderDownsampleParameters(ref VideoDecoderDescription inputDescRef, ColorSpaceType inputColorSpace, ref VideoDecoderConfig inputConfigRef, Rational frameRateRef, out VideoSampleDescription recommendedOutputDescRef)
		{
			recommendedOutputDescRef = default(VideoSampleDescription);
			Result result;
			fixed (VideoSampleDescription* ptr = &recommendedOutputDescRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoDecoderConfig* ptr3 = &inputConfigRef)
				{
					void* ptr4 = (void*)ptr3;
					fixed (VideoDecoderDescription* ptr5 = &inputDescRef)
					{
						void* ptr6 = (void*)ptr5;
						result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr6, inputColorSpace, ptr4, &frameRateRef, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
		}
	}
}
