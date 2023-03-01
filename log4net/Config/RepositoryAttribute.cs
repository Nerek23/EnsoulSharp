using System;

namespace log4net.Config
{
	// Token: 0x020000CC RID: 204
	[AttributeUsage(AttributeTargets.Assembly)]
	[Serializable]
	public class RepositoryAttribute : Attribute
	{
		// Token: 0x060005B0 RID: 1456 RVA: 0x00011F04 File Offset: 0x00010F04
		public RepositoryAttribute()
		{
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00011F0C File Offset: 0x00010F0C
		public RepositoryAttribute(string name)
		{
			this.m_name = name;
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00011F1B File Offset: 0x00010F1B
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00011F23 File Offset: 0x00010F23
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

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00011F2C File Offset: 0x00010F2C
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00011F34 File Offset: 0x00010F34
		public Type RepositoryType
		{
			get
			{
				return this.m_repositoryType;
			}
			set
			{
				this.m_repositoryType = value;
			}
		}

		// Token: 0x040001A4 RID: 420
		private string m_name;

		// Token: 0x040001A5 RID: 421
		private Type m_repositoryType;
	}
}
