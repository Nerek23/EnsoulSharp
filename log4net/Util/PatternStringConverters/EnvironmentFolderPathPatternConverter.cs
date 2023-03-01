using System;
using System.IO;
using System.Security;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000043 RID: 67
	internal sealed class EnvironmentFolderPathPatternConverter : PatternConverter
	{
		// Token: 0x0600025B RID: 603 RVA: 0x000076C0 File Offset: 0x000066C0
		protected override void Convert(TextWriter writer, object state)
		{
			try
			{
				if (this.Option != null && this.Option.Length > 0)
				{
					string folderPath = Environment.GetFolderPath((Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), this.Option, true));
					if (folderPath != null && folderPath.Length > 0)
					{
						writer.Write(folderPath);
					}
				}
			}
			catch (SecurityException exception)
			{
				LogLog.Debug(EnvironmentFolderPathPatternConverter.declaringType, "Security exception while trying to expand environment variables. Error Ignored. No Expansion.", exception);
			}
			catch (Exception exception2)
			{
				LogLog.Error(EnvironmentFolderPathPatternConverter.declaringType, "Error occurred while converting environment variable.", exception2);
			}
		}

		// Token: 0x04000081 RID: 129
		private static readonly Type declaringType = typeof(EnvironmentFolderPathPatternConverter);
	}
}
