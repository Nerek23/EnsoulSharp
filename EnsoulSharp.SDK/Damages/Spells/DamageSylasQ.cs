using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C9 RID: 713
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sylas", SpellSlot.Q, 0)]
	public class DamageSylasQ : DamageSpell
	{
		// Token: 0x06000E74 RID: 3700 RVA: 0x00041AA2 File Offset: 0x0003FCA2
		public DamageSylasQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x00041AB8 File Offset: 0x0003FCB8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSylasQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E0 RID: 2016
		private static readonly double[] damages = new double[]
		{
			40.0,
			60.0,
			80.0,
			100.0,
			120.0
		};
	}
}
