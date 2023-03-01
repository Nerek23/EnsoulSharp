using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F6 RID: 246
	[NullableContext(2)]
	internal interface IXmlNode
	{
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000CC3 RID: 3267
		XmlNodeType NodeType { get; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000CC4 RID: 3268
		string LocalName { get; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000CC5 RID: 3269
		[Nullable(1)]
		List<IXmlNode> ChildNodes { [NullableContext(1)] get; }

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000CC6 RID: 3270
		[Nullable(1)]
		List<IXmlNode> Attributes { [NullableContext(1)] get; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000CC7 RID: 3271
		IXmlNode ParentNode { get; }

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000CC8 RID: 3272
		// (set) Token: 0x06000CC9 RID: 3273
		string Value { get; set; }

		// Token: 0x06000CCA RID: 3274
		[NullableContext(1)]
		IXmlNode AppendChild(IXmlNode newChild);

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000CCB RID: 3275
		string NamespaceUri { get; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000CCC RID: 3276
		object WrappedNode { get; }
	}
}
