using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000289 RID: 649
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rengar", SpellSlot.Q, 0)]
	public class DamageRengarQ : DamageSpell
	{
		// Token: 0x06000DB4 RID: 3508 RVA: 0x0004046D File Offset: 0x0003E66D
		public DamageRengarQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00040483 File Offset: 0x0003E683
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRengarQ.damages[level] + DamageRengarQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000792 RID: 1938
		private static readonly double[] damages = new double[]
		{
			30.0,
			60.0,
			90.0,
			120.0,
			150.0
		};

		// Token: 0x04000793 RID: 1939
		private static readonly double[] damagePercents = new double[]
		{
			0.0,
			0.05,
			0.1,
			0.15,
			0.2
		};
	}
}
