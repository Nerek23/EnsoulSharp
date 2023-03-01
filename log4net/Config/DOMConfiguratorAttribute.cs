using System;

namespace log4net.Config
{
	// Token: 0x020000C9 RID: 201
	[AttributeUsage(AttributeTargets.Assembly)]
	[Obsolete("Use XmlConfiguratorAttribute instead of DOMConfiguratorAttribute")]
	[Serializable]
	public sealed class DOMConfiguratorAttribute : XmlConfiguratorAttribute
	{
	}
}
