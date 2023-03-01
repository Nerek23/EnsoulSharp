using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000221 RID: 545
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lux", SpellSlot.Q, 0)]
	public class DamageLuxQ : DamageSpell
	{
		// Token: 0x06000C7E RID: 3198 RVA: 0x0003E385 File Offset: 0x0003C585
		public DamageLuxQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0003E39B File Offset: 0x0003C59B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLuxQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000726 RID: 1830
		private static readonly double[] damages = new double[]
		{
			80.0,
			125.0,
			170.0,
			215.0,
			260.0
		};
	}
}
