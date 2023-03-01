using System;
using System.IO;
using System.Security;
using System.Security.Principal;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x0200004B RID: 75
	internal sealed class UserNamePatternConverter : PatternConverter
	{
		// Token: 0x06000273 RID: 627 RVA: 0x00007B9C File Offset: 0x00006B9C
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				WindowsIdentity current = WindowsIdentity.GetCurrent();
				if (current != null && current.Name != null)
				{
					writer.Write(current.Name);
				}
			}
			catch (SecurityException)
			{
				LogLog.Debug(UserNamePatternConverter.declaringType, "Security exception while trying to get current windows identity. Error Ignored.");
				writer.Write(SystemInfo.NotAvailableText);
			}
		}

		// Token: 0x04000088 RID: 136
		private static readonly Type declaringType = typeof(UserNamePatternConverter);
	}
}
