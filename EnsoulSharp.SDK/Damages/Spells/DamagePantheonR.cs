using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000266 RID: 614
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pantheon", SpellSlot.R, 0)]
	public class DamagePantheonR : DamageSpell
	{
		// Token: 0x06000D4C RID: 3404 RVA: 0x0003F94D File Offset: 0x0003DB4D
		public DamagePantheonR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x0003F963 File Offset: 0x0003DB63
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePantheonR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400076E RID: 1902
		private static readonly double[] damages = new double[]
		{
			300.0,
			500.0,
			700.0
		};
	}
}
