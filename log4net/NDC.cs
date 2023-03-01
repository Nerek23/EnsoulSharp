using System;
using System.Collections;
using log4net.Util;

namespace log4net
{
	// Token: 0x02000007 RID: 7
	public sealed class NDC
	{
		// Token: 0x0600005D RID: 93 RVA: 0x0000230B File Offset: 0x0000130B
		private NDC()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002313 File Offset: 0x00001313
		public static int Depth
		{
			get
			{
				return ThreadContext.Stacks["NDC"].Count;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002329 File Offset: 0x00001329
		public static void Clear()
		{
			ThreadContext.Stacks["NDC"].Clear();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000233F File Offset: 0x0000133F
		public static Stack CloneStack()
		{
			return ThreadContext.Stacks["NDC"].InternalStack;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002355 File Offset: 0x00001355
		public static void Inherit(Stack stack)
		{
			ThreadContext.Stacks["NDC"].InternalStack = stack;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000236C File Offset: 0x0000136C
		public static string Pop()
		{
			return ThreadContext.Stacks["NDC"].Pop();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002382 File Offset: 0x00001382
		public static IDisposable Push(string message)
		{
			return ThreadContext.Stacks["NDC"].Push(message);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002399 File Offset: 0x00001399
		public static IDisposable PushFormat(string messageFormat, params object[] args)
		{
			return NDC.Push(string.Format(messageFormat, args));
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000023A7 File Offset: 0x000013A7
		public static void Remove()
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000023AC File Offset: 0x000013AC
		public static void SetMaxDepth(int maxDepth)
		{
			if (maxDepth >= 0)
			{
				ThreadContextStack threadContextStack = ThreadContext.Stacks["NDC"];
				if (maxDepth == 0)
				{
					threadContextStack.Clear();
					return;
				}
				while (threadContextStack.Count > maxDepth)
				{
					threadContextStack.Pop();
				}
			}
		}
	}
}
