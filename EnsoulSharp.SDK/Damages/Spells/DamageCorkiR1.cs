using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000159 RID: 345
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Corki", SpellSlot.R, 1)]
	public class DamageCorkiR1 : DamageSpell
	{
		// Token: 0x06000A19 RID: 2585 RVA: 0x0003A191 File Offset: 0x00038391
		public DamageCorkiR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0003A1AE File Offset: 0x000383AE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCorkiR1.damages[level] + DamageCorkiR1.damagePercents[level] * (double)source.GetTotalAaDamage() + 0.24 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000648 RID: 1608
		private static readonly double[] damages = new double[]
		{
			160.0,
			230.0,
			300.0
		};

		// Token: 0x04000649 RID: 1609
		private static readonly double[] damagePercents = new double[]
		{
			0.3,
			0.9,
			1.5
		};
	}
}
