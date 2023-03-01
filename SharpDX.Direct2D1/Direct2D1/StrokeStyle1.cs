using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000230 RID: 560
	[Guid("10a72a66-e91c-43f4-993f-ddf4b82b0b4a")]
	public class StrokeStyle1 : StrokeStyle
	{
		// Token: 0x06000CB3 RID: 3251 RVA: 0x00023317 File Offset: 0x00021517
		public StrokeStyle1(Factory1 factory, StrokeStyleProperties1 strokeStyleProperties) : base(IntPtr.Zero)
		{
			factory.CreateStrokeStyle(ref strokeStyleProperties, null, 0, this);
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0002332F File Offset: 0x0002152F
		public StrokeStyle1(Factory1 factory, StrokeStyleProperties1 strokeStyleProperties, float[] dashes) : base(IntPtr.Zero)
		{
			factory.CreateStrokeStyle(ref strokeStyleProperties, dashes, dashes.Length, this);
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x00023349 File Offset: 0x00021549
		public StrokeStyle1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x00023352 File Offset: 0x00021552
		public new static explicit operator StrokeStyle1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new StrokeStyle1(nativePtr);
			}
			return null;
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x00023369 File Offset: 0x00021569
		public StrokeTransformType StrokeTransformType
		{
			get
			{
				return this.GetStrokeTransformType();
			}
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x00023371 File Offset: 0x00021571
		internal unsafe StrokeTransformType GetStrokeTransformType()
		{
			return calli(SharpDX.Direct2D1.StrokeTransformType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}
	}
}
