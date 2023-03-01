using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Obj_SpawnPoint object.
	/// </summary>
	// Token: 0x02000163 RID: 355
	public class Obj_SpawnPoint : BuildingClient
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x00005C60 File Offset: 0x00005060
		internal Obj_SpawnPoint()
		{
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00005C48 File Offset: 0x00005048
		internal Obj_SpawnPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
