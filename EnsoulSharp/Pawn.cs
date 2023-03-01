using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Pawn object.
	/// </summary>
	// Token: 0x0200015F RID: 351
	public class Pawn : GameObject
	{
		// Token: 0x06000694 RID: 1684 RVA: 0x00005C8C File Offset: 0x0000508C
		internal Pawn()
		{
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00005C74 File Offset: 0x00005074
		internal Pawn(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
