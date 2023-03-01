using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F7 RID: 759
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Urgot", SpellSlot.W, 0)]
	public class DamageUrgotW : DamageSpell
	{
		// Token: 0x06000EFE RID: 3838 RVA: 0x00042A42 File Offset: 0x00040C42
		public DamageUrgotW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00042A5F File Offset: 0x00040C5F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageUrgotW.damages[level] + DamageUrgotW.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000812 RID: 2066
		private static readonly double[] damages = new double[]
		{
			12.0,
			12.0,
			12.0,
			12.0,
			12.0
		};

		// Token: 0x04000813 RID: 2067
		private static readonly double[] damagePercents = new double[]
		{
			0.2,
			0.235,
			0.27,
			0.305,
			0.34
		};
	}
}
