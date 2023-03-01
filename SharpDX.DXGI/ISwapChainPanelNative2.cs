using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000068 RID: 104
	[Guid("D5A2F60C-37B2-44A2-937B-8D8EB9726821")]
	public class ISwapChainPanelNative2 : ISwapChainPanelNative
	{
		// Token: 0x060001BA RID: 442 RVA: 0x000070E6 File Offset: 0x000052E6
		public ISwapChainPanelNative2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000070EF File Offset: 0x000052EF
		public new static explicit operator ISwapChainPanelNative2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ISwapChainPanelNative2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000033 RID: 51
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00007106 File Offset: 0x00005306
		public IntPtr SwapChainHandle
		{
			set
			{
				this.SetSwapChainHandle(value);
			}
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00007110 File Offset: 0x00005310
		internal unsafe void SetSwapChainHandle(IntPtr swapChainHandle)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)swapChainHandle, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
