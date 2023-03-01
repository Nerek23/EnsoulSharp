using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000061 RID: 97
	[Guid("7632e1f5-ee65-4dca-87fd-84cd75f8838d")]
	public class Factory5 : Factory4
	{
		// Token: 0x0600019A RID: 410 RVA: 0x00006B78 File Offset: 0x00004D78
		public Factory5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006B81 File Offset: 0x00004D81
		public new static explicit operator Factory5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory5(nativePtr);
			}
			return null;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006B98 File Offset: 0x00004D98
		public unsafe void CheckFeatureSupport(Feature feature, IntPtr featureSupportDataRef, int featureSupportDataSize)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, feature, (void*)featureSupportDataRef, featureSupportDataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
