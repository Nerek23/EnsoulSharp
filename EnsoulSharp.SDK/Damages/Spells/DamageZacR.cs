using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000341 RID: 833
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zac", SpellSlot.R, 0)]
	public class DamageZacR : DamageSpell
	{
		// Token: 0x06000FDC RID: 4060 RVA: 0x0004428F File Offset: 0x0004248F
		public DamageZacR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x000442A5 File Offset: 0x000424A5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZacR.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000865 RID: 2149
		private static readonly double[] damages = new double[]
		{
			140.0,
			210.0,
			280.0
		};
	}
}
