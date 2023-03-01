using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E9 RID: 745
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Tristana", SpellSlot.W, 0)]
	public class DamageTristanaW : DamageSpell
	{
		// Token: 0x06000ED4 RID: 3796 RVA: 0x00042560 File Offset: 0x00040760
		public DamageTristanaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x00042576 File Offset: 0x00040776
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTristanaW.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000802 RID: 2050
		private static readonly double[] damages = new double[]
		{
			95.0,
			145.0,
			195.0,
			245.0,
			295.0
		};
	}
}
