using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000141 RID: 321
	[Guid("F9D711C3-9777-40AE-87E8-3E5AF9BF0948")]
	public class RenderingParams2 : RenderingParams1
	{
		// Token: 0x060005F3 RID: 1523 RVA: 0x00013424 File Offset: 0x00011624
		public RenderingParams2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001342D File Offset: 0x0001162D
		public new static explicit operator RenderingParams2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderingParams2(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x00013444 File Offset: 0x00011644
		public GridFitMode GridFitMode
		{
			get
			{
				return this.GetGridFitMode();
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0001344C File Offset: 0x0001164C
		internal unsafe GridFitMode GetGridFitMode()
		{
			return calli(SharpDX.DirectWrite.GridFitMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}
	}
}
