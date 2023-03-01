using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200006D RID: 109
	[Guid("95c75a6e-3e8c-4ec2-85a8-aebcc551e59b")]
	internal class DevelopRawNotificationCallback : ComObject
	{
		// Token: 0x0600022D RID: 557 RVA: 0x00002A7F File Offset: 0x00000C7F
		public DevelopRawNotificationCallback(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000090FB File Offset: 0x000072FB
		public new static explicit operator DevelopRawNotificationCallback(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DevelopRawNotificationCallback(nativePtr);
			}
			return null;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00009114 File Offset: 0x00007314
		public unsafe void Notify(int notificationMask)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, notificationMask, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
