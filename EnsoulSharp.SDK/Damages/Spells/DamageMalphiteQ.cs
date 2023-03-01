using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000224 RID: 548
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Malphite", SpellSlot.Q, 0)]
	public class DamageMalphiteQ : DamageSpell
	{
		// Token: 0x06000C87 RID: 3207 RVA: 0x0003E46E File Offset: 0x0003C66E
		public DamageMalphiteQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x0003E484 File Offset: 0x0003C684
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMalphiteQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000729 RID: 1833
		private static readonly double[] damages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};
	}
}
