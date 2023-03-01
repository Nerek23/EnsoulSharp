using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000292 RID: 658
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sett", SpellSlot.W, 0)]
	public class DamageSettW : DamageSpell
	{
		// Token: 0x06000DCF RID: 3535 RVA: 0x00040774 File Offset: 0x0003E974
		public DamageSettW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x0004078A File Offset: 0x0003E98A
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSettW.damages[level] + 0.25 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400079F RID: 1951
		private static readonly double[] damages = new double[]
		{
			80.0,
			100.0,
			120.0,
			140.0,
			160.0
		};
	}
}
