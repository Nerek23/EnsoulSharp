using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each LevelPropGameObjectClient object.
	/// </summary>
	// Token: 0x0200014C RID: 332
	public class LevelPropGameObjectClient : GameObject
	{
		// Token: 0x06000654 RID: 1620 RVA: 0x00005D0C File Offset: 0x0000510C
		internal LevelPropGameObjectClient()
		{
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal LevelPropGameObjectClient(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
