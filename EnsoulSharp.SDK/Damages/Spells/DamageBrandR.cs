using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000140 RID: 320
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Brand", SpellSlot.R, 0)]
	public class DamageBrandR : DamageSpell
	{
		// Token: 0x060009CE RID: 2510 RVA: 0x0003994A File Offset: 0x00037B4A
		public DamageBrandR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00039960 File Offset: 0x00037B60
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBrandR.damages[level] + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400062C RID: 1580
		private static readonly double[] damages = new double[]
		{
			100.0,
			200.0,
			300.0
		};
	}
}
