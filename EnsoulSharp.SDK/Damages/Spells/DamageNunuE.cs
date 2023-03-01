using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000250 RID: 592
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nunu", SpellSlot.E, 0)]
	public class DamageNunuE : DamageSpell
	{
		// Token: 0x06000D0A RID: 3338 RVA: 0x0003F272 File Offset: 0x0003D472
		public DamageNunuE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0003F288 File Offset: 0x0003D488
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageNunuE.damages[level] + 0.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000756 RID: 1878
		private static readonly double[] damages = new double[]
		{
			16.0,
			24.0,
			32.0,
			40.0,
			48.0
		};
	}
}
