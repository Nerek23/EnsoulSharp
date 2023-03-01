using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000150 RID: 336
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Cassiopeia", SpellSlot.R, 0)]
	public class DamageCassiopeiaR : DamageSpell
	{
		// Token: 0x060009FE RID: 2558 RVA: 0x00039E40 File Offset: 0x00038040
		public DamageCassiopeiaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00039E56 File Offset: 0x00038056
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCassiopeiaR.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400063E RID: 1598
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
