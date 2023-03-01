using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000240 RID: 576
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nasus", SpellSlot.E, 0)]
	public class DamageNasusE : DamageSpell
	{
		// Token: 0x06000CDA RID: 3290 RVA: 0x0003ECFB File Offset: 0x0003CEFB
		public DamageNasusE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0003ED11 File Offset: 0x0003CF11
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNasusE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000745 RID: 1861
		private static readonly double[] damages = new double[]
		{
			55.0,
			95.0,
			135.0,
			175.0,
			215.0
		};
	}
}
