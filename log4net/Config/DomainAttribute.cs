using System;

namespace log4net.Config
{
	// Token: 0x020000C7 RID: 199
	[AttributeUsage(AttributeTargets.Assembly)]
	[Obsolete("Use RepositoryAttribute instead of DomainAttribute")]
	[Serializable]
	public sealed class DomainAttribute : RepositoryAttribute
	{
		// Token: 0x06000598 RID: 1432 RVA: 0x00011D5F File Offset: 0x00010D5F
		public DomainAttribute()
		{
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00011D67 File Offset: 0x00010D67
		public DomainAttribute(string name) : base(name)
		{
		}
	}
}
