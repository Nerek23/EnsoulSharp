using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000214 RID: 532
	[Guid("2cd906ac-12e2-11dc-9fed-001143a055f9")]
	public class RadialGradientBrush : Brush
	{
		// Token: 0x06000BA2 RID: 2978 RVA: 0x00020F70 File Offset: 0x0001F170
		public RadialGradientBrush(RenderTarget renderTarget, ref RadialGradientBrushProperties radialGradientBrushProperties, GradientStopCollection gradientStopCollection) : this(renderTarget, ref radialGradientBrushProperties, null, gradientStopCollection)
		{
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x00020F90 File Offset: 0x0001F190
		public RadialGradientBrush(RenderTarget renderTarget, RadialGradientBrushProperties radialGradientBrushProperties, GradientStopCollection gradientStopCollection) : this(renderTarget, ref radialGradientBrushProperties, null, gradientStopCollection)
		{
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x00020FB0 File Offset: 0x0001F1B0
		public RadialGradientBrush(RenderTarget renderTarget, RadialGradientBrushProperties radialGradientBrushProperties, BrushProperties brushProperties, GradientStopCollection gradientStopCollection) : this(renderTarget, ref radialGradientBrushProperties, new BrushProperties?(brushProperties), gradientStopCollection)
		{
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x00020FC3 File Offset: 0x0001F1C3
		public RadialGradientBrush(RenderTarget renderTarget, ref RadialGradientBrushProperties radialGradientBrushProperties, BrushProperties? brushProperties, GradientStopCollection gradientStopCollection) : base(IntPtr.Zero)
		{
			renderTarget.CreateRadialGradientBrush(ref radialGradientBrushProperties, brushProperties, gradientStopCollection, this);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x00015A4C File Offset: 0x00013C4C
		public RadialGradientBrush(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x00020FDB File Offset: 0x0001F1DB
		public new static explicit operator RadialGradientBrush(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RadialGradientBrush(nativePtr);
			}
			return null;
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x00020FF2 File Offset: 0x0001F1F2
		// (set) Token: 0x06000BA9 RID: 2985 RVA: 0x00020FFA File Offset: 0x0001F1FA
		public RawVector2 Center
		{
			get
			{
				return this.GetCenter();
			}
			set
			{
				this.SetCenter(value);
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x00021003 File Offset: 0x0001F203
		// (set) Token: 0x06000BAB RID: 2987 RVA: 0x0002100B File Offset: 0x0001F20B
		public RawVector2 GradientOriginOffset
		{
			get
			{
				return this.GetGradientOriginOffset();
			}
			set
			{
				this.SetGradientOriginOffset(value);
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x00021014 File Offset: 0x0001F214
		// (set) Token: 0x06000BAD RID: 2989 RVA: 0x0002101C File Offset: 0x0001F21C
		public float RadiusX
		{
			get
			{
				return this.GetRadiusX();
			}
			set
			{
				this.SetRadiusX(value);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x00021025 File Offset: 0x0001F225
		// (set) Token: 0x06000BAF RID: 2991 RVA: 0x0002102D File Offset: 0x0001F22D
		public float RadiusY
		{
			get
			{
				return this.GetRadiusY();
			}
			set
			{
				this.SetRadiusY(value);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x00021038 File Offset: 0x0001F238
		public GradientStopCollection GradientStopCollection
		{
			get
			{
				GradientStopCollection result;
				this.GetGradientStopCollection(out result);
				return result;
			}
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0001F6C2 File Offset: 0x0001D8C2
		internal unsafe void SetCenter(RawVector2 center)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2), this._nativePointer, center, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0001F6E2 File Offset: 0x0001D8E2
		internal unsafe void SetGradientOriginOffset(RawVector2 gradientOriginOffset)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2), this._nativePointer, gradientOriginOffset, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0002104E File Offset: 0x0001F24E
		internal unsafe void SetRadiusX(float radiusX)
		{
			calli(System.Void(System.Void*,System.Single), this._nativePointer, radiusX, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0002106F File Offset: 0x0001F26F
		internal unsafe void SetRadiusY(float radiusY)
		{
			calli(System.Void(System.Void*,System.Single), this._nativePointer, radiusY, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00021090 File Offset: 0x0001F290
		internal unsafe RawVector2 GetCenter()
		{
			RawVector2 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x000210C0 File Offset: 0x0001F2C0
		internal unsafe RawVector2 GetGradientOriginOffset()
		{
			RawVector2 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x000210F0 File Offset: 0x0001F2F0
		internal unsafe float GetRadiusX()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x00021110 File Offset: 0x0001F310
		internal unsafe float GetRadiusY()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x00021130 File Offset: 0x0001F330
		internal unsafe void GetGradientStopCollection(out GradientStopCollection gradientStopCollection)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				gradientStopCollection = new GradientStopCollection(zero);
				return;
			}
			gradientStopCollection = null;
		}
	}
}
