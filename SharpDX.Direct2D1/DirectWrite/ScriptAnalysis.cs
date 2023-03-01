using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000167 RID: 359
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ScriptAnalysis
	{
		// Token: 0x040005A3 RID: 1443
		public short Script;

		// Token: 0x040005A4 RID: 1444
		public ScriptShapes Shapes;
	}
}
