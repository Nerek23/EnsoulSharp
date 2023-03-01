using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x0200010C RID: 268
	internal class BsonString : BsonValue
	{
		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000D92 RID: 3474 RVA: 0x0003682F File Offset: 0x00034A2F
		// (set) Token: 0x06000D93 RID: 3475 RVA: 0x00036837 File Offset: 0x00034A37
		public int ByteCount { get; set; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000D94 RID: 3476 RVA: 0x00036840 File Offset: 0x00034A40
		public bool IncludeLength { get; }

		// Token: 0x06000D95 RID: 3477 RVA: 0x00036848 File Offset: 0x00034A48
		public BsonString(object value, bool includeLength) : base(value, BsonType.String)
		{
			this.IncludeLength = includeLength;
		}
	}
}
