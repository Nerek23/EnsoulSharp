using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002AF RID: 687
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shyvana", SpellSlot.E, 0)]
	public class DamageShyvanaE : DamageSpell
	{
		// Token: 0x06000E26 RID: 3622 RVA: 0x000411F7 File Offset: 0x0003F3F7
		public DamageShyvanaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x0004120D File Offset: 0x0003F40D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShyvanaE.damages[level] + 0.4 * (double)source.TotalAttackDamage + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007C1 RID: 1985
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
