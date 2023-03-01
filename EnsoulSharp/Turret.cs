using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Turret object.
	/// </summary>
	// Token: 0x02000166 RID: 358
	public class Turret : AnimatedBuildingClient
	{
		// Token: 0x060006A2 RID: 1698 RVA: 0x0000649C File Offset: 0x0000589C
		internal Turret()
		{
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00006484 File Offset: 0x00005884
		internal Turret(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
