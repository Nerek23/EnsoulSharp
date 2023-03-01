using System;
using System.Collections;

namespace log4net.Util
{
	// Token: 0x0200000A RID: 10
	public sealed class CompositeProperties
	{
		// Token: 0x06000076 RID: 118 RVA: 0x0000278D File Offset: 0x0000178D
		internal CompositeProperties()
		{
		}

		// Token: 0x1700000D RID: 13
		public object this[string key]
		{
			get
			{
				if (this.m_flattened != null)
				{
					return this.m_flattened[key];
				}
				foreach (object obj in this.m_nestedProperties)
				{
					ReadOnlyPropertiesDictionary readOnlyPropertiesDictionary = (ReadOnlyPropertiesDictionary)obj;
					if (readOnlyPropertiesDictionary.Contains(key))
					{
						return readOnlyPropertiesDictionary[key];
					}
				}
				return null;
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002820 File Offset: 0x00001820
		public void Add(ReadOnlyPropertiesDictionary properties)
		{
			this.m_flattened = null;
			this.m_nestedProperties.Add(properties);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002838 File Offset: 0x00001838
		public PropertiesDictionary Flatten()
		{
			if (this.m_flattened == null)
			{
				this.m_flattened = new PropertiesDictionary();
				int num = this.m_nestedProperties.Count;
				while (--num >= 0)
				{
					foreach (object obj in ((IEnumerable)((ReadOnlyPropertiesDictionary)this.m_nestedProperties[num])))
					{
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						this.m_flattened[(string)dictionaryEntry.Key] = dictionaryEntry.Value;
					}
				}
			}
			return this.m_flattened;
		}

		// Token: 0x0400000A RID: 10
		private PropertiesDictionary m_flattened;

		// Token: 0x0400000B RID: 11
		private ArrayList m_nestedProperties = new ArrayList();
	}
}
