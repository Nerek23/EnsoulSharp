using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200023A RID: 570
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Morgana", SpellSlot.R, 0)]
	public class DamageMorganaR : DamageSpell
	{
		// Token: 0x06000CC8 RID: 3272 RVA: 0x0003EB45 File Offset: 0x0003CD45
		public DamageMorganaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x0003EB5B File Offset: 0x0003CD5B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMorganaR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400073F RID: 1855
		private static readonly double[] damages = new double[]
		{
			150.0,
			225.0,
			300.0
		};
	}
}
