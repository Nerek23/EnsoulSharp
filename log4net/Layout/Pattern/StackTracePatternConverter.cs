using System;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Layout.Pattern
{
	// Token: 0x0200008D RID: 141
	internal class StackTracePatternConverter : PatternLayoutConverter, IOptionHandler
	{
		// Token: 0x06000408 RID: 1032 RVA: 0x0000D324 File Offset: 0x0000C324
		public void ActivateOptions()
		{
			if (this.Option == null)
			{
				return;
			}
			string text = this.Option.Trim();
			if (text.Length != 0)
			{
				int num;
				if (SystemInfo.TryParse(text, out num))
				{
					if (num <= 0)
					{
						LogLog.Error(StackTracePatternConverter.declaringType, "StackTracePatternConverter: StackeFrameLevel option (" + text + ") isn't a positive integer.");
						return;
					}
					this.m_stackFrameLevel = num;
					return;
				}
				else
				{
					LogLog.Error(StackTracePatternConverter.declaringType, "StackTracePatternConverter: StackFrameLevel option \"" + text + "\" not a decimal integer.");
				}
			}
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000D39C File Offset: 0x0000C39C
		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			StackFrameItem[] stackFrames = loggingEvent.LocationInformation.StackFrames;
			if (stackFrames == null || stackFrames.Length == 0)
			{
				LogLog.Error(StackTracePatternConverter.declaringType, "loggingEvent.LocationInformation.StackFrames was null or empty.");
				return;
			}
			int i = this.m_stackFrameLevel - 1;
			while (i >= 0)
			{
				if (i >= stackFrames.Length)
				{
					i--;
				}
				else
				{
					StackFrameItem stackFrameItem = stackFrames[i];
					writer.Write("{0}.{1}", stackFrameItem.ClassName, this.GetMethodInformation(stackFrameItem.Method));
					if (i > 0)
					{
						writer.Write(" > ");
					}
					i--;
				}
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000D41B File Offset: 0x0000C41B
		internal virtual string GetMethodInformation(MethodItem method)
		{
			return method.Name;
		}

		// Token: 0x04000107 RID: 263
		private int m_stackFrameLevel = 1;

		// Token: 0x04000108 RID: 264
		private static readonly Type declaringType = typeof(StackTracePatternConverter);
	}
}
