using System;

namespace SharpDX.WIC
{
	// Token: 0x0200002A RID: 42
	public class PngBitmapDecoder : BitmapDecoder
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x00004860 File Offset: 0x00002A60
		public PngBitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000778B File Offset: 0x0000598B
		public PngBitmapDecoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Png)
		{
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00007799 File Offset: 0x00005999
		public PngBitmapDecoder(ImagingFactory factory, Guid guidVendorRef) : base(factory, ContainerFormatGuids.Png, guidVendorRef)
		{
		}
	}
}
