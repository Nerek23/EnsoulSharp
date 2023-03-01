using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000215 RID: 533
	[Guid("2cd906a2-12e2-11dc-9fed-001143a055f9")]
	public class RectangleGeometry : Geometry
	{
		// Token: 0x06000BBA RID: 3002 RVA: 0x0002117D File Offset: 0x0001F37D
		public RectangleGeometry(Factory factory, RawRectangleF rectangle) : base(IntPtr.Zero)
		{
			factory.CreateRectangleGeometry(rectangle, this);
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0001C75D File Offset: 0x0001A95D
		public RectangleGeometry(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x00021192 File Offset: 0x0001F392
		public new static explicit operator RectangleGeometry(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RectangleGeometry(nativePtr);
			}
			return null;
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x000211AC File Offset: 0x0001F3AC
		public RawRectangleF Rectangle
		{
			get
			{
				RawRectangleF result;
				this.GetRectangle(out result);
				return result;
			}
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x000211C4 File Offset: 0x0001F3C4
		internal unsafe void GetRectangle(out RawRectangleF rect)
		{
			rect = default(RawRectangleF);
			fixed (RawRectangleF* ptr = &rect)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
