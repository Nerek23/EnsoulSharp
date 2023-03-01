using System;
using System.Text;

namespace log4net.Util
{
	// Token: 0x0200002E RID: 46
	public sealed class SystemStringFormat
	{
		// Token: 0x060001EB RID: 491 RVA: 0x000065F2 File Offset: 0x000055F2
		public SystemStringFormat(IFormatProvider provider, string format, params object[] args)
		{
			this.m_provider = provider;
			this.m_format = format;
			this.m_args = args;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000660F File Offset: 0x0000560F
		public override string ToString()
		{
			return SystemStringFormat.StringFormat(this.m_provider, this.m_format, this.m_args);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00006628 File Offset: 0x00005628
		private static string StringFormat(IFormatProvider provider, string format, params object[] args)
		{
			string result;
			try
			{
				if (format == null)
				{
					result = null;
				}
				else if (args == null)
				{
					result = format;
				}
				else
				{
					result = string.Format(provider, format, args);
				}
			}
			catch (Exception ex)
			{
				LogLog.Warn(SystemStringFormat.declaringType, "Exception while rendering format [" + format + "]", ex);
				result = SystemStringFormat.StringFormatError(ex, format, args);
			}
			return result;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00006688 File Offset: 0x00005688
		private static string StringFormatError(Exception formatException, string format, object[] args)
		{
			string result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder("<log4net.Error>");
				if (formatException != null)
				{
					stringBuilder.Append("Exception during StringFormat: ").Append(formatException.Message);
				}
				else
				{
					stringBuilder.Append("Exception during StringFormat");
				}
				stringBuilder.Append(" <format>").Append(format).Append("</format>");
				stringBuilder.Append("<args>");
				SystemStringFormat.RenderArray(args, stringBuilder);
				stringBuilder.Append("</args>");
				stringBuilder.Append("</log4net.Error>");
				result = stringBuilder.ToString();
			}
			catch (Exception exception)
			{
				LogLog.Error(SystemStringFormat.declaringType, "INTERNAL ERROR during StringFormat error handling", exception);
				result = "<log4net.Error>Exception during StringFormat. See Internal Log.</log4net.Error>";
			}
			return result;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00006744 File Offset: 0x00005744
		private static void RenderArray(Array array, StringBuilder buffer)
		{
			if (array == null)
			{
				buffer.Append(SystemInfo.NullText);
				return;
			}
			if (array.Rank != 1)
			{
				buffer.Append(array.ToString());
				return;
			}
			buffer.Append("{");
			int length = array.Length;
			if (length > 0)
			{
				SystemStringFormat.RenderObject(array.GetValue(0), buffer);
				for (int i = 1; i < length; i++)
				{
					buffer.Append(", ");
					SystemStringFormat.RenderObject(array.GetValue(i), buffer);
				}
			}
			buffer.Append("}");
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000067D0 File Offset: 0x000057D0
		private static void RenderObject(object obj, StringBuilder buffer)
		{
			if (obj == null)
			{
				buffer.Append(SystemInfo.NullText);
				return;
			}
			try
			{
				buffer.Append(obj);
			}
			catch (Exception ex)
			{
				buffer.Append("<Exception: ").Append(ex.Message).Append(">");
			}
		}

		// Token: 0x04000069 RID: 105
		private readonly IFormatProvider m_provider;

		// Token: 0x0400006A RID: 106
		private readonly string m_format;

		// Token: 0x0400006B RID: 107
		private readonly object[] m_args;

		// Token: 0x0400006C RID: 108
		private static readonly Type declaringType = typeof(SystemStringFormat);
	}
}
