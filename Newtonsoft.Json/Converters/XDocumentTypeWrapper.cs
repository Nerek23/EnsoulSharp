using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F8 RID: 248
	[NullableContext(1)]
	[Nullable(0)]
	internal class XDocumentTypeWrapper : XObjectWrapper, IXmlDocumentType, IXmlNode
	{
		// Token: 0x06000CD5 RID: 3285 RVA: 0x00032FF9 File Offset: 0x000311F9
		public XDocumentTypeWrapper(XDocumentType documentType) : base(documentType)
		{
			this._documentType = documentType;
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000CD6 RID: 3286 RVA: 0x00033009 File Offset: 0x00031209
		public string Name
		{
			get
			{
				return this._documentType.Name;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x00033016 File Offset: 0x00031216
		public string System
		{
			get
			{
				return this._documentType.SystemId;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x00033023 File Offset: 0x00031223
		public string Public
		{
			get
			{
				return this._documentType.PublicId;
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00033030 File Offset: 0x00031230
		public string InternalSubset
		{
			get
			{
				return this._documentType.InternalSubset;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x0003303D File Offset: 0x0003123D
		[Nullable(2)]
		public override string LocalName
		{
			[NullableContext(2)]
			get
			{
				return "DOCTYPE";
			}
		}

		// Token: 0x040003ED RID: 1005
		private readonly XDocumentType _documentType;
	}
}
