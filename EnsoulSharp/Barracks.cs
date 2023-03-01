using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each Barracks object.
	/// </summary>
	// Token: 0x020000D5 RID: 213
	public class Barracks : BuildingClient
	{
		// Token: 0x060004E4 RID: 1252 RVA: 0x00005C60 File Offset: 0x00005060
		internal Barracks()
		{
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x00005C48 File Offset: 0x00005048
		internal Barracks(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
