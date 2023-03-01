using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000190 RID: 400
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Garen", SpellSlot.R, 0)]
	public class DamageGarenR : DamageSpell
	{
		// Token: 0x06000AC8 RID: 2760 RVA: 0x0003B439 File Offset: 0x00039639
		public DamageGarenR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0003B44F File Offset: 0x0003964F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGarenR.damages[level] + DamageGarenR.damagePercents[level] * (double)(target.MaxHealth - target.Health);
		}

		// Token: 0x0400068D RID: 1677
		private static readonly double[] damages = new double[]
		{
			150.0,
			300.0,
			450.0
		};

		// Token: 0x0400068E RID: 1678
		private static readonly double[] damagePercents = new double[]
		{
			0.25,
			0.3,
			0.35
		};
	}
}
