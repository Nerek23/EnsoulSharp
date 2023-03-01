using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001F9 RID: 505
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InputDescription
	{
		// Token: 0x06000AD7 RID: 2775 RVA: 0x0001F12D File Offset: 0x0001D32D
		public InputDescription(Filter filter, int levelOfDetail)
		{
			this.Filter = filter;
			this.LevelOfDetailCount = levelOfDetail;
		}

		// Token: 0x0400066A RID: 1642
		public Filter Filter;

		// Token: 0x0400066B RID: 1643
		public int LevelOfDetailCount;
	}
}
