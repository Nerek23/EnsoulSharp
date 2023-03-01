using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B0 RID: 688
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Shyvana", SpellSlot.Q, 0)]
	public class DamageShyvanaQ : DamageSpell
	{
		// Token: 0x06000E29 RID: 3625 RVA: 0x00041252 File Offset: 0x0003F452
		public DamageShyvanaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00041268 File Offset: 0x0003F468
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageShyvanaQ.damages[level] * (double)source.TotalAttackDamage + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007C2 RID: 1986
		private static readonly double[] damages = new double[]
		{
			0.2,
			0.35,
			0.5,
			0.65,
			0.8
		};
	}
}
