using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000203 RID: 515
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("LeeSin", SpellSlot.E, 0)]
	public class DamageLeeSinE : DamageSpell
	{
		// Token: 0x06000C24 RID: 3108 RVA: 0x0003DA3F File Offset: 0x0003BC3F
		public DamageLeeSinE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x0003DA55 File Offset: 0x0003BC55
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeeSinE.damages[level] + (double)(1f * source.TotalAttackDamage);
		}

		// Token: 0x04000707 RID: 1799
		private static readonly double[] damages = new double[]
		{
			35.0,
			65.0,
			95.0,
			125.0,
			155.0
		};
	}
}
