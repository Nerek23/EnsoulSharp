using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000025 RID: 37
	public struct FarmLocation
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000B526 File Offset: 0x00009726
		public FarmLocation(Vector2 position, int minionsHit)
		{
			this.Position = position;
			this.MinionsHit = minionsHit;
		}

		// Token: 0x040000B6 RID: 182
		public int MinionsHit;

		// Token: 0x040000B7 RID: 183
		public Vector2 Position;
	}
}
