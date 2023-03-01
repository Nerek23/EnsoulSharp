using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000281 RID: 641
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.Q, 1)]
	public class DamageRenektonQ1 : DamageSpell
	{
		// Token: 0x06000D9C RID: 3484 RVA: 0x000401A7 File Offset: 0x0003E3A7
		public DamageRenektonQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x000401C4 File Offset: 0x0003E3C4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonQ1.damages[level] + 1.4 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400078A RID: 1930
		private static readonly double[] damages = new double[]
		{
			90.0,
			135.0,
			180.0,
			225.0,
			270.0
		};
	}
}
