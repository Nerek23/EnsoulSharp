using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each ShopClient object.
	/// </summary>
	// Token: 0x02000167 RID: 359
	public class ShopClient : BuildingClient
	{
		// Token: 0x060006AD RID: 1709 RVA: 0x00005CE0 File Offset: 0x000050E0
		internal ShopClient()
		{
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00005CC8 File Offset: 0x000050C8
		internal ShopClient(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
