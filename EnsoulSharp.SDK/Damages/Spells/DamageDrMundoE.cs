using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F6 RID: 246
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("DrMundo", SpellSlot.E, 0)]
	public class DamageDrMundoE : DamageSpell
	{
		// Token: 0x060008F1 RID: 2289 RVA: 0x00037F0F File Offset: 0x0003610F
		public DamageDrMundoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00037F28 File Offset: 0x00036128
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = Math.Min(Math.Round((double)(100f - source.HealthPercent)), 40.0);
			return Math.Min(DamageDrMundoE.basicdamages[Math.Min(level, 4)] * (1.0 + num * 0.015), DamageDrMundoE.maxdamages[Math.Min(level, 4)]);
		}

		// Token: 0x040005D6 RID: 1494
		private static readonly double[] basicdamages = new double[]
		{
			15.0,
			20.0,
			25.0,
			30.0,
			35.0
		};

		// Token: 0x040005D7 RID: 1495
		private static readonly double[] maxdamages = new double[]
		{
			25.0,
			30.0,
			35.0,
			40.0,
			45.0
		};
	}
}
