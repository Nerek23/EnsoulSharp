using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000253 RID: 595
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nunu", SpellSlot.R, 0)]
	public class DamageNunuR : DamageSpell
	{
		// Token: 0x06000D13 RID: 3347 RVA: 0x0003F395 File Offset: 0x0003D595
		public DamageNunuR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0003F3AB File Offset: 0x0003D5AB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNunuR.damages[level] + (double)(3f * source.TotalMagicalDamage);
		}

		// Token: 0x0400075A RID: 1882
		private static readonly double[] damages = new double[]
		{
			625.0,
			950.0,
			1275.0
		};
	}
}
