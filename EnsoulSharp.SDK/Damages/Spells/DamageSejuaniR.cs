using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A4 RID: 676
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sejuani", SpellSlot.R, 0)]
	public class DamageSejuaniR : DamageSpell
	{
		// Token: 0x06000E05 RID: 3589 RVA: 0x00040D6D File Offset: 0x0003EF6D
		public DamageSejuaniR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x00040D83 File Offset: 0x0003EF83
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSejuaniR.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007B3 RID: 1971
		private static readonly double[] damages = new double[]
		{
			125.0,
			150.0,
			175.0
		};
	}
}
