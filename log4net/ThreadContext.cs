using System;
using log4net.Util;

namespace log4net
{
	// Token: 0x02000008 RID: 8
	public sealed class ThreadContext
	{
		// Token: 0x06000067 RID: 103 RVA: 0x000023E7 File Offset: 0x000013E7
		private ThreadContext()
		{
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000023EF File Offset: 0x000013EF
		public static ThreadContextProperties Properties
		{
			get
			{
				return ThreadContext.s_properties;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000069 RID: 105 RVA: 0x000023F6 File Offset: 0x000013F6
		public static ThreadContextStacks Stacks
		{
			get
			{
				return ThreadContext.s_stacks;
			}
		}

		// Token: 0x04000005 RID: 5
		private static readonly ThreadContextProperties s_properties = new ThreadContextProperties();

		// Token: 0x04000006 RID: 6
		private static readonly ThreadContextStacks s_stacks = new ThreadContextStacks(ThreadContext.s_properties);
	}
}
