using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Reflection;
using System.Threading;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.MenuUI;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000022 RID: 34
	public class Bootstrap
	{
		// Token: 0x06000189 RID: 393 RVA: 0x00009EC4 File Offset: 0x000080C4
		public static void Init(byte[] data)
		{
			if (Bootstrap.initialized)
			{
				return;
			}
			Bootstrap.initialized = true;
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
			CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Config.SandboxConfig = new BootstrapConfig().Deserialize(data);
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			CompositionContainer container = new CompositionContainer(new AssemblyCatalog(executingAssembly), Array.Empty<ExportProvider>());
			Library.GameEvent = Bootstrap.Export<GameEvent>(container, new GameEvent());
			GameEvent.AlwaysLoadActions.Add(delegate
			{
				Library.GameObjects = Bootstrap.Export<GameObjects>(container, new GameObjects());
				Library.GameCache = Bootstrap.Export<GameCache>(container, new GameCache());
				Library.DamageData = Bootstrap.Export<DamageData>(container, new DamageData());
				Library.MenuWrapper = Bootstrap.Export<MenuWrapper>(container, new MenuWrapper());
				Library.DamageData.SortSpells();
			});
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00009F6E File Offset: 0x0000816E
		private static T Export<T>(CompositionContainer container, T value)
		{
			container.SatisfyImportsOnce(value);
			container.ComposeExportedValue(value);
			return value;
		}

		// Token: 0x040000B1 RID: 177
		private static bool initialized;
	}
}
