using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200030B RID: 779
	[Guid("82237326-8111-4f7c-bcf4-b5c1175564fe")]
	internal class GdiMetafileSinkNative : ComObject, GdiMetafileSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000DB0 RID: 3504 RVA: 0x00002A7F File Offset: 0x00000C7F
		public GdiMetafileSinkNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00025EB1 File Offset: 0x000240B1
		public new static explicit operator GdiMetafileSinkNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiMetafileSinkNative(nativePtr);
			}
			return null;
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00025EC8 File Offset: 0x000240C8
		internal unsafe void ProcessRecord_(int recordType, IntPtr recordData, int recordDataSize)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, recordType, (void*)recordData, recordDataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
