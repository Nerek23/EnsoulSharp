using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000216 RID: 534
	[Guid("2cd90694-12e2-11dc-9fed-001143a055f9")]
	public class RenderTarget : Resource
	{
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x000211FF File Offset: 0x0001F3FF
		// (set) Token: 0x06000BC0 RID: 3008 RVA: 0x00021207 File Offset: 0x0001F407
		public float StrokeWidth
		{
			get
			{
				return this._strokeWidth;
			}
			set
			{
				this._strokeWidth = value;
			}
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x00021210 File Offset: 0x0001F410
		public RenderTarget(SharpDX.Direct2D1.Factory factory, Surface dxgiSurface, RenderTargetProperties properties) : base(IntPtr.Zero)
		{
			factory.CreateDxgiSurfaceRenderTarget(dxgiSurface, ref properties, this);
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x00021234 File Offset: 0x0001F434
		public void DrawBitmap(Bitmap bitmap, float opacity, BitmapInterpolationMode interpolationMode)
		{
			this.DrawBitmap(bitmap, null, opacity, interpolationMode, null);
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0002125C File Offset: 0x0001F45C
		public void DrawBitmap(Bitmap bitmap, RawRectangleF destinationRectangle, float opacity, BitmapInterpolationMode interpolationMode)
		{
			this.DrawBitmap(bitmap, new RawRectangleF?(destinationRectangle), opacity, interpolationMode, null);
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x00021284 File Offset: 0x0001F484
		public void DrawBitmap(Bitmap bitmap, float opacity, BitmapInterpolationMode interpolationMode, RawRectangleF sourceRectangle)
		{
			this.DrawBitmap(bitmap, null, opacity, interpolationMode, new RawRectangleF?(sourceRectangle));
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x000212AA File Offset: 0x0001F4AA
		public void DrawEllipse(Ellipse ellipse, Brush brush)
		{
			this.DrawEllipse(ellipse, brush, this.StrokeWidth, null);
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x000212BB File Offset: 0x0001F4BB
		public void DrawEllipse(Ellipse ellipse, Brush brush, float strokeWidth)
		{
			this.DrawEllipse(ellipse, brush, strokeWidth, null);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x000212C7 File Offset: 0x0001F4C7
		public void DrawGeometry(Geometry geometry, Brush brush)
		{
			this.DrawGeometry(geometry, brush, this.StrokeWidth, null);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x000212D8 File Offset: 0x0001F4D8
		public void DrawGeometry(Geometry geometry, Brush brush, float strokeWidth)
		{
			this.DrawGeometry(geometry, brush, strokeWidth, null);
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x000212E4 File Offset: 0x0001F4E4
		public void DrawLine(RawVector2 point0, RawVector2 point1, Brush brush)
		{
			this.DrawLine(point0, point1, brush, this.StrokeWidth, null);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x000212F6 File Offset: 0x0001F4F6
		public void DrawLine(RawVector2 point0, RawVector2 point1, Brush brush, float strokeWidth)
		{
			this.DrawLine(point0, point1, brush, strokeWidth, null);
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x00021304 File Offset: 0x0001F504
		public void DrawRectangle(RawRectangleF rect, Brush brush)
		{
			this.DrawRectangle(rect, brush, this.StrokeWidth, null);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x00021315 File Offset: 0x0001F515
		public void DrawRectangle(RawRectangleF rect, Brush brush, float strokeWidth)
		{
			this.DrawRectangle(rect, brush, strokeWidth, null);
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x00021321 File Offset: 0x0001F521
		public void DrawRoundedRectangle(RoundedRectangle roundedRect, Brush brush)
		{
			this.DrawRoundedRectangle(ref roundedRect, brush, this.StrokeWidth, null);
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x00021333 File Offset: 0x0001F533
		public void DrawRoundedRectangle(RoundedRectangle roundedRect, Brush brush, float strokeWidth)
		{
			this.DrawRoundedRectangle(ref roundedRect, brush, strokeWidth, null);
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x00021340 File Offset: 0x0001F540
		public void DrawRoundedRectangle(RoundedRectangle roundedRect, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			this.DrawRoundedRectangle(ref roundedRect, brush, strokeWidth, strokeStyle);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0002134E File Offset: 0x0001F54E
		public void DrawText(string text, TextFormat textFormat, RawRectangleF layoutRect, Brush defaultForegroundBrush)
		{
			this.DrawText(text, text.Length, textFormat, layoutRect, defaultForegroundBrush, DrawTextOptions.None, MeasuringMode.Natural);
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00021363 File Offset: 0x0001F563
		public void DrawText(string text, TextFormat textFormat, RawRectangleF layoutRect, Brush defaultForegroundBrush, DrawTextOptions options)
		{
			this.DrawText(text, text.Length, textFormat, layoutRect, defaultForegroundBrush, options, MeasuringMode.Natural);
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x00021379 File Offset: 0x0001F579
		public void DrawText(string text, TextFormat textFormat, RawRectangleF layoutRect, Brush defaultForegroundBrush, DrawTextOptions options, MeasuringMode measuringMode)
		{
			this.DrawText(text, text.Length, textFormat, layoutRect, defaultForegroundBrush, options, measuringMode);
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x00021390 File Offset: 0x0001F590
		public void DrawTextLayout(RawVector2 origin, TextLayout textLayout, Brush defaultForegroundBrush)
		{
			this.DrawTextLayout(origin, textLayout, defaultForegroundBrush, DrawTextOptions.None);
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0002139C File Offset: 0x0001F59C
		public void EndDraw(out long tag1, out long tag2)
		{
			this.TryEndDraw(out tag1, out tag2).CheckError();
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x000213BC File Offset: 0x0001F5BC
		public void EndDraw()
		{
			long num;
			long num2;
			this.EndDraw(out num, out num2);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000213D3 File Offset: 0x0001F5D3
		public void FillGeometry(Geometry geometry, Brush brush)
		{
			this.FillGeometry(geometry, brush, null);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x000213E0 File Offset: 0x0001F5E0
		public void FillOpacityMask(Bitmap opacityMask, Brush brush, OpacityMaskContent content)
		{
			this.FillOpacityMask(opacityMask, brush, content, null, null);
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x00021408 File Offset: 0x0001F608
		public void FillRoundedRectangle(RoundedRectangle roundedRect, Brush brush)
		{
			this.FillRoundedRectangle(ref roundedRect, brush);
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x00021414 File Offset: 0x0001F614
		public void Flush()
		{
			long num;
			long num2;
			this.Flush(out num, out num2);
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0002142C File Offset: 0x0001F62C
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x0002144A File Offset: 0x0001F64A
		public Size2F DotsPerInch
		{
			get
			{
				float width;
				float height;
				this.GetDpi(out width, out height);
				return new Size2F(width, height);
			}
			set
			{
				this.SetDpi(value.Width, value.Height);
			}
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x0002145E File Offset: 0x0001F65E
		public RenderTarget(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00021472 File Offset: 0x0001F672
		public new static explicit operator RenderTarget(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderTarget(nativePtr);
			}
			return null;
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x0002148C File Offset: 0x0001F68C
		// (set) Token: 0x06000BDF RID: 3039 RVA: 0x000214A2 File Offset: 0x0001F6A2
		public RawMatrix3x2 Transform
		{
			get
			{
				RawMatrix3x2 result;
				this.GetTransform(out result);
				return result;
			}
			set
			{
				this.SetTransform(ref value);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x000214AC File Offset: 0x0001F6AC
		// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x000214B4 File Offset: 0x0001F6B4
		public AntialiasMode AntialiasMode
		{
			get
			{
				return this.GetAntialiasMode();
			}
			set
			{
				this.SetAntialiasMode(value);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x000214BD File Offset: 0x0001F6BD
		// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x000214C5 File Offset: 0x0001F6C5
		public TextAntialiasMode TextAntialiasMode
		{
			get
			{
				return this.GetTextAntialiasMode();
			}
			set
			{
				this.SetTextAntialiasMode(value);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x000214D0 File Offset: 0x0001F6D0
		// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x000214E6 File Offset: 0x0001F6E6
		public RenderingParams TextRenderingParams
		{
			get
			{
				RenderingParams result;
				this.GetTextRenderingParams(out result);
				return result;
			}
			set
			{
				this.SetTextRenderingParams(value);
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x000214EF File Offset: 0x0001F6EF
		public PixelFormat PixelFormat
		{
			get
			{
				return this.GetPixelFormat();
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x000214F7 File Offset: 0x0001F6F7
		public Size2F Size
		{
			get
			{
				return this.GetSize();
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x000214FF File Offset: 0x0001F6FF
		public Size2 PixelSize
		{
			get
			{
				return this.GetPixelSize();
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x00021507 File Offset: 0x0001F707
		public int MaximumBitmapSize
		{
			get
			{
				return this.GetMaximumBitmapSize();
			}
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00021510 File Offset: 0x0001F710
		internal unsafe void CreateBitmap(Size2 size, IntPtr srcData, int pitch, BitmapProperties bitmapProperties, Bitmap bitmap)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,SharpDX.Size2,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, size, (void*)srcData, pitch, &bitmapProperties, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			bitmap.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00021564 File Offset: 0x0001F764
		internal unsafe void CreateBitmapFromWicBitmap(BitmapSource wicBitmapSource, BitmapProperties? bitmapProperties, out Bitmap bitmap)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(wicBitmapSource);
			BitmapProperties value2;
			if (bitmapProperties != null)
			{
				value2 = bitmapProperties.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (bitmapProperties == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmap = new Bitmap(zero);
			}
			else
			{
				bitmap = null;
			}
			result.CheckError();
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x000215F4 File Offset: 0x0001F7F4
		internal unsafe void CreateSharedBitmap(Guid riid, IntPtr data, BitmapProperties? bitmapProperties, Bitmap bitmap)
		{
			IntPtr zero = IntPtr.Zero;
			BitmapProperties value;
			if (bitmapProperties != null)
			{
				value = bitmapProperties.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, (void*)data, (bitmapProperties == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			bitmap.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00021668 File Offset: 0x0001F868
		internal unsafe void CreateBitmapBrush(Bitmap bitmap, BitmapBrushProperties? bitmapBrushProperties, BrushProperties? brushProperties, BitmapBrush bitmapBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			BitmapBrushProperties value2;
			if (bitmapBrushProperties != null)
			{
				value2 = bitmapBrushProperties.Value;
			}
			BrushProperties value3;
			if (brushProperties != null)
			{
				value3 = brushProperties.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (bitmapBrushProperties == null) ? null : (&value2), (brushProperties == null) ? null : (&value3), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			bitmapBrush.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00021708 File Offset: 0x0001F908
		internal unsafe void CreateSolidColorBrush(RawColor4 color, BrushProperties? brushProperties, SolidColorBrush solidColorBrush)
		{
			IntPtr zero = IntPtr.Zero;
			BrushProperties value;
			if (brushProperties != null)
			{
				value = brushProperties.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &color, (brushProperties == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			solidColorBrush.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00021774 File Offset: 0x0001F974
		internal unsafe void CreateGradientStopCollection(GradientStop[] gradientStops, int gradientStopsCount, Gamma colorInterpolationGamma, ExtendMode extendMode, GradientStopCollection gradientStopCollection)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
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
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, ptr, gradientStopsCount, colorInterpolationGamma, extendMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			gradientStopCollection.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x000217DC File Offset: 0x0001F9DC
		internal unsafe void CreateLinearGradientBrush(LinearGradientBrushProperties linearGradientBrushProperties, BrushProperties? brushProperties, GradientStopCollection gradientStopCollection, LinearGradientBrush linearGradientBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			BrushProperties value2;
			if (brushProperties != null)
			{
				value2 = brushProperties.Value;
			}
			value = CppObject.ToCallbackPtr<GradientStopCollection>(gradientStopCollection);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &linearGradientBrushProperties, (brushProperties == null) ? null : (&value2), (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			linearGradientBrush.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0002185C File Offset: 0x0001FA5C
		internal unsafe void CreateRadialGradientBrush(ref RadialGradientBrushProperties radialGradientBrushProperties, BrushProperties? brushProperties, GradientStopCollection gradientStopCollection, RadialGradientBrush radialGradientBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			BrushProperties value2;
			if (brushProperties != null)
			{
				value2 = brushProperties.Value;
			}
			value = CppObject.ToCallbackPtr<GradientStopCollection>(gradientStopCollection);
			Result result;
			fixed (RadialGradientBrushProperties* ptr = &radialGradientBrushProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, (brushProperties == null) ? null : (&value2), (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			radialGradientBrush.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x000218E8 File Offset: 0x0001FAE8
		internal unsafe void CreateCompatibleRenderTarget(Size2F? desiredSize, Size2? desiredPixelSize, PixelFormat? desiredFormat, CompatibleRenderTargetOptions options, BitmapRenderTarget bitmapRenderTarget)
		{
			IntPtr zero = IntPtr.Zero;
			Size2F value;
			if (desiredSize != null)
			{
				value = desiredSize.Value;
			}
			Size2 value2;
			if (desiredPixelSize != null)
			{
				value2 = desiredPixelSize.Value;
			}
			PixelFormat value3;
			if (desiredFormat != null)
			{
				value3 = desiredFormat.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (desiredSize == null) ? null : (&value), (desiredPixelSize == null) ? null : (&value2), (desiredFormat == null) ? null : (&value3), options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			bitmapRenderTarget.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00021998 File Offset: 0x0001FB98
		internal unsafe void CreateLayer(Size2F? size, Layer layer)
		{
			IntPtr zero = IntPtr.Zero;
			Size2F value;
			if (size != null)
			{
				value = size.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (size == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			layer.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x00021A04 File Offset: 0x0001FC04
		internal unsafe void CreateMesh(Mesh mesh)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			mesh.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x00021A4C File Offset: 0x0001FC4C
		public unsafe void DrawLine(RawVector2 point0, RawVector2 point1, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Single,System.Void*), this._nativePointer, point0, point1, (void*)value, strokeWidth, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x00021AA4 File Offset: 0x0001FCA4
		public unsafe void DrawRectangle(RawRectangleF rect, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, &rect, (void*)value, strokeWidth, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x00021AFC File Offset: 0x0001FCFC
		public unsafe void FillRectangle(RawRectangleF rect, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, &rect, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00021B40 File Offset: 0x0001FD40
		public unsafe void DrawRoundedRectangle(ref RoundedRectangle roundedRect, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			fixed (RoundedRectangle* ptr = &roundedRect)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, ptr2, (void*)value, strokeWidth, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00021B9C File Offset: 0x0001FD9C
		public unsafe void FillRoundedRectangle(ref RoundedRectangle roundedRect, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			fixed (RoundedRectangle* ptr = &roundedRect)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x00021BE4 File Offset: 0x0001FDE4
		public unsafe void DrawEllipse(Ellipse ellipse, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, &ellipse, (void*)value, strokeWidth, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x00021C3C File Offset: 0x0001FE3C
		public unsafe void FillEllipse(Ellipse ellipse, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, &ellipse, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x00021C80 File Offset: 0x0001FE80
		public unsafe void DrawGeometry(Geometry geometry, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(geometry);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			value3 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (void*)value, (void*)value2, strokeWidth, (void*)value3, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x00021CE8 File Offset: 0x0001FEE8
		public unsafe void FillGeometry(Geometry geometry, Brush brush, Brush opacityBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(geometry);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			value3 = CppObject.ToCallbackPtr<Brush>(opacityBrush);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00021D4C File Offset: 0x0001FF4C
		public unsafe void FillMesh(Mesh mesh, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Mesh>(mesh);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x00021DA0 File Offset: 0x0001FFA0
		public unsafe void FillOpacityMask(Bitmap opacityMask, Brush brush, OpacityMaskContent content, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(opacityMask);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			RawRectangleF value3;
			if (destinationRectangle != null)
			{
				value3 = destinationRectangle.Value;
			}
			RawRectangleF value4;
			if (sourceRectangle != null)
			{
				value4 = sourceRectangle.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, content, (destinationRectangle == null) ? null : (&value3), (sourceRectangle == null) ? null : (&value4), *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x00021E34 File Offset: 0x00020034
		public unsafe void DrawBitmap(Bitmap bitmap, RawRectangleF? destinationRectangle, float opacity, BitmapInterpolationMode interpolationMode, RawRectangleF? sourceRectangle)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			RawRectangleF value2;
			if (destinationRectangle != null)
			{
				value2 = destinationRectangle.Value;
			}
			RawRectangleF value3;
			if (sourceRectangle != null)
			{
				value3 = sourceRectangle.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Single,System.Int32,System.Void*), this._nativePointer, (void*)value, (destinationRectangle == null) ? null : (&value2), opacity, interpolationMode, (sourceRectangle == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x00021EB8 File Offset: 0x000200B8
		public unsafe void DrawText(string text, int stringLength, TextFormat textFormat, RawRectangleF layoutRect, Brush defaultFillBrush, DrawTextOptions options, MeasuringMode measuringMode)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextFormat>(textFormat);
			value2 = CppObject.ToCallbackPtr<Brush>(defaultFillBrush);
			fixed (string text2 = text)
			{
				char* ptr = text2;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, ptr, stringLength, (void*)value, &layoutRect, (void*)value2, options, measuringMode, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x00021F28 File Offset: 0x00020128
		public unsafe void DrawTextLayout(RawVector2 origin, TextLayout textLayout, Brush defaultFillBrush, DrawTextOptions options)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<TextLayout>(textLayout);
			value2 = CppObject.ToCallbackPtr<Brush>(defaultFillBrush);
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Int32), this._nativePointer, origin, (void*)value, (void*)value2, options, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00021F7C File Offset: 0x0002017C
		public unsafe void DrawGlyphRun(RawVector2 baselineOrigin, GlyphRun glyphRun, Brush foregroundBrush, MeasuringMode measuringMode)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			IntPtr value = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			value = CppObject.ToCallbackPtr<Brush>(foregroundBrush);
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Int32), this._nativePointer, baselineOrigin, &_Native, (void*)value, measuringMode, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			glyphRun.__MarshalFree(ref _Native);
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x00021FD8 File Offset: 0x000201D8
		internal unsafe void SetTransform(ref RawMatrix3x2 transform)
		{
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0002200C File Offset: 0x0002020C
		internal unsafe void GetTransform(out RawMatrix3x2 transform)
		{
			transform = default(RawMatrix3x2);
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x00022047 File Offset: 0x00020247
		internal unsafe void SetAntialiasMode(AntialiasMode antialiasMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, antialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x00022068 File Offset: 0x00020268
		internal unsafe AntialiasMode GetAntialiasMode()
		{
			return calli(SharpDX.Direct2D1.AntialiasMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00022088 File Offset: 0x00020288
		internal unsafe void SetTextAntialiasMode(TextAntialiasMode textAntialiasMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, textAntialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x000220A9 File Offset: 0x000202A9
		internal unsafe TextAntialiasMode GetTextAntialiasMode()
		{
			return calli(SharpDX.Direct2D1.TextAntialiasMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x000220CC File Offset: 0x000202CC
		internal unsafe void SetTextRenderingParams(RenderingParams textRenderingParams)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderingParams>(textRenderingParams);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0002210C File Offset: 0x0002030C
		internal unsafe void GetTextRenderingParams(out RenderingParams textRenderingParams)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				textRenderingParams = new RenderingParams(zero);
				return;
			}
			textRenderingParams = null;
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00022159 File Offset: 0x00020359
		public unsafe void SetTags(long tag1, long tag2)
		{
			calli(System.Void(System.Void*,System.Int64,System.Int64), this._nativePointer, tag1, tag2, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0002217C File Offset: 0x0002037C
		public unsafe void GetTags(out long tag1, out long tag2)
		{
			fixed (long* ptr = &tag2)
			{
				void* ptr2 = (void*)ptr;
				fixed (long* ptr3 = &tag1)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x000221BC File Offset: 0x000203BC
		public unsafe void PushLayer(ref LayerParameters layerParameters, Layer layer)
		{
			LayerParameters.__Native _Native = default(LayerParameters.__Native);
			IntPtr value = IntPtr.Zero;
			layerParameters.__MarshalTo(ref _Native);
			value = CppObject.ToCallbackPtr<Layer>(layer);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			layerParameters.__MarshalFree(ref _Native);
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00022215 File Offset: 0x00020415
		public unsafe void PopLayer()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00022238 File Offset: 0x00020438
		public unsafe void Flush(out long tag1, out long tag2)
		{
			Result result;
			fixed (long* ptr = &tag2)
			{
				void* ptr2 = (void*)ptr;
				fixed (long* ptr3 = &tag1)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00022288 File Offset: 0x00020488
		public unsafe void SaveDrawingState(DrawingStateBlock drawingStateBlock)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DrawingStateBlock>(drawingStateBlock);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x000222C8 File Offset: 0x000204C8
		public unsafe void RestoreDrawingState(DrawingStateBlock drawingStateBlock)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DrawingStateBlock>(drawingStateBlock);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00022306 File Offset: 0x00020506
		public unsafe void PushAxisAlignedClip(RawRectangleF clipRect, AntialiasMode antialiasMode)
		{
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, &clipRect, antialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x0002232A File Offset: 0x0002052A
		public unsafe void PopAxisAlignedClip()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x0002234C File Offset: 0x0002054C
		public unsafe void Clear(RawColor4? clearColor)
		{
			RawColor4 value;
			if (clearColor != null)
			{
				value = clearColor.Value;
			}
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (clearColor == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00022398 File Offset: 0x00020598
		public unsafe void BeginDraw()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x000223B8 File Offset: 0x000205B8
		public unsafe Result TryEndDraw(out long tag1, out long tag2)
		{
			Result result;
			fixed (long* ptr = &tag2)
			{
				void* ptr2 = (void*)ptr;
				fixed (long* ptr3 = &tag1)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
				}
			}
			return result;
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x000223FC File Offset: 0x000205FC
		internal unsafe PixelFormat GetPixelFormat()
		{
			PixelFormat result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0002242C File Offset: 0x0002062C
		internal unsafe void SetDpi(float dpiX, float dpiY)
		{
			calli(System.Void(System.Void*,System.Single,System.Single), this._nativePointer, dpiX, dpiY, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00022450 File Offset: 0x00020650
		internal unsafe void GetDpi(out float dpiX, out float dpiY)
		{
			fixed (float* ptr = &dpiY)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &dpiX)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00022490 File Offset: 0x00020690
		internal unsafe Size2F GetSize()
		{
			Size2F result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x000224C0 File Offset: 0x000206C0
		internal unsafe Size2 GetPixelSize()
		{
			Size2 result;
			object obj = calli(System.Void*(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x000224F0 File Offset: 0x000206F0
		internal unsafe int GetMaximumBitmapSize()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00022510 File Offset: 0x00020710
		public unsafe RawBool IsSupported(ref RenderTargetProperties renderTargetProperties)
		{
			RawBool result;
			fixed (RenderTargetProperties* ptr = &renderTargetProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x040006AC RID: 1708
		private float _strokeWidth = 1f;

		// Token: 0x040006AD RID: 1709
		public const float DefaultStrokeWidth = 1f;
	}
}
