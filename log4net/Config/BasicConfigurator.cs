using System;
using System.Collections;
using System.Reflection;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository;
using log4net.Util;

namespace log4net.Config
{
	// Token: 0x020000C5 RID: 197
	public sealed class BasicConfigurator
	{
		// Token: 0x0600058C RID: 1420 RVA: 0x00011B6F File Offset: 0x00010B6F
		private BasicConfigurator()
		{
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00011B77 File Offset: 0x00010B77
		public static ICollection Configure()
		{
			return BasicConfigurator.Configure(LogManager.GetRepository(Assembly.GetCallingAssembly()));
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00011B88 File Offset: 0x00010B88
		public static ICollection Configure(params IAppender[] appenders)
		{
			ArrayList arrayList = new ArrayList();
			ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				BasicConfigurator.InternalConfigure(repository, appenders);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00011BD8 File Offset: 0x00010BD8
		public static ICollection Configure(IAppender appender)
		{
			return BasicConfigurator.Configure(new IAppender[]
			{
				appender
			});
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00011BEC File Offset: 0x00010BEC
		public static ICollection Configure(ILoggerRepository repository)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				PatternLayout patternLayout = new PatternLayout();
				patternLayout.ConversionPattern = "%timestamp [%thread] %level %logger %ndc - %message%newline";
				patternLayout.ActivateOptions();
				ConsoleAppender consoleAppender = new ConsoleAppender();
				consoleAppender.Layout = patternLayout;
				consoleAppender.ActivateOptions();
				BasicConfigurator.InternalConfigure(repository, new IAppender[]
				{
					consoleAppender
				});
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00011C64 File Offset: 0x00010C64
		public static ICollection Configure(ILoggerRepository repository, IAppender appender)
		{
			return BasicConfigurator.Configure(repository, new IAppender[]
			{
				appender
			});
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00011C78 File Offset: 0x00010C78
		public static ICollection Configure(ILoggerRepository repository, params IAppender[] appenders)
		{
			ArrayList arrayList = new ArrayList();
			using (new LogLog.LogReceivedAdapter(arrayList))
			{
				BasicConfigurator.InternalConfigure(repository, appenders);
			}
			repository.ConfigurationMessages = arrayList;
			return arrayList;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00011CC0 File Offset: 0x00010CC0
		private static void InternalConfigure(ILoggerRepository repository, params IAppender[] appenders)
		{
			IBasicRepositoryConfigurator basicRepositoryConfigurator = repository as IBasicRepositoryConfigurator;
			if (basicRepositoryConfigurator != null)
			{
				basicRepositoryConfigurator.Configure(appenders);
				return;
			}
			LogLog.Warn(BasicConfigurator.declaringType, "BasicConfigurator: Repository [" + ((repository != null) ? repository.ToString() : null) + "] does not support the BasicConfigurator");
		}

		// Token: 0x040001A0 RID: 416
		private static readonly Type declaringType = typeof(BasicConfigurator);
	}
}
