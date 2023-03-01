using System;

namespace log4net.Util
{
	// Token: 0x02000019 RID: 25
	public sealed class LogicalThreadContextStacks
	{
		// Token: 0x06000108 RID: 264 RVA: 0x00004134 File Offset: 0x00003134
		internal LogicalThreadContextStacks(LogicalThreadContextProperties properties)
		{
			this.m_properties = properties;
		}

		// Token: 0x1700002B RID: 43
		public LogicalThreadContextStack this[string key]
		{
			get
			{
				object obj = this.m_properties[key];
				LogicalThreadContextStack logicalThreadContextStack;
				if (obj == null)
				{
					logicalThreadContextStack = new LogicalThreadContextStack(key, new TwoArgAction<string, LogicalThreadContextStack>(this.registerNew));
					this.m_properties[key] = logicalThreadContextStack;
				}
				else
				{
					logicalThreadContextStack = (obj as LogicalThreadContextStack);
					if (logicalThreadContextStack == null)
					{
						string text = SystemInfo.NullText;
						try
						{
							text = obj.ToString();
						}
						catch
						{
						}
						LogLog.Error(LogicalThreadContextStacks.declaringType, string.Concat(new string[]
						{
							"ThreadContextStacks: Request for stack named [",
							key,
							"] failed because a property with the same name exists which is a [",
							obj.GetType().Name,
							"] with value [",
							text,
							"]"
						}));
						logicalThreadContextStack = new LogicalThreadContextStack(key, new TwoArgAction<string, LogicalThreadContextStack>(this.registerNew));
					}
				}
				return logicalThreadContextStack;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00004210 File Offset: 0x00003210
		private void registerNew(string stackName, LogicalThreadContextStack stack)
		{
			this.m_properties[stackName] = stack;
		}

		// Token: 0x04000026 RID: 38
		private readonly LogicalThreadContextProperties m_properties;

		// Token: 0x04000027 RID: 39
		private static readonly Type declaringType = typeof(LogicalThreadContextStacks);
	}
}
