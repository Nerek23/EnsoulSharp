using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200019C RID: 412
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Graves", SpellSlot.Q, 0)]
	public class DamageGravesQ : DamageSpell
	{
		// Token: 0x06000AEC RID: 2796 RVA: 0x0003B85D File Offset: 0x00039A5D
		public DamageGravesQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0003B873 File Offset: 0x00039A73
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGravesQ.damages[level] + (double)(0.8f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x0400069B RID: 1691
		private static readonly double[] damages = new double[]
		{
			45.0,
			60.0,
			75.0,
			90.0,
			105.0
		};
	}
}
