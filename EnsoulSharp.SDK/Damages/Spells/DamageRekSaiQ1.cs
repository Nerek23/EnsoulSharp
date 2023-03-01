using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200027B RID: 635
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("RekSai", SpellSlot.Q, 1)]
	public class DamageRekSaiQ1 : DamageSpell
	{
		// Token: 0x06000D8A RID: 3466 RVA: 0x0003FFAE File Offset: 0x0003E1AE
		public DamageRekSaiQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x0003FFCB File Offset: 0x0003E1CB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRekSaiQ1.damages[level] + 0.5 * (double)source.GetBonusPhysicalDamage() + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000783 RID: 1923
		private static readonly double[] damages = new double[]
		{
			60.0,
			95.0,
			130.0,
			165.0,
			200.0
		};
	}
}
