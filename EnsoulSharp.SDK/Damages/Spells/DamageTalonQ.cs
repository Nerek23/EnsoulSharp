using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D9 RID: 729
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Talon", SpellSlot.Q, 0)]
	public class DamageTalonQ : DamageSpell
	{
		// Token: 0x06000EA4 RID: 3748 RVA: 0x00041F5B File Offset: 0x0004015B
		public DamageTalonQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x00041F71 File Offset: 0x00040171
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTalonQ.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x040007F0 RID: 2032
		private static readonly double[] damages = new double[]
		{
			65.0,
			85.0,
			105.0,
			125.0,
			145.0
		};
	}
}
