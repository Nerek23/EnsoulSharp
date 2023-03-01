using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000093 RID: 147
	[DebuggerDisplay("X: {X}, Y: {Y}, Width: {Width}, Height: {Height}, MinDepth: {MinDepth}, MaxDepth: {MaxDepth}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawViewportF
	{
		// Token: 0x04001194 RID: 4500
		public float X;

		// Token: 0x04001195 RID: 4501
		public float Y;

		// Token: 0x04001196 RID: 4502
		public float Width;

		// Token: 0x04001197 RID: 4503
		public float Height;

		// Token: 0x04001198 RID: 4504
		public float MinDepth;

		// Token: 0x04001199 RID: 4505
		public float MaxDepth;
	}
}
