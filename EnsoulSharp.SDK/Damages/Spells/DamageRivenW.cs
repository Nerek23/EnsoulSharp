using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000298 RID: 664
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Riven", SpellSlot.W, 0)]
	public class DamageRivenW : DamageSpell
	{
		// Token: 0x06000DE1 RID: 3553 RVA: 0x000409BE File Offset: 0x0003EBBE
		public DamageRivenW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x000409D4 File Offset: 0x0003EBD4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRivenW.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x040007A7 RID: 1959
		private static readonly double[] damages = new double[]
		{
			65.0,
			95.0,
			125.0,
			155.0,
			185.0
		};
	}
}
