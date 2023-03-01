using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200029E RID: 670
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rumble", SpellSlot.R, 1)]
	public class DamageRumbleR1 : DamageSpell
	{
		// Token: 0x06000DF3 RID: 3571 RVA: 0x00040B7E File Offset: 0x0003ED7E
		public DamageRumbleR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x00040B9B File Offset: 0x0003ED9B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRumbleR1.damages[level] + 0.175 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007AD RID: 1965
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0
		};
	}
}
