using System;
using log4net.Util;

namespace log4net
{
	// Token: 0x02000004 RID: 4
	public sealed class LogicalThreadContext
	{
		// Token: 0x0600002C RID: 44 RVA: 0x0000207F File Offset: 0x0000107F
		private LogicalThreadContext()
		{
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002087 File Offset: 0x00001087
		public static LogicalThreadContextProperties Properties
		{
			get
			{
				return LogicalThreadContext.s_properties;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000208E File Offset: 0x0000108E
		public static LogicalThreadContextStacks Stacks
		{
			get
			{
				return LogicalThreadContext.s_stacks;
			}
		}

		// Token: 0x04000002 RID: 2
		private static readonly LogicalThreadContextProperties s_properties = new LogicalThreadContextProperties();

		// Token: 0x04000003 RID: 3
		private static readonly LogicalThreadContextStacks s_stacks = new LogicalThreadContextStacks(LogicalThreadContext.s_properties);
	}
}
