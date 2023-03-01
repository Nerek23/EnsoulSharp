using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D7 RID: 471
	internal class DrawTransformShadow : TransformShadow
	{
		// Token: 0x0600098D RID: 2445 RVA: 0x0001B8B6 File Offset: 0x00019AB6
		public static IntPtr ToIntPtr(DrawTransform callback)
		{
			return CppObject.ToCallbackPtr<DrawTransform>(callback);
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x0001B8BE File Offset: 0x00019ABE
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return DrawTransformShadow.Vtbl;
			}
		}

		// Token: 0x04000620 RID: 1568
		private static readonly DrawTransformShadow.DrawTransformVtbl Vtbl = new DrawTransformShadow.DrawTransformVtbl(0);

		// Token: 0x020001D8 RID: 472
		public class DrawTransformVtbl : TransformShadow.TransformVtbl
		{
			// Token: 0x06000991 RID: 2449 RVA: 0x0001B8D2 File Offset: 0x00019AD2
			public DrawTransformVtbl(int methods) : base(1 + methods)
			{
				base.AddMethod(new DrawTransformShadow.DrawTransformVtbl.SetDrawInfoDelegate(DrawTransformShadow.DrawTransformVtbl.SetDrawInfoImpl));
			}

			// Token: 0x06000992 RID: 2450 RVA: 0x0001B8F0 File Offset: 0x00019AF0
			private static int SetDrawInfoImpl(IntPtr thisPtr, IntPtr drawInfo)
			{
				try
				{
					((DrawTransform)CppObjectShadow.ToShadow<DrawTransformShadow>(thisPtr).Callback).SetDrawInformation(new DrawInformation(drawInfo));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020001D9 RID: 473
			// (Invoke) Token: 0x06000994 RID: 2452
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetDrawInfoDelegate(IntPtr thisPtr, IntPtr drawInfo);
		}
	}
}
