using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000BF RID: 191
	[Guid("193dacdf-0db2-4c05-a55c-ef06cac56fd9")]
	public class RefTrackingOptions : ComObject
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x0000383E File Offset: 0x00001A3E
		public RefTrackingOptions(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000EE59 File Offset: 0x0000D059
		public new static explicit operator RefTrackingOptions(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RefTrackingOptions(nativePtr);
			}
			return null;
		}

		// Token: 0x17000065 RID: 101
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x0000EE70 File Offset: 0x0000D070
		public int TrackingOptions
		{
			set
			{
				this.SetTrackingOptions(value);
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000EE7C File Offset: 0x0000D07C
		internal unsafe void SetTrackingOptions(int uOptions)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, uOptions, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
