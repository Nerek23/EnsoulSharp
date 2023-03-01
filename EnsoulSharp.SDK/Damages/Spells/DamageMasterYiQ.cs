using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200022F RID: 559
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MasterYi", SpellSlot.Q, 0)]
	public class DamageMasterYiQ : DamageSpell
	{
		// Token: 0x06000CA8 RID: 3240 RVA: 0x0003E80F File Offset: 0x0003CA0F
		public DamageMasterYiQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0003E825 File Offset: 0x0003CA25
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMasterYiQ.damages[level] + 0.6 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000735 RID: 1845
		private static readonly double[] damages = new double[]
		{
			30.0,
			60.0,
			90.0,
			120.0,
			150.0
		};
	}
}
