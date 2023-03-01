using System;
using System.Collections;
using log4net.Appender;
using log4net.Core;
using log4net.ObjectRenderer;
using log4net.Plugin;
using log4net.Util;

namespace log4net.Repository
{
	// Token: 0x02000052 RID: 82
	public interface ILoggerRepository
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000289 RID: 649
		// (set) Token: 0x0600028A RID: 650
		string Name { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600028B RID: 651
		RendererMap RendererMap { get; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600028C RID: 652
		PluginMap PluginMap { get; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600028D RID: 653
		LevelMap LevelMap { get; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600028E RID: 654
		// (set) Token: 0x0600028F RID: 655
		Level Threshold { get; set; }

		// Token: 0x06000290 RID: 656
		ILogger Exists(string name);

		// Token: 0x06000291 RID: 657
		ILogger[] GetCurrentLoggers();

		// Token: 0x06000292 RID: 658
		ILogger GetLogger(string name);

		// Token: 0x06000293 RID: 659
		void Shutdown();

		// Token: 0x06000294 RID: 660
		void ResetConfiguration();

		// Token: 0x06000295 RID: 661
		void Log(LoggingEvent logEvent);

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000296 RID: 662
		// (set) Token: 0x06000297 RID: 663
		bool Configured { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000298 RID: 664
		// (set) Token: 0x06000299 RID: 665
		ICollection ConfigurationMessages { get; set; }

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600029A RID: 666
		// (remove) Token: 0x0600029B RID: 667
		event LoggerRepositoryShutdownEventHandler ShutdownEvent;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600029C RID: 668
		// (remove) Token: 0x0600029D RID: 669
		event LoggerRepositoryConfigurationResetEventHandler ConfigurationReset;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600029E RID: 670
		// (remove) Token: 0x0600029F RID: 671
		event LoggerRepositoryConfigurationChangedEventHandler ConfigurationChanged;

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060002A0 RID: 672
		PropertiesDictionary Properties { get; }

		// Token: 0x060002A1 RID: 673
		IAppender[] GetAppenders();
	}
}
