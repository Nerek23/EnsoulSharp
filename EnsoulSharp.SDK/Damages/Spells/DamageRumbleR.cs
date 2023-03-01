using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200029D RID: 669
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rumble", SpellSlot.R, 0)]
	public class DamageRumbleR : DamageSpell
	{
		// Token: 0x06000DF0 RID: 3568 RVA: 0x00040B35 File Offset: 0x0003ED35
		public DamageRumbleR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00040B4B File Offset: 0x0003ED4B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRumbleR.damages[level] + 1.75 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007AC RID: 1964
		private static readonly double[] damages = new double[]
		{
			700.0,
			1050.0,
			1400.0
		};
	}
}
