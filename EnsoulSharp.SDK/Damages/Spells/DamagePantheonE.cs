using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000263 RID: 611
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pantheon", SpellSlot.E, 0)]
	public class DamagePantheonE : DamageSpell
	{
		// Token: 0x06000D43 RID: 3395 RVA: 0x0003F85C File Offset: 0x0003DA5C
		public DamagePantheonE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0003F872 File Offset: 0x0003DA72
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePantheonE.damages[level] + 1.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400076B RID: 1899
		private static readonly double[] damages = new double[]
		{
			55.0,
			105.0,
			155.0,
			205.0,
			255.0
		};
	}
}
