using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000178 RID: 376
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ezreal", SpellSlot.Q, 0)]
	public class DamageEzrealQ : DamageSpell
	{
		// Token: 0x06000A80 RID: 2688 RVA: 0x0003AC73 File Offset: 0x00038E73
		public DamageEzrealQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0003AC89 File Offset: 0x00038E89
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEzrealQ.damages[level] + 1.3 * (double)source.TotalAttackDamage + 0.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000671 RID: 1649
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
