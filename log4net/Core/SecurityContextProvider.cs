using System;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000BE RID: 190
	public class SecurityContextProvider
	{
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x000117A5 File Offset: 0x000107A5
		// (set) Token: 0x0600056E RID: 1390 RVA: 0x000117AC File Offset: 0x000107AC
		public static SecurityContextProvider DefaultProvider
		{
			get
			{
				return SecurityContextProvider.s_defaultProvider;
			}
			set
			{
				SecurityContextProvider.s_defaultProvider = value;
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000117B4 File Offset: 0x000107B4
		protected SecurityContextProvider()
		{
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000117BC File Offset: 0x000107BC
		public virtual SecurityContext CreateSecurityContext(object consumer)
		{
			return NullSecurityContext.Instance;
		}

		// Token: 0x04000191 RID: 401
		private static SecurityContextProvider s_defaultProvider = new SecurityContextProvider();
	}
}
