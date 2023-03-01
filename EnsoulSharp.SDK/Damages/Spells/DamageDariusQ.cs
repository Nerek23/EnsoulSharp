using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200015E RID: 350
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Darius", SpellSlot.Q, 0)]
	public class DamageDariusQ : DamageSpell
	{
		// Token: 0x06000A32 RID: 2610 RVA: 0x0003A338 File Offset: 0x00038538
		public DamageDariusQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0003A34E File Offset: 0x0003854E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDariusQ.damages[level] + DamageDariusQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000651 RID: 1617
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};

		// Token: 0x04000652 RID: 1618
		private static readonly double[] damagePercents = new double[]
		{
			1.0,
			1.1,
			1.2,
			1.3,
			1.4
		};
	}
}
