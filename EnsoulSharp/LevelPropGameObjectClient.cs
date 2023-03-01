using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each LevelPropGameObjectClient object.
	/// </summary>
	// Token: 0x0200014A RID: 330
	public class LevelPropGameObjectClient : GameObject
	{
		// Token: 0x06000647 RID: 1607 RVA: 0x00005C8C File Offset: 0x0000508C
		internal LevelPropGameObjectClient()
		{
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00005C74 File Offset: 0x00005074
		internal LevelPropGameObjectClient(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
