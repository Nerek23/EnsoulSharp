using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200017B RID: 379
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiddlesticks", SpellSlot.E, 0)]
	public class DamageFiddlesticksE : DamageSpell
	{
		// Token: 0x06000A89 RID: 2697 RVA: 0x0003AD94 File Offset: 0x00038F94
		public DamageFiddlesticksE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0003ADAA File Offset: 0x00038FAA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFiddlesticksE.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000675 RID: 1653
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
