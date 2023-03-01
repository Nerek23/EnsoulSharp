using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000155 RID: 341
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Chogath", SpellSlot.W, 0)]
	public class DamageChogathW : DamageSpell
	{
		// Token: 0x06000A0D RID: 2573 RVA: 0x0003A035 File Offset: 0x00038235
		public DamageChogathW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0003A04B File Offset: 0x0003824B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageChogathW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000643 RID: 1603
		private static readonly double[] damages = new double[]
		{
			80.0,
			135.0,
			190.0,
			245.0,
			300.0
		};
	}
}
