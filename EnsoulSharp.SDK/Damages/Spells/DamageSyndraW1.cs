using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C3 RID: 707
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Syndra", SpellSlot.W, 1)]
	public class DamageSyndraW1 : DamageSpell
	{
		// Token: 0x06000E62 RID: 3682 RVA: 0x000418A1 File Offset: 0x0003FAA1
		public DamageSyndraW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x000418B8 File Offset: 0x0003FAB8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = 1.0 + (0.15 + (double)(source.TotalMagicalDamage / 100f) * 0.015);
			return source.CalculateMagicDamage(target, DamageSyndraW1.damages[level] + 0.7 * (double)source.TotalMagicalDamage) * num;
		}

		// Token: 0x040007DA RID: 2010
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
