using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000229 RID: 553
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Maokai", SpellSlot.E, 0)]
	public class DamageMaokaiE : DamageSpell
	{
		// Token: 0x06000C96 RID: 3222 RVA: 0x0003E614 File Offset: 0x0003C814
		public DamageMaokaiE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x0003E62A File Offset: 0x0003C82A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMaokaiE.damages[level] + (double)(0.25f * source.TotalMagicalDamage) + (double)(0.06f * source.BonusHealth);
		}

		// Token: 0x0400072E RID: 1838
		private static readonly double[] damages = new double[]
		{
			50.0,
			75.0,
			100.0,
			125.0,
			150.0
		};
	}
}
