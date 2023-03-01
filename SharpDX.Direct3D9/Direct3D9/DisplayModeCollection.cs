using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200001D RID: 29
	[DefaultMember("Item")]
	public class DisplayModeCollection : ReadOnlyCollection<DisplayMode>
	{
		// Token: 0x0600023A RID: 570 RVA: 0x00009448 File Offset: 0x00007648
		internal DisplayModeCollection(Direct3D direct3D, int adapter, Format format) : base(new List<DisplayMode>())
		{
			int adapterModeCount = direct3D.GetAdapterModeCount(adapter, format);
			for (int i = 0; i < adapterModeCount; i++)
			{
				base.Items.Add(direct3D.EnumAdapterModes(adapter, format, i));
			}
		}
	}
}
