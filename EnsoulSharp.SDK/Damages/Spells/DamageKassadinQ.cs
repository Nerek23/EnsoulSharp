using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D7 RID: 471
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kassadin", SpellSlot.Q, 0)]
	public class DamageKassadinQ : DamageSpell
	{
		// Token: 0x06000BA2 RID: 2978 RVA: 0x0003CB68 File Offset: 0x0003AD68
		public DamageKassadinQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0003CB7E File Offset: 0x0003AD7E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKassadinQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006DA RID: 1754
		private static readonly double[] damages = new double[]
		{
			65.0,
			95.0,
			125.0,
			155.0,
			185.0
		};
	}
}
