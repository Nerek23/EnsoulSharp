using System;

namespace log4net.Core
{
	// Token: 0x020000B0 RID: 176
	[Serializable]
	public sealed class Level : IComparable
	{
		// Token: 0x06000495 RID: 1173 RVA: 0x0000EDAF File Offset: 0x0000DDAF
		public Level(int level, string levelName, string displayName)
		{
			if (levelName == null)
			{
				throw new ArgumentNullException("levelName");
			}
			if (displayName == null)
			{
				throw new ArgumentNullException("displayName");
			}
			this.m_levelValue = level;
			this.m_levelName = string.Intern(levelName);
			this.m_levelDisplayName = displayName;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000EDED File Offset: 0x0000DDED
		public Level(int level, string levelName) : this(level, levelName, levelName)
		{
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000EDF8 File Offset: 0x0000DDF8
		public string Name
		{
			get
			{
				return this.m_levelName;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000EE00 File Offset: 0x0000DE00
		public int Value
		{
			get
			{
				return this.m_levelValue;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000EE08 File Offset: 0x0000DE08
		public string DisplayName
		{
			get
			{
				return this.m_levelDisplayName;
			}
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000EE10 File Offset: 0x0000DE10
		public override string ToString()
		{
			return this.m_levelName;
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0000EE18 File Offset: 0x0000DE18
		public override bool Equals(object o)
		{
			Level level = o as Level;
			if (level != null)
			{
				return this.m_levelValue == level.m_levelValue;
			}
			return base.Equals(o);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000EE4B File Offset: 0x0000DE4B
		public override int GetHashCode()
		{
			return this.m_levelValue;
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000EE54 File Offset: 0x0000DE54
		public int CompareTo(object r)
		{
			Level level = r as Level;
			if (level != null)
			{
				return Level.Compare(this, level);
			}
			throw new ArgumentException("Parameter: r, Value: [" + ((r != null) ? r.ToString() : null) + "] is not an instance of Level");
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000EE99 File Offset: 0x0000DE99
		public static bool operator >(Level l, Level r)
		{
			return l.m_levelValue > r.m_levelValue;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000EEA9 File Offset: 0x0000DEA9
		public static bool operator <(Level l, Level r)
		{
			return l.m_levelValue < r.m_levelValue;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0000EEB9 File Offset: 0x0000DEB9
		public static bool operator >=(Level l, Level r)
		{
			return l.m_levelValue >= r.m_levelValue;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0000EECC File Offset: 0x0000DECC
		public static bool operator <=(Level l, Level r)
		{
			return l.m_levelValue <= r.m_levelValue;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0000EEDF File Offset: 0x0000DEDF
		public static bool operator ==(Level l, Level r)
		{
			if (l != null && r != null)
			{
				return l.m_levelValue == r.m_levelValue;
			}
			return l == r;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0000EEFA File Offset: 0x0000DEFA
		public static bool operator !=(Level l, Level r)
		{
			return !(l == r);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000EF08 File Offset: 0x0000DF08
		public static int Compare(Level l, Level r)
		{
			if (l == r)
			{
				return 0;
			}
			if (l == null && r == null)
			{
				return 0;
			}
			if (l == null)
			{
				return -1;
			}
			if (r == null)
			{
				return 1;
			}
			return l.m_levelValue.CompareTo(r.m_levelValue);
		}

		// Token: 0x0400013A RID: 314
		public static readonly Level Off = new Level(int.MaxValue, "OFF");

		// Token: 0x0400013B RID: 315
		public static readonly Level Log4Net_Debug = new Level(120000, "log4net:DEBUG");

		// Token: 0x0400013C RID: 316
		public static readonly Level Emergency = new Level(120000, "EMERGENCY");

		// Token: 0x0400013D RID: 317
		public static readonly Level Fatal = new Level(110000, "FATAL");

		// Token: 0x0400013E RID: 318
		public static readonly Level Alert = new Level(100000, "ALERT");

		// Token: 0x0400013F RID: 319
		public static readonly Level Critical = new Level(90000, "CRITICAL");

		// Token: 0x04000140 RID: 320
		public static readonly Level Severe = new Level(80000, "SEVERE");

		// Token: 0x04000141 RID: 321
		public static readonly Level Error = new Level(70000, "ERROR");

		// Token: 0x04000142 RID: 322
		public static readonly Level Warn = new Level(60000, "WARN");

		// Token: 0x04000143 RID: 323
		public static readonly Level Notice = new Level(50000, "NOTICE");

		// Token: 0x04000144 RID: 324
		public static readonly Level Info = new Level(40000, "INFO");

		// Token: 0x04000145 RID: 325
		public static readonly Level Debug = new Level(30000, "DEBUG");

		// Token: 0x04000146 RID: 326
		public static readonly Level Fine = new Level(30000, "FINE");

		// Token: 0x04000147 RID: 327
		public static readonly Level Trace = new Level(20000, "TRACE");

		// Token: 0x04000148 RID: 328
		public static readonly Level Finer = new Level(20000, "FINER");

		// Token: 0x04000149 RID: 329
		public static readonly Level Verbose = new Level(10000, "VERBOSE");

		// Token: 0x0400014A RID: 330
		public static readonly Level Finest = new Level(10000, "FINEST");

		// Token: 0x0400014B RID: 331
		public static readonly Level All = new Level(int.MinValue, "ALL");

		// Token: 0x0400014C RID: 332
		private readonly int m_levelValue;

		// Token: 0x0400014D RID: 333
		private readonly string m_levelName;

		// Token: 0x0400014E RID: 334
		private readonly string m_levelDisplayName;
	}
}
