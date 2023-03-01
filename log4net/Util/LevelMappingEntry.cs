using System;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000015 RID: 21
	public abstract class LevelMappingEntry : IOptionHandler
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00003E70 File Offset: 0x00002E70
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00003E78 File Offset: 0x00002E78
		public Level Level
		{
			get
			{
				return this.m_level;
			}
			set
			{
				this.m_level = value;
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00003E81 File Offset: 0x00002E81
		public virtual void ActivateOptions()
		{
		}

		// Token: 0x0400001F RID: 31
		private Level m_level;
	}
}
