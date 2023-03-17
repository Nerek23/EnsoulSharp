using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Obj_NavPoint object.
	/// </summary>
	// Token: 0x02000164 RID: 356
	public class Obj_NavPoint : BuildingClient
	{
		// Token: 0x060006A7 RID: 1703 RVA: 0x00005CE0 File Offset: 0x000050E0
		internal Obj_NavPoint()
		{
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00005CC8 File Offset: 0x000050C8
		internal Obj_NavPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
