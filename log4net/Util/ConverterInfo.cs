using System;

namespace log4net.Util
{
	// Token: 0x0200000C RID: 12
	public sealed class ConverterInfo
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000028FF File Offset: 0x000018FF
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002907 File Offset: 0x00001907
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002910 File Offset: 0x00001910
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00002918 File Offset: 0x00001918
		public Type Type
		{
			get
			{
				return this.m_type;
			}
			set
			{
				this.m_type = value;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002921 File Offset: 0x00001921
		public void AddProperty(PropertyEntry entry)
		{
			this.properties[entry.Key] = entry.Value;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000293A File Offset: 0x0000193A
		public PropertiesDictionary Properties
		{
			get
			{
				return this.properties;
			}
		}

		// Token: 0x0400000C RID: 12
		private string m_name;

		// Token: 0x0400000D RID: 13
		private Type m_type;

		// Token: 0x0400000E RID: 14
		private readonly PropertiesDictionary properties = new PropertiesDictionary();
	}
}
