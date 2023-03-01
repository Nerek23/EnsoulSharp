using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E7 RID: 743
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Tristana", SpellSlot.E, 0)]
	public class DamageTristanaE : DamageSpell
	{
		// Token: 0x06000ECE RID: 3790 RVA: 0x000424AC File Offset: 0x000406AC
		public DamageTristanaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x000424C2 File Offset: 0x000406C2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTristanaE.damages[level] + DamageTristanaE.damagePercents[level] * (double)source.GetBonusPhysicalDamage() + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007FF RID: 2047
		private static readonly double[] damages = new double[]
		{
			70.0,
			80.0,
			90.0,
			100.0,
			110.0
		};

		// Token: 0x04000800 RID: 2048
		private static readonly double[] damagePercents = new double[]
		{
			0.5,
			0.75,
			1.0,
			1.25,
			1.5
		};
	}
}
