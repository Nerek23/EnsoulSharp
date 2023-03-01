using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200010A RID: 266
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.Q, 1)]
	public class DamageRellQ1 : DamageSpell
	{
		// Token: 0x0600092D RID: 2349 RVA: 0x000386B1 File Offset: 0x000368B1
		public DamageRellQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000386CE File Offset: 0x000368CE
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellQ1.damages[level] + 0.25 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005EE RID: 1518
		private static readonly double[] damages = new double[]
		{
			35.0,
			52.5,
			70.0,
			87.5,
			105.0
		};
	}
}
