using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D8 RID: 728
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Talon", SpellSlot.Q, 1)]
	public class DamageTalonQ1 : DamageSpell
	{
		// Token: 0x06000EA1 RID: 3745 RVA: 0x00041F0B File Offset: 0x0004010B
		public DamageTalonQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00041F28 File Offset: 0x00040128
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTalonQ1.damages[level] + 1.65 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007EF RID: 2031
		private static readonly double[] damages = new double[]
		{
			97.5,
			135.0,
			172.5,
			210.0,
			247.5
		};
	}
}
