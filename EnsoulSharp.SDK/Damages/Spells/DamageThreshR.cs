using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E6 RID: 742
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Thresh", SpellSlot.R, 0)]
	public class DamageThreshR : DamageSpell
	{
		// Token: 0x06000ECB RID: 3787 RVA: 0x00042467 File Offset: 0x00040667
		public DamageThreshR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x0004247D File Offset: 0x0004067D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageThreshR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x040007FE RID: 2046
		private static readonly double[] damages = new double[]
		{
			250.0,
			400.0,
			550.0
		};
	}
}
