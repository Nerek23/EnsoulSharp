using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each LevelPropSpawnerPoint object.
	/// </summary>
	// Token: 0x0200014D RID: 333
	public class LevelPropSpawnerPoint : GameObject
	{
		// Token: 0x06000656 RID: 1622 RVA: 0x00005D0C File Offset: 0x0000510C
		internal LevelPropSpawnerPoint()
		{
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal LevelPropSpawnerPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
