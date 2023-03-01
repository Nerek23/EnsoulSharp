using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200017F RID: 383
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiddlesticks", SpellSlot.W, 0)]
	public class DamageFiddlesticksW : DamageSpell
	{
		// Token: 0x06000A95 RID: 2709 RVA: 0x0003AEED File Offset: 0x000390ED
		public DamageFiddlesticksW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0003AF03 File Offset: 0x00039103
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFiddlesticksW.damages[level] + 0.0875 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000679 RID: 1657
		private static readonly double[] damages = new double[]
		{
			15.0,
			22.5,
			30.0,
			37.5,
			45.0
		};
	}
}
