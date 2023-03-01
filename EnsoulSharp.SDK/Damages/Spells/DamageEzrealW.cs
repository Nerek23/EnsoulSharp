using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200017A RID: 378
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ezreal", SpellSlot.W, 0)]
	public class DamageEzrealW : DamageSpell
	{
		// Token: 0x06000A86 RID: 2694 RVA: 0x0003AD25 File Offset: 0x00038F25
		public DamageEzrealW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0003AD3B File Offset: 0x00038F3B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEzrealW.damages[level] + 0.6 * (double)source.GetBonusPhysicalDamage() + DamageEzrealW.damagePercents[level] * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000673 RID: 1651
		private static readonly double[] damages = new double[]
		{
			80.0,
			135.0,
			190.0,
			245.0,
			300.0
		};

		// Token: 0x04000674 RID: 1652
		private static readonly double[] damagePercents = new double[]
		{
			0.7,
			0.75,
			0.8,
			0.85,
			0.9
		};
	}
}
