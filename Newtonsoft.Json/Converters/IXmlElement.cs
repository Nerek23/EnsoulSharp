using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F5 RID: 245
	[NullableContext(1)]
	internal interface IXmlElement : IXmlNode
	{
		// Token: 0x06000CC0 RID: 3264
		void SetAttributeNode(IXmlNode attribute);

		// Token: 0x06000CC1 RID: 3265
		string GetPrefixOfNamespace(string namespaceUri);

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000CC2 RID: 3266
		bool IsEmpty { get; }
	}
}
