using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002DA RID: 730
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Talon", SpellSlot.R, 0)]
	public class DamageTalonR : DamageSpell
	{
		// Token: 0x06000EA7 RID: 3751 RVA: 0x00041FA0 File Offset: 0x000401A0
		public DamageTalonR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x00041FB6 File Offset: 0x000401B6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTalonR.damages[level] + (double)(1f * source.GetBonusAaDamage());
		}

		// Token: 0x040007F1 RID: 2033
		private static readonly double[] damages = new double[]
		{
			90.0,
			135.0,
			180.0
		};
	}
}
