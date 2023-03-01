using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200030E RID: 782
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Velkoz", SpellSlot.E, 0)]
	public class DamageVelkozE : DamageSpell
	{
		// Token: 0x06000F43 RID: 3907 RVA: 0x00043203 File Offset: 0x00041403
		public DamageVelkozE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x00043219 File Offset: 0x00041419
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVelkozE.damages[level] + 0.3 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400082D RID: 2093
		private static readonly double[] damages = new double[]
		{
			70.0,
			100.0,
			130.0,
			160.0,
			190.0
		};
	}
}
