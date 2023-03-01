using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001FB RID: 507
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KogMaw", SpellSlot.R, 0)]
	public class DamageKogMawR : DamageSpell
	{
		// Token: 0x06000C0C RID: 3084 RVA: 0x0003D75C File Offset: 0x0003B95C
		public DamageKogMawR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0003D774 File Offset: 0x0003B974
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageKogMawR.damages[level] + 0.65 * (double)source.GetBonusAaDamage() + 0.35 * (double)source.TotalMagicalDamage) * (double)((target.HealthPercent < 25f) ? 3 : ((target.HealthPercent < 50f) ? 2 : 1));
		}

		// Token: 0x040006FF RID: 1791
		private static readonly double[] damages = new double[]
		{
			100.0,
			140.0,
			180.0
		};
	}
}
