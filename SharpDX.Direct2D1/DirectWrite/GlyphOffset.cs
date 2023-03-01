using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000159 RID: 345
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct GlyphOffset
	{
		// Token: 0x04000536 RID: 1334
		public float AdvanceOffset;

		// Token: 0x04000537 RID: 1335
		public float AscenderOffset;
	}
}
