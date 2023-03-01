using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F4 RID: 500
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Khazix", SpellSlot.Q, 1)]
	public class DamageKhazixQ1 : DamageSpell
	{
		// Token: 0x06000BF7 RID: 3063 RVA: 0x0003D55A File Offset: 0x0003B75A
		public DamageKhazixQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0003D577 File Offset: 0x0003B777
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKhazixQ1.damages[level] + 2.415 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006F8 RID: 1784
		private static readonly double[] damages = new double[]
		{
			126.0,
			178.5,
			231.0,
			283.55,
			336.0
		};
	}
}
