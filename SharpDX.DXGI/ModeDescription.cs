using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000018 RID: 24
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ModeDescription
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00004003 File Offset: 0x00002203
		public ModeDescription(int width, int height, Rational refreshRate, Format format)
		{
			this.Width = width;
			this.Height = height;
			this.RefreshRate = refreshRate;
			this.Format = format;
			this.ScanlineOrdering = DisplayModeScanlineOrder.Unspecified;
			this.Scaling = DisplayModeScaling.Unspecified;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004030 File Offset: 0x00002230
		public ModeDescription(Format format)
		{
			this = default(ModeDescription);
			this.Format = format;
		}

		// Token: 0x04000019 RID: 25
		public int Width;

		// Token: 0x0400001A RID: 26
		public int Height;

		// Token: 0x0400001B RID: 27
		public Rational RefreshRate;

		// Token: 0x0400001C RID: 28
		public Format Format;

		// Token: 0x0400001D RID: 29
		public DisplayModeScanlineOrder ScanlineOrdering;

		// Token: 0x0400001E RID: 30
		public DisplayModeScaling Scaling;
	}
}
