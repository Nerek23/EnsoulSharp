using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001CB RID: 459
	[Guid("e8f7fe7a-191c-466d-ad95-975678bda998")]
	public class DeviceContext : RenderTarget
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x00019554 File Offset: 0x00017754
		public DeviceContext(Surface surface) : base(IntPtr.Zero)
		{
			D2D1.CreateDeviceContext(surface, null, this);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0001957C File Offset: 0x0001777C
		public DeviceContext(Surface surface, CreationProperties creationProperties) : base(IntPtr.Zero)
		{
			D2D1.CreateDeviceContext(surface, new CreationProperties?(creationProperties), this);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00019596 File Offset: 0x00017796
		public DeviceContext(Device device, DeviceContextOptions options) : base(IntPtr.Zero)
		{
			device.CreateDeviceContext(options, this);
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x000195AC File Offset: 0x000177AC
		public void DrawImage(Effect effect, RawVector2 targetOffset, InterpolationMode interpolationMode = InterpolationMode.Linear, CompositeMode compositeMode = CompositeMode.SourceOver)
		{
			using (Image output = effect.Output)
			{
				this.DrawImage(output, new RawVector2?(targetOffset), null, interpolationMode, compositeMode);
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x000195F8 File Offset: 0x000177F8
		public void DrawImage(Effect effect, InterpolationMode interpolationMode = InterpolationMode.Linear, CompositeMode compositeMode = CompositeMode.SourceOver)
		{
			using (Image output = effect.Output)
			{
				this.DrawImage(output, null, null, interpolationMode, compositeMode);
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00019644 File Offset: 0x00017844
		public void DrawImage(Image image, RawVector2 targetOffset, InterpolationMode interpolationMode = InterpolationMode.Linear, CompositeMode compositeMode = CompositeMode.SourceOver)
		{
			this.DrawImage(image, new RawVector2?(targetOffset), null, interpolationMode, compositeMode);
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0001966C File Offset: 0x0001786C
		public void DrawImage(Image image, InterpolationMode interpolationMode = InterpolationMode.Linear, CompositeMode compositeMode = CompositeMode.SourceOver)
		{
			this.DrawImage(image, null, null, interpolationMode, compositeMode);
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00019694 File Offset: 0x00017894
		public void DrawBitmap(Bitmap bitmap, float opacity, InterpolationMode interpolationMode)
		{
			this.DrawBitmap(bitmap, null, opacity, interpolationMode, null, null);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x000196C8 File Offset: 0x000178C8
		public void DrawBitmap(Bitmap bitmap, float opacity, InterpolationMode interpolationMode, RawMatrix perspectiveTransformRef)
		{
			this.DrawBitmap(bitmap, null, opacity, interpolationMode, null, new RawMatrix?(perspectiveTransformRef));
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x000196F8 File Offset: 0x000178F8
		public void DrawBitmap(Bitmap bitmap, float opacity, InterpolationMode interpolationMode, RawRectangleF sourceRectangle, RawMatrix perspectiveTransformRef)
		{
			this.DrawBitmap(bitmap, null, opacity, interpolationMode, new RawRectangleF?(sourceRectangle), new RawMatrix?(perspectiveTransformRef));
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00019725 File Offset: 0x00017925
		public void PushLayer(LayerParameters1 layerParameters, Layer layer)
		{
			this.PushLayer(ref layerParameters, layer);
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00019730 File Offset: 0x00017930
		public RawRectangleF[] GetEffectInvalidRectangles(Effect effect)
		{
			RawRectangleF[] array = new RawRectangleF[this.GetEffectInvalidRectangleCount(effect)];
			if (array.Length == 0)
			{
				return array;
			}
			this.GetEffectInvalidRectangles(effect, array, array.Length);
			return array;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0001975C File Offset: 0x0001795C
		public RawRectangleF[] GetEffectRequiredInputRectangles(Effect renderEffect, EffectInputDescription[] inputDescriptions)
		{
			RawRectangleF[] array = new RawRectangleF[inputDescriptions.Length];
			this.GetEffectRequiredInputRectangles(renderEffect, null, inputDescriptions, array, inputDescriptions.Length);
			return array;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00019788 File Offset: 0x00017988
		public RawRectangleF[] GetEffectRequiredInputRectangles(Effect renderEffect, RawRectangleF renderImageRectangle, EffectInputDescription[] inputDescriptions)
		{
			RawRectangleF[] array = new RawRectangleF[inputDescriptions.Length];
			this.GetEffectRequiredInputRectangles(renderEffect, new RawRectangleF?(renderImageRectangle), inputDescriptions, array, inputDescriptions.Length);
			return array;
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000197B4 File Offset: 0x000179B4
		public void FillOpacityMask(Bitmap opacityMask, Brush brush)
		{
			this.FillOpacityMask(opacityMask, brush, null, null);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00015EFA File Offset: 0x000140FA
		public DeviceContext(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x000197DB File Offset: 0x000179DB
		public new static explicit operator DeviceContext(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext(nativePtr);
			}
			return null;
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x000197F4 File Offset: 0x000179F4
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0001980C File Offset: 0x00017A0C
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x00019822 File Offset: 0x00017A22
		public Image Target
		{
			get
			{
				Image result;
				this.GetTarget(out result);
				return result;
			}
			set
			{
				this.SetTarget(value);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0001982C File Offset: 0x00017A2C
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x00019842 File Offset: 0x00017A42
		public RenderingControls RenderingControls
		{
			get
			{
				RenderingControls result;
				this.GetRenderingControls(out result);
				return result;
			}
			set
			{
				this.SetRenderingControls(value);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0001984B File Offset: 0x00017A4B
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00019853 File Offset: 0x00017A53
		public PrimitiveBlend PrimitiveBlend
		{
			get
			{
				return this.GetPrimitiveBlend();
			}
			set
			{
				this.SetPrimitiveBlend(value);
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0001985C File Offset: 0x00017A5C
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x00019864 File Offset: 0x00017A64
		public UnitMode UnitMode
		{
			get
			{
				return this.GetUnitMode();
			}
			set
			{
				this.SetUnitMode(value);
			}
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00019870 File Offset: 0x00017A70
		internal unsafe void CreateBitmap(Size2 size, IntPtr sourceData, int pitch, BitmapProperties1 bitmapProperties, Bitmap1 bitmap)
		{
			BitmapProperties1.__Native _Native = default(BitmapProperties1.__Native);
			IntPtr zero = IntPtr.Zero;
			bitmapProperties.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,SharpDX.Size2,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, size, (void*)sourceData, pitch, &_Native, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
			bitmap.NativePointer = zero;
			bitmapProperties.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x000198E0 File Offset: 0x00017AE0
		internal unsafe void CreateBitmapFromWicBitmap(BitmapSource wicBitmapSource, BitmapProperties1 bitmapProperties, out Bitmap1 bitmap)
		{
			IntPtr value = IntPtr.Zero;
			BitmapProperties1.__Native _Native = default(BitmapProperties1.__Native);
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(wicBitmapSource);
			if (bitmapProperties != null)
			{
				bitmapProperties.__MarshalTo(ref _Native);
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (bitmapProperties == null) ? null : (&_Native), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				bitmap = new Bitmap1(zero);
			}
			else
			{
				bitmap = null;
			}
			if (bitmapProperties != null)
			{
				bitmapProperties.__MarshalFree(ref _Native);
			}
			result.CheckError();
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00019978 File Offset: 0x00017B78
		internal unsafe void CreateColorContext(ColorSpace space, byte[] rofileRef, int profileSize, ColorContext colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (byte[] array = rofileRef)
			{
				void* ptr;
				if (rofileRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, space, ptr, profileSize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
			}
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000199E0 File Offset: 0x00017BE0
		internal unsafe void CreateColorContextFromFilename(string filename, ColorContext colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = filename)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*)));
			}
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00019A3C File Offset: 0x00017C3C
		internal unsafe void CreateColorContextFromWicColorContext(ColorContext wicColorContext, ColorContext colorContext)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ColorContext>(wicColorContext);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)61 * (IntPtr)sizeof(void*)));
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00019A98 File Offset: 0x00017C98
		internal unsafe void CreateBitmapFromDxgiSurface(Surface surface, BitmapProperties1 bitmapProperties, Bitmap1 bitmap)
		{
			IntPtr value = IntPtr.Zero;
			BitmapProperties1.__Native _Native = default(BitmapProperties1.__Native);
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Surface>(surface);
			if (bitmapProperties != null)
			{
				bitmapProperties.__MarshalTo(ref _Native);
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (bitmapProperties == null) ? null : (&_Native), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)62 * (IntPtr)sizeof(void*)));
			bitmap.NativePointer = zero;
			if (bitmapProperties != null)
			{
				bitmapProperties.__MarshalFree(ref _Native);
			}
			result.CheckError();
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00019B1C File Offset: 0x00017D1C
		internal unsafe void CreateEffect(Guid effectId, Effect effect)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &effectId, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*)));
			effect.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00019B68 File Offset: 0x00017D68
		internal unsafe void CreateGradientStopCollection(GradientStop[] straightAlphaGradientStops, int straightAlphaGradientStopsCount, ColorSpace preInterpolationSpace, ColorSpace postInterpolationSpace, BufferPrecision bufferPrecision, ExtendMode extendMode, ColorInterpolationMode colorInterpolationMode, GradientStopCollection1 gradientStopCollection1)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (GradientStop[] array = straightAlphaGradientStops)
			{
				void* ptr;
				if (straightAlphaGradientStops == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, ptr, straightAlphaGradientStopsCount, preInterpolationSpace, postInterpolationSpace, bufferPrecision, extendMode, colorInterpolationMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
			}
			gradientStopCollection1.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00019BD8 File Offset: 0x00017DD8
		internal unsafe void CreateImageBrush(Image image, ref ImageBrushProperties imageBrushProperties, BrushProperties? brushProperties, ImageBrush imageBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(image);
			BrushProperties value2;
			if (brushProperties != null)
			{
				value2 = brushProperties.Value;
			}
			Result result;
			fixed (ImageBrushProperties* ptr = &imageBrushProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, (brushProperties == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*)));
			}
			imageBrush.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00019C64 File Offset: 0x00017E64
		internal unsafe void CreateBitmapBrush(Bitmap bitmap, BitmapBrushProperties1? bitmapBrushProperties, BrushProperties? brushProperties, BitmapBrush1 bitmapBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(bitmap);
			BitmapBrushProperties1 value2;
			if (bitmapBrushProperties != null)
			{
				value2 = bitmapBrushProperties.Value;
			}
			BrushProperties value3;
			if (brushProperties != null)
			{
				value3 = brushProperties.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (bitmapBrushProperties == null) ? null : (&value2), (brushProperties == null) ? null : (&value3), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*)));
			bitmapBrush.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00019D04 File Offset: 0x00017F04
		internal unsafe void CreateCommandList(CommandList commandList)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*)));
			commandList.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00019D4C File Offset: 0x00017F4C
		public unsafe RawBool IsDxgiFormatSupported(Format format)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, format, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00019D6D File Offset: 0x00017F6D
		public unsafe RawBool IsBufferPrecisionSupported(BufferPrecision bufferPrecision)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, bufferPrecision, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00019D90 File Offset: 0x00017F90
		public unsafe RawRectangleF GetImageLocalBounds(Image image)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(image);
			RawRectangleF result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)70 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00019DE0 File Offset: 0x00017FE0
		public unsafe RawRectangleF GetImageWorldBounds(Image image)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(image);
			RawRectangleF result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)71 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00019E30 File Offset: 0x00018030
		public unsafe RawRectangleF GetGlyphRunWorldBounds(RawVector2 baselineOrigin, GlyphRun glyphRun, MeasuringMode measuringMode)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			glyphRun.__MarshalTo(ref _Native);
			RawRectangleF result2;
			Result result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Int32,System.Void*), this._nativePointer, baselineOrigin, &_Native, measuringMode, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)72 * (IntPtr)sizeof(void*)));
			glyphRun.__MarshalFree(ref _Native);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00019E8C File Offset: 0x0001808C
		internal unsafe void GetDevice(out Device device)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)73 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				device = new Device(zero);
				return;
			}
			device = null;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00019EDC File Offset: 0x000180DC
		internal unsafe void SetTarget(Image image)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(image);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)74 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00019F1C File Offset: 0x0001811C
		internal unsafe void GetTarget(out Image image)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)75 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				image = new Image(zero);
				return;
			}
			image = null;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00019F69 File Offset: 0x00018169
		internal unsafe void SetRenderingControls(RenderingControls renderingControls)
		{
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &renderingControls, *(*(IntPtr*)this._nativePointer + (IntPtr)76 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00019F8C File Offset: 0x0001818C
		internal unsafe void GetRenderingControls(out RenderingControls renderingControls)
		{
			renderingControls = default(RenderingControls);
			fixed (RenderingControls* ptr = &renderingControls)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)77 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00019FC7 File Offset: 0x000181C7
		internal unsafe void SetPrimitiveBlend(PrimitiveBlend primitiveBlend)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, primitiveBlend, *(*(IntPtr*)this._nativePointer + (IntPtr)78 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00019FE8 File Offset: 0x000181E8
		internal unsafe PrimitiveBlend GetPrimitiveBlend()
		{
			return calli(SharpDX.Direct2D1.PrimitiveBlend(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)79 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0001A008 File Offset: 0x00018208
		internal unsafe void SetUnitMode(UnitMode unitMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, unitMode, *(*(IntPtr*)this._nativePointer + (IntPtr)80 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0001A029 File Offset: 0x00018229
		internal unsafe UnitMode GetUnitMode()
		{
			return calli(SharpDX.Direct2D1.UnitMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)81 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0001A04C File Offset: 0x0001824C
		public unsafe void DrawGlyphRun(RawVector2 baselineOrigin, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, Brush foregroundBrush, MeasuringMode measuringMode)
		{
			GlyphRun.__Native _Native = default(GlyphRun.__Native);
			GlyphRunDescription.__Native _Native2 = default(GlyphRunDescription.__Native);
			IntPtr value = IntPtr.Zero;
			glyphRun.__MarshalTo(ref _Native);
			if (glyphRunDescription != null)
			{
				glyphRunDescription.__MarshalTo(ref _Native2);
			}
			value = CppObject.ToCallbackPtr<Brush>(foregroundBrush);
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, baselineOrigin, &_Native, (glyphRunDescription == null) ? null : (&_Native2), (void*)value, measuringMode, *(*(IntPtr*)this._nativePointer + (IntPtr)82 * (IntPtr)sizeof(void*)));
			glyphRun.__MarshalFree(ref _Native);
			if (glyphRunDescription != null)
			{
				glyphRunDescription.__MarshalFree(ref _Native2);
			}
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0001A0D4 File Offset: 0x000182D4
		public unsafe void DrawImage(Image image, RawVector2? targetOffset, RawRectangleF? imageRectangle, InterpolationMode interpolationMode, CompositeMode compositeMode)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(image);
			RawVector2 value2;
			if (targetOffset != null)
			{
				value2 = targetOffset.Value;
			}
			RawRectangleF value3;
			if (imageRectangle != null)
			{
				value3 = imageRectangle.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, (targetOffset == null) ? null : (&value2), (imageRectangle == null) ? null : (&value3), interpolationMode, compositeMode, *(*(IntPtr*)this._nativePointer + (IntPtr)83 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0001A158 File Offset: 0x00018358
		public unsafe void DrawGdiMetafile(GdiMetafile gdiMetafile, RawVector2? targetOffset)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GdiMetafile>(gdiMetafile);
			RawVector2 value2;
			if (targetOffset != null)
			{
				value2 = targetOffset.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (targetOffset == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)84 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0001A1B8 File Offset: 0x000183B8
		public unsafe void DrawBitmap(Bitmap bitmap, RawRectangleF? destinationRectangle, float opacity, InterpolationMode interpolationMode, RawRectangleF? sourceRectangle, RawMatrix? erspectiveTransformRef)
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
			RawMatrix value4;
			if (erspectiveTransformRef != null)
			{
				value4 = erspectiveTransformRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Single,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, (destinationRectangle == null) ? null : (&value2), opacity, interpolationMode, (sourceRectangle == null) ? null : (&value3), (erspectiveTransformRef == null) ? null : (&value4), *(*(IntPtr*)this._nativePointer + (IntPtr)85 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0001A25C File Offset: 0x0001845C
		public unsafe void PushLayer(ref LayerParameters1 layerParameters, Layer layer)
		{
			LayerParameters1.__Native _Native = default(LayerParameters1.__Native);
			IntPtr value = IntPtr.Zero;
			layerParameters.__MarshalTo(ref _Native);
			value = CppObject.ToCallbackPtr<Layer>(layer);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)86 * (IntPtr)sizeof(void*)));
			layerParameters.__MarshalFree(ref _Native);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0001A2B8 File Offset: 0x000184B8
		public unsafe void InvalidateEffectInputRectangle(Effect effect, int input, RawRectangleF inputRectangle)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Effect>(effect);
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, input, &inputRectangle, *(*(IntPtr*)this._nativePointer + (IntPtr)87 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001A308 File Offset: 0x00018508
		internal unsafe int GetEffectInvalidRectangleCount(Effect effect)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Effect>(effect);
			int result;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)88 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0001A358 File Offset: 0x00018558
		internal unsafe void GetEffectInvalidRectangles(Effect effect, RawRectangleF[] rectangles, int rectanglesCount)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Effect>(effect);
			Result result;
			fixed (RawRectangleF[] array = rectangles)
			{
				void* ptr;
				if (rectangles == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, rectanglesCount, *(*(IntPtr*)this._nativePointer + (IntPtr)89 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0001A3C0 File Offset: 0x000185C0
		internal unsafe void GetEffectRequiredInputRectangles(Effect renderEffect, RawRectangleF? renderImageRectangle, EffectInputDescription[] inputDescriptions, RawRectangleF[] requiredInputRects, int inputCount)
		{
			IntPtr value = IntPtr.Zero;
			EffectInputDescription.__Native[] array = new EffectInputDescription.__Native[inputDescriptions.Length];
			value = CppObject.ToCallbackPtr<Effect>(renderEffect);
			RawRectangleF value2;
			if (renderImageRectangle != null)
			{
				value2 = renderImageRectangle.Value;
			}
			for (int i = 0; i < inputDescriptions.Length; i++)
			{
				inputDescriptions[i].__MarshalTo(ref array[i]);
			}
			Result result;
			fixed (RawRectangleF[] array2 = requiredInputRects)
			{
				void* ptr;
				if (requiredInputRects == null || array2.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array2[0]);
				}
				EffectInputDescription.__Native[] array3;
				void* ptr2;
				if ((array3 = array) == null || array3.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array3[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (renderImageRectangle == null) ? null : (&value2), ptr2, ptr, inputCount, *(*(IntPtr*)this._nativePointer + (IntPtr)90 * (IntPtr)sizeof(void*)));
				array3 = null;
			}
			for (int j = 0; j < inputDescriptions.Length; j++)
			{
				inputDescriptions[j].__MarshalFree(ref array[j]);
			}
			result.CheckError();
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0001A4C4 File Offset: 0x000186C4
		public unsafe void FillOpacityMask(Bitmap opacityMask, Brush brush, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
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
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (destinationRectangle == null) ? null : (&value3), (sourceRectangle == null) ? null : (&value4), *(*(IntPtr*)this._nativePointer + (IntPtr)91 * (IntPtr)sizeof(void*)));
		}
	}
}
