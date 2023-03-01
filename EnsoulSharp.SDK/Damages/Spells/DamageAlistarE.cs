using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200011E RID: 286
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Alistar", SpellSlot.E, 0)]
	public class DamageAlistarE : DamageSpell
	{
		// Token: 0x06000969 RID: 2409 RVA: 0x00038DBB File Offset: 0x00036FBB
		public DamageAlistarE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00038DD1 File Offset: 0x00036FD1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAlistarE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000605 RID: 1541
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
