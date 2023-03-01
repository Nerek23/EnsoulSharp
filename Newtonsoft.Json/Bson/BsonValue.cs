using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x0200010A RID: 266
	internal class BsonValue : BsonToken
	{
		// Token: 0x06000D8D RID: 3469 RVA: 0x000367E2 File Offset: 0x000349E2
		public BsonValue(object value, BsonType type)
		{
			this._value = value;
			this._type = type;
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x000367F8 File Offset: 0x000349F8
		public object Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000D8F RID: 3471 RVA: 0x00036800 File Offset: 0x00034A00
		public override BsonType Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x04000420 RID: 1056
		private readonly object _value;

		// Token: 0x04000421 RID: 1057
		private readonly BsonType _type;
	}
}
