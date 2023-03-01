using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000193 RID: 403
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.Q, 0)]
	public class DamageGnarQ : DamageSpell
	{
		// Token: 0x06000AD1 RID: 2769 RVA: 0x0003B536 File Offset: 0x00039736
		public DamageGnarQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0003B54C File Offset: 0x0003974C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGnarQ.damages[level] + 1.15 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000691 RID: 1681
		private static readonly double[] damages = new double[]
		{
			5.0,
			45.0,
			85.0,
			125.0,
			165.0
		};
	}
}
