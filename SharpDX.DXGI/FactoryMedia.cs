using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000062 RID: 98
	[Guid("41e7d1f2-a591-4f7b-a2e5-fa9c843e1c12")]
	public class FactoryMedia : ComObject
	{
		// Token: 0x0600019D RID: 413 RVA: 0x0000272E File Offset: 0x0000092E
		public FactoryMedia(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006BD8 File Offset: 0x00004DD8
		public new static explicit operator FactoryMedia(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FactoryMedia(nativePtr);
			}
			return null;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00006BF0 File Offset: 0x00004DF0
		public unsafe void CreateSwapChainForCompositionSurfaceHandle(IUnknown deviceRef, IntPtr hSurface, ref SwapChainDescription1 descRef, Output restrictToOutputRef, out SwapChain1 swapChainOut)
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)hSurface, ptr2, (void*)value2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				swapChainOut = new SwapChain1(zero);
			}
			else
			{
				swapChainOut = null;
			}
			result.CheckError();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00006C88 File Offset: 0x00004E88
		public unsafe void CreateDecodeSwapChainForCompositionSurfaceHandle(IUnknown deviceRef, IntPtr hSurface, DecodeSwapChainDescription descRef, Resource yuvDecodeBuffersRef, Output restrictToOutputRef, out DecodeSwapChain swapChainOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			value2 = CppObject.ToCallbackPtr<Resource>(yuvDecodeBuffersRef);
			value3 = CppObject.ToCallbackPtr<Output>(restrictToOutputRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)hSurface, &descRef, (void*)value2, (void*)value3, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				swapChainOut = new DecodeSwapChain(zero);
			}
			else
			{
				swapChainOut = null;
			}
			result.CheckError();
		}
	}
}
