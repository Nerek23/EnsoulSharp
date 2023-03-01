using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000243 RID: 579
	internal class TransformShadow : TransformNodeShadow
	{
		// Token: 0x06000D56 RID: 3414 RVA: 0x00024B5C File Offset: 0x00022D5C
		public static IntPtr ToIntPtr(Transform callback)
		{
			return CppObject.ToCallbackPtr<Transform>(callback);
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000D57 RID: 3415 RVA: 0x00024B64 File Offset: 0x00022D64
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TransformShadow.Vtbl;
			}
		}

		// Token: 0x040006C6 RID: 1734
		private static readonly TransformShadow.TransformVtbl Vtbl = new TransformShadow.TransformVtbl(0);

		// Token: 0x02000244 RID: 580
		public class TransformVtbl : TransformNodeShadow.TransformNodeVtbl
		{
			// Token: 0x06000D5A RID: 3418 RVA: 0x00024B80 File Offset: 0x00022D80
			public TransformVtbl(int methods) : base(3 + methods)
			{
				base.AddMethod(new TransformShadow.TransformVtbl.MapOutputRectToInputRectsDelegate(TransformShadow.TransformVtbl.MapOutputRectToInputRectsImpl));
				base.AddMethod(new TransformShadow.TransformVtbl.MapInputRectsToOutputRectDelegate(TransformShadow.TransformVtbl.MapInputRectsToOutputRectImpl));
				base.AddMethod(new TransformShadow.TransformVtbl.MapInvalidRectDelegate(TransformShadow.TransformVtbl.MapInvalidRectImpl));
			}

			// Token: 0x06000D5B RID: 3419 RVA: 0x00024BCC File Offset: 0x00022DCC
			private unsafe static int MapOutputRectToInputRectsImpl(IntPtr thisPtr, IntPtr outputRect, IntPtr inputRects, int inputRectsCount)
			{
				try
				{
					Transform transform = (Transform)CppObjectShadow.ToShadow<TransformShadow>(thisPtr).Callback;
					RawRectangle[] array = new RawRectangle[inputRectsCount];
					Utilities.Read<RawRectangle>(inputRects, array, 0, inputRectsCount);
					transform.MapOutputRectangleToInputRectangles(*(RawRectangle*)((void*)outputRect), array);
					Utilities.Write<RawRectangle>(inputRects, array, 0, inputRectsCount);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000D5C RID: 3420 RVA: 0x00024C44 File Offset: 0x00022E44
			private unsafe static int MapInputRectsToOutputRectImpl(IntPtr thisPtr, IntPtr inputRects, IntPtr inputOpaqueSubRects, int inputRectsCount, IntPtr outputRect, IntPtr outputOpaqueSubRect)
			{
				try
				{
					Transform transform = (Transform)CppObjectShadow.ToShadow<TransformShadow>(thisPtr).Callback;
					RawRectangle[] array = new RawRectangle[inputRectsCount];
					Utilities.Read<RawRectangle>(inputRects, array, 0, inputRectsCount);
					RawRectangle[] array2 = new RawRectangle[inputRectsCount];
					Utilities.Read<RawRectangle>(inputOpaqueSubRects, array2, 0, inputRectsCount);
					*(RawRectangle*)((void*)outputRect) = transform.MapInputRectanglesToOutputRectangle(array, array2, out *(RawRectangle*)((void*)outputOpaqueSubRect));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000D5D RID: 3421 RVA: 0x00024CD0 File Offset: 0x00022ED0
			private unsafe static int MapInvalidRectImpl(IntPtr thisPtr, int inputIndex, IntPtr invalidInputRect, IntPtr invalidOutputRect)
			{
				try
				{
					Transform transform = (Transform)CppObjectShadow.ToShadow<TransformShadow>(thisPtr).Callback;
					*(RawRectangle*)((void*)invalidOutputRect) = transform.MapInvalidRect(inputIndex, *(RawRectangle*)((void*)invalidInputRect));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000245 RID: 581
			// (Invoke) Token: 0x06000D5F RID: 3423
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int MapOutputRectToInputRectsDelegate(IntPtr thisPtr, IntPtr outputRect, IntPtr inputRects, int inputRectsCount);

			// Token: 0x02000246 RID: 582
			// (Invoke) Token: 0x06000D63 RID: 3427
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int MapInputRectsToOutputRectDelegate(IntPtr thisPtr, IntPtr inputRects, IntPtr inputOpaqueSubRects, int inputRectsCount, IntPtr outputRect, IntPtr outputOpaqueSubRect);

			// Token: 0x02000247 RID: 583
			// (Invoke) Token: 0x06000D67 RID: 3431
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int MapInvalidRectDelegate(IntPtr thisPtr, int inputIndex, IntPtr invalidInputRect, IntPtr invalidOutputRect);
		}
	}
}
