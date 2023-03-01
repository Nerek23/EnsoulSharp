using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000AC RID: 172
	[Shadow(typeof(InlineObjectShadow))]
	[Guid("8339FDE3-106F-47ab-8373-1C6295EB10B3")]
	public interface InlineObject : IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000367 RID: 871
		void Draw(object clientDrawingContext, TextRenderer renderer, float originX, float originY, bool isSideways, bool isRightToLeft, ComObject clientDrawingEffect);

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000368 RID: 872
		InlineObjectMetrics Metrics { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000369 RID: 873
		OverhangMetrics OverhangMetrics { get; }

		// Token: 0x0600036A RID: 874
		void GetBreakConditions(out BreakCondition breakConditionBefore, out BreakCondition breakConditionAfter);
	}
}
