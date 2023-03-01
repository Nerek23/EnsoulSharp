using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000CE RID: 206
	[Shadow(typeof(TextAnalysisSource1Shadow))]
	[Guid("639CFAD8-0FB4-4B21-A58A-067920120009")]
	public interface TextAnalysisSource1 : TextAnalysisSource, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000410 RID: 1040
		void GetVerticalGlyphOrientation(int textPosition, out int textLength, out VerticalGlyphOrientation glyphOrientation, out byte bidiLevel);
	}
}
