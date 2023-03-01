using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000188 RID: 392
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Galio", SpellSlot.E, 0)]
	public class DamageGalioE : DamageSpell
	{
		// Token: 0x06000AB0 RID: 2736 RVA: 0x0003B1A6 File Offset: 0x000393A6
		public DamageGalioE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0003B1BC File Offset: 0x000393BC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGalioE.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000683 RID: 1667
		private static readonly double[] damages = new double[]
		{
			90.0,
			130.0,
			170.0,
			210.0,
			250.0
		};
	}
}
