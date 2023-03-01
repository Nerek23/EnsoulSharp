using System;

namespace log4net.Config
{
	// Token: 0x020000C4 RID: 196
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Serializable]
	public class AliasRepositoryAttribute : Attribute
	{
		// Token: 0x06000589 RID: 1417 RVA: 0x00011B4F File Offset: 0x00010B4F
		public AliasRepositoryAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00011B5E File Offset: 0x00010B5E
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x00011B66 File Offset: 0x00010B66
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

		// Token: 0x0400019F RID: 415
		private string m_name;
	}
}
