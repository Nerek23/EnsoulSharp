using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F7 RID: 503
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kindred", SpellSlot.Q, 0)]
	public class DamageKindredQ : DamageSpell
	{
		// Token: 0x06000C00 RID: 3072 RVA: 0x0003D638 File Offset: 0x0003B838
		public DamageKindredQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0003D64E File Offset: 0x0003B84E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKindredQ.damages[level] + 0.75 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040006FB RID: 1787
		private static readonly double[] damages = new double[]
		{
			60.0,
			85.0,
			110.0,
			135.0,
			160.0
		};
	}
}
