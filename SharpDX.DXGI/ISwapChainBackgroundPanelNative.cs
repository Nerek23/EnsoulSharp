using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000066 RID: 102
	[Guid("43bebd4e-add5-4035-8f85-5608d08e9dc9")]
	public class ISwapChainBackgroundPanelNative : ComObject
	{
		// Token: 0x060001B2 RID: 434 RVA: 0x0000272E File Offset: 0x0000092E
		public ISwapChainBackgroundPanelNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000700F File Offset: 0x0000520F
		public new static explicit operator ISwapChainBackgroundPanelNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ISwapChainBackgroundPanelNative(nativePtr);
			}
			return null;
		}

		// Token: 0x17000031 RID: 49
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00007026 File Offset: 0x00005226
		public SwapChain SwapChain
		{
			set
			{
				this.SetSwapChain(value);
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00007030 File Offset: 0x00005230
		internal unsafe void SetSwapChain(SwapChain swapChain)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SwapChain>(swapChain);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
