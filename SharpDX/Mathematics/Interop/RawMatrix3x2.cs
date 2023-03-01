using System;
using System.Runtime.InteropServices;

namespace SharpDX.Mathematics.Interop
{
	// Token: 0x02000087 RID: 135
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct RawMatrix3x2
	{
		// Token: 0x0600030B RID: 779 RVA: 0x000090B6 File Offset: 0x000072B6
		public RawMatrix3x2(float m11, float m12, float m21, float m22, float m31, float m32)
		{
			this.M11 = m11;
			this.M12 = m12;
			this.M21 = m21;
			this.M22 = m22;
			this.M31 = m31;
			this.M32 = m32;
		}

		// Token: 0x0400114F RID: 4431
		public float M11;

		// Token: 0x04001150 RID: 4432
		public float M12;

		// Token: 0x04001151 RID: 4433
		public float M21;

		// Token: 0x04001152 RID: 4434
		public float M22;

		// Token: 0x04001153 RID: 4435
		public float M31;

		// Token: 0x04001154 RID: 4436
		public float M32;
	}
}
