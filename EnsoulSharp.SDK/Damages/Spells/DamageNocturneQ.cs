using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200024E RID: 590
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nocturne", SpellSlot.Q, 0)]
	public class DamageNocturneQ : DamageSpell
	{
		// Token: 0x06000D04 RID: 3332 RVA: 0x0003F1E0 File Offset: 0x0003D3E0
		public DamageNocturneQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x0003F1F6 File Offset: 0x0003D3F6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNocturneQ.damage[level] + 0.85 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000754 RID: 1876
		private static readonly double[] damage = new double[]
		{
			65.0,
			110.0,
			155.0,
			200.0,
			245.0
		};
	}
}
