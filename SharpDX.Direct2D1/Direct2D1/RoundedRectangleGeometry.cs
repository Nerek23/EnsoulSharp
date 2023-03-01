using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200021B RID: 539
	[Guid("2cd906a3-12e2-11dc-9fed-001143a055f9")]
	public class RoundedRectangleGeometry : Geometry
	{
		// Token: 0x06000C2F RID: 3119 RVA: 0x00022849 File Offset: 0x00020A49
		public RoundedRectangleGeometry(Factory factory, RoundedRectangle roundedRectangle) : base(IntPtr.Zero)
		{
			factory.CreateRoundedRectangleGeometry(ref roundedRectangle, this);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0001C75D File Offset: 0x0001A95D
		public RoundedRectangleGeometry(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0002285F File Offset: 0x00020A5F
		public new static explicit operator RoundedRectangleGeometry(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RoundedRectangleGeometry(nativePtr);
			}
			return null;
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x00022878 File Offset: 0x00020A78
		public RoundedRectangle RoundedRect
		{
			get
			{
				RoundedRectangle result;
				this.GetRoundedRect(out result);
				return result;
			}
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00022890 File Offset: 0x00020A90
		internal unsafe void GetRoundedRect(out RoundedRectangle roundedRect)
		{
			roundedRect = default(RoundedRectangle);
			fixed (RoundedRectangle* ptr = &roundedRect)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
