using System;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001DF RID: 479
	[Guid("06152247-6f50-465a-9245-118bfd3b6007")]
	public class Factory : ComObject
	{
		// Token: 0x060009CB RID: 2507 RVA: 0x0001C7D3 File Offset: 0x0001A9D3
		public Factory() : this(FactoryType.SingleThreaded)
		{
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x0001C7DC File Offset: 0x0001A9DC
		public Factory(FactoryType factoryType) : this(factoryType, DebugLevel.None)
		{
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0001C7E8 File Offset: 0x0001A9E8
		public Factory(FactoryType factoryType, DebugLevel debugLevel) : base(IntPtr.Zero)
		{
			FactoryOptions? factoryOptionsRef = null;
			if (debugLevel != DebugLevel.None)
			{
				factoryOptionsRef = new FactoryOptions?(new FactoryOptions
				{
					DebugLevel = debugLevel
				});
			}
			IntPtr temp;
			D2D1.CreateFactory(factoryType, Utilities.GetGuidFromType(base.GetType()), factoryOptionsRef, out temp);
			base.FromTemp(temp);
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060009CE RID: 2510 RVA: 0x0001C840 File Offset: 0x0001AA40
		public Size2F DesktopDpi
		{
			get
			{
				float width;
				float height;
				this.GetDesktopDpi(out width, out height);
				return new Size2F(width, height);
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00002A7F File Offset: 0x00000C7F
		public Factory(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0001C85E File Offset: 0x0001AA5E
		public new static explicit operator SharpDX.Direct2D1.Factory(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SharpDX.Direct2D1.Factory(nativePtr);
			}
			return null;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0001C878 File Offset: 0x0001AA78
		public unsafe void ReloadSystemMetrics()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0001C8B0 File Offset: 0x0001AAB0
		internal unsafe void GetDesktopDpi(out float dpiX, out float dpiY)
		{
			fixed (float* ptr = &dpiY)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &dpiX)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0001C8EC File Offset: 0x0001AAEC
		internal unsafe void CreateRectangleGeometry(RawRectangleF rectangle, RectangleGeometry rectangleGeometry)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &rectangle, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			rectangleGeometry.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0001C938 File Offset: 0x0001AB38
		internal unsafe void CreateRoundedRectangleGeometry(ref RoundedRectangle roundedRectangle, RoundedRectangleGeometry roundedRectangleGeometry)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RoundedRectangle* ptr = &roundedRectangle)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			roundedRectangleGeometry.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0001C988 File Offset: 0x0001AB88
		internal unsafe void CreateEllipseGeometry(Ellipse ellipse, EllipseGeometry ellipseGeometry)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &ellipse, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			ellipseGeometry.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0001C9D4 File Offset: 0x0001ABD4
		internal unsafe void CreateGeometryGroup(FillMode fillMode, Geometry[] geometries, int geometriesCount, GeometryGroup geometryGroup)
		{
			IntPtr* ptr = null;
			if (geometries != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)geometries.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			IntPtr zero = IntPtr.Zero;
			if (geometries != null)
			{
				for (int i = 0; i < geometries.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Geometry>(geometries[i]);
				}
			}
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, fillMode, ptr, geometriesCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			geometryGroup.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0001CA58 File Offset: 0x0001AC58
		internal unsafe void CreateTransformedGeometry(Geometry sourceGeometry, ref RawMatrix3x2 transform, TransformedGeometry transformedGeometry)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(sourceGeometry);
			Result result;
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			transformedGeometry.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0001CAC0 File Offset: 0x0001ACC0
		internal unsafe void CreatePathGeometry(PathGeometry athGeometryRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			athGeometryRef.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0001CB08 File Offset: 0x0001AD08
		internal unsafe void CreateStrokeStyle(ref StrokeStyleProperties strokeStyleProperties, float[] dashes, int dashesCount, StrokeStyle strokeStyle)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
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
				fixed (StrokeStyleProperties* ptr2 = &strokeStyleProperties)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr3, ptr, dashesCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
				}
			}
			strokeStyle.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0001CB7C File Offset: 0x0001AD7C
		internal unsafe void CreateDrawingStateBlock(DrawingStateDescription? drawingStateDescription, RenderingParams textRenderingParams, DrawingStateBlock drawingStateBlock)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			DrawingStateDescription value2;
			if (drawingStateDescription != null)
			{
				value2 = drawingStateDescription.Value;
			}
			value = CppObject.ToCallbackPtr<RenderingParams>(textRenderingParams);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (drawingStateDescription == null) ? null : (&value2), (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			drawingStateBlock.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0001CBF8 File Offset: 0x0001ADF8
		internal unsafe void CreateWicBitmapRenderTarget(Bitmap target, ref RenderTargetProperties renderTargetProperties, RenderTarget renderTarget)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Bitmap>(target);
			Result result;
			fixed (RenderTargetProperties* ptr = &renderTargetProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			renderTarget.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0001CC60 File Offset: 0x0001AE60
		internal unsafe void CreateHwndRenderTarget(ref RenderTargetProperties renderTargetProperties, ref HwndRenderTargetProperties hwndRenderTargetProperties, WindowRenderTarget hwndRenderTarget)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (HwndRenderTargetProperties* ptr = &hwndRenderTargetProperties)
			{
				void* ptr2 = (void*)ptr;
				fixed (RenderTargetProperties* ptr3 = &renderTargetProperties)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
				}
			}
			hwndRenderTarget.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0001CCC0 File Offset: 0x0001AEC0
		internal unsafe void CreateDxgiSurfaceRenderTarget(Surface dxgiSurface, ref RenderTargetProperties renderTargetProperties, RenderTarget renderTarget)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Surface>(dxgiSurface);
			Result result;
			fixed (RenderTargetProperties* ptr = &renderTargetProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			}
			renderTarget.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0001CD28 File Offset: 0x0001AF28
		internal unsafe void CreateDCRenderTarget(ref RenderTargetProperties renderTargetProperties, DeviceContextRenderTarget dcRenderTarget)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RenderTargetProperties* ptr = &renderTargetProperties)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			dcRenderTarget.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0001CD7C File Offset: 0x0001AF7C
		internal unsafe void CreateGeometryGroup(FillMode fillMode, ComArray<Geometry> geometries, int geometriesCount, GeometryGroup geometryGroup)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, fillMode, (void*)((geometries != null) ? geometries.NativePointer : IntPtr.Zero), geometriesCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			geometryGroup.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0001CDDC File Offset: 0x0001AFDC
		private unsafe void CreateGeometryGroup(FillMode fillMode, IntPtr geometries, int geometriesCount, IntPtr geometryGroup)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, fillMode, (void*)geometries, geometriesCount, (void*)geometryGroup, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
