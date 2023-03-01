using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B4 RID: 436
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Janna", SpellSlot.Q, 0)]
	public class DamageJannaQ : DamageSpell
	{
		// Token: 0x06000B3A RID: 2874 RVA: 0x0003BF41 File Offset: 0x0003A141
		public DamageJannaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0003BF57 File Offset: 0x0003A157
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJannaQ.damages[level] + 0.35 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006B1 RID: 1713
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
