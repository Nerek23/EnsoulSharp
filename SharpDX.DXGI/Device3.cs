using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200005D RID: 93
	[Guid("6007896c-3244-4afd-bf18-a6d3beda5023")]
	public class Device3 : Device2
	{
		// Token: 0x06000185 RID: 389 RVA: 0x00006811 File Offset: 0x00004A11
		public Device3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000681A File Offset: 0x00004A1A
		public new static explicit operator Device3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device3(nativePtr);
			}
			return null;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006831 File Offset: 0x00004A31
		public unsafe void Trim()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}
	}
}
