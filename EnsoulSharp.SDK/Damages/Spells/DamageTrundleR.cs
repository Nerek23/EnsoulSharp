using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002EB RID: 747
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Trundle", SpellSlot.R, 0)]
	public class DamageTrundleR : DamageSpell
	{
		// Token: 0x06000EDA RID: 3802 RVA: 0x00042606 File Offset: 0x00040806
		public DamageTrundleR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x0004261C File Offset: 0x0004081C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageTrundleR.damages[level] + 0.01 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x04000805 RID: 2053
		private static readonly double[] damages = new double[]
		{
			0.2,
			0.25,
			0.3
		};
	}
}
