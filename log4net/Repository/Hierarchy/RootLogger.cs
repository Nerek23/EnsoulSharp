using System;
using log4net.Core;
using log4net.Util;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x0200005D RID: 93
	public class RootLogger : Logger
	{
		// Token: 0x06000319 RID: 793 RVA: 0x000092F9 File Offset: 0x000082F9
		public RootLogger(Level level) : base("root")
		{
			this.Level = level;
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000930D File Offset: 0x0000830D
		public override Level EffectiveLevel
		{
			get
			{
				return base.Level;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00009315 File Offset: 0x00008315
		// (set) Token: 0x0600031C RID: 796 RVA: 0x0000931D File Offset: 0x0000831D
		public override Level Level
		{
			get
			{
				return base.Level;
			}
			set
			{
				if (value == null)
				{
					LogLog.Error(RootLogger.declaringType, "You have tried to set a null level to root.", new LogException());
					return;
				}
				base.Level = value;
			}
		}

		// Token: 0x040000A8 RID: 168
		private static readonly Type declaringType = typeof(RootLogger);
	}
}
