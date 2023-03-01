using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000338 RID: 824
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yorick", SpellSlot.Q, 0)]
	public class DamageYorickQ : DamageSpell
	{
		// Token: 0x06000FC1 RID: 4033 RVA: 0x00043F91 File Offset: 0x00042191
		public DamageYorickQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00043FA7 File Offset: 0x000421A7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYorickQ.damages[level] + 0.4 * (double)source.TotalAttackDamage;
		}

		// Token: 0x0400085A RID: 2138
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
