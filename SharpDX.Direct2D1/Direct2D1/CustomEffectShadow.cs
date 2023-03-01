using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001BD RID: 445
	internal class CustomEffectShadow : ComObjectShadow
	{
		// Token: 0x06000891 RID: 2193 RVA: 0x00018AB2 File Offset: 0x00016CB2
		public static IntPtr ToIntPtr(CustomEffect callback)
		{
			return CppObject.ToCallbackPtr<CustomEffect>(callback);
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x00018ABA File Offset: 0x00016CBA
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return CustomEffectShadow.Vtbl;
			}
		}

		// Token: 0x04000611 RID: 1553
		private static readonly CustomEffectShadow.CustomEffectVtbl Vtbl = new CustomEffectShadow.CustomEffectVtbl();

		// Token: 0x020001BE RID: 446
		public class CustomEffectVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000895 RID: 2197 RVA: 0x00018ACD File Offset: 0x00016CCD
			public CustomEffectVtbl() : base(3)
			{
				base.AddMethod(new CustomEffectShadow.CustomEffectVtbl.InitializeDelegate(CustomEffectShadow.CustomEffectVtbl.InitializeImpl));
				base.AddMethod(new CustomEffectShadow.CustomEffectVtbl.PrepareForRenderDelegate(CustomEffectShadow.CustomEffectVtbl.PrepareForRenderImpl));
				base.AddMethod(new CustomEffectShadow.CustomEffectVtbl.SetGraphDelegate(CustomEffectShadow.CustomEffectVtbl.SetGraphImpl));
			}

			// Token: 0x06000896 RID: 2198 RVA: 0x00018B0C File Offset: 0x00016D0C
			private static int InitializeImpl(IntPtr thisPtr, IntPtr effectContext, IntPtr transformationGraph)
			{
				try
				{
					((CustomEffect)CppObjectShadow.ToShadow<CustomEffectShadow>(thisPtr).Callback).Initialize(new EffectContext(effectContext), new TransformGraph(transformationGraph));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000897 RID: 2199 RVA: 0x00018B68 File Offset: 0x00016D68
			private static int PrepareForRenderImpl(IntPtr thisPtr, ChangeType changeType)
			{
				try
				{
					((CustomEffect)CppObjectShadow.ToShadow<CustomEffectShadow>(thisPtr).Callback).PrepareForRender(changeType);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000898 RID: 2200 RVA: 0x00018BBC File Offset: 0x00016DBC
			private static int SetGraphImpl(IntPtr thisPtr, IntPtr transformGraph)
			{
				try
				{
					((CustomEffect)CppObjectShadow.ToShadow<CustomEffectShadow>(thisPtr).Callback).SetGraph(new TransformGraph(transformGraph));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020001BF RID: 447
			// (Invoke) Token: 0x0600089A RID: 2202
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int InitializeDelegate(IntPtr thisPtr, IntPtr effectContext, IntPtr transformationGraph);

			// Token: 0x020001C0 RID: 448
			// (Invoke) Token: 0x0600089E RID: 2206
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int PrepareForRenderDelegate(IntPtr thisPtr, ChangeType changeType);

			// Token: 0x020001C1 RID: 449
			// (Invoke) Token: 0x060008A2 RID: 2210
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetGraphDelegate(IntPtr thisPtr, IntPtr transformGraph);
		}
	}
}
