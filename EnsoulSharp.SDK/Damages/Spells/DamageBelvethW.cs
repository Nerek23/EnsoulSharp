using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F3 RID: 243
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Belveth", SpellSlot.W, 0)]
	public class DamageBelvethW : DamageSpell
	{
		// Token: 0x060008E9 RID: 2281 RVA: 0x00037E21 File Offset: 0x00036021
		public DamageBelvethW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00037E37 File Offset: 0x00036037
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBelvethW.damages[level] + (double)(1f * source.GetBonusPhysicalDamage()) + 1.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005D4 RID: 1492
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
