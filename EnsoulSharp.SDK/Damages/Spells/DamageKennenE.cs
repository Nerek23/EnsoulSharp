using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001EC RID: 492
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kennen", SpellSlot.E, 0)]
	public class DamageKennenE : DamageSpell
	{
		// Token: 0x06000BDF RID: 3039 RVA: 0x0003D2DE File Offset: 0x0003B4DE
		public DamageKennenE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0003D2F4 File Offset: 0x0003B4F4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKennenE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006EF RID: 1775
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
