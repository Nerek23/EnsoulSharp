using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000FE RID: 254
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KSante", SpellSlot.Q, 0)]
	public class DamageKSanteQ : DamageSpell
	{
		// Token: 0x06000909 RID: 2313 RVA: 0x000382A8 File Offset: 0x000364A8
		public DamageKSanteQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x000382BE File Offset: 0x000364BE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKSanteQ.damages[level] + 0.4 * (double)source.TotalAttackDamage + 0.3 * (double)source.BonusArmor + 0.3 * (double)source.PercentBonusMagicPenetrationMod;
		}

		// Token: 0x040005DF RID: 1503
		private static readonly double[] damages = new double[]
		{
			50.0,
			75.0,
			100.0,
			125.0,
			150.0
		};
	}
}
