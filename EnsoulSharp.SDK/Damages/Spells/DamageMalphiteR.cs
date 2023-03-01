using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000225 RID: 549
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Malphite", SpellSlot.R, 0)]
	public class DamageMalphiteR : DamageSpell
	{
		// Token: 0x06000C8A RID: 3210 RVA: 0x0003E4B7 File Offset: 0x0003C6B7
		public DamageMalphiteR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0003E4CD File Offset: 0x0003C6CD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMalphiteR.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400072A RID: 1834
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
