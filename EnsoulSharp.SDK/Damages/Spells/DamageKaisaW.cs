using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001CB RID: 459
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kaisa", SpellSlot.W, 0)]
	public class DamageKaisaW : DamageSpell
	{
		// Token: 0x06000B7E RID: 2942 RVA: 0x0003C6DE File Offset: 0x0003A8DE
		public DamageKaisaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0003C6F4 File Offset: 0x0003A8F4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKaisaW.damages[level] + 1.3 * (double)source.TotalAttackDamage + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006CA RID: 1738
		private static readonly double[] damages = new double[]
		{
			30.0,
			55.0,
			80.0,
			105.0,
			130.0
		};
	}
}
