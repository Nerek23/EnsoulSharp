using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace log4net.Util
{
	// Token: 0x0200002F RID: 47
	public abstract class TextWriterAdapter : TextWriter
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x0000683D File Offset: 0x0000583D
		protected TextWriterAdapter(TextWriter writer) : base(CultureInfo.InvariantCulture)
		{
			this.m_writer = writer;
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00006851 File Offset: 0x00005851
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x00006859 File Offset: 0x00005859
		protected TextWriter Writer
		{
			get
			{
				return this.m_writer;
			}
			set
			{
				this.m_writer = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00006862 File Offset: 0x00005862
		public override Encoding Encoding
		{
			get
			{
				return this.m_writer.Encoding;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0000686F File Offset: 0x0000586F
		public override IFormatProvider FormatProvider
		{
			get
			{
				return this.m_writer.FormatProvider;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000687C File Offset: 0x0000587C
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00006889 File Offset: 0x00005889
		public override string NewLine
		{
			get
			{
				return this.m_writer.NewLine;
			}
			set
			{
				this.m_writer.NewLine = value;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00006897 File Offset: 0x00005897
		public override void Close()
		{
			this.m_writer.Close();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000068A4 File Offset: 0x000058A4
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				((IDisposable)this.m_writer).Dispose();
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000068B4 File Offset: 0x000058B4
		public override void Flush()
		{
			this.m_writer.Flush();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000068C1 File Offset: 0x000058C1
		public override void Write(char value)
		{
			this.m_writer.Write(value);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000068CF File Offset: 0x000058CF
		public override void Write(char[] buffer, int index, int count)
		{
			this.m_writer.Write(buffer, index, count);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000068DF File Offset: 0x000058DF
		public override void Write(string value)
		{
			this.m_writer.Write(value);
		}

		// Token: 0x0400006D RID: 109
		private TextWriter m_writer;
	}
}
