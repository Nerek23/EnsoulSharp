using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B7 RID: 695
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sion", SpellSlot.Q, 1)]
	public class DamageSionQ1 : DamageSpell
	{
		// Token: 0x06000E3E RID: 3646 RVA: 0x00041493 File Offset: 0x0003F693
		public DamageSionQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x000414B0 File Offset: 0x0003F6B0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSionQ1.damages[level] + DamageSionQ1.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x040007CB RID: 1995
		private static readonly double[] damages = new double[]
		{
			90.0,
			155.0,
			220.0,
			285.0,
			350.0
		};

		// Token: 0x040007CC RID: 1996
		private static readonly double[] damagePercents = new double[]
		{
			0.27,
			0.315,
			0.36,
			0.405,
			0.45
		};
	}
}
