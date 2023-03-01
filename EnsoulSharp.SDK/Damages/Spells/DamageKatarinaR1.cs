using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001DD RID: 477
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Katarina", SpellSlot.R, 1)]
	public class DamageKatarinaR1 : DamageSpell
	{
		// Token: 0x06000BB4 RID: 2996 RVA: 0x0003CDD4 File Offset: 0x0003AFD4
		public DamageKatarinaR1()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0003CDF4 File Offset: 0x0003AFF4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKatarinaR1.damages[level] + 0.19 * (double)source.TotalMagicalDamage + (0.15 + 0.099 * (double)(1f / source.AttackDelay)) * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040006E1 RID: 1761
		private static readonly double[] damages = new double[]
		{
			25.0,
			37.5,
			50.0
		};
	}
}
