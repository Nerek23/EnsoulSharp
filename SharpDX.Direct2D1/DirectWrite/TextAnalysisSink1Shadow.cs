using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000C4 RID: 196
	internal class TextAnalysisSink1Shadow : TextAnalysisSinkShadow
	{
		// Token: 0x060003E8 RID: 1000 RVA: 0x0000D7D5 File Offset: 0x0000B9D5
		public static IntPtr ToIntPtr(TextAnalysisSink1 callback)
		{
			return CppObject.ToCallbackPtr<TextAnalysisSink1>(callback);
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0000D7DD File Offset: 0x0000B9DD
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TextAnalysisSink1Shadow.Vtbl;
			}
		}

		// Token: 0x04000265 RID: 613
		private static readonly TextAnalysisSink1Shadow.TextAnalysisSink1Vtbl Vtbl = new TextAnalysisSink1Shadow.TextAnalysisSink1Vtbl();

		// Token: 0x020000C5 RID: 197
		protected class TextAnalysisSink1Vtbl : TextAnalysisSinkShadow.TextAnalysisSinkVtbl
		{
			// Token: 0x060003EC RID: 1004 RVA: 0x0000D7F8 File Offset: 0x0000B9F8
			public TextAnalysisSink1Vtbl() : base(1)
			{
				base.AddMethod(new TextAnalysisSink1Shadow.TextAnalysisSink1Vtbl.SetGlyphOrientationDelegate(TextAnalysisSink1Shadow.TextAnalysisSink1Vtbl.SetGlyphOrientationImpl));
			}

			// Token: 0x060003ED RID: 1005 RVA: 0x0000D814 File Offset: 0x0000BA14
			private static int SetGlyphOrientationImpl(IntPtr thisPtr, int textPosition, int textLength, GlyphOrientationAngle glyphOrientationAngle, byte adjustedBidiLevel, RawBool isSideways, RawBool isRightToLeft)
			{
				try
				{
					((TextAnalysisSink1)CppObjectShadow.ToShadow<TextAnalysisSink1Shadow>(thisPtr).Callback).SetGlyphOrientation(textPosition, textLength, glyphOrientationAngle, adjustedBidiLevel, isSideways, isRightToLeft);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x020000C6 RID: 198
			// (Invoke) Token: 0x060003EF RID: 1007
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetGlyphOrientationDelegate(IntPtr thisPtr, int textPosition, int textLength, GlyphOrientationAngle glyphOrientationAngle, byte adjustedBidiLevel, RawBool isSideways, RawBool isRightToLeft);
		}
	}
}
