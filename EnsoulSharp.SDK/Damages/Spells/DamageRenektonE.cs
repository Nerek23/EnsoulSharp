using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200027F RID: 639
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.E, 0)]
	public class DamageRenektonE : DamageSpell
	{
		// Token: 0x06000D96 RID: 3478 RVA: 0x0004011F File Offset: 0x0003E31F
		public DamageRenektonE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00040135 File Offset: 0x0003E335
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonE.damages[level] + 0.9 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000788 RID: 1928
		private static readonly double[] damages = new double[]
		{
			40.0,
			70.0,
			100.0,
			130.0,
			160.0
		};
	}
}
