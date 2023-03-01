using System;

namespace SharpDX.Win32
{
	// Token: 0x02000056 RID: 86
	public class PropertyBagKey<T1, T2>
	{
		// Token: 0x06000260 RID: 608 RVA: 0x00006CB1 File Offset: 0x00004EB1
		public PropertyBagKey(string name)
		{
			this.Name = name;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00006CC0 File Offset: 0x00004EC0
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00006CC8 File Offset: 0x00004EC8
		public string Name { get; private set; }
	}
}
