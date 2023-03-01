using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000006 RID: 6
	[DefaultMember("Item")]
	public class AdapterCollection : ReadOnlyCollection<AdapterInformation>
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000020A4 File Offset: 0x000002A4
		internal AdapterCollection(Direct3D direct3D) : base(new List<AdapterInformation>())
		{
			for (int i = 0; i < direct3D.AdapterCount; i++)
			{
				base.Items.Add(new AdapterInformation(direct3D, i));
			}
		}
	}
}
