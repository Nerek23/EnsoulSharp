using System;

namespace SharpDX.WIC
{
	// Token: 0x0200001B RID: 27
	public class GifBitmapDecoder : BitmapDecoder
	{
		// Token: 0x06000134 RID: 308 RVA: 0x00004860 File Offset: 0x00002A60
		public GifBitmapDecoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005454 File Offset: 0x00003654
		public GifBitmapDecoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Gif)
		{
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005462 File Offset: 0x00003662
		public GifBitmapDecoder(ImagingFactory factory, Guid guidVendorRef) : base(factory, ContainerFormatGuids.Gif, guidVendorRef)
		{
		}
	}
}
