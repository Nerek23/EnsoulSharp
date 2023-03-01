using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200014A RID: 330
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.R, 0)]
	public class DamageCamilleR : DamageSpell
	{
		// Token: 0x060009EC RID: 2540 RVA: 0x00039C2D File Offset: 0x00037E2D
		public DamageCamilleR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00039C43 File Offset: 0x00037E43
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleR.damages[level] + DamageCamilleR.damagePercents[level] * (double)target.Health;
		}

		// Token: 0x04000636 RID: 1590
		private static readonly double[] damages = new double[]
		{
			5.0,
			10.0,
			15.0
		};

		// Token: 0x04000637 RID: 1591
		private static readonly double[] damagePercents = new double[]
		{
			0.04,
			0.06,
			0.08
		};
	}
}
