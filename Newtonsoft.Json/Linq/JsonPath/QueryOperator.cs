using System;

namespace Newtonsoft.Json.Linq.JsonPath
{
	// Token: 0x020000D4 RID: 212
	internal enum QueryOperator
	{
		// Token: 0x040003B7 RID: 951
		None,
		// Token: 0x040003B8 RID: 952
		Equals,
		// Token: 0x040003B9 RID: 953
		NotEquals,
		// Token: 0x040003BA RID: 954
		Exists,
		// Token: 0x040003BB RID: 955
		LessThan,
		// Token: 0x040003BC RID: 956
		LessThanOrEquals,
		// Token: 0x040003BD RID: 957
		GreaterThan,
		// Token: 0x040003BE RID: 958
		GreaterThanOrEquals,
		// Token: 0x040003BF RID: 959
		And,
		// Token: 0x040003C0 RID: 960
		Or,
		// Token: 0x040003C1 RID: 961
		RegexEquals,
		// Token: 0x040003C2 RID: 962
		StrictEquals,
		// Token: 0x040003C3 RID: 963
		StrictNotEquals
	}
}
