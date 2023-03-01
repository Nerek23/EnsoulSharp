using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000109 RID: 265
	internal class BsonEmpty : BsonToken
	{
		// Token: 0x06000D8A RID: 3466 RVA: 0x000367B2 File Offset: 0x000349B2
		private BsonEmpty(BsonType type)
		{
			this.Type = type;
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000D8B RID: 3467 RVA: 0x000367C1 File Offset: 0x000349C1
		public override BsonType Type { get; }

		// Token: 0x0400041D RID: 1053
		public static readonly BsonToken Null = new BsonEmpty(BsonType.Null);

		// Token: 0x0400041E RID: 1054
		public static readonly BsonToken Undefined = new BsonEmpty(BsonType.Undefined);
	}
}
