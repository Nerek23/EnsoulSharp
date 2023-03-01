using System;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200018F RID: 399
	[Guid("54d7898a-a061-40a7-bec7-e465bcba2c4f")]
	internal class CommandSinkNative : ComObject, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000778 RID: 1912 RVA: 0x00016841 File Offset: 0x00014A41
		public void BeginDraw()
		{
			this.BeginDraw_();
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00016849 File Offset: 0x00014A49
		public void EndDraw()
		{
			this.EndDraw_();
		}

		// Token: 0x1700012D RID: 301
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x00016851 File Offset: 0x00014A51
		public AntialiasMode AntialiasMode
		{
			set
			{
				this.SetAntialiasMode_(value);
			}
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0001685A File Offset: 0x00014A5A
		public void SetTags(long tag1, long tag2)
		{
			this.SetTags_(tag1, tag2);
		}

		// Token: 0x1700012E RID: 302
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x00016864 File Offset: 0x00014A64
		public TextAntialiasMode TextAntialiasMode
		{
			set
			{
				this.SetTextAntialiasMode_(value);
			}
		}

		// Token: 0x1700012F RID: 303
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x0001686D File Offset: 0x00014A6D
		public RenderingParams TextRenderingParams
		{
			set
			{
				this.SetTextRenderingParams_(value);
			}
		}

		// Token: 0x17000130 RID: 304
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x00016876 File Offset: 0x00014A76
		public RawMatrix3x2 Transform
		{
			set
			{
				this.SetTransform_(ref value);
			}
		}

		// Token: 0x17000131 RID: 305
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x00016880 File Offset: 0x00014A80
		public PrimitiveBlend PrimitiveBlend
		{
			set
			{
				this.SetPrimitiveBlend_(value);
			}
		}

		// Token: 0x17000132 RID: 306
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x00016889 File Offset: 0x00014A89
		public UnitMode UnitMode
		{
			set
			{
				this.SetUnitMode_(value);
			}
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00016892 File Offset: 0x00014A92
		public void Clear(RawColor4? color = null)
		{
			this.Clear_(color);
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0001689B File Offset: 0x00014A9B
		public void DrawGlyphRun(RawVector2 baselineOrigin, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, Brush foregroundBrush, MeasuringMode measuringMode)
		{
			this.DrawGlyphRun_(baselineOrigin, glyphRun, glyphRunDescription, foregroundBrush, measuringMode);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x000168AA File Offset: 0x00014AAA
		public void DrawLine(RawVector2 point0, RawVector2 point1, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			this.DrawLine_(point0, point1, brush, strokeWidth, strokeStyle);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x000168B9 File Offset: 0x00014AB9
		public void DrawGeometry(Geometry geometry, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			this.DrawGeometry_(geometry, brush, strokeWidth, strokeStyle);
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x000168C6 File Offset: 0x00014AC6
		public void DrawRectangle(RawRectangleF rect, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			this.DrawRectangle_(rect, brush, strokeWidth, strokeStyle);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x000168D3 File Offset: 0x00014AD3
		public void DrawBitmap(Bitmap bitmap, RawRectangleF? destinationRectangle, float opacity, InterpolationMode interpolationMode, RawRectangleF? sourceRectangle, RawMatrix? erspectiveTransformRef)
		{
			this.DrawBitmap_(bitmap, destinationRectangle, opacity, interpolationMode, sourceRectangle, erspectiveTransformRef);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x000168E4 File Offset: 0x00014AE4
		public void DrawImage(Image image, RawVector2? targetOffset, RawRectangleF? imageRectangle, InterpolationMode interpolationMode, CompositeMode compositeMode)
		{
			this.DrawImage_(image, targetOffset, imageRectangle, interpolationMode, compositeMode);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x000168F3 File Offset: 0x00014AF3
		public void DrawGdiMetafile(GdiMetafile gdiMetafile, RawVector2? targetOffset)
		{
			this.DrawGdiMetafile_(gdiMetafile, targetOffset);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x000168FD File Offset: 0x00014AFD
		public void FillMesh(Mesh mesh, Brush brush)
		{
			this.FillMesh_(mesh, brush);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00016907 File Offset: 0x00014B07
		public void FillOpacityMask(Bitmap opacityMask, Brush brush, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
		{
			this.FillOpacityMask_(opacityMask, brush, destinationRectangle, sourceRectangle);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00016914 File Offset: 0x00014B14
		public void FillGeometry(Geometry geometry, Brush brush, Brush opacityBrush)
		{
			this.FillGeometry_(geometry, brush, opacityBrush);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001691F File Offset: 0x00014B1F
		public void FillRectangle(RawRectangleF rect, Brush brush)
		{
			this.FillRectangle_(rect, brush);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00016929 File Offset: 0x00014B29
		public void PushAxisAlignedClip(RawRectangleF clipRect, AntialiasMode antialiasMode)
		{
			this.PushAxisAlignedClip_(clipRect, antialiasMode);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00016933 File Offset: 0x00014B33
		public void PushLayer(ref LayerParameters1 layerParameters1, Layer layer)
		{
			this.PushLayer_(ref layerParameters1, layer);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0001693D File Offset: 0x00014B3D
		public void PopAxisAlignedClip()
		{
			this.PopAxisAlignedClip_();
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00016945 File Offset: 0x00014B45
		public void PopLayer()
		{
			this.PopLayer_();
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00002A7F File Offset: 0x00000C7F
		public CommandSinkNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001694D File Offset: 0x00014B4D
		public new static explicit operator CommandSinkNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandSinkNative(nativePtr);
			}
			return null;
		}

		// Token: 0x17000133 RID: 307
		// (set) Token: 0x06000793 RID: 1939 RVA: 0x00016851 File Offset: 0x00014A51
		public AntialiasMode AntialiasMode_
		{
			set
			{
				this.SetAntialiasMode_(value);
			}
		}

		// Token: 0x17000134 RID: 308
		// (set) Token: 0x06000794 RID: 1940 RVA: 0x00016864 File Offset: 0x00014A64
		public TextAntialiasMode TextAntialiasMode_
		{
			set
			{
				this.SetTextAntialiasMode_(value);
			}
		}

		// Token: 0x17000135 RID: 309
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x0001686D File Offset: 0x00014A6D
		public RenderingParams TextRenderingParams_
		{
			set
			{
				this.SetTextRenderingParams_(value);
			}
		}

		// Token: 0x17000136 RID: 310
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x00016876 File Offset: 0x00014A76
		public RawMatrix3x2 Transform_
		{
			set
			{
				this.SetTransform_(ref value);
			}
		}

		// Token: 0x17000137 RID: 311
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x00016880 File Offset: 0x00014A80
		public PrimitiveBlend PrimitiveBlend_
		{
			set
			{
				this.SetPrimitiveBlend_(value);
			}
		}

		// Token: 0x17000138 RID: 312
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x00016889 File Offset: 0x00014A89
		public UnitMode UnitMode_
		{
			set
			{
				this.SetUnitMode_(value);
			}
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00016964 File Offset: 0x00014B64
		internal unsafe void BeginDraw_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001699C File Offset: 0x00014B9C
		internal unsafe void EndDraw_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000169D4 File Offset: 0x00014BD4
		internal unsafe void SetAntialiasMode_(AntialiasMode antialiasMode)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, antialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00016A0C File Offset: 0x00014C0C
		internal unsafe void SetTags_(long tag1, long tag2)
		{
			calli(System.Int32(System.Void*,System.Int64,System.Int64), this._nativePointer, tag1, tag2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00016A48 File Offset: 0x00014C48
		internal unsafe void SetTextAntialiasMode_(TextAntialiasMode textAntialiasMode)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, textAntialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00016A80 File Offset: 0x00014C80
		internal unsafe void SetTextRenderingParams_(RenderingParams textRenderingParams)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderingParams>(textRenderingParams);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00016ACC File Offset: 0x00014CCC
		internal unsafe void SetTransform_(ref RawMatrix3x2 transform)
		{
			Result result;
			fixed (RawMatrix3x2* ptr = &transform)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00016B10 File Offset: 0x00014D10
		internal unsafe void SetPrimitiveBlend_(PrimitiveBlend primitiveBlend)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, primitiveBlend, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00016B4C File Offset: 0x00014D4C
		internal unsafe void SetUnitMode_(UnitMode unitMode)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, unitMode, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00016B88 File Offset: 0x00014D88
		internal unsafe void Clear_(RawColor4? color)
		{
			RawColor4 value;
			if (color != null)
			{
				value = color.Value;
			}
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (color == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00016BE4 File Offset: 0x00014DE4
		internal unsafe void DrawGlyphRun_(RawVector2 baselineOrigin, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription, Brush foregroundBrush, MeasuringMode measuringMode)
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
			Result result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, baselineOrigin, &_Native, (glyphRunDescription == null) ? null : (&_Native2), (void*)value, measuringMode, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			glyphRun.__MarshalFree(ref _Native);
			if (glyphRunDescription != null)
			{
				glyphRunDescription.__MarshalFree(ref _Native2);
			}
			result.CheckError();
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00016C78 File Offset: 0x00014E78
		internal unsafe void DrawLine_(RawVector2 point0, RawVector2 point1, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawVector2,SharpDX.Mathematics.Interop.RawVector2,System.Void*,System.Single,System.Void*), this._nativePointer, point0, point1, (void*)value, strokeWidth, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00016CDC File Offset: 0x00014EDC
		internal unsafe void DrawGeometry_(Geometry geometry, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(geometry);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			value3 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, (void*)value, (void*)value2, strokeWidth, (void*)value3, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00016D50 File Offset: 0x00014F50
		internal unsafe void DrawRectangle_(RawRectangleF rect, Brush brush, float strokeWidth, StrokeStyle strokeStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			value2 = CppObject.ToCallbackPtr<StrokeStyle>(strokeStyle);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Void*), this._nativePointer, &rect, (void*)value, strokeWidth, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00016DB4 File Offset: 0x00014FB4
		internal unsafe void DrawBitmap_(Bitmap bitmap, RawRectangleF? destinationRectangle, float opacity, InterpolationMode interpolationMode, RawRectangleF? sourceRectangle, RawMatrix? erspectiveTransformRef)
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
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Single,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, (destinationRectangle == null) ? null : (&value2), opacity, interpolationMode, (sourceRectangle == null) ? null : (&value3), (erspectiveTransformRef == null) ? null : (&value4), *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00016E68 File Offset: 0x00015068
		internal unsafe void DrawImage_(Image image, RawVector2? targetOffset, RawRectangleF? imageRectangle, InterpolationMode interpolationMode, CompositeMode compositeMode)
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
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, (targetOffset == null) ? null : (&value2), (imageRectangle == null) ? null : (&value3), interpolationMode, compositeMode, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00016EFC File Offset: 0x000150FC
		internal unsafe void DrawGdiMetafile_(GdiMetafile gdiMetafile, RawVector2? targetOffset)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GdiMetafile>(gdiMetafile);
			RawVector2 value2;
			if (targetOffset != null)
			{
				value2 = targetOffset.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (targetOffset == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00016F68 File Offset: 0x00015168
		internal unsafe void FillMesh_(Mesh mesh, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Mesh>(mesh);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00016FC8 File Offset: 0x000151C8
		internal unsafe void FillOpacityMask_(Bitmap opacityMask, Brush brush, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
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
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (destinationRectangle == null) ? null : (&value3), (sourceRectangle == null) ? null : (&value4), *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0001706C File Offset: 0x0001526C
		internal unsafe void FillGeometry_(Geometry geometry, Brush brush, Brush opacityBrush)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Geometry>(geometry);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			value3 = CppObject.ToCallbackPtr<Brush>(opacityBrush);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x000170E0 File Offset: 0x000152E0
		internal unsafe void FillRectangle_(RawRectangleF rect, Brush brush)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Brush>(brush);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &rect, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00017130 File Offset: 0x00015330
		internal unsafe void PushAxisAlignedClip_(RawRectangleF clipRect, AntialiasMode antialiasMode)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, &clipRect, antialiasMode, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0001716C File Offset: 0x0001536C
		internal unsafe void PushLayer_(ref LayerParameters1 layerParameters1, Layer layer)
		{
			LayerParameters1.__Native _Native = default(LayerParameters1.__Native);
			IntPtr value = IntPtr.Zero;
			layerParameters1.__MarshalTo(ref _Native);
			value = CppObject.ToCallbackPtr<Layer>(layer);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			layerParameters1.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000171D4 File Offset: 0x000153D4
		internal unsafe void PopAxisAlignedClip_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0001720C File Offset: 0x0001540C
		internal unsafe void PopLayer_()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
