using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000213 RID: 531
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leona", SpellSlot.E, 0)]
	public class DamageLeonaE : DamageSpell
	{
		// Token: 0x06000C54 RID: 3156 RVA: 0x0003DF61 File Offset: 0x0003C161
		public DamageLeonaE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0003DF77 File Offset: 0x0003C177
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeonaE.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000717 RID: 1815
		private static readonly double[] damages = new double[]
		{
			50.0,
			90.0,
			130.0,
			170.0,
			210.0
		};
	}
}
