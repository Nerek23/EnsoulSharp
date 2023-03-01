using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000CF RID: 207
	internal class TextAnalysisSource1Shadow : TextAnalysisSourceShadow
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000DA58 File Offset: 0x0000BC58
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TextAnalysisSource1Shadow.Vtbl;
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000DA5F File Offset: 0x0000BC5F
		public static IntPtr ToIntPtr(TextAnalysisSource1 callback)
		{
			return CppObject.ToCallbackPtr<TextAnalysisSource1>(callback);
		}

		// Token: 0x04000267 RID: 615
		private static readonly TextAnalysisSource1Shadow.TextAnalysisSource1Vtbl Vtbl = new TextAnalysisSource1Shadow.TextAnalysisSource1Vtbl();

		// Token: 0x020000D0 RID: 208
		private class TextAnalysisSource1Vtbl : TextAnalysisSourceShadow.TextAnalysisSourceVtbl
		{
			// Token: 0x06000415 RID: 1045 RVA: 0x0000DA7B File Offset: 0x0000BC7B
			public TextAnalysisSource1Vtbl() : base(1)
			{
				base.AddMethod(new TextAnalysisSource1Shadow.TextAnalysisSource1Vtbl.GetVerticalGlyphOrientationDelegate(TextAnalysisSource1Shadow.TextAnalysisSource1Vtbl.GetVerticalGlyphOrientationImpl));
			}

			// Token: 0x06000416 RID: 1046 RVA: 0x0000DA98 File Offset: 0x0000BC98
			private static int GetVerticalGlyphOrientationImpl(IntPtr thisPtr, int textPosition, out int textLength, out VerticalGlyphOrientation glyphOrientation, out byte bidiLevel)
			{
				textLength = 0;
				glyphOrientation = VerticalGlyphOrientation.Default;
				bidiLevel = 0;
				try
				{
					((TextAnalysisSource1)CppObjectShadow.ToShadow<TextAnalysisSource1Shadow>(thisPtr).Callback).GetVerticalGlyphOrientation(textPosition, out textLength, out glyphOrientation, out bidiLevel);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020000D1 RID: 209
			// (Invoke) Token: 0x06000418 RID: 1048
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int GetVerticalGlyphOrientationDelegate(IntPtr thisPtr, int textPosition, out int textLength, out VerticalGlyphOrientation glyphOrientation, out byte bidiLevel);
		}
	}
}
