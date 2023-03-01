using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000309 RID: 777
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vayne", SpellSlot.Q, 0)]
	public class DamageVayneQ : DamageSpell
	{
		// Token: 0x06000F34 RID: 3892 RVA: 0x0004303B File Offset: 0x0004123B
		public DamageVayneQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x00043051 File Offset: 0x00041251
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVayneQ.damages[level] * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000827 RID: 2087
		private static readonly double[] damages = new double[]
		{
			0.6,
			0.65,
			0.7,
			0.75,
			0.8
		};
	}
}
