using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000053 RID: 83
	public class LastCastPacketSentEntry
	{
		// Token: 0x0600034A RID: 842 RVA: 0x00018E4D File Offset: 0x0001704D
		public LastCastPacketSentEntry(SpellSlot slot, int tick, int targetNetworkId)
		{
			this.Slot = slot;
			this.Tick = tick;
			this.TargetNetworkId = targetNetworkId;
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600034B RID: 843 RVA: 0x00018E6A File Offset: 0x0001706A
		public int Tick { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00018E72 File Offset: 0x00017072
		public int TargetNetworkId { get; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00018E7A File Offset: 0x0001707A
		public SpellSlot Slot { get; }
	}
}
