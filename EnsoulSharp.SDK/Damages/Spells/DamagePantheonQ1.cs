using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000264 RID: 612
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pantheon", SpellSlot.Q, 1)]
	public class DamagePantheonQ1 : DamageSpell
	{
		// Token: 0x06000D46 RID: 3398 RVA: 0x0003F8A5 File Offset: 0x0003DAA5
		public DamagePantheonQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0003F8C2 File Offset: 0x0003DAC2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePantheonQ1.damages[Math.Min(17, source.Level - 1)] + 1.15 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400076C RID: 1900
		private static readonly double[] damages = new double[]
		{
			20.0,
			33.0,
			46.0,
			59.0,
			72.0,
			85.0,
			98.0,
			111.0,
			124.0,
			137.0,
			150.0,
			163.0,
			176.0,
			189.0,
			202.0,
			215.0,
			228.0,
			241.0
		};
	}
}
