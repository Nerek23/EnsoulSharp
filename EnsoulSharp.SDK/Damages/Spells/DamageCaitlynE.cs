using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200014B RID: 331
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Caitlyn", SpellSlot.E, 0)]
	public class DamageCaitlynE : DamageSpell
	{
		// Token: 0x060009EF RID: 2543 RVA: 0x00039C8A File Offset: 0x00037E8A
		public DamageCaitlynE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00039CA0 File Offset: 0x00037EA0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageCaitlynE.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000638 RID: 1592
		private static readonly double[] damages = new double[]
		{
			80.0,
			130.0,
			180.0,
			230.0,
			280.0
		};
	}
}
