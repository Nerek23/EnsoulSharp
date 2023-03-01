using System;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x0200005B RID: 91
	internal sealed class LoggerKey
	{
		// Token: 0x06000315 RID: 789 RVA: 0x00009291 File Offset: 0x00008291
		internal LoggerKey(string name)
		{
			this.m_name = string.Intern(name);
			this.m_hashCache = name.GetHashCode();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000092B1 File Offset: 0x000082B1
		public override int GetHashCode()
		{
			return this.m_hashCache;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000092BC File Offset: 0x000082BC
		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			LoggerKey loggerKey = obj as LoggerKey;
			return loggerKey != null && this.m_name == loggerKey.m_name;
		}

		// Token: 0x040000A6 RID: 166
		private readonly string m_name;

		// Token: 0x040000A7 RID: 167
		private readonly int m_hashCache;
	}
}
