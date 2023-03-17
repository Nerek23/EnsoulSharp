using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each UnrevealedTarget object.
	/// </summary>
	// Token: 0x02000162 RID: 354
	public class UnrevealedTarget : GameObject
	{
		// Token: 0x060006A3 RID: 1699 RVA: 0x00005D0C File Offset: 0x0000510C
		internal UnrevealedTarget()
		{
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal UnrevealedTarget(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
