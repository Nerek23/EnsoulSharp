using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000303 RID: 771
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viego", SpellSlot.R, 0)]
	public class DamageViegoR : DamageSpell
	{
		// Token: 0x06000F22 RID: 3874 RVA: 0x00042E35 File Offset: 0x00041035
		public DamageViegoR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x00042E4C File Offset: 0x0004104C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = 1.2 * (double)source.GetBonusAaDamage() * (1.0 + 0.1 * Math.Floor((double)(source.Crit * 10f)));
			double num2 = DamageViegoR.damages[level] + 0.05 * Math.Floor((double)(source.GetBonusAaDamage() / 100f));
			return num + num2;
		}

		// Token: 0x04000821 RID: 2081
		private static readonly double[] damages = new double[]
		{
			0.12,
			0.16,
			0.2
		};
	}
}
