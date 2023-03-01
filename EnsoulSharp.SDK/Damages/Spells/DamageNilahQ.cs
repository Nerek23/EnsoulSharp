using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000102 RID: 258
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nilah", SpellSlot.Q, 0)]
	public class DamageNilahQ : DamageSpell
	{
		// Token: 0x06000915 RID: 2325 RVA: 0x000383F9 File Offset: 0x000365F9
		public DamageNilahQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0003840F File Offset: 0x0003660F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNilahQ.damages[level] + DamageNilahQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x040005E3 RID: 1507
		private static readonly double[] damages = new double[]
		{
			5.0,
			10.0,
			15.0,
			20.0,
			25.0
		};

		// Token: 0x040005E4 RID: 1508
		private static readonly double[] damagePercents = new double[]
		{
			0.9,
			1.0,
			1.1,
			1.2,
			1.3
		};
	}
}
