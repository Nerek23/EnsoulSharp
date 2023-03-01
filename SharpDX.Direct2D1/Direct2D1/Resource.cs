using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200030F RID: 783
	[Guid("2cd90691-12e2-11dc-9fed-001143a055f9")]
	public class Resource : ComObject
	{
		// Token: 0x06000DC3 RID: 3523 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Resource(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00026039 File Offset: 0x00024239
		public new static explicit operator Resource(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Resource(nativePtr);
			}
			return null;
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00026050 File Offset: 0x00024250
		public Factory Factory
		{
			get
			{
				Factory result;
				this.GetFactory(out result);
				return result;
			}
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00026068 File Offset: 0x00024268
		internal unsafe void GetFactory(out Factory factory)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				factory = new Factory(zero);
				return;
			}
			factory = null;
		}
	}
}
