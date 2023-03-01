using System;
using System.IO;
using System.Security;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000044 RID: 68
	internal sealed class EnvironmentPatternConverter : PatternConverter
	{
		// Token: 0x0600025E RID: 606 RVA: 0x00007778 File Offset: 0x00006778
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				if (this.Option != null && this.Option.Length > 0)
				{
					string environmentVariable = Environment.GetEnvironmentVariable(this.Option);
					if (environmentVariable == null)
					{
						environmentVariable = Environment.GetEnvironmentVariable(this.Option, EnvironmentVariableTarget.User);
					}
					if (environmentVariable == null)
					{
						environmentVariable = Environment.GetEnvironmentVariable(this.Option, EnvironmentVariableTarget.Machine);
					}
					if (environmentVariable != null && environmentVariable.Length > 0)
					{
						writer.Write(environmentVariable);
					}
				}
			}
			catch (SecurityException exception)
			{
				LogLog.Debug(EnvironmentPatternConverter.declaringType, "Security exception while trying to expand environment variables. Error Ignored. No Expansion.", exception);
			}
			catch (Exception exception2)
			{
				LogLog.Error(EnvironmentPatternConverter.declaringType, "Error occurred while converting environment variable.", exception2);
			}
		}

		// Token: 0x04000082 RID: 130
		private static readonly Type declaringType = typeof(EnvironmentPatternConverter);
	}
}
