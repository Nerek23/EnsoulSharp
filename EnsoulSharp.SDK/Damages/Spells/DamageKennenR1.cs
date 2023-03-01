using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001EE RID: 494
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kennen", SpellSlot.R, 1)]
	public class DamageKennenR1 : DamageSpell
	{
		// Token: 0x06000BE5 RID: 3045 RVA: 0x0003D370 File Offset: 0x0003B570
		public DamageKennenR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x0003D38D File Offset: 0x0003B58D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKennenR1.damages[level] + 0.225 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006F1 RID: 1777
		private static readonly double[] damages = new double[]
		{
			40.0,
			75.0,
			110.0
		};
	}
}
