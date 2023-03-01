using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000294 RID: 660
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Senna", SpellSlot.R, 0)]
	public class DamageSennaR : DamageSpell
	{
		// Token: 0x06000DD5 RID: 3541 RVA: 0x00040806 File Offset: 0x0003EA06
		public DamageSennaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x0004081C File Offset: 0x0003EA1C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSennaR.damages[level] + 1.15 * (double)source.GetBonusAaDamage() + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007A1 RID: 1953
		private static readonly double[] damages = new double[]
		{
			250.0,
			400.0,
			550.0
		};
	}
}
