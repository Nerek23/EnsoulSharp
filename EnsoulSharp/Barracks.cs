using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Barracks object.
	/// </summary>
	// Token: 0x020000D5 RID: 213
	public class Barracks : BuildingClient
	{
		// Token: 0x060004EF RID: 1263 RVA: 0x00005CE0 File Offset: 0x000050E0
		internal Barracks()
		{
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00005CC8 File Offset: 0x000050C8
		internal Barracks(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
