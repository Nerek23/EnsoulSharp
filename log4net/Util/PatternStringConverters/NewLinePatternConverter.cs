using System;
using log4net.Core;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000047 RID: 71
	internal sealed class NewLinePatternConverter : LiteralPatternConverter, IOptionHandler
	{
		// Token: 0x06000268 RID: 616 RVA: 0x0000792C File Offset: 0x0000692C
		public void ActivateOptions()
		{
			if (SystemInfo.EqualsIgnoringCase(this.Option, "DOS"))
			{
				this.Option = "\r\n";
				return;
			}
			if (SystemInfo.EqualsIgnoringCase(this.Option, "UNIX"))
			{
				this.Option = "\n";
				return;
			}
			this.Option = SystemInfo.NewLine;
		}
	}
}
