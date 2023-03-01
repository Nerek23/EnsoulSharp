using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000056 RID: 86
	public struct ProjectionInfo
	{
		// Token: 0x06000351 RID: 849 RVA: 0x00018EBE File Offset: 0x000170BE
		internal ProjectionInfo(bool isOnSegment, Vector2 segmentPoint, Vector2 linePoint)
		{
			this.IsOnSegment = isOnSegment;
			this.SegmentPoint = segmentPoint;
			this.LinePoint = linePoint;
		}

		// Token: 0x040001F1 RID: 497
		public bool IsOnSegment;

		// Token: 0x040001F2 RID: 498
		public Vector2 LinePoint;

		// Token: 0x040001F3 RID: 499
		public Vector2 SegmentPoint;
	}
}
