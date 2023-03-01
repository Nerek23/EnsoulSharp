using System;
using System.Collections;
using log4net.Appender;
using log4net.Core;
using log4net.ObjectRenderer;
using log4net.Plugin;
using log4net.Util;

namespace log4net.Repository
{
	// Token: 0x02000054 RID: 84
	public abstract class LoggerRepositorySkeleton : ILoggerRepository, IFlushable
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060002A3 RID: 675 RVA: 0x00007C88 File Offset: 0x00006C88
		// (remove) Token: 0x060002A4 RID: 676 RVA: 0x00007CC0 File Offset: 0x00006CC0
		private event LoggerRepositoryShutdownEventHandler m_shutdownEvent;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060002A5 RID: 677 RVA: 0x00007CF8 File Offset: 0x00006CF8
		// (remove) Token: 0x060002A6 RID: 678 RVA: 0x00007D30 File Offset: 0x00006D30
		private event LoggerRepositoryConfigurationResetEventHandler m_configurationResetEvent;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060002A7 RID: 679 RVA: 0x00007D68 File Offset: 0x00006D68
		// (remove) Token: 0x060002A8 RID: 680 RVA: 0x00007DA0 File Offset: 0x00006DA0
		private event LoggerRepositoryConfigurationChangedEventHandler m_configurationChangedEvent;

		// Token: 0x060002A9 RID: 681 RVA: 0x00007DD5 File Offset: 0x00006DD5
		protected LoggerRepositorySkeleton() : this(new PropertiesDictionary())
		{
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00007DE4 File Offset: 0x00006DE4
		protected LoggerRepositorySkeleton(PropertiesDictionary properties)
		{
			this.m_properties = properties;
			this.m_rendererMap = new RendererMap();
			this.m_pluginMap = new PluginMap(this);
			this.m_levelMap = new LevelMap();
			this.m_configurationMessages = EmptyCollection.Instance;
			this.m_configured = false;
			this.AddBuiltinLevels();
			this.m_threshold = Level.All;
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002AB RID: 683 RVA: 0x00007E43 File Offset: 0x00006E43
		// (set) Token: 0x060002AC RID: 684 RVA: 0x00007E4B File Offset: 0x00006E4B
		public virtual string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00007E54 File Offset: 0x00006E54
		// (set) Token: 0x060002AE RID: 686 RVA: 0x00007E5C File Offset: 0x00006E5C
		public virtual Level Threshold
		{
			get
			{
				return this.m_threshold;
			}
			set
			{
				if (value != null)
				{
					this.m_threshold = value;
					return;
				}
				LogLog.Warn(LoggerRepositorySkeleton.declaringType, "LoggerRepositorySkeleton: Threshold cannot be set to null. Setting to ALL");
				this.m_threshold = Level.All;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002AF RID: 687 RVA: 0x00007E89 File Offset: 0x00006E89
		public virtual RendererMap RendererMap
		{
			get
			{
				return this.m_rendererMap;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00007E91 File Offset: 0x00006E91
		public virtual PluginMap PluginMap
		{
			get
			{
				return this.m_pluginMap;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00007E99 File Offset: 0x00006E99
		public virtual LevelMap LevelMap
		{
			get
			{
				return this.m_levelMap;
			}
		}

		// Token: 0x060002B2 RID: 690
		public abstract ILogger Exists(string name);

		// Token: 0x060002B3 RID: 691
		public abstract ILogger[] GetCurrentLoggers();

		// Token: 0x060002B4 RID: 692
		public abstract ILogger GetLogger(string name);

		// Token: 0x060002B5 RID: 693 RVA: 0x00007EA4 File Offset: 0x00006EA4
		public virtual void Shutdown()
		{
			foreach (IPlugin plugin in this.PluginMap.AllPlugins)
			{
				plugin.Shutdown();
			}
			this.OnShutdown(null);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00007F04 File Offset: 0x00006F04
		public virtual void ResetConfiguration()
		{
			this.m_rendererMap.Clear();
			this.m_levelMap.Clear();
			this.m_configurationMessages = EmptyCollection.Instance;
			this.AddBuiltinLevels();
			this.Configured = false;
			this.OnConfigurationReset(null);
		}

		// Token: 0x060002B7 RID: 695
		public abstract void Log(LoggingEvent logEvent);

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00007F3B File Offset: 0x00006F3B
		// (set) Token: 0x060002B9 RID: 697 RVA: 0x00007F43 File Offset: 0x00006F43
		public virtual bool Configured
		{
			get
			{
				return this.m_configured;
			}
			set
			{
				this.m_configured = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00007F4C File Offset: 0x00006F4C
		// (set) Token: 0x060002BB RID: 699 RVA: 0x00007F54 File Offset: 0x00006F54
		public virtual ICollection ConfigurationMessages
		{
			get
			{
				return this.m_configurationMessages;
			}
			set
			{
				this.m_configurationMessages = value;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060002BC RID: 700 RVA: 0x00007F5D File Offset: 0x00006F5D
		// (remove) Token: 0x060002BD RID: 701 RVA: 0x00007F66 File Offset: 0x00006F66
		public event LoggerRepositoryShutdownEventHandler ShutdownEvent
		{
			add
			{
				this.m_shutdownEvent += value;
			}
			remove
			{
				this.m_shutdownEvent -= value;
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060002BE RID: 702 RVA: 0x00007F6F File Offset: 0x00006F6F
		// (remove) Token: 0x060002BF RID: 703 RVA: 0x00007F78 File Offset: 0x00006F78
		public event LoggerRepositoryConfigurationResetEventHandler ConfigurationReset
		{
			add
			{
				this.m_configurationResetEvent += value;
			}
			remove
			{
				this.m_configurationResetEvent -= value;
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060002C0 RID: 704 RVA: 0x00007F81 File Offset: 0x00006F81
		// (remove) Token: 0x060002C1 RID: 705 RVA: 0x00007F8A File Offset: 0x00006F8A
		public event LoggerRepositoryConfigurationChangedEventHandler ConfigurationChanged
		{
			add
			{
				this.m_configurationChangedEvent += value;
			}
			remove
			{
				this.m_configurationChangedEvent -= value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00007F93 File Offset: 0x00006F93
		public PropertiesDictionary Properties
		{
			get
			{
				return this.m_properties;
			}
		}

		// Token: 0x060002C3 RID: 707
		public abstract IAppender[] GetAppenders();

		// Token: 0x060002C4 RID: 708 RVA: 0x00007F9C File Offset: 0x00006F9C
		private void AddBuiltinLevels()
		{
			this.m_levelMap.Add(Level.Off);
			this.m_levelMap.Add(Level.Emergency);
			this.m_levelMap.Add(Level.Fatal);
			this.m_levelMap.Add(Level.Alert);
			this.m_levelMap.Add(Level.Critical);
			this.m_levelMap.Add(Level.Severe);
			this.m_levelMap.Add(Level.Error);
			this.m_levelMap.Add(Level.Warn);
			this.m_levelMap.Add(Level.Notice);
			this.m_levelMap.Add(Level.Info);
			this.m_levelMap.Add(Level.Debug);
			this.m_levelMap.Add(Level.Fine);
			this.m_levelMap.Add(Level.Trace);
			this.m_levelMap.Add(Level.Finer);
			this.m_levelMap.Add(Level.Verbose);
			this.m_levelMap.Add(Level.Finest);
			this.m_levelMap.Add(Level.All);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x000080B9 File Offset: 0x000070B9
		public virtual void AddRenderer(Type typeToRender, IObjectRenderer rendererInstance)
		{
			if (typeToRender == null)
			{
				throw new ArgumentNullException("typeToRender");
			}
			if (rendererInstance == null)
			{
				throw new ArgumentNullException("rendererInstance");
			}
			this.m_rendererMap.Put(typeToRender, rendererInstance);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000080EC File Offset: 0x000070EC
		protected virtual void OnShutdown(EventArgs e)
		{
			if (e == null)
			{
				e = EventArgs.Empty;
			}
			LoggerRepositoryShutdownEventHandler shutdownEvent = this.m_shutdownEvent;
			if (shutdownEvent != null)
			{
				shutdownEvent(this, e);
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00008118 File Offset: 0x00007118
		protected virtual void OnConfigurationReset(EventArgs e)
		{
			if (e == null)
			{
				e = EventArgs.Empty;
			}
			LoggerRepositoryConfigurationResetEventHandler configurationResetEvent = this.m_configurationResetEvent;
			if (configurationResetEvent != null)
			{
				configurationResetEvent(this, e);
			}
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00008144 File Offset: 0x00007144
		protected virtual void OnConfigurationChanged(EventArgs e)
		{
			if (e == null)
			{
				e = EventArgs.Empty;
			}
			LoggerRepositoryConfigurationChangedEventHandler configurationChangedEvent = this.m_configurationChangedEvent;
			if (configurationChangedEvent != null)
			{
				configurationChangedEvent(this, e);
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000816D File Offset: 0x0000716D
		public void RaiseConfigurationChanged(EventArgs e)
		{
			this.OnConfigurationChanged(e);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00008178 File Offset: 0x00007178
		private static int GetWaitTime(DateTime startTimeUtc, int millisecondsTimeout)
		{
			if (millisecondsTimeout == -1)
			{
				return -1;
			}
			if (millisecondsTimeout == 0)
			{
				return 0;
			}
			int num = (int)(DateTime.UtcNow - startTimeUtc).TotalMilliseconds;
			int num2 = millisecondsTimeout - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			return num2;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000081B0 File Offset: 0x000071B0
		public bool Flush(int millisecondsTimeout)
		{
			if (millisecondsTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout", "Timeout must be -1 (Timeout.Infinite) or non-negative");
			}
			bool result = true;
			DateTime utcNow = DateTime.UtcNow;
			foreach (IAppender appender in this.GetAppenders())
			{
				IFlushable flushable = appender as IFlushable;
				if (flushable != null && appender is BufferingAppenderSkeleton)
				{
					int waitTime = LoggerRepositorySkeleton.GetWaitTime(utcNow, millisecondsTimeout);
					if (!flushable.Flush(waitTime))
					{
						result = false;
					}
				}
			}
			foreach (IAppender appender2 in this.GetAppenders())
			{
				IFlushable flushable2 = appender2 as IFlushable;
				if (flushable2 != null && !(appender2 is BufferingAppenderSkeleton))
				{
					int waitTime2 = LoggerRepositorySkeleton.GetWaitTime(utcNow, millisecondsTimeout);
					if (!flushable2.Flush(waitTime2))
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x0400008B RID: 139
		private string m_name;

		// Token: 0x0400008C RID: 140
		private RendererMap m_rendererMap;

		// Token: 0x0400008D RID: 141
		private PluginMap m_pluginMap;

		// Token: 0x0400008E RID: 142
		private LevelMap m_levelMap;

		// Token: 0x0400008F RID: 143
		private Level m_threshold;

		// Token: 0x04000090 RID: 144
		private bool m_configured;

		// Token: 0x04000091 RID: 145
		private ICollection m_configurationMessages;

		// Token: 0x04000095 RID: 149
		private PropertiesDictionary m_properties;

		// Token: 0x04000096 RID: 150
		private static readonly Type declaringType = typeof(LoggerRepositorySkeleton);
	}
}
