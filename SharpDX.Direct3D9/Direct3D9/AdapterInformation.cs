using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200000A RID: 10
	public class AdapterInformation
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000023B3 File Offset: 0x000005B3
		internal AdapterInformation(Direct3D direct3D, int adapter)
		{
			this.direct3d = direct3D;
			this.Adapter = adapter;
			this.Details = direct3D.GetAdapterIdentifier(adapter, 0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000023D7 File Offset: 0x000005D7
		public Capabilities GetCaps(DeviceType type)
		{
			return this.direct3d.GetDeviceCaps(this.Adapter, type);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000023EB File Offset: 0x000005EB
		public DisplayModeCollection GetDisplayModes(Format format)
		{
			return new DisplayModeCollection(this.direct3d, this.Adapter, format);
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000023FF File Offset: 0x000005FF
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002407 File Offset: 0x00000607
		public int Adapter { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002410 File Offset: 0x00000610
		public DisplayMode CurrentDisplayMode
		{
			get
			{
				return this.direct3d.GetAdapterDisplayMode(this.Adapter);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002423 File Offset: 0x00000623
		// (set) Token: 0x0600002A RID: 42 RVA: 0x0000242B File Offset: 0x0000062B
		public AdapterDetails Details { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002434 File Offset: 0x00000634
		public IntPtr Monitor
		{
			get
			{
				return this.direct3d.GetAdapterMonitor(this.Adapter);
			}
		}

		// Token: 0x0400044E RID: 1102
		private readonly Direct3D direct3d;
	}
}
