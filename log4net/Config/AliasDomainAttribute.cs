using System;

namespace log4net.Config
{
	// Token: 0x020000C3 RID: 195
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Obsolete("Use AliasRepositoryAttribute instead of AliasDomainAttribute")]
	[Serializable]
	public sealed class AliasDomainAttribute : AliasRepositoryAttribute
	{
		// Token: 0x06000588 RID: 1416 RVA: 0x00011B46 File Offset: 0x00010B46
		public AliasDomainAttribute(string name) : base(name)
		{
		}
	}
}
