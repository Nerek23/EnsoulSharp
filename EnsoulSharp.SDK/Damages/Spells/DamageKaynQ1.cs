using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001EA RID: 490
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayn", SpellSlot.Q, 1)]
	public class DamageKaynQ1 : DamageSpell
	{
		// Token: 0x06000BD9 RID: 3033 RVA: 0x0003D245 File Offset: 0x0003B445
		public DamageKaynQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0003D262 File Offset: 0x0003B462
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKaynQ1.damages[level] + 1.3 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006ED RID: 1773
		private static readonly double[] damages = new double[]
		{
			140.0,
			170.0,
			210.0,
			250.0,
			290.0
		};
	}
}
