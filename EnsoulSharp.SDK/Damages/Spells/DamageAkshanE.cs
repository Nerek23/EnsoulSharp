using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000EC RID: 236
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akshan", SpellSlot.E, 0)]
	public class DamageAkshanE : DamageSpell
	{
		// Token: 0x060008D4 RID: 2260 RVA: 0x00037B16 File Offset: 0x00035D16
		public DamageAkshanE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00037B2C File Offset: 0x00035D2C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAkshanE.damages[level] + 0.175 * (double)source.GetBonusPhysicalDamage() + 0.3 * (double)(source.AttackSpeedMod - 1f) * 100.0;
		}

		// Token: 0x040005CA RID: 1482
		private static readonly double[] damages = new double[]
		{
			30.0,
			45.0,
			60.0,
			75.0,
			90.0
		};
	}
}
