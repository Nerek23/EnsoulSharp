using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200011F RID: 287
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Alistar", SpellSlot.W, 0)]
	public class DamageAlistarW : DamageSpell
	{
		// Token: 0x0600096C RID: 2412 RVA: 0x00038E04 File Offset: 0x00037004
		public DamageAlistarW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00038E1A File Offset: 0x0003701A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAlistarW.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000606 RID: 1542
		private static readonly double[] damages = new double[]
		{
			55.0,
			110.0,
			165.0,
			220.0,
			275.0
		};
	}
}
