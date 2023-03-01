using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000C3 RID: 195
	[Guid("B0D941A0-85E7-4D8B-9FD3-5CED9934482A")]
	[Shadow(typeof(TextAnalysisSink1Shadow))]
	public interface TextAnalysisSink1 : TextAnalysisSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060003E7 RID: 999
		void SetGlyphOrientation(int textPosition, int textLength, GlyphOrientationAngle glyphOrientationAngle, byte adjustedBidiLevel, RawBool isSideways, RawBool isRightToLeft);
	}
}
