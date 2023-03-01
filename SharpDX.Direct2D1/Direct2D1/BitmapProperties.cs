using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000179 RID: 377
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BitmapProperties
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x00015D0E File Offset: 0x00013F0E
		public BitmapProperties(PixelFormat pixelFormat)
		{
			this.DpiX = 96f;
			this.DpiY = 96f;
			this.PixelFormat = pixelFormat;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00015D2D File Offset: 0x00013F2D
		public BitmapProperties(PixelFormat pixelFormat, float dpiX, float dpiY)
		{
			this.PixelFormat = pixelFormat;
			this.DpiX = dpiX;
			this.DpiY = dpiY;
		}

		// Token: 0x040005EB RID: 1515
		public PixelFormat PixelFormat;

		// Token: 0x040005EC RID: 1516
		public float DpiX;

		// Token: 0x040005ED RID: 1517
		public float DpiY;
	}
}
