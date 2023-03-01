using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000123 RID: 291
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Amumu", SpellSlot.W, 0)]
	public class DamageAmumuW : DamageSpell
	{
		// Token: 0x06000978 RID: 2424 RVA: 0x00038F24 File Offset: 0x00037124
		public DamageAmumuW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00038F3A File Offset: 0x0003713A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAmumuW.damages[level] + (DamageAmumuW.damagePercents[level] + 0.005 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x0400060A RID: 1546
		private static readonly double[] damages = new double[]
		{
			12.0,
			16.0,
			20.0,
			24.0,
			28.0
		};

		// Token: 0x0400060B RID: 1547
		private static readonly double[] damagePercents = new double[]
		{
			0.01,
			0.0115,
			0.013,
			0.0145,
			0.016
		};
	}
}
