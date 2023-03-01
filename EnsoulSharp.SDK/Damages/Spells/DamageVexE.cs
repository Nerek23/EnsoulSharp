using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002FE RID: 766
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vex", SpellSlot.E, 0)]
	public class DamageVexE : DamageSpell
	{
		// Token: 0x06000F13 RID: 3859 RVA: 0x00042C81 File Offset: 0x00040E81
		public DamageVexE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x00042C97 File Offset: 0x00040E97
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVexE.damages[level] + DamageVexE.damagePercents[level] * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400081B RID: 2075
		private static readonly double[] damages = new double[]
		{
			50.0,
			70.0,
			90.0,
			110.0,
			130.0
		};

		// Token: 0x0400081C RID: 2076
		private static readonly double[] damagePercents = new double[]
		{
			0.4,
			0.45,
			0.5,
			0.55,
			0.6
		};
	}
}
