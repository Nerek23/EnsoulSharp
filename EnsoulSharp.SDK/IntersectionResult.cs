using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000054 RID: 84
	public struct IntersectionResult
	{
		// Token: 0x0600034E RID: 846 RVA: 0x00018E82 File Offset: 0x00017082
		public IntersectionResult(bool intersects = false, Vector2 point = default(Vector2))
		{
			this.Intersects = intersects;
			this.Point = point;
		}

		// Token: 0x040001ED RID: 493
		public bool Intersects;

		// Token: 0x040001EE RID: 494
		public Vector2 Point;
	}
}
