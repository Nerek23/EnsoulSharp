using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002E8 RID: 744
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Tristana", SpellSlot.R, 0)]
	public class DamageTristanaR : DamageSpell
	{
		// Token: 0x06000ED1 RID: 3793 RVA: 0x0004251B File Offset: 0x0004071B
		public DamageTristanaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x00042531 File Offset: 0x00040731
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTristanaR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000801 RID: 2049
		private static readonly double[] damages = new double[]
		{
			300.0,
			400.0,
			500.0
		};
	}
}
