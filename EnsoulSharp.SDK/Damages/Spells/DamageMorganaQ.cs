using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000239 RID: 569
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Morgana", SpellSlot.Q, 0)]
	public class DamageMorganaQ : DamageSpell
	{
		// Token: 0x06000CC5 RID: 3269 RVA: 0x0003EAFC File Offset: 0x0003CCFC
		public DamageMorganaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0003EB12 File Offset: 0x0003CD12
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMorganaQ.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400073E RID: 1854
		private static readonly double[] damages = new double[]
		{
			80.0,
			135.0,
			190.0,
			245.0,
			300.0
		};
	}
}
