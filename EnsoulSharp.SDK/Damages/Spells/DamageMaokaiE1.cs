using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200022A RID: 554
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Maokai", SpellSlot.E, 1)]
	public class DamageMaokaiE1 : DamageSpell
	{
		// Token: 0x06000C99 RID: 3225 RVA: 0x0003E667 File Offset: 0x0003C867
		public DamageMaokaiE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x0003E684 File Offset: 0x0003C884
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMaokaiE1.damages[level] + 0.8 * (double)source.TotalMagicalDamage + (double)(0.12f * source.BonusHealth);
		}

		// Token: 0x0400072F RID: 1839
		private static readonly double[] damages = new double[]
		{
			110.0,
			160.0,
			210.0,
			260.0,
			310.0
		};
	}
}
