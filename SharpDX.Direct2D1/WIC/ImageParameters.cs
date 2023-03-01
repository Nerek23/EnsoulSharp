using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.WIC
{
	// Token: 0x0200001E RID: 30
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ImageParameters
	{
		// Token: 0x06000143 RID: 323 RVA: 0x00005604 File Offset: 0x00003804
		public ImageParameters(PixelFormat pixelFormat, float dpiX, float dpiY, float top, float left, int pixelWidth, int pixelHeight)
		{
			this.PixelFormat = pixelFormat;
			this.DpiX = dpiX;
			this.DpiY = dpiY;
			this.Top = top;
			this.Left = left;
			this.PixelWidth = pixelWidth;
			this.PixelHeight = pixelHeight;
		}

		// Token: 0x04000010 RID: 16
		public PixelFormat PixelFormat;

		// Token: 0x04000011 RID: 17
		public float DpiX;

		// Token: 0x04000012 RID: 18
		public float DpiY;

		// Token: 0x04000013 RID: 19
		public float Top;

		// Token: 0x04000014 RID: 20
		public float Left;

		// Token: 0x04000015 RID: 21
		public int PixelWidth;

		// Token: 0x04000016 RID: 22
		public int PixelHeight;
	}
}
