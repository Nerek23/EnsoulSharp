using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000C7 RID: 199
	internal class TextAnalysisSinkShadow : ComObjectShadow
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x0000D870 File Offset: 0x0000BA70
		public static IntPtr ToIntPtr(TextAnalysisSink callback)
		{
			return CppObject.ToCallbackPtr<TextAnalysisSink>(callback);
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000D878 File Offset: 0x0000BA78
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TextAnalysisSinkShadow.Vtbl;
			}
		}

		// Token: 0x04000266 RID: 614
		private static readonly TextAnalysisSinkShadow.TextAnalysisSinkVtbl Vtbl = new TextAnalysisSinkShadow.TextAnalysisSinkVtbl(0);

		// Token: 0x020000C8 RID: 200
		protected class TextAnalysisSinkVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x060003F6 RID: 1014 RVA: 0x0000D88C File Offset: 0x0000BA8C
			public TextAnalysisSinkVtbl(int methodCount = 0) : base(4 + methodCount)
			{
				base.AddMethod(new TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetScriptAnalysisDelegate(TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetScriptAnalysisImpl));
				base.AddMethod(new TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetLineBreakpointsDelegate(TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetLineBreakpointsImpl));
				base.AddMethod(new TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetBidiLevelDelegate(TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetBidiLevelImpl));
				base.AddMethod(new TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetNumberSubstitutionDelegate(TextAnalysisSinkShadow.TextAnalysisSinkVtbl.SetNumberSubstitutionImpl));
			}

			// Token: 0x060003F7 RID: 1015 RVA: 0x0000D8EC File Offset: 0x0000BAEC
			private unsafe static int SetScriptAnalysisImpl(IntPtr thisPtr, int textPosition, int textLength, ScriptAnalysis* scriptAnalysis)
			{
				try
				{
					((TextAnalysisSink)CppObjectShadow.ToShadow<TextAnalysisSinkShadow>(thisPtr).Callback).SetScriptAnalysis(textPosition, textLength, *scriptAnalysis);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060003F8 RID: 1016 RVA: 0x0000D944 File Offset: 0x0000BB44
			private static int SetLineBreakpointsImpl(IntPtr thisPtr, int textPosition, int textLength, IntPtr pLineBreakpoints)
			{
				try
				{
					TextAnalysisSink textAnalysisSink = (TextAnalysisSink)CppObjectShadow.ToShadow<TextAnalysisSinkShadow>(thisPtr).Callback;
					LineBreakpoint[] array = new LineBreakpoint[textLength];
					Utilities.Read<LineBreakpoint>(pLineBreakpoints, array, 0, textLength);
					textAnalysisSink.SetLineBreakpoints(textPosition, textLength, array);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060003F9 RID: 1017 RVA: 0x0000D9A8 File Offset: 0x0000BBA8
			private static int SetBidiLevelImpl(IntPtr thisPtr, int textPosition, int textLength, byte explicitLevel, byte resolvedLevel)
			{
				try
				{
					((TextAnalysisSink)CppObjectShadow.ToShadow<TextAnalysisSinkShadow>(thisPtr).Callback).SetBidiLevel(textPosition, textLength, explicitLevel, resolvedLevel);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060003FA RID: 1018 RVA: 0x0000DA00 File Offset: 0x0000BC00
			private static int SetNumberSubstitutionImpl(IntPtr thisPtr, int textPosition, int textLength, IntPtr numberSubstitution)
			{
				try
				{
					((TextAnalysisSink)CppObjectShadow.ToShadow<TextAnalysisSinkShadow>(thisPtr).Callback).SetNumberSubstitution(textPosition, textLength, new NumberSubstitution(numberSubstitution));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020000C9 RID: 201
			// (Invoke) Token: 0x060003FC RID: 1020
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int SetScriptAnalysisDelegate(IntPtr thisPtr, int textPosition, int textLength, ScriptAnalysis* scriptAnalysis);

			// Token: 0x020000CA RID: 202
			// (Invoke) Token: 0x06000400 RID: 1024
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetLineBreakpointsDelegate(IntPtr thisPtr, int textPosition, int textLength, IntPtr pLineBreakpoints);

			// Token: 0x020000CB RID: 203
			// (Invoke) Token: 0x06000404 RID: 1028
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetBidiLevelDelegate(IntPtr thisPtr, int textPosition, int textLength, byte explicitLevel, byte resolvedLevel);

			// Token: 0x020000CC RID: 204
			// (Invoke) Token: 0x06000408 RID: 1032
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetNumberSubstitutionDelegate(IntPtr thisPtr, int textPosition, int textLength, IntPtr numberSubstitution);
		}
	}
}
