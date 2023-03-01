using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000139 RID: 313
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Azir", SpellSlot.W, 0)]
	public class DamageAzirW : DamageSpell
	{
		// Token: 0x060009BA RID: 2490 RVA: 0x0003974A File Offset: 0x0003794A
		public DamageAzirW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00039760 File Offset: 0x00037960
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAzirW.damages[Math.Min(source.Level - 1, 17)] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000626 RID: 1574
		private static readonly double[] damages = new double[]
		{
			50.0,
			52.0,
			54.0,
			56.0,
			58.0,
			60.0,
			62.0,
			65.0,
			70.0,
			75.0,
			80.0,
			90.0,
			100.0,
			110.0,
			120.0,
			130.0,
			140.0,
			150.0
		};
	}
}
