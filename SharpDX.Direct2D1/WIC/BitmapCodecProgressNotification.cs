using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000068 RID: 104
	[Guid("64C1024E-C3CF-4462-8078-88C2B11C46D9")]
	internal class BitmapCodecProgressNotification : ComObject
	{
		// Token: 0x060001E0 RID: 480 RVA: 0x00002A7F File Offset: 0x00000C7F
		public BitmapCodecProgressNotification(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00008341 File Offset: 0x00006541
		public new static explicit operator BitmapCodecProgressNotification(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BitmapCodecProgressNotification(nativePtr);
			}
			return null;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00008358 File Offset: 0x00006558
		internal unsafe void RegisterProgressNotification(FunctionCallback fnProgressNotificationRef, IntPtr vDataRef, int progressFlags)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, fnProgressNotificationRef, (void*)vDataRef, progressFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
