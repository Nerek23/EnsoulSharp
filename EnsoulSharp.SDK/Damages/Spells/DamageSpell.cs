using System;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200015D RID: 349
	public class DamageSpell : IDamageSpell
	{
		// Token: 0x06000A26 RID: 2598 RVA: 0x0003A2BD File Offset: 0x000384BD
		public DamageSpell()
		{
			this.Damage = new SpellDamageDelegate(this.GetDamage);
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000A27 RID: 2599 RVA: 0x0003A2D8 File Offset: 0x000384D8
		// (set) Token: 0x06000A28 RID: 2600 RVA: 0x0003A2E0 File Offset: 0x000384E0
		public double CalculatedDamage { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000A29 RID: 2601 RVA: 0x0003A2E9 File Offset: 0x000384E9
		// (set) Token: 0x06000A2A RID: 2602 RVA: 0x0003A2F1 File Offset: 0x000384F1
		public SpellDamageDelegate Damage { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x0003A2FA File Offset: 0x000384FA
		// (set) Token: 0x06000A2C RID: 2604 RVA: 0x0003A302 File Offset: 0x00038502
		public DamageType DamageType { get; set; }

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x0003A30B File Offset: 0x0003850B
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x0003A313 File Offset: 0x00038513
		public SpellSlot Slot { get; set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000A2F RID: 2607 RVA: 0x0003A31C File Offset: 0x0003851C
		// (set) Token: 0x06000A30 RID: 2608 RVA: 0x0003A324 File Offset: 0x00038524
		public int Stage { get; set; }

		// Token: 0x06000A31 RID: 2609 RVA: 0x0003A32D File Offset: 0x0003852D
		protected virtual double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return 0.0;
		}
	}
}
