using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000EE RID: 238
	[NullableContext(1)]
	[Nullable(0)]
	internal class XmlElementWrapper : XmlNodeWrapper, IXmlElement, IXmlNode
	{
		// Token: 0x06000C8C RID: 3212 RVA: 0x00032BE1 File Offset: 0x00030DE1
		public XmlElementWrapper(XmlElement element) : base(element)
		{
			this._element = element;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00032BF4 File Offset: 0x00030DF4
		public void SetAttributeNode(IXmlNode attribute)
		{
			XmlNodeWrapper xmlNodeWrapper = (XmlNodeWrapper)attribute;
			this._element.SetAttributeNode((XmlAttribute)xmlNodeWrapper.WrappedNode);
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x00032C1F File Offset: 0x00030E1F
		public string GetPrefixOfNamespace(string namespaceUri)
		{
			return this._element.GetPrefixOfNamespace(namespaceUri);
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x00032C2D File Offset: 0x00030E2D
		public bool IsEmpty
		{
			get
			{
				return this._element.IsEmpty;
			}
		}

		// Token: 0x040003E6 RID: 998
		private readonly XmlElement _element;
	}
}
