using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each LevelPropSpawnerPoint object.
	/// </summary>
	// Token: 0x0200014B RID: 331
	public class LevelPropSpawnerPoint : GameObject
	{
		// Token: 0x06000649 RID: 1609 RVA: 0x00005C8C File Offset: 0x0000508C
		internal LevelPropSpawnerPoint()
		{
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00005C74 File Offset: 0x00005074
		internal LevelPropSpawnerPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
