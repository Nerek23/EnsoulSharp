using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200018D RID: 397
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gangplank", SpellSlot.R, 0)]
	public class DamageGangplankR : DamageSpell
	{
		// Token: 0x06000ABF RID: 2751 RVA: 0x0003B30F File Offset: 0x0003950F
		public DamageGangplankR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0003B325 File Offset: 0x00039525
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGangplankR.damages[level] + 0.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000688 RID: 1672
		private static readonly double[] damages = new double[]
		{
			40.0,
			70.0,
			100.0
		};
	}
}
