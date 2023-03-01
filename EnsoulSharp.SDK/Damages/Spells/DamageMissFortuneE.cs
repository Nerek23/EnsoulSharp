using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000230 RID: 560
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MissFortune", SpellSlot.E, 0)]
	public class DamageMissFortuneE : DamageSpell
	{
		// Token: 0x06000CAB RID: 3243 RVA: 0x0003E858 File Offset: 0x0003CA58
		public DamageMissFortuneE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x0003E86E File Offset: 0x0003CA6E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMissFortuneE.damages[level] + (double)(1.2f * source.TotalMagicalDamage);
		}

		// Token: 0x04000736 RID: 1846
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
