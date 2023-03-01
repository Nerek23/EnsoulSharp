using System;
using System.Diagnostics;
using System.IO;
using System.Security;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000048 RID: 72
	internal sealed class ProcessIdPatternConverter : PatternConverter
	{
		// Token: 0x0600026A RID: 618 RVA: 0x00007988 File Offset: 0x00006988
		[SecuritySafeCritical]
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				writer.Write(Process.GetCurrentProcess().Id);
			}
			catch (SecurityException)
			{
				LogLog.Debug(ProcessIdPatternConverter.declaringType, "Security exception while trying to get current process id. Error Ignored.");
				writer.Write(SystemInfo.NotAvailableText);
			}
		}

		// Token: 0x04000084 RID: 132
		private static readonly Type declaringType = typeof(ProcessIdPatternConverter);
	}
}
