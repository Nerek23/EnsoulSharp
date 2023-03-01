using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200026A RID: 618
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Poppy", SpellSlot.Q, 0)]
	public class DamagePoppyQ : DamageSpell
	{
		// Token: 0x06000D58 RID: 3416 RVA: 0x0003FA6C File Offset: 0x0003DC6C
		public DamagePoppyQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x0003FA82 File Offset: 0x0003DC82
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePoppyQ.damages[level] + 0.89 * (double)source.GetBonusPhysicalDamage() + 0.08 * (double)target.MaxHealth;
		}

		// Token: 0x04000772 RID: 1906
		private static readonly double[] damages = new double[]
		{
			40.0,
			60.0,
			80.0,
			100.0,
			120.0
		};
	}
}
