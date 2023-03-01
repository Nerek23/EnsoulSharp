using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200027C RID: 636
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("RekSai", SpellSlot.R, 0)]
	public class DamageRekSaiR : DamageSpell
	{
		// Token: 0x06000D8D RID: 3469 RVA: 0x00040010 File Offset: 0x0003E210
		public DamageRekSaiR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00040026 File Offset: 0x0003E226
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRekSaiR.damages[level] + 1.75 * (double)source.GetBonusAaDamage() + DamageRekSaiR.damagePercents[level] * (double)(target.MaxHealth - target.Health);
		}

		// Token: 0x04000784 RID: 1924
		private static readonly double[] damages = new double[]
		{
			100.0,
			250.0,
			400.0
		};

		// Token: 0x04000785 RID: 1925
		private static readonly double[] damagePercents = new double[]
		{
			0.2,
			0.25,
			0.3
		};
	}
}
