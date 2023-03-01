using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000027 RID: 39
	[Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
	public class SwapChain : DeviceChild
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00004E90 File Offset: 0x00003090
		public SwapChain(Factory factory, ComObject device, SwapChainDescription description) : base(IntPtr.Zero)
		{
			factory.CreateSwapChain(device, ref description, this);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00004EA8 File Offset: 0x000030A8
		public T GetBackBuffer<T>(int index) where T : ComObject
		{
			IntPtr comObjectPtr;
			this.GetBuffer(index, Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00004ED4 File Offset: 0x000030D4
		public FrameStatistics FrameStatistics
		{
			get
			{
				FrameStatistics result;
				this.TryGetFrameStatistics(out result).CheckError();
				return result;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00004EF4 File Offset: 0x000030F4
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00004F1A File Offset: 0x0000311A
		public bool IsFullScreen
		{
			get
			{
				RawBool booleanValue;
				Output output;
				this.GetFullscreenState(out booleanValue, out output);
				if (output != null)
				{
					output.Dispose();
				}
				return booleanValue;
			}
			set
			{
				this.SetFullscreenState(value, null);
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004F2C File Offset: 0x0000312C
		public Result Present(int syncInterval, PresentFlags flags)
		{
			Result result = this.TryPresent(syncInterval, flags);
			result.CheckError();
			return result;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004C1F File Offset: 0x00002E1F
		public SwapChain(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004F4A File Offset: 0x0000314A
		public new static explicit operator SwapChain(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwapChain(nativePtr);
			}
			return null;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00004F64 File Offset: 0x00003164
		public SwapChainDescription Description
		{
			get
			{
				SwapChainDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00004F7C File Offset: 0x0000317C
		public Output ContainingOutput
		{
			get
			{
				Output result;
				this.GetContainingOutput(out result);
				return result;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00004F94 File Offset: 0x00003194
		public int LastPresentCount
		{
			get
			{
				int result;
				this.GetLastPresentCount(out result);
				return result;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004FAA File Offset: 0x000031AA
		public unsafe Result TryPresent(int syncInterval, PresentFlags flags)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, syncInterval, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00004FD0 File Offset: 0x000031D0
		internal unsafe void GetBuffer(int buffer, Guid riid, out IntPtr surfaceOut)
		{
			Result result;
			fixed (IntPtr* ptr = &surfaceOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, buffer, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005018 File Offset: 0x00003218
		public unsafe void SetFullscreenState(RawBool fullscreen, Output targetRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Output>(targetRef);
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, fullscreen, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005064 File Offset: 0x00003264
		public unsafe void GetFullscreenState(out RawBool fullscreenRef, out Output targetOut)
		{
			fullscreenRef = default(RawBool);
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RawBool* ptr = &fullscreenRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				targetOut = new Output(zero);
			}
			else
			{
				targetOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000050D0 File Offset: 0x000032D0
		internal unsafe void GetDescription(out SwapChainDescription descRef)
		{
			descRef = default(SwapChainDescription);
			Result result;
			fixed (SwapChainDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005118 File Offset: 0x00003318
		public unsafe void ResizeBuffers(int bufferCount, int width, int height, Format newFormat, SwapChainFlags swapChainFlags)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, bufferCount, width, height, newFormat, swapChainFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005158 File Offset: 0x00003358
		public unsafe void ResizeTarget(ref ModeDescription newTargetParametersRef)
		{
			Result result;
			fixed (ModeDescription* ptr = &newTargetParametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000519C File Offset: 0x0000339C
		internal unsafe void GetContainingOutput(out Output outputOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				outputOut = new Output(zero);
			}
			else
			{
				outputOut = null;
			}
			result.CheckError();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000051F8 File Offset: 0x000033F8
		public unsafe Result TryGetFrameStatistics(out FrameStatistics statsRef)
		{
			statsRef = default(FrameStatistics);
			Result result;
			fixed (FrameStatistics* ptr = &statsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00005238 File Offset: 0x00003438
		internal unsafe void GetLastPresentCount(out int lastPresentCountRef)
		{
			Result result;
			fixed (int* ptr = &lastPresentCountRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
