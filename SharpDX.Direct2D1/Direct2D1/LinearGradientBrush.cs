using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000201 RID: 513
	[Guid("2cd906ab-12e2-11dc-9fed-001143a055f9")]
	public class LinearGradientBrush : Brush
	{
		// Token: 0x06000AF0 RID: 2800 RVA: 0x0001F63C File Offset: 0x0001D83C
		public LinearGradientBrush(RenderTarget renderTarget, LinearGradientBrushProperties linearGradientBrushProperties, GradientStopCollection gradientStopCollection) : this(renderTarget, linearGradientBrushProperties, null, gradientStopCollection)
		{
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0001F65B File Offset: 0x0001D85B
		public LinearGradientBrush(RenderTarget renderTarget, LinearGradientBrushProperties linearGradientBrushProperties, BrushProperties? brushProperties, GradientStopCollection gradientStopCollection) : base(IntPtr.Zero)
		{
			renderTarget.CreateLinearGradientBrush(linearGradientBrushProperties, brushProperties, gradientStopCollection, this);
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00015A4C File Offset: 0x00013C4C
		public LinearGradientBrush(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0001F673 File Offset: 0x0001D873
		public new static explicit operator LinearGradientBrush(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new LinearGradientBrush(nativePtr);
			}
			return null;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0001F68A File Offset: 0x0001D88A
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x0001F692 File Offset: 0x0001D892
		public RawVector2 StartPoint
		{
			get
			{
				return this.GetStartPoint();
			}
			set
			{
				this.SetStartPoint(value);
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0001F69B File Offset: 0x0001D89B
		// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x0001F6A3 File Offset: 0x0001D8A3
		public RawVector2 EndPoint
		{
			get
			{
				return this.GetEndPoint();
			}
			set
			{
				this.SetEndPoint(value);
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0001F6AC File Offset: 0x0001D8AC
		public GradientStopCollection GradientStopCollection
		{
			get
			{
				GradientStopCollection result;
				this.GetGradientStopCollection(out result);
				return result;
			}
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0001F6C2 File Offset: 0x0001D8C2
		internal unsafe void SetStartPoint(RawVector2 startPoint)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2), this._nativePointer, startPoint, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0001F6E2 File Offset: 0x0001D8E2
		internal unsafe void SetEndPoint(RawVector2 endPoint)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2), this._nativePointer, endPoint, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0001F704 File Offset: 0x0001D904
		internal unsafe RawVector2 GetStartPoint()
		{
			RawVector2 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0001F734 File Offset: 0x0001D934
		internal unsafe RawVector2 GetEndPoint()
		{
			RawVector2 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0001F764 File Offset: 0x0001D964
		internal unsafe void GetGradientStopCollection(out GradientStopCollection gradientStopCollection)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				gradientStopCollection = new GradientStopCollection(zero);
				return;
			}
			gradientStopCollection = null;
		}
	}
}
