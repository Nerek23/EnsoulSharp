using System;

namespace Newtonsoft.Json.Bson
{
	// Token: 0x02000102 RID: 258
	internal enum BsonBinaryType : byte
	{
		// Token: 0x040003FE RID: 1022
		Binary,
		// Token: 0x040003FF RID: 1023
		Function,
		// Token: 0x04000400 RID: 1024
		[Obsolete("This type has been deprecated in the BSON specification. Use Binary instead.")]
		BinaryOld,
		// Token: 0x04000401 RID: 1025
		[Obsolete("This type has been deprecated in the BSON specification. Use Uuid instead.")]
		UuidOld,
		// Token: 0x04000402 RID: 1026
		Uuid,
		// Token: 0x04000403 RID: 1027
		Md5,
		// Token: 0x04000404 RID: 1028
		UserDefined = 128
	}
}
