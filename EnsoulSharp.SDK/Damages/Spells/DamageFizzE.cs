using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000182 RID: 386
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fizz", SpellSlot.E, 0)]
	public class DamageFizzE : DamageSpell
	{
		// Token: 0x06000A9E RID: 2718 RVA: 0x0003AFD8 File Offset: 0x000391D8
		public DamageFizzE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0003AFEE File Offset: 0x000391EE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFizzE.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400067D RID: 1661
		private static readonly double[] damages = new double[]
		{
			80.0,
			130.0,
			180.0,
			230.0,
			280.0
		};
	}
}
