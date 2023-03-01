using System;
using System.IO;
using System.Security;
using System.Threading;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000045 RID: 69
	internal sealed class IdentityPatternConverter : PatternConverter
	{
		// Token: 0x06000261 RID: 609 RVA: 0x0000783C File Offset: 0x0000683C
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.Name != null)
				{
					writer.Write(Thread.CurrentPrincipal.Identity.Name);
				}
			}
			catch (SecurityException)
			{
				LogLog.Debug(IdentityPatternConverter.declaringType, "Security exception while trying to get current thread principal. Error Ignored.");
				writer.Write(SystemInfo.NotAvailableText);
			}
		}

		// Token: 0x04000083 RID: 131
		private static readonly Type declaringType = typeof(IdentityPatternConverter);
	}
}
