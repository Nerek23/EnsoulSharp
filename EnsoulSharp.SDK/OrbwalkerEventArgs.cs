using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200003E RID: 62
	public class OrbwalkerEventArgs : EventArgs
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00012074 File Offset: 0x00010274
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0001207C File Offset: 0x0001027C
		public AttackableUnit Target { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00012085 File Offset: 0x00010285
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x0001208D File Offset: 0x0001028D
		public string OrbwalkerName { get; set; }
	}
}
