using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D1 RID: 465
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Karma", SpellSlot.W, 0)]
	public class DamageKarmaW : DamageSpell
	{
		// Token: 0x06000B90 RID: 2960 RVA: 0x0003C980 File Offset: 0x0003AB80
		public DamageKarmaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0003C996 File Offset: 0x0003AB96
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKarmaW.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006D4 RID: 1748
		private static readonly double[] damages = new double[]
		{
			40.0,
			65.0,
			90.0,
			115.0,
			140.0
		};
	}
}
