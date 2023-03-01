using System;
using System.IO;

namespace SharpDX.WIC
{
	// Token: 0x0200001C RID: 28
	public class GifBitmapEncoder : BitmapEncoder
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00004886 File Offset: 0x00002A86
		public GifBitmapEncoder(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00005471 File Offset: 0x00003671
		public GifBitmapEncoder(ImagingFactory factory) : base(factory, ContainerFormatGuids.Gif)
		{
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000547F File Offset: 0x0000367F
		public GifBitmapEncoder(ImagingFactory factory, Stream stream = null) : base(factory, ContainerFormatGuids.Gif, stream)
		{
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000548E File Offset: 0x0000368E
		public GifBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, Stream stream = null) : base(factory, ContainerFormatGuids.Gif, guidVendorRef, stream)
		{
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000549E File Offset: 0x0000369E
		public GifBitmapEncoder(ImagingFactory factory, WICStream stream = null) : base(factory, ContainerFormatGuids.Gif, stream)
		{
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000054AD File Offset: 0x000036AD
		public GifBitmapEncoder(ImagingFactory factory, Guid guidVendorRef, WICStream stream = null) : base(factory, ContainerFormatGuids.Gif, guidVendorRef, stream)
		{
		}
	}
}
