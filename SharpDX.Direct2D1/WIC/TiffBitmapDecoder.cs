using System;

namespace SharpDX.WIC
{
	// Token: 0x0200002C RID: 44
	public class TiffBitmapDecoder : BitmapDecoder
	{
		// Token: 0x060001BC RID: 444 RVA: 0x00004860 File Offset: 0x00002A60
		public TiffBitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001BD RID: 445 RVA: 0x000077F4 File Offset: 0x000059F4
		public TiffBitmapDecoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Tiff)
		{
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00007802 File Offset: 0x00005A02
		public TiffBitmapDecoder(ImagingFactory factory, Guid guidVendorRef) : base(factory, ContainerFormatGuids.Tiff, guidVendorRef)
		{
		}
	}
}
