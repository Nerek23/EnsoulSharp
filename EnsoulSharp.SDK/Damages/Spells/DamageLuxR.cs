using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000222 RID: 546
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lux", SpellSlot.R, 0)]
	public class DamageLuxR : DamageSpell
	{
		// Token: 0x06000C81 RID: 3201 RVA: 0x0003E3CE File Offset: 0x0003C5CE
		public DamageLuxR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0003E3E4 File Offset: 0x0003C5E4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLuxR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000727 RID: 1831
		private static readonly double[] damages = new double[]
		{
			300.0,
			400.0,
			500.0
		};
	}
}
