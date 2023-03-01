using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200032B RID: 811
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xerath", SpellSlot.Q, 0)]
	public class DamageYuumiQ1 : DamageSpell
	{
		// Token: 0x06000F9A RID: 3994 RVA: 0x00043B5D File Offset: 0x00041D5D
		public DamageYuumiQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x00043B7A File Offset: 0x00041D7A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageYuumiQ1.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400084D RID: 2125
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0,
			260.0
		};
	}
}
