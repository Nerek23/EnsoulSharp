using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200030C RID: 780
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Veigar", SpellSlot.R, 0)]
	public class DamageVeigarR : DamageSpell
	{
		// Token: 0x06000F3D RID: 3901 RVA: 0x00043124 File Offset: 0x00041324
		public DamageVeigarR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x0004313C File Offset: 0x0004133C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageVeigarR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
			double num2 = 0.015 * (double)(target.MaxHealth - target.Health) / (double)target.MaxHealth * 100.0;
			if (target.HealthPercent < 33f)
			{
				num2 = 2.0;
			}
			return num * num2;
		}

		// Token: 0x0400082B RID: 2091
		private static readonly double[] damages = new double[]
		{
			175.0,
			250.0,
			325.0
		};
	}
}
