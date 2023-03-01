using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001E5 RID: 485
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kled", SpellSlot.R, 0)]
	public class DamageKledR : DamageSpell
	{
		// Token: 0x06000BCB RID: 3019 RVA: 0x0003D08C File Offset: 0x0003B28C
		public DamageKledR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0003D0A2 File Offset: 0x0003B2A2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKledR.damages[level] * (double)target.MaxHealth;
		}

		// Token: 0x040006E8 RID: 1768
		private static readonly double[] damages = new double[]
		{
			0.04,
			0.05,
			0.06
		};
	}
}
