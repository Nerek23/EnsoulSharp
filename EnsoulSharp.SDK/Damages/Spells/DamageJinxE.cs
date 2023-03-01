using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C6 RID: 454
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jinx", SpellSlot.E, 0)]
	public class DamageJinxE : DamageSpell
	{
		// Token: 0x06000B70 RID: 2928 RVA: 0x0003C556 File Offset: 0x0003A756
		public DamageJinxE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0003C56C File Offset: 0x0003A76C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJinxE.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x040006C5 RID: 1733
		private static readonly double[] damages = new double[]
		{
			70.0,
			120.0,
			170.0,
			220.0,
			270.0
		};
	}
}
