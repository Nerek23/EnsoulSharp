using System;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200000F RID: 15
	public class CounterMetadata
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002D8A File Offset: 0x00000F8A
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002D92 File Offset: 0x00000F92
		public CounterType Type { get; internal set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002D9B File Offset: 0x00000F9B
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002DA3 File Offset: 0x00000FA3
		public int HardwareCounterCount { get; internal set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002DAC File Offset: 0x00000FAC
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002DB4 File Offset: 0x00000FB4
		public string Name { get; internal set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002DBD File Offset: 0x00000FBD
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00002DC5 File Offset: 0x00000FC5
		public string Units { get; internal set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002DCE File Offset: 0x00000FCE
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002DD6 File Offset: 0x00000FD6
		public string Description { get; internal set; }
	}
}
