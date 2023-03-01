using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001AB RID: 427
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Illaoi", SpellSlot.R, 0)]
	public class DamageIllaoiR : DamageSpell
	{
		// Token: 0x06000B1F RID: 2847 RVA: 0x0003BC65 File Offset: 0x00039E65
		public DamageIllaoiR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0003BC7B File Offset: 0x00039E7B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIllaoiR.damages[level] + 0.5 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040006A8 RID: 1704
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
