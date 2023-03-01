using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000217 RID: 535
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RenderTargetProperties
	{
		// Token: 0x06000C1F RID: 3103 RVA: 0x00022544 File Offset: 0x00020744
		public RenderTargetProperties(PixelFormat pixelFormat)
		{
			this = new RenderTargetProperties(RenderTargetType.Default, pixelFormat, 96f, 96f, RenderTargetUsage.None, FeatureLevel.Level_DEFAULT);
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0002255A File Offset: 0x0002075A
		public RenderTargetProperties(RenderTargetType type, PixelFormat pixelFormat, float dpiX, float dpiY, RenderTargetUsage usage, FeatureLevel minLevel)
		{
			this.Type = type;
			this.PixelFormat = pixelFormat;
			this.DpiX = dpiX;
			this.DpiY = dpiY;
			this.Usage = usage;
			this.MinLevel = minLevel;
		}

		// Token: 0x040006AE RID: 1710
		public RenderTargetType Type;

		// Token: 0x040006AF RID: 1711
		public PixelFormat PixelFormat;

		// Token: 0x040006B0 RID: 1712
		public float DpiX;

		// Token: 0x040006B1 RID: 1713
		public float DpiY;

		// Token: 0x040006B2 RID: 1714
		public RenderTargetUsage Usage;

		// Token: 0x040006B3 RID: 1715
		public FeatureLevel MinLevel;
	}
}
