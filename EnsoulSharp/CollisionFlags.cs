using System;

namespace EnsoulSharp
{
	// Token: 0x02000022 RID: 34
	[Flags]
	public enum CollisionFlags
	{
		// Token: 0x04000084 RID: 132
		None = 0,
		// Token: 0x04000085 RID: 133
		Grass = 1,
		// Token: 0x04000086 RID: 134
		Wall = 2,
		// Token: 0x04000087 RID: 135
		Building = 64,
		// Token: 0x04000088 RID: 136
		Prop = 128,
		// Token: 0x04000089 RID: 137
		GlobalVision = 256
	}
}
