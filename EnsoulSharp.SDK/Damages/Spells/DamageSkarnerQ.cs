using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002BD RID: 701
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Skarner", SpellSlot.Q, 0)]
	public class DamageSkarnerQ : DamageSpell
	{
		// Token: 0x06000E50 RID: 3664 RVA: 0x000416D1 File Offset: 0x0003F8D1
		public DamageSkarnerQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x000416E7 File Offset: 0x0003F8E7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSkarnerQ.damages[level] * (double)target.MaxHealth + 0.2 * (double)source.TotalAttackDamage;
		}

		// Token: 0x040007D4 RID: 2004
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
