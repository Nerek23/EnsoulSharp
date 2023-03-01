using System;

namespace SharpDX.Win32
{
	// Token: 0x02000057 RID: 87
	public struct SecurityAttributes
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00006CD1 File Offset: 0x00004ED1
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00006CDC File Offset: 0x00004EDC
		public bool InheritHandle
		{
			get
			{
				return this.inheritHandle != 0;
			}
			set
			{
				this.inheritHandle = (value ? 1 : 0);
			}
		}

		// Token: 0x040000B3 RID: 179
		public int Length;

		// Token: 0x040000B4 RID: 180
		public IntPtr Descriptor;

		// Token: 0x040000B5 RID: 181
		private int inheritHandle;
	}
}
