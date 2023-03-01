using System;
using System.IO;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000046 RID: 70
	internal class LiteralPatternConverter : PatternConverter
	{
		// Token: 0x06000264 RID: 612 RVA: 0x000078D0 File Offset: 0x000068D0
		public override PatternConverter SetNext(PatternConverter pc)
		{
			LiteralPatternConverter literalPatternConverter = pc as LiteralPatternConverter;
			if (literalPatternConverter != null)
			{
				this.Option += literalPatternConverter.Option;
				return this;
			}
			return base.SetNext(pc);
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00007907 File Offset: 0x00006907
		public override void Format(TextWriter writer, object state)
		{
			writer.Write(this.Option);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00007915 File Offset: 0x00006915
		protected override void Convert(TextWriter writer, object state)
		{
			throw new InvalidOperationException("Should never get here because of the overridden Format method");
		}
	}
}
