using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000106 RID: 262
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renata", SpellSlot.Q, 0)]
	public class DamageRenataQ : DamageSpell
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x00038586 File Offset: 0x00036786
		public DamageRenataQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0003859C File Offset: 0x0003679C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenataQ.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005EA RID: 1514
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
