using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000240 RID: 576
	internal class TransformNodeShadow : ComObjectShadow
	{
		// Token: 0x06000D4C RID: 3404 RVA: 0x00024B0C File Offset: 0x00022D0C
		public static IntPtr ToIntPtr(TransformNode callback)
		{
			return CppObject.ToCallbackPtr<TransformNode>(callback);
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x00024B14 File Offset: 0x00022D14
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TransformNodeShadow.Vtbl;
			}
		}

		// Token: 0x040006C5 RID: 1733
		private static readonly TransformNodeShadow.TransformNodeVtbl Vtbl = new TransformNodeShadow.TransformNodeVtbl(0);

		// Token: 0x02000241 RID: 577
		public class TransformNodeVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000D50 RID: 3408 RVA: 0x00024B28 File Offset: 0x00022D28
			public TransformNodeVtbl(int methods) : base(1 + methods)
			{
				base.AddMethod(new TransformNodeShadow.TransformNodeVtbl.GetInputCountDelegate(TransformNodeShadow.TransformNodeVtbl.GetInputCountImpl));
			}

			// Token: 0x06000D51 RID: 3409 RVA: 0x00024B45 File Offset: 0x00022D45
			private static int GetInputCountImpl(IntPtr thisPtr)
			{
				return ((TransformNode)CppObjectShadow.ToShadow<TransformNodeShadow>(thisPtr).Callback).InputCount;
			}

			// Token: 0x02000242 RID: 578
			// (Invoke) Token: 0x06000D53 RID: 3411
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetInputCountDelegate(IntPtr thisPtr);
		}
	}
}
