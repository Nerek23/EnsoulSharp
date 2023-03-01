using System;
using log4net.Util;

namespace log4net
{
	// Token: 0x02000002 RID: 2
	public sealed class GlobalContext
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		private GlobalContext()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00001058
		static GlobalContext()
		{
			GlobalContext.Properties["log4net:HostName"] = SystemInfo.HostName;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002078 File Offset: 0x00001078
		public static GlobalContextProperties Properties
		{
			get
			{
				return GlobalContext.s_properties;
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly GlobalContextProperties s_properties = new GlobalContextProperties();
	}
}
