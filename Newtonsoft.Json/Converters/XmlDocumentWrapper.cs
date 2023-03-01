using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000ED RID: 237
	[NullableContext(1)]
	[Nullable(0)]
	internal class XmlDocumentWrapper : XmlNodeWrapper, IXmlDocument, IXmlNode
	{
		// Token: 0x06000C7E RID: 3198 RVA: 0x00032AB6 File Offset: 0x00030CB6
		public XmlDocumentWrapper(XmlDocument document) : base(document)
		{
			this._document = document;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x00032AC6 File Offset: 0x00030CC6
		public IXmlNode CreateComment([Nullable(2)] string data)
		{
			return new XmlNodeWrapper(this._document.CreateComment(data));
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00032AD9 File Offset: 0x00030CD9
		public IXmlNode CreateTextNode([Nullable(2)] string text)
		{
			return new XmlNodeWrapper(this._document.CreateTextNode(text));
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00032AEC File Offset: 0x00030CEC
		public IXmlNode CreateCDataSection([Nullable(2)] string data)
		{
			return new XmlNodeWrapper(this._document.CreateCDataSection(data));
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00032AFF File Offset: 0x00030CFF
		public IXmlNode CreateWhitespace([Nullable(2)] string text)
		{
			return new XmlNodeWrapper(this._document.CreateWhitespace(text));
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00032B12 File Offset: 0x00030D12
		public IXmlNode CreateSignificantWhitespace([Nullable(2)] string text)
		{
			return new XmlNodeWrapper(this._document.CreateSignificantWhitespace(text));
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00032B25 File Offset: 0x00030D25
		[NullableContext(2)]
		[return: Nullable(1)]
		public IXmlNode CreateXmlDeclaration(string version, string encoding, string standalone)
		{
			return new XmlDeclarationWrapper(this._document.CreateXmlDeclaration(version, encoding, standalone));
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00032B3A File Offset: 0x00030D3A
		[NullableContext(2)]
		[return: Nullable(1)]
		public IXmlNode CreateXmlDocumentType(string name, string publicId, string systemId, string internalSubset)
		{
			return new XmlDocumentTypeWrapper(this._document.CreateDocumentType(name, publicId, systemId, null));
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x00032B50 File Offset: 0x00030D50
		public IXmlNode CreateProcessingInstruction(string target, [Nullable(2)] string data)
		{
			return new XmlNodeWrapper(this._document.CreateProcessingInstruction(target, data));
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00032B64 File Offset: 0x00030D64
		public IXmlElement CreateElement(string elementName)
		{
			return new XmlElementWrapper(this._document.CreateElement(elementName));
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00032B77 File Offset: 0x00030D77
		public IXmlElement CreateElement(string qualifiedName, string namespaceUri)
		{
			return new XmlElementWrapper(this._document.CreateElement(qualifiedName, namespaceUri));
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00032B8B File Offset: 0x00030D8B
		public IXmlNode CreateAttribute(string name, [Nullable(2)] string value)
		{
			return new XmlNodeWrapper(this._document.CreateAttribute(name))
			{
				Value = value
			};
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00032BA5 File Offset: 0x00030DA5
		public IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, [Nullable(2)] string value)
		{
			return new XmlNodeWrapper(this._document.CreateAttribute(qualifiedName, namespaceUri))
			{
				Value = value
			};
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x00032BC0 File Offset: 0x00030DC0
		[Nullable(2)]
		public IXmlElement DocumentElement
		{
			[NullableContext(2)]
			get
			{
				if (this._document.DocumentElement == null)
				{
					return null;
				}
				return new XmlElementWrapper(this._document.DocumentElement);
			}
		}

		// Token: 0x040003E5 RID: 997
		private readonly XmlDocument _document;
	}
}
