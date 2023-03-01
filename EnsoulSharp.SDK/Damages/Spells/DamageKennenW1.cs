using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F1 RID: 497
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kennen", SpellSlot.W, 1)]
	public class DamageKennenW1 : DamageSpell
	{
		// Token: 0x06000BEE RID: 3054 RVA: 0x0003D478 File Offset: 0x0003B678
		public DamageKennenW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0003D495 File Offset: 0x0003B695
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKennenW1.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006F5 RID: 1781
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
