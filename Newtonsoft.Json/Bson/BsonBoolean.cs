using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x0200010B RID: 267
	internal class BsonBoolean : BsonValue
	{
		// Token: 0x06000D90 RID: 3472 RVA: 0x00036808 File Offset: 0x00034A08
		private BsonBoolean(bool value) : base(value, BsonType.Boolean)
		{
		}

		// Token: 0x04000422 RID: 1058
		public static readonly BsonBoolean False = new BsonBoolean(false);

		// Token: 0x04000423 RID: 1059
		public static readonly BsonBoolean True = new BsonBoolean(true);
	}
}
