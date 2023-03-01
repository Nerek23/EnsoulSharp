using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x02000075 RID: 117
	[Guid("4776F9CD-9517-45FA-BF24-E89C5EC5C60C")]
	internal class ProgressCallback : ComObject
	{
		// Token: 0x0600025E RID: 606 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ProgressCallback(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00009C85 File Offset: 0x00007E85
		public new static explicit operator ProgressCallback(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ProgressCallback(nativePtr);
			}
			return null;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00009C9C File Offset: 0x00007E9C
		public unsafe void Notify(int frameNum, ProgressOperation operation, double dblProgress)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Double), this._nativePointer, frameNum, operation, dblProgress, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
