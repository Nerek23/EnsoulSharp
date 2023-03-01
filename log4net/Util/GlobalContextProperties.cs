using System;

namespace log4net.Util
{
	// Token: 0x02000012 RID: 18
	public sealed class GlobalContextProperties : ContextPropertiesBase
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00002F83 File Offset: 0x00001F83
		internal GlobalContextProperties()
		{
		}

		// Token: 0x17000026 RID: 38
		public override object this[string key]
		{
			get
			{
				return this.m_readOnlyProperties[key];
			}
			set
			{
				object syncRoot = this.m_syncRoot;
				lock (syncRoot)
				{
					PropertiesDictionary propertiesDictionary = new PropertiesDictionary(this.m_readOnlyProperties);
					propertiesDictionary[key] = value;
					this.m_readOnlyProperties = new ReadOnlyPropertiesDictionary(propertiesDictionary);
				}
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003014 File Offset: 0x00002014
		public void Remove(string key)
		{
			object syncRoot = this.m_syncRoot;
			lock (syncRoot)
			{
				if (this.m_readOnlyProperties.Contains(key))
				{
					PropertiesDictionary propertiesDictionary = new PropertiesDictionary(this.m_readOnlyProperties);
					propertiesDictionary.Remove(key);
					this.m_readOnlyProperties = new ReadOnlyPropertiesDictionary(propertiesDictionary);
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003084 File Offset: 0x00002084
		public void Clear()
		{
			object syncRoot = this.m_syncRoot;
			lock (syncRoot)
			{
				this.m_readOnlyProperties = new ReadOnlyPropertiesDictionary();
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000030CC File Offset: 0x000020CC
		internal ReadOnlyPropertiesDictionary GetReadOnlyProperties()
		{
			return this.m_readOnlyProperties;
		}

		// Token: 0x0400001A RID: 26
		private volatile ReadOnlyPropertiesDictionary m_readOnlyProperties = new ReadOnlyPropertiesDictionary();

		// Token: 0x0400001B RID: 27
		private readonly object m_syncRoot = new object();
	}
}
