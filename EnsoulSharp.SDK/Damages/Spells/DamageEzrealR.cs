using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000179 RID: 377
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ezreal", SpellSlot.R, 0)]
	public class DamageEzrealR : DamageSpell
	{
		// Token: 0x06000A83 RID: 2691 RVA: 0x0003ACCE File Offset: 0x00038ECE
		public DamageEzrealR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0003ACE4 File Offset: 0x00038EE4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEzrealR.damages[level] + (double)(1f * source.GetBonusAaDamage()) + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000672 RID: 1650
		private static readonly double[] damages = new double[]
		{
			350.0,
			500.0,
			650.0
		};
	}
}
