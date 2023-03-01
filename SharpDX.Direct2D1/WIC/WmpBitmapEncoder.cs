using System;
using System.IO;

namespace SharpDX.WIC
{
	// Token: 0x02000030 RID: 48
	public class WmpBitmapEncoder : BitmapEncoder
	{
		// Token: 0x060001D2 RID: 466 RVA: 0x00004886 File Offset: 0x00002A86
		public WmpBitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00007A52 File Offset: 0x00005C52
		public WmpBitmapEncoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Wmp)
		{
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00007A60 File Offset: 0x00005C60
		public WmpBitmapEncoder(ImagingFactory factory, Stream stream = null) : base(factory, ContainerFormatGuids.Wmp, stream)
		{
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007A6F File Offset: 0x00005C6F
		public WmpBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, Stream stream = null) : base(factory, ContainerFormatGuids.Wmp, guidVendorRef, stream)
		{
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00007A7F File Offset: 0x00005C7F
		public WmpBitmapEncoder(ImagingFactory factory, WICStream stream = null) : base(factory, ContainerFormatGuids.Wmp, stream)
		{
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00007A8E File Offset: 0x00005C8E
		public WmpBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, WICStream stream = null) : base(factory, ContainerFormatGuids.Wmp, guidVendorRef, stream)
		{
		}
	}
}
