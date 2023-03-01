using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace log4net.Util
{
	// Token: 0x02000033 RID: 51
	public sealed class Transform
	{
		// Token: 0x06000213 RID: 531 RVA: 0x00006B49 File Offset: 0x00005B49
		private Transform()
		{
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00006B54 File Offset: 0x00005B54
		public static void WriteEscapedXmlString(XmlWriter writer, string textData, string invalidCharReplacement)
		{
			string text = Transform.MaskXmlInvalidCharacters(textData, invalidCharReplacement);
			int num = 12 * (1 + Transform.CountSubstrings(text, "]]>"));
			if (3 * (Transform.CountSubstrings(text, "<") + Transform.CountSubstrings(text, ">")) + 4 * Transform.CountSubstrings(text, "&") <= num)
			{
				writer.WriteString(text);
				return;
			}
			int i = text.IndexOf("]]>");
			if (i < 0)
			{
				writer.WriteCData(text);
				return;
			}
			int num2 = 0;
			while (i > -1)
			{
				writer.WriteCData(text.Substring(num2, i - num2));
				if (i == text.Length - 3)
				{
					num2 = text.Length;
					writer.WriteString("]]>");
					break;
				}
				writer.WriteString("]]");
				num2 = i + 2;
				i = text.IndexOf("]]>", num2);
			}
			if (num2 < text.Length)
			{
				writer.WriteCData(text.Substring(num2));
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00006C2D File Offset: 0x00005C2D
		public static string MaskXmlInvalidCharacters(string textData, string mask)
		{
			return Transform.INVALIDCHARS.Replace(textData, mask);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00006C3C File Offset: 0x00005C3C
		private static int CountSubstrings(string text, string substring)
		{
			int num = 0;
			int i = 0;
			int length = text.Length;
			int length2 = substring.Length;
			if (length == 0)
			{
				return 0;
			}
			if (length2 == 0)
			{
				return 0;
			}
			while (i < length)
			{
				int num2 = text.IndexOf(substring, i);
				if (num2 == -1)
				{
					break;
				}
				num++;
				i = num2 + length2;
			}
			return num;
		}

		// Token: 0x04000072 RID: 114
		private const string CDATA_END = "]]>";

		// Token: 0x04000073 RID: 115
		private const string CDATA_UNESCAPABLE_TOKEN = "]]";

		// Token: 0x04000074 RID: 116
		private static Regex INVALIDCHARS = new Regex("[^\\x09\\x0A\\x0D\\x20-\\uD7FF\\uE000-\\uFFFD]", RegexOptions.Compiled);
	}
}
