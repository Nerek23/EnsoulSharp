using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each BuildingClient object.
	/// </summary>
	// Token: 0x020000CE RID: 206
	public class BuildingClient : AttackableUnit
	{
		// Token: 0x060004E0 RID: 1248 RVA: 0x000016C4 File Offset: 0x00000AC4
		internal BuildingClient()
		{
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x000016AC File Offset: 0x00000AAC
		internal BuildingClient(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
