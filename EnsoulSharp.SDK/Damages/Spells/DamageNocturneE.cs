using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200024D RID: 589
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nocturne", SpellSlot.E, 0)]
	public class DamageNocturneE : DamageSpell
	{
		// Token: 0x06000D01 RID: 3329 RVA: 0x0003F19B File Offset: 0x0003D39B
		public DamageNocturneE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x0003F1B1 File Offset: 0x0003D3B1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNocturneE.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000753 RID: 1875
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
