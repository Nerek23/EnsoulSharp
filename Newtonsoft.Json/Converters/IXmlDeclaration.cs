using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F3 RID: 243
	[NullableContext(1)]
	internal interface IXmlDeclaration : IXmlNode
	{
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000CB7 RID: 3255
		string Version { get; }

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000CB8 RID: 3256
		// (set) Token: 0x06000CB9 RID: 3257
		string Encoding { get; set; }

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000CBA RID: 3258
		// (set) Token: 0x06000CBB RID: 3259
		string Standalone { get; set; }
	}
}
