using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200000B RID: 11
	public class AdapterInformationEx
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002447 File Offset: 0x00000647
		internal AdapterInformationEx(Direct3DEx direct3D, int adapter)
		{
			this.direct3d = direct3D;
			this.Adapter = adapter;
			this.Details = direct3D.GetAdapterIdentifier(adapter, 0);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000246B File Offset: 0x0000066B
		public Capabilities GetCaps(DeviceType type)
		{
			return this.direct3d.GetDeviceCaps(this.Adapter, type);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000247F File Offset: 0x0000067F
		public DisplayModeExCollection GetDisplayModes(DisplayModeFilter filter)
		{
			return new DisplayModeExCollection(this.direct3d, this.Adapter, filter);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002493 File Offset: 0x00000693
		// (set) Token: 0x06000030 RID: 48 RVA: 0x0000249B File Offset: 0x0000069B
		public int Adapter { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000024A4 File Offset: 0x000006A4
		public DisplayModeEx CurrentDisplayMode
		{
			get
			{
				return this.direct3d.GetAdapterDisplayModeEx(this.Adapter);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000024B7 File Offset: 0x000006B7
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000024BF File Offset: 0x000006BF
		public AdapterDetails Details { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000024C8 File Offset: 0x000006C8
		public IntPtr Monitor
		{
			get
			{
				return this.direct3d.GetAdapterMonitor(this.Adapter);
			}
		}

		// Token: 0x04000451 RID: 1105
		private readonly Direct3DEx direct3d;
	}
}
