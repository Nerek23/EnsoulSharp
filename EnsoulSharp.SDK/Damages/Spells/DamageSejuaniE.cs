using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002A2 RID: 674
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sejuani", SpellSlot.E, 0)]
	public class DamageSejuaniE : DamageSpell
	{
		// Token: 0x06000DFF RID: 3583 RVA: 0x00040CDF File Offset: 0x0003EEDF
		public DamageSejuaniE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00040CF5 File Offset: 0x0003EEF5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSejuaniE.damages[level] + (double)(0.6f * source.TotalMagicalDamage);
		}

		// Token: 0x040007B1 RID: 1969
		private static readonly double[] damages = new double[]
		{
			55.0,
			105.0,
			155.0,
			205.0,
			255.0
		};
	}
}
