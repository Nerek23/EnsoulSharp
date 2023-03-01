using System;
using System.Collections;
using System.IO;
using System.Reflection;
using log4net.Repository;
using log4net.Util;

namespace log4net.Config
{
	// Token: 0x020000CF RID: 207
	[AttributeUsage(AttributeTargets.Assembly)]
	[Serializable]
	public class XmlConfiguratorAttribute : ConfiguratorAttribute
	{
		// Token: 0x060005CF RID: 1487 RVA: 0x000129FC File Offset: 0x000119FC
		public XmlConfiguratorAttribute() : base(0)
		{
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00012A05 File Offset: 0x00011A05
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x00012A0D File Offset: 0x00011A0D
		public string ConfigFile
		{
			get
			{
				return this.m_configFile;
			}
			set
			{
				this.m_configFile = value;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00012A16 File Offset: 0x00011A16
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00012A1E File Offset: 0x00011A1E
		public string ConfigFileExtension
		{
			get
			{
				return this.m_configFileExtension;
			}
			set
			{
				this.m_configFileExtension = value;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00012A27 File Offset: 0x00011A27
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00012A2F File Offset: 0x00011A2F
		public bool Watch
		{
			get
			{
				return this.m_configureAndWatch;
			}
			set
			{
				this.m_configureAndWatch = value;
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00012A38 File Offset: 0x00011A38
		public override void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
		{
			IList list = new ArrayList();
			using (new LogLog.LogReceivedAdapter(list))
			{
				string text = null;
				try
				{
					text = SystemInfo.ApplicationBaseDirectory;
				}
				catch
				{
				}
				if (text == null || new Uri(text).IsFile)
				{
					this.ConfigureFromFile(sourceAssembly, targetRepository);
				}
				else
				{
					this.ConfigureFromUri(sourceAssembly, targetRepository);
				}
			}
			targetRepository.ConfigurationMessages = list;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00012AB0 File Offset: 0x00011AB0
		private void ConfigureFromFile(Assembly sourceAssembly, ILoggerRepository targetRepository)
		{
			string text = null;
			if (this.m_configFile == null || this.m_configFile.Length == 0)
			{
				if (this.m_configFileExtension == null || this.m_configFileExtension.Length == 0)
				{
					try
					{
						text = SystemInfo.ConfigurationFileLocation;
						goto IL_FD;
					}
					catch (Exception exception)
					{
						LogLog.Error(XmlConfiguratorAttribute.declaringType, "XmlConfiguratorAttribute: Exception getting ConfigurationFileLocation. Must be able to resolve ConfigurationFileLocation when ConfigFile and ConfigFileExtension properties are not set.", exception);
						goto IL_FD;
					}
				}
				if (this.m_configFileExtension[0] != '.')
				{
					this.m_configFileExtension = "." + this.m_configFileExtension;
				}
				string text2 = null;
				try
				{
					text2 = SystemInfo.ApplicationBaseDirectory;
				}
				catch (Exception exception2)
				{
					LogLog.Error(XmlConfiguratorAttribute.declaringType, "Exception getting ApplicationBaseDirectory. Must be able to resolve ApplicationBaseDirectory and AssemblyFileName when ConfigFileExtension property is set.", exception2);
				}
				if (text2 != null)
				{
					text = Path.Combine(text2, SystemInfo.AssemblyFileName(sourceAssembly) + this.m_configFileExtension);
				}
			}
			else
			{
				string text3 = null;
				try
				{
					text3 = SystemInfo.ApplicationBaseDirectory;
				}
				catch (Exception exception3)
				{
					LogLog.Warn(XmlConfiguratorAttribute.declaringType, "Exception getting ApplicationBaseDirectory. ConfigFile property path [" + this.m_configFile + "] will be treated as an absolute path.", exception3);
				}
				if (text3 != null)
				{
					text = Path.Combine(text3, this.m_configFile);
				}
				else
				{
					text = this.m_configFile;
				}
			}
			IL_FD:
			if (text != null)
			{
				this.ConfigureFromFile(targetRepository, new FileInfo(text));
			}
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00012BF4 File Offset: 0x00011BF4
		private void ConfigureFromFile(ILoggerRepository targetRepository, FileInfo configFile)
		{
			if (this.m_configureAndWatch)
			{
				XmlConfigurator.ConfigureAndWatch(targetRepository, configFile);
				return;
			}
			XmlConfigurator.Configure(targetRepository, configFile);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00012C10 File Offset: 0x00011C10
		private void ConfigureFromUri(Assembly sourceAssembly, ILoggerRepository targetRepository)
		{
			Uri uri = null;
			if (this.m_configFile == null || this.m_configFile.Length == 0)
			{
				if (this.m_configFileExtension == null || this.m_configFileExtension.Length == 0)
				{
					string text = null;
					try
					{
						text = SystemInfo.ConfigurationFileLocation;
					}
					catch (Exception exception)
					{
						LogLog.Error(XmlConfiguratorAttribute.declaringType, "XmlConfiguratorAttribute: Exception getting ConfigurationFileLocation. Must be able to resolve ConfigurationFileLocation when ConfigFile and ConfigFileExtension properties are not set.", exception);
					}
					if (text != null)
					{
						uri = new Uri(text);
					}
				}
				else
				{
					if (this.m_configFileExtension[0] != '.')
					{
						this.m_configFileExtension = "." + this.m_configFileExtension;
					}
					string text2 = null;
					try
					{
						text2 = SystemInfo.ConfigurationFileLocation;
					}
					catch (Exception exception2)
					{
						LogLog.Error(XmlConfiguratorAttribute.declaringType, "XmlConfiguratorAttribute: Exception getting ConfigurationFileLocation. Must be able to resolve ConfigurationFileLocation when the ConfigFile property are not set.", exception2);
					}
					if (text2 != null)
					{
						UriBuilder uriBuilder = new UriBuilder(new Uri(text2));
						string text3 = uriBuilder.Path;
						int num = text3.LastIndexOf(".");
						if (num >= 0)
						{
							text3 = text3.Substring(0, num);
						}
						text3 += this.m_configFileExtension;
						uriBuilder.Path = text3;
						uri = uriBuilder.Uri;
					}
				}
			}
			else
			{
				string text4 = null;
				try
				{
					text4 = SystemInfo.ApplicationBaseDirectory;
				}
				catch (Exception exception3)
				{
					LogLog.Warn(XmlConfiguratorAttribute.declaringType, "Exception getting ApplicationBaseDirectory. ConfigFile property path [" + this.m_configFile + "] will be treated as an absolute URI.", exception3);
				}
				if (text4 != null)
				{
					uri = new Uri(new Uri(text4), this.m_configFile);
				}
				else
				{
					uri = new Uri(this.m_configFile);
				}
			}
			if (uri != null)
			{
				if (uri.IsFile)
				{
					this.ConfigureFromFile(targetRepository, new FileInfo(uri.LocalPath));
					return;
				}
				if (this.m_configureAndWatch)
				{
					LogLog.Warn(XmlConfiguratorAttribute.declaringType, "XmlConfiguratorAttribute: Unable to watch config file loaded from a URI");
				}
				XmlConfigurator.Configure(targetRepository, uri);
			}
		}

		// Token: 0x040001AA RID: 426
		private string m_configFile;

		// Token: 0x040001AB RID: 427
		private string m_configFileExtension;

		// Token: 0x040001AC RID: 428
		private bool m_configureAndWatch;

		// Token: 0x040001AD RID: 429
		private static readonly Type declaringType = typeof(XmlConfiguratorAttribute);
	}
}
