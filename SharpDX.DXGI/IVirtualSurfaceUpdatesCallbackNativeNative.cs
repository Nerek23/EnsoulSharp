using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000015 RID: 21
	[Guid("dbf2e947-8e6c-4254-9eee-7738f71386c9")]
	internal class IVirtualSurfaceUpdatesCallbackNativeNative : ComObject, IVirtualSurfaceUpdatesCallbackNative, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00003FAA File Offset: 0x000021AA
		public void UpdatesNeeded()
		{
			this.UpdatesNeeded_();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000272E File Offset: 0x0000092E
		public IVirtualSurfaceUpdatesCallbackNativeNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003FB2 File Offset: 0x000021B2
		public new static explicit operator IVirtualSurfaceUpdatesCallbackNativeNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new IVirtualSurfaceUpdatesCallbackNativeNative(nativePtr);
			}
			return null;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003FCC File Offset: 0x000021CC
		internal unsafe void UpdatesNeeded_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
