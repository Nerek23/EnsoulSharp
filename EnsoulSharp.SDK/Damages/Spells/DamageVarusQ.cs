using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002FA RID: 762
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Varus", SpellSlot.Q, 0)]
	public class DamageVarusQ : DamageSpell
	{
		// Token: 0x06000F07 RID: 3847 RVA: 0x00042B34 File Offset: 0x00040D34
		public DamageVarusQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x00042B4A File Offset: 0x00040D4A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVarusQ.damages[level] + DamageVarusQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000816 RID: 2070
		private static readonly double[] damages = new double[]
		{
			15.0,
			70.0,
			125.0,
			180.0,
			235.0
		};

		// Token: 0x04000817 RID: 2071
		private static readonly double[] damagePercents = new double[]
		{
			1.25,
			1.3,
			1.35,
			1.4,
			1.45
		};
	}
}
