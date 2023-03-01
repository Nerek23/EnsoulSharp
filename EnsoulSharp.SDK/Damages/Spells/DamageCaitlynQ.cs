using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200014C RID: 332
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Caitlyn", SpellSlot.Q, 0)]
	public class DamageCaitlynQ : DamageSpell
	{
		// Token: 0x060009F2 RID: 2546 RVA: 0x00039CD3 File Offset: 0x00037ED3
		public DamageCaitlynQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00039CE9 File Offset: 0x00037EE9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCaitlynQ.damages[level] + DamageCaitlynQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000639 RID: 1593
		private static readonly double[] damages = new double[]
		{
			50.0,
			90.0,
			130.0,
			170.0,
			210.0
		};

		// Token: 0x0400063A RID: 1594
		private static readonly double[] damagePercents = new double[]
		{
			1.25,
			1.45,
			1.65,
			1.85,
			2.05
		};
	}
}
