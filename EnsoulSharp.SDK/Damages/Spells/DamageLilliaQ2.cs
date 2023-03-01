using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000208 RID: 520
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lillia", SpellSlot.Q, 1)]
	public class DamageLilliaQ2 : DamageSpell
	{
		// Token: 0x06000C33 RID: 3123 RVA: 0x0003DBC4 File Offset: 0x0003BDC4
		public DamageLilliaQ2()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.True;
			base.Stage = 1;
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0003DBE1 File Offset: 0x0003BDE1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLilliaQ2.damages[level] + 0.4 * (double)source.TotalMagicalDamage + source.CalculateMagicDamage(target, DamageLilliaQ2.damages[level]);
		}

		// Token: 0x0400070C RID: 1804
		private static readonly double[] damages = new double[]
		{
			40.0,
			50.0,
			60.0,
			70.0,
			80.0
		};
	}
}
