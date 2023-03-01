using System;
using SharpDX;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x02000083 RID: 131
	public struct MecCircle
	{
		// Token: 0x060004E0 RID: 1248 RVA: 0x0002474D File Offset: 0x0002294D
		public MecCircle(Vector2 center, float radius)
		{
			this.Center = center;
			this.Radius = radius;
		}

		// Token: 0x040002B3 RID: 691
		public float Radius;

		// Token: 0x040002B4 RID: 692
		public Vector2 Center;
	}
}
