using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000009 RID: 9
	[DefaultMember("Item")]
	public class AdapterExCollection : ReadOnlyCollection<AdapterInformationEx>
	{
		// Token: 0x06000022 RID: 34 RVA: 0x00002378 File Offset: 0x00000578
		internal AdapterExCollection(Direct3DEx direct3D) : base(new List<AdapterInformationEx>())
		{
			for (int i = 0; i < direct3D.AdapterCount; i++)
			{
				base.Items.Add(new AdapterInformationEx(direct3D, i));
			}
		}
	}
}
