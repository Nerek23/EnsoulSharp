using System;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000EF RID: 239
	[NullableContext(1)]
	[Nullable(0)]
	internal class XmlDeclarationWrapper : XmlNodeWrapper, IXmlDeclaration, IXmlNode
	{
		// Token: 0x06000C90 RID: 3216 RVA: 0x00032C3A File Offset: 0x00030E3A
		public XmlDeclarationWrapper(XmlDeclaration declaration) : base(declaration)
		{
			this._declaration = declaration;
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x00032C4A File Offset: 0x00030E4A
		public string Version
		{
			get
			{
				return this._declaration.Version;
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x00032C57 File Offset: 0x00030E57
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x00032C64 File Offset: 0x00030E64
		public string Encoding
		{
			get
			{
				return this._declaration.Encoding;
			}
			set
			{
				this._declaration.Encoding = value;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x00032C72 File Offset: 0x00030E72
		// (set) Token: 0x06000C95 RID: 3221 RVA: 0x00032C7F File Offset: 0x00030E7F
		public string Standalone
		{
			get
			{
				return this._declaration.Standalone;
			}
			set
			{
				this._declaration.Standalone = value;
			}
		}

		// Token: 0x040003E7 RID: 999
		private readonly XmlDeclaration _declaration;
	}
}
