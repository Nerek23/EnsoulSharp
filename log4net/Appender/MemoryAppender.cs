using System;
using System.Collections;
using log4net.Core;

namespace log4net.Appender
{
	// Token: 0x020000E3 RID: 227
	public class MemoryAppender : AppenderSkeleton
	{
		// Token: 0x060006F7 RID: 1783 RVA: 0x00015DC2 File Offset: 0x00014DC2
		public MemoryAppender()
		{
			this.m_eventsList = new ArrayList();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00015DE0 File Offset: 0x00014DE0
		public virtual LoggingEvent[] GetEvents()
		{
			object syncRoot = this.m_eventsList.SyncRoot;
			LoggingEvent[] result;
			lock (syncRoot)
			{
				result = (LoggingEvent[])this.m_eventsList.ToArray(typeof(LoggingEvent));
			}
			return result;
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00015E3C File Offset: 0x00014E3C
		// (set) Token: 0x060006FA RID: 1786 RVA: 0x00015E4B File Offset: 0x00014E4B
		[Obsolete("Use Fix property")]
		public virtual bool OnlyFixPartialEventData
		{
			get
			{
				return this.Fix == FixFlags.Partial;
			}
			set
			{
				if (value)
				{
					this.Fix = FixFlags.Partial;
					return;
				}
				this.Fix = FixFlags.All;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00015E67 File Offset: 0x00014E67
		// (set) Token: 0x060006FC RID: 1788 RVA: 0x00015E6F File Offset: 0x00014E6F
		public virtual FixFlags Fix
		{
			get
			{
				return this.m_fixFlags;
			}
			set
			{
				this.m_fixFlags = value;
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00015E78 File Offset: 0x00014E78
		protected override void Append(LoggingEvent loggingEvent)
		{
			loggingEvent.Fix = this.Fix;
			object syncRoot = this.m_eventsList.SyncRoot;
			lock (syncRoot)
			{
				this.m_eventsList.Add(loggingEvent);
			}
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00015ED0 File Offset: 0x00014ED0
		public virtual void Clear()
		{
			object syncRoot = this.m_eventsList.SyncRoot;
			lock (syncRoot)
			{
				this.m_eventsList.Clear();
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00015F1C File Offset: 0x00014F1C
		public virtual LoggingEvent[] PopAllEvents()
		{
			object syncRoot = this.m_eventsList.SyncRoot;
			LoggingEvent[] result;
			lock (syncRoot)
			{
				LoggingEvent[] array = (LoggingEvent[])this.m_eventsList.ToArray(typeof(LoggingEvent));
				this.m_eventsList.Clear();
				result = array;
			}
			return result;
		}

		// Token: 0x04000209 RID: 521
		protected ArrayList m_eventsList;

		// Token: 0x0400020A RID: 522
		protected FixFlags m_fixFlags = FixFlags.All;
	}
}
