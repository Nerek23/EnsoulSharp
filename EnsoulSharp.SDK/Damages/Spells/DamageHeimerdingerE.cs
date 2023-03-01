using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A4 RID: 420
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Heimerdinger", SpellSlot.E, 0)]
	public class DamageHeimerdingerE : DamageSpell
	{
		// Token: 0x06000B04 RID: 2820 RVA: 0x0003BADB File Offset: 0x00039CDB
		public DamageHeimerdingerE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0003BAF1 File Offset: 0x00039CF1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHeimerdingerE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006A4 RID: 1700
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
