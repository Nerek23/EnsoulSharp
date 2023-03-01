using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200033B RID: 827
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zeri", SpellSlot.W, 0)]
	public class DamageZeriW : DamageSpell
	{
		// Token: 0x06000FCA RID: 4042 RVA: 0x00044088 File Offset: 0x00042288
		public DamageZeriW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x0004409E File Offset: 0x0004229E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZeriW.damage[level] + 1.3 * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400085E RID: 2142
		private static readonly double[] damage = new double[]
		{
			20.0,
			60.0,
			100.0,
			140.0,
			180.0
		};
	}
}
