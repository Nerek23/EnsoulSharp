using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000BA RID: 186
	internal abstract class PixelSnappingShadow : ComObjectShadow
	{
		// Token: 0x020000BB RID: 187
		public class PixelSnappingVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x060003B8 RID: 952 RVA: 0x0000D450 File Offset: 0x0000B650
			protected PixelSnappingVtbl(int nbMethods) : base(nbMethods + 3)
			{
				base.AddMethod(new PixelSnappingShadow.PixelSnappingVtbl.IsPixelSnappingDisabledDelegate(PixelSnappingShadow.PixelSnappingVtbl.IsPixelSnappingDisabledImpl));
				base.AddMethod(new PixelSnappingShadow.PixelSnappingVtbl.GetCurrentTransformDelegate(PixelSnappingShadow.PixelSnappingVtbl.GetCurrentTransformImpl));
				base.AddMethod(new PixelSnappingShadow.PixelSnappingVtbl.GetPixelsPerDipDelegate(PixelSnappingShadow.PixelSnappingVtbl.GetPixelsPerDipImpl));
			}

			// Token: 0x060003B9 RID: 953 RVA: 0x0000D49C File Offset: 0x0000B69C
			private static int IsPixelSnappingDisabledImpl(IntPtr thisPtr, IntPtr clientDrawingContextPtr, out int isDisabled)
			{
				isDisabled = 0;
				try
				{
					PixelSnapping pixelSnapping = (PixelSnapping)CppObjectShadow.ToShadow<PixelSnappingShadow>(thisPtr).Callback;
					isDisabled = (pixelSnapping.IsPixelSnappingDisabled(GCHandle.FromIntPtr(clientDrawingContextPtr).Target) ? 1 : 0);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060003BA RID: 954 RVA: 0x0000D508 File Offset: 0x0000B708
			private static int GetCurrentTransformImpl(IntPtr thisPtr, IntPtr clientDrawingContextPtr, IntPtr transform)
			{
				try
				{
					RawMatrix3x2 currentTransform = ((PixelSnapping)CppObjectShadow.ToShadow<PixelSnappingShadow>(thisPtr).Callback).GetCurrentTransform(GCHandle.FromIntPtr(clientDrawingContextPtr).Target);
					Utilities.Write<RawMatrix3x2>(transform, ref currentTransform);
				}
				catch (SharpDXException ex)
				{
					return ex.ResultCode.Code;
				}
				catch (Exception)
				{
					return Result.Fail.Code;
				}
				return Result.Ok.Code;
			}

			// Token: 0x060003BB RID: 955 RVA: 0x0000D58C File Offset: 0x0000B78C
			private static int GetPixelsPerDipImpl(IntPtr thisPtr, IntPtr clientDrawingContextPtr, out float pixelPerDip)
			{
				pixelPerDip = 0f;
				try
				{
					PixelSnapping pixelSnapping = (PixelSnapping)CppObjectShadow.ToShadow<PixelSnappingShadow>(thisPtr).Callback;
					pixelPerDip = pixelSnapping.GetPixelsPerDip(GCHandle.FromIntPtr(clientDrawingContextPtr).Target);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020000BC RID: 188
			// (Invoke) Token: 0x060003BD RID: 957
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int IsPixelSnappingDisabledDelegate(IntPtr thisPtr, IntPtr clientDrawingContext, out int isDisabled);

			// Token: 0x020000BD RID: 189
			// (Invoke) Token: 0x060003C1 RID: 961
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetCurrentTransformDelegate(IntPtr thisPtr, IntPtr clientDrawingContext, IntPtr transform);

			// Token: 0x020000BE RID: 190
			// (Invoke) Token: 0x060003C5 RID: 965
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetPixelsPerDipDelegate(IntPtr thisPtr, IntPtr clientDrawingContext, out float pixelPerDip);
		}
	}
}
