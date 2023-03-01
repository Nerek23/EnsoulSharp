using System;
using log4net.Util;

namespace log4net.Layout
{
	// Token: 0x02000068 RID: 104
	public class DynamicPatternLayout : PatternLayout
	{
		// Token: 0x06000383 RID: 899 RVA: 0x0000B829 File Offset: 0x0000A829
		public DynamicPatternLayout()
		{
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000B851 File Offset: 0x0000A851
		public DynamicPatternLayout(string pattern) : base(pattern)
		{
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000B87A File Offset: 0x0000A87A
		// (set) Token: 0x06000386 RID: 902 RVA: 0x0000B887 File Offset: 0x0000A887
		public override string Header
		{
			get
			{
				return this.m_headerPatternString.Format();
			}
			set
			{
				base.Header = value;
				this.m_headerPatternString = new PatternString(value);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0000B89C File Offset: 0x0000A89C
		// (set) Token: 0x06000388 RID: 904 RVA: 0x0000B8A9 File Offset: 0x0000A8A9
		public override string Footer
		{
			get
			{
				return this.m_footerPatternString.Format();
			}
			set
			{
				base.Footer = value;
				this.m_footerPatternString = new PatternString(value);
			}
		}

		// Token: 0x040000D2 RID: 210
		private PatternString m_headerPatternString = new PatternString("");

		// Token: 0x040000D3 RID: 211
		private PatternString m_footerPatternString = new PatternString("");
	}
}
