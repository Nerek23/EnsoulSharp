using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000137 RID: 311
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Azir", SpellSlot.Q, 0)]
	public class DamageAzirQ : DamageSpell
	{
		// Token: 0x060009B4 RID: 2484 RVA: 0x000396B8 File Offset: 0x000378B8
		public DamageAzirQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000396CE File Offset: 0x000378CE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAzirQ.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000624 RID: 1572
		private static readonly double[] damages = new double[]
		{
			60.0,
			80.0,
			100.0,
			120.0,
			140.0
		};
	}
}
