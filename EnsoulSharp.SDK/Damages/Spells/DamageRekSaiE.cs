using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000278 RID: 632
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("RekSai", SpellSlot.E, 0)]
	public class DamageRekSaiE : DamageSpell
	{
		// Token: 0x06000D81 RID: 3457 RVA: 0x0003FECC File Offset: 0x0003E0CC
		public DamageRekSaiE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x0003FEE2 File Offset: 0x0003E0E2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRekSaiE.damages[level] + 0.85 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000780 RID: 1920
		private static readonly double[] damages = new double[]
		{
			50.0,
			60.0,
			70.0,
			80.0,
			90.0
		};
	}
}
