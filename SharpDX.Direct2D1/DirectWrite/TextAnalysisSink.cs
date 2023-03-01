using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000C2 RID: 194
	[Shadow(typeof(TextAnalysisSinkShadow))]
	[Guid("5810cd44-0ca0-4701-b3fa-bec5182ae4f6")]
	public interface TextAnalysisSink : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060003E3 RID: 995
		void SetScriptAnalysis(int textPosition, int textLength, ScriptAnalysis scriptAnalysis);

		// Token: 0x060003E4 RID: 996
		void SetLineBreakpoints(int textPosition, int textLength, LineBreakpoint[] lineBreakpoints);

		// Token: 0x060003E5 RID: 997
		void SetBidiLevel(int textPosition, int textLength, byte explicitLevel, byte resolvedLevel);

		// Token: 0x060003E6 RID: 998
		void SetNumberSubstitution(int textPosition, int textLength, NumberSubstitution numberSubstitution);
	}
}
