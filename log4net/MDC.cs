using System;

namespace log4net
{
	// Token: 0x02000006 RID: 6
	public sealed class MDC
	{
		// Token: 0x06000058 RID: 88 RVA: 0x000022B8 File Offset: 0x000012B8
		private MDC()
		{
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000022C0 File Offset: 0x000012C0
		public static string Get(string key)
		{
			object obj = ThreadContext.Properties[key];
			if (obj == null)
			{
				return null;
			}
			return obj.ToString();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000022E4 File Offset: 0x000012E4
		public static void Set(string key, string value)
		{
			ThreadContext.Properties[key] = value;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000022F2 File Offset: 0x000012F2
		public static void Remove(string key)
		{
			ThreadContext.Properties.Remove(key);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000022FF File Offset: 0x000012FF
		public static void Clear()
		{
			ThreadContext.Properties.Clear();
		}
	}
}
