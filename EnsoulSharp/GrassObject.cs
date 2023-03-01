using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each GrassObject object.
	/// </summary>
	// Token: 0x02000139 RID: 313
	public class GrassObject : GameObject
	{
		// Token: 0x06000627 RID: 1575 RVA: 0x00005C8C File Offset: 0x0000508C
		internal GrassObject()
		{
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00005C74 File Offset: 0x00005074
		internal GrassObject(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
