using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000165 RID: 357
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Draven", SpellSlot.E, 0)]
	public class DamageDravenE : DamageSpell
	{
		// Token: 0x06000A47 RID: 2631 RVA: 0x0003A588 File Offset: 0x00038788
		public DamageDravenE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0003A59E File Offset: 0x0003879E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDravenE.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000659 RID: 1625
		private static readonly double[] damages = new double[]
		{
			75.0,
			110.0,
			145.0,
			180.0,
			215.0
		};
	}
}
