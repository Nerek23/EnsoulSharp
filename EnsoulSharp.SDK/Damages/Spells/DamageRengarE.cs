using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000285 RID: 645
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rengar", SpellSlot.E, 0)]
	public class DamageRengarE : DamageSpell
	{
		// Token: 0x06000DA8 RID: 3496 RVA: 0x00040307 File Offset: 0x0003E507
		public DamageRengarE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x0004031D File Offset: 0x0003E51D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRengarE.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400078E RID: 1934
		private static readonly double[] damages = new double[]
		{
			55.0,
			100.0,
			145.0,
			190.0,
			235.0
		};
	}
}
