using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200026B RID: 619
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Poppy", SpellSlot.R, 0)]
	public class DamagePoppyR : DamageSpell
	{
		// Token: 0x06000D5B RID: 3419 RVA: 0x0003FAC7 File Offset: 0x0003DCC7
		public DamagePoppyR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x0003FADD File Offset: 0x0003DCDD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePoppyR.damages[level] + 0.9 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000773 RID: 1907
		private static readonly double[] damages = new double[]
		{
			200.0,
			300.0,
			400.0
		};
	}
}
