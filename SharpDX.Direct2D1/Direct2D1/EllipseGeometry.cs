using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001DE RID: 478
	[Guid("2cd906a4-12e2-11dc-9fed-001143a055f9")]
	public class EllipseGeometry : Geometry
	{
		// Token: 0x060009C6 RID: 2502 RVA: 0x0001C748 File Offset: 0x0001A948
		public EllipseGeometry(Factory factory, Ellipse ellipse) : base(IntPtr.Zero)
		{
			factory.CreateEllipseGeometry(ellipse, this);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0001C75D File Offset: 0x0001A95D
		public EllipseGeometry(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0001C766 File Offset: 0x0001A966
		public new static explicit operator EllipseGeometry(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new EllipseGeometry(nativePtr);
			}
			return null;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x0001C780 File Offset: 0x0001A980
		public Ellipse Ellipse
		{
			get
			{
				Ellipse result;
				this.GetEllipse(out result);
				return result;
			}
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0001C798 File Offset: 0x0001A998
		internal unsafe void GetEllipse(out Ellipse ellipse)
		{
			ellipse = default(Ellipse);
			fixed (Ellipse* ptr = &ellipse)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
