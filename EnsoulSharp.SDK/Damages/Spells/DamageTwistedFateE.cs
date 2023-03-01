using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002ED RID: 749
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TwistedFate", SpellSlot.E, 0)]
	public class DamageTwistedFateE : DamageSpell
	{
		// Token: 0x06000EE0 RID: 3808 RVA: 0x000426BC File Offset: 0x000408BC
		public DamageTwistedFateE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x000426D2 File Offset: 0x000408D2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTwistedFateE.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000807 RID: 2055
		private static readonly double[] damages = new double[]
		{
			65.0,
			90.0,
			115.0,
			140.0,
			165.0
		};
	}
}
