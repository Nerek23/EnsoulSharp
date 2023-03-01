using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000CD RID: 205
	[Shadow(typeof(TextAnalysisSourceShadow))]
	[Guid("688e1a58-5094-47c8-adc8-fbcea60ae92b")]
	public interface TextAnalysisSource : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x0600040B RID: 1035
		string GetTextAtPosition(int textPosition);

		// Token: 0x0600040C RID: 1036
		string GetTextBeforePosition(int textPosition);

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600040D RID: 1037
		ReadingDirection ReadingDirection { get; }

		// Token: 0x0600040E RID: 1038
		string GetLocaleName(int textPosition, out int textLength);

		// Token: 0x0600040F RID: 1039
		NumberSubstitution GetNumberSubstitution(int textPosition, out int textLength);
	}
}
