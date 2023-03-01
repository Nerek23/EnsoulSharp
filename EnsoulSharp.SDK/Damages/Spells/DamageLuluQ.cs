using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200021F RID: 543
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lulu", SpellSlot.Q, 0)]
	public class DamageLuluQ : DamageSpell
	{
		// Token: 0x06000C78 RID: 3192 RVA: 0x0003E2F3 File Offset: 0x0003C4F3
		public DamageLuluQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0003E309 File Offset: 0x0003C509
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLuluQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000724 RID: 1828
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
