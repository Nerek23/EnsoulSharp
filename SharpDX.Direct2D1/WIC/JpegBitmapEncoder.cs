using System;
using System.IO;

namespace SharpDX.WIC
{
	// Token: 0x02000022 RID: 34
	public class JpegBitmapEncoder : BitmapEncoder
	{
		// Token: 0x06000168 RID: 360 RVA: 0x00004886 File Offset: 0x00002A86
		public JpegBitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000601C File Offset: 0x0000421C
		public JpegBitmapEncoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Jpeg)
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000602A File Offset: 0x0000422A
		public JpegBitmapEncoder(ImagingFactory factory, Stream stream = null) : base(factory, ContainerFormatGuids.Jpeg, stream)
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006039 File Offset: 0x00004239
		public JpegBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, Stream stream = null) : base(factory, ContainerFormatGuids.Jpeg, guidVendorRef, stream)
		{
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006049 File Offset: 0x00004249
		public JpegBitmapEncoder(ImagingFactory factory, WICStream stream = null) : base(factory, ContainerFormatGuids.Jpeg, stream)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006058 File Offset: 0x00004258
		public JpegBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, WICStream stream = null) : base(factory, ContainerFormatGuids.Jpeg, guidVendorRef, stream)
		{
		}
	}
}
