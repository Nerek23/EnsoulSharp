using System;
using System.IO;

namespace SharpDX.WIC
{
	// Token: 0x0200002D RID: 45
	public class TiffBitmapEncoder : BitmapEncoder
	{
		// Token: 0x060001BF RID: 447 RVA: 0x00004886 File Offset: 0x00002A86
		public TiffBitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00007811 File Offset: 0x00005A11
		public TiffBitmapEncoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Tiff)
		{
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000781F File Offset: 0x00005A1F
		public TiffBitmapEncoder(ImagingFactory factory, Stream stream = null) : base(factory, ContainerFormatGuids.Tiff, stream)
		{
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000782E File Offset: 0x00005A2E
		public TiffBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, Stream stream = null) : base(factory, ContainerFormatGuids.Tiff, guidVendorRef, stream)
		{
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000783E File Offset: 0x00005A3E
		public TiffBitmapEncoder(ImagingFactory factory, WICStream stream = null) : base(factory, ContainerFormatGuids.Tiff, stream)
		{
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000784D File Offset: 0x00005A4D
		public TiffBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, WICStream stream = null) : base(factory, ContainerFormatGuids.Tiff, guidVendorRef, stream)
		{
		}
	}
}
