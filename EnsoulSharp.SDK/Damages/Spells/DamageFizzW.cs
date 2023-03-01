using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000187 RID: 391
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fizz", SpellSlot.W, 0)]
	public class DamageFizzW : DamageSpell
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x0003B15D File Offset: 0x0003935D
		public DamageFizzW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0003B173 File Offset: 0x00039373
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFizzW.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000682 RID: 1666
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};
	}
}
