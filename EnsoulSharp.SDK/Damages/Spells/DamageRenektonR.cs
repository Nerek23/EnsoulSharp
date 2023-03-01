using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000282 RID: 642
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.R, 0)]
	public class DamageRenektonR : DamageSpell
	{
		// Token: 0x06000D9F RID: 3487 RVA: 0x000401F7 File Offset: 0x0003E3F7
		public DamageRenektonR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x0004020D File Offset: 0x0003E40D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonR.damages[level] + 0.1 * (double)source.TotalMagicalDamage + 0.1 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x0400078B RID: 1931
		private static readonly double[] damages = new double[]
		{
			50.0,
			100.0,
			150.0
		};
	}
}
