using System;

namespace SharpDX
{
	// Token: 0x02000032 RID: 50
	[AttributeUsage(AttributeTargets.All)]
	public class TagAttribute : Attribute
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00005123 File Offset: 0x00003323
		// (set) Token: 0x06000186 RID: 390 RVA: 0x0000512B File Offset: 0x0000332B
		public string Value { get; private set; }

		// Token: 0x06000187 RID: 391 RVA: 0x00005134 File Offset: 0x00003334
		public TagAttribute(string value)
		{
			this.Value = value;
		}
	}
}
