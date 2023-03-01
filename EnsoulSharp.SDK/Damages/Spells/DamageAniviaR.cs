using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000127 RID: 295
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Anivia", SpellSlot.R, 0)]
	public class DamageAniviaR : DamageSpell
	{
		// Token: 0x06000984 RID: 2436 RVA: 0x00039092 File Offset: 0x00037292
		public DamageAniviaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x000390A8 File Offset: 0x000372A8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAniviaR.damages[level] + 0.125 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400060F RID: 1551
		private static readonly double[] damages = new double[]
		{
			30.0,
			45.0,
			60.0
		};
	}
}
