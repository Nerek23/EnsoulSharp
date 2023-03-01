using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000296 RID: 662
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Riven", SpellSlot.Q, 0)]
	public class DamageRivenQ : DamageSpell
	{
		// Token: 0x06000DDB RID: 3547 RVA: 0x000408AA File Offset: 0x0003EAAA
		public DamageRivenQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x000408C0 File Offset: 0x0003EAC0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRivenQ.damages[level] + DamageRivenQ.damagePercents[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x040007A3 RID: 1955
		private static readonly double[] damages = new double[]
		{
			15.0,
			35.0,
			55.0,
			75.0,
			95.0
		};

		// Token: 0x040007A4 RID: 1956
		private static readonly double[] damagePercents = new double[]
		{
			0.45,
			0.5,
			0.55,
			0.6,
			0.65
		};
	}
}
