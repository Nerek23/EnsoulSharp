using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x0200010E RID: 270
	internal class BsonRegex : BsonToken
	{
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x0003687B File Offset: 0x00034A7B
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x00036883 File Offset: 0x00034A83
		public BsonString Pattern { get; set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x0003688C File Offset: 0x00034A8C
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x00036894 File Offset: 0x00034A94
		public BsonString Options { get; set; }

		// Token: 0x06000D9D RID: 3485 RVA: 0x0003689D File Offset: 0x00034A9D
		public BsonRegex(string pattern, string options)
		{
			this.Pattern = new BsonString(pattern, false);
			this.Options = new BsonString(options, false);
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000D9E RID: 3486 RVA: 0x000368BF File Offset: 0x00034ABF
		public override BsonType Type
		{
			get
			{
				return BsonType.Regex;
			}
		}
	}
}
