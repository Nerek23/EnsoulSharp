using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Turret object.
	/// </summary>
	// Token: 0x02000168 RID: 360
	public class Turret : AnimatedBuildingClient
	{
		// Token: 0x060006AF RID: 1711 RVA: 0x00006534 File Offset: 0x00005934
		internal Turret()
		{
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0000651C File Offset: 0x0000591C
		internal Turret(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
