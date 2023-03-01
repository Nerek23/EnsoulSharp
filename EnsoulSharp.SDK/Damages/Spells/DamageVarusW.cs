using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002FC RID: 764
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Varus", SpellSlot.W, 0)]
	public class DamageVarusW : DamageSpell
	{
		// Token: 0x06000F0D RID: 3853 RVA: 0x00042BD6 File Offset: 0x00040DD6
		public DamageVarusW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x00042BEC File Offset: 0x00040DEC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageVarusW.damages[level] + 0.02 * (double)source.TotalMagicalDamage / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x04000819 RID: 2073
		private static readonly double[] damages = new double[]
		{
			0.03,
			0.035,
			0.04,
			0.045,
			0.05
		};
	}
}
