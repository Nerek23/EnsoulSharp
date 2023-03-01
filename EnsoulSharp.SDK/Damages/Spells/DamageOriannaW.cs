using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000259 RID: 601
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Orianna", SpellSlot.W, 0)]
	public class DamageOriannaW : DamageSpell
	{
		// Token: 0x06000D25 RID: 3365 RVA: 0x0003F543 File Offset: 0x0003D743
		public DamageOriannaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x0003F559 File Offset: 0x0003D759
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOriannaW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000760 RID: 1888
		private static readonly double[] damages = new double[]
		{
			60.0,
			105.0,
			150.0,
			195.0,
			240.0
		};
	}
}
