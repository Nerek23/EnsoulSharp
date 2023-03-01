using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x02000089 RID: 137
	public abstract class PatternLayoutConverter : PatternConverter
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003FC RID: 1020 RVA: 0x0000D14F File Offset: 0x0000C14F
		// (set) Token: 0x060003FD RID: 1021 RVA: 0x0000D157 File Offset: 0x0000C157
		public virtual bool IgnoresException
		{
			get
			{
				return this.m_ignoresException;
			}
			set
			{
				this.m_ignoresException = value;
			}
		}

		// Token: 0x060003FE RID: 1022
		protected abstract void Convert(TextWriter writer, LoggingEvent loggingEvent);

		// Token: 0x060003FF RID: 1023 RVA: 0x0000D160 File Offset: 0x0000C160
		protected override void Convert(TextWriter writer, object state)
		{
			LoggingEvent loggingEvent = state as LoggingEvent;
			if (loggingEvent != null)
			{
				this.Convert(writer, loggingEvent);
				return;
			}
			throw new ArgumentException("state must be of type [" + typeof(LoggingEvent).FullName + "]", "state");
		}

		// Token: 0x04000105 RID: 261
		private bool m_ignoresException = true;
	}
}
