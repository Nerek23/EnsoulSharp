using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000EF RID: 239
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("AurelionSol", SpellSlot.E, 0)]
	public class DamageAurelionSolE : DamageSpell
	{
		// Token: 0x060008DD RID: 2269 RVA: 0x00037C91 File Offset: 0x00035E91
		public DamageAurelionSolE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00037CA7 File Offset: 0x00035EA7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAurelionSolE.damages[level] + 0.0625 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005CF RID: 1487
		private static readonly double[] damages = new double[]
		{
			2.5,
			3.75,
			5.0,
			6.25,
			7.5
		};
	}
}
