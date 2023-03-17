using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains ecerything we can offer related to each MapPropClient object.
	/// </summary>
	// Token: 0x0200014E RID: 334
	public class MapPropClient : GameObject
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x00005D0C File Offset: 0x0000510C
		internal MapPropClient()
		{
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal MapPropClient(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
