using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001B0 RID: 432
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	public class CustomEffectAttribute : Attribute
	{
		// Token: 0x0600084D RID: 2125 RVA: 0x0001825C File Offset: 0x0001645C
		public CustomEffectAttribute(string description, string category, string author)
		{
			this.description = description;
			this.category = category;
			this.author = author;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x00018279 File Offset: 0x00016479
		// (set) Token: 0x0600084F RID: 2127 RVA: 0x00018281 File Offset: 0x00016481
		public string DisplayName { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000850 RID: 2128 RVA: 0x0001828A File Offset: 0x0001648A
		public string Description
		{
			get
			{
				return this.description;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00018292 File Offset: 0x00016492
		public string Category
		{
			get
			{
				return this.category;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000852 RID: 2130 RVA: 0x0001829A File Offset: 0x0001649A
		public string Author
		{
			get
			{
				return this.author;
			}
		}

		// Token: 0x040005FC RID: 1532
		private string description;

		// Token: 0x040005FD RID: 1533
		private string category;

		// Token: 0x040005FE RID: 1534
		private string author;
	}
}
