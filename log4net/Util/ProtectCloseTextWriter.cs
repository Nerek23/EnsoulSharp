using System;
using System.IO;

namespace log4net.Util
{
	// Token: 0x02000028 RID: 40
	public class ProtectCloseTextWriter : TextWriterAdapter
	{
		// Token: 0x060001A0 RID: 416 RVA: 0x00005A7A File Offset: 0x00004A7A
		public ProtectCloseTextWriter(TextWriter writer) : base(writer)
		{
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005A83 File Offset: 0x00004A83
		public void Attach(TextWriter writer)
		{
			base.Writer = writer;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00005A8C File Offset: 0x00004A8C
		public override void Close()
		{
		}
	}
}
