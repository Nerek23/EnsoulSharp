using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B1 RID: 177
	[Guid("4b35d0cd-1e15-4258-9c98-1b1333f6dd3b")]
	public class Asynchronous : DeviceChild
	{
		// Token: 0x0600035F RID: 863 RVA: 0x00002075 File Offset: 0x00000275
		public Asynchronous(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000D765 File Offset: 0x0000B965
		public new static explicit operator Asynchronous(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Asynchronous(nativePtr);
			}
			return null;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000D77C File Offset: 0x0000B97C
		public int DataSize
		{
			get
			{
				return this.GetDataSize();
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000D784 File Offset: 0x0000B984
		internal unsafe int GetDataSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}
	}
}
