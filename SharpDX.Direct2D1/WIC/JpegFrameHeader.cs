using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200007C RID: 124
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct JpegFrameHeader
	{
		// Token: 0x040001E5 RID: 485
		public int Width;

		// Token: 0x040001E6 RID: 486
		public int Height;

		// Token: 0x040001E7 RID: 487
		public JpegTransferMatrix TransferMatrix;

		// Token: 0x040001E8 RID: 488
		public JpegScanType ScanType;

		// Token: 0x040001E9 RID: 489
		public int CComponents;

		// Token: 0x040001EA RID: 490
		public int ComponentIdentifiers;

		// Token: 0x040001EB RID: 491
		public int SampleFactors;

		// Token: 0x040001EC RID: 492
		public int QuantizationTableIndices;
	}
}
