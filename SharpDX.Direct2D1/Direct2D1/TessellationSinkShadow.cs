using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000236 RID: 566
	internal class TessellationSinkShadow : ComObjectShadow
	{
		// Token: 0x06000D1E RID: 3358 RVA: 0x000246EB File Offset: 0x000228EB
		public static IntPtr ToIntPtr(TessellationSink tessellationSink)
		{
			return CppObject.ToCallbackPtr<TessellationSink>(tessellationSink);
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x000246F3 File Offset: 0x000228F3
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TessellationSinkShadow.Vtbl;
			}
		}

		// Token: 0x040006C4 RID: 1732
		private static readonly TessellationSinkShadow.TessellationSinkVtbl Vtbl = new TessellationSinkShadow.TessellationSinkVtbl();

		// Token: 0x02000237 RID: 567
		public class TessellationSinkVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000D22 RID: 3362 RVA: 0x00024706 File Offset: 0x00022906
			public TessellationSinkVtbl() : base(2)
			{
				base.AddMethod(new TessellationSinkShadow.TessellationSinkVtbl.AddTrianglesDelegate(TessellationSinkShadow.TessellationSinkVtbl.AddTrianglesImpl));
				base.AddMethod(new TessellationSinkShadow.TessellationSinkVtbl.CloseDelegate(TessellationSinkShadow.TessellationSinkVtbl.CloseImpl));
			}

			// Token: 0x06000D23 RID: 3363 RVA: 0x00024734 File Offset: 0x00022934
			private static void AddTrianglesImpl(IntPtr thisPtr, IntPtr triangles, int trianglesCount)
			{
				TessellationSink tessellationSink = (TessellationSink)CppObjectShadow.ToShadow<TessellationSinkShadow>(thisPtr).Callback;
				Triangle[] array = new Triangle[trianglesCount];
				Utilities.Read<Triangle>(triangles, array, 0, trianglesCount);
				tessellationSink.AddTriangles(array);
			}

			// Token: 0x06000D24 RID: 3364 RVA: 0x00024768 File Offset: 0x00022968
			private static int CloseImpl(IntPtr thisPtr)
			{
				try
				{
					((TessellationSink)CppObjectShadow.ToShadow<TessellationSinkShadow>(thisPtr).Callback).Close();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000238 RID: 568
			// (Invoke) Token: 0x06000D26 RID: 3366
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate void AddTrianglesDelegate(IntPtr thisPtr, IntPtr triangles, int trianglesCount);

			// Token: 0x02000239 RID: 569
			// (Invoke) Token: 0x06000D2A RID: 3370
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CloseDelegate(IntPtr thisPtr);
		}
	}
}
