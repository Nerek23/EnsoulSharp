using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x02000100 RID: 256
	[NullableContext(1)]
	[Nullable(0)]
	internal class XElementWrapper : XContainerWrapper, IXmlElement, IXmlNode
	{
		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x00033526 File Offset: 0x00031726
		private XElement Element
		{
			get
			{
				return (XElement)base.WrappedNode;
			}
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x00033533 File Offset: 0x00031733
		public XElementWrapper(XElement element) : base(element)
		{
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0003353C File Offset: 0x0003173C
		public void SetAttributeNode(IXmlNode attribute)
		{
			XObjectWrapper xobjectWrapper = (XObjectWrapper)attribute;
			this.Element.Add(xobjectWrapper.WrappedNode);
			this._attributes = null;
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x00033568 File Offset: 0x00031768
		public override List<IXmlNode> Attributes
		{
			get
			{
				if (this._attributes == null)
				{
					if (!this.Element.HasAttributes && !this.HasImplicitNamespaceAttribute(this.NamespaceUri))
					{
						this._attributes = XmlNodeConverter.EmptyChildNodes;
					}
					else
					{
						this._attributes = new List<IXmlNode>();
						foreach (XAttribute attribute in this.Element.Attributes())
						{
							this._attributes.Add(new XAttributeWrapper(attribute));
						}
						string namespaceUri = this.NamespaceUri;
						if (this.HasImplicitNamespaceAttribute(namespaceUri))
						{
							this._attributes.Insert(0, new XAttributeWrapper(new XAttribute("xmlns", namespaceUri)));
						}
					}
				}
				return this._attributes;
			}
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0003363C File Offset: 0x0003183C
		private bool HasImplicitNamespaceAttribute(string namespaceUri)
		{
			if (!StringUtils.IsNullOrEmpty(namespaceUri))
			{
				IXmlNode parentNode = this.ParentNode;
				if (namespaceUri != ((parentNode != null) ? parentNode.NamespaceUri : null) && StringUtils.IsNullOrEmpty(this.GetPrefixOfNamespace(namespaceUri)))
				{
					bool flag = false;
					if (this.Element.HasAttributes)
					{
						foreach (XAttribute xattribute in this.Element.Attributes())
						{
							if (xattribute.Name.LocalName == "xmlns" && StringUtils.IsNullOrEmpty(xattribute.Name.NamespaceName) && xattribute.Value == namespaceUri)
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0003370C File Offset: 0x0003190C
		public override IXmlNode AppendChild(IXmlNode newChild)
		{
			IXmlNode result = base.AppendChild(newChild);
			this._attributes = null;
			return result;
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x0003371C File Offset: 0x0003191C
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x00033729 File Offset: 0x00031929
		[Nullable(2)]
		public override string Value
		{
			[NullableContext(2)]
			get
			{
				return this.Element.Value;
			}
			[NullableContext(2)]
			set
			{
				this.Element.Value = value;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00033737 File Offset: 0x00031937
		[Nullable(2)]
		public override string LocalName
		{
			[NullableContext(2)]
			get
			{
				return this.Element.Name.LocalName;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x00033749 File Offset: 0x00031949
		[Nullable(2)]
		public override string NamespaceUri
		{
			[NullableContext(2)]
			get
			{
				return this.Element.Name.NamespaceName;
			}
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0003375B File Offset: 0x0003195B
		public string GetPrefixOfNamespace(string namespaceUri)
		{
			return this.Element.GetPrefixOfNamespace(namespaceUri);
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x0003376E File Offset: 0x0003196E
		public bool IsEmpty
		{
			get
			{
				return this.Element.IsEmpty;
			}
		}

		// Token: 0x040003F0 RID: 1008
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IXmlNode> _attributes;
	}
}
