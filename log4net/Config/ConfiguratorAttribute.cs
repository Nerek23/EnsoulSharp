using System;
using System.Reflection;
using log4net.Repository;

namespace log4net.Config
{
	// Token: 0x020000C6 RID: 198
	[AttributeUsage(AttributeTargets.Assembly)]
	public abstract class ConfiguratorAttribute : Attribute, IComparable
	{
		// Token: 0x06000595 RID: 1429 RVA: 0x00011D16 File Offset: 0x00010D16
		protected ConfiguratorAttribute(int priority)
		{
			this.m_priority = priority;
		}

		// Token: 0x06000596 RID: 1430
		public abstract void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository);

		// Token: 0x06000597 RID: 1431 RVA: 0x00011D28 File Offset: 0x00010D28
		public int CompareTo(object obj)
		{
			if (this == obj)
			{
				return 0;
			}
			int num = -1;
			ConfiguratorAttribute configuratorAttribute = obj as ConfiguratorAttribute;
			if (configuratorAttribute != null)
			{
				num = configuratorAttribute.m_priority.CompareTo(this.m_priority);
				if (num == 0)
				{
					num = -1;
				}
			}
			return num;
		}

		// Token: 0x040001A1 RID: 417
		private int m_priority;
	}
}
