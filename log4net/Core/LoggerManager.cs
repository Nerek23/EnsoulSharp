using System;
using System.Reflection;
using System.Security;
using System.Text;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000B6 RID: 182
	public sealed class LoggerManager
	{
		// Token: 0x060004EC RID: 1260 RVA: 0x0000FCDF File Offset: 0x0000ECDF
		private LoggerManager()
		{
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000FCE8 File Offset: 0x0000ECE8
		static LoggerManager()
		{
			try
			{
				LoggerManager.RegisterAppDomainEvents();
			}
			catch (SecurityException)
			{
				LogLog.Debug(LoggerManager.declaringType, "Security Exception (ControlAppDomain LinkDemand) while trying to register Shutdown handler with the AppDomain. LoggerManager.Shutdown() will not be called automatically when the AppDomain exits. It must be called programmatically.");
			}
			LogLog.Debug(LoggerManager.declaringType, LoggerManager.GetVersionInfo());
			string appSetting = SystemInfo.GetAppSetting("log4net.RepositorySelector");
			if (appSetting != null && appSetting.Length > 0)
			{
				Type type = null;
				try
				{
					type = SystemInfo.GetTypeFromString(appSetting, false, true);
				}
				catch (Exception exception)
				{
					LogLog.Error(LoggerManager.declaringType, "Exception while resolving RepositorySelector Type [" + appSetting + "]", exception);
				}
				if (type != null)
				{
					object obj = null;
					try
					{
						obj = Activator.CreateInstance(type);
					}
					catch (Exception exception2)
					{
						LogLog.Error(LoggerManager.declaringType, "Exception while creating RepositorySelector [" + type.FullName + "]", exception2);
					}
					if (obj != null && obj is IRepositorySelector)
					{
						LoggerManager.s_repositorySelector = (IRepositorySelector)obj;
					}
					else
					{
						LogLog.Error(LoggerManager.declaringType, "RepositorySelector Type [" + type.FullName + "] is not an IRepositorySelector");
					}
				}
			}
			if (LoggerManager.s_repositorySelector == null)
			{
				LoggerManager.s_repositorySelector = new DefaultRepositorySelector(typeof(Hierarchy));
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000FE28 File Offset: 0x0000EE28
		private static void RegisterAppDomainEvents()
		{
			AppDomain.CurrentDomain.ProcessExit += LoggerManager.OnProcessExit;
			AppDomain.CurrentDomain.DomainUnload += LoggerManager.OnDomainUnload;
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000FE56 File Offset: 0x0000EE56
		[Obsolete("Use GetRepository instead of GetLoggerRepository")]
		public static ILoggerRepository GetLoggerRepository(string repository)
		{
			return LoggerManager.GetRepository(repository);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000FE5E File Offset: 0x0000EE5E
		[Obsolete("Use GetRepository instead of GetLoggerRepository")]
		public static ILoggerRepository GetLoggerRepository(Assembly repositoryAssembly)
		{
			return LoggerManager.GetRepository(repositoryAssembly);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0000FE66 File Offset: 0x0000EE66
		public static ILoggerRepository GetRepository(string repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			return LoggerManager.RepositorySelector.GetRepository(repository);
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000FE81 File Offset: 0x0000EE81
		public static ILoggerRepository GetRepository(Assembly repositoryAssembly)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			return LoggerManager.RepositorySelector.GetRepository(repositoryAssembly);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000FEA2 File Offset: 0x0000EEA2
		public static ILogger Exists(string repository, string name)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return LoggerManager.RepositorySelector.GetRepository(repository).Exists(name);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000FED1 File Offset: 0x0000EED1
		public static ILogger Exists(Assembly repositoryAssembly, string name)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return LoggerManager.RepositorySelector.GetRepository(repositoryAssembly).Exists(name);
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000FF06 File Offset: 0x0000EF06
		public static ILogger[] GetCurrentLoggers(string repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			return LoggerManager.RepositorySelector.GetRepository(repository).GetCurrentLoggers();
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000FF26 File Offset: 0x0000EF26
		public static ILogger[] GetCurrentLoggers(Assembly repositoryAssembly)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			return LoggerManager.RepositorySelector.GetRepository(repositoryAssembly).GetCurrentLoggers();
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000FF4C File Offset: 0x0000EF4C
		public static ILogger GetLogger(string repository, string name)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return LoggerManager.RepositorySelector.GetRepository(repository).GetLogger(name);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0000FF7B File Offset: 0x0000EF7B
		public static ILogger GetLogger(Assembly repositoryAssembly, string name)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return LoggerManager.RepositorySelector.GetRepository(repositoryAssembly).GetLogger(name);
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000FFB0 File Offset: 0x0000EFB0
		public static ILogger GetLogger(string repository, Type type)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return LoggerManager.RepositorySelector.GetRepository(repository).GetLogger(type.FullName);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000FFEA File Offset: 0x0000EFEA
		public static ILogger GetLogger(Assembly repositoryAssembly, Type type)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return LoggerManager.RepositorySelector.GetRepository(repositoryAssembly).GetLogger(type.FullName);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0001002C File Offset: 0x0000F02C
		public static void Shutdown()
		{
			ILoggerRepository[] allRepositories = LoggerManager.GetAllRepositories();
			for (int i = 0; i < allRepositories.Length; i++)
			{
				allRepositories[i].Shutdown();
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00010055 File Offset: 0x0000F055
		public static void ShutdownRepository(string repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			LoggerManager.RepositorySelector.GetRepository(repository).Shutdown();
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00010075 File Offset: 0x0000F075
		public static void ShutdownRepository(Assembly repositoryAssembly)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			LoggerManager.RepositorySelector.GetRepository(repositoryAssembly).Shutdown();
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0001009B File Offset: 0x0000F09B
		public static void ResetConfiguration(string repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			LoggerManager.RepositorySelector.GetRepository(repository).ResetConfiguration();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000100BB File Offset: 0x0000F0BB
		public static void ResetConfiguration(Assembly repositoryAssembly)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			LoggerManager.RepositorySelector.GetRepository(repositoryAssembly).ResetConfiguration();
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000100E1 File Offset: 0x0000F0E1
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(string repository)
		{
			return LoggerManager.CreateRepository(repository);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x000100E9 File Offset: 0x0000F0E9
		public static ILoggerRepository CreateRepository(string repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			return LoggerManager.RepositorySelector.CreateRepository(repository, null);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00010105 File Offset: 0x0000F105
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(string repository, Type repositoryType)
		{
			return LoggerManager.CreateRepository(repository, repositoryType);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001010E File Offset: 0x0000F10E
		public static ILoggerRepository CreateRepository(string repository, Type repositoryType)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			if (repositoryType == null)
			{
				throw new ArgumentNullException("repositoryType");
			}
			return LoggerManager.RepositorySelector.CreateRepository(repository, repositoryType);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0001013E File Offset: 0x0000F13E
		[Obsolete("Use CreateRepository instead of CreateDomain")]
		public static ILoggerRepository CreateDomain(Assembly repositoryAssembly, Type repositoryType)
		{
			return LoggerManager.CreateRepository(repositoryAssembly, repositoryType);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00010147 File Offset: 0x0000F147
		public static ILoggerRepository CreateRepository(Assembly repositoryAssembly, Type repositoryType)
		{
			if (repositoryAssembly == null)
			{
				throw new ArgumentNullException("repositoryAssembly");
			}
			if (repositoryType == null)
			{
				throw new ArgumentNullException("repositoryType");
			}
			return LoggerManager.RepositorySelector.CreateRepository(repositoryAssembly, repositoryType);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0001017D File Offset: 0x0000F17D
		public static ILoggerRepository[] GetAllRepositories()
		{
			return LoggerManager.RepositorySelector.GetAllRepositories();
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00010189 File Offset: 0x0000F189
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x00010190 File Offset: 0x0000F190
		public static IRepositorySelector RepositorySelector
		{
			get
			{
				return LoggerManager.s_repositorySelector;
			}
			set
			{
				LoggerManager.s_repositorySelector = value;
			}
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00010198 File Offset: 0x0000F198
		private static string GetVersionInfo()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			stringBuilder.Append("log4net assembly [").Append(executingAssembly.FullName).Append("]. ");
			stringBuilder.Append("Loaded from [").Append(SystemInfo.AssemblyLocationInfo(executingAssembly)).Append("]. ");
			stringBuilder.Append("(.NET Runtime [").Append(Environment.Version.ToString()).Append("]");
			stringBuilder.Append(" on ").Append(Environment.OSVersion.ToString());
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00010243 File Offset: 0x0000F243
		private static void OnDomainUnload(object sender, EventArgs e)
		{
			LoggerManager.Shutdown();
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0001024A File Offset: 0x0000F24A
		private static void OnProcessExit(object sender, EventArgs e)
		{
			LoggerManager.Shutdown();
		}

		// Token: 0x0400015D RID: 349
		private static readonly Type declaringType = typeof(LoggerManager);

		// Token: 0x0400015E RID: 350
		private static IRepositorySelector s_repositorySelector;
	}
}
