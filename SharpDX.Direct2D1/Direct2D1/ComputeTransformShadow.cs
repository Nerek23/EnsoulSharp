using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001AB RID: 427
	internal class ComputeTransformShadow : TransformShadow
	{
		// Token: 0x0600083B RID: 2107 RVA: 0x0001812A File Offset: 0x0001632A
		public static IntPtr ToIntPtr(ComputeTransform callback)
		{
			return CppObject.ToCallbackPtr<ComputeTransform>(callback);
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x00018132 File Offset: 0x00016332
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return ComputeTransformShadow.Vtbl;
			}
		}

		// Token: 0x040005FB RID: 1531
		private static readonly ComputeTransformShadow.ComputeTransformVtbl Vtbl = new ComputeTransformShadow.ComputeTransformVtbl(0);

		// Token: 0x020001AC RID: 428
		public class ComputeTransformVtbl : TransformShadow.TransformVtbl
		{
			// Token: 0x0600083F RID: 2111 RVA: 0x0001814E File Offset: 0x0001634E
			public ComputeTransformVtbl(int methods) : base(2 + methods)
			{
				base.AddMethod(new ComputeTransformShadow.ComputeTransformVtbl.SetComputeInformationDelegate(ComputeTransformShadow.ComputeTransformVtbl.SetComputeInformationImpl));
				base.AddMethod(new ComputeTransformShadow.ComputeTransformVtbl.CalculateThreadgroupsDelegate(ComputeTransformShadow.ComputeTransformVtbl.CalculateThreadgroupsImpl));
			}

			// Token: 0x06000840 RID: 2112 RVA: 0x00018180 File Offset: 0x00016380
			private static int SetComputeInformationImpl(IntPtr thisPtr, IntPtr computeInfo)
			{
				try
				{
					((ComputeTransform)CppObjectShadow.ToShadow<ComputeTransformShadow>(thisPtr).Callback).SetComputeInformation(new ComputeInformation(computeInfo));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000841 RID: 2113 RVA: 0x000181D8 File Offset: 0x000163D8
			private unsafe static int CalculateThreadgroupsImpl(IntPtr thisPtr, IntPtr rect, out int dimX, out int dimY, out int dimZ)
			{
				int num = dimZ = 0;
				num = (dimY = num);
				dimX = num;
				try
				{
					RawInt3 rawInt = ((ComputeTransform)CppObjectShadow.ToShadow<ComputeTransformShadow>(thisPtr).Callback).CalculateThreadgroups(*(RawRectangle*)((void*)rect));
					dimX = rawInt.X;
					dimY = rawInt.Y;
					dimZ = rawInt.Z;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020001AD RID: 429
			// (Invoke) Token: 0x06000843 RID: 2115
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetComputeInformationDelegate(IntPtr thisPtr, IntPtr computeInfo);

			// Token: 0x020001AE RID: 430
			// (Invoke) Token: 0x06000847 RID: 2119
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CalculateThreadgroupsDelegate(IntPtr thisPtr, IntPtr rect, out int dimX, out int dimY, out int dimZ);
		}
	}
}
