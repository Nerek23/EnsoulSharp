using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200018F RID: 399
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Garen", SpellSlot.Q, 0)]
	public class DamageGarenQ : DamageSpell
	{
		// Token: 0x06000AC5 RID: 2757 RVA: 0x0003B3F0 File Offset: 0x000395F0
		public DamageGarenQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0003B406 File Offset: 0x00039606
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGarenQ.damages[level] + 0.5 * (double)source.TotalAttackDamage;
		}

		// Token: 0x0400068C RID: 1676
		private static readonly double[] damages = new double[]
		{
			30.0,
			60.0,
			90.0,
			120.0,
			150.0
		};
	}
}
