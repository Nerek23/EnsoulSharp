using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200017D RID: 381
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiddlesticks", SpellSlot.R, 0)]
	public class DamageFiddlesticksR : DamageSpell
	{
		// Token: 0x06000A8F RID: 2703 RVA: 0x0003AE3F File Offset: 0x0003903F
		public DamageFiddlesticksR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0003AE55 File Offset: 0x00039055
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFiddlesticksR.damages[level] + 0.1125 * (double)source.TotalMagicalDamage * 20.0;
		}

		// Token: 0x04000677 RID: 1655
		private static readonly double[] damages = new double[]
		{
			31.25,
			56.25,
			81.25
		};
	}
}
