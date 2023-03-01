using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000244 RID: 580
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nautilus", SpellSlot.E, 0)]
	public class DamageNautilusE : DamageSpell
	{
		// Token: 0x06000CE6 RID: 3302 RVA: 0x0003EE37 File Offset: 0x0003D037
		public DamageNautilusE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x0003EE4D File Offset: 0x0003D04D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNautilusE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000749 RID: 1865
		private static readonly double[] damages = new double[]
		{
			55.0,
			85.0,
			115.0,
			145.0,
			175.0
		};
	}
}
