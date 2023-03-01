using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000023 RID: 35
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SampleDescription
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00004B60 File Offset: 0x00002D60
		public SampleDescription(int count, int quality)
		{
			this.Count = count;
			this.Quality = quality;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004B70 File Offset: 0x00002D70
		public override string ToString()
		{
			return string.Format("{{{0}, {1}}}", this.Count, this.Quality);
		}

		// Token: 0x0400002D RID: 45
		public int Count;

		// Token: 0x0400002E RID: 46
		public int Quality;
	}
}
