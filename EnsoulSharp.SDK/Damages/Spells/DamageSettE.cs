using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200028F RID: 655
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sett", SpellSlot.E, 0)]
	public class DamageSettE : DamageSpell
	{
		// Token: 0x06000DC6 RID: 3526 RVA: 0x00040643 File Offset: 0x0003E843
		public DamageSettE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00040659 File Offset: 0x0003E859
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSettE.damages[level] + 0.6 * (double)source.TotalAttackDamage;
		}

		// Token: 0x0400079A RID: 1946
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};
	}
}
