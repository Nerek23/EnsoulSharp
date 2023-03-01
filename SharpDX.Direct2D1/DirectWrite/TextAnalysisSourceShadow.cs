using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000D2 RID: 210
	internal class TextAnalysisSourceShadow : ComObjectShadow
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TextAnalysisSourceShadow.Vtbl;
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000DB00 File Offset: 0x0000BD00
		protected override void Dispose(bool disposing)
		{
			if (this.allocatedStrings != null)
			{
				foreach (IntPtr hglobal in this.allocatedStrings)
				{
					Marshal.FreeHGlobal(hglobal);
				}
				this.allocatedStrings = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000DB68 File Offset: 0x0000BD68
		public static IntPtr ToIntPtr(TextAnalysisSource callback)
		{
			return CppObject.ToCallbackPtr<TextAnalysisSource>(callback);
		}

		// Token: 0x04000268 RID: 616
		private static readonly TextAnalysisSourceShadow.TextAnalysisSourceVtbl Vtbl = new TextAnalysisSourceShadow.TextAnalysisSourceVtbl(0);

		// Token: 0x04000269 RID: 617
		private List<IntPtr> allocatedStrings = new List<IntPtr>();

		// Token: 0x020000D3 RID: 211
		protected class TextAnalysisSourceVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x06000420 RID: 1056 RVA: 0x0000DB90 File Offset: 0x0000BD90
			public TextAnalysisSourceVtbl(int methodCount = 0) : base(5 + methodCount)
			{
				base.AddMethod(new TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetTextAtPositionDelegate(TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetTextAtPositionImpl));
				base.AddMethod(new TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetTextBeforePositionDelegate(TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetTextBeforePositionImpl));
				base.AddMethod(new TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetParagraphReadingDirectionDelegate(TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetParagraphReadingDirectionImpl));
				base.AddMethod(new TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetLocaleNameDelegate(TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetLocaleNameImpl));
				base.AddMethod(new TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetNumberSubstitutionDelegate(TextAnalysisSourceShadow.TextAnalysisSourceVtbl.GetNumberSubstitutionImpl));
			}

			// Token: 0x06000421 RID: 1057 RVA: 0x0000DC00 File Offset: 0x0000BE00
			private static int GetTextAtPositionImpl(IntPtr thisPtr, int textPosition, out IntPtr textString, out int textLength)
			{
				textString = IntPtr.Zero;
				textLength = 0;
				try
				{
					TextAnalysisSourceShadow textAnalysisSourceShadow = CppObjectShadow.ToShadow<TextAnalysisSourceShadow>(thisPtr);
					string textAtPosition = ((TextAnalysisSource)textAnalysisSourceShadow.Callback).GetTextAtPosition(textPosition);
					if (textAtPosition != null)
					{
						textString = Marshal.StringToHGlobalUni(textAtPosition);
						textLength = textAtPosition.Length;
						textAnalysisSourceShadow.allocatedStrings.Add(textString);
					}
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000422 RID: 1058 RVA: 0x0000DC80 File Offset: 0x0000BE80
			private static int GetTextBeforePositionImpl(IntPtr thisPtr, int textPosition, out IntPtr textString, out int textLength)
			{
				textString = IntPtr.Zero;
				textLength = 0;
				try
				{
					TextAnalysisSourceShadow textAnalysisSourceShadow = CppObjectShadow.ToShadow<TextAnalysisSourceShadow>(thisPtr);
					string textBeforePosition = ((TextAnalysisSource)textAnalysisSourceShadow.Callback).GetTextBeforePosition(textPosition);
					if (textBeforePosition != null)
					{
						textString = Marshal.StringToHGlobalUni(textBeforePosition);
						textLength = textBeforePosition.Length;
						textAnalysisSourceShadow.allocatedStrings.Add(textString);
					}
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000423 RID: 1059 RVA: 0x0000DD00 File Offset: 0x0000BF00
			private static ReadingDirection GetParagraphReadingDirectionImpl(IntPtr thisPtr)
			{
				return ((TextAnalysisSource)CppObjectShadow.ToShadow<TextAnalysisSourceShadow>(thisPtr).Callback).ReadingDirection;
			}

			// Token: 0x06000424 RID: 1060 RVA: 0x0000DD18 File Offset: 0x0000BF18
			private static int GetLocaleNameImpl(IntPtr thisPtr, int textPosition, out int textLength, out IntPtr textString)
			{
				textString = IntPtr.Zero;
				textLength = 0;
				try
				{
					TextAnalysisSourceShadow textAnalysisSourceShadow = CppObjectShadow.ToShadow<TextAnalysisSourceShadow>(thisPtr);
					string localeName = ((TextAnalysisSource)textAnalysisSourceShadow.Callback).GetLocaleName(textPosition, out textLength);
					if (localeName != null)
					{
						textString = Marshal.StringToHGlobalUni(localeName);
						textAnalysisSourceShadow.allocatedStrings.Add(textString);
					}
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x06000425 RID: 1061 RVA: 0x0000DD90 File Offset: 0x0000BF90
			private static int GetNumberSubstitutionImpl(IntPtr thisPtr, int textPosition, out int textLength, out IntPtr numberSubstitutionPtr)
			{
				numberSubstitutionPtr = IntPtr.Zero;
				textLength = 0;
				try
				{
					NumberSubstitution numberSubstitution = ((TextAnalysisSource)CppObjectShadow.ToShadow<TextAnalysisSourceShadow>(thisPtr).Callback).GetNumberSubstitution(textPosition, out textLength);
					numberSubstitutionPtr = ((numberSubstitution == null) ? IntPtr.Zero : numberSubstitution.NativePointer);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020000D4 RID: 212
			// (Invoke) Token: 0x06000427 RID: 1063
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetTextAtPositionDelegate(IntPtr thisPtr, int textPosition, out IntPtr textString, out int textLength);

			// Token: 0x020000D5 RID: 213
			// (Invoke) Token: 0x0600042B RID: 1067
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetTextBeforePositionDelegate(IntPtr thisPtr, int textPosition, out IntPtr textString, out int textLength);

			// Token: 0x020000D6 RID: 214
			// (Invoke) Token: 0x0600042F RID: 1071
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate ReadingDirection GetParagraphReadingDirectionDelegate(IntPtr thisPtr);

			// Token: 0x020000D7 RID: 215
			// (Invoke) Token: 0x06000433 RID: 1075
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetLocaleNameDelegate(IntPtr thisPtr, int textPosition, out int textLength, out IntPtr textString);

			// Token: 0x020000D8 RID: 216
			// (Invoke) Token: 0x06000437 RID: 1079
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetNumberSubstitutionDelegate(IntPtr thisPtr, int textPosition, out int textLength, out IntPtr numberSubstitutionPtr);
		}
	}
}
