using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200029C RID: 668
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rumble", SpellSlot.Q, 1)]
	public class DamageRumbleQ1 : DamageSpell
	{
		// Token: 0x06000DED RID: 3565 RVA: 0x00040AE5 File Offset: 0x0003ECE5
		public DamageRumbleQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00040B02 File Offset: 0x0003ED02
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRumbleQ1.damages[level] + 1.65 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007AB RID: 1963
		private static readonly double[] damages = new double[]
		{
			270.0,
			330.0,
			390.0,
			450.0,
			510.0
		};
	}
}
