using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001DF RID: 479
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kayle", SpellSlot.R, 0)]
	public class DamageKayleR : DamageSpell
	{
		// Token: 0x06000BB9 RID: 3001 RVA: 0x0003CEA8 File Offset: 0x0003B0A8
		public DamageKayleR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0003CEBE File Offset: 0x0003B0BE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKayleR.damages[level] + (double)(1f * source.GetBonusAaDamage()) + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006E2 RID: 1762
		private static readonly double[] damages = new double[]
		{
			200.0,
			350.0,
			500.0
		};
	}
}
