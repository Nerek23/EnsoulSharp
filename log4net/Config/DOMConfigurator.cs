using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net.Repository;

namespace log4net.Config
{
	// Token: 0x020000C8 RID: 200
	[Obsolete("Use XmlConfigurator instead of DOMConfigurator")]
	public sealed class DOMConfigurator
	{
		// Token: 0x0600059A RID: 1434 RVA: 0x00011D70 File Offset: 0x00010D70
		private DOMConfigurator()
		{
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00011D78 File Offset: 0x00010D78
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure()
		{
			XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetCallingAssembly()));
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00011D8A File Offset: 0x00010D8A
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(ILoggerRepository repository)
		{
			XmlConfigurator.Configure(repository);
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00011D93 File Offset: 0x00010D93
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(XmlElement element)
		{
			XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetCallingAssembly()), element);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00011DA6 File Offset: 0x00010DA6
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(ILoggerRepository repository, XmlElement element)
		{
			XmlConfigurator.Configure(repository, element);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00011DB0 File Offset: 0x00010DB0
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(FileInfo configFile)
		{
			XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetCallingAssembly()), configFile);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00011DC3 File Offset: 0x00010DC3
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(Stream configStream)
		{
			XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetCallingAssembly()), configStream);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00011DD6 File Offset: 0x00010DD6
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(ILoggerRepository repository, FileInfo configFile)
		{
			XmlConfigurator.Configure(repository, configFile);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00011DE0 File Offset: 0x00010DE0
		[Obsolete("Use XmlConfigurator.Configure instead of DOMConfigurator.Configure")]
		public static void Configure(ILoggerRepository repository, Stream configStream)
		{
			XmlConfigurator.Configure(repository, configStream);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00011DEA File Offset: 0x00010DEA
		[Obsolete("Use XmlConfigurator.ConfigureAndWatch instead of DOMConfigurator.ConfigureAndWatch")]
		public static void ConfigureAndWatch(FileInfo configFile)
		{
			XmlConfigurator.ConfigureAndWatch(LogManager.GetRepository(Assembly.GetCallingAssembly()), configFile);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x00011DFD File Offset: 0x00010DFD
		[Obsolete("Use XmlConfigurator.ConfigureAndWatch instead of DOMConfigurator.ConfigureAndWatch")]
		public static void ConfigureAndWatch(ILoggerRepository repository, FileInfo configFile)
		{
			XmlConfigurator.ConfigureAndWatch(repository, configFile);
		}
	}
}
