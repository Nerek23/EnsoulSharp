using System;
using System.Net;

namespace log4net.Util.TypeConverters
{
	// Token: 0x0200003B RID: 59
	internal class IPAddressConverter : IConvertFrom
	{
		// Token: 0x0600023E RID: 574 RVA: 0x000072C2 File Offset: 0x000062C2
		public bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x000072D4 File Offset: 0x000062D4
		public object ConvertFrom(object source)
		{
			string text = source as string;
			if (text != null && text.Length > 0)
			{
				try
				{
					IPAddress result;
					if (IPAddress.TryParse(text, out result))
					{
						return result;
					}
					IPHostEntry hostEntry = Dns.GetHostEntry(text);
					if (hostEntry != null && hostEntry.AddressList != null && hostEntry.AddressList.Length != 0 && hostEntry.AddressList[0] != null)
					{
						return hostEntry.AddressList[0];
					}
				}
				catch (Exception innerException)
				{
					throw ConversionNotSupportedException.Create(typeof(IPAddress), source, innerException);
				}
			}
			throw ConversionNotSupportedException.Create(typeof(IPAddress), source);
		}

		// Token: 0x0400007C RID: 124
		private static readonly char[] validIpAddressChars = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'x',
			'X',
			'.',
			':',
			'%'
		};
	}
}
