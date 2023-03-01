using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000020 RID: 32
	[DefaultMember("Item")]
	public class DisplayModeExCollection : ReadOnlyCollection<DisplayModeEx>
	{
		// Token: 0x06000243 RID: 579 RVA: 0x000095E4 File Offset: 0x000077E4
		internal DisplayModeExCollection(Direct3DEx direct3D, int adapter, DisplayModeFilter filter) : base(new List<DisplayModeEx>())
		{
			int adapterModeCountEx = direct3D.GetAdapterModeCountEx(adapter, filter);
			for (int i = 0; i < adapterModeCountEx; i++)
			{
				base.Items.Add(direct3D.EnumerateAdapterModesEx(adapter, filter, i));
			}
		}
	}
}
