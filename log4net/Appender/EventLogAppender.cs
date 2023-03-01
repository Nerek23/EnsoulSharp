using System;
using System.Diagnostics;
using System.Security;
using System.Threading;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000DB RID: 219
	public class EventLogAppender : AppenderSkeleton
	{
		// Token: 0x0600069E RID: 1694 RVA: 0x00014DA7 File Offset: 0x00013DA7
		public EventLogAppender()
		{
			this.m_applicationName = Thread.GetDomain().FriendlyName;
			this.m_logName = "Application";
			this.m_machineName = ".";
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00014DE0 File Offset: 0x00013DE0
		[Obsolete("Instead use the default constructor and set the Layout property")]
		public EventLogAppender(ILayout layout) : this()
		{
			this.Layout = layout;
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x00014DEF File Offset: 0x00013DEF
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x00014DF7 File Offset: 0x00013DF7
		public string LogName
		{
			get
			{
				return this.m_logName;
			}
			set
			{
				this.m_logName = value;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x00014E00 File Offset: 0x00013E00
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x00014E08 File Offset: 0x00013E08
		public string ApplicationName
		{
			get
			{
				return this.m_applicationName;
			}
			set
			{
				this.m_applicationName = value;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x00014E11 File Offset: 0x00013E11
		// (set) Token: 0x060006A5 RID: 1701 RVA: 0x00014E19 File Offset: 0x00013E19
		public string MachineName
		{
			get
			{
				return this.m_machineName;
			}
			set
			{
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00014E1B File Offset: 0x00013E1B
		public void AddMapping(EventLogAppender.Level2EventLogEntryType mapping)
		{
			this.m_levelMapping.Add(mapping);
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00014E29 File Offset: 0x00013E29
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x00014E31 File Offset: 0x00013E31
		public log4net.Core.SecurityContext SecurityContext
		{
			get
			{
				return this.m_securityContext;
			}
			set
			{
				this.m_securityContext = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00014E3A File Offset: 0x00013E3A
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x00014E42 File Offset: 0x00013E42
		public int EventId
		{
			get
			{
				return this.m_eventId;
			}
			set
			{
				this.m_eventId = value;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x00014E4B File Offset: 0x00013E4B
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x00014E53 File Offset: 0x00013E53
		public short Category
		{
			get
			{
				return this.m_category;
			}
			set
			{
				this.m_category = value;
			}
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00014E5C File Offset: 0x00013E5C
		public override void ActivateOptions()
		{
			try
			{
				base.ActivateOptions();
				if (this.m_securityContext == null)
				{
					this.m_securityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
				}
				bool flag = false;
				string text = null;
				using (this.SecurityContext.Impersonate(this))
				{
					flag = EventLog.SourceExists(this.m_applicationName);
					if (flag)
					{
						text = EventLog.LogNameFromSourceName(this.m_applicationName, this.m_machineName);
					}
				}
				if (flag && text != this.m_logName)
				{
					LogLog.Debug(EventLogAppender.declaringType, string.Concat(new string[]
					{
						"Changing event source [",
						this.m_applicationName,
						"] from log [",
						text,
						"] to log [",
						this.m_logName,
						"]"
					}));
				}
				else if (!flag)
				{
					LogLog.Debug(EventLogAppender.declaringType, string.Concat(new string[]
					{
						"Creating event source Source [",
						this.m_applicationName,
						"] in log ",
						this.m_logName,
						"]"
					}));
				}
				string text2 = null;
				using (this.SecurityContext.Impersonate(this))
				{
					if (flag && text != this.m_logName)
					{
						EventLog.DeleteEventSource(this.m_applicationName, this.m_machineName);
						EventLogAppender.CreateEventSource(this.m_applicationName, this.m_logName, this.m_machineName);
						text2 = EventLog.LogNameFromSourceName(this.m_applicationName, this.m_machineName);
					}
					else if (!flag)
					{
						EventLogAppender.CreateEventSource(this.m_applicationName, this.m_logName, this.m_machineName);
						text2 = EventLog.LogNameFromSourceName(this.m_applicationName, this.m_machineName);
					}
				}
				this.m_levelMapping.ActivateOptions();
				LogLog.Debug(EventLogAppender.declaringType, string.Concat(new string[]
				{
					"Source [",
					this.m_applicationName,
					"] is registered to log [",
					text2,
					"]"
				}));
			}
			catch (SecurityException e)
			{
				this.ErrorHandler.Error("Caught a SecurityException trying to access the EventLog.  Most likely the event source " + this.m_applicationName + " doesn't exist and must be created by a local administrator.  Will disable EventLogAppender.  See http://logging.apache.org/log4net/release/faq.html#trouble-EventLog", e);
				base.Threshold = Level.Off;
			}
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x000150C0 File Offset: 0x000140C0
		private static void CreateEventSource(string source, string logName, string machineName)
		{
			EventLog.CreateEventSource(new EventSourceCreationData(source, logName)
			{
				MachineName = machineName
			});
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000150D8 File Offset: 0x000140D8
		protected override void Append(LoggingEvent loggingEvent)
		{
			int eventID = this.m_eventId;
			object obj = loggingEvent.LookupProperty("EventID");
			if (obj != null)
			{
				if (obj is int)
				{
					eventID = (int)obj;
				}
				else
				{
					string text = obj as string;
					if (text == null)
					{
						text = obj.ToString();
					}
					if (text != null && text.Length > 0)
					{
						int num;
						if (SystemInfo.TryParse(text, out num))
						{
							eventID = num;
						}
						else
						{
							this.ErrorHandler.Error("Unable to parse event ID property [" + text + "].");
						}
					}
				}
			}
			short category = this.m_category;
			object obj2 = loggingEvent.LookupProperty("Category");
			if (obj2 != null)
			{
				if (obj2 is short)
				{
					category = (short)obj2;
				}
				else
				{
					string text2 = obj2 as string;
					if (text2 == null)
					{
						text2 = obj2.ToString();
					}
					if (text2 != null && text2.Length > 0)
					{
						short num2;
						if (SystemInfo.TryParse(text2, out num2))
						{
							category = num2;
						}
						else
						{
							this.ErrorHandler.Error("Unable to parse event category property [" + text2 + "].");
						}
					}
				}
			}
			try
			{
				string text3 = base.RenderLoggingEvent(loggingEvent);
				if (text3.Length > EventLogAppender.MAX_EVENTLOG_MESSAGE_SIZE)
				{
					text3 = text3.Substring(0, EventLogAppender.MAX_EVENTLOG_MESSAGE_SIZE);
				}
				EventLogEntryType entryType = this.GetEntryType(loggingEvent.Level);
				using (this.SecurityContext.Impersonate(this))
				{
					EventLog.WriteEntry(this.m_applicationName, text3, entryType, eventID, category);
				}
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error(string.Concat(new string[]
				{
					"Unable to write to event log [",
					this.m_logName,
					"] using source [",
					this.m_applicationName,
					"]"
				}), e);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x00015298 File Offset: 0x00014298
		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001529C File Offset: 0x0001429C
		protected virtual EventLogEntryType GetEntryType(Level level)
		{
			EventLogAppender.Level2EventLogEntryType level2EventLogEntryType = this.m_levelMapping.Lookup(level) as EventLogAppender.Level2EventLogEntryType;
			if (level2EventLogEntryType != null)
			{
				return level2EventLogEntryType.EventLogEntryType;
			}
			if (level >= Level.Error)
			{
				return EventLogEntryType.Error;
			}
			if (level == Level.Warn)
			{
				return EventLogEntryType.Warning;
			}
			return EventLogEntryType.Information;
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x000152E4 File Offset: 0x000142E4
		private static int GetMaxEventLogMessageSize()
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
			{
				return EventLogAppender.MAX_EVENTLOG_MESSAGE_SIZE_VISTA_OR_NEWER;
			}
			return EventLogAppender.MAX_EVENTLOG_MESSAGE_SIZE_DEFAULT;
		}

		// Token: 0x040001EE RID: 494
		private string m_logName;

		// Token: 0x040001EF RID: 495
		private string m_applicationName;

		// Token: 0x040001F0 RID: 496
		private string m_machineName;

		// Token: 0x040001F1 RID: 497
		private LevelMapping m_levelMapping = new LevelMapping();

		// Token: 0x040001F2 RID: 498
		private log4net.Core.SecurityContext m_securityContext;

		// Token: 0x040001F3 RID: 499
		private int m_eventId;

		// Token: 0x040001F4 RID: 500
		private short m_category;

		// Token: 0x040001F5 RID: 501
		private static readonly Type declaringType = typeof(EventLogAppender);

		// Token: 0x040001F6 RID: 502
		private static readonly int MAX_EVENTLOG_MESSAGE_SIZE_DEFAULT = 32766;

		// Token: 0x040001F7 RID: 503
		private static readonly int MAX_EVENTLOG_MESSAGE_SIZE_VISTA_OR_NEWER = 31837;

		// Token: 0x040001F8 RID: 504
		private static readonly int MAX_EVENTLOG_MESSAGE_SIZE = EventLogAppender.GetMaxEventLogMessageSize();

		// Token: 0x02000111 RID: 273
		public class Level2EventLogEntryType : LevelMappingEntry
		{
			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x06000855 RID: 2133 RVA: 0x00019747 File Offset: 0x00018747
			// (set) Token: 0x06000856 RID: 2134 RVA: 0x0001974F File Offset: 0x0001874F
			public EventLogEntryType EventLogEntryType
			{
				get
				{
					return this.m_entryType;
				}
				set
				{
					this.m_entryType = value;
				}
			}

			// Token: 0x040002AD RID: 685
			private EventLogEntryType m_entryType;
		}
	}
}
