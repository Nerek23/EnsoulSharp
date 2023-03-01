using System;
using System.Configuration;
using System.Xml;

namespace log4net.Config
{
	// Token: 0x020000CA RID: 202
	public class Log4NetConfigurationSectionHandler : IConfigurationSectionHandler
	{
		// Token: 0x060005A7 RID: 1447 RVA: 0x00011E17 File Offset: 0x00010E17
		public object Create(object parent, object configContext, XmlNode section)
		{
			return section;
		}
	}
}
