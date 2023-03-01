using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C9 RID: 457
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jinx", SpellSlot.W, 0)]
	public class DamageJinxW : DamageSpell
	{
		// Token: 0x06000B78 RID: 2936 RVA: 0x0003C63A File Offset: 0x0003A83A
		public DamageJinxW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0003C650 File Offset: 0x0003A850
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJinxW.damages[level] + 1.6 * (double)source.TotalAttackDamage;
		}

		// Token: 0x040006C8 RID: 1736
		private static readonly double[] damages = new double[]
		{
			10.0,
			60.0,
			110.0,
			160.0,
			210.0
		};
	}
}
