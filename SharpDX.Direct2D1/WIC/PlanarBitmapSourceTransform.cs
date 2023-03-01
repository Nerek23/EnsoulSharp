using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000073 RID: 115
	[Guid("3AFF9CCE-BE95-4303-B927-E7D16FF4A613")]
	public class PlanarBitmapSourceTransform : ComObject
	{
		// Token: 0x06000254 RID: 596 RVA: 0x00002A7F File Offset: 0x00000C7F
		public PlanarBitmapSourceTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000996C File Offset: 0x00007B6C
		public new static explicit operator PlanarBitmapSourceTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PlanarBitmapSourceTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00009984 File Offset: 0x00007B84
		public unsafe void DoesSupportTransform(ref int widthRef, ref int heightRef, BitmapTransformOptions dstTransform, PlanarOptions dstPlanarOptions, Guid[] guidDstFormatsRef, BitmapPlaneDescription[] planeDescriptionsRef, int planes, out RawBool fIsSupportedRef)
		{
			fIsSupportedRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fIsSupportedRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (BitmapPlaneDescription[] array = planeDescriptionsRef)
				{
					void* ptr3;
					if (planeDescriptionsRef == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					fixed (Guid[] array2 = guidDstFormatsRef)
					{
						void* ptr4;
						if (guidDstFormatsRef == null || array2.Length == 0)
						{
							ptr4 = null;
						}
						else
						{
							ptr4 = (void*)(&array2[0]);
						}
						fixed (int* ptr5 = &heightRef)
						{
							void* ptr6 = (void*)ptr5;
							fixed (int* ptr7 = &widthRef)
							{
								void* ptr8 = (void*)ptr7;
								result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr8, ptr6, dstTransform, dstPlanarOptions, ptr4, ptr3, planes, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00009A34 File Offset: 0x00007C34
		public unsafe void CopyPixels(RawBox? rcSourceRef, int width, int height, BitmapTransformOptions dstTransform, PlanarOptions dstPlanarOptions, BitmapPlane[] dstPlanesRef, int planes)
		{
			RawBox value;
			if (rcSourceRef != null)
			{
				value = rcSourceRef.Value;
			}
			Result result;
			fixed (BitmapPlane[] array = dstPlanesRef)
			{
				void* ptr;
				if (dstPlanesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, (rcSourceRef == null) ? null : (&value), width, height, dstTransform, dstPlanarOptions, ptr, planes, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
