using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002BC RID: 700
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Skarner", SpellSlot.Q, 1)]
	public class DamageSkarnerQ2 : DamageSpell
	{
		// Token: 0x06000E4D RID: 3661 RVA: 0x00041667 File Offset: 0x0003F867
		public DamageSkarnerQ2()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x00041684 File Offset: 0x0003F884
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSkarnerQ2.damages[level] * (double)target.MaxHealth + 0.2 * (double)source.TotalAttackDamage + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007D3 RID: 2003
		private static readonly double[] damages = new double[]
		{
			0.01,
			0.015,
			0.02,
			0.025,
			0.03
		};
	}
}
