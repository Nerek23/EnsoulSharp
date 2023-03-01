using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001B9 RID: 441
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Jax", SpellSlot.E, 0)]
	public class DamageJaxE : DamageSpell
	{
		// Token: 0x06000B49 RID: 2889 RVA: 0x0003C0E0 File Offset: 0x0003A2E0
		public DamageJaxE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0003C0F6 File Offset: 0x0003A2F6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageJaxE.damages[level] + 0.04 * (double)target.MaxHealth + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006B6 RID: 1718
		private static readonly double[] damages = new double[]
		{
			55.0,
			85.0,
			115.0,
			145.0,
			175.0
		};
	}
}
