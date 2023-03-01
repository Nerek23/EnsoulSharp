using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200020F RID: 527
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Neeko", SpellSlot.Q, 1)]
	public class DamageNeekoQ1 : DamageSpell
	{
		// Token: 0x06000C48 RID: 3144 RVA: 0x0003DE36 File Offset: 0x0003C036
		public DamageNeekoQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0003DE53 File Offset: 0x0003C053
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNeekoQ1.damages[level] + 0.2 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000713 RID: 1811
		private static readonly double[] damages = new double[]
		{
			40.0,
			65.0,
			90.0,
			115.0,
			140.0
		};
	}
}
