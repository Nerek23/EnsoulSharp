using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000AE RID: 174
	internal class InlineObjectShadow : ComObjectShadow
	{
		// Token: 0x06000377 RID: 887 RVA: 0x0000CD90 File Offset: 0x0000AF90
		public static IntPtr ToIntPtr(InlineObject callback)
		{
			return CppObject.ToCallbackPtr<InlineObject>(callback);
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000CD98 File Offset: 0x0000AF98
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return InlineObjectShadow.Vtbl;
			}
		}

		// Token: 0x0400024C RID: 588
		private static readonly InlineObjectShadow.InlineObjectVtbl Vtbl = new InlineObjectShadow.InlineObjectVtbl();

		// Token: 0x020000AF RID: 175
		private class InlineObjectVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x0600037B RID: 891 RVA: 0x0000CDAC File Offset: 0x0000AFAC
			public InlineObjectVtbl() : base(4)
			{
				base.AddMethod(new InlineObjectShadow.InlineObjectVtbl.DrawDelegate(InlineObjectShadow.InlineObjectVtbl.DrawImpl));
				base.AddMethod(new InlineObjectShadow.InlineObjectVtbl.GetMetricsDelegate(InlineObjectShadow.InlineObjectVtbl.GetMetricsImpl));
				base.AddMethod(new InlineObjectShadow.InlineObjectVtbl.GetOverhangMetricsDelegate(InlineObjectShadow.InlineObjectVtbl.GetOverhangMetricsImpl));
				base.AddMethod(new InlineObjectShadow.InlineObjectVtbl.GetBreakConditionsDelegate(InlineObjectShadow.InlineObjectVtbl.GetBreakConditionsImpl));
			}

			// Token: 0x0600037C RID: 892 RVA: 0x0000CE08 File Offset: 0x0000B008
			private static int DrawImpl(IntPtr thisPtr, IntPtr clientDrawingContextPtr, IntPtr renderer, float originX, float originY, int isSideways, int isRightToLeft, IntPtr clientDrawingEffectPtr)
			{
				try
				{
					InlineObject inlineObject = (InlineObject)CppObjectShadow.ToShadow<InlineObjectShadow>(thisPtr).Callback;
					TextRendererShadow textRendererShadow = CppObjectShadow.ToShadow<TextRendererShadow>(renderer);
					inlineObject.Draw(GCHandle.FromIntPtr(clientDrawingContextPtr).Target, (TextRenderer)textRendererShadow.Callback, originX, originY, isSideways != 0, isRightToLeft != 0, (ComObject)Utilities.GetObjectForIUnknown(clientDrawingEffectPtr));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0600037D RID: 893 RVA: 0x0000CE94 File Offset: 0x0000B094
			private unsafe static int GetMetricsImpl(IntPtr thisPtr, InlineObjectMetrics* pMetrics)
			{
				try
				{
					InlineObject inlineObject = (InlineObject)CppObjectShadow.ToShadow<InlineObjectShadow>(thisPtr).Callback;
					*pMetrics = inlineObject.Metrics;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0600037E RID: 894 RVA: 0x0000CEEC File Offset: 0x0000B0EC
			private unsafe static int GetOverhangMetricsImpl(IntPtr thisPtr, OverhangMetrics* pOverhangs)
			{
				try
				{
					InlineObject inlineObject = (InlineObject)CppObjectShadow.ToShadow<InlineObjectShadow>(thisPtr).Callback;
					*pOverhangs = inlineObject.OverhangMetrics;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0600037F RID: 895 RVA: 0x0000CF44 File Offset: 0x0000B144
			private static int GetBreakConditionsImpl(IntPtr thisPtr, out BreakCondition breakConditionBefore, out BreakCondition breakConditionAfter)
			{
				breakConditionBefore = BreakCondition.Neutral;
				breakConditionAfter = BreakCondition.Neutral;
				try
				{
					((InlineObject)CppObjectShadow.ToShadow<InlineObjectShadow>(thisPtr).Callback).GetBreakConditions(out breakConditionBefore, out breakConditionAfter);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020000B0 RID: 176
			// (Invoke) Token: 0x06000381 RID: 897
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawDelegate(IntPtr thisPtr, IntPtr clientDrawingContextPtr, IntPtr renderer, float originX, float originY, int isSideways, int isRightToLeft, IntPtr clientDrawingEffectPtr);

			// Token: 0x020000B1 RID: 177
			// (Invoke) Token: 0x06000385 RID: 901
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int GetMetricsDelegate(IntPtr thisPtr, InlineObjectMetrics* pMetrics);

			// Token: 0x020000B2 RID: 178
			// (Invoke) Token: 0x06000389 RID: 905
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int GetOverhangMetricsDelegate(IntPtr thisPtr, OverhangMetrics* pOverhangs);

			// Token: 0x020000B3 RID: 179
			// (Invoke) Token: 0x0600038D RID: 909
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetBreakConditionsDelegate(IntPtr thisPtr, out BreakCondition breakConditionBefore, out BreakCondition breakConditionAfter);
		}
	}
}
