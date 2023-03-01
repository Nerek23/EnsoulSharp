using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002DD RID: 733
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Taric", SpellSlot.E, 0)]
	public class DamageTaricE : DamageSpell
	{
		// Token: 0x06000EB0 RID: 3760 RVA: 0x0004207E File Offset: 0x0004027E
		public DamageTaricE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x00042094 File Offset: 0x00040294
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTaricE.damages[level] + 0.5 * (double)source.TotalMagicalDamage + 0.5 * (double)source.BonusArmor;
		}

		// Token: 0x040007F4 RID: 2036
		private static readonly double[] damages = new double[]
		{
			90.0,
			130.0,
			170.0,
			210.0,
			250.0
		};
	}
}
