using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200022F RID: 559
	[Guid("2cd9069d-12e2-11dc-9fed-001143a055f9")]
	public class StrokeStyle : Resource
	{
		// Token: 0x06000C9E RID: 3230 RVA: 0x0002314C File Offset: 0x0002134C
		public StrokeStyle(Factory factory, StrokeStyleProperties properties) : base(IntPtr.Zero)
		{
			factory.CreateStrokeStyle(ref properties, null, 0, this);
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x00023164 File Offset: 0x00021364
		public StrokeStyle(Factory factory, StrokeStyleProperties properties, float[] dashes) : base(IntPtr.Zero)
		{
			factory.CreateStrokeStyle(ref properties, dashes, dashes.Length, this);
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00016258 File Offset: 0x00014458
		public StrokeStyle(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x0002317E File Offset: 0x0002137E
		public new static explicit operator StrokeStyle(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new StrokeStyle(nativePtr);
			}
			return null;
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x00023195 File Offset: 0x00021395
		public CapStyle StartCap
		{
			get
			{
				return this.GetStartCap();
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0002319D File Offset: 0x0002139D
		public CapStyle EndCap
		{
			get
			{
				return this.GetEndCap();
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000CA4 RID: 3236 RVA: 0x000231A5 File Offset: 0x000213A5
		public CapStyle DashCap
		{
			get
			{
				return this.GetDashCap();
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x000231AD File Offset: 0x000213AD
		public float MiterLimit
		{
			get
			{
				return this.GetMiterLimit();
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x000231B5 File Offset: 0x000213B5
		public LineJoin LineJoin
		{
			get
			{
				return this.GetLineJoin();
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x000231BD File Offset: 0x000213BD
		public float DashOffset
		{
			get
			{
				return this.GetDashOffset();
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x000231C5 File Offset: 0x000213C5
		public DashStyle DashStyle
		{
			get
			{
				return this.GetDashStyle();
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x000231CD File Offset: 0x000213CD
		public int DashesCount
		{
			get
			{
				return this.GetDashesCount();
			}
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x000231D5 File Offset: 0x000213D5
		internal unsafe CapStyle GetStartCap()
		{
			return calli(SharpDX.Direct2D1.CapStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x000231F4 File Offset: 0x000213F4
		internal unsafe CapStyle GetEndCap()
		{
			return calli(SharpDX.Direct2D1.CapStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x00023213 File Offset: 0x00021413
		internal unsafe CapStyle GetDashCap()
		{
			return calli(SharpDX.Direct2D1.CapStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x00023232 File Offset: 0x00021432
		internal unsafe float GetMiterLimit()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x00023251 File Offset: 0x00021451
		internal unsafe LineJoin GetLineJoin()
		{
			return calli(SharpDX.Direct2D1.LineJoin(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x00023270 File Offset: 0x00021470
		internal unsafe float GetDashOffset()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x00023290 File Offset: 0x00021490
		internal unsafe DashStyle GetDashStyle()
		{
			return calli(SharpDX.Direct2D1.DashStyle(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x000232B0 File Offset: 0x000214B0
		internal unsafe int GetDashesCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x000232D0 File Offset: 0x000214D0
		public unsafe void GetDashes(float[] dashes, int dashesCount)
		{
			fixed (float[] array = dashes)
			{
				void* ptr;
				if (dashes == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, dashesCount, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
