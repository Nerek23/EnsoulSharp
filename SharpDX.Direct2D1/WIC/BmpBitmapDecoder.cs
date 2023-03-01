using System;

namespace SharpDX.WIC
{
	// Token: 0x02000010 RID: 16
	public class BmpBitmapDecoder : BitmapDecoder
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00004860 File Offset: 0x00002A60
		public BmpBitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004869 File Offset: 0x00002A69
		public BmpBitmapDecoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Bmp)
		{
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004877 File Offset: 0x00002A77
		public BmpBitmapDecoder(ImagingFactory factory, Guid guidVendorRef) : base(factory, ContainerFormatGuids.Bmp, guidVendorRef)
		{
		}
	}
}
