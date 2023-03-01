using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002AE RID: 686
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shyvana", SpellSlot.E, 1)]
	public class DamageShyvanaE1 : DamageSpell
	{
		// Token: 0x06000E23 RID: 3619 RVA: 0x00041135 File Offset: 0x0003F335
		public DamageShyvanaE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00041154 File Offset: 0x0003F354
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageShyvanaE1.basicdamages[level] + 0.4 * (double)source.TotalAttackDamage + 0.9 * (double)source.TotalMagicalDamage;
			double num2 = DamageShyvanaE1.extradamages[Math.Min(17, source.Level - 1)] + 0.3 * (double)source.TotalAttackDamage + 0.3 * (double)source.TotalMagicalDamage;
			return num + num2;
		}

		// Token: 0x040007BF RID: 1983
		private static readonly double[] basicdamages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};

		// Token: 0x040007C0 RID: 1984
		private static readonly double[] extradamages = new double[]
		{
			75.0,
			75.0,
			75.0,
			75.0,
			75.0,
			75.0,
			80.0,
			85.0,
			90.0,
			95.0,
			100.0,
			105.0,
			110.0,
			115.0,
			120.0,
			125.0,
			130.0,
			135.0
		};
	}
}
