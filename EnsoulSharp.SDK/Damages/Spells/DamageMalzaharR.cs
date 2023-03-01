using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000228 RID: 552
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Malzahar", SpellSlot.R, 0)]
	public class DamageMalzaharR : DamageSpell
	{
		// Token: 0x06000C93 RID: 3219 RVA: 0x0003E592 File Offset: 0x0003C792
		public DamageMalzaharR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0003E5A8 File Offset: 0x0003C7A8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMalzaharR.damages[level] + 0.8 * (double)source.TotalMagicalDamage + 2.5 * (0.025 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x0400072D RID: 1837
		private static readonly double[] damages = new double[]
		{
			125.0,
			200.0,
			275.0
		};
	}
}
