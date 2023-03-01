using System;
using System.IO;

namespace SharpDX.WIC
{
	// Token: 0x0200002B RID: 43
	public class PngBitmapEncoder : BitmapEncoder
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x00004886 File Offset: 0x00002A86
		public PngBitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000077A8 File Offset: 0x000059A8
		public PngBitmapEncoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Png)
		{
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000077B6 File Offset: 0x000059B6
		public PngBitmapEncoder(ImagingFactory factory, Stream stream = null) : base(factory, ContainerFormatGuids.Png, stream)
		{
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000077C5 File Offset: 0x000059C5
		public PngBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, Stream stream = null) : base(factory, ContainerFormatGuids.Png, guidVendorRef, stream)
		{
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000077D5 File Offset: 0x000059D5
		public PngBitmapEncoder(ImagingFactory factory, WICStream stream = null) : base(factory, ContainerFormatGuids.Png, stream)
		{
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000077E4 File Offset: 0x000059E4
		public PngBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, WICStream stream = null) : base(factory, ContainerFormatGuids.Png, guidVendorRef, stream)
		{
		}
	}
}
