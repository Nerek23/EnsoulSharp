using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000067 RID: 103
	[Guid("F92F19D2-3ADE-45A6-A20C-F6F1EA90554B")]
	public class ISwapChainPanelNative : ComObject
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x0000272E File Offset: 0x0000092E
		public ISwapChainPanelNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000707A File Offset: 0x0000527A
		public new static explicit operator ISwapChainPanelNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ISwapChainPanelNative(nativePtr);
			}
			return null;
		}

		// Token: 0x17000032 RID: 50
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00007091 File Offset: 0x00005291
		public SwapChain SwapChain
		{
			set
			{
				this.SetSwapChain(value);
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000709C File Offset: 0x0000529C
		internal unsafe void SetSwapChain(SwapChain swapChain)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SwapChain>(swapChain);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
