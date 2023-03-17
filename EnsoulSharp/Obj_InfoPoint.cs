using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Obj_InfoPoint object.
	/// </summary>
	// Token: 0x02000166 RID: 358
	public class Obj_InfoPoint : GameObject
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x00005D0C File Offset: 0x0000510C
		internal Obj_InfoPoint()
		{
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal Obj_InfoPoint(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
