using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Threading;
using System.Xml;
using log4net.Repository;
using log4net.Util;

namespace log4net.Config
{
	// Token: 0x020000CE RID: 206
	public sealed class XmlConfigurator
	{
		// Token: 0x060005BB RID: 1467 RVA: 0x0001200F File Offset: 0x0001100F
		private XmlConfigurator()
		{
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00012018 File Offset: 0x00011018
		public static ICollection Configure(ILoggerRepository repository)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(repository);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001205C File Offset: 0x0001105C
		private static void InternalConfigure(ILoggerRepository repository)
		{
			LogLog.Debug(XmlConfigurator.declaringType, "configuring repository [" + repository.Name + "] using .config file section");
			try
			{
				LogLog.Debug(XmlConfigurator.declaringType, "Application config file is [" + SystemInfo.ConfigurationFileLocation + "]");
			}
			catch
			{
				LogLog.Debug(XmlConfigurator.declaringType, "Application config file location unknown");
			}
			try
			{
				XmlElement xmlElement = ConfigurationManager.GetSection("log4net") as XmlElement;
				if (xmlElement == null)
				{
					LogLog.Error(XmlConfigurator.declaringType, "Failed to find configuration section 'log4net' in the application's .config file. Check your .config file for the <log4net> and <configSections> elements. The configuration section should look like: <section name=\"log4net\" type=\"log4net.Config.Log4NetConfigurationSectionHandler,log4net\" />");
				}
				else
				{
					XmlConfigurator.InternalConfigureFromXml(repository, xmlElement);
				}
			}
			catch (ConfigurationException ex)
			{
				if (ex.BareMessage.IndexOf("Unrecognized element") >= 0)
				{
					LogLog.Error(XmlConfigurator.declaringType, "Failed to parse config file. Check your .config file is well formed XML.", ex);
				}
				else
				{
					string str = "<section name=\"log4net\" type=\"log4net.Config.Log4NetConfigurationSectionHandler," + Assembly.GetExecutingAssembly().FullName + "\" />";
					LogLog.Error(XmlConfigurator.declaringType, "Failed to parse config file. Is the <configSections> specified as: " + str, ex);
				}
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001215C File Offset: 0x0001115C
		public static ICollection Configure()
		{
			return XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetCallingAssembly()));
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00012170 File Offset: 0x00011170
		public static ICollection Configure(XmlElement element)
		{
			ArrayList arrayList = new ArrayList();
			ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigureFromXml(repository, element);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x000121C0 File Offset: 0x000111C0
		public static ICollection Configure(FileInfo configFile)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(LogManager.GetRepository(Assembly.GetCallingAssembly()), configFile);
			}
			return arrayList;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00012208 File Offset: 0x00011208
		public static ICollection Configure(Uri configUri)
		{
			ArrayList arrayList = new ArrayList();
			ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(repository, configUri);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00012258 File Offset: 0x00011258
		public static ICollection Configure(Stream configStream)
		{
			ArrayList arrayList = new ArrayList();
			ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(repository, configStream);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x000122A8 File Offset: 0x000112A8
		public static ICollection Configure(ILoggerRepository repository, XmlElement element)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				LogLog.Debug(XmlConfigurator.declaringType, "configuring repository [" + repository.Name + "] using XML element");
				XmlConfigurator.InternalConfigureFromXml(repository, element);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0001230C File Offset: 0x0001130C
		public static ICollection Configure(ILoggerRepository repository, FileInfo configFile)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(repository, configFile);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00012354 File Offset: 0x00011354
		private static void InternalConfigure(ILoggerRepository repository, FileInfo configFile)
		{
			LogLog.Debug(XmlConfigurator.declaringType, string.Concat(new string[]
			{
				"configuring repository [",
				repository.Name,
				"] using file [",
				(configFile != null) ? configFile.ToString() : null,
				"]"
			}));
			if (configFile == null)
			{
				LogLog.Error(XmlConfigurator.declaringType, "Configure called with null 'configFile' parameter");
				return;
			}
			if (File.Exists(configFile.FullName))
			{
				FileStream fileStream = null;
				int num = 5;
				while (--num >= 0)
				{
					try
					{
						fileStream = configFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
						break;
					}
					catch (IOException exception)
					{
						if (num == 0)
						{
							LogLog.Error(XmlConfigurator.declaringType, "Failed to open XML config file [" + configFile.Name + "]", exception);
							fileStream = null;
						}
						Thread.Sleep(250);
					}
				}
				if (fileStream == null)
				{
					return;
				}
				try
				{
					XmlConfigurator.InternalConfigure(repository, fileStream);
					return;
				}
				finally
				{
					fileStream.Dispose();
				}
			}
			LogLog.Debug(XmlConfigurator.declaringType, "config file [" + configFile.FullName + "] not found. Configuration unchanged.");
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00012464 File Offset: 0x00011464
		public static ICollection Configure(ILoggerRepository repository, Uri configUri)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(repository, configUri);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x000124AC File Offset: 0x000114AC
		private static void InternalConfigure(ILoggerRepository repository, Uri configUri)
		{
			LogLog.Debug(XmlConfigurator.declaringType, string.Concat(new string[]
			{
				"configuring repository [",
				repository.Name,
				"] using URI [",
				(configUri != null) ? configUri.ToString() : null,
				"]"
			}));
			if (configUri == null)
			{
				LogLog.Error(XmlConfigurator.declaringType, "Configure called with null 'configUri' parameter");
				return;
			}
			if (configUri.IsFile)
			{
				XmlConfigurator.InternalConfigure(repository, new FileInfo(configUri.LocalPath));
				return;
			}
			WebRequest webRequest = null;
			try
			{
				webRequest = WebRequest.Create(configUri);
			}
			catch (Exception exception)
			{
				LogLog.Error(XmlConfigurator.declaringType, "Failed to create WebRequest for URI [" + ((configUri != null) ? configUri.ToString() : null) + "]", exception);
			}
			if (webRequest != null)
			{
				try
				{
					webRequest.Credentials = CredentialCache.DefaultCredentials;
				}
				catch
				{
				}
				try
				{
					using (WebResponse response = webRequest.GetResponse())
					{
						if (response != null)
						{
							using (Stream responseStream = response.GetResponseStream())
							{
								XmlConfigurator.InternalConfigure(repository, responseStream);
							}
						}
					}
				}
				catch (Exception exception2)
				{
					LogLog.Error(XmlConfigurator.declaringType, "Failed to request config from URI [" + ((configUri != null) ? configUri.ToString() : null) + "]", exception2);
				}
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001261C File Offset: 0x0001161C
		public static ICollection Configure(ILoggerRepository repository, Stream configStream)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigure(repository, configStream);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00012664 File Offset: 0x00011664
		private static void InternalConfigure(ILoggerRepository repository, Stream configStream)
		{
			LogLog.Debug(XmlConfigurator.declaringType, "configuring repository [" + repository.Name + "] using stream");
			if (configStream == null)
			{
				LogLog.Error(XmlConfigurator.declaringType, "Configure called with null 'configStream' parameter");
				return;
			}
			XmlDocument xmlDocument = new XmlDocument
			{
				XmlResolver = null
			};
			try
			{
				using (XmlReader xmlReader = XmlReader.Create(configStream, new XmlReaderSettings
				{
					DtdProcessing = DtdProcessing.Ignore
				}))
				{
					xmlDocument.Load(xmlReader);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(XmlConfigurator.declaringType, "Error while loading XML configuration", exception);
				xmlDocument = null;
			}
			if (xmlDocument != null)
			{
				LogLog.Debug(XmlConfigurator.declaringType, "loading XML configuration");
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("log4net");
				if (elementsByTagName.Count == 0)
				{
					LogLog.Debug(XmlConfigurator.declaringType, "XML configuration does not contain a <log4net> element. Configuration Aborted.");
					return;
				}
				if (elementsByTagName.Count > 1)
				{
					LogLog.Error(XmlConfigurator.declaringType, "XML configuration contains [" + elementsByTagName.Count.ToString() + "] <log4net> elements. Only one is allowed. Configuration Aborted.");
					return;
				}
				XmlConfigurator.InternalConfigureFromXml(repository, elementsByTagName[0] as XmlElement);
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001278C File Offset: 0x0001178C
		public static ICollection ConfigureAndWatch(FileInfo configFile)
		{
			ArrayList arrayList = new ArrayList();
			ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigureAndWatch(repository, configFile);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x000127DC File Offset: 0x000117DC
		public static ICollection ConfigureAndWatch(ILoggerRepository repository, FileInfo configFile)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				XmlConfigurator.InternalConfigureAndWatch(repository, configFile);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00012824 File Offset: 0x00011824
		private static void InternalConfigureAndWatch(ILoggerRepository repository, FileInfo configFile)
		{
			LogLog.Debug(XmlConfigurator.declaringType, string.Concat(new string[]
			{
				"configuring repository [",
				repository.Name,
				"] using file [",
				(configFile != null) ? configFile.ToString() : null,
				"] watching for file updates"
			}));
			if (configFile == null)
			{
				LogLog.Error(XmlConfigurator.declaringType, "ConfigureAndWatch called with null 'configFile' parameter");
				return;
			}
			XmlConfigurator.InternalConfigure(repository, configFile);
			try
			{
				Hashtable repositoryName2ConfigAndWatchHandler = XmlConfigurator.m_repositoryName2ConfigAndWatchHandler;
				lock (repositoryName2ConfigAndWatchHandler)
				{
					XmlConfigurator.ConfigureAndWatchHandler configureAndWatchHandler = (XmlConfigurator.ConfigureAndWatchHandler)XmlConfigurator.m_repositoryName2ConfigAndWatchHandler[configFile.FullName];
					if (configureAndWatchHandler != null)
					{
						XmlConfigurator.m_repositoryName2ConfigAndWatchHandler.Remove(configFile.FullName);
						configureAndWatchHandler.Dispose();
					}
					configureAndWatchHandler = new XmlConfigurator.ConfigureAndWatchHandler(repository, configFile);
					XmlConfigurator.m_repositoryName2ConfigAndWatchHandler[configFile.FullName] = configureAndWatchHandler;
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(XmlConfigurator.declaringType, "Failed to initialize configuration file watcher for file [" + configFile.FullName + "]", exception);
			}
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00012938 File Offset: 0x00011938
		private static void InternalConfigureFromXml(ILoggerRepository repository, XmlElement element)
		{
			if (element == null)
			{
				LogLog.Error(XmlConfigurator.declaringType, "ConfigureFromXml called with null 'element' parameter");
				return;
			}
			if (repository == null)
			{
				LogLog.Error(XmlConfigurator.declaringType, "ConfigureFromXml called with null 'repository' parameter");
				return;
			}
			LogLog.Debug(XmlConfigurator.declaringType, "Configuring Repository [" + repository.Name + "]");
			IXmlRepositoryConfigurator xmlRepositoryConfigurator = repository as IXmlRepositoryConfigurator;
			if (xmlRepositoryConfigurator == null)
			{
				LogLog.Warn(XmlConfigurator.declaringType, "Repository [" + ((repository != null) ? repository.ToString() : null) + "] does not support the XmlConfigurator");
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.XmlResolver = null;
			XmlElement element2 = (XmlElement)xmlDocument.AppendChild(xmlDocument.ImportNode(element, true));
			xmlRepositoryConfigurator.Configure(element2);
		}

		// Token: 0x040001A8 RID: 424
		private static readonly Hashtable m_repositoryName2ConfigAndWatchHandler = new Hashtable();

		// Token: 0x040001A9 RID: 425
		private static readonly Type declaringType = typeof(XmlConfigurator);

		// Token: 0x02000104 RID: 260
		private sealed class ConfigureAndWatchHandler : IDisposable
		{
			// Token: 0x0600081F RID: 2079 RVA: 0x000191C0 File Offset: 0x000181C0
			[SecuritySafeCritical]
			public ConfigureAndWatchHandler(ILoggerRepository repository, FileInfo configFile)
			{
				this.m_repository = repository;
				this.m_configFile = configFile;
				this.m_watcher = new FileSystemWatcher();
				this.m_watcher.Path = this.m_configFile.DirectoryName;
				this.m_watcher.Filter = this.m_configFile.Name;
				this.m_watcher.NotifyFilter = (NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime);
				this.m_watcher.Changed += this.ConfigureAndWatchHandler_OnChanged;
				this.m_watcher.Created += this.ConfigureAndWatchHandler_OnChanged;
				this.m_watcher.Deleted += this.ConfigureAndWatchHandler_OnChanged;
				this.m_watcher.Renamed += this.ConfigureAndWatchHandler_OnRenamed;
				this.m_watcher.EnableRaisingEvents = true;
				this.m_timer = new Timer(new TimerCallback(this.OnWatchedFileChange), null, -1, -1);
			}

			// Token: 0x06000820 RID: 2080 RVA: 0x000192A8 File Offset: 0x000182A8
			private void ConfigureAndWatchHandler_OnChanged(object source, FileSystemEventArgs e)
			{
				LogLog.Debug(XmlConfigurator.declaringType, string.Concat(new string[]
				{
					"ConfigureAndWatchHandler: ",
					e.ChangeType.ToString(),
					" [",
					this.m_configFile.FullName,
					"]"
				}));
				this.m_timer.Change(500, -1);
			}

			// Token: 0x06000821 RID: 2081 RVA: 0x0001931C File Offset: 0x0001831C
			private void ConfigureAndWatchHandler_OnRenamed(object source, RenamedEventArgs e)
			{
				LogLog.Debug(XmlConfigurator.declaringType, string.Concat(new string[]
				{
					"ConfigureAndWatchHandler: ",
					e.ChangeType.ToString(),
					" [",
					this.m_configFile.FullName,
					"]"
				}));
				this.m_timer.Change(500, -1);
			}

			// Token: 0x06000822 RID: 2082 RVA: 0x0001938D File Offset: 0x0001838D
			private void OnWatchedFileChange(object state)
			{
				XmlConfigurator.InternalConfigure(this.m_repository, this.m_configFile);
			}

			// Token: 0x06000823 RID: 2083 RVA: 0x000193A0 File Offset: 0x000183A0
			[SecuritySafeCritical]
			public void Dispose()
			{
				this.m_watcher.EnableRaisingEvents = false;
				this.m_watcher.Dispose();
				this.m_timer.Dispose();
			}

			// Token: 0x04000275 RID: 629
			private FileInfo m_configFile;

			// Token: 0x04000276 RID: 630
			private ILoggerRepository m_repository;

			// Token: 0x04000277 RID: 631
			private Timer m_timer;

			// Token: 0x04000278 RID: 632
			private const int TimeoutMillis = 500;

			// Token: 0x04000279 RID: 633
			private FileSystemWatcher m_watcher;
		}
	}
}
