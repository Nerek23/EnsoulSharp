using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200024A RID: 586
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nidalee", SpellSlot.Q, 1)]
	public class DamageNidaleeQ1 : DamageSpell
	{
		// Token: 0x06000CF8 RID: 3320 RVA: 0x0003F014 File Offset: 0x0003D214
		public DamageNidaleeQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x0003F034 File Offset: 0x0003D234
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			int num = source.Spellbook.GetSpell(SpellSlot.R).Level;
			if (num == 0)
			{
				num = 1;
			}
			return (DamageNidaleeQ1.damages[num - 1] + 0.4 * (double)source.TotalMagicalDamage + 0.75 * (double)source.TotalAttackDamage) * ((double)((target.MaxHealth - target.Health) / target.MaxHealth) * DamageNidaleeQ1.damagePercents[num - 1] + 1.0);
		}

		// Token: 0x0400074F RID: 1871
		private static readonly double[] damages = new double[]
		{
			5.0,
			30.0,
			55.0,
			80.0
		};

		// Token: 0x04000750 RID: 1872
		private static readonly double[] damagePercents = new double[]
		{
			1.0,
			1.25,
			1.5,
			1.75
		};
	}
}
