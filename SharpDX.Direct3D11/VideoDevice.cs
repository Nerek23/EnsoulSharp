using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C8 RID: 200
	[Guid("10EC4D5B-975A-4689-B9E4-D0AAC30FE333")]
	public class VideoDevice : ComObject
	{
		// Token: 0x06000401 RID: 1025 RVA: 0x0000383E File Offset: 0x00001A3E
		public VideoDevice(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000FB76 File Offset: 0x0000DD76
		public new static explicit operator VideoDevice(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VideoDevice(nativePtr);
			}
			return null;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000FB8D File Offset: 0x0000DD8D
		public int VideoDecoderProfileCount
		{
			get
			{
				return this.GetVideoDecoderProfileCount();
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000FB98 File Offset: 0x0000DD98
		public unsafe void CreateVideoDecoder(ref VideoDecoderDescription videoDescRef, ref VideoDecoderConfig configRef, out VideoDecoder decoderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (VideoDecoderConfig* ptr = &configRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoDecoderDescription* ptr3 = &videoDescRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
			if (zero != IntPtr.Zero)
			{
				decoderOut = new VideoDecoder(zero);
			}
			else
			{
				decoderOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000FC0C File Offset: 0x0000DE0C
		public unsafe void CreateVideoProcessor(VideoProcessorEnumerator enumRef, int rateConversionIndex, out VideoProcessor videoProcessorOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VideoProcessorEnumerator>(enumRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, rateConversionIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				videoProcessorOut = new VideoProcessor(zero);
			}
			else
			{
				videoProcessorOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000FC7C File Offset: 0x0000DE7C
		public unsafe void CreateAuthenticatedChannel(AuthenticatedChannelType channelType, out AuthenticatedChannel authenticatedChannelOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, channelType, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				authenticatedChannelOut = new AuthenticatedChannel(zero);
			}
			else
			{
				authenticatedChannelOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000FCD8 File Offset: 0x0000DED8
		public unsafe void CreateCryptoSession(Guid cryptoTypeRef, Guid? decoderProfileRef, Guid keyExchangeTypeRef, out CryptoSession cryptoSessionOut)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (decoderProfileRef != null)
			{
				value = decoderProfileRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &cryptoTypeRef, (decoderProfileRef == null) ? null : (&value), &keyExchangeTypeRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				cryptoSessionOut = new CryptoSession(zero);
			}
			else
			{
				cryptoSessionOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000FD5C File Offset: 0x0000DF5C
		public unsafe void CreateVideoDecoderOutputView(Resource resourceRef, ref VideoDecoderOutputViewDescription descRef, out VideoDecoderOutputView vDOVViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			Result result;
			fixed (VideoDecoderOutputViewDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				vDOVViewOut = new VideoDecoderOutputView(zero);
			}
			else
			{
				vDOVViewOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000FDD8 File Offset: 0x0000DFD8
		public unsafe void CreateVideoProcessorInputView(Resource resourceRef, VideoProcessorEnumerator enumRef, VideoProcessorInputViewDescription descRef, out VideoProcessorInputView vPIViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			value2 = CppObject.ToCallbackPtr<VideoProcessorEnumerator>(enumRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, &descRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				vPIViewOut = new VideoProcessorInputView(zero);
			}
			else
			{
				vPIViewOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000FE60 File Offset: 0x0000E060
		public unsafe void CreateVideoProcessorOutputView(Resource resourceRef, VideoProcessorEnumerator enumRef, VideoProcessorOutputViewDescription descRef, out VideoProcessorOutputView vPOViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			value2 = CppObject.ToCallbackPtr<VideoProcessorEnumerator>(enumRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, &descRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				vPOViewOut = new VideoProcessorOutputView(zero);
			}
			else
			{
				vPOViewOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
		public unsafe void CreateVideoProcessorEnumerator(ref VideoProcessorContentDescription descRef, out VideoProcessorEnumerator enumOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (VideoProcessorContentDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				enumOut = new VideoProcessorEnumerator(zero);
			}
			else
			{
				enumOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000FF4C File Offset: 0x0000E14C
		internal unsafe int GetVideoDecoderProfileCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000FF6C File Offset: 0x0000E16C
		public unsafe void GetVideoDecoderProfile(int index, out Guid decoderProfileRef)
		{
			decoderProfileRef = default(Guid);
			Result result;
			fixed (Guid* ptr = &decoderProfileRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000FFB8 File Offset: 0x0000E1B8
		public unsafe void CheckVideoDecoderFormat(Guid decoderProfileRef, Format format, out RawBool supportedRef)
		{
			supportedRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &supportedRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &decoderProfileRef, format, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00010004 File Offset: 0x0000E204
		public unsafe void GetVideoDecoderConfigCount(ref VideoDecoderDescription descRef, out int countRef)
		{
			Result result;
			fixed (int* ptr = &countRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoDecoderDescription* ptr3 = &descRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00010054 File Offset: 0x0000E254
		public unsafe void GetVideoDecoderConfig(ref VideoDecoderDescription descRef, int index, out VideoDecoderConfig configRef)
		{
			configRef = default(VideoDecoderConfig);
			Result result;
			fixed (VideoDecoderConfig* ptr = &configRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (VideoDecoderDescription* ptr3 = &descRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr4, index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000100AC File Offset: 0x0000E2AC
		public unsafe void GetContentProtectionCaps(Guid? cryptoTypeRef, Guid? decoderProfileRef, out VideoContentProtectionCaps capsRef)
		{
			capsRef = default(VideoContentProtectionCaps);
			Guid value;
			if (cryptoTypeRef != null)
			{
				value = cryptoTypeRef.Value;
			}
			Guid value2;
			if (decoderProfileRef != null)
			{
				value2 = decoderProfileRef.Value;
			}
			Result result;
			fixed (VideoContentProtectionCaps* ptr = &capsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (cryptoTypeRef == null) ? null : (&value), (decoderProfileRef == null) ? null : (&value2), ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001013C File Offset: 0x0000E33C
		public unsafe void CheckCryptoKeyExchange(Guid cryptoTypeRef, Guid? decoderProfileRef, int index, out Guid keyExchangeTypeRef)
		{
			keyExchangeTypeRef = default(Guid);
			Guid value;
			if (decoderProfileRef != null)
			{
				value = decoderProfileRef.Value;
			}
			Result result;
			fixed (Guid* ptr = &keyExchangeTypeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &cryptoTypeRef, (decoderProfileRef == null) ? null : (&value), index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000101AC File Offset: 0x0000E3AC
		public unsafe void SetPrivateData(Guid guid, int dataSize, IntPtr dataRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &guid, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000101F0 File Offset: 0x0000E3F0
		public unsafe void SetPrivateDataInterface(Guid guid, IUnknown dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(dataRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &guid, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
