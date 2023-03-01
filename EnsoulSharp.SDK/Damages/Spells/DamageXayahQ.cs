using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000307 RID: 775
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Xayah", SpellSlot.Q, 0)]
	public class DamageXayahQ : DamageSpell
	{
		// Token: 0x06000F2E RID: 3886 RVA: 0x00042FA3 File Offset: 0x000411A3
		public DamageXayahQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x00042FB9 File Offset: 0x000411B9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageXayahQ.damages[level] + (double)(0.5f * source.GetBonusPhysicalDamage())) * 2.0;
		}

		// Token: 0x04000825 RID: 2085
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
