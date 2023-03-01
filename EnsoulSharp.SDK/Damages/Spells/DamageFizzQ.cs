using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000183 RID: 387
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fizz", SpellSlot.Q, 0)]
	public class DamageFizzQ : DamageSpell
	{
		// Token: 0x06000AA1 RID: 2721 RVA: 0x0003B021 File Offset: 0x00039221
		public DamageFizzQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0003B037 File Offset: 0x00039237
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFizzQ.damages[level] + (double)(1f * source.TotalAttackDamage) + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400067E RID: 1662
		private static readonly double[] damages = new double[]
		{
			10.0,
			25.0,
			40.0,
			55.0,
			70.0
		};
	}
}
