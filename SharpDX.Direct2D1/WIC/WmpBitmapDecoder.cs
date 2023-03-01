using System;

namespace SharpDX.WIC
{
	// Token: 0x0200002F RID: 47
	public class WmpBitmapDecoder : BitmapDecoder
	{
		// Token: 0x060001CF RID: 463 RVA: 0x00004860 File Offset: 0x00002A60
		public WmpBitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00007A35 File Offset: 0x00005C35
		public WmpBitmapDecoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Wmp)
		{
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00007A43 File Offset: 0x00005C43
		public WmpBitmapDecoder(ImagingFactory factory, Guid guidVendorRef) : base(factory, ContainerFormatGuids.Wmp, guidVendorRef)
		{
		}
	}
}
