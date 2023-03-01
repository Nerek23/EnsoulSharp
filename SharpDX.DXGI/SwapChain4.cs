using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000070 RID: 112
	[Guid("3D585D5A-BD4A-489E-B1F4-3DBCB6452FFB")]
	public class SwapChain4 : SwapChain3
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x000076F6 File Offset: 0x000058F6
		public SwapChain4(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000076FF File Offset: 0x000058FF
		public new static explicit operator SwapChain4(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SwapChain4(nativePtr);
			}
			return null;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00007718 File Offset: 0x00005918
		public unsafe void SetHDRMetaData(HdrMetadataType type, int size, IntPtr metaDataRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, type, size, (void*)metaDataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
