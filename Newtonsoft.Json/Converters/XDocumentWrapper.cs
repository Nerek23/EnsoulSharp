using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F9 RID: 249
	[NullableContext(1)]
	[Nullable(0)]
	internal class XDocumentWrapper : XContainerWrapper, IXmlDocument, IXmlNode
	{
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x00033044 File Offset: 0x00031244
		private XDocument Document
		{
			get
			{
				return (XDocument)base.WrappedNode;
			}
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x00033051 File Offset: 0x00031251
		public XDocumentWrapper(XDocument document) : base(document)
		{
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x0003305C File Offset: 0x0003125C
		public override List<IXmlNode> ChildNodes
		{
			get
			{
				List<IXmlNode> childNodes = base.ChildNodes;
				if (this.Document.Declaration != null && (childNodes.Count == 0 || childNodes[0].NodeType != XmlNodeType.XmlDeclaration))
				{
					childNodes.Insert(0, new XDeclarationWrapper(this.Document.Declaration));
				}
				return childNodes;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x000330AD File Offset: 0x000312AD
		protected override bool HasChildNodes
		{
			get
			{
				return base.HasChildNodes || this.Document.Declaration != null;
			}
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x000330C7 File Offset: 0x000312C7
		public IXmlNode CreateComment([Nullable(2)] string text)
		{
			return new XObjectWrapper(new XComment(text));
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x000330D4 File Offset: 0x000312D4
		public IXmlNode CreateTextNode([Nullable(2)] string text)
		{
			return new XObjectWrapper(new XText(text));
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x000330E1 File Offset: 0x000312E1
		public IXmlNode CreateCDataSection([Nullable(2)] string data)
		{
			return new XObjectWrapper(new XCData(data));
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x000330EE File Offset: 0x000312EE
		public IXmlNode CreateWhitespace([Nullable(2)] string text)
		{
			return new XObjectWrapper(new XText(text));
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x000330FB File Offset: 0x000312FB
		public IXmlNode CreateSignificantWhitespace([Nullable(2)] string text)
		{
			return new XObjectWrapper(new XText(text));
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00033108 File Offset: 0x00031308
		[NullableContext(2)]
		[return: Nullable(1)]
		public IXmlNode CreateXmlDeclaration(string version, string encoding, string standalone)
		{
			return new XDeclarationWrapper(new XDeclaration(version, encoding, standalone));
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00033117 File Offset: 0x00031317
		[NullableContext(2)]
		[return: Nullable(1)]
		public IXmlNode CreateXmlDocumentType(string name, string publicId, string systemId, string internalSubset)
		{
			return new XDocumentTypeWrapper(new XDocumentType(name, publicId, systemId, internalSubset));
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00033128 File Offset: 0x00031328
		public IXmlNode CreateProcessingInstruction(string target, [Nullable(2)] string data)
		{
			return new XProcessingInstructionWrapper(new XProcessingInstruction(target, data));
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00033136 File Offset: 0x00031336
		public IXmlElement CreateElement(string elementName)
		{
			return new XElementWrapper(new XElement(elementName));
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00033148 File Offset: 0x00031348
		public IXmlElement CreateElement(string qualifiedName, string namespaceUri)
		{
			return new XElementWrapper(new XElement(XName.Get(MiscellaneousUtils.GetLocalName(qualifiedName), namespaceUri)));
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00033160 File Offset: 0x00031360
		public IXmlNode CreateAttribute(string name, [Nullable(2)] string value)
		{
			return new XAttributeWrapper(new XAttribute(name, value));
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x00033173 File Offset: 0x00031373
		public IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, [Nullable(2)] string value)
		{
			return new XAttributeWrapper(new XAttribute(XName.Get(MiscellaneousUtils.GetLocalName(qualifiedName), namespaceUri), value));
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000CEB RID: 3307 RVA: 0x0003318C File Offset: 0x0003138C
		[Nullable(2)]
		public IXmlElement DocumentElement
		{
			[NullableContext(2)]
			get
			{
				if (this.Document.Root == null)
				{
					return null;
				}
				return new XElementWrapper(this.Document.Root);
			}
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x000331B0 File Offset: 0x000313B0
		public override IXmlNode AppendChild(IXmlNode newChild)
		{
			XDeclarationWrapper xdeclarationWrapper = newChild as XDeclarationWrapper;
			if (xdeclarationWrapper != null)
			{
				this.Document.Declaration = xdeclarationWrapper.Declaration;
				return xdeclarationWrapper;
			}
			return base.AppendChild(newChild);
		}
	}
}
