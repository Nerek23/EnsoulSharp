using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each DrawFX object.
	/// </summary>
	// Token: 0x020000F4 RID: 244
	public class DrawFX : GameObject
	{
		// Token: 0x0600057B RID: 1403 RVA: 0x00005C8C File Offset: 0x0000508C
		internal DrawFX()
		{
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00005C74 File Offset: 0x00005074
		internal DrawFX(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
