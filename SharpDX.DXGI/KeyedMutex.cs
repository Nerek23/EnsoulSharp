using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000069 RID: 105
	[Guid("9d8e1289-d7b3-465f-8126-250e349af85d")]
	public class KeyedMutex : DeviceChild
	{
		// Token: 0x060001BE RID: 446 RVA: 0x00004C1F File Offset: 0x00002E1F
		public KeyedMutex(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000714D File Offset: 0x0000534D
		public new static explicit operator KeyedMutex(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new KeyedMutex(nativePtr);
			}
			return null;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00007164 File Offset: 0x00005364
		public unsafe Result Acquire(long key, int dwMilliseconds)
		{
			Result result = calli(System.Int32(System.Void*,System.Int64,System.Int32), this._nativePointer, key, dwMilliseconds, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			result.CheckError();
			return result;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000071A0 File Offset: 0x000053A0
		public unsafe void Release(long key)
		{
			calli(System.Int32(System.Void*,System.Int64), this._nativePointer, key, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
