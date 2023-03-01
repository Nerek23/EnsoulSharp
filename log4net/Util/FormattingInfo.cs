using System;

namespace log4net.Util
{
	// Token: 0x02000011 RID: 17
	public class FormattingInfo
	{
		// Token: 0x060000AD RID: 173 RVA: 0x00002F07 File Offset: 0x00001F07
		public FormattingInfo()
		{
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002F21 File Offset: 0x00001F21
		public FormattingInfo(int min, int max, bool leftAlign)
		{
			this.m_min = min;
			this.m_max = max;
			this.m_leftAlign = leftAlign;
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00002F50 File Offset: 0x00001F50
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00002F58 File Offset: 0x00001F58
		public int Min
		{
			get
			{
				return this.m_min;
			}
			set
			{
				this.m_min = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00002F61 File Offset: 0x00001F61
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00002F69 File Offset: 0x00001F69
		public int Max
		{
			get
			{
				return this.m_max;
			}
			set
			{
				this.m_max = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00002F72 File Offset: 0x00001F72
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00002F7A File Offset: 0x00001F7A
		public bool LeftAlign
		{
			get
			{
				return this.m_leftAlign;
			}
			set
			{
				this.m_leftAlign = value;
			}
		}

		// Token: 0x04000017 RID: 23
		private int m_min = -1;

		// Token: 0x04000018 RID: 24
		private int m_max = int.MaxValue;

		// Token: 0x04000019 RID: 25
		private bool m_leftAlign;
	}
}
