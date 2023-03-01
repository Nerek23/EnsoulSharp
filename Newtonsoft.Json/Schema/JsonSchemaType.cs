using System;

namespace Newtonsoft.Json.Schema
{
	// Token: 0x020000B0 RID: 176
	[Flags]
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public enum JsonSchemaType
	{
		// Token: 0x04000346 RID: 838
		None = 0,
		// Token: 0x04000347 RID: 839
		String = 1,
		// Token: 0x04000348 RID: 840
		Float = 2,
		// Token: 0x04000349 RID: 841
		Integer = 4,
		// Token: 0x0400034A RID: 842
		Boolean = 8,
		// Token: 0x0400034B RID: 843
		Object = 16,
		// Token: 0x0400034C RID: 844
		Array = 32,
		// Token: 0x0400034D RID: 845
		Null = 64,
		// Token: 0x0400034E RID: 846
		Any = 127
	}
}
