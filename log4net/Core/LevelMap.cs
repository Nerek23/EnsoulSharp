using System;
using System.Collections;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000B3 RID: 179
	public sealed class LevelMap
	{
		// Token: 0x060004D8 RID: 1240 RVA: 0x0000F7E2 File Offset: 0x0000E7E2
		public void Clear()
		{
			this.m_mapName2Level.Clear();
		}

		// Token: 0x170000E0 RID: 224
		public Level this[string name]
		{
			get
			{
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				Level result;
				lock (this)
				{
					result = (Level)this.m_mapName2Level[name];
				}
				return result;
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0000F848 File Offset: 0x0000E848
		public void Add(string name, int value)
		{
			this.Add(name, value, null);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000F854 File Offset: 0x0000E854
		public void Add(string name, int value, string displayName)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw SystemInfo.CreateArgumentOutOfRangeException("name", name, "Parameter: name, Value: [" + name + "] out of range. Level name must not be empty");
			}
			if (displayName == null || displayName.Length == 0)
			{
				displayName = name;
			}
			this.Add(new Level(value, name, displayName));
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000F8B0 File Offset: 0x0000E8B0
		public void Add(Level level)
		{
			if (level == null)
			{
				throw new ArgumentNullException("level");
			}
			lock (this)
			{
				this.m_mapName2Level[level.Name] = level;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x0000F90C File Offset: 0x0000E90C
		public LevelCollection AllLevels
		{
			get
			{
				LevelCollection result;
				lock (this)
				{
					result = new LevelCollection(this.m_mapName2Level.Values);
				}
				return result;
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0000F954 File Offset: 0x0000E954
		public Level LookupWithDefault(Level defaultLevel)
		{
			if (defaultLevel == null)
			{
				throw new ArgumentNullException("defaultLevel");
			}
			Level result;
			lock (this)
			{
				Level level = (Level)this.m_mapName2Level[defaultLevel.Name];
				if (level == null)
				{
					this.m_mapName2Level[defaultLevel.Name] = defaultLevel;
					result = defaultLevel;
				}
				else
				{
					result = level;
				}
			}
			return result;
		}

		// Token: 0x04000154 RID: 340
		private Hashtable m_mapName2Level = SystemInfo.CreateCaseInsensitiveHashtable();
	}
}
