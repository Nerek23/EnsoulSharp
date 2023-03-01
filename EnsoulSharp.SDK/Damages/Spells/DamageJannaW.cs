using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B5 RID: 437
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Janna", SpellSlot.W, 0)]
	public class DamageJannaW : DamageSpell
	{
		// Token: 0x06000B3D RID: 2877 RVA: 0x0003BF8A File Offset: 0x0003A18A
		public DamageJannaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0003BFA0 File Offset: 0x0003A1A0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJannaW.damage[level] + 0.5 * (double)source.TotalMagicalDamage + ((source.Level >= 10) ? 0.35 : 0.25) * (double)source.MoveSpeed;
		}

		// Token: 0x040006B2 RID: 1714
		private static readonly double[] damage = new double[]
		{
			70.0,
			100.0,
			130.0,
			160.0,
			190.0
		};
	}
}
