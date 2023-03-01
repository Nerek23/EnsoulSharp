using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F1 RID: 241
	[NullableContext(2)]
	[Nullable(0)]
	internal class XmlNodeWrapper : IXmlNode
	{
		// Token: 0x06000C9C RID: 3228 RVA: 0x00032CD8 File Offset: 0x00030ED8
		[NullableContext(1)]
		public XmlNodeWrapper(XmlNode node)
		{
			this._node = node;
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x00032CE7 File Offset: 0x00030EE7
		public object WrappedNode
		{
			get
			{
				return this._node;
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000C9E RID: 3230 RVA: 0x00032CEF File Offset: 0x00030EEF
		public XmlNodeType NodeType
		{
			get
			{
				return this._node.NodeType;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00032CFC File Offset: 0x00030EFC
		public virtual string LocalName
		{
			get
			{
				return this._node.LocalName;
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x00032D0C File Offset: 0x00030F0C
		[Nullable(1)]
		public List<IXmlNode> ChildNodes
		{
			[NullableContext(1)]
			get
			{
				if (this._childNodes == null)
				{
					if (!this._node.HasChildNodes)
					{
						this._childNodes = XmlNodeConverter.EmptyChildNodes;
					}
					else
					{
						this._childNodes = new List<IXmlNode>(this._node.ChildNodes.Count);
						foreach (object obj in this._node.ChildNodes)
						{
							XmlNode node = (XmlNode)obj;
							this._childNodes.Add(XmlNodeWrapper.WrapNode(node));
						}
					}
				}
				return this._childNodes;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x00032DBC File Offset: 0x00030FBC
		protected virtual bool HasChildNodes
		{
			get
			{
				return this._node.HasChildNodes;
			}
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x00032DCC File Offset: 0x00030FCC
		[NullableContext(1)]
		internal static IXmlNode WrapNode(XmlNode node)
		{
			XmlNodeType nodeType = node.NodeType;
			if (nodeType == XmlNodeType.Element)
			{
				return new XmlElementWrapper((XmlElement)node);
			}
			if (nodeType == XmlNodeType.DocumentType)
			{
				return new XmlDocumentTypeWrapper((XmlDocumentType)node);
			}
			if (nodeType != XmlNodeType.XmlDeclaration)
			{
				return new XmlNodeWrapper(node);
			}
			return new XmlDeclarationWrapper((XmlDeclaration)node);
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x00032E1C File Offset: 0x0003101C
		[Nullable(1)]
		public List<IXmlNode> Attributes
		{
			[NullableContext(1)]
			get
			{
				if (this._attributes == null)
				{
					if (!this.HasAttributes)
					{
						this._attributes = XmlNodeConverter.EmptyChildNodes;
					}
					else
					{
						this._attributes = new List<IXmlNode>(this._node.Attributes.Count);
						foreach (object obj in this._node.Attributes)
						{
							XmlAttribute node = (XmlAttribute)obj;
							this._attributes.Add(XmlNodeWrapper.WrapNode(node));
						}
					}
				}
				return this._attributes;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000CA4 RID: 3236 RVA: 0x00032EC4 File Offset: 0x000310C4
		private bool HasAttributes
		{
			get
			{
				XmlElement xmlElement = this._node as XmlElement;
				if (xmlElement != null)
				{
					return xmlElement.HasAttributes;
				}
				XmlAttributeCollection attributes = this._node.Attributes;
				return attributes != null && attributes.Count > 0;
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x00032F00 File Offset: 0x00031100
		public IXmlNode ParentNode
		{
			get
			{
				XmlAttribute xmlAttribute = this._node as XmlAttribute;
				XmlNode xmlNode = (xmlAttribute != null) ? xmlAttribute.OwnerElement : this._node.ParentNode;
				if (xmlNode == null)
				{
					return null;
				}
				return XmlNodeWrapper.WrapNode(xmlNode);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x00032F3B File Offset: 0x0003113B
		// (set) Token: 0x06000CA7 RID: 3239 RVA: 0x00032F48 File Offset: 0x00031148
		public string Value
		{
			get
			{
				return this._node.Value;
			}
			set
			{
				this._node.Value = value;
			}
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x00032F58 File Offset: 0x00031158
		[NullableContext(1)]
		public IXmlNode AppendChild(IXmlNode newChild)
		{
			XmlNodeWrapper xmlNodeWrapper = (XmlNodeWrapper)newChild;
			this._node.AppendChild(xmlNodeWrapper._node);
			this._childNodes = null;
			this._attributes = null;
			return newChild;
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x00032F8D File Offset: 0x0003118D
		public string NamespaceUri
		{
			get
			{
				return this._node.NamespaceURI;
			}
		}

		// Token: 0x040003E9 RID: 1001
		[Nullable(1)]
		private readonly XmlNode _node;

		// Token: 0x040003EA RID: 1002
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IXmlNode> _childNodes;

		// Token: 0x040003EB RID: 1003
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IXmlNode> _attributes;
	}
}
