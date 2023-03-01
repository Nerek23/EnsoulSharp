using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000106 RID: 262
	internal abstract class BsonToken
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000D7A RID: 3450
		public abstract BsonType Type { get; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x000366E6 File Offset: 0x000348E6
		// (set) Token: 0x06000D7C RID: 3452 RVA: 0x000366EE File Offset: 0x000348EE
		public BsonToken Parent { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000D7D RID: 3453 RVA: 0x000366F7 File Offset: 0x000348F7
		// (set) Token: 0x06000D7E RID: 3454 RVA: 0x000366FF File Offset: 0x000348FF
		public int CalculatedSize { get; set; }
	}
}
