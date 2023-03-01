using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000326 RID: 806
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Yone", SpellSlot.W, 0)]
	public class DamageYoneW : DamageSpell
	{
		// Token: 0x06000F8B RID: 3979 RVA: 0x000439DC File Offset: 0x00041BDC
		public DamageYoneW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x000439F2 File Offset: 0x00041BF2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYoneW.damages[level] + DamageYoneW.damagePercents[level] * (double)target.MaxHealth;
		}

		// Token: 0x04000847 RID: 2119
		private static readonly double[] damages = new double[]
		{
			10.0,
			20.0,
			30.0,
			40.0,
			50.0
		};

		// Token: 0x04000848 RID: 2120
		private static readonly double[] damagePercents = new double[]
		{
			0.11,
			0.12,
			0.13,
			0.14,
			0.15
		};
	}
}
