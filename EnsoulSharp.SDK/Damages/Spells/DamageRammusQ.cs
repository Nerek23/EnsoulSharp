using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000276 RID: 630
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rammus", SpellSlot.Q, 0)]
	public class DamageRammusQ : DamageSpell
	{
		// Token: 0x06000D7B RID: 3451 RVA: 0x0003FE3E File Offset: 0x0003E03E
		public DamageRammusQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0003FE54 File Offset: 0x0003E054
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRammusQ.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400077E RID: 1918
		private static readonly double[] damages = new double[]
		{
			100.0,
			125.0,
			150.0,
			175.0,
			200.0
		};
	}
}
