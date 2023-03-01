using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000101 RID: 257
	public struct PresentParameters
	{
		// Token: 0x06000754 RID: 1876 RVA: 0x0001A430 File Offset: 0x00018630
		public PresentParameters(int backBufferWidth, int backBufferHeight)
		{
			this = new PresentParameters(backBufferWidth, backBufferHeight, Format.X8R8G8B8, 1, MultisampleType.None, 0, SwapEffect.Discard, IntPtr.Zero, true, true, Format.D24X8, PresentFlags.None, 0, PresentInterval.Immediate);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0001A45C File Offset: 0x0001865C
		public PresentParameters(int backBufferWidth, int backBufferHeight, Format backBufferFormat, int backBufferCount, MultisampleType multiSampleType, int multiSampleQuality, SwapEffect swapEffect, IntPtr deviceWindowHandle, bool windowed, bool enableAutoDepthStencil, Format autoDepthStencilFormat, PresentFlags presentFlags, int fullScreenRefreshRateInHz, PresentInterval presentationInterval)
		{
			this.BackBufferWidth = backBufferWidth;
			this.BackBufferHeight = backBufferHeight;
			this.BackBufferFormat = backBufferFormat;
			this.BackBufferCount = backBufferCount;
			this.MultiSampleType = multiSampleType;
			this.MultiSampleQuality = multiSampleQuality;
			this.SwapEffect = swapEffect;
			this.DeviceWindowHandle = deviceWindowHandle;
			this.Windowed = windowed;
			this.EnableAutoDepthStencil = enableAutoDepthStencil;
			this.AutoDepthStencilFormat = autoDepthStencilFormat;
			this.PresentFlags = presentFlags;
			this.FullScreenRefreshRateInHz = fullScreenRefreshRateInHz;
			this.PresentationInterval = presentationInterval;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001A4E0 File Offset: 0x000186E0
		public void InitDefaults()
		{
			this.BackBufferWidth = 800;
			this.BackBufferHeight = 600;
			this.BackBufferFormat = Format.X8R8G8B8;
			this.BackBufferCount = 1;
			this.MultiSampleType = MultisampleType.None;
			this.SwapEffect = SwapEffect.Discard;
			this.DeviceWindowHandle = IntPtr.Zero;
			this.Windowed = true;
			this.EnableAutoDepthStencil = true;
			this.AutoDepthStencilFormat = Format.D24X8;
			this.PresentFlags = PresentFlags.None;
			this.PresentationInterval = PresentInterval.Immediate;
		}

		// Token: 0x04000DF3 RID: 3571
		public int BackBufferWidth;

		// Token: 0x04000DF4 RID: 3572
		public int BackBufferHeight;

		// Token: 0x04000DF5 RID: 3573
		public Format BackBufferFormat;

		// Token: 0x04000DF6 RID: 3574
		public int BackBufferCount;

		// Token: 0x04000DF7 RID: 3575
		public MultisampleType MultiSampleType;

		// Token: 0x04000DF8 RID: 3576
		public int MultiSampleQuality;

		// Token: 0x04000DF9 RID: 3577
		public SwapEffect SwapEffect;

		// Token: 0x04000DFA RID: 3578
		public IntPtr DeviceWindowHandle;

		// Token: 0x04000DFB RID: 3579
		public RawBool Windowed;

		// Token: 0x04000DFC RID: 3580
		public RawBool EnableAutoDepthStencil;

		// Token: 0x04000DFD RID: 3581
		public Format AutoDepthStencilFormat;

		// Token: 0x04000DFE RID: 3582
		public PresentFlags PresentFlags;

		// Token: 0x04000DFF RID: 3583
		public int FullScreenRefreshRateInHz;

		// Token: 0x04000E00 RID: 3584
		public PresentInterval PresentationInterval;
	}
}
