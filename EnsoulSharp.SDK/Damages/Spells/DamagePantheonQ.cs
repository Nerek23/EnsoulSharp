using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000265 RID: 613
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pantheon", SpellSlot.Q, 0)]
	public class DamagePantheonQ : DamageSpell
	{
		// Token: 0x06000D49 RID: 3401 RVA: 0x0003F904 File Offset: 0x0003DB04
		public DamagePantheonQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x0003F91A File Offset: 0x0003DB1A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePantheonQ.damages[level] + 1.15 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400076D RID: 1901
		private static readonly double[] damages = new double[]
		{
			70.0,
			100.0,
			130.0,
			160.0,
			190.0
		};
	}
}
