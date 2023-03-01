using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x0200008A RID: 138
	[DebuggerDisplay("Normal: {Normal}, D: {D}")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawPlane
	{
		// Token: 0x0600030C RID: 780 RVA: 0x000090E5 File Offset: 0x000072E5
		public RawPlane(RawVector3 normal, float d)
		{
			this.Normal = normal;
			this.D = d;
		}

		// Token: 0x04001175 RID: 4469
		public RawVector3 Normal;

		// Token: 0x04001176 RID: 4470
		public float D;
	}
}
