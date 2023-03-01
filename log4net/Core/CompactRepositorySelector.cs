using System;
using System.Collections;
using System.Reflection;
using log4net.Repository;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000A2 RID: 162
	public class CompactRepositorySelector : IRepositorySelector
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600044E RID: 1102 RVA: 0x0000DB98 File Offset: 0x0000CB98
		// (remove) Token: 0x0600044F RID: 1103 RVA: 0x0000DBD0 File Offset: 0x0000CBD0
		private event LoggerRepositoryCreationEventHandler m_loggerRepositoryCreatedEvent;

		// Token: 0x06000450 RID: 1104 RVA: 0x0000DC08 File Offset: 0x0000CC08
		public CompactRepositorySelector(Type defaultRepositoryType)
		{
			if (defaultRepositoryType == null)
			{
				throw new ArgumentNullException("defaultRepositoryType");
			}
			if (!typeof(ILoggerRepository).IsAssignableFrom(defaultRepositoryType))
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("defaultRepositoryType", defaultRepositoryType, "Parameter: defaultRepositoryType, Value: [" + ((defaultRepositoryType != null) ? defaultRepositoryType.ToString() : null) + "] out of range. Argument must implement the ILoggerRepository interface");
			}
			this.m_defaultRepositoryType = defaultRepositoryType;
			Type source = CompactRepositorySelector.declaringType;
			string str = "defaultRepositoryType [";
			Type defaultRepositoryType2 = this.m_defaultRepositoryType;
			LogLog.Debug(source, str + ((defaultRepositoryType2 != null) ? defaultRepositoryType2.ToString() : null) + "]");
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0000DCA6 File Offset: 0x0000CCA6
		public ILoggerRepository GetRepository(Assembly assembly)
		{
			return this.CreateRepository(assembly, this.m_defaultRepositoryType);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0000DCB8 File Offset: 0x0000CCB8
		public ILoggerRepository GetRepository(string repositoryName)
		{
			if (repositoryName == null)
			{
				throw new ArgumentNullException("repositoryName");
			}
			ILoggerRepository result;
			lock (this)
			{
				ILoggerRepository loggerRepository = this.m_name2repositoryMap[repositoryName] as ILoggerRepository;
				if (loggerRepository == null)
				{
					throw new LogException("Repository [" + repositoryName + "] is NOT defined.");
				}
				result = loggerRepository;
			}
			return result;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000DD28 File Offset: 0x0000CD28
		public ILoggerRepository CreateRepository(Assembly assembly, Type repositoryType)
		{
			if (repositoryType == null)
			{
				repositoryType = this.m_defaultRepositoryType;
			}
			ILoggerRepository result;
			lock (this)
			{
				ILoggerRepository loggerRepository = this.m_name2repositoryMap["log4net-default-repository"] as ILoggerRepository;
				if (loggerRepository == null)
				{
					loggerRepository = this.CreateRepository("log4net-default-repository", repositoryType);
				}
				result = loggerRepository;
			}
			return result;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000DD98 File Offset: 0x0000CD98
		public ILoggerRepository CreateRepository(string repositoryName, Type repositoryType)
		{
			if (repositoryName == null)
			{
				throw new ArgumentNullException("repositoryName");
			}
			if (repositoryType == null)
			{
				repositoryType = this.m_defaultRepositoryType;
			}
			ILoggerRepository result;
			lock (this)
			{
				ILoggerRepository loggerRepository = this.m_name2repositoryMap[repositoryName] as ILoggerRepository;
				if (loggerRepository != null)
				{
					throw new LogException("Repository [" + repositoryName + "] is already defined. Repositories cannot be redefined.");
				}
				Type source = CompactRepositorySelector.declaringType;
				string[] array = new string[5];
				array[0] = "Creating repository [";
				array[1] = repositoryName;
				array[2] = "] using type [";
				int num = 3;
				Type type = repositoryType;
				array[num] = ((type != null) ? type.ToString() : null);
				array[4] = "]";
				LogLog.Debug(source, string.Concat(array));
				loggerRepository = (ILoggerRepository)Activator.CreateInstance(repositoryType);
				loggerRepository.Name = repositoryName;
				this.m_name2repositoryMap[repositoryName] = loggerRepository;
				this.OnLoggerRepositoryCreatedEvent(loggerRepository);
				result = loggerRepository;
			}
			return result;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000DE84 File Offset: 0x0000CE84
		public bool ExistsRepository(string repositoryName)
		{
			bool result;
			lock (this)
			{
				result = this.m_name2repositoryMap.ContainsKey(repositoryName);
			}
			return result;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0000DEC8 File Offset: 0x0000CEC8
		public ILoggerRepository[] GetAllRepositories()
		{
			ILoggerRepository[] result;
			lock (this)
			{
				ICollection values = this.m_name2repositoryMap.Values;
				ILoggerRepository[] array = new ILoggerRepository[values.Count];
				values.CopyTo(array, 0);
				result = array;
			}
			return result;
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000457 RID: 1111 RVA: 0x0000DF20 File Offset: 0x0000CF20
		// (remove) Token: 0x06000458 RID: 1112 RVA: 0x0000DF29 File Offset: 0x0000CF29
		public event LoggerRepositoryCreationEventHandler LoggerRepositoryCreatedEvent
		{
			add
			{
				this.m_loggerRepositoryCreatedEvent += value;
			}
			remove
			{
				this.m_loggerRepositoryCreatedEvent -= value;
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0000DF34 File Offset: 0x0000CF34
		protected virtual void OnLoggerRepositoryCreatedEvent(ILoggerRepository repository)
		{
			LoggerRepositoryCreationEventHandler loggerRepositoryCreatedEvent = this.m_loggerRepositoryCreatedEvent;
			if (loggerRepositoryCreatedEvent != null)
			{
				loggerRepositoryCreatedEvent(this, new LoggerRepositoryCreationEventArgs(repository));
			}
		}

		// Token: 0x04000123 RID: 291
		private const string DefaultRepositoryName = "log4net-default-repository";

		// Token: 0x04000124 RID: 292
		private readonly Hashtable m_name2repositoryMap = new Hashtable();

		// Token: 0x04000125 RID: 293
		private readonly Type m_defaultRepositoryType;

		// Token: 0x04000127 RID: 295
		private static readonly Type declaringType = typeof(CompactRepositorySelector);
	}
}
