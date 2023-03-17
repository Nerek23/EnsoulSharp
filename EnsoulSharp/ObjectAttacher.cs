using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each ObjectAttacher object.
	/// </summary>
	// Token: 0x02000160 RID: 352
	public class ObjectAttacher : GameObject
	{
		// Token: 0x0600069F RID: 1695 RVA: 0x00005D0C File Offset: 0x0000510C
		internal ObjectAttacher()
		{
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00005CF4 File Offset: 0x000050F4
		internal ObjectAttacher(uint networkId, uint index) : base(networkId, index)
		{
		}
	}
}
