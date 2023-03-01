using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002CA RID: 714
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sylas", SpellSlot.Q, 1)]
	public class DamageSylasQ1 : DamageSpell
	{
		// Token: 0x06000E77 RID: 3703 RVA: 0x00041AEB File Offset: 0x0003FCEB
		public DamageSylasQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x00041B08 File Offset: 0x0003FD08
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSylasQ1.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E1 RID: 2017
		private static readonly double[] damages = new double[]
		{
			70.0,
			125.0,
			180.0,
			230.0,
			290.0
		};
	}
}
