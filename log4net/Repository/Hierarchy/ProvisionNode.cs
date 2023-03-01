using System;
using System.Collections;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x0200005C RID: 92
	internal sealed class ProvisionNode : ArrayList
	{
		// Token: 0x06000318 RID: 792 RVA: 0x000092E9 File Offset: 0x000082E9
		internal ProvisionNode(Logger log)
		{
			this.Add(log);
		}
	}
}
