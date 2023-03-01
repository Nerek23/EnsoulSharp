using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each ObjectAttacher object.
	/// </summary>
	// Token: 0x0200015E RID: 350
	public class ObjectAttacher : GameObject
	{
		// Token: 0x06000692 RID: 1682 RVA: 0x00005C8C File Offset: 0x0000508C
		internal ObjectAttacher()
		{
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00005C74 File Offset: 0x00005074
		internal ObjectAttacher(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
