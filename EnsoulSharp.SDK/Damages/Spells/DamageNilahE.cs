using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000101 RID: 257
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nilah", SpellSlot.E, 0)]
	public class DamageNilahE : DamageSpell
	{
		// Token: 0x06000912 RID: 2322 RVA: 0x000383B4 File Offset: 0x000365B4
		public DamageNilahE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x000383CA File Offset: 0x000365CA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNilahE.damages[level] + (double)(0.2f * source.TotalAttackDamage);
		}

		// Token: 0x040005E2 RID: 1506
		private static readonly double[] damages = new double[]
		{
			65.0,
			90.0,
			115.0,
			140.0,
			165.0
		};
	}
}
