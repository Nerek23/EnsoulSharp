using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C5 RID: 709
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Taliyah", SpellSlot.Q, 0)]
	public class DamageTaliyahQ1 : DamageSpell
	{
		// Token: 0x06000E68 RID: 3688 RVA: 0x00041974 File Offset: 0x0003FB74
		public DamageTaliyahQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00041991 File Offset: 0x0003FB91
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTaliyahQ1.damages[level] + 0.95 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007DC RID: 2012
		private static readonly double[] damages = new double[]
		{
			85.5,
			123.5,
			161.5,
			199.5,
			237.5
		};
	}
}
