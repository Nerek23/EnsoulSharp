using System;

namespace log4net.Core
{
	// Token: 0x020000BD RID: 189
	public abstract class SecurityContext
	{
		// Token: 0x0600056B RID: 1387
		public abstract IDisposable Impersonate(object state);
	}
}
