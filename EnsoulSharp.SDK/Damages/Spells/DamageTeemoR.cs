using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E3 RID: 739
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Teemo", SpellSlot.R, 0)]
	public class DamageTeemoR : DamageSpell
	{
		// Token: 0x06000EC2 RID: 3778 RVA: 0x0004238C File Offset: 0x0004058C
		public DamageTeemoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x000423A2 File Offset: 0x000405A2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTeemoR.damages[level] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007FB RID: 2043
		private static readonly double[] damages = new double[]
		{
			200.0,
			325.0,
			450.0
		};
	}
}
