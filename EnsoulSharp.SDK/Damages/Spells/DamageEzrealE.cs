using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000177 RID: 375
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ezreal", SpellSlot.E, 0)]
	public class DamageEzrealE : DamageSpell
	{
		// Token: 0x06000A7D RID: 2685 RVA: 0x0003AC18 File Offset: 0x00038E18
		public DamageEzrealE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0003AC2E File Offset: 0x00038E2E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEzrealE.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage() + 0.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000670 RID: 1648
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
