using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200000E RID: 14
	[Guid("50c83a1c-e072-4c48-87b0-3630fa36a6d0")]
	public class Factory2 : Factory1
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00002D4C File Offset: 0x00000F4C
		public Factory2(bool debug = false) : this(IntPtr.Zero)
		{
			IntPtr nativePointer;
			DXGI.CreateDXGIFactory2(debug ? 1 : 0, Utilities.GetGuidFromType(base.GetType()), out nativePointer);
			base.NativePointer = nativePointer;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D84 File Offset: 0x00000F84
		public Factory2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D8D File Offset: 0x00000F8D
		public new static explicit operator Factory2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory2(nativePtr);
			}
			return null;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002DA4 File Offset: 0x00000FA4
		public RawBool IsWindowedStereoEnabled
		{
			get
			{
				return this.IsWindowedStereoEnabled_();
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002DAC File Offset: 0x00000FAC
		internal unsafe RawBool IsWindowedStereoEnabled_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002DCC File Offset: 0x00000FCC
		internal unsafe void CreateSwapChainForHwnd(IUnknown deviceRef, IntPtr hWnd, ref SwapChainDescription1 descRef, SwapChainFullScreenDescription? fullscreenDescRef, Output restrictToOutputRef, SwapChain1 swapChainOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			SwapChainFullScreenDescription value3;
			if (fullscreenDescRef != null)
			{
				value3 = fullscreenDescRef.Value;
			}
			value2 = CppObject.ToCallbackPtr<Output>(restrictToOutputRef);
			Result result;
			fixed (SwapChainDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)hWnd, ptr2, (fullscreenDescRef == null) ? null : (&value3), (void*)value2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			swapChainOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002E74 File Offset: 0x00001074
		internal unsafe void CreateSwapChainForCoreWindow(IUnknown deviceRef, IUnknown windowRef, ref SwapChainDescription1 descRef, Output restrictToOutputRef, SwapChain1 swapChainOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			value2 = CppObject.ToCallbackPtr<IUnknown>(windowRef);
			value3 = CppObject.ToCallbackPtr<Output>(restrictToOutputRef);
			Result result;
			fixed (SwapChainDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, ptr2, (void*)value3, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			swapChainOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002F08 File Offset: 0x00001108
		public unsafe void GetSharedResourceAdapterLuid(IntPtr hResource, out long luidRef)
		{
			Result result;
			fixed (long* ptr = &luidRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hResource, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F50 File Offset: 0x00001150
		public unsafe void RegisterStereoStatusWindow(IntPtr windowHandle, int wMsg, out int dwCookieRef)
		{
			Result result;
			fixed (int* ptr = &dwCookieRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)windowHandle, wMsg, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002F98 File Offset: 0x00001198
		public unsafe void RegisterStereoStatusEvent(IntPtr hEvent, out int dwCookieRef)
		{
			Result result;
			fixed (int* ptr = &dwCookieRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hEvent, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002FDF File Offset: 0x000011DF
		public unsafe void UnregisterStereoStatus(int dwCookie)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, dwCookie, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003000 File Offset: 0x00001200
		public unsafe void RegisterOcclusionStatusWindow(IntPtr windowHandle, int wMsg, out int dwCookieRef)
		{
			Result result;
			fixed (int* ptr = &dwCookieRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)windowHandle, wMsg, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003048 File Offset: 0x00001248
		public unsafe void RegisterOcclusionStatusEvent(IntPtr hEvent, out int dwCookieRef)
		{
			Result result;
			fixed (int* ptr = &dwCookieRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hEvent, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000308F File Offset: 0x0000128F
		public unsafe void UnregisterOcclusionStatus(int dwCookie)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, dwCookie, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000030B0 File Offset: 0x000012B0
		internal unsafe void CreateSwapChainForComposition(IUnknown deviceRef, ref SwapChainDescription1 descRef, Output restrictToOutputRef, SwapChain1 swapChainOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			value2 = CppObject.ToCallbackPtr<Output>(restrictToOutputRef);
			Result result;
			fixed (SwapChainDescription1* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, (void*)value2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			}
			swapChainOut.NativePointer = zero;
			result.CheckError();
		}
	}
}
