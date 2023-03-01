using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001A2 RID: 418
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Hecarim", SpellSlot.R, 0)]
	public class DamageHecarimR : DamageSpell
	{
		// Token: 0x06000AFE RID: 2814 RVA: 0x0003BA4D File Offset: 0x00039C4D
		public DamageHecarimR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0003BA63 File Offset: 0x00039C63
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageHecarimR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x040006A2 RID: 1698
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
