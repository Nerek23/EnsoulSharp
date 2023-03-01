using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200017E RID: 382
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiddlesticks", SpellSlot.Q, 0)]
	public class DamageFiddlesticksQ : DamageSpell
	{
		// Token: 0x06000A92 RID: 2706 RVA: 0x0003AE92 File Offset: 0x00039092
		public DamageFiddlesticksQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0003AEA8 File Offset: 0x000390A8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageFiddlesticksQ.damages[level] + 0.02 * (double)source.TotalMagicalDamage / 100.0) * (double)target.Health;
		}

		// Token: 0x04000678 RID: 1656
		private static readonly double[] damages = new double[]
		{
			0.06,
			0.07,
			0.08,
			0.09,
			0.1
		};
	}
}
