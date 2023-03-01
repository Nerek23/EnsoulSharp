using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000148 RID: 328
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Camille", SpellSlot.W, 1)]
	public class DamageCamilleW1 : DamageSpell
	{
		// Token: 0x060009E6 RID: 2534 RVA: 0x00039B82 File Offset: 0x00037D82
		public DamageCamilleW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00039B9F File Offset: 0x00037D9F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCamilleW1.damages[level] + 0.025 * (double)source.GetBonusPhysicalDamage() / 100.0 * (double)target.MaxHealth;
		}

		// Token: 0x04000634 RID: 1588
		private static readonly double[] damages = new double[]
		{
			0.05,
			0.055,
			0.06,
			0.065,
			0.07
		};
	}
}
