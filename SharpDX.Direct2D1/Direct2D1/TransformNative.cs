using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200023D RID: 573
	[Guid("ef1a287d-342a-4f76-8fdb-da0d6ea9f92b")]
	public class TransformNative : TransformNodeNative, Transform, TransformNode, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000D3E RID: 3390 RVA: 0x00024986 File Offset: 0x00022B86
		public void MapOutputRectangleToInputRectangles(RawRectangle outputRect, RawRectangle[] inputRects)
		{
			this.MapOutputRectToInputRects_(outputRect, inputRects, inputRects.Length);
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00024993 File Offset: 0x00022B93
		public RawRectangle MapInputRectanglesToOutputRectangle(RawRectangle[] inputRects, RawRectangle[] inputOpaqueSubRects, out RawRectangle outputOpaqueSubRect)
		{
			return this.MapInputRectsToOutputRect_(inputRects, inputOpaqueSubRects, inputRects.Length, out outputOpaqueSubRect);
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x000249A1 File Offset: 0x00022BA1
		public RawRectangle MapInvalidRect(int inputIndex, RawRectangle invalidInputRect)
		{
			return this.MapInvalidRect_(inputIndex, invalidInputRect);
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0001614D File Offset: 0x0001434D
		public TransformNative(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x000249AB File Offset: 0x00022BAB
		public new static explicit operator TransformNative(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TransformNative(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x000249C4 File Offset: 0x00022BC4
		internal unsafe void MapOutputRectToInputRects_(RawRectangle outputRect, RawRectangle[] inputRects, int inputRectsCount)
		{
			Result result;
			fixed (RawRectangle[] array = inputRects)
			{
				void* ptr;
				if (inputRects == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, &outputRect, ptr, inputRectsCount, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00024A1C File Offset: 0x00022C1C
		internal unsafe RawRectangle MapInputRectsToOutputRect_(RawRectangle[] inputRects, RawRectangle[] inputOpaqueSubRects, int inputRectCount, out RawRectangle outputOpaqueSubRect)
		{
			outputOpaqueSubRect = default(RawRectangle);
			RawRectangle result2;
			Result result;
			fixed (RawRectangle* ptr = &outputOpaqueSubRect)
			{
				void* ptr2 = (void*)ptr;
				fixed (RawRectangle[] array = inputOpaqueSubRects)
				{
					void* ptr3;
					if (inputOpaqueSubRects == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					fixed (RawRectangle[] array2 = inputRects)
					{
						void* ptr4;
						if (inputRects == null || array2.Length == 0)
						{
							ptr4 = null;
						}
						else
						{
							ptr4 = (void*)(&array2[0]);
						}
						result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, ptr4, ptr3, inputRectCount, &result2, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
					}
				}
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x00024AB0 File Offset: 0x00022CB0
		internal unsafe RawRectangle MapInvalidRect_(int inputIndex, RawRectangle invalidInputRect)
		{
			RawRectangle result;
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawRectangle,System.Void*), this._nativePointer, inputIndex, invalidInputRect, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}
	}
}
