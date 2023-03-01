using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains ecerything we can offer related to each MapPropClient object.
	/// </summary>
	// Token: 0x0200014C RID: 332
	public class MapPropClient : GameObject
	{
		// Token: 0x0600064B RID: 1611 RVA: 0x00005C8C File Offset: 0x0000508C
		internal MapPropClient()
		{
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00005C74 File Offset: 0x00005074
		internal MapPropClient(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
