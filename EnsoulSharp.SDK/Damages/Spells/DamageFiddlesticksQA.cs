using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200017C RID: 380
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiddlesticks", SpellSlot.Q, 1)]
	public class DamageFiddlesticksQA : DamageSpell
	{
		// Token: 0x06000A8C RID: 2700 RVA: 0x0003ADDD File Offset: 0x00038FDD
		public DamageFiddlesticksQA()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0003ADFA File Offset: 0x00038FFA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageFiddlesticksQA.damages[level] + 0.04 * (double)source.TotalMagicalDamage / 100.0) * (double)target.Health;
		}

		// Token: 0x04000676 RID: 1654
		private static readonly double[] damages = new double[]
		{
			0.12,
			0.14,
			0.16,
			0.18,
			0.2
		};
	}
}
