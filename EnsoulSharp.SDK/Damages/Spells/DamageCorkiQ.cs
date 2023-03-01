using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000157 RID: 343
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Corki", SpellSlot.Q, 0)]
	public class DamageCorkiQ : DamageSpell
	{
		// Token: 0x06000A13 RID: 2579 RVA: 0x0003A0C7 File Offset: 0x000382C7
		public DamageCorkiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0003A0DD File Offset: 0x000382DD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCorkiQ.damages[level] + 0.7 * (double)source.GetBonusPhysicalDamage() + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000645 RID: 1605
		private static readonly double[] damages = new double[]
		{
			75.0,
			120.0,
			165.0,
			210.0,
			255.0
		};
	}
}
