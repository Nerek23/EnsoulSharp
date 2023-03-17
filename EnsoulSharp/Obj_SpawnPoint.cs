using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Obj_SpawnPoint object.
	/// </summary>
	// Token: 0x02000165 RID: 357
	public class Obj_SpawnPoint : BuildingClient
	{
		// Token: 0x060006A9 RID: 1705 RVA: 0x00005CE0 File Offset: 0x000050E0
		internal Obj_SpawnPoint()
		{
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00005CC8 File Offset: 0x000050C8
		internal Obj_SpawnPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
