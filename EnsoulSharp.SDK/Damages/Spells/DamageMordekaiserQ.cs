using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000238 RID: 568
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Mordekaiser", SpellSlot.Q, 0)]
	public class DamageMordekaiserQ : DamageSpell
	{
		// Token: 0x06000CC2 RID: 3266 RVA: 0x0003EAB3 File Offset: 0x0003CCB3
		public DamageMordekaiserQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0003EAC9 File Offset: 0x0003CCC9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMordekaiserQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400073D RID: 1853
		private static readonly double[] damages = new double[]
		{
			75.0,
			95.0,
			115.0,
			135.0,
			155.0
		};
	}
}
