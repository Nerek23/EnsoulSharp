using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200030A RID: 778
	[Guid("fd0ecb6b-91e6-411e-8655-395e760f91b4")]
	internal class GdiMetafileSink1Native : GdiMetafileSinkNative, GdiMetafileSink1, GdiMetafileSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000DAD RID: 3501 RVA: 0x00025E4F File Offset: 0x0002404F
		public GdiMetafileSink1Native(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00025E58 File Offset: 0x00024058
		public new static explicit operator GdiMetafileSink1Native(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GdiMetafileSink1Native(nativePtr);
			}
			return null;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00025E70 File Offset: 0x00024070
		internal unsafe void ProcessRecord_(int recordType, IntPtr recordData, int recordDataSize, int flags)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, recordType, (void*)recordData, recordDataSize, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
