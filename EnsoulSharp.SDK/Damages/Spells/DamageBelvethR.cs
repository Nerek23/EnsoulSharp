using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000F2 RID: 242
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Belveth", SpellSlot.R, 0)]
	public class DamageBelvethR : DamageSpell
	{
		// Token: 0x060008E6 RID: 2278 RVA: 0x00037DC3 File Offset: 0x00035FC3
		public DamageBelvethR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.True;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00037DD9 File Offset: 0x00035FD9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageBelvethR.damages[level] + (double)(1f * source.TotalMagicalDamage) + 0.25 * (double)(target.MaxHealth - target.Health);
		}

		// Token: 0x040005D3 RID: 1491
		private static readonly double[] damages = new double[]
		{
			150.0,
			200.0,
			250.0
		};
	}
}
