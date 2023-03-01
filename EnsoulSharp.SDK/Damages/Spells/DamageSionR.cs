using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002B8 RID: 696
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sion", SpellSlot.R, 0)]
	public class DamageSionR : DamageSpell
	{
		// Token: 0x06000E41 RID: 3649 RVA: 0x000414F7 File Offset: 0x0003F6F7
		public DamageSionR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x0004150D File Offset: 0x0003F70D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSionR.damages[level] + 0.4 * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040007CD RID: 1997
		private static readonly double[] damages = new double[]
		{
			150.0,
			300.0,
			450.0
		};
	}
}
