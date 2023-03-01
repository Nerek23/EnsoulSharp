using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x0200010D RID: 269
	internal class BsonBinary : BsonValue
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000D96 RID: 3478 RVA: 0x00036859 File Offset: 0x00034A59
		// (set) Token: 0x06000D97 RID: 3479 RVA: 0x00036861 File Offset: 0x00034A61
		public BsonBinaryType BinaryType { get; set; }

		// Token: 0x06000D98 RID: 3480 RVA: 0x0003686A File Offset: 0x00034A6A
		public BsonBinary(byte[] value, BsonBinaryType binaryType) : base(value, BsonType.Binary)
		{
			this.BinaryType = binaryType;
		}
	}
}
