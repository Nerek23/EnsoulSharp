using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000335 RID: 821
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yasuo", SpellSlot.Q, 0)]
	public class DamageYasuoQ : DamageSpell
	{
		// Token: 0x06000FB8 RID: 4024 RVA: 0x00043EA4 File Offset: 0x000420A4
		public DamageYasuoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x00043EBA File Offset: 0x000420BA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYasuoQ.damage[level] + 1.05 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000857 RID: 2135
		private static readonly double[] damage = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
