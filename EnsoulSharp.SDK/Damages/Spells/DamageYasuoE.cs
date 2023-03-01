using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000334 RID: 820
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yasuo", SpellSlot.E, 0)]
	public class DamageYasuoE : DamageSpell
	{
		// Token: 0x06000FB5 RID: 4021 RVA: 0x00043E49 File Offset: 0x00042049
		public DamageYasuoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x00043E5F File Offset: 0x0004205F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYasuoE.damages[level] + 0.2 * (double)source.GetBonusPhysicalDamage() + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000856 RID: 2134
		private static readonly double[] damages = new double[]
		{
			60.0,
			70.0,
			80.0,
			90.0,
			100.0
		};
	}
}
