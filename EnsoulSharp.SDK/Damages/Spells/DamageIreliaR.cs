using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001AF RID: 431
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Irelia", SpellSlot.R, 0)]
	public class DamageIreliaR : DamageSpell
	{
		// Token: 0x06000B2B RID: 2859 RVA: 0x0003BDC2 File Offset: 0x00039FC2
		public DamageIreliaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0003BDD8 File Offset: 0x00039FD8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageIreliaR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006AC RID: 1708
		private static readonly double[] damages = new double[]
		{
			125.0,
			250.0,
			375.0
		};
	}
}
