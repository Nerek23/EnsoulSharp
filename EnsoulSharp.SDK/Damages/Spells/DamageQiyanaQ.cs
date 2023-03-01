using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200025F RID: 607
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Qiyana", SpellSlot.Q, 0)]
	public class DamageQiyanaQ : DamageSpell
	{
		// Token: 0x06000D37 RID: 3383 RVA: 0x0003F6F9 File Offset: 0x0003D8F9
		public DamageQiyanaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x0003F70F File Offset: 0x0003D90F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQiyanaQ.damages[level] + 0.75 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000766 RID: 1894
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
