using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000140 RID: 320
	[Guid("94413cf4-a6fc-4248-8b50-6674348fcad3")]
	public class RenderingParams1 : RenderingParams
	{
		// Token: 0x060005EF RID: 1519 RVA: 0x000133DD File Offset: 0x000115DD
		public RenderingParams1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x000133E6 File Offset: 0x000115E6
		public new static explicit operator RenderingParams1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderingParams1(nativePtr);
			}
			return null;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x000133FD File Offset: 0x000115FD
		public float GrayscaleEnhancedContrast
		{
			get
			{
				return this.GetGrayscaleEnhancedContrast();
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00013405 File Offset: 0x00011605
		internal unsafe float GetGrayscaleEnhancedContrast()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}
	}
}
