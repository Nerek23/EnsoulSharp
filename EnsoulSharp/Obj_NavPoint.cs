using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Obj_NavPoint object.
	/// </summary>
	// Token: 0x02000162 RID: 354
	public class Obj_NavPoint : BuildingClient
	{
		// Token: 0x0600069A RID: 1690 RVA: 0x00005C60 File Offset: 0x00005060
		internal Obj_NavPoint()
		{
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00005C48 File Offset: 0x00005048
		internal Obj_NavPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
