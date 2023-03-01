using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each UnrevealedTarget object.
	/// </summary>
	// Token: 0x02000160 RID: 352
	public class UnrevealedTarget : GameObject
	{
		// Token: 0x06000696 RID: 1686 RVA: 0x00005C8C File Offset: 0x0000508C
		internal UnrevealedTarget()
		{
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00005C74 File Offset: 0x00005074
		internal UnrevealedTarget(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
