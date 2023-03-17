using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each GrassObject object.
	/// </summary>
	// Token: 0x0200013B RID: 315
	public class GrassObject : GameObject
	{
		// Token: 0x06000634 RID: 1588 RVA: 0x00005D0C File Offset: 0x0000510C
		internal GrassObject()
		{
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal GrassObject(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
