using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200001C RID: 28
	public struct DisplayMode
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000093DD File Offset: 0x000075DD
		public float AspectRatio
		{
			get
			{
				return (float)this.Width / (float)this.Height;
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000093F0 File Offset: 0x000075F0
		public override string ToString()
		{
			return string.Format("Width: {0}, Height: {1}, RefreshRate: {2}, Format: {3}", new object[]
			{
				this.Width,
				this.Height,
				this.RefreshRate,
				this.Format
			});
		}

		// Token: 0x040004B7 RID: 1207
		public int Width;

		// Token: 0x040004B8 RID: 1208
		public int Height;

		// Token: 0x040004B9 RID: 1209
		public int RefreshRate;

		// Token: 0x040004BA RID: 1210
		public Format Format;
	}
}
