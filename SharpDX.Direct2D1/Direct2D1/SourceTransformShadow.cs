using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200022A RID: 554
	internal class SourceTransformShadow : TransformShadow
	{
		// Token: 0x06000C86 RID: 3206 RVA: 0x00022D92 File Offset: 0x00020F92
		public static IntPtr ToIntPtr(SourceTransform callback)
		{
			return CppObject.ToCallbackPtr<SourceTransform>(callback);
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00022D9A File Offset: 0x00020F9A
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return SourceTransformShadow.Vtbl;
			}
		}

		// Token: 0x040006C3 RID: 1731
		private static readonly SourceTransformShadow.SourceTransformVtbl Vtbl = new SourceTransformShadow.SourceTransformVtbl(0);

		// Token: 0x0200022B RID: 555
		public class SourceTransformVtbl : TransformShadow.TransformVtbl
		{
			// Token: 0x06000C8A RID: 3210 RVA: 0x00022DAE File Offset: 0x00020FAE
			public SourceTransformVtbl(int methods) : base(2 + methods)
			{
				base.AddMethod(new SourceTransformShadow.SourceTransformVtbl.SetRenderInformationDelegate(SourceTransformShadow.SourceTransformVtbl.SetRenderInformationImpl));
				base.AddMethod(new SourceTransformShadow.SourceTransformVtbl.DrawDelegate(SourceTransformShadow.SourceTransformVtbl.DrawImpl));
			}

			// Token: 0x06000C8B RID: 3211 RVA: 0x00022DE0 File Offset: 0x00020FE0
			private static int SetRenderInformationImpl(IntPtr thisPtr, IntPtr renderInfo)
			{
				try
				{
					((SourceTransform)CppObjectShadow.ToShadow<SourceTransformShadow>(thisPtr).Callback).SetRenderInformation(new RenderInformation(renderInfo));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000C8C RID: 3212 RVA: 0x00022E38 File Offset: 0x00021038
			private unsafe static int DrawImpl(IntPtr thisPtr, IntPtr target, IntPtr drawRect, RawPoint targetOrigin)
			{
				try
				{
					((SourceTransform)CppObjectShadow.ToShadow<SourceTransformShadow>(thisPtr).Callback).Draw(new Bitmap1(target), *(RawRectangle*)((void*)drawRect), targetOrigin);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0200022C RID: 556
			// (Invoke) Token: 0x06000C8E RID: 3214
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetRenderInformationDelegate(IntPtr thisPtr, IntPtr renderInfo);

			// Token: 0x0200022D RID: 557
			// (Invoke) Token: 0x06000C92 RID: 3218
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawDelegate(IntPtr thisPtr, IntPtr target, IntPtr drawRect, RawPoint targetOrigin);
		}
	}
}
