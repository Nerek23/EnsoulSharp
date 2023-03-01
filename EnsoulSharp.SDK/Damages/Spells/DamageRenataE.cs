using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000105 RID: 261
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renata", SpellSlot.E, 0)]
	public class DamageRenataE : DamageSpell
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x0003853D File Offset: 0x0003673D
		public DamageRenataE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00038553 File Offset: 0x00036753
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenataE.damages[level] + 0.55 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005E9 RID: 1513
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
