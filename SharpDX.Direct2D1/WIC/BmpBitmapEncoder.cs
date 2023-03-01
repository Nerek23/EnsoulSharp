using System;
using System.IO;

namespace SharpDX.WIC
{
	// Token: 0x02000011 RID: 17
	public class BmpBitmapEncoder : BitmapEncoder
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00004886 File Offset: 0x00002A86
		public BmpBitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000488F File Offset: 0x00002A8F
		public BmpBitmapEncoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Bmp)
		{
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000489D File Offset: 0x00002A9D
		public BmpBitmapEncoder(ImagingFactory factory, Stream stream = null) : base(factory, ContainerFormatGuids.Bmp, stream)
		{
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000048AC File Offset: 0x00002AAC
		public BmpBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, Stream stream = null) : base(factory, ContainerFormatGuids.Bmp, guidVendorRef, stream)
		{
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000048BC File Offset: 0x00002ABC
		public BmpBitmapEncoder(ImagingFactory factory, WICStream stream = null) : base(factory, ContainerFormatGuids.Bmp, stream)
		{
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000048CB File Offset: 0x00002ACB
		public BmpBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, WICStream stream = null) : base(factory, ContainerFormatGuids.Bmp, guidVendorRef, stream)
		{
		}
	}
}
