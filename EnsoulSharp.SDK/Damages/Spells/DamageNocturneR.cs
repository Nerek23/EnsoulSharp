using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200024F RID: 591
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nocturne", SpellSlot.R, 0)]
	public class DamageNocturneR : DamageSpell
	{
		// Token: 0x06000D07 RID: 3335 RVA: 0x0003F229 File Offset: 0x0003D429
		public DamageNocturneR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0003F23F File Offset: 0x0003D43F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNocturneR.damages[level] + 1.2 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000755 RID: 1877
		private static readonly double[] damages = new double[]
		{
			150.0,
			275.0,
			400.0
		};
	}
}
