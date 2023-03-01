using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000340 RID: 832
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zac", SpellSlot.Q, 0)]
	public class DamageZacQ : DamageSpell
	{
		// Token: 0x06000FD9 RID: 4057 RVA: 0x00044234 File Offset: 0x00042434
		public DamageZacQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x0004424A File Offset: 0x0004244A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZacQ.damages[level] + 0.3 * (double)source.TotalMagicalDamage + 0.04 * (double)source.MaxHealth;
		}

		// Token: 0x04000864 RID: 2148
		private static readonly double[] damages = new double[]
		{
			40.0,
			55.0,
			70.0,
			85.0,
			100.0
		};
	}
}
