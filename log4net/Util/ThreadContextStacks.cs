using System;

namespace log4net.Util
{
	// Token: 0x02000032 RID: 50
	public sealed class ThreadContextStacks
	{
		// Token: 0x06000210 RID: 528 RVA: 0x00006A74 File Offset: 0x00005A74
		internal ThreadContextStacks(ContextPropertiesBase properties)
		{
			this.m_properties = properties;
		}

		// Token: 0x17000076 RID: 118
		public ThreadContextStack this[string key]
		{
			get
			{
				object obj = this.m_properties[key];
				ThreadContextStack threadContextStack;
				if (obj == null)
				{
					threadContextStack = new ThreadContextStack();
					this.m_properties[key] = threadContextStack;
				}
				else
				{
					threadContextStack = (obj as ThreadContextStack);
					if (threadContextStack == null)
					{
						string text = SystemInfo.NullText;
						try
						{
							text = obj.ToString();
						}
						catch
						{
						}
						LogLog.Error(ThreadContextStacks.declaringType, string.Concat(new string[]
						{
							"ThreadContextStacks: Request for stack named [",
							key,
							"] failed because a property with the same name exists which is a [",
							obj.GetType().Name,
							"] with value [",
							text,
							"]"
						}));
						threadContextStack = new ThreadContextStack();
					}
				}
				return threadContextStack;
			}
		}

		// Token: 0x04000070 RID: 112
		private readonly ContextPropertiesBase m_properties;

		// Token: 0x04000071 RID: 113
		private static readonly Type declaringType = typeof(ThreadContextStacks);
	}
}
