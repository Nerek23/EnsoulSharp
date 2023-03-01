using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000142 RID: 322
	[Guid("B7924BAA-391B-412A-8C5C-E44CC2D867DC")]
	public class RenderingParams3 : RenderingParams2
	{
		// Token: 0x060005F7 RID: 1527 RVA: 0x0001346C File Offset: 0x0001166C
		public RenderingParams3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00013475 File Offset: 0x00011675
		public new static explicit operator RenderingParams3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderingParams3(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0001348C File Offset: 0x0001168C
		public RenderingMode1 RenderingMode1
		{
			get
			{
				return this.GetRenderingMode1();
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00013494 File Offset: 0x00011694
		internal unsafe RenderingMode1 GetRenderingMode1()
		{
			return calli(SharpDX.DirectWrite.RenderingMode1(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}
	}
}
