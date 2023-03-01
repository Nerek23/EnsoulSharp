using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002CC RID: 716
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Swain", SpellSlot.E, 0)]
	public class DamageSwainE : DamageSpell
	{
		// Token: 0x06000E7D RID: 3709 RVA: 0x00041B84 File Offset: 0x0003FD84
		public DamageSwainE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x00041B9A File Offset: 0x0003FD9A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSwainE.damages[level] + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E3 RID: 2019
		private static readonly double[] damages = new double[]
		{
			35.0,
			70.0,
			105.0,
			140.0,
			175.0
		};
	}
}
