using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001CD RID: 461
	[Guid("394ea6a3-0c34-4321-950b-6ca20f0be6c7")]
	public class DeviceContext2 : DeviceContext1
	{
		// Token: 0x06000937 RID: 2359 RVA: 0x0001A6AD File Offset: 0x000188AD
		public DeviceContext2(Device2 device, DeviceContextOptions options) : base(IntPtr.Zero)
		{
			device.CreateDeviceContext(options, this);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0001A6C2 File Offset: 0x000188C2
		public DeviceContext2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001A6CB File Offset: 0x000188CB
		public new static explicit operator DeviceContext2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext2(nativePtr);
			}
			return null;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001A6E4 File Offset: 0x000188E4
		internal unsafe void CreateInk(InkPoint startPoint, Ink ink)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &startPoint, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)95 * (IntPtr)sizeof(void*)));
			ink.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0001A730 File Offset: 0x00018930
		internal unsafe void CreateInkStyle(InkStyleProperties? inkStyleProperties, InkStyle inkStyle)
		{
			IntPtr zero = IntPtr.Zero;
			InkStyleProperties value;
			if (inkStyleProperties != null)
			{
				value = inkStyleProperties.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (inkStyleProperties == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)96 * (IntPtr)sizeof(void*)));
			inkStyle.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001A79C File Offset: 0x0001899C
		internal unsafe void CreateGradientMesh(GradientMeshPatch[] atchesRef, int patchesCount, GradientMesh gradientMesh)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (GradientMeshPatch[] array = atchesRef)
			{
				void* ptr;
				if (atchesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr, patchesCount, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)97 * (IntPtr)sizeof(void*)));
			}
			gradientMesh.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0001A800 File Offset: 0x00018A00
		internal unsafe void CreateImageSourceFromWic(BitmapSource wicBitmapSource, ImageSourceLoadingOptions loadingOptions, AlphaMode alphaMode, ImageSourceFromWic imageSource)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<BitmapSource>(wicBitmapSource);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, loadingOptions, alphaMode, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)98 * (IntPtr)sizeof(void*)));
			imageSource.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0001A860 File Offset: 0x00018A60
		internal unsafe void CreateLookupTable3D(BufferPrecision precision, int[] extents, byte[] data, int dataCount, int[] strides, LookupTable3D lookupTable)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (int[] array = strides)
			{
				void* ptr;
				if (strides == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (byte[] array2 = data)
				{
					void* ptr2;
					if (data == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (int[] array3 = extents)
					{
						void* ptr3;
						if (extents == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, precision, ptr3, ptr2, dataCount, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)99 * (IntPtr)sizeof(void*)));
					}
				}
			}
			lookupTable.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0001A90C File Offset: 0x00018B0C
		internal unsafe void CreateImageSourceFromDxgi(Surface[] surfaces, int surfaceCount, ColorSpaceType colorSpace, ImageSourceFromDxgiOptions options, ImageSource imageSource)
		{
			IntPtr* ptr = null;
			if (surfaces != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)surfaces.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			IntPtr zero = IntPtr.Zero;
			if (surfaces != null)
			{
				for (int i = 0; i < surfaces.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<Surface>(surfaces[i]);
				}
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, ptr, surfaceCount, colorSpace, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)100 * (IntPtr)sizeof(void*)));
			imageSource.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0001A994 File Offset: 0x00018B94
		public unsafe void GetGradientMeshWorldBounds(GradientMesh gradientMesh, out RawRectangleF boundsRef)
		{
			IntPtr value = IntPtr.Zero;
			boundsRef = default(RawRectangleF);
			value = CppObject.ToCallbackPtr<GradientMesh>(gradientMesh);
			Result result;
			fixed (RawRectangleF* ptr = &boundsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)101 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0001A9F0 File Offset: 0x00018BF0
		public unsafe void DrawInk(Ink ink, Brush brush, InkStyle inkStyle)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr value3 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Ink>(ink);
			value2 = CppObject.ToCallbackPtr<Brush>(brush);
			value3 = CppObject.ToCallbackPtr<InkStyle>(inkStyle);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (void*)value3, *(*(IntPtr*)this._nativePointer + (IntPtr)102 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0001AA54 File Offset: 0x00018C54
		public unsafe void DrawGradientMesh(GradientMesh gradientMesh)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GradientMesh>(gradientMesh);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)103 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0001AA94 File Offset: 0x00018C94
		public unsafe void DrawGdiMetafile(GdiMetafile gdiMetafile, RawRectangleF? destinationRectangle, RawRectangleF? sourceRectangle)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GdiMetafile>(gdiMetafile);
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
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (destinationRectangle == null) ? null : (&value2), (sourceRectangle == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)104 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0001AB14 File Offset: 0x00018D14
		internal unsafe void CreateTransformedImageSource(ImageSource imageSource, ref TransformedImageSourceProperties ropertiesRef, TransformedImageSource transformedImageSource)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ImageSource>(imageSource);
			Result result;
			fixed (TransformedImageSourceProperties* ptr = &ropertiesRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)105 * (IntPtr)sizeof(void*)));
			}
			transformedImageSource.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0001AB7C File Offset: 0x00018D7C
		internal unsafe void CreateImageSourceFromDxgi(ComArray<Surface> surfaces, int surfaceCount, ColorSpaceType colorSpace, ImageSourceFromDxgiOptions options, ImageSource imageSource)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)((surfaces != null) ? surfaces.NativePointer : IntPtr.Zero), surfaceCount, colorSpace, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)100 * (IntPtr)sizeof(void*)));
			imageSource.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0001ABE0 File Offset: 0x00018DE0
		private unsafe void CreateImageSourceFromDxgi(IntPtr surfaces, int surfaceCount, ColorSpaceType colorSpace, ImageSourceFromDxgiOptions options, IntPtr imageSource)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)surfaces, surfaceCount, colorSpace, options, (void*)imageSource, *(*(IntPtr*)this._nativePointer + (IntPtr)100 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
