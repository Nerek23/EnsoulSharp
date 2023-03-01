using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000131 RID: 305
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aphelios", SpellSlot.R, 0)]
	public class DamageApheliosR : DamageSpell
	{
		// Token: 0x060009A2 RID: 2466 RVA: 0x000394F6 File Offset: 0x000376F6
		public DamageApheliosR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0003950C File Offset: 0x0003770C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageApheliosR.damages[level] + 0.2 * (double)source.GetBonusAaDamage() + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400061E RID: 1566
		private static readonly double[] damages = new double[]
		{
			125.0,
			175.0,
			225.0
		};
	}
}
