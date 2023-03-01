using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000302 RID: 770
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viego", SpellSlot.Q, 0)]
	public class DamageViegoQ : DamageSpell
	{
		// Token: 0x06000F1F RID: 3871 RVA: 0x00042DB9 File Offset: 0x00040FB9
		public DamageViegoQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00042DD0 File Offset: 0x00040FD0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageViegoQ.damages[level] + 0.7 * (double)source.TotalAttackDamage) * (1.0 + 0.075 * Math.Floor((double)(source.Crit * 10f)));
		}

		// Token: 0x04000820 RID: 2080
		private static readonly double[] damages = new double[]
		{
			15.0,
			30.0,
			45.0,
			60.0,
			75.0
		};
	}
}
