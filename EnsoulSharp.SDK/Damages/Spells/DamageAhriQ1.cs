using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000114 RID: 276
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ahri", SpellSlot.Q, 1)]
	public class DamageAhriQ1 : DamageSpell
	{
		// Token: 0x0600094B RID: 2379 RVA: 0x00038A4B File Offset: 0x00036C4B
		public DamageAhriQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.True;
			base.Stage = 1;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00038A68 File Offset: 0x00036C68
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAhriQ1.damages[level] + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005FB RID: 1531
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
