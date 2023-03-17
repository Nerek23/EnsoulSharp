using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001ED RID: 493
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kennen", SpellSlot.Q, 0)]
	public class DamageKennenQ : DamageSpell
	{
		// Token: 0x06000BE2 RID: 3042 RVA: 0x0003D327 File Offset: 0x0003B527
		public DamageKennenQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0003D33D File Offset: 0x0003B53D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKennenQ.damages[level] + 0.85 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006F0 RID: 1776
		private static readonly double[] damages = new double[]
		{
			75.0,
			125.0,
			175.0,
			225.0,
			275.0
		};
	}
}
