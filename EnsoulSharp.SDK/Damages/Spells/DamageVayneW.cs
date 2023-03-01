using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200030A RID: 778
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vayne", SpellSlot.W, 0)]
	public class DamageVayneW : DamageSpell
	{
		// Token: 0x06000F37 RID: 3895 RVA: 0x0004307A File Offset: 0x0004127A
		public DamageVayneW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x00043090 File Offset: 0x00041290
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return Math.Max(DamageVayneW.damages[level], DamageVayneW.damagePercents[level] * (double)target.MaxHealth);
		}

		// Token: 0x04000828 RID: 2088
		private static readonly double[] damages = new double[]
		{
			50.0,
			65.0,
			80.0,
			95.0,
			110.0
		};

		// Token: 0x04000829 RID: 2089
		private static readonly double[] damagePercents = new double[]
		{
			0.04,
			0.065,
			0.09,
			0.115,
			0.14
		};
	}
}
