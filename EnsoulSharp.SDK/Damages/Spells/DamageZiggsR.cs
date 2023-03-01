using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000348 RID: 840
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ziggs", SpellSlot.R, 0)]
	public class DamageZiggsR : DamageSpell
	{
		// Token: 0x06000FF0 RID: 4080 RVA: 0x00044498 File Offset: 0x00042698
		public DamageZiggsR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x000444AE File Offset: 0x000426AE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZiggsR.damages[level] + 1.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400086C RID: 2156
		private static readonly double[] damages = new double[]
		{
			300.0,
			450.0,
			600.0
		};
	}
}
