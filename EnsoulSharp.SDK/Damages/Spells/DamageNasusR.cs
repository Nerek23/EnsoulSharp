using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000243 RID: 579
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nasus", SpellSlot.R, 0)]
	public class DamageNasusR : DamageSpell
	{
		// Token: 0x06000CE3 RID: 3299 RVA: 0x0003EDE6 File Offset: 0x0003CFE6
		public DamageNasusR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x0003EDFC File Offset: 0x0003CFFC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageNasusR.damages[level] + 0.0001 * (double)source.TotalMagicalDamage) * (double)target.MaxHealth;
		}

		// Token: 0x04000748 RID: 1864
		private static readonly double[] damages = new double[]
		{
			0.03,
			0.04,
			0.05
		};
	}
}
