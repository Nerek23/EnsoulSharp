using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000167 RID: 359
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Draven", SpellSlot.R, 0)]
	public class DamageDravenR : DamageSpell
	{
		// Token: 0x06000A4D RID: 2637 RVA: 0x0003A62E File Offset: 0x0003882E
		public DamageDravenR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0003A644 File Offset: 0x00038844
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDravenR.damages[level] + DamageDravenR.damagePercents[level] * (double)source.GetBonusAaDamage();
		}

		// Token: 0x0400065C RID: 1628
		private static readonly double[] damages = new double[]
		{
			175.0,
			275.0,
			375.0
		};

		// Token: 0x0400065D RID: 1629
		private static readonly double[] damagePercents = new double[]
		{
			1.1,
			1.3,
			1.5
		};
	}
}
