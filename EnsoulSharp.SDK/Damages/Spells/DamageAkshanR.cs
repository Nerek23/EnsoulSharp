using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000ED RID: 237
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akshan", SpellSlot.R, 0)]
	public class DamageAkshanR : DamageSpell
	{
		// Token: 0x060008D7 RID: 2263 RVA: 0x00037B81 File Offset: 0x00035D81
		public DamageAkshanR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00037B98 File Offset: 0x00035D98
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageAkshanR.damages[level] + 0.1 * (double)source.GetTotalAaDamage();
			float num2 = 1f + (100f - target.HealthPercent) * 0.03f;
			return num * (double)num2 * DamageAkshanR.damagePercents[level];
		}

		// Token: 0x040005CB RID: 1483
		private static readonly double[] damages = new double[]
		{
			20.0,
			25.0,
			30.0
		};

		// Token: 0x040005CC RID: 1484
		private static readonly double[] damagePercents = new double[]
		{
			5.0,
			6.0,
			7.0
		};
	}
}
