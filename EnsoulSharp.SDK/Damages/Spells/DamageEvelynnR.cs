using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000175 RID: 373
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Evelynn", SpellSlot.R, 0)]
	public class DamageEvelynnR : DamageSpell
	{
		// Token: 0x06000A76 RID: 2678 RVA: 0x0003AB6A File Offset: 0x00038D6A
		public DamageEvelynnR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0003AB80 File Offset: 0x00038D80
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageEvelynnR.damages[level] + 0.75 * (double)source.TotalMagicalDamage;
			if (target.HealthPercent <= 30f)
			{
				num *= 1.4;
			}
			return num;
		}

		// Token: 0x0400066C RID: 1644
		private static readonly double[] damages = new double[]
		{
			125.0,
			250.0,
			375.0
		};
	}
}
