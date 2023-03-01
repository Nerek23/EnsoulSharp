using System;
using System.Collections;
using log4net.Repository;

namespace log4net.Plugin
{
	// Token: 0x02000062 RID: 98
	public sealed class PluginMap
	{
		// Token: 0x06000360 RID: 864 RVA: 0x0000B0F1 File Offset: 0x0000A0F1
		public PluginMap(ILoggerRepository repository)
		{
			this.m_repository = repository;
		}

		// Token: 0x170000A6 RID: 166
		public IPlugin this[string name]
		{
			get
			{
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				IPlugin result;
				lock (this)
				{
					result = (IPlugin)this.m_mapName2Plugin[name];
				}
				return result;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0000B164 File Offset: 0x0000A164
		public PluginCollection AllPlugins
		{
			get
			{
				PluginCollection result;
				lock (this)
				{
					result = new PluginCollection(this.m_mapName2Plugin.Values);
				}
				return result;
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000B1AC File Offset: 0x0000A1AC
		public void Add(IPlugin plugin)
		{
			if (plugin == null)
			{
				throw new ArgumentNullException("plugin");
			}
			IPlugin plugin2 = null;
			lock (this)
			{
				plugin2 = (this.m_mapName2Plugin[plugin.Name] as IPlugin);
				this.m_mapName2Plugin[plugin.Name] = plugin;
			}
			if (plugin2 != null)
			{
				plugin2.Shutdown();
			}
			plugin.Attach(this.m_repository);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000B230 File Offset: 0x0000A230
		public void Remove(IPlugin plugin)
		{
			if (plugin == null)
			{
				throw new ArgumentNullException("plugin");
			}
			lock (this)
			{
				this.m_mapName2Plugin.Remove(plugin.Name);
			}
		}

		// Token: 0x040000C7 RID: 199
		private readonly Hashtable m_mapName2Plugin = new Hashtable();

		// Token: 0x040000C8 RID: 200
		private readonly ILoggerRepository m_repository;
	}
}
