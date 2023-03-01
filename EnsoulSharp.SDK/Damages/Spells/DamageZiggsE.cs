using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000346 RID: 838
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ziggs", SpellSlot.E, 0)]
	public class DamageZiggsE : DamageSpell
	{
		// Token: 0x06000FEA RID: 4074 RVA: 0x00044406 File Offset: 0x00042606
		public DamageZiggsE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x0004441C File Offset: 0x0004261C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZiggsE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400086A RID: 2154
		private static readonly double[] damages = new double[]
		{
			30.0,
			70.0,
			110.0,
			150.0,
			190.0
		};
	}
}
