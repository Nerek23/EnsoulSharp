using System;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000020 RID: 32
	public sealed class NullSecurityContext : SecurityContext
	{
		// Token: 0x06000146 RID: 326 RVA: 0x0000475B File Offset: 0x0000375B
		private NullSecurityContext()
		{
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004763 File Offset: 0x00003763
		public override IDisposable Impersonate(object state)
		{
			return null;
		}

		// Token: 0x04000039 RID: 57
		public static readonly NullSecurityContext Instance = new NullSecurityContext();
	}
}
