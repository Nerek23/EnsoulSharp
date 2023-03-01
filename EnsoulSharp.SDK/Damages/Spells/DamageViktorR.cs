using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000315 RID: 789
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viktor", SpellSlot.R, 0)]
	public class DamageViktorR : DamageSpell
	{
		// Token: 0x06000F58 RID: 3928 RVA: 0x00043461 File Offset: 0x00041661
		public DamageViktorR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x00043477 File Offset: 0x00041677
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViktorR.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000835 RID: 2101
		private static readonly double[] damages = new double[]
		{
			100.0,
			175.0,
			250.0
		};
	}
}
