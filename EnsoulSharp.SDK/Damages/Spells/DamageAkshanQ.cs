using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000EE RID: 238
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Akshan", SpellSlot.Q, 0)]
	public class DamageAkshanQ : DamageSpell
	{
		// Token: 0x060008DA RID: 2266 RVA: 0x00037C10 File Offset: 0x00035E10
		public DamageAkshanQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00037C28 File Offset: 0x00035E28
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageAkshanQ.damages[level] + 0.8 * (double)source.TotalAttackDamage;
			if (target.Type != GameObjectType.AIHeroClient)
			{
				return DamageAkshanQ.damagePercents[level] * num;
			}
			return num;
		}

		// Token: 0x040005CD RID: 1485
		private static readonly double[] damages = new double[]
		{
			5.0,
			25.0,
			45.0,
			65.0,
			85.0
		};

		// Token: 0x040005CE RID: 1486
		private static readonly double[] damagePercents = new double[]
		{
			0.4,
			0.475,
			0.55,
			0.625,
			0.7
		};
	}
}
