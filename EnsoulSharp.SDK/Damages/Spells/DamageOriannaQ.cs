using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000257 RID: 599
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Orianna", SpellSlot.Q, 0)]
	public class DamageOriannaQ : DamageSpell
	{
		// Token: 0x06000D1F RID: 3359 RVA: 0x0003F4B1 File Offset: 0x0003D6B1
		public DamageOriannaQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x0003F4C7 File Offset: 0x0003D6C7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOriannaQ.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400075E RID: 1886
		private static readonly double[] damages = new double[]
		{
			60.0,
			90.0,
			120.0,
			150.0,
			180.0
		};
	}
}
