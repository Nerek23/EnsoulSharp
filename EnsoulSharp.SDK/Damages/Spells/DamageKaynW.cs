using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001EB RID: 491
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayn", SpellSlot.W, 0)]
	public class DamageKaynW : DamageSpell
	{
		// Token: 0x06000BDC RID: 3036 RVA: 0x0003D295 File Offset: 0x0003B495
		public DamageKaynW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0003D2AB File Offset: 0x0003B4AB
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKaynW.damages[level] + 1.3 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006EE RID: 1774
		private static readonly double[] damages = new double[]
		{
			90.0,
			135.0,
			180.0,
			225.0,
			270.0
		};
	}
}
