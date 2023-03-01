using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E2 RID: 738
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Teemo", SpellSlot.Q, 0)]
	public class DamageTeemoQ : DamageSpell
	{
		// Token: 0x06000EBF RID: 3775 RVA: 0x00042343 File Offset: 0x00040543
		public DamageTeemoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00042359 File Offset: 0x00040559
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTeemoQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007FA RID: 2042
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
