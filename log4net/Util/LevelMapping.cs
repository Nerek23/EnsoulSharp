using System;
using System.Collections;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000014 RID: 20
	public sealed class LevelMapping : IOptionHandler
	{
		// Token: 0x060000EA RID: 234 RVA: 0x00003D68 File Offset: 0x00002D68
		public void Add(LevelMappingEntry entry)
		{
			if (this.m_entriesMap.ContainsKey(entry.Level))
			{
				this.m_entriesMap.Remove(entry.Level);
			}
			this.m_entriesMap.Add(entry.Level, entry);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003DA0 File Offset: 0x00002DA0
		public LevelMappingEntry Lookup(Level level)
		{
			if (this.m_entries != null)
			{
				foreach (LevelMappingEntry levelMappingEntry in this.m_entries)
				{
					if (level >= levelMappingEntry.Level)
					{
						return levelMappingEntry;
					}
				}
			}
			return null;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003DE0 File Offset: 0x00002DE0
		public void ActivateOptions()
		{
			Level[] array = new Level[this.m_entriesMap.Count];
			LevelMappingEntry[] array2 = new LevelMappingEntry[this.m_entriesMap.Count];
			this.m_entriesMap.Keys.CopyTo(array, 0);
			this.m_entriesMap.Values.CopyTo(array2, 0);
			Array.Sort<Level, LevelMappingEntry>(array, array2, 0, array.Length, null);
			Array.Reverse(array2, 0, array2.Length);
			LevelMappingEntry[] array3 = array2;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].ActivateOptions();
			}
			this.m_entries = array2;
		}

		// Token: 0x0400001D RID: 29
		private Hashtable m_entriesMap = new Hashtable();

		// Token: 0x0400001E RID: 30
		private LevelMappingEntry[] m_entries;
	}
}
