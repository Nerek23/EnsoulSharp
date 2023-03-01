using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000060 RID: 96
	[Guid("25483823-cd46-4c7d-86ca-47aa95b837bd")]
	public class Factory3 : Factory2
	{
		// Token: 0x06000196 RID: 406 RVA: 0x00006B30 File Offset: 0x00004D30
		public Factory3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00006B39 File Offset: 0x00004D39
		public new static explicit operator Factory3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory3(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00006B50 File Offset: 0x00004D50
		public int CreationFlags
		{
			get
			{
				return this.GetCreationFlags();
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00006B58 File Offset: 0x00004D58
		internal unsafe int GetCreationFlags()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
		}
	}
}
