using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200024B RID: 587
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct VertexRange
	{
		// Token: 0x06000D76 RID: 3446 RVA: 0x00024FF4 File Offset: 0x000231F4
		public VertexRange(int startVertex, int vertexCount)
		{
			this.StartVertex = startVertex;
			this.VertexCount = vertexCount;
		}

		// Token: 0x040006D0 RID: 1744
		public int StartVertex;

		// Token: 0x040006D1 RID: 1745
		public int VertexCount;
	}
}
