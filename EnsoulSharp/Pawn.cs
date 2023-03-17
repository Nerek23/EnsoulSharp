using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Pawn object.
	/// </summary>
	// Token: 0x02000161 RID: 353
	public class Pawn : GameObject
	{
		// Token: 0x060006A1 RID: 1697 RVA: 0x00005D0C File Offset: 0x0000510C
		internal Pawn()
		{
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal Pawn(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
