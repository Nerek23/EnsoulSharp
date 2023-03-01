using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x0200010F RID: 271
	internal class BsonProperty
	{
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x000368C3 File Offset: 0x00034AC3
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x000368CB File Offset: 0x00034ACB
		public BsonString Name { get; set; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x000368D4 File Offset: 0x00034AD4
		// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x000368DC File Offset: 0x00034ADC
		public BsonToken Value { get; set; }
	}
}
