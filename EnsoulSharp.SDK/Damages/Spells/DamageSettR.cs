using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000291 RID: 657
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sett", SpellSlot.R, 0)]
	public class DamageSettR : DamageSpell
	{
		// Token: 0x06000DCC RID: 3532 RVA: 0x00040705 File Offset: 0x0003E905
		public DamageSettR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x0004071B File Offset: 0x0003E91B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSettR.damages[level] + 1.2 * (double)source.GetBonusAaDamage() + DamageSettR.damagePercents[level] * (double)target.BonusHealth;
		}

		// Token: 0x0400079D RID: 1949
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};

		// Token: 0x0400079E RID: 1950
		private static readonly double[] damagePercents = new double[]
		{
			0.4,
			0.5,
			0.6
		};
	}
}
