using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each DrawFX object.
	/// </summary>
	// Token: 0x020000F4 RID: 244
	public class DrawFX : GameObject
	{
		// Token: 0x06000586 RID: 1414 RVA: 0x00005D0C File Offset: 0x0000510C
		internal DrawFX()
		{
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal DrawFX(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
