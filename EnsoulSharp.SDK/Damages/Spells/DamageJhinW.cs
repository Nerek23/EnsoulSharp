using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001C5 RID: 453
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jhin", SpellSlot.W, 0)]
	public class DamageJhinW : DamageSpell
	{
		// Token: 0x06000B6D RID: 2925 RVA: 0x0003C50D File Offset: 0x0003A70D
		public DamageJhinW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0003C523 File Offset: 0x0003A723
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJhinW.damages[level] + 0.5 * (double)source.TotalAttackDamage;
		}

		// Token: 0x040006C4 RID: 1732
		private static readonly double[] damages = new double[]
		{
			60.0,
			95.0,
			130.0,
			165.0,
			200.0
		};
	}
}
