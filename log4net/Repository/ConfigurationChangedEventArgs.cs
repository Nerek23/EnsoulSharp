using System;
using System.Collections;

namespace log4net.Repository
{
	// Token: 0x0200004D RID: 77
	public class ConfigurationChangedEventArgs : EventArgs
	{
		// Token: 0x06000279 RID: 633 RVA: 0x00007C71 File Offset: 0x00006C71
		public ConfigurationChangedEventArgs(ICollection configurationMessages)
		{
			this.configurationMessages = configurationMessages;
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00007C80 File Offset: 0x00006C80
		public ICollection ConfigurationMessages
		{
			get
			{
				return this.configurationMessages;
			}
		}

		// Token: 0x0400008A RID: 138
		private readonly ICollection configurationMessages;
	}
}
