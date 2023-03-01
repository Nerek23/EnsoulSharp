using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200007D RID: 125
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct JpegScanHeader
	{
		// Token: 0x040001ED RID: 493
		public int CComponents;

		// Token: 0x040001EE RID: 494
		public int RestartInterval;

		// Token: 0x040001EF RID: 495
		public int ComponentSelectors;

		// Token: 0x040001F0 RID: 496
		public int HuffmanTableIndices;

		// Token: 0x040001F1 RID: 497
		public byte StartSpectralSelection;

		// Token: 0x040001F2 RID: 498
		public byte EndSpectralSelection;

		// Token: 0x040001F3 RID: 499
		public byte SuccessiveApproximationHigh;

		// Token: 0x040001F4 RID: 500
		public byte SuccessiveApproximationLow;
	}
}
