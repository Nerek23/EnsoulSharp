using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D4 RID: 468
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karthus", SpellSlot.Q, 0)]
	public class DamageKarthusQ : DamageSpell
	{
		// Token: 0x06000B99 RID: 2969 RVA: 0x0003CA62 File Offset: 0x0003AC62
		public DamageKarthusQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0003CA78 File Offset: 0x0003AC78
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageKarthusQ.damages[level] + (double)(0.35f * source.TotalMagicalDamage);
			if (target.Type == GameObjectType.AIMinionClient && target.Team == GameObjectTeam.Neutral)
			{
				return 0.8500000238418579 * num;
			}
			return num;
		}

		// Token: 0x040006D7 RID: 1751
		private static readonly double[] damages = new double[]
		{
			45.0,
			62.5,
			80.0,
			97.5,
			115.0
		};
	}
}
