using System;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F7 RID: 247
	[NullableContext(1)]
	[Nullable(0)]
	internal class XDeclarationWrapper : XObjectWrapper, IXmlDeclaration, IXmlNode
	{
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00032F9A File Offset: 0x0003119A
		internal XDeclaration Declaration { get; }

		// Token: 0x06000CCE RID: 3278 RVA: 0x00032FA2 File Offset: 0x000311A2
		public XDeclarationWrapper(XDeclaration declaration) : base(null)
		{
			this.Declaration = declaration;
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00032FB2 File Offset: 0x000311B2
		public override XmlNodeType NodeType
		{
			get
			{
				return XmlNodeType.XmlDeclaration;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x00032FB6 File Offset: 0x000311B6
		public string Version
		{
			get
			{
				return this.Declaration.Version;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00032FC3 File Offset: 0x000311C3
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x00032FD0 File Offset: 0x000311D0
		public string Encoding
		{
			get
			{
				return this.Declaration.Encoding;
			}
			set
			{
				this.Declaration.Encoding = value;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x00032FDE File Offset: 0x000311DE
		// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x00032FEB File Offset: 0x000311EB
		public string Standalone
		{
			get
			{
				return this.Declaration.Standalone;
			}
			set
			{
				this.Declaration.Standalone = value;
			}
		}
	}
}
