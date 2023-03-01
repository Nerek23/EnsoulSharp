using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F0 RID: 240
	[NullableContext(1)]
	[Nullable(0)]
	internal class XmlDocumentTypeWrapper : XmlNodeWrapper, IXmlDocumentType, IXmlNode
	{
		// Token: 0x06000C96 RID: 3222 RVA: 0x00032C8D File Offset: 0x00030E8D
		public XmlDocumentTypeWrapper(XmlDocumentType documentType) : base(documentType)
		{
			this._documentType = documentType;
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00032C9D File Offset: 0x00030E9D
		public string Name
		{
			get
			{
				return this._documentType.Name;
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000C98 RID: 3224 RVA: 0x00032CAA File Offset: 0x00030EAA
		public string System
		{
			get
			{
				return this._documentType.SystemId;
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00032CB7 File Offset: 0x00030EB7
		public string Public
		{
			get
			{
				return this._documentType.PublicId;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000C9A RID: 3226 RVA: 0x00032CC4 File Offset: 0x00030EC4
		public string InternalSubset
		{
			get
			{
				return this._documentType.InternalSubset;
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x00032CD1 File Offset: 0x00030ED1
		[Nullable(2)]
		public override string LocalName
		{
			[NullableContext(2)]
			get
			{
				return "DOCTYPE";
			}
		}

		// Token: 0x040003E8 RID: 1000
		private readonly XmlDocumentType _documentType;
	}
}
