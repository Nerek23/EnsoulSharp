using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000113 RID: 275
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ahri", SpellSlot.Q, 0)]
	public class DamageAhriQ : DamageSpell
	{
		// Token: 0x06000948 RID: 2376 RVA: 0x00038A02 File Offset: 0x00036C02
		public DamageAhriQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00038A18 File Offset: 0x00036C18
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAhriQ.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005FA RID: 1530
		private static readonly double[] damages = new double[]
		{
			40.0,
			65.0,
			90.0,
			115.0,
			140.0
		};
	}
}
