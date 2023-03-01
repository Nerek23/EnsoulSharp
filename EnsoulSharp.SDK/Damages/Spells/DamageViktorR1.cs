using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000316 RID: 790
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viktor", SpellSlot.R, 1)]
	public class DamageViktorR1 : DamageSpell
	{
		// Token: 0x06000F5B RID: 3931 RVA: 0x000434AA File Offset: 0x000416AA
		public DamageViktorR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x000434C7 File Offset: 0x000416C7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViktorR1.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000836 RID: 2102
		private static readonly double[] damages = new double[]
		{
			65.0,
			105.0,
			145.0
		};
	}
}
