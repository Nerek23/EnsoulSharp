using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F5 RID: 757
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Urgot", SpellSlot.R, 0)]
	public class DamageUrgotR : DamageSpell
	{
		// Token: 0x06000EF8 RID: 3832 RVA: 0x000429B4 File Offset: 0x00040BB4
		public DamageUrgotR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x000429CA File Offset: 0x00040BCA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageUrgotR.damages[level] + 0.5 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x04000810 RID: 2064
		private static readonly double[] damages = new double[]
		{
			100.0,
			225.0,
			350.0
		};
	}
}
