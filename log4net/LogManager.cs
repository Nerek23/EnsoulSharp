using System;
using System.Reflection;
using log4net.Appender;
using log4net.Core;
using log4net.Repository;

namespace log4net
{
	// Token: 0x02000005 RID: 5
	public sealed class LogManager
	{
		// Token: 0x06000030 RID: 48 RVA: 0x000020B0 File Offset: 0x000010B0
		private LogManager()
		{
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000020B8 File Offset: 0x000010B8
		public static ILog Exists(string name)
		{
			return LogManager.Exists(Assembly.GetCallingAssembly(), name);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000020C5 File Offset: 0x000010C5
		public static ILog[] GetCurrentLoggers()
		{
			return LogManager.GetCurrentLoggers(Assembly.GetCallingAssembly());
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000020D1 File Offset: 0x000010D1
		public static ILog GetLogger(string name)
		{
			return LogManager.GetLogger(Assembly.GetCallingAssembly(), name);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000020DE File Offset: 0x000010DE
		public static ILog Exists(string repository, string name)
		{
			return LogManager.WrapLogger(LoggerManager.Exists(repository, name));
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000020EC File Offset: 0x000010EC
		public static ILog Exists(Assembly repositoryAssembly, string name)
		{
			return LogManager.WrapLogger(LoggerManager.Exists(repositoryAssembly, name));
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000020FA File Offset: 0x000010FA
		public static ILog[] GetCurrentLoggers(string repository)
		{
			return LogManager.WrapLoggers(LoggerManager.GetCurrentLoggers(repository));
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002107 File Offset: 0x00001107
		public static ILog[] GetCurrentLoggers(Assembly repositoryAssembly)
		{
			return LogManager.WrapLoggers(LoggerManager.GetCurrentLoggers(repositoryAssembly));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002114 File Offset: 0x00001114
		public static ILog GetLogger(string repository, string name)
		{
			return LogManager.WrapLogger(LoggerManager.GetLogger(repository, name));
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002122 File Offset: 0x00001122
		public static ILog GetLogger(Assembly repositoryAssembly, string name)
		{
			return LogManager.WrapLogger(LoggerManager.GetLogger(repositoryAssembly, name));
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002130 File Offset: 0x00001130
		public static ILog GetLogger(Type type)
		{
			return LogManager.GetLogger(Assembly.GetCallingAssembly(), type.FullName);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002142 File Offset: 0x00001142
		public static ILog GetLogger(string repository, Type type)
		{
			return LogManager.WrapLogger(LoggerManager.GetLogger(repository, type));
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002150 File Offset: 0x00001150
		public static ILog GetLogger(Assembly repositoryAssembly, Type type)
		{
			return LogManager.WrapLogger(LoggerManager.GetLogger(repositoryAssembly, type));
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000215E File Offset: 0x0000115E
		public static void Shutdown()
		{
			LoggerManager.Shutdown();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002165 File Offset: 0x00001165
		public static void ShutdownRepository()
		{
			LogManager.ShutdownRepository(Assembly.GetCallingAssembly());
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002171 File Offset: 0x00001171
		public static void ShutdownRepository(string repository)
		{
			LoggerManager.ShutdownRepository(repository);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002179 File Offset: 0x00001179
		public static void ShutdownRepository(Assembly repositoryAssembly)
		{
			LoggerManager.ShutdownRepository(repositoryAssembly);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002181 File Offset: 0x00001181
		public static void ResetConfiguration()
		{
			LogManager.ResetConfiguration(Assembly.GetCallingAssembly());
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000218D File Offset: 0x0000118D
		public static void ResetConfiguration(string repository)
		{
			LoggerManager.ResetConfiguration(repository);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002195 File Offset: 0x00001195
		public static void ResetConfiguration(Assembly repositoryAssembly)
		{
			LoggerManager.ResetConfiguration(repositoryAssembly);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000219D File Offset: 0x0000119D
		[Obsolete("Use GetRepository instead of GetLoggerRepository")]
		public static ILoggerRepository GetLoggerRepository()
		{
			return LogManager.GetRepository(Assembly.GetCallingAssembly());
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000021A9 File Offset: 0x000011A9
		[Obsolete("Use GetRepository instead of GetLoggerRepository")]
		public static ILoggerRepository GetLoggerRepository(string repository)
		{
			return LogManager.GetRepository(repository);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000021B1 File Offset: 0x000011B1
		[Obsolete("Use GetRepository instead of GetLoggerRepository")]
		public static ILoggerRepository GetLoggerRepository(Assembly repositoryAssembly)
		{
			return LogManager.GetRepository(repositoryAssembly);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000021B9 File Offset: 0x000011B9
		public static ILoggerRepository GetRepository()
		{
			return LogManager.GetRepository(Assembly.GetCallingAssembly());
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000021C5 File Offset: 0x000011C5
		public static ILoggerRepository GetRepository(string repository)
		{
			return LoggerManager.GetRepository(repository);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000021CD File Offset: 0x000011CD
		public static ILoggerRepository GetRepository(Assembly repositoryAssembly)
		{
			return LoggerManager.GetRepository(repositoryAssembly);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000021D5 File Offset: 0x000011D5
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(Type repositoryType)
		{
			return LogManager.CreateRepository(Assembly.GetCallingAssembly(), repositoryType);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000021E2 File Offset: 0x000011E2
		public static ILoggerRepository CreateRepository(Type repositoryType)
		{
			return LogManager.CreateRepository(Assembly.GetCallingAssembly(), repositoryType);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000021EF File Offset: 0x000011EF
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(string repository)
		{
			return LoggerManager.CreateRepository(repository);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000021F7 File Offset: 0x000011F7
		public static ILoggerRepository CreateRepository(string repository)
		{
			return LoggerManager.CreateRepository(repository);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000021FF File Offset: 0x000011FF
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(string repository, Type repositoryType)
		{
			return LoggerManager.CreateRepository(repository, repositoryType);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002208 File Offset: 0x00001208
		public static ILoggerRepository CreateRepository(string repository, Type repositoryType)
		{
			return LoggerManager.CreateRepository(repository, repositoryType);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002211 File Offset: 0x00001211
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(Assembly repositoryAssembly, Type repositoryType)
		{
			return LoggerManager.CreateRepository(repositoryAssembly, repositoryType);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000221A File Offset: 0x0000121A
		public static ILoggerRepository CreateRepository(Assembly repositoryAssembly, Type repositoryType)
		{
			return LoggerManager.CreateRepository(repositoryAssembly, repositoryType);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002223 File Offset: 0x00001223
		public static ILoggerRepository[] GetAllRepositories()
		{
			return LoggerManager.GetAllRepositories();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000222C File Offset: 0x0000122C
		public static bool Flush(int millisecondsTimeout)
		{
			IFlushable flushable = LoggerManager.GetRepository(Assembly.GetCallingAssembly()) as IFlushable;
			return flushable != null && flushable.Flush(millisecondsTimeout);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002255 File Offset: 0x00001255
		private static ILog WrapLogger(ILogger logger)
		{
			return (ILog)LogManager.s_wrapperMap.GetWrapper(logger);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002268 File Offset: 0x00001268
		private static ILog[] WrapLoggers(ILogger[] loggers)
		{
			ILog[] array = new ILog[loggers.Length];
			for (int i = 0; i < loggers.Length; i++)
			{
				array[i] = LogManager.WrapLogger(loggers[i]);
			}
			return array;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002298 File Offset: 0x00001298
		private static ILoggerWrapper WrapperCreationHandler(ILogger logger)
		{
			return new LogImpl(logger);
		}

		// Token: 0x04000004 RID: 4
		private static readonly WrapperMap s_wrapperMap = new WrapperMap(new WrapperCreationHandler(LogManager.WrapperCreationHandler));
	}
}
