using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200003F RID: 63
	public class BeforeAttackEventArgs : OrbwalkerEventArgs
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0001209E File Offset: 0x0001029E
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x000120A6 File Offset: 0x000102A6
		public bool Process { get; set; } = true;
	}
}
