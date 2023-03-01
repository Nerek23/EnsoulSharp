using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000268 RID: 616
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Poppy", SpellSlot.E, 0)]
	public class DamagePoppyE : DamageSpell
	{
		// Token: 0x06000D52 RID: 3410 RVA: 0x0003F9D7 File Offset: 0x0003DBD7
		public DamagePoppyE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x0003F9ED File Offset: 0x0003DBED
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePoppyE.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000770 RID: 1904
		private static readonly double[] damages = new double[]
		{
			60.0,
			80.0,
			100.0,
			120.0,
			140.0
		};
	}
}
