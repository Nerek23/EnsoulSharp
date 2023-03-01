using System;

namespace SharpDX.WIC
{
	// Token: 0x0200003E RID: 62
	[Flags]
	public enum ComponentEnumerateOptions
	{
		// Token: 0x040000C9 RID: 201
		Default = 0,
		// Token: 0x040000CA RID: 202
		Refresh = 1,
		// Token: 0x040000CB RID: 203
		Disabled = -2147483648,
		// Token: 0x040000CC RID: 204
		Unsigned = 1073741824,
		// Token: 0x040000CD RID: 205
		BuiltInOnly = 536870912
	}
}
