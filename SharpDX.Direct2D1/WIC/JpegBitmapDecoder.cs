using System;

namespace SharpDX.WIC
{
	// Token: 0x02000021 RID: 33
	public class JpegBitmapDecoder : BitmapDecoder
	{
		// Token: 0x06000165 RID: 357 RVA: 0x00004860 File Offset: 0x00002A60
		public JpegBitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005FFF File Offset: 0x000041FF
		public JpegBitmapDecoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Jpeg)
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000600D File Offset: 0x0000420D
		public JpegBitmapDecoder(ImagingFactory factory, Guid guidVendorRef) : base(factory, ContainerFormatGuids.Jpeg, guidVendorRef)
		{
		}
	}
}
