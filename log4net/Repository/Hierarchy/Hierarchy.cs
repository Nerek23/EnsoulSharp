using System;
using System.Collections;
using System.Xml;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace log4net.Repository.Hierarchy
{
	// Token: 0x02000058 RID: 88
	public class Hierarchy : LoggerRepositorySkeleton, IBasicRepositoryConfigurator, IXmlRepositoryConfigurator
	{
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060002D5 RID: 725 RVA: 0x000082B7 File Offset: 0x000072B7
		// (remove) Token: 0x060002D6 RID: 726 RVA: 0x000082C0 File Offset: 0x000072C0
		public event LoggerCreationEventHandler LoggerCreatedEvent
		{
			add
			{
				this.m_loggerCreatedEvent += value;
			}
			remove
			{
				this.m_loggerCreatedEvent -= value;
			}
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000082C9 File Offset: 0x000072C9
		public Hierarchy() : this(new DefaultLoggerFactory())
		{
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x000082D6 File Offset: 0x000072D6
		public Hierarchy(PropertiesDictionary properties) : this(properties, new DefaultLoggerFactory())
		{
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000082E4 File Offset: 0x000072E4
		public Hierarchy(ILoggerFactory loggerFactory) : this(new PropertiesDictionary(), loggerFactory)
		{
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000082F2 File Offset: 0x000072F2
		public Hierarchy(PropertiesDictionary properties, ILoggerFactory loggerFactory) : base(properties)
		{
			if (loggerFactory == null)
			{
				throw new ArgumentNullException("loggerFactory");
			}
			this.m_defaultFactory = loggerFactory;
			this.m_ht = Hashtable.Synchronized(new Hashtable());
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002DB RID: 731 RVA: 0x00008320 File Offset: 0x00007320
		// (set) Token: 0x060002DC RID: 732 RVA: 0x00008328 File Offset: 0x00007328
		public bool EmittedNoAppenderWarning
		{
			get
			{
				return this.m_emittedNoAppenderWarning;
			}
			set
			{
				this.m_emittedNoAppenderWarning = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002DD RID: 733 RVA: 0x00008334 File Offset: 0x00007334
		public Logger Root
		{
			get
			{
				if (this.m_root == null)
				{
					lock (this)
					{
						if (this.m_root == null)
						{
							Logger logger = this.m_defaultFactory.CreateLogger(this, null);
							logger.Hierarchy = this;
							this.m_root = logger;
						}
					}
				}
				return this.m_root;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000839C File Offset: 0x0000739C
		// (set) Token: 0x060002DF RID: 735 RVA: 0x000083A4 File Offset: 0x000073A4
		public ILoggerFactory LoggerFactory
		{
			get
			{
				return this.m_defaultFactory;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.m_defaultFactory = value;
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000083BC File Offset: 0x000073BC
		public override ILogger Exists(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			Hashtable ht = this.m_ht;
			ILogger result;
			lock (ht)
			{
				result = (this.m_ht[new LoggerKey(name)] as Logger);
			}
			return result;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000841C File Offset: 0x0000741C
		public override ILogger[] GetCurrentLoggers()
		{
			Hashtable ht = this.m_ht;
			ILogger[] array;
			lock (ht)
			{
				ArrayList arrayList = new ArrayList(this.m_ht.Count);
				foreach (object obj in this.m_ht.Values)
				{
					if (obj is Logger)
					{
						arrayList.Add(obj);
					}
				}
				array = (Logger[])arrayList.ToArray(typeof(Logger));
				array = array;
			}
			return array;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000084DC File Offset: 0x000074DC
		public override ILogger GetLogger(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return this.GetLogger(name, this.m_defaultFactory);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000084FC File Offset: 0x000074FC
		public override void Shutdown()
		{
			LogLog.Debug(Hierarchy.declaringType, "Shutdown called on Hierarchy [" + this.Name + "]");
			this.Root.CloseNestedAppenders();
			Hashtable ht = this.m_ht;
			lock (ht)
			{
				ILogger[] currentLoggers = this.GetCurrentLoggers();
				ILogger[] array = currentLoggers;
				for (int i = 0; i < array.Length; i++)
				{
					((Logger)array[i]).CloseNestedAppenders();
				}
				this.Root.RemoveAllAppenders();
				array = currentLoggers;
				for (int i = 0; i < array.Length; i++)
				{
					((Logger)array[i]).RemoveAllAppenders();
				}
			}
			base.Shutdown();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000085BC File Offset: 0x000075BC
		public override void ResetConfiguration()
		{
			this.Root.Level = this.LevelMap.LookupWithDefault(Level.Debug);
			this.Threshold = this.LevelMap.LookupWithDefault(Level.All);
			Hashtable ht = this.m_ht;
			lock (ht)
			{
				this.Shutdown();
				foreach (Logger logger in this.GetCurrentLoggers())
				{
					logger.Level = null;
					logger.Additivity = true;
				}
			}
			base.ResetConfiguration();
			this.OnConfigurationChanged(null);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00008664 File Offset: 0x00007664
		public override void Log(LoggingEvent logEvent)
		{
			if (logEvent == null)
			{
				throw new ArgumentNullException("logEvent");
			}
			this.GetLogger(logEvent.LoggerName, this.m_defaultFactory).Log(logEvent);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000868C File Offset: 0x0000768C
		public override IAppender[] GetAppenders()
		{
			ArrayList arrayList = new ArrayList();
			Hierarchy.CollectAppenders(arrayList, this.Root);
			foreach (Logger container in this.GetCurrentLoggers())
			{
				Hierarchy.CollectAppenders(arrayList, container);
			}
			return (IAppender[])arrayList.ToArray(typeof(IAppender));
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000086E8 File Offset: 0x000076E8
		private static void CollectAppender(ArrayList appenderList, IAppender appender)
		{
			if (!appenderList.Contains(appender))
			{
				appenderList.Add(appender);
				IAppenderAttachable appenderAttachable = appender as IAppenderAttachable;
				if (appenderAttachable != null)
				{
					Hierarchy.CollectAppenders(appenderList, appenderAttachable);
				}
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00008718 File Offset: 0x00007718
		private static void CollectAppenders(ArrayList appenderList, IAppenderAttachable container)
		{
			foreach (IAppender appender in container.Appenders)
			{
				Hierarchy.CollectAppender(appenderList, appender);
			}
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000876C File Offset: 0x0000776C
		void IBasicRepositoryConfigurator.Configure(IAppender appender)
		{
			this.BasicRepositoryConfigure(new IAppender[]
			{
				appender
			});
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000877E File Offset: 0x0000777E
		void IBasicRepositoryConfigurator.Configure(params IAppender[] appenders)
		{
			this.BasicRepositoryConfigure(appenders);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00008788 File Offset: 0x00007788
		protected void BasicRepositoryConfigure(params IAppender[] appenders)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				foreach (IAppender newAppender in appenders)
				{
					this.Root.AddAppender(newAppender);
				}
			}
			this.Configured = true;
			this.ConfigurationMessages = arrayList;
			this.OnConfigurationChanged(new ConfigurationChangedEventArgs(arrayList));
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000087FC File Offset: 0x000077FC
		void IXmlRepositoryConfigurator.Configure(XmlElement element)
		{
			this.XmlRepositoryConfigure(element);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00008808 File Offset: 0x00007808
		protected void XmlRepositoryConfigure(XmlElement element)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				new XmlHierarchyConfigurator(this).Configure(element);
			}
			this.Configured = true;
			this.ConfigurationMessages = arrayList;
			this.OnConfigurationChanged(new ConfigurationChangedEventArgs(arrayList));
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00008864 File Offset: 0x00007864
		public bool IsDisabled(Level level)
		{
			if (level == null)
			{
				throw new ArgumentNullException("level");
			}
			return !this.Configured || this.Threshold > level;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000888C File Offset: 0x0000788C
		public void Clear()
		{
			Hashtable ht = this.m_ht;
			lock (ht)
			{
				this.m_ht.Clear();
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000088D4 File Offset: 0x000078D4
		public Logger GetLogger(string name, ILoggerFactory factory)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			LoggerKey key = new LoggerKey(name);
			Hashtable ht = this.m_ht;
			Logger result;
			lock (ht)
			{
				object obj = this.m_ht[key];
				if (obj == null)
				{
					Logger logger = factory.CreateLogger(this, name);
					logger.Hierarchy = this;
					this.m_ht[key] = logger;
					this.UpdateParents(logger);
					this.OnLoggerCreationEvent(logger);
					result = logger;
				}
				else
				{
					Logger logger2 = obj as Logger;
					if (logger2 != null)
					{
						result = logger2;
					}
					else
					{
						ProvisionNode provisionNode = obj as ProvisionNode;
						if (provisionNode != null)
						{
							Logger logger = factory.CreateLogger(this, name);
							logger.Hierarchy = this;
							this.m_ht[key] = logger;
							Hierarchy.UpdateChildren(provisionNode, logger);
							this.UpdateParents(logger);
							this.OnLoggerCreationEvent(logger);
							result = logger;
						}
						else
						{
							result = null;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x000089D4 File Offset: 0x000079D4
		protected virtual void OnLoggerCreationEvent(Logger logger)
		{
			LoggerCreationEventHandler loggerCreatedEvent = this.m_loggerCreatedEvent;
			if (loggerCreatedEvent != null)
			{
				loggerCreatedEvent(this, new LoggerCreationEventArgs(logger));
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000089F8 File Offset: 0x000079F8
		private void UpdateParents(Logger log)
		{
			string name = log.Name;
			int length = name.Length;
			bool flag = false;
			for (int i = name.LastIndexOf('.', length - 1); i >= 0; i = name.LastIndexOf('.', i - 1))
			{
				LoggerKey key = new LoggerKey(name.Substring(0, i));
				object obj = this.m_ht[key];
				if (obj == null)
				{
					ProvisionNode value = new ProvisionNode(log);
					this.m_ht[key] = value;
				}
				else
				{
					Logger logger = obj as Logger;
					if (logger != null)
					{
						flag = true;
						log.Parent = logger;
						break;
					}
					ProvisionNode provisionNode = obj as ProvisionNode;
					if (provisionNode != null)
					{
						provisionNode.Add(log);
					}
					else
					{
						Type source = Hierarchy.declaringType;
						string str = "Unexpected object type [";
						Type type = obj.GetType();
						LogLog.Error(source, str + ((type != null) ? type.ToString() : null) + "] in ht.", new LogException());
					}
				}
				if (i == 0)
				{
					break;
				}
			}
			if (!flag)
			{
				log.Parent = this.Root;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00008AE8 File Offset: 0x00007AE8
		private static void UpdateChildren(ProvisionNode pn, Logger log)
		{
			for (int i = 0; i < pn.Count; i++)
			{
				Logger logger = (Logger)pn[i];
				if (!logger.Parent.Name.StartsWith(log.Name))
				{
					log.Parent = logger.Parent;
					logger.Parent = log;
				}
			}
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00008B40 File Offset: 0x00007B40
		internal void AddLevel(Hierarchy.LevelEntry levelEntry)
		{
			if (levelEntry == null)
			{
				throw new ArgumentNullException("levelEntry");
			}
			if (levelEntry.Name == null)
			{
				throw new ArgumentNullException("levelEntry.Name");
			}
			if (levelEntry.Value == -1)
			{
				Level level = this.LevelMap[levelEntry.Name];
				if (level == null)
				{
					throw new InvalidOperationException("Cannot redefine level [" + levelEntry.Name + "] because it is not defined in the LevelMap. To define the level supply the level value.");
				}
				levelEntry.Value = level.Value;
			}
			this.LevelMap.Add(levelEntry.Name, levelEntry.Value, levelEntry.DisplayName);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00008BD6 File Offset: 0x00007BD6
		internal void AddProperty(PropertyEntry propertyEntry)
		{
			if (propertyEntry == null)
			{
				throw new ArgumentNullException("propertyEntry");
			}
			if (propertyEntry.Key == null)
			{
				throw new ArgumentNullException("propertyEntry.Key");
			}
			base.Properties[propertyEntry.Key] = propertyEntry.Value;
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060002F6 RID: 758 RVA: 0x00008C10 File Offset: 0x00007C10
		// (remove) Token: 0x060002F7 RID: 759 RVA: 0x00008C48 File Offset: 0x00007C48
		private event LoggerCreationEventHandler m_loggerCreatedEvent;

		// Token: 0x04000098 RID: 152
		private ILoggerFactory m_defaultFactory;

		// Token: 0x04000099 RID: 153
		private Hashtable m_ht;

		// Token: 0x0400009A RID: 154
		private Logger m_root;

		// Token: 0x0400009B RID: 155
		private bool m_emittedNoAppenderWarning;

		// Token: 0x0400009D RID: 157
		private static readonly Type declaringType = typeof(Hierarchy);

		// Token: 0x020000F9 RID: 249
		internal class LevelEntry
		{
			// Token: 0x17000199 RID: 409
			// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00018DA3 File Offset: 0x00017DA3
			// (set) Token: 0x060007D9 RID: 2009 RVA: 0x00018DAB File Offset: 0x00017DAB
			public int Value
			{
				get
				{
					return this.m_levelValue;
				}
				set
				{
					this.m_levelValue = value;
				}
			}

			// Token: 0x1700019A RID: 410
			// (get) Token: 0x060007DA RID: 2010 RVA: 0x00018DB4 File Offset: 0x00017DB4
			// (set) Token: 0x060007DB RID: 2011 RVA: 0x00018DBC File Offset: 0x00017DBC
			public string Name
			{
				get
				{
					return this.m_levelName;
				}
				set
				{
					this.m_levelName = value;
				}
			}

			// Token: 0x1700019B RID: 411
			// (get) Token: 0x060007DC RID: 2012 RVA: 0x00018DC5 File Offset: 0x00017DC5
			// (set) Token: 0x060007DD RID: 2013 RVA: 0x00018DCD File Offset: 0x00017DCD
			public string DisplayName
			{
				get
				{
					return this.m_levelDisplayName;
				}
				set
				{
					this.m_levelDisplayName = value;
				}
			}

			// Token: 0x060007DE RID: 2014 RVA: 0x00018DD8 File Offset: 0x00017DD8
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					"LevelEntry(Value=",
					this.m_levelValue.ToString(),
					", Name=",
					this.m_levelName,
					", DisplayName=",
					this.m_levelDisplayName,
					")"
				});
			}

			// Token: 0x04000262 RID: 610
			private int m_levelValue = -1;

			// Token: 0x04000263 RID: 611
			private string m_levelName;

			// Token: 0x04000264 RID: 612
			private string m_levelDisplayName;
		}
	}
}
