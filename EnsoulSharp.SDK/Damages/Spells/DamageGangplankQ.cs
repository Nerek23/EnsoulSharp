using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200018C RID: 396
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gangplank", SpellSlot.Q, 0)]
	public class DamageGangplankQ : DamageSpell
	{
		// Token: 0x06000ABC RID: 2748 RVA: 0x0003B2CA File Offset: 0x000394CA
		public DamageGangplankQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0003B2E0 File Offset: 0x000394E0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGangplankQ.damages[level] + (double)(1f * source.TotalAttackDamage);
		}

		// Token: 0x04000687 RID: 1671
		private static readonly double[] damages = new double[]
		{
			10.0,
			40.0,
			70.0,
			100.0,
			130.0
		};
	}
}
