using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F2 RID: 498
	[Guid("2cd906a7-12e2-11dc-9fed-001143a055f9")]
	public class GradientStopCollection : Resource
	{
		// Token: 0x06000A7D RID: 2685 RVA: 0x0001E6AC File Offset: 0x0001C8AC
		public GradientStopCollection(RenderTarget renderTarget, GradientStop[] gradientStops) : this(renderTarget, gradientStops, Gamma.StandardRgb, ExtendMode.Clamp)
		{
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0001E6B8 File Offset: 0x0001C8B8
		public GradientStopCollection(RenderTarget renderTarget, GradientStop[] gradientStops, ExtendMode extendMode) : this(renderTarget, gradientStops, Gamma.StandardRgb, extendMode)
		{
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0001E6C4 File Offset: 0x0001C8C4
		public GradientStopCollection(RenderTarget renderTarget, GradientStop[] gradientStops, Gamma colorInterpolationGamma) : this(renderTarget, gradientStops, colorInterpolationGamma, ExtendMode.Clamp)
		{
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0001E6D0 File Offset: 0x0001C8D0
		public GradientStopCollection(RenderTarget renderTarget, GradientStop[] gradientStops, Gamma colorInterpolationGamma, ExtendMode extendMode) : base(IntPtr.Zero)
		{
			renderTarget.CreateGradientStopCollection(gradientStops, gradientStops.Length, colorInterpolationGamma, extendMode, this);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00016258 File Offset: 0x00014458
		public GradientStopCollection(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0001E6EB File Offset: 0x0001C8EB
		public new static explicit operator GradientStopCollection(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GradientStopCollection(nativePtr);
			}
			return null;
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x0001E702 File Offset: 0x0001C902
		public int GradientStopCount
		{
			get
			{
				return this.GetGradientStopCount();
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0001E70A File Offset: 0x0001C90A
		public Gamma ColorInterpolationGamma
		{
			get
			{
				return this.GetColorInterpolationGamma();
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0001E712 File Offset: 0x0001C912
		public ExtendMode ExtendMode
		{
			get
			{
				return this.GetExtendMode();
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00010018 File Offset: 0x0000E218
		internal unsafe int GetGradientStopCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0001E71C File Offset: 0x0001C91C
		public unsafe void GetGradientStops(GradientStop[] gradientStops, int gradientStopsCount)
		{
			fixed (GradientStop[] array = gradientStops)
			{
				void* ptr;
				if (gradientStops == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, gradientStopsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0001E762 File Offset: 0x0001C962
		internal unsafe Gamma GetColorInterpolationGamma()
		{
			return calli(SharpDX.Direct2D1.Gamma(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0001E781 File Offset: 0x0001C981
		internal unsafe ExtendMode GetExtendMode()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}
	}
}
