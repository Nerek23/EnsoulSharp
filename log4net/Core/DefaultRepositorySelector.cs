using System;
using System.Collections;
using System.IO;
using System.Reflection;
using log4net.Config;
using log4net.Plugin;
using log4net.Repository;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000A3 RID: 163
	public class DefaultRepositorySelector : IRepositorySelector
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600045B RID: 1115 RVA: 0x0000DF69 File Offset: 0x0000CF69
		// (remove) Token: 0x0600045C RID: 1116 RVA: 0x0000DF72 File Offset: 0x0000CF72
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

		// Token: 0x0600045D RID: 1117 RVA: 0x0000DF7C File Offset: 0x0000CF7C
		public DefaultRepositorySelector(Type defaultRepositoryType)
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
			Type source = DefaultRepositorySelector.declaringType;
			string str = "defaultRepositoryType [";
			Type defaultRepositoryType2 = this.m_defaultRepositoryType;
			LogLog.Debug(source, str + ((defaultRepositoryType2 != null) ? defaultRepositoryType2.ToString() : null) + "]");
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000E030 File Offset: 0x0000D030
		public ILoggerRepository GetRepository(Assembly repositoryAssembly)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			return this.CreateRepository(repositoryAssembly, this.m_defaultRepositoryType);
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000E054 File Offset: 0x0000D054
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

		// Token: 0x06000460 RID: 1120 RVA: 0x0000E0C4 File Offset: 0x0000D0C4
		public ILoggerRepository CreateRepository(Assembly repositoryAssembly, Type repositoryType)
		{
			return this.CreateRepository(repositoryAssembly, repositoryType, "log4net-default-repository", true);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000E0D4 File Offset: 0x0000D0D4
		public ILoggerRepository CreateRepository(Assembly repositoryAssembly, Type repositoryType, string repositoryName, bool readAssemblyAttributes)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			if (repositoryType == null)
			{
				repositoryType = this.m_defaultRepositoryType;
			}
			ILoggerRepository result;
			lock (this)
			{
				ILoggerRepository loggerRepository = this.m_assembly2repositoryMap[repositoryAssembly] as ILoggerRepository;
				if (loggerRepository == null)
				{
					LogLog.Debug(DefaultRepositorySelector.declaringType, "Creating repository for assembly [" + ((repositoryAssembly != null) ? repositoryAssembly.ToString() : null) + "]");
					string text = repositoryName;
					Type type = repositoryType;
					if (readAssemblyAttributes)
					{
						this.GetInfoForAssembly(repositoryAssembly, ref text, ref type);
					}
					Type source = DefaultRepositorySelector.declaringType;
					string[] array = new string[7];
					array[0] = "Assembly [";
					array[1] = ((repositoryAssembly != null) ? repositoryAssembly.ToString() : null);
					array[2] = "] using repository [";
					array[3] = text;
					array[4] = "] and repository type [";
					int num = 5;
					Type type2 = type;
					array[num] = ((type2 != null) ? type2.ToString() : null);
					array[6] = "]";
					LogLog.Debug(source, string.Concat(array));
					loggerRepository = (this.m_name2repositoryMap[text] as ILoggerRepository);
					if (loggerRepository == null)
					{
						loggerRepository = this.CreateRepository(text, type);
						if (!readAssemblyAttributes)
						{
							goto IL_1AD;
						}
						try
						{
							this.LoadAliases(repositoryAssembly, loggerRepository);
							this.LoadPlugins(repositoryAssembly, loggerRepository);
							this.ConfigureRepository(repositoryAssembly, loggerRepository);
							goto IL_1AD;
						}
						catch (Exception exception)
						{
							LogLog.Error(DefaultRepositorySelector.declaringType, "Failed to configure repository [" + text + "] from assembly attributes.", exception);
							goto IL_1AD;
						}
					}
					LogLog.Debug(DefaultRepositorySelector.declaringType, string.Concat(new string[]
					{
						"repository [",
						text,
						"] already exists, using repository type [",
						loggerRepository.GetType().FullName,
						"]"
					}));
					if (readAssemblyAttributes)
					{
						try
						{
							this.LoadPlugins(repositoryAssembly, loggerRepository);
						}
						catch (Exception exception2)
						{
							LogLog.Error(DefaultRepositorySelector.declaringType, "Failed to configure repository [" + text + "] from assembly attributes.", exception2);
						}
					}
					IL_1AD:
					this.m_assembly2repositoryMap[repositoryAssembly] = loggerRepository;
				}
				result = loggerRepository;
			}
			return result;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000E2F8 File Offset: 0x0000D2F8
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
				ILoggerRepository loggerRepository2 = this.m_alias2repositoryMap[repositoryName] as ILoggerRepository;
				if (loggerRepository2 != null)
				{
					if (loggerRepository2.GetType() == repositoryType)
					{
						LogLog.Debug(DefaultRepositorySelector.declaringType, string.Concat(new string[]
						{
							"Aliasing repository [",
							repositoryName,
							"] to existing repository [",
							loggerRepository2.Name,
							"]"
						}));
						loggerRepository = loggerRepository2;
						this.m_name2repositoryMap[repositoryName] = loggerRepository;
					}
					else
					{
						LogLog.Error(DefaultRepositorySelector.declaringType, string.Concat(new string[]
						{
							"Failed to alias repository [",
							repositoryName,
							"] to existing repository [",
							loggerRepository2.Name,
							"]. Requested repository type [",
							repositoryType.FullName,
							"] is not compatible with existing type [",
							loggerRepository2.GetType().FullName,
							"]"
						}));
					}
				}
				if (loggerRepository == null)
				{
					Type source = DefaultRepositorySelector.declaringType;
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
				}
				result = loggerRepository;
			}
			return result;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000E4C8 File Offset: 0x0000D4C8
		public bool ExistsRepository(string repositoryName)
		{
			bool result;
			lock (this)
			{
				result = this.m_name2repositoryMap.ContainsKey(repositoryName);
			}
			return result;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000E50C File Offset: 0x0000D50C
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

		// Token: 0x06000465 RID: 1125 RVA: 0x0000E564 File Offset: 0x0000D564
		public void AliasRepository(string repositoryAlias, ILoggerRepository repositoryTarget)
		{
			if (repositoryAlias == null)
			{
				throw new ArgumentNullException("repositoryAlias");
			}
			if (repositoryTarget == null)
			{
				throw new ArgumentNullException("repositoryTarget");
			}
			lock (this)
			{
				if (this.m_alias2repositoryMap.Contains(repositoryAlias))
				{
					if (repositoryTarget != (ILoggerRepository)this.m_alias2repositoryMap[repositoryAlias])
					{
						throw new InvalidOperationException(string.Concat(new string[]
						{
							"Repository [",
							repositoryAlias,
							"] is already aliased to repository [",
							((ILoggerRepository)this.m_alias2repositoryMap[repositoryAlias]).Name,
							"]. Aliases cannot be redefined."
						}));
					}
				}
				else if (this.m_name2repositoryMap.Contains(repositoryAlias))
				{
					if (repositoryTarget != (ILoggerRepository)this.m_name2repositoryMap[repositoryAlias])
					{
						throw new InvalidOperationException(string.Concat(new string[]
						{
							"Repository [",
							repositoryAlias,
							"] already exists and cannot be aliased to repository [",
							repositoryTarget.Name,
							"]."
						}));
					}
				}
				else
				{
					this.m_alias2repositoryMap[repositoryAlias] = repositoryTarget;
				}
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000E688 File Offset: 0x0000D688
		protected virtual void OnLoggerRepositoryCreatedEvent(ILoggerRepository repository)
		{
			LoggerRepositoryCreationEventHandler loggerRepositoryCreatedEvent = this.m_loggerRepositoryCreatedEvent;
			if (loggerRepositoryCreatedEvent != null)
			{
				loggerRepositoryCreatedEvent(this, new LoggerRepositoryCreationEventArgs(repository));
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000E6AC File Offset: 0x0000D6AC
		private void GetInfoForAssembly(Assembly assembly, ref string repositoryName, ref Type repositoryType)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			try
			{
				LogLog.Debug(DefaultRepositorySelector.declaringType, string.Concat(new string[]
				{
					"Assembly [",
					assembly.FullName,
					"] Loaded From [",
					SystemInfo.AssemblyLocationInfo(assembly),
					"]"
				}));
			}
			catch
			{
			}
			try
			{
				object[] customAttributes = Attribute.GetCustomAttributes(assembly, typeof(RepositoryAttribute), false);
				object[] array = customAttributes;
				if (array == null || array.Length == 0)
				{
					LogLog.Debug(DefaultRepositorySelector.declaringType, "Assembly [" + ((assembly != null) ? assembly.ToString() : null) + "] does not have a RepositoryAttribute specified.");
				}
				else
				{
					if (array.Length > 1)
					{
						LogLog.Error(DefaultRepositorySelector.declaringType, "Assembly [" + ((assembly != null) ? assembly.ToString() : null) + "] has multiple log4net.Config.RepositoryAttribute assembly attributes. Only using first occurrence.");
					}
					RepositoryAttribute repositoryAttribute = array[0] as RepositoryAttribute;
					if (repositoryAttribute == null)
					{
						LogLog.Error(DefaultRepositorySelector.declaringType, "Assembly [" + ((assembly != null) ? assembly.ToString() : null) + "] has a RepositoryAttribute but it does not!.");
					}
					else
					{
						if (repositoryAttribute.Name != null)
						{
							repositoryName = repositoryAttribute.Name;
						}
						if (repositoryAttribute.RepositoryType != null)
						{
							if (typeof(ILoggerRepository).IsAssignableFrom(repositoryAttribute.RepositoryType))
							{
								repositoryType = repositoryAttribute.RepositoryType;
							}
							else
							{
								Type source = DefaultRepositorySelector.declaringType;
								string str = "DefaultRepositorySelector: Repository Type [";
								Type repositoryType2 = repositoryAttribute.RepositoryType;
								LogLog.Error(source, str + ((repositoryType2 != null) ? repositoryType2.ToString() : null) + "] must implement the ILoggerRepository interface.");
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(DefaultRepositorySelector.declaringType, "Unhandled exception in GetInfoForAssembly", exception);
			}
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000E86C File Offset: 0x0000D86C
		private void ConfigureRepository(Assembly assembly, ILoggerRepository repository)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			object[] array = Attribute.GetCustomAttributes(assembly, typeof(ConfiguratorAttribute), false);
			object[] array2 = array;
			if (array2 != null && array2.Length != 0)
			{
				Array.Sort<object>(array2);
				foreach (ConfiguratorAttribute configuratorAttribute in array2)
				{
					if (configuratorAttribute != null)
					{
						try
						{
							configuratorAttribute.Configure(assembly, repository);
						}
						catch (Exception exception)
						{
							LogLog.Error(DefaultRepositorySelector.declaringType, "Exception calling [" + configuratorAttribute.GetType().FullName + "] .Configure method.", exception);
						}
					}
				}
			}
			if (repository.Name == "log4net-default-repository")
			{
				string appSetting = SystemInfo.GetAppSetting("log4net.Config");
				if (appSetting != null && appSetting.Length > 0)
				{
					string text = null;
					try
					{
						text = SystemInfo.ApplicationBaseDirectory;
					}
					catch (Exception exception2)
					{
						LogLog.Warn(DefaultRepositorySelector.declaringType, "Exception getting ApplicationBaseDirectory. appSettings log4net.Config path [" + appSetting + "] will be treated as an absolute URI", exception2);
					}
					string text2 = appSetting;
					if (text != null)
					{
						text2 = Path.Combine(text, appSetting);
					}
					bool flag = false;
					bool.TryParse(SystemInfo.GetAppSetting("log4net.Config.Watch"), out flag);
					if (flag)
					{
						FileInfo configFile = null;
						try
						{
							configFile = new FileInfo(text2);
						}
						catch (Exception exception3)
						{
							LogLog.Error(DefaultRepositorySelector.declaringType, "DefaultRepositorySelector: Exception while parsing log4net.Config file physical path [" + text2 + "]", exception3);
						}
						try
						{
							LogLog.Debug(DefaultRepositorySelector.declaringType, "Loading and watching configuration for default repository from AppSettings specified Config path [" + text2 + "]");
							XmlConfigurator.ConfigureAndWatch(repository, configFile);
							return;
						}
						catch (Exception exception4)
						{
							LogLog.Error(DefaultRepositorySelector.declaringType, "DefaultRepositorySelector: Exception calling XmlConfigurator.ConfigureAndWatch method with ConfigFilePath [" + text2 + "]", exception4);
							return;
						}
					}
					Uri uri = null;
					try
					{
						uri = new Uri(text2);
					}
					catch (Exception exception5)
					{
						LogLog.Error(DefaultRepositorySelector.declaringType, "Exception while parsing log4net.Config file path [" + appSetting + "]", exception5);
					}
					if (uri != null)
					{
						LogLog.Debug(DefaultRepositorySelector.declaringType, "Loading configuration for default repository from AppSettings specified Config URI [" + uri.ToString() + "]");
						try
						{
							XmlConfigurator.Configure(repository, uri);
						}
						catch (Exception exception6)
						{
							Type source = DefaultRepositorySelector.declaringType;
							string str = "Exception calling XmlConfigurator.Configure method with ConfigUri [";
							Uri uri2 = uri;
							LogLog.Error(source, str + ((uri2 != null) ? uri2.ToString() : null) + "]", exception6);
						}
					}
				}
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000EAF4 File Offset: 0x0000DAF4
		private void LoadPlugins(Assembly assembly, ILoggerRepository repository)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			object[] array = Attribute.GetCustomAttributes(assembly, typeof(PluginAttribute), false);
			object[] array2 = array;
			if (array2 != null && array2.Length != 0)
			{
				foreach (IPluginFactory pluginFactory in array2)
				{
					try
					{
						repository.PluginMap.Add(pluginFactory.CreatePlugin());
					}
					catch (Exception exception)
					{
						LogLog.Error(DefaultRepositorySelector.declaringType, "Failed to create plugin. Attribute [" + pluginFactory.ToString() + "]", exception);
					}
				}
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000EBA0 File Offset: 0x0000DBA0
		private void LoadAliases(Assembly assembly, ILoggerRepository repository)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			object[] array = Attribute.GetCustomAttributes(assembly, typeof(AliasRepositoryAttribute), false);
			object[] array2 = array;
			if (array2 != null && array2.Length != 0)
			{
				foreach (AliasRepositoryAttribute aliasRepositoryAttribute in array2)
				{
					try
					{
						this.AliasRepository(aliasRepositoryAttribute.Name, repository);
					}
					catch (Exception exception)
					{
						LogLog.Error(DefaultRepositorySelector.declaringType, "Failed to alias repository [" + aliasRepositoryAttribute.Name + "]", exception);
					}
				}
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600046B RID: 1131 RVA: 0x0000EC48 File Offset: 0x0000DC48
		// (remove) Token: 0x0600046C RID: 1132 RVA: 0x0000EC80 File Offset: 0x0000DC80
		private event LoggerRepositoryCreationEventHandler m_loggerRepositoryCreatedEvent;

		// Token: 0x04000128 RID: 296
		private static readonly Type declaringType = typeof(DefaultRepositorySelector);

		// Token: 0x04000129 RID: 297
		private const string DefaultRepositoryName = "log4net-default-repository";

		// Token: 0x0400012A RID: 298
		private readonly Hashtable m_name2repositoryMap = new Hashtable();

		// Token: 0x0400012B RID: 299
		private readonly Hashtable m_assembly2repositoryMap = new Hashtable();

		// Token: 0x0400012C RID: 300
		private readonly Hashtable m_alias2repositoryMap = new Hashtable();

		// Token: 0x0400012D RID: 301
		private readonly Type m_defaultRepositoryType;
	}
}
