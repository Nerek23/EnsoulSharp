using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x020000F4 RID: 244
	[NullableContext(1)]
	internal interface IXmlDocumentType : IXmlNode
	{
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000CBC RID: 3260
		string Name { get; }

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000CBD RID: 3261
		string System { get; }

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000CBE RID: 3262
		string Public { get; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000CBF RID: 3263
		string InternalSubset { get; }
	}
}
