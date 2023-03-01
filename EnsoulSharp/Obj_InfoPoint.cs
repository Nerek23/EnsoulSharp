using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Obj_InfoPoint object.
	/// </summary>
	// Token: 0x02000164 RID: 356
	public class Obj_InfoPoint : GameObject
	{
		// Token: 0x0600069E RID: 1694 RVA: 0x00005C8C File Offset: 0x0000508C
		internal Obj_InfoPoint()
		{
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00005C74 File Offset: 0x00005074
		internal Obj_InfoPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
