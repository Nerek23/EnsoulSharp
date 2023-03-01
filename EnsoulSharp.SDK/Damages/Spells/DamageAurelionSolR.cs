using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000134 RID: 308
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("AurelionSol", SpellSlot.R, 0)]
	public class DamageAurelionSolR : DamageSpell
	{
		// Token: 0x060009AB RID: 2475 RVA: 0x000395D7 File Offset: 0x000377D7
		public DamageAurelionSolR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000395ED File Offset: 0x000377ED
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAurelionSolR.damages[level] + 0.65 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000621 RID: 1569
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
