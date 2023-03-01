using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001DA RID: 474
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Katarina", SpellSlot.E, 0)]
	public class DamageKatarinaE : DamageSpell
	{
		// Token: 0x06000BAB RID: 2987 RVA: 0x0003CCB2 File Offset: 0x0003AEB2
		public DamageKatarinaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0003CCC8 File Offset: 0x0003AEC8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKatarinaE.damages[level] + 0.4 * (double)source.TotalAttackDamage + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006DE RID: 1758
		private static readonly double[] damages = new double[]
		{
			20.0,
			35.0,
			50.0,
			65.0,
			80.0
		};
	}
}
